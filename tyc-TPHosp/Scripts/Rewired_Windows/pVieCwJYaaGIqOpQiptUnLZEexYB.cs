using System;
using System.Runtime.InteropServices;

internal class pVieCwJYaaGIqOpQiptUnLZEexYB : IDisposable
{
	private int exsGVPiIvNaGzXQwFEJfgCTVptcO;

	private uint tnjnnszAeVgbCefqvSkKimCiVDd;

	private IntPtr IOafCJIxxrAryHTldcFjhYyXNdFv;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public pVieCwJYaaGIqOpQiptUnLZEexYB(uint size)
	{
		if (size == 0)
		{
			throw new Exception("size must be > 0!");
		}
		tnjnnszAeVgbCefqvSkKimCiVDd = size;
		exsGVPiIvNaGzXQwFEJfgCTVptcO = 0;
		try
		{
			IOafCJIxxrAryHTldcFjhYyXNdFv = Marshal.AllocHGlobal((int)size);
			if (IOafCJIxxrAryHTldcFjhYyXNdFv == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr zkwAQVnfzqfJaCfPOplLVkfflWk(uint P_0, void* P_1)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > tnjnnszAeVgbCefqvSkKimCiVDd)
		{
			return IntPtr.Zero;
		}
		if (exsGVPiIvNaGzXQwFEJfgCTVptcO + P_0 >= tnjnnszAeVgbCefqvSkKimCiVDd)
		{
			exsGVPiIvNaGzXQwFEJfgCTVptcO = 0;
		}
		IntPtr intPtr = new IntPtr(IOafCJIxxrAryHTldcFjhYyXNdFv.ToInt64() + exsGVPiIvNaGzXQwFEJfgCTVptcO);
		QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl(intPtr, (IntPtr)P_1, (int)P_0);
		exsGVPiIvNaGzXQwFEJfgCTVptcO += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~pVieCwJYaaGIqOpQiptUnLZEexYB()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
			if (IOafCJIxxrAryHTldcFjhYyXNdFv != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(IOafCJIxxrAryHTldcFjhYyXNdFv);
			}
		}
	}
}
