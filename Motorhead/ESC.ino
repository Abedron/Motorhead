#include <Servo.h>

Servo ESC;     // create servo object to control the ESC

void setup() {
  ESC.writeMicroseconds(180); //initialize the signal to 1000
  ESC.attach(9,1000,2000); // (pin, min pulse width, max pulse width in microseconds) 
}

void loop() {
  ESC.write(90);    // Send the signal to the ESC
}
