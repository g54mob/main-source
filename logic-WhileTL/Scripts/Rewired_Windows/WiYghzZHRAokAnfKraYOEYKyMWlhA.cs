using System;
using System.Runtime.InteropServices;

internal class WiYghzZHRAokAnfKraYOEYKyMWlhA
{
	private int wywqsgGelHZyHDdDmjJvCCOkChVe;

	private byte[] pshxLsVBaxPobdRQOPmmlqHPIgYt;

	public virtual int cfckFHAeKtxOuKnldkennpJlaHxB => wywqsgGelHZyHDdDmjJvCCOkChVe;

	protected WiYghzZHRAokAnfKraYOEYKyMWlhA()
	{
	}

	internal WiYghzZHRAokAnfKraYOEYKyMWlhA(int P_0, IntPtr P_1)
	{
		WuflAoNgHfNrTWAitlHTduHQRmXo(P_0, P_1);
	}

	private unsafe void WuflAoNgHfNrTWAitlHTduHQRmXo(int P_0, IntPtr P_1)
	{
		wywqsgGelHZyHDdDmjJvCCOkChVe = P_0;
		if (wywqsgGelHZyHDdDmjJvCCOkChVe > 0 && P_1 != IntPtr.Zero)
		{
			pshxLsVBaxPobdRQOPmmlqHPIgYt = new byte[P_0];
			fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
			{
				qUbotaSLZASADLtRbuWjzvVhFURA.NsKFffFPSKzDQTlXyLHVFzjeGUrUA((IntPtr)ptr, P_1, wywqsgGelHZyHDdDmjJvCCOkChVe);
			}
		}
	}

	protected virtual WiYghzZHRAokAnfKraYOEYKyMWlhA ZJamvOBqlragIzEdiIujKsgZJGRQ(int P_0, IntPtr P_1)
	{
		WuflAoNgHfNrTWAitlHTduHQRmXo(P_0, P_1);
		return this;
	}

	internal virtual void xjlGqfDmYpifEewQmgFddxGHzLKwB(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr QChgzcSTHmUHtfpVMOcTJIItokbl()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (wywqsgGelHZyHDdDmjJvCCOkChVe > 0 && pshxLsVBaxPobdRQOPmmlqHPIgYt != null)
		{
			intPtr = Marshal.AllocHGlobal(wywqsgGelHZyHDdDmjJvCCOkChVe);
			fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
			{
				qUbotaSLZASADLtRbuWjzvVhFURA.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(intPtr, (IntPtr)ptr, wywqsgGelHZyHDdDmjJvCCOkChVe);
			}
		}
		return intPtr;
	}

	public unsafe _0001 uHWEsLQkWIffMgjOUvRmmuiiSYRE<_0001>() where _0001 : WiYghzZHRAokAnfKraYOEYKyMWlhA, new()
	{
		if ((object)GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if ((object)GetType() == typeof(WiYghzZHRAokAnfKraYOEYKyMWlhA))
		{
			fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().ZJamvOBqlragIzEdiIujKsgZJGRQ(wywqsgGelHZyHDdDmjJvCCOkChVe, (IntPtr)ptr2);
			}
		}
		return null;
	}
}
