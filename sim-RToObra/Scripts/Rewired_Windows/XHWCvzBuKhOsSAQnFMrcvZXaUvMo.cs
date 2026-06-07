using System;
using Rewired.Libraries.SharpDX.DirectInput;

internal struct XHWCvzBuKhOsSAQnFMrcvZXaUvMo : ljBboFKnVnZvPrifuYUjgBZmjtqF
{
	internal int xeneszFMgwgsUEUWpBCICXAZtcHB;

	internal int JdvAUuiZIjqpmuBMKovdOmacUFXr;

	private int gAbgMDARYaozsswqDxujSecdOGy;

	private int gALtmJYUYTHbmRAiQoVEAKmLcGEF;

	public int RawOffset
	{
		get
		{
			return xeneszFMgwgsUEUWpBCICXAZtcHB;
		}
		set
		{
			xeneszFMgwgsUEUWpBCICXAZtcHB = value;
		}
	}

	public int Value
	{
		get
		{
			return JdvAUuiZIjqpmuBMKovdOmacUFXr;
		}
		set
		{
			JdvAUuiZIjqpmuBMKovdOmacUFXr = value;
		}
	}

	public int Timestamp
	{
		get
		{
			return gAbgMDARYaozsswqDxujSecdOGy;
		}
		set
		{
			gAbgMDARYaozsswqDxujSecdOGy = value;
		}
	}

	public int Sequence
	{
		get
		{
			return gALtmJYUYTHbmRAiQoVEAKmLcGEF;
		}
		set
		{
			gALtmJYUYTHbmRAiQoVEAKmLcGEF = value;
		}
	}

	public Key Key
	{
		get
		{
			return FsfxCtDECEABGKrjnJOXnrzVZrxV(xeneszFMgwgsUEUWpBCICXAZtcHB);
		}
	}

	public bool IsPressed
	{
		get
		{
			return (JdvAUuiZIjqpmuBMKovdOmacUFXr & 0x80) != 0;
		}
	}

	public bool IsReleased
	{
		get
		{
			return !IsPressed;
		}
	}

	private static Key FsfxCtDECEABGKrjnJOXnrzVZrxV(int P_0)
	{
		if (Enum.IsDefined(typeof(Key), P_0))
		{
			return (Key)P_0;
		}
		return Key.Unknown;
	}

	public override string ToString()
	{
		return string.Format("Key: {0}, IsPressed: {1} Timestamp: {2} Sequence: {3}", Key, IsPressed, gAbgMDARYaozsswqDxujSecdOGy, gALtmJYUYTHbmRAiQoVEAKmLcGEF);
	}
}
