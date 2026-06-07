using System;
using System.Runtime.InteropServices;

internal class OAsaOhivNnJJcaXGgqiIbGrVdCbmc
{
	private int ysCVhgwPyouDCzHtxFChCdzjCrPl;

	private byte[] njPEqelkqUAXHcVOBySkfuuGgySaA;

	public virtual int woNJXLkWwUOBugYfuMGynSMoksFi => ysCVhgwPyouDCzHtxFChCdzjCrPl;

	protected OAsaOhivNnJJcaXGgqiIbGrVdCbmc()
	{
	}

	internal OAsaOhivNnJJcaXGgqiIbGrVdCbmc(int P_0, IntPtr P_1)
	{
		WCFFzsHtLWMKfhauyUvHRdaBsqRcA(P_0, P_1);
	}

	private unsafe void WCFFzsHtLWMKfhauyUvHRdaBsqRcA(int P_0, IntPtr P_1)
	{
		ysCVhgwPyouDCzHtxFChCdzjCrPl = P_0;
		if (ysCVhgwPyouDCzHtxFChCdzjCrPl > 0 && P_1 != IntPtr.Zero)
		{
			njPEqelkqUAXHcVOBySkfuuGgySaA = new byte[P_0];
			fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
			{
				egeTdzIGHudlgfKlEvWOdRMMLrIl.XzyKQtjTUtOkyLWLbIpJnkSlLGhP((IntPtr)ptr, P_1, ysCVhgwPyouDCzHtxFChCdzjCrPl);
			}
		}
	}

	protected virtual OAsaOhivNnJJcaXGgqiIbGrVdCbmc PWrFUHxdERHkATtEfEdKOHdOSVib(int P_0, IntPtr P_1)
	{
		WCFFzsHtLWMKfhauyUvHRdaBsqRcA(P_0, P_1);
		return this;
	}

	internal virtual void dOFMTjStEQdUcCXEfdjdxerkdDOFA(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr MoFcJaajRNOlFTgfBbaVBVnkDofXA()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (ysCVhgwPyouDCzHtxFChCdzjCrPl > 0 && njPEqelkqUAXHcVOBySkfuuGgySaA != null)
		{
			intPtr = Marshal.AllocHGlobal(ysCVhgwPyouDCzHtxFChCdzjCrPl);
			fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
			{
				egeTdzIGHudlgfKlEvWOdRMMLrIl.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(intPtr, (IntPtr)ptr, ysCVhgwPyouDCzHtxFChCdzjCrPl);
			}
		}
		return intPtr;
	}

	public unsafe _0001 sQiAnFibenPEcGYnNJJqwIRjDIFkA<_0001>() where _0001 : OAsaOhivNnJJcaXGgqiIbGrVdCbmc, new()
	{
		if ((object)GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if ((object)GetType() == typeof(OAsaOhivNnJJcaXGgqiIbGrVdCbmc))
		{
			fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().PWrFUHxdERHkATtEfEdKOHdOSVib(ysCVhgwPyouDCzHtxFChCdzjCrPl, (IntPtr)ptr2);
			}
		}
		return null;
	}
}
