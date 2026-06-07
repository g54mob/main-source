using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class WwcwFFXrcgizEHXRtCqRIUJLIniV : IDisposable
{
	private unsafe byte* yRgEOFBkubxfaGxeTsHFHKIayhyR;

	private int CpBwjqeiRARQGVOPHcAHFjhfRBCQ;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public unsafe byte* UnsafePointer
	{
		get
		{
			return yRgEOFBkubxfaGxeTsHFHKIayhyR;
		}
	}

	public unsafe IntPtr Pointer
	{
		get
		{
			return (IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR;
		}
	}

	public int Length
	{
		get
		{
			return CpBwjqeiRARQGVOPHcAHFjhfRBCQ;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
			{
				throw new IndexOutOfRangeException();
			}
			return yRgEOFBkubxfaGxeTsHFHKIayhyR[index];
		}
		set
		{
			if (index < 0 || index >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
			{
				throw new IndexOutOfRangeException();
			}
			yRgEOFBkubxfaGxeTsHFHKIayhyR[index] = value;
		}
	}

	public WwcwFFXrcgizEHXRtCqRIUJLIniV(int size)
	{
		WotzQgfiuWMSMRqZcQFLfFyIfrg(size);
	}

	public unsafe IntPtr dkCXvjWqBRgCwptgHacfDiyzXOc(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR;
		}
		if (P_0 < 0 || P_0 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe string YJduzNbXQZJCpUzpDXoQflyHqZx()
	{
		string text = "";
		for (int i = 0; i < CpBwjqeiRARQGVOPHcAHFjhfRBCQ; i++)
		{
			text = text + yRgEOFBkubxfaGxeTsHFHKIayhyR[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool AAVpkejpNwDagxlDTRPbJKQANwj(int P_0, byte P_1)
	{
		if (1 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (yRgEOFBkubxfaGxeTsHFHKIayhyR[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte mslbjdACzObJEiNqHnQNLHvGOHNv(int P_0)
	{
		if (1 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return yRgEOFBkubxfaGxeTsHFHKIayhyR[P_0];
	}

	public unsafe short vwVaNTxrMLFYODzZhqiaVmztxL(int P_0)
	{
		if (2 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe ushort zBMEluWlJzaymChTLbdXoIzrsmkp(int P_0)
	{
		if (2 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe int sFIdLRamzmGtwutvfAHcCmtrwaYI(int P_0)
	{
		if (4 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe uint WGaFzmiAXvKMJTpyiMQKAgqnNckd(int P_0)
	{
		if (4 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe long NTjTqGlgLMXJhQYJapFcwosUffsc(int P_0)
	{
		if (8 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe ulong ZUFyNsgallXPLAPtCgonDrDWFxc(int P_0)
	{
		if (8 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0);
	}

	public unsafe void NanoMDSNERLILwGbZOVIzaIWByQA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_2 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_1 + P_2 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_2, P_3, P_1);
	}

	public unsafe void NanoMDSNERLILwGbZOVIzaIWByQA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_2 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_2 + P_3 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_3, P_4, P_2);
	}

	public unsafe void NanoMDSNERLILwGbZOVIzaIWByQA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		NanoMDSNERLILwGbZOVIzaIWByQA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int WZbANmUdaBabMjcRyqxSFuUdMeDZ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0)
		{
			return 0;
		}
		if (P_2 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			return 0;
		}
		if (P_3 >= num)
		{
			return 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			P_1 = CpBwjqeiRARQGVOPHcAHFjhfRBCQ - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int WZbANmUdaBabMjcRyqxSFuUdMeDZ(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			return 0;
		}
		if (P_4 >= P_1)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 + P_2 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			P_2 = CpBwjqeiRARQGVOPHcAHFjhfRBCQ - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int WZbANmUdaBabMjcRyqxSFuUdMeDZ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return WZbANmUdaBabMjcRyqxSFuUdMeDZ((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void ecXmScdJkFcorHpSAyqpVxGlfUlM(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* intPtr = yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0;
			*intPtr |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* intPtr2 = yRgEOFBkubxfaGxeTsHFHKIayhyR + P_0;
			*intPtr2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(byte P_0, int P_1)
	{
		if (1 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		yRgEOFBkubxfaGxeTsHFHKIayhyR[P_1] = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(short P_0, int P_1)
	{
		if (2 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_1) = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(ushort P_0, int P_1)
	{
		if (2 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_1) = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(int P_0, int P_1)
	{
		if (4 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_1) = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(uint P_0, int P_1)
	{
		if (4 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_1) = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(long P_0, int P_1)
	{
		if (8 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_1) = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(ulong P_0, int P_1)
	{
		if (8 + P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(yRgEOFBkubxfaGxeTsHFHKIayhyR + P_1) = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_1 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_2 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_1 + P_2 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_3, P_2, P_1);
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_2 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_2 + P_3 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(P_0, yRgEOFBkubxfaGxeTsHFHKIayhyR, P_4, P_3, P_2);
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		mszIJNECfxEuJZasPAYwzZDCgpx((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int oXchfZSLmtNkbNnHlTJqYQvNcJW(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 + P_2 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			P_1 = CpBwjqeiRARQGVOPHcAHFjhfRBCQ - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int oXchfZSLmtNkbNnHlTJqYQvNcJW(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			return 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		if (P_2 + P_3 > CpBwjqeiRARQGVOPHcAHFjhfRBCQ)
		{
			P_2 = CpBwjqeiRARQGVOPHcAHFjhfRBCQ - P_3;
		}
		iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(P_0, yRgEOFBkubxfaGxeTsHFHKIayhyR, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int oXchfZSLmtNkbNnHlTJqYQvNcJW(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return oXchfZSLmtNkbNnHlTJqYQvNcJW((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool WotzQgfiuWMSMRqZcQFLfFyIfrg(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (CpBwjqeiRARQGVOPHcAHFjhfRBCQ == P_0)
		{
			return true;
		}
		VMTfqPHmasXYlFpuPbgOhJsdpSAG();
		if (P_0 == 0)
		{
			return true;
		}
		CpBwjqeiRARQGVOPHcAHFjhfRBCQ = P_0;
		yRgEOFBkubxfaGxeTsHFHKIayhyR = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		fWzuAFjFXxdRoqxypOAIFkBEHOX();
		return true;
	}

	public unsafe void fWzuAFjFXxdRoqxypOAIFkBEHOX()
	{
		if (CpBwjqeiRARQGVOPHcAHFjhfRBCQ != 0)
		{
			iDmPgLoZjlLdrlGLlipujkvVHRKy.xArZVAsTQiQDizbGaorpAUpxdvS(yRgEOFBkubxfaGxeTsHFHKIayhyR, CpBwjqeiRARQGVOPHcAHFjhfRBCQ);
		}
	}

	public unsafe void VMTfqPHmasXYlFpuPbgOhJsdpSAG()
	{
		if (CpBwjqeiRARQGVOPHcAHFjhfRBCQ == 0)
		{
			return;
		}
		try
		{
			if (yRgEOFBkubxfaGxeTsHFHKIayhyR != null)
			{
				Marshal.FreeHGlobal(Pointer);
			}
		}
		catch
		{
		}
		yRgEOFBkubxfaGxeTsHFHKIayhyR = null;
		CpBwjqeiRARQGVOPHcAHFjhfRBCQ = 0;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < CpBwjqeiRARQGVOPHcAHFjhfRBCQ; i++)
		{
			text = text + mslbjdACzObJEiNqHnQNLHvGOHNv(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~WwcwFFXrcgizEHXRtCqRIUJLIniV()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			VMTfqPHmasXYlFpuPbgOhJsdpSAG();
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}

	public unsafe static implicit operator IntPtr(WwcwFFXrcgizEHXRtCqRIUJLIniV buffer)
	{
		if (buffer == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)buffer.yRgEOFBkubxfaGxeTsHFHKIayhyR;
	}

	public unsafe static implicit operator void*(WwcwFFXrcgizEHXRtCqRIUJLIniV buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		return buffer.yRgEOFBkubxfaGxeTsHFHKIayhyR;
	}

	public unsafe static bool glrFXgbWMyKYqsCIgeYmyZLXFwP(WwcwFFXrcgizEHXRtCqRIUJLIniV P_0, WwcwFFXrcgizEHXRtCqRIUJLIniV P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.CpBwjqeiRARQGVOPHcAHFjhfRBCQ == 0)
		{
			P_1.VMTfqPHmasXYlFpuPbgOhJsdpSAG();
			return true;
		}
		if (P_1.WotzQgfiuWMSMRqZcQFLfFyIfrg(P_0.CpBwjqeiRARQGVOPHcAHFjhfRBCQ))
		{
			P_1.mszIJNECfxEuJZasPAYwzZDCgpx(P_0.yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0.CpBwjqeiRARQGVOPHcAHFjhfRBCQ, P_0.CpBwjqeiRARQGVOPHcAHFjhfRBCQ);
			return true;
		}
		return false;
	}
}
