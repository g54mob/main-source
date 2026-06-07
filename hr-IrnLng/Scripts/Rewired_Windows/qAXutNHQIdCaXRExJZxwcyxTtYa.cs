using System;
using System.Runtime.InteropServices;

internal class qAXutNHQIdCaXRExJZxwcyxTtYa : IDisposable
{
	private int vGVcvOpITSLYMndemCrUBzeEXtaO;

	private uint iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	private IntPtr DSRwjINZJsvAFbfASvXQvJkKhKV;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public qAXutNHQIdCaXRExJZxwcyxTtYa(uint size)
	{
		if (size == 0)
		{
			throw new Exception("size must be > 0!");
		}
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = size;
		vGVcvOpITSLYMndemCrUBzeEXtaO = 0;
		try
		{
			DSRwjINZJsvAFbfASvXQvJkKhKV = Marshal.AllocHGlobal((int)size);
			if (DSRwjINZJsvAFbfASvXQvJkKhKV == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr eUHeyUyORxWRVoiDvPZqazEckWe(uint P_0, void* P_1)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > iiCeZsFqsCMgMBWpCvqNRTNxrPf)
		{
			return IntPtr.Zero;
		}
		if (vGVcvOpITSLYMndemCrUBzeEXtaO + P_0 >= iiCeZsFqsCMgMBWpCvqNRTNxrPf)
		{
			vGVcvOpITSLYMndemCrUBzeEXtaO = 0;
		}
		IntPtr intPtr = new IntPtr(DSRwjINZJsvAFbfASvXQvJkKhKV.ToInt64() + vGVcvOpITSLYMndemCrUBzeEXtaO);
		JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz(intPtr, (IntPtr)P_1, (int)P_0);
		vGVcvOpITSLYMndemCrUBzeEXtaO += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~qAXutNHQIdCaXRExJZxwcyxTtYa()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			euujVPFzGztViWDbYvUutBvFQFP = true;
			if (DSRwjINZJsvAFbfASvXQvJkKhKV != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(DSRwjINZJsvAFbfASvXQvJkKhKV);
			}
		}
	}
}
