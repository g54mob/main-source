using System;
using System.Runtime.InteropServices;

internal class MTDdOUAQDDlORdpeJZWconHqnhGgA
{
	private int oBnDjjEEippHHWUwjcVmFGRKJofG;

	private byte[] vCbzVXRBpduZjVcXHglDIAfoTLvSA;

	public virtual int ckSYfNvnjCgLabGSZghzoKsihUeEA => oBnDjjEEippHHWUwjcVmFGRKJofG;

	protected MTDdOUAQDDlORdpeJZWconHqnhGgA()
	{
	}

	internal MTDdOUAQDDlORdpeJZWconHqnhGgA(int P_0, IntPtr P_1)
	{
		jHLGpIcikLilaJblYiDyGNJKuAaMA(P_0, P_1);
	}

	private unsafe void jHLGpIcikLilaJblYiDyGNJKuAaMA(int P_0, IntPtr P_1)
	{
		oBnDjjEEippHHWUwjcVmFGRKJofG = P_0;
		if (oBnDjjEEippHHWUwjcVmFGRKJofG > 0 && P_1 != IntPtr.Zero)
		{
			vCbzVXRBpduZjVcXHglDIAfoTLvSA = new byte[P_0];
			fixed (byte* ptr = vCbzVXRBpduZjVcXHglDIAfoTLvSA)
			{
				klLdHAhsLOLqXXQXtowmGbeHymvN.YWRxEuxdXPFHNctXvomvIDJsuVkx((IntPtr)ptr, P_1, oBnDjjEEippHHWUwjcVmFGRKJofG);
			}
		}
	}

	protected virtual MTDdOUAQDDlORdpeJZWconHqnhGgA jPCaaZfEVUfEsfuOgMkYSctDZEID(int P_0, IntPtr P_1)
	{
		jHLGpIcikLilaJblYiDyGNJKuAaMA(P_0, P_1);
		return this;
	}

	internal virtual void KRsvfyWHODHixIrUnFXQbspKYwgAc(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr poujARCIsiDLsBGUUADcIHLXDWXP()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (oBnDjjEEippHHWUwjcVmFGRKJofG > 0 && vCbzVXRBpduZjVcXHglDIAfoTLvSA != null)
		{
			intPtr = Marshal.AllocHGlobal(oBnDjjEEippHHWUwjcVmFGRKJofG);
			fixed (byte* ptr = vCbzVXRBpduZjVcXHglDIAfoTLvSA)
			{
				klLdHAhsLOLqXXQXtowmGbeHymvN.YWRxEuxdXPFHNctXvomvIDJsuVkx(intPtr, (IntPtr)ptr, oBnDjjEEippHHWUwjcVmFGRKJofG);
			}
		}
		return intPtr;
	}

	public unsafe _0001 pBhtjZbzojcSKXuFrIbAisFwiTEW<_0001>() where _0001 : MTDdOUAQDDlORdpeJZWconHqnhGgA, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(MTDdOUAQDDlORdpeJZWconHqnhGgA))
		{
			fixed (byte* ptr = vCbzVXRBpduZjVcXHglDIAfoTLvSA)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().jPCaaZfEVUfEsfuOgMkYSctDZEID(oBnDjjEEippHHWUwjcVmFGRKJofG, (IntPtr)ptr2);
			}
		}
		return null;
	}
}
