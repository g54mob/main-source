using System;
using System.Runtime.InteropServices;

internal class ZxtmmGcWMZvspDfkwsxWMAtBqruT : IDisposable
{
	internal enum hoOAGtIlsiorHkFpGhfaAlZSFuuAA
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr ePchJZeuJAqbJHyXNLzZslMXHfrn(int nCode, IntPtr wParam, IntPtr lParam);

	private const int AhIxFKJAnUTUBMyoUKsubpNoDHPs = 4;

	private IntPtr zZmaFxkjqfnlkvPSTwvAfrppAypcb = IntPtr.Zero;

	private ePchJZeuJAqbJHyXNLzZslMXHfrn EERawzFgzypqfsucIkXgMCSdaDIPA;

	private Action<IntPtr, IntPtr, uint, uint> mrDTDzBSFCgxcVQyRCCsxyaJvkiO;

	private bool wNSXTkfrzBxqLFYERnVGtKogJUfA;

	public void uhDxKdHZgnvsYiTygSEYSFNijEad(Action<IntPtr, IntPtr, uint, uint> P_0, hoOAGtIlsiorHkFpGhfaAlZSFuuAA P_1)
	{
		mrDTDzBSFCgxcVQyRCCsxyaJvkiO = P_0;
		EERawzFgzypqfsucIkXgMCSdaDIPA = VtkchFggyTkAmPfoekQohDGiLKVNA;
		uint num = 0u;
		if (P_1 == hoOAGtIlsiorHkFpGhfaAlZSFuuAA.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		zZmaFxkjqfnlkvPSTwvAfrppAypcb = wruOBMvEABonemzuDRxszmicHnJM(4, EERawzFgzypqfsucIkXgMCSdaDIPA, IntPtr.Zero, num);
		_ = zZmaFxkjqfnlkvPSTwvAfrppAypcb == IntPtr.Zero;
	}

	public void wodBsgXxDXBjVcVUvJPzvobxtgaMA()
	{
		if (!(zZmaFxkjqfnlkvPSTwvAfrppAypcb == IntPtr.Zero) && ZmwhouYBEcsEFgRakrFsNxruTMhH(zZmaFxkjqfnlkvPSTwvAfrppAypcb))
		{
			zZmaFxkjqfnlkvPSTwvAfrppAypcb = IntPtr.Zero;
		}
	}

	private IntPtr VtkchFggyTkAmPfoekQohDGiLKVNA(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (P_0 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(P_2, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(P_2, num);
			mrDTDzBSFCgxcVQyRCCsxyaJvkiO(arg, arg2, arg3, arg4);
		}
		return TdAhYYAajaISfUwVRBSQjcjHKPYc(zZmaFxkjqfnlkvPSTwvAfrppAypcb, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		ltiJyeEgWQFagJEHfpcHzRigRlBmA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void CiOuhhuBpBihQAKWccHoAsQIVnRqB()
	{
		try
		{
			ltiJyeEgWQFagJEHfpcHzRigRlBmA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ltiJyeEgWQFagJEHfpcHzRigRlBmA(bool P_0)
	{
		if (!wNSXTkfrzBxqLFYERnVGtKogJUfA)
		{
			wodBsgXxDXBjVcVUvJPzvobxtgaMA();
			wNSXTkfrzBxqLFYERnVGtKogJUfA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr wruOBMvEABonemzuDRxszmicHnJM(int P_0, ePchJZeuJAqbJHyXNLzZslMXHfrn P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool ZmwhouYBEcsEFgRakrFsNxruTMhH(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr TdAhYYAajaISfUwVRBSQjcjHKPYc(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
