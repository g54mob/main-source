using System;
using System.Runtime.InteropServices;

internal class yGDpJcSWtmEtudcouWqSeUlkaZd : IDisposable
{
	private int dnTaouuvLBxIsNWCJPuFxYAbRep;

	private uint kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;

	private IntPtr HBGjccEFzUpfeRXvNsDfbfcbmAK;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public yGDpJcSWtmEtudcouWqSeUlkaZd(uint size)
	{
		if (size == 0)
		{
			throw new Exception("size must be > 0!");
		}
		kBAhMOEbyJqqiAiFfGtMWTzCtIgJ = size;
		dnTaouuvLBxIsNWCJPuFxYAbRep = 0;
		try
		{
			HBGjccEFzUpfeRXvNsDfbfcbmAK = Marshal.AllocHGlobal((int)size);
			if (HBGjccEFzUpfeRXvNsDfbfcbmAK == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr aBXKlqdeXmyNlMpjIGSxjikZDLlO(uint P_0, void* P_1)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > kBAhMOEbyJqqiAiFfGtMWTzCtIgJ)
		{
			return IntPtr.Zero;
		}
		if (dnTaouuvLBxIsNWCJPuFxYAbRep + P_0 >= kBAhMOEbyJqqiAiFfGtMWTzCtIgJ)
		{
			dnTaouuvLBxIsNWCJPuFxYAbRep = 0;
		}
		IntPtr intPtr = new IntPtr(HBGjccEFzUpfeRXvNsDfbfcbmAK.ToInt64() + dnTaouuvLBxIsNWCJPuFxYAbRep);
		XhNUbpKnHPBQaARiBNUpPFpGECJ.qzVukddgYEFywyhAwohqPAzjNic(intPtr, (IntPtr)P_1, (int)P_0);
		dnTaouuvLBxIsNWCJPuFxYAbRep += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~yGDpJcSWtmEtudcouWqSeUlkaZd()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
			if (HBGjccEFzUpfeRXvNsDfbfcbmAK != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(HBGjccEFzUpfeRXvNsDfbfcbmAK);
			}
		}
	}
}
