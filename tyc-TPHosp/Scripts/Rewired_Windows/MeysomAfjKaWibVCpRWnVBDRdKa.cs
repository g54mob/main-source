using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MeysomAfjKaWibVCpRWnVBDRdKa : efmrLSrolSjovsfxfjCVLLJRnGz
{
	[CompilerGenerated]
	private int nSEElrIDvDJBvLSlzKjHuzjlXyRF;

	[CompilerGenerated]
	private int dPNuEMqDCBslAAgauCdVDwcbUnbh;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return nSEElrIDvDJBvLSlzKjHuzjlXyRF;
		}
		[CompilerGenerated]
		set
		{
			nSEElrIDvDJBvLSlzKjHuzjlXyRF = value;
		}
	}

	public int End
	{
		[CompilerGenerated]
		get
		{
			return dPNuEMqDCBslAAgauCdVDwcbUnbh;
		}
		[CompilerGenerated]
		set
		{
			dPNuEMqDCBslAAgauCdVDwcbUnbh = value;
		}
	}

	public override int Size => QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<jViLmghoSWRRLmESzzGJYxujKst>();

	protected unsafe override efmrLSrolSjovsfxfjCVLLJRnGz jgUKJdlhVlbmjmcGcqukHIxicKDF(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(jViLmghoSWRRLmESzzGJYxujKst))
		{
			return null;
		}
		Start = ((jViLmghoSWRRLmESzzGJYxujKst*)(void*)P_1)->ZWHXmzFoPzsdydQwCbiSIgZvLxH;
		End = ((jViLmghoSWRRLmESzzGJYxujKst*)(void*)P_1)->LLWHKrpmvvlBHBJIntnWFFYFjIR;
		return this;
	}

	internal unsafe override IntPtr ytPODbihcgKkYwOfQIFAEFNEgkj()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((jViLmghoSWRRLmESzzGJYxujKst*)(void*)intPtr)->ZWHXmzFoPzsdydQwCbiSIgZvLxH = Start;
		((jViLmghoSWRRLmESzzGJYxujKst*)(void*)intPtr)->LLWHKrpmvvlBHBJIntnWFFYFjIR = End;
		return intPtr;
	}
}
