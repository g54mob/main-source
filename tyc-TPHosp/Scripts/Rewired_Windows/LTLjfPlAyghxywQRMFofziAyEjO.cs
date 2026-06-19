using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class LTLjfPlAyghxywQRMFofziAyEjO : efmrLSrolSjovsfxfjCVLLJRnGz
{
	[CompilerGenerated]
	private int cxATEBlKVdvcfcFTeNRvRZXttLp;

	[CompilerGenerated]
	private int AzCksuLZCGBmylqcrhQtdsVixREi;

	[CompilerGenerated]
	private int kgvabhGbTpiezZbDpqDMJmPWzZDU;

	[CompilerGenerated]
	private int XodOmVmlCXRSMmIQaEQqemQULjJ;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return cxATEBlKVdvcfcFTeNRvRZXttLp;
		}
		[CompilerGenerated]
		set
		{
			cxATEBlKVdvcfcFTeNRvRZXttLp = value;
		}
	}

	public int Offset
	{
		[CompilerGenerated]
		get
		{
			return AzCksuLZCGBmylqcrhQtdsVixREi;
		}
		[CompilerGenerated]
		set
		{
			AzCksuLZCGBmylqcrhQtdsVixREi = value;
		}
	}

	public int Phase
	{
		[CompilerGenerated]
		get
		{
			return kgvabhGbTpiezZbDpqDMJmPWzZDU;
		}
		[CompilerGenerated]
		set
		{
			kgvabhGbTpiezZbDpqDMJmPWzZDU = value;
		}
	}

	public int Period
	{
		[CompilerGenerated]
		get
		{
			return XodOmVmlCXRSMmIQaEQqemQULjJ;
		}
		[CompilerGenerated]
		set
		{
			XodOmVmlCXRSMmIQaEQqemQULjJ = value;
		}
	}

	public override int Size => QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<EjVEUvSlouEAZbfFCGbTeIBAVLq>();

	protected unsafe override efmrLSrolSjovsfxfjCVLLJRnGz jgUKJdlhVlbmjmcGcqukHIxicKDF(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(EjVEUvSlouEAZbfFCGbTeIBAVLq))
		{
			return null;
		}
		Magnitude = ((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)P_1)->GZQEsynxELRuselvHylVlxQwtBL;
		Offset = ((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)P_1)->vWDCHhwuXPHeHeeYshRgNHYNPtE;
		Phase = ((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)P_1)->HstdxpSAdXiCTeCEifZGiMCoHzJZ;
		Period = ((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)P_1)->pUkHjOhkaNNbQmRdHjNjvNcGZNO;
		return this;
	}

	internal unsafe override IntPtr ytPODbihcgKkYwOfQIFAEFNEgkj()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)intPtr)->GZQEsynxELRuselvHylVlxQwtBL = Magnitude;
		((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)intPtr)->vWDCHhwuXPHeHeeYshRgNHYNPtE = Offset;
		((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)intPtr)->HstdxpSAdXiCTeCEifZGiMCoHzJZ = Phase;
		((EjVEUvSlouEAZbfFCGbTeIBAVLq*)(void*)intPtr)->pUkHjOhkaNNbQmRdHjNjvNcGZNO = Period;
		return intPtr;
	}
}
