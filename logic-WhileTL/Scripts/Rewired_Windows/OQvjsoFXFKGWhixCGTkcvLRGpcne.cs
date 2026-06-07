using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class OQvjsoFXFKGWhixCGTkcvLRGpcne : WiYghzZHRAokAnfKraYOEYKyMWlhA
{
	[CompilerGenerated]
	private cPGTjpqObWCypmAWalOQdTTEeUGW[] PFywwWSNevCvFNVSJmOHwKDHeiGb;

	public cPGTjpqObWCypmAWalOQdTTEeUGW[] BgjeZsinOnqlXaOfbVnGrCKHCulyA
	{
		[CompilerGenerated]
		get
		{
			return PFywwWSNevCvFNVSJmOHwKDHeiGb;
		}
		[CompilerGenerated]
		set
		{
			PFywwWSNevCvFNVSJmOHwKDHeiGb = pFywwWSNevCvFNVSJmOHwKDHeiGb;
		}
	}

	unsafe int WiYghzZHRAokAnfKraYOEYKyMWlhA.cfckFHAeKtxOuKnldkennpJlaHxB
	{
		get
		{
			if (BgjeZsinOnqlXaOfbVnGrCKHCulyA == null)
			{
				return 0;
			}
			return BgjeZsinOnqlXaOfbVnGrCKHCulyA.Length * sizeof(cPGTjpqObWCypmAWalOQdTTEeUGW);
		}
	}

	protected unsafe override WiYghzZHRAokAnfKraYOEYKyMWlhA ZJamvOBqlragIzEdiIujKsgZJGRQ(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(cPGTjpqObWCypmAWalOQdTTEeUGW) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(cPGTjpqObWCypmAWalOQdTTEeUGW);
		BgjeZsinOnqlXaOfbVnGrCKHCulyA = new cPGTjpqObWCypmAWalOQdTTEeUGW[num];
		fixed (cPGTjpqObWCypmAWalOQdTTEeUGW* ptr = BgjeZsinOnqlXaOfbVnGrCKHCulyA)
		{
			qUbotaSLZASADLtRbuWjzvVhFURA.NsKFffFPSKzDQTlXyLHVFzjeGUrUA((IntPtr)ptr, P_1, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<cPGTjpqObWCypmAWalOQdTTEeUGW>() * BgjeZsinOnqlXaOfbVnGrCKHCulyA.Length);
		}
		return this;
	}

	internal unsafe override IntPtr QChgzcSTHmUHtfpVMOcTJIItokbl()
	{
		if (cfckFHAeKtxOuKnldkennpJlaHxB == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(cfckFHAeKtxOuKnldkennpJlaHxB);
		fixed (cPGTjpqObWCypmAWalOQdTTEeUGW* ptr = BgjeZsinOnqlXaOfbVnGrCKHCulyA)
		{
			qUbotaSLZASADLtRbuWjzvVhFURA.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(intPtr, (IntPtr)ptr, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<cPGTjpqObWCypmAWalOQdTTEeUGW>() * BgjeZsinOnqlXaOfbVnGrCKHCulyA.Length);
		}
		return intPtr;
	}
}
