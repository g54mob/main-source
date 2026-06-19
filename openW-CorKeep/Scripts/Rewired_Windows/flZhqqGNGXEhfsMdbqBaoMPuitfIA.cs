using System;
using System.Runtime.InteropServices;

internal class flZhqqGNGXEhfsMdbqBaoMPuitfIA
{
	private int VGpxwXGKlvYjpNBdDzryYaPWeHSv;

	private byte[] EcfOvjByyrfoTOkQhYoHNdpipPMW;

	public virtual int HEWoFzvEwEgaOBVBpuonkFuinWTtA => VGpxwXGKlvYjpNBdDzryYaPWeHSv;

	protected flZhqqGNGXEhfsMdbqBaoMPuitfIA()
	{
	}

	internal flZhqqGNGXEhfsMdbqBaoMPuitfIA(int P_0, IntPtr P_1)
	{
		OZFeiWeljJUJACyFuAqgWJCCKHBG(P_0, P_1);
	}

	private unsafe void OZFeiWeljJUJACyFuAqgWJCCKHBG(int P_0, IntPtr P_1)
	{
		VGpxwXGKlvYjpNBdDzryYaPWeHSv = P_0;
		if (VGpxwXGKlvYjpNBdDzryYaPWeHSv > 0 && P_1 != IntPtr.Zero)
		{
			EcfOvjByyrfoTOkQhYoHNdpipPMW = new byte[P_0];
			fixed (byte* ecfOvjByyrfoTOkQhYoHNdpipPMW = EcfOvjByyrfoTOkQhYoHNdpipPMW)
			{
				VRhfcElUYIDhtSYXXbsQDsFMgObb.lBZHGQvYjHqJlnMVThPjXLJyLHBD((IntPtr)ecfOvjByyrfoTOkQhYoHNdpipPMW, P_1, VGpxwXGKlvYjpNBdDzryYaPWeHSv);
			}
		}
	}

	protected virtual flZhqqGNGXEhfsMdbqBaoMPuitfIA AtECPddFJYEKMoCpCUZOTIcJEDtx(int P_0, IntPtr P_1)
	{
		OZFeiWeljJUJACyFuAqgWJCCKHBG(P_0, P_1);
		return this;
	}

	internal virtual void zWoPFIAQRNCTNhaBPFOCFrveYeDFc(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr QjsDofGrliiyEYePcFTsVBTNGXgD()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (VGpxwXGKlvYjpNBdDzryYaPWeHSv > 0 && EcfOvjByyrfoTOkQhYoHNdpipPMW != null)
		{
			intPtr = Marshal.AllocHGlobal(VGpxwXGKlvYjpNBdDzryYaPWeHSv);
			fixed (byte* ecfOvjByyrfoTOkQhYoHNdpipPMW = EcfOvjByyrfoTOkQhYoHNdpipPMW)
			{
				VRhfcElUYIDhtSYXXbsQDsFMgObb.lBZHGQvYjHqJlnMVThPjXLJyLHBD(intPtr, (IntPtr)ecfOvjByyrfoTOkQhYoHNdpipPMW, VGpxwXGKlvYjpNBdDzryYaPWeHSv);
			}
		}
		return intPtr;
	}

	public unsafe _0001 CnlTJjfHzhmdaCMABuUAxeZeTspk<_0001>() where _0001 : flZhqqGNGXEhfsMdbqBaoMPuitfIA, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(flZhqqGNGXEhfsMdbqBaoMPuitfIA))
		{
			fixed (byte* ecfOvjByyrfoTOkQhYoHNdpipPMW = EcfOvjByyrfoTOkQhYoHNdpipPMW)
			{
				void* ptr = ecfOvjByyrfoTOkQhYoHNdpipPMW;
				return (_0001)new _0001().AtECPddFJYEKMoCpCUZOTIcJEDtx(VGpxwXGKlvYjpNBdDzryYaPWeHSv, (IntPtr)ptr);
			}
		}
		return null;
	}
}
