void setup() {
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
}

bool genChange = false;
long previousTime = millis();
long milli = 100;

String message = "1";
void loop() {



  
  if (Serial.available() > 0){
      message = Serial.readString();
      message.trim();
      milli = message.toInt();
  }




  
  if(SquareGenerator(milli, 100, millis())){
    if(!genChange) {
        genChange = true;
        digitalWrite(9, HIGH);
    }
  } else {
    if(genChange) {
        genChange = false;
        digitalWrite(9, LOW);
    }
  }
}

//       Interval  Length   
//            /_____/             _____
//            |     |            |     |
//            |     |            |     |
//------------       ------------       ------------
bool SquareGenerator(float interval, long length, long time)
{
    long offset = time - previousTime;
    if (offset >= interval) {
        if (interval + length <= offset) {
            previousTime = time;
            return false;
        }
        return true;
    }

    return false;
}
