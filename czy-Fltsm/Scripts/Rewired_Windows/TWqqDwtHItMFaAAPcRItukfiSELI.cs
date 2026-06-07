using System;
using System.Runtime.InteropServices;

internal class TWqqDwtHItMFaAAPcRItukfiSELI : IDisposable
{
	private int MkPdukGBJcZhXpCRHFsbOrkmFdeYA;

	private uint IwsVsfjBlSwIZjBQnamoTVbbVMkr;

	private IntPtr lvoYdMmzvIHHvonuyCLGjbcBmSbL;

	private bool UqzZUxKgKCAiFbFSzoMNCHokGJvHb;

	public TWqqDwtHItMFaAAPcRItukfiSELI(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		IwsVsfjBlSwIZjBQnamoTVbbVMkr = P_0;
		MkPdukGBJcZhXpCRHFsbOrkmFdeYA = 0;
		try
		{
			lvoYdMmzvIHHvonuyCLGjbcBmSbL = Marshal.AllocHGlobal((int)P_0);
			if (lvoYdMmzvIHHvonuyCLGjbcBmSbL == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr GeoboFHpQHbRhExXhmGhVPoJWnaYA(uint P_0, void* P_1)
	{
		if (UqzZUxKgKCAiFbFSzoMNCHokGJvHb)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > IwsVsfjBlSwIZjBQnamoTVbbVMkr)
		{
			return IntPtr.Zero;
		}
		if (MkPdukGBJcZhXpCRHFsbOrkmFdeYA + P_0 >= IwsVsfjBlSwIZjBQnamoTVbbVMkr)
		{
			MkPdukGBJcZhXpCRHFsbOrkmFdeYA = 0;
		}
		IntPtr intPtr = new IntPtr(lvoYdMmzvIHHvonuyCLGjbcBmSbL.ToInt64() + MkPdukGBJcZhXpCRHFsbOrkmFdeYA);
		qxcVmGprUKQYlnqWDgYoPbSYiwBQ.SLqTOazZKJnjvIMWFgYbNIplONWs(intPtr, (IntPtr)P_1, (int)P_0);
		MkPdukGBJcZhXpCRHFsbOrkmFdeYA += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		rocGgglVpEwAOVAbsjandOwLUFbp(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void yCeImeatesMuryFMfwhVXSNVuoNF()
	{
		try
		{
			rocGgglVpEwAOVAbsjandOwLUFbp(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void rocGgglVpEwAOVAbsjandOwLUFbp(bool P_0)
	{
		if (!UqzZUxKgKCAiFbFSzoMNCHokGJvHb)
		{
			UqzZUxKgKCAiFbFSzoMNCHokGJvHb = true;
			if (lvoYdMmzvIHHvonuyCLGjbcBmSbL != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(lvoYdMmzvIHHvonuyCLGjbcBmSbL);
			}
		}
	}
}
