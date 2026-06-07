using System;
using System.Runtime.InteropServices;

internal class DLYoSQUYnJrhRtdgGOpazrhdeiyn : IDisposable
{
	private int GAfULYoVlQOuwhUjrOQyiirrRbHg;

	private uint GLAGfPMVRqGFuQyiXkUvWMfokmPw;

	private IntPtr nPKCaeELDkowEBBCAgcXnssKoOEAb;

	private bool KHHiELrZeuXkuqkuNiaCWUwvrHAG;

	public DLYoSQUYnJrhRtdgGOpazrhdeiyn(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		GLAGfPMVRqGFuQyiXkUvWMfokmPw = P_0;
		GAfULYoVlQOuwhUjrOQyiirrRbHg = 0;
		try
		{
			nPKCaeELDkowEBBCAgcXnssKoOEAb = Marshal.AllocHGlobal((int)P_0);
			if (nPKCaeELDkowEBBCAgcXnssKoOEAb == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr WhOQtbKikjfaMYFlCOwsQCcIOVTs(uint P_0, void* P_1)
	{
		if (KHHiELrZeuXkuqkuNiaCWUwvrHAG)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > GLAGfPMVRqGFuQyiXkUvWMfokmPw)
		{
			return IntPtr.Zero;
		}
		if (GAfULYoVlQOuwhUjrOQyiirrRbHg + P_0 >= GLAGfPMVRqGFuQyiXkUvWMfokmPw)
		{
			GAfULYoVlQOuwhUjrOQyiirrRbHg = 0;
		}
		IntPtr intPtr = new IntPtr(nPKCaeELDkowEBBCAgcXnssKoOEAb.ToInt64() + GAfULYoVlQOuwhUjrOQyiirrRbHg);
		ehSEMeSdgiGvGKoctLujYIMHUCqW.CSQaWQYGczAKOnyczLceYNtmcbhq(intPtr, (IntPtr)P_1, (int)P_0);
		GAfULYoVlQOuwhUjrOQyiirrRbHg += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		pJMEoGkEFmATlViXCSOoWyaOFrAxA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void uOUgeUFLOQKpIwXkVPMGaIBKVCyOA()
	{
		try
		{
			pJMEoGkEFmATlViXCSOoWyaOFrAxA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void pJMEoGkEFmATlViXCSOoWyaOFrAxA(bool P_0)
	{
		if (!KHHiELrZeuXkuqkuNiaCWUwvrHAG)
		{
			KHHiELrZeuXkuqkuNiaCWUwvrHAG = true;
			if (nPKCaeELDkowEBBCAgcXnssKoOEAb != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(nPKCaeELDkowEBBCAgcXnssKoOEAb);
			}
		}
	}
}
