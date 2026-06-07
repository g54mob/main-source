using System;

public struct ControllerPacket : ICloneable
{
	public float leftStickX;

	public float leftStickY;

	public float rightStickX;

	public float rightStickY;

	public bool leftStickPressed;

	public bool rightStickPressed;

	public bool butX;

	public bool butY;

	public bool butA;

	public bool butB;

	public bool up;

	public bool down;

	public bool left;

	public bool right;

	public bool leftBumper;

	public float leftTrigger;

	public bool rightBumper;

	public float rightTrigger;

	public bool pause;

	public bool back;

	public bool NonZeroLeftStick;

	private static ControllerPacket _empty;

	public static ControllerPacket Empty => (ControllerPacket)_empty.Clone();

	public object Clone()
	{
		return MemberwiseClone();
	}
}
