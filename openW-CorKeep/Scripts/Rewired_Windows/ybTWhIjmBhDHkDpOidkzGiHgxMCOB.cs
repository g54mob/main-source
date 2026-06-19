using System;
using System.Runtime.InteropServices;

internal class ybTWhIjmBhDHkDpOidkzGiHgxMCOB : IDisposable
{
	private int tQubkGVJFcuXFnRuPRchtEIldDvI;

	private uint rgJDURddpKkfNfIUrYTqSNDsLQzBb;

	private IntPtr OcVhPcyCjIUMfBhcmqdQfVQYrkyX;

	private bool vwILZJACFInBRehQldJXJDCjCTsu;

	public ybTWhIjmBhDHkDpOidkzGiHgxMCOB(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		rgJDURddpKkfNfIUrYTqSNDsLQzBb = P_0;
		tQubkGVJFcuXFnRuPRchtEIldDvI = 0;
		try
		{
			OcVhPcyCjIUMfBhcmqdQfVQYrkyX = Marshal.AllocHGlobal((int)P_0);
			if (OcVhPcyCjIUMfBhcmqdQfVQYrkyX == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr fLzzblpQVmKppGDwChrePEBSfzKb(uint P_0, void* P_1)
	{
		if (vwILZJACFInBRehQldJXJDCjCTsu)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > rgJDURddpKkfNfIUrYTqSNDsLQzBb)
		{
			return IntPtr.Zero;
		}
		if (tQubkGVJFcuXFnRuPRchtEIldDvI + P_0 >= rgJDURddpKkfNfIUrYTqSNDsLQzBb)
		{
			tQubkGVJFcuXFnRuPRchtEIldDvI = 0;
		}
		IntPtr intPtr = new IntPtr(OcVhPcyCjIUMfBhcmqdQfVQYrkyX.ToInt64() + tQubkGVJFcuXFnRuPRchtEIldDvI);
		VRhfcElUYIDhtSYXXbsQDsFMgObb.lBZHGQvYjHqJlnMVThPjXLJyLHBD(intPtr, (IntPtr)P_1, (int)P_0);
		tQubkGVJFcuXFnRuPRchtEIldDvI += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		CVFHZSpvtUObSoAnqqLnjQUGfFqr(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void DuHITCcxueDRbJyWzJRPXchGauIGA()
	{
		try
		{
			CVFHZSpvtUObSoAnqqLnjQUGfFqr(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void CVFHZSpvtUObSoAnqqLnjQUGfFqr(bool P_0)
	{
		if (!vwILZJACFInBRehQldJXJDCjCTsu)
		{
			vwILZJACFInBRehQldJXJDCjCTsu = true;
			if (OcVhPcyCjIUMfBhcmqdQfVQYrkyX != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(OcVhPcyCjIUMfBhcmqdQfVQYrkyX);
			}
		}
	}
}
