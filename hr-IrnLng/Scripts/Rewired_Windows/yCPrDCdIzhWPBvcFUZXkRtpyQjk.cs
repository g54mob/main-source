using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class yCPrDCdIzhWPBvcFUZXkRtpyQjk : jTTnjFcmJNutQYLpCwPogAkUWGz
{
	[CompilerGenerated]
	private int nlxydQyMgmNfYIkZLfxAegmoYhtr;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return nlxydQyMgmNfYIkZLfxAegmoYhtr;
		}
		[CompilerGenerated]
		set
		{
			nlxydQyMgmNfYIkZLfxAegmoYhtr = value;
		}
	}

	public override int Size => JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<YUxMDDmLpfdrwylTUgkVapOBKDC>();

	protected unsafe override jTTnjFcmJNutQYLpCwPogAkUWGz aRreqoecxmLuIAlYVRIPwMKrCMT(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(YUxMDDmLpfdrwylTUgkVapOBKDC))
		{
			return null;
		}
		Magnitude = ((YUxMDDmLpfdrwylTUgkVapOBKDC*)(void*)P_1)->HrvHolcikWHXZaApwdSgVSxbbzRN;
		return this;
	}

	internal unsafe override IntPtr diiFuCizNlbWbcWAcnolWnmjPwtB()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((YUxMDDmLpfdrwylTUgkVapOBKDC*)(void*)intPtr)->HrvHolcikWHXZaApwdSgVSxbbzRN = Magnitude;
		return intPtr;
	}
}
