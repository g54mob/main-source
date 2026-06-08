using System;
using Rewired.Libraries.SharpDX.DirectInput;

internal struct QXXqsQNLwFEZxCDlRmmahPwwxjwS : sICszkYwpNiWijkjbVFpRqgCSlS
{
	internal int iheXxAuZSEhTnXIAmmTABgdlXkj;

	internal int CbigNTsukThQPOzMZKybwcHUxLr;

	private int xdmAJsfTsGwAFbRaKbbziORJkMWx;

	private int zAGCjeDtsvAYNlYyLPCYOYBvEIkh;

	public int RawOffset
	{
		get
		{
			return iheXxAuZSEhTnXIAmmTABgdlXkj;
		}
		set
		{
			iheXxAuZSEhTnXIAmmTABgdlXkj = value;
		}
	}

	public int Value
	{
		get
		{
			return CbigNTsukThQPOzMZKybwcHUxLr;
		}
		set
		{
			CbigNTsukThQPOzMZKybwcHUxLr = value;
		}
	}

	public int Timestamp
	{
		get
		{
			return xdmAJsfTsGwAFbRaKbbziORJkMWx;
		}
		set
		{
			xdmAJsfTsGwAFbRaKbbziORJkMWx = value;
		}
	}

	public int Sequence
	{
		get
		{
			return zAGCjeDtsvAYNlYyLPCYOYBvEIkh;
		}
		set
		{
			zAGCjeDtsvAYNlYyLPCYOYBvEIkh = value;
		}
	}

	public Key Key => ATcfHYufwqmebwjpkeHRkhClbvXM(iheXxAuZSEhTnXIAmmTABgdlXkj);

	public bool IsPressed => (CbigNTsukThQPOzMZKybwcHUxLr & 0x80) != 0;

	public bool IsReleased => !IsPressed;

	private static Key ATcfHYufwqmebwjpkeHRkhClbvXM(int P_0)
	{
		if (Enum.IsDefined(typeof(Key), P_0))
		{
			return (Key)P_0;
		}
		return Key.Unknown;
	}

	public override string ToString()
	{
		return $"Key: {Key}, IsPressed: {IsPressed} Timestamp: {xdmAJsfTsGwAFbRaKbbziORJkMWx} Sequence: {zAGCjeDtsvAYNlYyLPCYOYBvEIkh}";
	}
}
