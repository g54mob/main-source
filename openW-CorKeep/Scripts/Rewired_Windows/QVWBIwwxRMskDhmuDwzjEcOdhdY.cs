using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct QVWBIwwxRMskDhmuDwzjEcOdhdY : IDisposable
{
	private unsafe byte* lLDcFzwroikSAtvQSvwjgJecKngW;

	private int dymUgnVVoqRbwYPPocBMjznNjzeV;

	private bool kDyiJXALGBPlmMsiYtzOlzmtTSZIA;

	public unsafe byte* MzWlcQQxcZZBRpepXjPQlygnUIyw => lLDcFzwroikSAtvQSvwjgJecKngW;

	public unsafe IntPtr ZbedHwvaWiaGKlzxqIPmKHtwSWhE => (IntPtr)lLDcFzwroikSAtvQSvwjgJecKngW;

	public int pdmzJLJNkZQNlPAXFEzJTuYGQMsC => dymUgnVVoqRbwYPPocBMjznNjzeV;

	public unsafe byte AOspCxLhggfOgmDSwqotZrqmYXrG
	{
		get
		{
			if (P_0 < 0 || P_0 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
			{
				throw new IndexOutOfRangeException();
			}
			return lLDcFzwroikSAtvQSvwjgJecKngW[P_0];
		}
		set
		{
			if (num < 0 || num >= dymUgnVVoqRbwYPPocBMjznNjzeV)
			{
				throw new IndexOutOfRangeException();
			}
			lLDcFzwroikSAtvQSvwjgJecKngW[num] = b;
		}
	}

	public unsafe QVWBIwwxRMskDhmuDwzjEcOdhdY(int P_0)
	{
		lLDcFzwroikSAtvQSvwjgJecKngW = null;
		dymUgnVVoqRbwYPPocBMjznNjzeV = 0;
		kDyiJXALGBPlmMsiYtzOlzmtTSZIA = false;
		oxyCZVtdsQPpzHaUhOiBNphFGNKg(P_0);
	}

	public unsafe IntPtr uMjdvRTWBHHCaBvZzwpQNyEQDXKYA(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)lLDcFzwroikSAtvQSvwjgJecKngW;
		}
		if (P_0 < 0 || P_0 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe string zPqsOFmlFPBJtXhhDiQxOMtdTigK()
	{
		string text = "";
		for (int i = 0; i < dymUgnVVoqRbwYPPocBMjznNjzeV; i++)
		{
			text = text + lLDcFzwroikSAtvQSvwjgJecKngW[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool gVweKLnbzKWFVpGIrjWxSnQVsxIg(int P_0, byte P_1)
	{
		if (1 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (lLDcFzwroikSAtvQSvwjgJecKngW[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte GrQwxNNQeKQhyYufUPOOBohkUtCl(int P_0)
	{
		if (1 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return lLDcFzwroikSAtvQSvwjgJecKngW[P_0];
	}

	public unsafe short lBQHunmkeiOUEPhstBFUIOFjwCKOA(int P_0)
	{
		if (2 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe ushort OaXWqMiLxVbYaBAyIXjIQOHEvGDxA(int P_0)
	{
		if (2 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe int zvQtYGoSrqiOYIguAjDAljGQEbNT(int P_0)
	{
		if (4 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe uint GhsUjageeSbpqGCJTXKROdMwKtMr(int P_0)
	{
		if (4 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe long OGKmvsayxpYMtXxUthVYPPPGPCpE(int P_0)
	{
		if (8 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe ulong daWrfOZFgCNucSplvIoICsIUjewNA(int P_0)
	{
		if (8 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_0);
	}

	public unsafe void aZpdimfYTKYIVNbhQzkQtiqDiqarA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_2 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_1 + P_2 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)lLDcFzwroikSAtvQSvwjgJecKngW, P_0, P_2, P_3, P_1);
	}

	public unsafe void XcyIHsGynxqWdwsNSinkevRbTSGH(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_3 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_2 + P_3 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(lLDcFzwroikSAtvQSvwjgJecKngW, P_0, P_3, P_4, P_2);
	}

	public unsafe void jBMIGhZriuNDVIPFtIjlOUScJyeo(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		XcyIHsGynxqWdwsNSinkevRbTSGH((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int NNhjnOkOwDjBTGlNCttjcOePIQaAA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_2 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			P_1 = dymUgnVVoqRbwYPPocBMjznNjzeV - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)lLDcFzwroikSAtvQSvwjgJecKngW, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int xjAlatZwWqhoKkhNDkaXWBdGDPzn(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_3 + P_2 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			P_2 = dymUgnVVoqRbwYPPocBMjznNjzeV - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(lLDcFzwroikSAtvQSvwjgJecKngW, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int sBQjKmXhCMlMmFhoGEavfRjaiapFA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return xjAlatZwWqhoKkhNDkaXWBdGDPzn((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void blTuynhzxZoEDUsTJpEwdSNyzHRE(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = lLDcFzwroikSAtvQSvwjgJecKngW + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = lLDcFzwroikSAtvQSvwjgJecKngW + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void QrtagbJnSULTAuubLJdJFAoFrYKYB(byte P_0, int P_1)
	{
		if (1 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		lLDcFzwroikSAtvQSvwjgJecKngW[P_1] = P_0;
	}

	public unsafe void UfMbEKHCvbyBocQLAJuQIDJUJkNoA(short P_0, int P_1)
	{
		if (2 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_1) = P_0;
	}

	public unsafe void ZZLQpLKmGWwhpKgnSfAPKqXTrQHZ(ushort P_0, int P_1)
	{
		if (2 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_1) = P_0;
	}

	public unsafe void zteTCaOXzYqsHoMTMdyJqtgeGeBm(int P_0, int P_1)
	{
		if (4 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_1) = P_0;
	}

	public unsafe void VjPYyjUlEJCJZyQZArjaGIUdPgRh(uint P_0, int P_1)
	{
		if (4 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_1) = P_0;
	}

	public unsafe void WprgKkDroselRWBfusmGAeOYEuBh(long P_0, int P_1)
	{
		if (8 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_1) = P_0;
	}

	public unsafe void LASBqvpsYqNTXwpwrrMoqvMfIWok(ulong P_0, int P_1)
	{
		if (8 + P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(lLDcFzwroikSAtvQSvwjgJecKngW + P_1) = P_0;
	}

	public unsafe void KqBsLNdbzdqvwPLYquQQNCQaCSsr(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_2 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_1 + P_2 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)lLDcFzwroikSAtvQSvwjgJecKngW, P_3, P_2, P_1);
	}

	public unsafe void FjpPjjGQrnwPAPOBkZuYgFJZGBAIA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_3 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_2 + P_3 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(P_0, lLDcFzwroikSAtvQSvwjgJecKngW, P_4, P_3, P_2);
	}

	public unsafe void xqOYlRwiYimEXNsYJghPhNCsmAPQ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		FjpPjjGQrnwPAPOBkZuYgFJZGBAIA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int BvorBJkqRBSxQHfhDUiBscEiHlrV(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_1 + P_2 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			P_1 = dymUgnVVoqRbwYPPocBMjznNjzeV - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)lLDcFzwroikSAtvQSvwjgJecKngW, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int OvspjxPiJxuewlJvEKcyfnkXIciL(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= dymUgnVVoqRbwYPPocBMjznNjzeV)
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
		if (P_2 + P_3 > dymUgnVVoqRbwYPPocBMjznNjzeV)
		{
			P_2 = dymUgnVVoqRbwYPPocBMjznNjzeV - P_3;
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(P_0, lLDcFzwroikSAtvQSvwjgJecKngW, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int AxwvaSbRwrRkOlnAbtRkRvQTwRQM(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return OvspjxPiJxuewlJvEKcyfnkXIciL((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool oxyCZVtdsQPpzHaUhOiBNphFGNKg(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (dymUgnVVoqRbwYPPocBMjznNjzeV == P_0)
		{
			return true;
		}
		VYIUGCBiCDcFrkegzHZUUKjbRCqTA();
		if (P_0 == 0)
		{
			return true;
		}
		dymUgnVVoqRbwYPPocBMjznNjzeV = P_0;
		lLDcFzwroikSAtvQSvwjgJecKngW = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		nvhYLvANGMjoTQiRHDcQiOJLOiOdA();
		return true;
	}

	public unsafe void nvhYLvANGMjoTQiRHDcQiOJLOiOdA()
	{
		if (dymUgnVVoqRbwYPPocBMjznNjzeV != 0)
		{
			byZcZqIHxDbsMlffPcbwjwzKCDShb.QWzjHjKKFDaDLHcBJvSqVPOlqHWH(lLDcFzwroikSAtvQSvwjgJecKngW, dymUgnVVoqRbwYPPocBMjznNjzeV);
		}
	}

	public unsafe void VYIUGCBiCDcFrkegzHZUUKjbRCqTA()
	{
		if (dymUgnVVoqRbwYPPocBMjznNjzeV == 0)
		{
			return;
		}
		try
		{
			if (lLDcFzwroikSAtvQSvwjgJecKngW != null)
			{
				Marshal.FreeHGlobal(ZbedHwvaWiaGKlzxqIPmKHtwSWhE);
			}
		}
		catch
		{
		}
		lLDcFzwroikSAtvQSvwjgJecKngW = null;
		dymUgnVVoqRbwYPPocBMjznNjzeV = 0;
	}

	public string neBavWHQUVxbgfcZIAXCDafoDsTh()
	{
		string text = "";
		for (int i = 0; i < dymUgnVVoqRbwYPPocBMjznNjzeV; i++)
		{
			text = text + GrQwxNNQeKQhyYufUPOOBohkUtCl(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		eCEGhDFwaMNHJouYSLjHMHCFxPSK(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void eCEGhDFwaMNHJouYSLjHMHCFxPSK(bool P_0)
	{
		if (!kDyiJXALGBPlmMsiYtzOlzmtTSZIA)
		{
			VYIUGCBiCDcFrkegzHZUUKjbRCqTA();
			kDyiJXALGBPlmMsiYtzOlzmtTSZIA = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr mIBSANXnbqkvPxBEMZmTVWHLTpvE(QVWBIwwxRMskDhmuDwzjEcOdhdY P_0)
	{
		return (IntPtr)P_0.lLDcFzwroikSAtvQSvwjgJecKngW;
	}

	[SpecialName]
	public unsafe static void* mIBSANXnbqkvPxBEMZmTVWHLTpvE(QVWBIwwxRMskDhmuDwzjEcOdhdY P_0)
	{
		return P_0.lLDcFzwroikSAtvQSvwjgJecKngW;
	}

	public unsafe static bool ZFJHikbCkWKxkJIMPiByvNqIPJweb(QVWBIwwxRMskDhmuDwzjEcOdhdY P_0, QVWBIwwxRMskDhmuDwzjEcOdhdY P_1)
	{
		if (P_0.dymUgnVVoqRbwYPPocBMjznNjzeV == 0)
		{
			P_1.VYIUGCBiCDcFrkegzHZUUKjbRCqTA();
			return true;
		}
		if (P_1.oxyCZVtdsQPpzHaUhOiBNphFGNKg(P_0.dymUgnVVoqRbwYPPocBMjznNjzeV))
		{
			P_1.FjpPjjGQrnwPAPOBkZuYgFJZGBAIA(P_0.lLDcFzwroikSAtvQSvwjgJecKngW, P_0.dymUgnVVoqRbwYPPocBMjznNjzeV, P_0.dymUgnVVoqRbwYPPocBMjznNjzeV);
			return true;
		}
		return false;
	}
}
