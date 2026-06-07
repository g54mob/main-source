using System;
using System.Runtime.InteropServices;

internal class uiIFGbFnfmeNgclXAVjyNHmstSYCB
{
	private int KgoDgYtFAGczqYwNzDYadHoDwpdi;

	private byte[] LXewBgedHWMAMHPgREGPwSKnAcdiA;

	public virtual int YvNwnaANRlPKFYvzJdKlkyBxuraS => KgoDgYtFAGczqYwNzDYadHoDwpdi;

	protected uiIFGbFnfmeNgclXAVjyNHmstSYCB()
	{
	}

	internal uiIFGbFnfmeNgclXAVjyNHmstSYCB(int P_0, IntPtr P_1)
	{
		RmSMOtBhUqciLHZQEqmydYkDBlcn(P_0, P_1);
	}

	private unsafe void RmSMOtBhUqciLHZQEqmydYkDBlcn(int P_0, IntPtr P_1)
	{
		KgoDgYtFAGczqYwNzDYadHoDwpdi = P_0;
		if (KgoDgYtFAGczqYwNzDYadHoDwpdi > 0 && P_1 != IntPtr.Zero)
		{
			LXewBgedHWMAMHPgREGPwSKnAcdiA = new byte[P_0];
			fixed (byte* lXewBgedHWMAMHPgREGPwSKnAcdiA = LXewBgedHWMAMHPgREGPwSKnAcdiA)
			{
				UzSdPpQstdjpcZsalnZeqrJQhDdn.gLWtQFUcdwcEsyTafnFfcDcnxkwx((IntPtr)lXewBgedHWMAMHPgREGPwSKnAcdiA, P_1, KgoDgYtFAGczqYwNzDYadHoDwpdi);
			}
		}
	}

	protected virtual uiIFGbFnfmeNgclXAVjyNHmstSYCB BuBadiUcMtyjDhFWylBUaFnYoEUD(int P_0, IntPtr P_1)
	{
		RmSMOtBhUqciLHZQEqmydYkDBlcn(P_0, P_1);
		return this;
	}

	internal virtual void uCvUnTrMkmLnAfHbxcmMfUITyZcEA(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr VdlfMavJQPQIZDgdChpkmhoSndHS()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (KgoDgYtFAGczqYwNzDYadHoDwpdi > 0 && LXewBgedHWMAMHPgREGPwSKnAcdiA != null)
		{
			intPtr = Marshal.AllocHGlobal(KgoDgYtFAGczqYwNzDYadHoDwpdi);
			fixed (byte* lXewBgedHWMAMHPgREGPwSKnAcdiA = LXewBgedHWMAMHPgREGPwSKnAcdiA)
			{
				UzSdPpQstdjpcZsalnZeqrJQhDdn.gLWtQFUcdwcEsyTafnFfcDcnxkwx(intPtr, (IntPtr)lXewBgedHWMAMHPgREGPwSKnAcdiA, KgoDgYtFAGczqYwNzDYadHoDwpdi);
			}
		}
		return intPtr;
	}

	public unsafe _0001 HnqQhkCoKMDVfTvilfUOYLsjvmCy<_0001>() where _0001 : uiIFGbFnfmeNgclXAVjyNHmstSYCB, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(uiIFGbFnfmeNgclXAVjyNHmstSYCB))
		{
			fixed (byte* lXewBgedHWMAMHPgREGPwSKnAcdiA = LXewBgedHWMAMHPgREGPwSKnAcdiA)
			{
				void* ptr = lXewBgedHWMAMHPgREGPwSKnAcdiA;
				return (_0001)new _0001().BuBadiUcMtyjDhFWylBUaFnYoEUD(KgoDgYtFAGczqYwNzDYadHoDwpdi, (IntPtr)ptr);
			}
		}
		return null;
	}
}
