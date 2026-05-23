using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class bSnyqDYFvFKIYgiXGrXPhhscBPW : IDisposable
{
	private readonly byte[] RlrDFPWlIVBjihBXNSARRWgibHv;

	public readonly int GgrgjYMnvDtqaCsPUiELzdYULam;

	private GCHandle AWAUOziGBmNTEuhEcaHpkZywwUF;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public bool IsPinned
	{
		get
		{
			return AWAUOziGBmNTEuhEcaHpkZywwUF.IsAllocated;
		}
	}

	public byte this[int index]
	{
		get
		{
			return RlrDFPWlIVBjihBXNSARRWgibHv[index];
		}
		set
		{
			RlrDFPWlIVBjihBXNSARRWgibHv[index] = value;
		}
	}

	public bSnyqDYFvFKIYgiXGrXPhhscBPW(int size)
	{
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		GgrgjYMnvDtqaCsPUiELzdYULam = size;
		RlrDFPWlIVBjihBXNSARRWgibHv = new byte[size];
	}

	public IntPtr OSUOnRqocfJagPoucEOZByahEzB()
	{
		if (AWAUOziGBmNTEuhEcaHpkZywwUF.IsAllocated)
		{
			return AWAUOziGBmNTEuhEcaHpkZywwUF.AddrOfPinnedObject();
		}
		AWAUOziGBmNTEuhEcaHpkZywwUF = GCHandle.Alloc(RlrDFPWlIVBjihBXNSARRWgibHv, GCHandleType.Pinned);
		return AWAUOziGBmNTEuhEcaHpkZywwUF.AddrOfPinnedObject();
	}

	public void nHECtxphhEUrNEjecqgLRekDly()
	{
		if (AWAUOziGBmNTEuhEcaHpkZywwUF.IsAllocated)
		{
			AWAUOziGBmNTEuhEcaHpkZywwUF.Free();
		}
	}

	public string YJduzNbXQZJCpUzpDXoQflyHqZx()
	{
		string text = "";
		for (int i = 0; i < GgrgjYMnvDtqaCsPUiELzdYULam; i++)
		{
			text = text + RlrDFPWlIVBjihBXNSARRWgibHv[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool AAVpkejpNwDagxlDTRPbJKQANwj(int P_0, byte P_1)
	{
		if (1 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (RlrDFPWlIVBjihBXNSARRWgibHv[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte mslbjdACzObJEiNqHnQNLHvGOHNv(int P_0)
	{
		if (1 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return RlrDFPWlIVBjihBXNSARRWgibHv[P_0];
	}

	public unsafe short vwVaNTxrMLFYODzZhqiaVmztxL(int P_0)
	{
		if (2 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			return *(short*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_0);
		}
	}

	public unsafe ushort zBMEluWlJzaymChTLbdXoIzrsmkp(int P_0)
	{
		if (2 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			return *(ushort*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_0);
		}
	}

	public unsafe int sFIdLRamzmGtwutvfAHcCmtrwaYI(int P_0)
	{
		if (4 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			return *(int*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_0);
		}
	}

	public unsafe uint WGaFzmiAXvKMJTpyiMQKAgqnNckd(int P_0)
	{
		if (4 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			return *(uint*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_0);
		}
	}

	public unsafe long NTjTqGlgLMXJhQYJapFcwosUffsc(int P_0)
	{
		if (8 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			return *(long*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_0);
		}
	}

	public unsafe ulong ZUFyNsgallXPLAPtCgonDrDWFxc(int P_0)
	{
		if (8 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			return *(ulong*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_0);
		}
	}

	public void NanoMDSNERLILwGbZOVIzaIWByQA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_2 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_1 + P_2 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(RlrDFPWlIVBjihBXNSARRWgibHv, P_2, P_0, P_3, P_1);
	}

	public void NanoMDSNERLILwGbZOVIzaIWByQA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
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
		if (P_2 > GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_3 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_2 + P_3 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(RlrDFPWlIVBjihBXNSARRWgibHv, P_0, P_3, P_4, P_2);
	}

	public int WZbANmUdaBabMjcRyqxSFuUdMeDZ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_2 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			P_1 = GgrgjYMnvDtqaCsPUiELzdYULam - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(RlrDFPWlIVBjihBXNSARRWgibHv, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int WZbANmUdaBabMjcRyqxSFuUdMeDZ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_3 + P_2 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			P_2 = GgrgjYMnvDtqaCsPUiELzdYULam - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(RlrDFPWlIVBjihBXNSARRWgibHv, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void ecXmScdJkFcorHpSAyqpVxGlfUlM(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > GgrgjYMnvDtqaCsPUiELzdYULam || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			RlrDFPWlIVBjihBXNSARRWgibHv[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			RlrDFPWlIVBjihBXNSARRWgibHv[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void mszIJNECfxEuJZasPAYwzZDCgpx(byte P_0, int P_1)
	{
		if (1 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		RlrDFPWlIVBjihBXNSARRWgibHv[P_1] = P_0;
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(short P_0, int P_1)
	{
		if (2 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			*(short*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_1) = P_0;
		}
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(ushort P_0, int P_1)
	{
		if (2 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			*(ushort*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_1) = P_0;
		}
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(int P_0, int P_1)
	{
		if (4 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			*(int*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_1) = P_0;
		}
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(uint P_0, int P_1)
	{
		if (4 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			*(uint*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_1) = P_0;
		}
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(long P_0, int P_1)
	{
		if (8 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			*(long*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_1) = P_0;
		}
	}

	public unsafe void mszIJNECfxEuJZasPAYwzZDCgpx(ulong P_0, int P_1)
	{
		if (8 + P_1 > GgrgjYMnvDtqaCsPUiELzdYULam || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* rlrDFPWlIVBjihBXNSARRWgibHv = RlrDFPWlIVBjihBXNSARRWgibHv)
		{
			*(ulong*)(rlrDFPWlIVBjihBXNSARRWgibHv + P_1) = P_0;
		}
	}

	public void mszIJNECfxEuJZasPAYwzZDCgpx(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_2 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_1 + P_2 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, RlrDFPWlIVBjihBXNSARRWgibHv, P_2, P_1);
	}

	public void mszIJNECfxEuJZasPAYwzZDCgpx(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
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
		if (P_2 > GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_3 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_2 + P_3 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, RlrDFPWlIVBjihBXNSARRWgibHv, P_4, P_3, P_2);
	}

	public int oXchfZSLmtNkbNnHlTJqYQvNcJW(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_1 + P_2 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			P_1 = GgrgjYMnvDtqaCsPUiELzdYULam - P_2;
		}
		Array.Copy(P_0, P_3, RlrDFPWlIVBjihBXNSARRWgibHv, P_2, P_1);
		return P_1;
	}

	public int oXchfZSLmtNkbNnHlTJqYQvNcJW(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= GgrgjYMnvDtqaCsPUiELzdYULam)
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
		if (P_2 + P_3 > GgrgjYMnvDtqaCsPUiELzdYULam)
		{
			P_2 = GgrgjYMnvDtqaCsPUiELzdYULam - P_3;
		}
		NativeTools.CopyMemory(P_0, RlrDFPWlIVBjihBXNSARRWgibHv, P_4, P_3, P_2);
		return P_2;
	}

	public void fWzuAFjFXxdRoqxypOAIFkBEHOX()
	{
		Array.Clear(RlrDFPWlIVBjihBXNSARRWgibHv, 0, GgrgjYMnvDtqaCsPUiELzdYULam);
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < GgrgjYMnvDtqaCsPUiELzdYULam; i++)
		{
			text = text + this[i].ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~bSnyqDYFvFKIYgiXGrXPhhscBPW()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			if (AWAUOziGBmNTEuhEcaHpkZywwUF.IsAllocated)
			{
				AWAUOziGBmNTEuhEcaHpkZywwUF.Free();
			}
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}

	public static void glrFXgbWMyKYqsCIgeYmyZLXFwP(bSnyqDYFvFKIYgiXGrXPhhscBPW P_0, bSnyqDYFvFKIYgiXGrXPhhscBPW P_1, int P_2)
	{
		Array.Copy(P_0.RlrDFPWlIVBjihBXNSARRWgibHv, P_1.RlrDFPWlIVBjihBXNSARRWgibHv, P_2);
	}

	public static void glrFXgbWMyKYqsCIgeYmyZLXFwP(bSnyqDYFvFKIYgiXGrXPhhscBPW P_0, int P_1, bSnyqDYFvFKIYgiXGrXPhhscBPW P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.RlrDFPWlIVBjihBXNSARRWgibHv, P_1, P_2.RlrDFPWlIVBjihBXNSARRWgibHv, P_3, P_4);
	}
}
