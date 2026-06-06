using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct zDiYSyaxjBvXsqicoFerveALMbuy : IDisposable
{
	private unsafe byte* OQqNOVoGoczTYCDAEtHlyWEphdzw;

	private int OpLzVVXcQqkwabLhesGulDzEbxvb;

	private bool PUZAUtBWDLcWgBgTMYvUbKNyAdQC;

	public unsafe byte* vbdHciOmcReSXeAnZzqATtCisSffb => OQqNOVoGoczTYCDAEtHlyWEphdzw;

	public unsafe IntPtr eyBEgQddWmEhKFIjmzzsIEzjWKoKA => (IntPtr)OQqNOVoGoczTYCDAEtHlyWEphdzw;

	public int YUJJejFgmXtRvyQUJElZXzGBQOlW => OpLzVVXcQqkwabLhesGulDzEbxvb;

	public unsafe byte jWNBmLhJkaEqgRZIsfNjwBStfEgjb
	{
		get
		{
			if (P_0 < 0 || P_0 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
			{
				throw new IndexOutOfRangeException();
			}
			return OQqNOVoGoczTYCDAEtHlyWEphdzw[P_0];
		}
		set
		{
			if (num < 0 || num >= OpLzVVXcQqkwabLhesGulDzEbxvb)
			{
				throw new IndexOutOfRangeException();
			}
			OQqNOVoGoczTYCDAEtHlyWEphdzw[num] = b;
		}
	}

	public unsafe zDiYSyaxjBvXsqicoFerveALMbuy(int P_0)
	{
		OQqNOVoGoczTYCDAEtHlyWEphdzw = null;
		OpLzVVXcQqkwabLhesGulDzEbxvb = 0;
		PUZAUtBWDLcWgBgTMYvUbKNyAdQC = false;
		NDXlJjhRkIwWhygKpffNePFCxUPrA(P_0);
	}

	public unsafe IntPtr FOGaLxRHBPXXiKkBhQrOoaoHJnLI(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)OQqNOVoGoczTYCDAEtHlyWEphdzw;
		}
		if (P_0 < 0 || P_0 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe string SvDCvjcczJyUlbkfPITnvOXaANpCb()
	{
		string text = "";
		for (int i = 0; i < OpLzVVXcQqkwabLhesGulDzEbxvb; i++)
		{
			text = text + OQqNOVoGoczTYCDAEtHlyWEphdzw[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool PFNcrzFrvUSFLCrCbHQbeKwYFaLTA(int P_0, byte P_1)
	{
		if (1 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (OQqNOVoGoczTYCDAEtHlyWEphdzw[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte tijwjjXmJKuNuxblUloAVXNrENBD(int P_0)
	{
		if (1 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return OQqNOVoGoczTYCDAEtHlyWEphdzw[P_0];
	}

	public unsafe short MvdrfRweqsEXAugypmuEAktiPCLS(int P_0)
	{
		if (2 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe ushort fAavseepPJZGifKyAOWOMpvDYXSh(int P_0)
	{
		if (2 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe int WBfGyceJtsJrUnGuSRUWvdqRzvWr(int P_0)
	{
		if (4 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe uint diTqNKcQsQcosdrZHazNAGmbLzBqA(int P_0)
	{
		if (4 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe long xSzQnOwpjzjVvcOpldSKPvnRELkFA(int P_0)
	{
		if (8 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe ulong UNxypyDCsQDxovtzdFVYmQsLdihR(int P_0)
	{
		if (8 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0);
	}

	public unsafe void FOYhmMAXUIXHPOjOOFeSebGUqcvi(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_2 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_1 + P_2 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)OQqNOVoGoczTYCDAEtHlyWEphdzw, P_0, P_2, P_3, P_1);
	}

	public unsafe void uIHqBIUaprazfcDNWrFmsshwEXZnA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_3 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_2 + P_3 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(OQqNOVoGoczTYCDAEtHlyWEphdzw, P_0, P_3, P_4, P_2);
	}

	public unsafe void EKfFZXBDooCJRvnLtUvlCxihyubj(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		uIHqBIUaprazfcDNWrFmsshwEXZnA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int qKSsGawmeHGjDrfTSDQrsqYGsMto(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_2 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			P_1 = OpLzVVXcQqkwabLhesGulDzEbxvb - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)OQqNOVoGoczTYCDAEtHlyWEphdzw, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int GptHeTJAEcieOcZHNjNPYWVDyJqn(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_3 + P_2 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			P_2 = OpLzVVXcQqkwabLhesGulDzEbxvb - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(OQqNOVoGoczTYCDAEtHlyWEphdzw, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int JkxFUENhUGFVoiVyORLfjlPpgvoJ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return GptHeTJAEcieOcZHNjNPYWVDyJqn((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void UqqFlZFhvJNjBbdkVMMqvxipPrIKA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = OQqNOVoGoczTYCDAEtHlyWEphdzw + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void xXYbvRvCbIYCCPEfLUNVKbCkEbZl(byte P_0, int P_1)
	{
		if (1 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		OQqNOVoGoczTYCDAEtHlyWEphdzw[P_1] = P_0;
	}

	public unsafe void lFdJukKfshIIkriXWTeQDlvBgGEi(short P_0, int P_1)
	{
		if (2 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_1) = P_0;
	}

	public unsafe void czqwfpAgUIagjrrpIqhFifnMdKOZ(ushort P_0, int P_1)
	{
		if (2 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_1) = P_0;
	}

	public unsafe void SEThUCIPzGInRJDNIcWTuLAdIAOKA(int P_0, int P_1)
	{
		if (4 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_1) = P_0;
	}

	public unsafe void epcGTZQACHSDNFmNWcYmUggcxXYt(uint P_0, int P_1)
	{
		if (4 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_1) = P_0;
	}

	public unsafe void bUEevAZhmeHzFarjomLKcKaDWGYfA(long P_0, int P_1)
	{
		if (8 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_1) = P_0;
	}

	public unsafe void emjldDhDAgSCXRnorKruqIygBEtp(ulong P_0, int P_1)
	{
		if (8 + P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(OQqNOVoGoczTYCDAEtHlyWEphdzw + P_1) = P_0;
	}

	public unsafe void timaIltUffqkysyWcOZIVbctMCzT(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_2 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_1 + P_2 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)OQqNOVoGoczTYCDAEtHlyWEphdzw, P_3, P_2, P_1);
	}

	public unsafe void isOCkLOlntmYQyTFiTWMeZpOZNDk(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_3 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_2 + P_3 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(P_0, OQqNOVoGoczTYCDAEtHlyWEphdzw, P_4, P_3, P_2);
	}

	public unsafe void WklshKmWzqJRnmAwJSRhdoovQSTB(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		isOCkLOlntmYQyTFiTWMeZpOZNDk((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int usDishqiHDqBGeojJGfNmkavjjaFA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_1 + P_2 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			P_1 = OpLzVVXcQqkwabLhesGulDzEbxvb - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)OQqNOVoGoczTYCDAEtHlyWEphdzw, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int rEVCiRHXNxefqkUjYIbeHxWFKUjTB(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= OpLzVVXcQqkwabLhesGulDzEbxvb)
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
		if (P_2 + P_3 > OpLzVVXcQqkwabLhesGulDzEbxvb)
		{
			P_2 = OpLzVVXcQqkwabLhesGulDzEbxvb - P_3;
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(P_0, OQqNOVoGoczTYCDAEtHlyWEphdzw, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int lJJrgEtqflfKyCItsguSRaQtFZY(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return rEVCiRHXNxefqkUjYIbeHxWFKUjTB((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool NDXlJjhRkIwWhygKpffNePFCxUPrA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (OpLzVVXcQqkwabLhesGulDzEbxvb == P_0)
		{
			return true;
		}
		eYnPgmZYoPWVbTwpfoEVOTiqAfrD();
		if (P_0 == 0)
		{
			return true;
		}
		OpLzVVXcQqkwabLhesGulDzEbxvb = P_0;
		OQqNOVoGoczTYCDAEtHlyWEphdzw = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		UfCSPqYMCQfcRtBRNVWSCflAsAPh();
		return true;
	}

	public unsafe void UfCSPqYMCQfcRtBRNVWSCflAsAPh()
	{
		if (OpLzVVXcQqkwabLhesGulDzEbxvb != 0)
		{
			YeypUSYzjFxvMCDxNtGmgYXVPZRT.xbOwmZQwGJcjNgOZBaSqHPiiakDW(OQqNOVoGoczTYCDAEtHlyWEphdzw, OpLzVVXcQqkwabLhesGulDzEbxvb);
		}
	}

	public unsafe void eYnPgmZYoPWVbTwpfoEVOTiqAfrD()
	{
		if (OpLzVVXcQqkwabLhesGulDzEbxvb == 0)
		{
			return;
		}
		try
		{
			if (OQqNOVoGoczTYCDAEtHlyWEphdzw != null)
			{
				Marshal.FreeHGlobal(eyBEgQddWmEhKFIjmzzsIEzjWKoKA);
			}
		}
		catch
		{
		}
		OQqNOVoGoczTYCDAEtHlyWEphdzw = null;
		OpLzVVXcQqkwabLhesGulDzEbxvb = 0;
	}

	public string YjsbncCZUHAsyMVXUXdKDGZhYFCr()
	{
		string text = "";
		for (int i = 0; i < OpLzVVXcQqkwabLhesGulDzEbxvb; i++)
		{
			text = text + tijwjjXmJKuNuxblUloAVXNrENBD(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		XinkZbHagWsKZBaQUoeZQboEDpLEA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void XinkZbHagWsKZBaQUoeZQboEDpLEA(bool P_0)
	{
		if (!PUZAUtBWDLcWgBgTMYvUbKNyAdQC)
		{
			eYnPgmZYoPWVbTwpfoEVOTiqAfrD();
			PUZAUtBWDLcWgBgTMYvUbKNyAdQC = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr VQuvJnTUjoKlFUATQfyZhBqInPcxA(zDiYSyaxjBvXsqicoFerveALMbuy P_0)
	{
		return (IntPtr)P_0.OQqNOVoGoczTYCDAEtHlyWEphdzw;
	}

	[SpecialName]
	public unsafe static void* VQuvJnTUjoKlFUATQfyZhBqInPcxA(zDiYSyaxjBvXsqicoFerveALMbuy P_0)
	{
		return P_0.OQqNOVoGoczTYCDAEtHlyWEphdzw;
	}

	public unsafe static bool wwadRASowQwmgpQuTkCeJWcNHuvE(zDiYSyaxjBvXsqicoFerveALMbuy P_0, zDiYSyaxjBvXsqicoFerveALMbuy P_1)
	{
		if (P_0.OpLzVVXcQqkwabLhesGulDzEbxvb == 0)
		{
			P_1.eYnPgmZYoPWVbTwpfoEVOTiqAfrD();
			return true;
		}
		if (P_1.NDXlJjhRkIwWhygKpffNePFCxUPrA(P_0.OpLzVVXcQqkwabLhesGulDzEbxvb))
		{
			P_1.isOCkLOlntmYQyTFiTWMeZpOZNDk(P_0.OQqNOVoGoczTYCDAEtHlyWEphdzw, P_0.OpLzVVXcQqkwabLhesGulDzEbxvb, P_0.OpLzVVXcQqkwabLhesGulDzEbxvb);
			return true;
		}
		return false;
	}
}
