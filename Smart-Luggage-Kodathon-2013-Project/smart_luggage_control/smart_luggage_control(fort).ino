#include <PID_v1.h>

#define dypIn A0 // Echo Pin
#define dypOut 7
#define mzIn A1

// Motor pinleri
const int motSagOn = 11;
const int motSolOn = 10;
const int motSolArka = 9;
const int motSagArka = 6;

// Pid degiskenleri
int distance[2] = {0, 0};
double error[2] = {0, 0};
double output[2] = {0, 0};
double refDiff = 0;
double refDist = 0;

// Motor kontrol degiskenleri
int motSag = 0;
int motSol = 0;
int offsetSag = 70;
int offsetSol = 40;
// Pid objeleri
PID pid1(&error[0], &output[0], &refDiff, 6.0, 0.1, 0.0, DIRECT);
PID pid2(&error[1], &output[1], &refDist, 1.5, 0.4, 0.0, DIRECT);

void setup() {
  Serial.begin(9600);
  
  // Pin ayarlari
  pinMode(dypOut, OUTPUT);
  pinMode(dypIn, INPUT);
  pinMode(mzIn, INPUT);
  
  // Pid ayarlari
  pid1.SetMode(AUTOMATIC);
  pid2.SetMode(AUTOMATIC);
  pid1.SetOutputLimits(-255, 255);
  pid2.SetOutputLimits(0, 255);
  
  // Motorlar hep ileri
  analogWrite(motSagArka, 0);
  analogWrite(motSolArka, 0);
}

void loop() {
  // Sensorleri oku ve hatalari hesapla
  getDyp();
  getError();
  
  // Pidleri hesapla
  pid1.Compute();
  pid2.Compute();

  // Motor kontrollerini hesapla
  motSag = constrain((offsetSag + output[1] + output[0]), 0, 255);
  motSol = constrain((offsetSol + output[1] - output[0]), 0, 255);
  motor(motSol, motSag);
  
  Serial.print(distance[0]);
  Serial.print(" - ");
  Serial.println(distance[1]);
  
  /*
  Serial.println("----------");
  Serial.print(error[0]);
  Serial.print(" - ");
  Serial.println(output[0]);
  Serial.print(error[1]);
  Serial.print(" - ");
  Serial.println(output[1]);
  */
  
  delay(300);
}

void getDyp(){
  int pulseTime1 = 0;
  int pulseTime2 = 0;
  
  digitalWrite(dypOut,LOW);
  delayMicroseconds(2);  
  digitalWrite(dypOut,HIGH);
  delayMicroseconds(10);
  digitalWrite(dypOut,LOW);
  distance[0] = (pulseIn(mzIn,HIGH,10000) / 5.8);
  distance[1] = (24000/(analogRead(dypIn)-20));
  
  distance[0] = constrain(distance[0], 0, 300);
  if (distance[1] < 0)
  {
    distance[1] = 300;
    if (distance[0] == 300) {
      distance[0] = 0;
      distance[1] = 0;
    }
  }
}

void getError() {
  error[0] = distance[0] - distance[1];
  error[1] = 150 - ((distance[0] + distance[1]) / 2);
}

void motor(int sol, int sag) {
  analogWrite(motSagOn, sol);
  analogWrite(motSolOn, sag);
  delay(1000);
}
