using System;
using Rewired.Libraries.SharpDX.DirectInput;

internal struct RryiXLNEqnrrVJXCpnreQZryxLA : hqppqxEFMrkdOneNLCGrQSVQngm
{
	internal int xoDhYRyoootuTZfiMKWIQWSrgWJ;

	internal int NZRLUDiCvWuxMAkrOrrwreCYVVb;

	private int wWVJHrdPYiqspppSegjhJYwRUoy;

	private int sNvfHndYAZmahUPOrPBIPtitOfG;

	public int RawOffset
	{
		get
		{
			return xoDhYRyoootuTZfiMKWIQWSrgWJ;
		}
		set
		{
			xoDhYRyoootuTZfiMKWIQWSrgWJ = value;
		}
	}

	public int Value
	{
		get
		{
			return NZRLUDiCvWuxMAkrOrrwreCYVVb;
		}
		set
		{
			NZRLUDiCvWuxMAkrOrrwreCYVVb = value;
		}
	}

	public int Timestamp
	{
		get
		{
			return wWVJHrdPYiqspppSegjhJYwRUoy;
		}
		set
		{
			wWVJHrdPYiqspppSegjhJYwRUoy = value;
		}
	}

	public int Sequence
	{
		get
		{
			return sNvfHndYAZmahUPOrPBIPtitOfG;
		}
		set
		{
			sNvfHndYAZmahUPOrPBIPtitOfG = value;
		}
	}

	public Key Key
	{
		get
		{
			return LAHDHNsQYGCJjkDCUAdFypglxzv(xoDhYRyoootuTZfiMKWIQWSrgWJ);
		}
	}

	public bool IsPressed
	{
		get
		{
			return (NZRLUDiCvWuxMAkrOrrwreCYVVb & 0x80) != 0;
		}
	}

	public bool IsReleased
	{
		get
		{
			return !IsPressed;
		}
	}

	private static Key LAHDHNsQYGCJjkDCUAdFypglxzv(int P_0)
	{
		if (Enum.IsDefined(typeof(Key), P_0))
		{
			return (Key)P_0;
		}
		return Key.Unknown;
	}

	public override string ToString()
	{
		return string.Format("Key: {0}, IsPressed: {1} Timestamp: {2} Sequence: {3}", Key, IsPressed, wWVJHrdPYiqspppSegjhJYwRUoy, sNvfHndYAZmahUPOrPBIPtitOfG);
	}
}
