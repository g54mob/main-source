using System.Globalization;
using System.Runtime.CompilerServices;

internal struct BcULecnbJOYisVDznNGumjicoPO : qpYpeINzxEGLIPgRGaGoXOSzeyBH
{
	[CompilerGenerated]
	private int rTerJnrEkEZFazIiEPpfaGuYtGz;

	[CompilerGenerated]
	private int glqnAFHEETFcahHnfxhgkkVKaH;

	[CompilerGenerated]
	private int qHONNnVZlldSannAIGfpsjmCFQd;

	[CompilerGenerated]
	private int tXFrRxneqmgsJGnZNYPcrgmQaCjt;

	public int RawOffset
	{
		[CompilerGenerated]
		get
		{
			return rTerJnrEkEZFazIiEPpfaGuYtGz;
		}
		[CompilerGenerated]
		set
		{
			rTerJnrEkEZFazIiEPpfaGuYtGz = value;
		}
	}

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return glqnAFHEETFcahHnfxhgkkVKaH;
		}
		[CompilerGenerated]
		set
		{
			glqnAFHEETFcahHnfxhgkkVKaH = value;
		}
	}

	public int Timestamp
	{
		[CompilerGenerated]
		get
		{
			return qHONNnVZlldSannAIGfpsjmCFQd;
		}
		[CompilerGenerated]
		set
		{
			qHONNnVZlldSannAIGfpsjmCFQd = value;
		}
	}

	public int Sequence
	{
		[CompilerGenerated]
		get
		{
			return tXFrRxneqmgsJGnZNYPcrgmQaCjt;
		}
		[CompilerGenerated]
		set
		{
			tXFrRxneqmgsJGnZNYPcrgmQaCjt = value;
		}
	}

	public LRYSHKbThRAxcQfQZYKvTAwphcx Offset => (LRYSHKbThRAxcQfQZYKvTAwphcx)RawOffset;

	public bool IsButton
	{
		get
		{
			if (Offset >= LRYSHKbThRAxcQfQZYKvTAwphcx.iBuknEloRUrWSskvjaWhGBuFECf)
			{
				return Offset <= LRYSHKbThRAxcQfQZYKvTAwphcx.NKQbnazyWNMsYfRdTmFPcXaIbwi;
			}
			return false;
		}
	}

	public override string ToString()
	{
		object obj = ((Offset < LRYSHKbThRAxcQfQZYKvTAwphcx.iBuknEloRUrWSskvjaWhGBuFECf) ? ((object)Value) : ((object)((Value & 0x80) != 0)));
		return string.Format(CultureInfo.InvariantCulture, "Offset: {0}, Value: {1} Timestamp: {2} Sequence: {3}", Offset, obj, Timestamp, Sequence);
	}
}
