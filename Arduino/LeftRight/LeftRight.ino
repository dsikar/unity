/*
  Arduino and Unity interaction as described
  in https://www.youtube.com/watch?v=of_oLAvWfSI
*/

const int buttonPin01 = 6;
const int buttonPin02 = 7;

void setup() 
{
  Serial.begin(9600);

  pinMode(buttonPin01, INPUT);
  pinMode(buttonPin02, INPUT);

  digitalWrite(buttonPin01, HIGH);
  digitalWrite(buttonPin02, HIGH);
}

void loop() 
{
  // Read left
  if(digitalRead(buttonPin01) == LOW)
  {
    // Serial.println for arduino serial monitor
    // Serial.println("Left");
    // Serial.write for unity
    Serial.write(1);
    Serial.flush();
    delay(20);
  }
  // Read right
  if(digitalRead(buttonPin02) == LOW)
  {
    // Serial.println("Right");
    Serial.write(2);
    Serial.flush();
    delay(20);
  }
}
