using System;
using System.Runtime.InteropServices;

internal class JYUtoZyCQuaGPHylyvjViOQrMdSGb : IDisposable
{
	private int EGOPzmMkDHvQMQFNBJVudZCwubkhA;

	private uint FfDDSSPkoVyXSlRGlShrtpjBTkxH;

	private IntPtr yjGTaywhRpVvRKyWrKJyLMniWpJM;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public JYUtoZyCQuaGPHylyvjViOQrMdSGb(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		FfDDSSPkoVyXSlRGlShrtpjBTkxH = P_0;
		EGOPzmMkDHvQMQFNBJVudZCwubkhA = 0;
		try
		{
			yjGTaywhRpVvRKyWrKJyLMniWpJM = Marshal.AllocHGlobal((int)P_0);
			if (yjGTaywhRpVvRKyWrKJyLMniWpJM == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr PoWuVwNQVuFqVDDyMvfSIHoGGBqj(uint P_0, void* P_1)
	{
		if (TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > FfDDSSPkoVyXSlRGlShrtpjBTkxH)
		{
			return IntPtr.Zero;
		}
		if (EGOPzmMkDHvQMQFNBJVudZCwubkhA + P_0 >= FfDDSSPkoVyXSlRGlShrtpjBTkxH)
		{
			EGOPzmMkDHvQMQFNBJVudZCwubkhA = 0;
		}
		IntPtr intPtr = new IntPtr(yjGTaywhRpVvRKyWrKJyLMniWpJM.ToInt64() + EGOPzmMkDHvQMQFNBJVudZCwubkhA);
		qUbotaSLZASADLtRbuWjzvVhFURA.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(intPtr, (IntPtr)P_1, (int)P_0);
		EGOPzmMkDHvQMQFNBJVudZCwubkhA += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
			if (yjGTaywhRpVvRKyWrKJyLMniWpJM != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(yjGTaywhRpVvRKyWrKJyLMniWpJM);
			}
		}
	}
}
