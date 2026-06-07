using System;
using Simulation;

public class ArduinoCodeBase
{
	public ArduinoElm arduinoElm;

	public const int HIGH = 1;

	public const int LOW = 0;

	public const int INPUT = 0;

	public const int OUTPUT = 1;

	public const int INPUT_PULLUP = 2;

	public const double PI = Math.PI;

	public const double HALF_PI = Math.PI / 2.0;

	public const double TWO_PI = Math.PI * 2.0;

	public const double DEG_TO_RAD = Math.PI / 180.0;

	public const double RAD_TO_DEG = 180.0 / Math.PI;

	public const double EULER = Math.E;

	public const int SERIAL = 0;

	public const int DISPLAY = 1;

	public const int LSBFIRST = 0;

	public const int MSBFIRST = 1;

	public const int CHANGE = 1;

	public const int FALLING = 2;

	public const int RISING = 3;

	private double setupTime;

	private double elapsedTime;

	public virtual void CallSetup()
	{
	}

	public virtual void CallLoop()
	{
	}

	protected void pinMode(int pin, int mode)
	{
	}

	protected void digitalWrite(int pin, int value)
	{
	}

	protected ulong millis()
	{
		return 0uL;
	}

	protected void tone(int pin, int frequency)
	{
	}

	protected void tone(int pin, int frequency, int duration)
	{
	}

	protected void noTone(int pin)
	{
	}
}
