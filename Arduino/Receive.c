#include <SoftwareSerial.h>
#include <Wire.h>

SoftwareSerial BT(8, 9);
char val;
 
void setup() {
  Serial.begin(9600);
  BT.begin(9600);
}

boolean canShow = true;

void loop() {

  /*
  int delayTotal = 3;
  
  //test in unity
  Serial.println("y,16.5,17.5,-95.60");
  delay(delayTotal);
  Serial.println("y,17.5,18.5,-95.60");
  delay(delayTotal);
  Serial.println("y,18.69,19.65,-95.60");
  delay(delayTotal);
  Serial.println("y,19.88,20.80,-95.60");
  delay(delayTotal);
  Serial.println("y,20.84,21.25,-95.60");
  delay(delayTotal);
  Serial.println("y,21.89,22.25,-95.60");
  delay(delayTotal);
  Serial.println("y,22.93,23.85,-95.60");
  delay(delayTotal);
  Serial.println("y,23.87,24.60,-95.60");
  delay(delayTotal);
  Serial.println("y,24.86,25.71,-95.60");
  delay(delayTotal);
  Serial.println("y,25.29,26.47,-95.60");
  delay(delayTotal);
  Serial.println("y,26.85,27.89,-95.60");
  delay(delayTotal);
  Serial.println("y,25.29,26.47,-95.60");
  delay(delayTotal);
  Serial.println("y,23.87,24.60,-95.60");*/

  if (Serial.available()) {
    val = Serial.read();
    BT.print(val);
  }
  if (BT.available()) {
    val = BT.read();
    Serial.print(val);
  }
  
}
