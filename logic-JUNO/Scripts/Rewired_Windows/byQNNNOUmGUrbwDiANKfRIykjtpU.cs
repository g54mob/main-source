using System;
using System.Runtime.InteropServices;

internal class byQNNNOUmGUrbwDiANKfRIykjtpU : IDisposable
{
	private int sBlNeBiOsPCLEsgbpvrbOFjsbGSs;

	private uint euAhcACYMzDTYDuoFjrwqPqnRdQO;

	private IntPtr ZWGddxZSSpwecQLKWwJCYMnTdHRGA;

	private bool mxRhBEfnbtJyStciZZqBuQhsqZFG;

	public byQNNNOUmGUrbwDiANKfRIykjtpU(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		euAhcACYMzDTYDuoFjrwqPqnRdQO = P_0;
		sBlNeBiOsPCLEsgbpvrbOFjsbGSs = 0;
		try
		{
			ZWGddxZSSpwecQLKWwJCYMnTdHRGA = Marshal.AllocHGlobal((int)P_0);
			if (ZWGddxZSSpwecQLKWwJCYMnTdHRGA == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr gzSFRaEgtaiciZlfMPTjewtTnGYP(uint P_0, void* P_1)
	{
		if (mxRhBEfnbtJyStciZZqBuQhsqZFG)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > euAhcACYMzDTYDuoFjrwqPqnRdQO)
		{
			return IntPtr.Zero;
		}
		if (sBlNeBiOsPCLEsgbpvrbOFjsbGSs + P_0 >= euAhcACYMzDTYDuoFjrwqPqnRdQO)
		{
			sBlNeBiOsPCLEsgbpvrbOFjsbGSs = 0;
		}
		IntPtr intPtr = new IntPtr(ZWGddxZSSpwecQLKWwJCYMnTdHRGA.ToInt64() + sBlNeBiOsPCLEsgbpvrbOFjsbGSs);
		UzSdPpQstdjpcZsalnZeqrJQhDdn.gLWtQFUcdwcEsyTafnFfcDcnxkwx(intPtr, (IntPtr)P_1, (int)P_0);
		sBlNeBiOsPCLEsgbpvrbOFjsbGSs += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		BdWCnLFGUfFJXKrLCgltaGhaDiRkB(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void YXUBzXNMJPyjyOpkVcjHDwARzRbRA()
	{
		try
		{
			BdWCnLFGUfFJXKrLCgltaGhaDiRkB(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void BdWCnLFGUfFJXKrLCgltaGhaDiRkB(bool P_0)
	{
		if (!mxRhBEfnbtJyStciZZqBuQhsqZFG)
		{
			mxRhBEfnbtJyStciZZqBuQhsqZFG = true;
			if (ZWGddxZSSpwecQLKWwJCYMnTdHRGA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(ZWGddxZSSpwecQLKWwJCYMnTdHRGA);
			}
		}
	}
}
