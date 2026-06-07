using UnityEngine;

public struct ColorHSV
{
	public float h;

	public float s;

	public float v;

	public float a;

	public ColorHSV(float h, float s, float v, float a)
	{
		this.h = 0f;
		this.s = 0f;
		this.v = 0f;
		this.a = 0f;
	}

	public override string ToString()
	{
		return null;
	}

	public static bool operator ==(ColorHSV lhs, ColorHSV rhs)
	{
		return false;
	}

	public static implicit operator ColorHSV(Color c)
	{
		return default(ColorHSV);
	}

	public static implicit operator Color(ColorHSV hsv)
	{
		return default(Color);
	}

	public static implicit operator ColorHSV(Color32 c32)
	{
		return default(ColorHSV);
	}

	public static implicit operator Color32(ColorHSV hsv)
	{
		return default(Color32);
	}

	public static bool operator !=(ColorHSV lhs, ColorHSV rhs)
	{
		return false;
	}

	public override bool Equals(object other)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public Color ToRGB()
	{
		return default(Color);
	}

	private static Vector3 HUEtoRGB(float h)
	{
		return default(Vector3);
	}
}
