using System;
using UnityEngine;

public struct Color6bit
{
	public static Color6bit black = new Color6bit(0);

	public static Color6bit darkBlue = new Color6bit(1);

	public static Color6bit blue = new Color6bit(3);

	public static Color6bit darkGreen = new Color6bit(4);

	public static Color6bit darkCyan = new Color6bit(5);

	public static Color6bit green = new Color6bit(12);

	public static Color6bit cyan = new Color6bit(15);

	public static Color6bit darkRed = new Color6bit(16);

	public static Color6bit darkMagenta = new Color6bit(17);

	public static Color6bit darkYellow = new Color6bit(20);

	public static Color6bit darkGrey = new Color6bit(21);

	public static Color6bit lightGrey = new Color6bit(42);

	public static Color6bit red = new Color6bit(48);

	public static Color6bit magenta = new Color6bit(51);

	public static Color6bit yellow = new Color6bit(60);

	public static Color6bit white = new Color6bit(63);

	private static byte twoBitMask = 3;

	private byte _value;

	private float floatValue;

	private byte _r;

	private byte _g;

	private byte _b;

	public byte Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			_r = (byte)((_value >> 4) & 3);
			_g = (byte)((_value >> 2) & 3);
			_b = (byte)(_value & 3);
			ComputeFloatValues();
		}
	}

	public float FloatValue => floatValue;

	public byte r
	{
		get
		{
			return _r;
		}
		set
		{
			value = Limit(value);
			if (_r != value)
			{
				_r = value;
				ComputeFromRGB();
			}
		}
	}

	public byte g
	{
		get
		{
			return _g;
		}
		set
		{
			value = Limit(value);
			if (_g != value)
			{
				_g = value;
				ComputeFromRGB();
			}
		}
	}

	public byte b
	{
		get
		{
			return _b;
		}
		set
		{
			value = Limit(value);
			if (_b != value)
			{
				_b = value;
				ComputeFromRGB();
			}
		}
	}

	public float floatR
	{
		get
		{
			return (float)(int)_r / 3f;
		}
		set
		{
			value = Mathf.Clamp01(value);
			r = (byte)Mathf.RoundToInt(value * 3f);
		}
	}

	public float floatG
	{
		get
		{
			return (float)(int)_g / 3f;
		}
		set
		{
			value = Mathf.Clamp01(value);
			g = (byte)Mathf.RoundToInt(value * 3f);
		}
	}

	public float floatB
	{
		get
		{
			return (float)(int)_b / 3f;
		}
		set
		{
			value = Mathf.Clamp01(value);
			b = (byte)Mathf.RoundToInt(value * 3f);
		}
	}

	public Color6bit(byte colorValue)
	{
		_r = (byte)((colorValue >> 4) & 3);
		_g = (byte)((colorValue >> 2) & 3);
		_b = (byte)(colorValue & 3);
		_value = colorValue;
		floatValue = (float)(int)_value / 256f;
	}

	public Color6bit(byte red, byte green, byte blue)
	{
		_r = Limit(red);
		_g = Limit(green);
		_b = Limit(blue);
		_value = 0;
		floatValue = 0f;
		ComputeFromRGB();
	}

	public Color6bit(Color color)
	{
		_r = (byte)Mathf.RoundToInt(Mathf.Clamp01(color.r) * 3f);
		_g = (byte)Mathf.RoundToInt(Mathf.Clamp01(color.g) * 3f);
		_b = (byte)Mathf.RoundToInt(Mathf.Clamp01(color.b) * 3f);
		_value = 0;
		floatValue = 0f;
		ComputeFromRGB();
	}

	private static byte Limit(byte v)
	{
		v = ((v > twoBitMask) ? twoBitMask : v);
		if (v >= 0)
		{
			return v;
		}
		return 0;
	}

	private void ComputeFromRGB()
	{
		_value = (byte)((_r << 4) + (_g << 2) + _b);
		ComputeFloatValues();
	}

	private void ComputeFloatValues()
	{
		floatValue = (float)(int)_value / 256f;
	}

	public static Color6bit Lerp(Color6bit a, Color6bit b, float t)
	{
		if (a == b)
		{
			return a;
		}
		byte num = Lerp(a.r, b.r, t);
		byte b2 = Lerp(a.g, b.g, t);
		byte b3 = Lerp(a.b, b.b, t);
		return new Color6bit(num, b2, b3);
	}

	public static byte Lerp(byte a, byte b, float t)
	{
		if (a == b)
		{
			return a;
		}
		return (byte)Mathf.RoundToInt((float)(int)a * (1f - t) + (float)(int)b * t);
	}

	public static bool operator ==(Color6bit a, Color6bit b)
	{
		if ((object)a == (object)b)
		{
			return true;
		}
		return a._value == b._value;
	}

	public static bool operator !=(Color6bit a, Color6bit b)
	{
		return !(a == b);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		try
		{
			Color6bit color6bit = (Color6bit)obj;
			return _value == color6bit._value;
		}
		catch (InvalidCastException)
		{
			return false;
		}
	}

	public override int GetHashCode()
	{
		return _value;
	}
}
