using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class bNmozGYGnBLzHvCJKUWzVIsCYvwB : flZhqqGNGXEhfsMdbqBaoMPuitfIA
{
	[CompilerGenerated]
	private LrHSiahGkFldCzCfeyPuVHWIAzQu[] heejCTQQRBOYTEoDlaxegDFNPtWr;

	public LrHSiahGkFldCzCfeyPuVHWIAzQu[] sydearYDWPAKKJjBbDCfAdrZOluLA
	{
		[CompilerGenerated]
		get
		{
			return heejCTQQRBOYTEoDlaxegDFNPtWr;
		}
		[CompilerGenerated]
		set
		{
			heejCTQQRBOYTEoDlaxegDFNPtWr = array;
		}
	}

	unsafe int flZhqqGNGXEhfsMdbqBaoMPuitfIA.HEWoFzvEwEgaOBVBpuonkFuinWTtA
	{
		get
		{
			if (sydearYDWPAKKJjBbDCfAdrZOluLA == null)
			{
				return 0;
			}
			return sydearYDWPAKKJjBbDCfAdrZOluLA.Length * sizeof(LrHSiahGkFldCzCfeyPuVHWIAzQu);
		}
	}

	protected unsafe virtual flZhqqGNGXEhfsMdbqBaoMPuitfIA MYyYacTtVsJNDkfdTcehbxbGCcGd(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(LrHSiahGkFldCzCfeyPuVHWIAzQu) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(LrHSiahGkFldCzCfeyPuVHWIAzQu);
		sydearYDWPAKKJjBbDCfAdrZOluLA = new LrHSiahGkFldCzCfeyPuVHWIAzQu[num];
		fixed (LrHSiahGkFldCzCfeyPuVHWIAzQu* ptr = sydearYDWPAKKJjBbDCfAdrZOluLA)
		{
			VRhfcElUYIDhtSYXXbsQDsFMgObb.lBZHGQvYjHqJlnMVThPjXLJyLHBD((IntPtr)ptr, P_1, VRhfcElUYIDhtSYXXbsQDsFMgObb.SMbLtcBgTmiVeQQXRwhsKdNWLAkr<LrHSiahGkFldCzCfeyPuVHWIAzQu>() * sydearYDWPAKKJjBbDCfAdrZOluLA.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr XffhDicFzaDXIOfnLFJOFYLRBgzK()
	{
		if (HEWoFzvEwEgaOBVBpuonkFuinWTtA == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(HEWoFzvEwEgaOBVBpuonkFuinWTtA);
		fixed (LrHSiahGkFldCzCfeyPuVHWIAzQu* ptr = sydearYDWPAKKJjBbDCfAdrZOluLA)
		{
			VRhfcElUYIDhtSYXXbsQDsFMgObb.lBZHGQvYjHqJlnMVThPjXLJyLHBD(intPtr, (IntPtr)ptr, VRhfcElUYIDhtSYXXbsQDsFMgObb.SMbLtcBgTmiVeQQXRwhsKdNWLAkr<LrHSiahGkFldCzCfeyPuVHWIAzQu>() * sydearYDWPAKKJjBbDCfAdrZOluLA.Length);
		}
		return intPtr;
	}
}
