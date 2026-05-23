using System;
using System.Runtime.InteropServices;

internal class JSrFWeHKCynvAnYPbJcptSdCCLqjb : IDisposable
{
	private int IUyUeKqAfSWhFUKKZHrFTwYjcZBb;

	private uint MOpXppAfmJUXzvnXufBovAnDBDHaA;

	private IntPtr lPtqwEDeeDokTilvzDvKVBktAjAFA;

	private bool WmwIptNjFPwfFLmwrBZfmUCKfYC;

	public JSrFWeHKCynvAnYPbJcptSdCCLqjb(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		MOpXppAfmJUXzvnXufBovAnDBDHaA = P_0;
		IUyUeKqAfSWhFUKKZHrFTwYjcZBb = 0;
		try
		{
			lPtqwEDeeDokTilvzDvKVBktAjAFA = Marshal.AllocHGlobal((int)P_0);
			if (lPtqwEDeeDokTilvzDvKVBktAjAFA == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr GQbGmVIRuWcvFjOOdpFdhcKpuVJE(uint P_0, void* P_1)
	{
		if (WmwIptNjFPwfFLmwrBZfmUCKfYC)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > MOpXppAfmJUXzvnXufBovAnDBDHaA)
		{
			return IntPtr.Zero;
		}
		if (IUyUeKqAfSWhFUKKZHrFTwYjcZBb + P_0 >= MOpXppAfmJUXzvnXufBovAnDBDHaA)
		{
			IUyUeKqAfSWhFUKKZHrFTwYjcZBb = 0;
		}
		IntPtr intPtr = new IntPtr(lPtqwEDeeDokTilvzDvKVBktAjAFA.ToInt64() + IUyUeKqAfSWhFUKKZHrFTwYjcZBb);
		qEhGRKCBLVdeTteVGclkbvGuEbqQ.QPzyomEBrMYCJYJGQjOnlpkXCKnC(intPtr, (IntPtr)P_1, (int)P_0);
		IUyUeKqAfSWhFUKKZHrFTwYjcZBb += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		xixKgsWloFCBeEPsbMDfDVcnLIEmA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void kQhpaeHkvhppNgOFmwHVlvVpsdku()
	{
		try
		{
			xixKgsWloFCBeEPsbMDfDVcnLIEmA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void xixKgsWloFCBeEPsbMDfDVcnLIEmA(bool P_0)
	{
		if (!WmwIptNjFPwfFLmwrBZfmUCKfYC)
		{
			WmwIptNjFPwfFLmwrBZfmUCKfYC = true;
			if (lPtqwEDeeDokTilvzDvKVBktAjAFA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(lPtqwEDeeDokTilvzDvKVBktAjAFA);
			}
		}
	}
}
