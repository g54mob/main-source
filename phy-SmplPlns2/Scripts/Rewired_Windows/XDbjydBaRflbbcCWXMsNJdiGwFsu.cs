using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class XDbjydBaRflbbcCWXMsNJdiGwFsu : IDisposable
{
	private unsafe byte* RyiVQDdIcIIJGhAIxaTpTcpMTLYTA;

	private int GYQHOPynfgYJaNItkxIxPTHRBagy;

	private bool ajbOPLKuqHWQiJIGbSSxeGlqImQV;

	public unsafe byte* MzVnVBpZcecVSVigpTOFDUCTmyUE => RyiVQDdIcIIJGhAIxaTpTcpMTLYTA;

	public unsafe IntPtr XPoUgrQanfDKnELyjemeETOoeCpEb => (IntPtr)RyiVQDdIcIIJGhAIxaTpTcpMTLYTA;

	public int zbRMVBTIarCGJLhKJFUoANUlLvodb => GYQHOPynfgYJaNItkxIxPTHRBagy;

	public unsafe byte LUZMbewiloMjrMnUtBszdDCHcfBbA
	{
		get
		{
			if (P_0 < 0 || P_0 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
			{
				throw new IndexOutOfRangeException();
			}
			return RyiVQDdIcIIJGhAIxaTpTcpMTLYTA[P_0];
		}
		set
		{
			if (num < 0 || num >= GYQHOPynfgYJaNItkxIxPTHRBagy)
			{
				throw new IndexOutOfRangeException();
			}
			RyiVQDdIcIIJGhAIxaTpTcpMTLYTA[num] = b;
		}
	}

	public XDbjydBaRflbbcCWXMsNJdiGwFsu(int P_0)
	{
		pLqOMuCrHehXdQqUjazBUKinDWyR(P_0);
	}

	public unsafe IntPtr diXGrtHQrzRhhPpIQrFgceCgihVwA(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)RyiVQDdIcIIJGhAIxaTpTcpMTLYTA;
		}
		if (P_0 < 0 || P_0 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe string QPJTzdFxycGGvQjCCRssTJRtBzWR()
	{
		string text = "";
		for (int i = 0; i < GYQHOPynfgYJaNItkxIxPTHRBagy; i++)
		{
			text = text + RyiVQDdIcIIJGhAIxaTpTcpMTLYTA[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool nKHWBAkKoSFoaCdUcXvROwAQmRzr(int P_0, byte P_1)
	{
		if (1 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (RyiVQDdIcIIJGhAIxaTpTcpMTLYTA[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte ewVgdDoBxqqrnNqfzsJunNPhmXbD(int P_0)
	{
		if (1 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return RyiVQDdIcIIJGhAIxaTpTcpMTLYTA[P_0];
	}

	public unsafe short YnjgqTJjqfdXlkezrrikpMVbtOyV(int P_0)
	{
		if (2 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe ushort qkZXzDZASMEFOunutApJEpEPrAin(int P_0)
	{
		if (2 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe int sBWjVCsmiThvPzDLYOMCjvUFBEtC(int P_0)
	{
		if (4 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe uint dvjtaTvDeglDjqLiUmHAsBbnMDqG(int P_0)
	{
		if (4 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe long BAMQNunHIRFYadjGiZrPgFbQZkNb(int P_0)
	{
		if (8 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe ulong vwrOyawWGBlqVfQGkHddSFEBJXzw(int P_0)
	{
		if (8 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe float zSBabaCYKCaSWDXuCNeIkQyEwxfHA(int P_0)
	{
		if (4 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe double eMukbTTGgAXSjkklnfPYcyhGQSvMA(int P_0)
	{
		if (8 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0);
	}

	public unsafe void lepdEKXwiKjSFkgWJPaMCbGkCDTZ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_2 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_1 + P_2 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_0, P_2, P_3, P_1);
	}

	public unsafe void MYVFvzChHeTlzVxbUEFPROfmPzDQ(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_3 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_2 + P_3 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_0, P_3, P_4, P_2);
	}

	public unsafe void jkzOCyXXweqfTWFXtiABKGiflYSi(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		MYVFvzChHeTlzVxbUEFPROfmPzDQ((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int BcJRMxonisbCmaRlDJWkzyAsvQclA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_2 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			P_1 = GYQHOPynfgYJaNItkxIxPTHRBagy - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int uTmENDANNVnxYNZlWbDCcQValJGX(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_3 + P_2 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			P_2 = GYQHOPynfgYJaNItkxIxPTHRBagy - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int cJHwsEmNiBxyHxgOQDyswEjkNEAr(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return uTmENDANNVnxYNZlWbDCcQValJGX((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void rhmOfkYHYhvhiwYGaMJRklyGpSMK(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void sBNPHbcitHGpdCORzpfOwGPGZDocA(byte P_0, int P_1)
	{
		if (1 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		RyiVQDdIcIIJGhAIxaTpTcpMTLYTA[P_1] = P_0;
	}

	public unsafe void nUtzpuvHgQeuvAGyoKMJGUDgigaqb(short P_0, int P_1)
	{
		if (2 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void PibiuwlPkksDhMjHVibeRWYRaLKP(ushort P_0, int P_1)
	{
		if (2 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void sFQdpUoOmnnfQDPaEhUldaGeIxeRA(int P_0, int P_1)
	{
		if (4 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void KdUbncaOotWkLedlLVdrFZRQeKFN(uint P_0, int P_1)
	{
		if (4 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void LhWnviYKGLPwDczbNHZcrGwqqyiK(long P_0, int P_1)
	{
		if (8 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void GKrpiTGiYvuNTEsDtDeNWAIOgafJ(ulong P_0, int P_1)
	{
		if (8 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void aJvykiRFaDNCGYhCrEWBXZvTeFcb(float P_0, int P_1)
	{
		if (4 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void svTHgcJbmqFhXeTnnnLCLgaiAYxI(double P_0, int P_1)
	{
		if (8 + P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA + P_1) = P_0;
	}

	public unsafe void ntfkNtDTkEFaPCYPsrRKjplTfHSbA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_2 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_1 + P_2 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_3, P_2, P_1);
	}

	public unsafe void dwgDjwrRQQqkHkcBeaoTxQxycnGB(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_3 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_2 + P_3 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(P_0, RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_4, P_3, P_2);
	}

	public unsafe void ScaCioRapNUurXEYqFUbFnXCPzUWA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		dwgDjwrRQQqkHkcBeaoTxQxycnGB((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int CtHwjmqDtjleNGUEekFGkQtpaGGf(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_1 + P_2 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			P_1 = GYQHOPynfgYJaNItkxIxPTHRBagy - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int uxXfzWekZkEErxQMfmOfTlhGaPsw(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= GYQHOPynfgYJaNItkxIxPTHRBagy)
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
		if (P_2 + P_3 > GYQHOPynfgYJaNItkxIxPTHRBagy)
		{
			P_2 = GYQHOPynfgYJaNItkxIxPTHRBagy - P_3;
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(P_0, RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int aaZDAvvyycdhPsOBkPSXFPVjpDqu(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return uxXfzWekZkEErxQMfmOfTlhGaPsw((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool pLqOMuCrHehXdQqUjazBUKinDWyR(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (GYQHOPynfgYJaNItkxIxPTHRBagy == P_0)
		{
			return true;
		}
		MoytzVbxYwklwooyGYcGSOBZQZdO();
		if (P_0 == 0)
		{
			return true;
		}
		GYQHOPynfgYJaNItkxIxPTHRBagy = P_0;
		RyiVQDdIcIIJGhAIxaTpTcpMTLYTA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		qIHTGPyXAFeIvekIkInZUpXVBhoU();
		return true;
	}

	public unsafe void qIHTGPyXAFeIvekIkInZUpXVBhoU()
	{
		if (GYQHOPynfgYJaNItkxIxPTHRBagy != 0)
		{
			TbAntJIfSSmAyfyyGIMdtrdGaNBT.oZggRQgOfULUnGHOdGGtmCQIzwaVe(RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, GYQHOPynfgYJaNItkxIxPTHRBagy);
		}
	}

	public unsafe void MoytzVbxYwklwooyGYcGSOBZQZdO()
	{
		if (GYQHOPynfgYJaNItkxIxPTHRBagy == 0)
		{
			return;
		}
		try
		{
			if (RyiVQDdIcIIJGhAIxaTpTcpMTLYTA != null)
			{
				Marshal.FreeHGlobal(XPoUgrQanfDKnELyjemeETOoeCpEb);
			}
		}
		catch
		{
		}
		RyiVQDdIcIIJGhAIxaTpTcpMTLYTA = null;
		GYQHOPynfgYJaNItkxIxPTHRBagy = 0;
	}

	public virtual string VjmaihnBKMMBUsSpzfENDGBUkaSk()
	{
		string text = "";
		for (int i = 0; i < GYQHOPynfgYJaNItkxIxPTHRBagy; i++)
		{
			text = text + ewVgdDoBxqqrnNqfzsJunNPhmXbD(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		xSwupOfJnpkNaWoBQWeJXVYlnuzD(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void IMlnmSmpdDzUGITkFDcBMUVaiLyK()
	{
		try
		{
			xSwupOfJnpkNaWoBQWeJXVYlnuzD(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void xSwupOfJnpkNaWoBQWeJXVYlnuzD(bool P_0)
	{
		if (!ajbOPLKuqHWQiJIGbSSxeGlqImQV)
		{
			MoytzVbxYwklwooyGYcGSOBZQZdO();
			ajbOPLKuqHWQiJIGbSSxeGlqImQV = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr ppDCbGJKoMCeiEeyUIfgpJPpsDxF(XDbjydBaRflbbcCWXMsNJdiGwFsu P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.RyiVQDdIcIIJGhAIxaTpTcpMTLYTA;
	}

	[SpecialName]
	public unsafe static void* ppDCbGJKoMCeiEeyUIfgpJPpsDxF(XDbjydBaRflbbcCWXMsNJdiGwFsu P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.RyiVQDdIcIIJGhAIxaTpTcpMTLYTA;
	}

	public unsafe static bool prPHxtwlHlQzasbNjEwAAnIUAqKfb(XDbjydBaRflbbcCWXMsNJdiGwFsu P_0, XDbjydBaRflbbcCWXMsNJdiGwFsu P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.GYQHOPynfgYJaNItkxIxPTHRBagy == 0)
		{
			P_1.MoytzVbxYwklwooyGYcGSOBZQZdO();
			return true;
		}
		if (P_1.pLqOMuCrHehXdQqUjazBUKinDWyR(P_0.GYQHOPynfgYJaNItkxIxPTHRBagy))
		{
			P_1.dwgDjwrRQQqkHkcBeaoTxQxycnGB(P_0.RyiVQDdIcIIJGhAIxaTpTcpMTLYTA, P_0.GYQHOPynfgYJaNItkxIxPTHRBagy, P_0.GYQHOPynfgYJaNItkxIxPTHRBagy);
			return true;
		}
		return false;
	}
}
