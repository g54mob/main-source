using System;

internal struct EQXKzqKcqQADVluRyerdTxYPechD : qpYpeINzxEGLIPgRGaGoXOSzeyBH
{
	internal int gNavkshxABbPNhmoZfKZdJPCWhoN;

	internal int EUwgGvplcUPAtidagjfqCcpnyEke;

	private int lwetWUmJoDgKnNxGfQksKVlucJD;

	private int rUOccGhikuLOfpgEgITPgWxELBjC;

	public int RawOffset
	{
		get
		{
			return gNavkshxABbPNhmoZfKZdJPCWhoN;
		}
		set
		{
			gNavkshxABbPNhmoZfKZdJPCWhoN = value;
		}
	}

	public int Value
	{
		get
		{
			return EUwgGvplcUPAtidagjfqCcpnyEke;
		}
		set
		{
			EUwgGvplcUPAtidagjfqCcpnyEke = value;
		}
	}

	public int Timestamp
	{
		get
		{
			return lwetWUmJoDgKnNxGfQksKVlucJD;
		}
		set
		{
			lwetWUmJoDgKnNxGfQksKVlucJD = value;
		}
	}

	public int Sequence
	{
		get
		{
			return rUOccGhikuLOfpgEgITPgWxELBjC;
		}
		set
		{
			rUOccGhikuLOfpgEgITPgWxELBjC = value;
		}
	}

	public qrEjnDBpsfLaOQSXihQkOtzQgir Key => MAymAixOobvoHSCHNZCIlqcKusG(gNavkshxABbPNhmoZfKZdJPCWhoN);

	public bool IsPressed => (EUwgGvplcUPAtidagjfqCcpnyEke & 0x80) != 0;

	public bool IsReleased => !IsPressed;

	private static qrEjnDBpsfLaOQSXihQkOtzQgir MAymAixOobvoHSCHNZCIlqcKusG(int P_0)
	{
		if (Enum.IsDefined(typeof(qrEjnDBpsfLaOQSXihQkOtzQgir), P_0))
		{
			return (qrEjnDBpsfLaOQSXihQkOtzQgir)P_0;
		}
		return qrEjnDBpsfLaOQSXihQkOtzQgir.vCzaCJAEVtIPxCWyepokaLtcMzhL;
	}

	public override string ToString()
	{
		return $"Key: {Key}, IsPressed: {IsPressed} Timestamp: {lwetWUmJoDgKnNxGfQksKVlucJD} Sequence: {rUOccGhikuLOfpgEgITPgWxELBjC}";
	}
}
