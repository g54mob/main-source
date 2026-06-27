using System;
using System.Runtime.InteropServices;

internal class BDHqHuhgGjYsQadTKmhrnkZrrYjv : IDisposable
{
	private int EQiJgqHNQyXjzmDYnUchaUGflpSl;

	private uint SiRjwrfZmOBQpFVTZfEiMtXelSEO;

	private IntPtr rlXfnEbyuGFzBoEdCmgCYkUIlaRHA;

	private bool OmGfnvGmJAELzdaLDaxVAcIdkPVR;

	public BDHqHuhgGjYsQadTKmhrnkZrrYjv(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		SiRjwrfZmOBQpFVTZfEiMtXelSEO = P_0;
		EQiJgqHNQyXjzmDYnUchaUGflpSl = 0;
		try
		{
			rlXfnEbyuGFzBoEdCmgCYkUIlaRHA = Marshal.AllocHGlobal((int)P_0);
			if (rlXfnEbyuGFzBoEdCmgCYkUIlaRHA == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr MeZbDHrAFJMfTBnOGmcjSwWWDnKq(uint P_0, void* P_1)
	{
		if (OmGfnvGmJAELzdaLDaxVAcIdkPVR)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > SiRjwrfZmOBQpFVTZfEiMtXelSEO)
		{
			return IntPtr.Zero;
		}
		if (EQiJgqHNQyXjzmDYnUchaUGflpSl + P_0 >= SiRjwrfZmOBQpFVTZfEiMtXelSEO)
		{
			EQiJgqHNQyXjzmDYnUchaUGflpSl = 0;
		}
		IntPtr intPtr = new IntPtr(rlXfnEbyuGFzBoEdCmgCYkUIlaRHA.ToInt64() + EQiJgqHNQyXjzmDYnUchaUGflpSl);
		klLdHAhsLOLqXXQXtowmGbeHymvN.YWRxEuxdXPFHNctXvomvIDJsuVkx(intPtr, (IntPtr)P_1, (int)P_0);
		EQiJgqHNQyXjzmDYnUchaUGflpSl += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		vRFdxsHdiKFEwxpmUYYxeoKMJXBlA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void cJNBrcCofkQaPjYPiTUPKIpPUchpb()
	{
		try
		{
			vRFdxsHdiKFEwxpmUYYxeoKMJXBlA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vRFdxsHdiKFEwxpmUYYxeoKMJXBlA(bool P_0)
	{
		if (!OmGfnvGmJAELzdaLDaxVAcIdkPVR)
		{
			OmGfnvGmJAELzdaLDaxVAcIdkPVR = true;
			if (rlXfnEbyuGFzBoEdCmgCYkUIlaRHA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(rlXfnEbyuGFzBoEdCmgCYkUIlaRHA);
			}
		}
	}
}
