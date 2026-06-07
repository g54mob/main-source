namespace CLanguage.Tests
{
	public class ArduinoInterpreterTests
	{
		public const string BlinkCode = "\r\nvoid setup() {                \r\n  // initialize the digital pin as an output.\r\n  // Pin 13 has an LED connected on most Arduino boards:\r\n  pinMode(13, OUTPUT);     \r\n}\r\n\r\nvoid loop() {\r\n  digitalWrite(13, HIGH);   // set the LED on\r\n delay(1000);              // wait for 3 seconds\r\n \r\ndigitalWrite(13, LOW);    // set the LED off\r\n delay(1000);              // wait for 3 seconds\r\n}\r\n";

		public const string FadeCode = "\r\nint brightness = 0;    // how bright the LED is\r\nint fadeAmount = 5;    // how many points to fade the LED by\r\n\r\nvoid setup()  { \r\n  // declare pin 9 to be an output:\r\n  pinMode(9, OUTPUT);\r\n} \r\n\r\nvoid loop()  { \r\n  // set the brightness of pin 9:\r\n  analogWrite(9, brightness);    \r\n\r\n  // change the brightness for next time through the loop:\r\n  brightness = brightness + fadeAmount;\r\n\r\n  // reverse the direction of the fading at the ends of the fade: \r\n  if (brightness == 0 || brightness == 255) {\r\n    fadeAmount = -fadeAmount ; \r\n  }     \r\n  // wait for 30 milliseconds to see the dimming effect    \r\n  delay(30);                            \r\n}\r\n";

		private ArduinoMachine.TestArduino Run(string code)
		{
			return null;
		}

		public void Sizes()
		{
		}

		public void Blink()
		{
		}

		public void InternalLocalCtorTest()
		{
		}

		public void InternalGlobalCtorTest()
		{
		}

		public void CallbackVoidIntIntTest()
		{
		}

		public void CallbackIntIntIntTest()
		{
		}

		public void CallbackMemberVoidIntTest()
		{
		}

		public void AnalogReadSerial()
		{
		}

		public void DigitalReadSerial()
		{
		}

		public void DigitalRead()
		{
		}

		public void Fade()
		{
		}

		public void Tone()
		{
		}

		public void Calibration()
		{
		}

		public void StateChangeDetection()
		{
		}

		public void UserBug0()
		{
		}
	}
}
