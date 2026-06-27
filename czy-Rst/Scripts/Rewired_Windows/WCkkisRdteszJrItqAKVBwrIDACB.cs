using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class WCkkisRdteszJrItqAKVBwrIDACB : IDisposable
{
	private unsafe byte* YfnCrUnpMFAREFoCMxEgmqfSLZqF;

	private int NiXOKQoJhrIwLIdFLyIcVZoNwFCd;

	private bool lZovCIQTCYpHoAQGCsueiqzasuiR;

	public unsafe byte* BdKOfYloxnhtYUpkQBjSXmKDZguO => YfnCrUnpMFAREFoCMxEgmqfSLZqF;

	public unsafe IntPtr QutFGsgABgGPfQNiUrMvVJIqbUBsA => (IntPtr)YfnCrUnpMFAREFoCMxEgmqfSLZqF;

	public int sDWGGEfREwYTXPSQyBgpPVKfHnGrA => NiXOKQoJhrIwLIdFLyIcVZoNwFCd;

	public unsafe byte OIIdmvccFtqBlLPAWQlodjYVrXdC
	{
		get
		{
			if (P_0 < 0 || P_0 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
			{
				throw new IndexOutOfRangeException();
			}
			return YfnCrUnpMFAREFoCMxEgmqfSLZqF[P_0];
		}
		set
		{
			if (num < 0 || num >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
			{
				throw new IndexOutOfRangeException();
			}
			YfnCrUnpMFAREFoCMxEgmqfSLZqF[num] = b;
		}
	}

	public WCkkisRdteszJrItqAKVBwrIDACB(int P_0)
	{
		gWfSyxShMfGLpVIaCRfCGcStSgMG(P_0);
	}

	public unsafe IntPtr sxSvKeAELyhytkRYfebvoaYuqtdU(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)YfnCrUnpMFAREFoCMxEgmqfSLZqF;
		}
		if (P_0 < 0 || P_0 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe string DoKbsoPPKfXWdXPKtOpnPaJnjqkG()
	{
		string text = "";
		for (int i = 0; i < NiXOKQoJhrIwLIdFLyIcVZoNwFCd; i++)
		{
			text = text + YfnCrUnpMFAREFoCMxEgmqfSLZqF[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool cyYLjLunMFfNePcODBLCUxCKoBXV(int P_0, byte P_1)
	{
		if (1 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (YfnCrUnpMFAREFoCMxEgmqfSLZqF[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte hEOFoUwBtbcfbJOyGZIzWpDpHgXmA(int P_0)
	{
		if (1 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return YfnCrUnpMFAREFoCMxEgmqfSLZqF[P_0];
	}

	public unsafe short ZoyyQIXWqkYtufrMOMvGxTOrGSnB(int P_0)
	{
		if (2 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe ushort hZGneYVKqVWfKtBkYdRAEMSBySWN(int P_0)
	{
		if (2 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe int rfHrzPwOQWjsBcFVvIoTjtxHuJTQ(int P_0)
	{
		if (4 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe uint iKyErtfobngyjxWHnAUZkZDfVOMR(int P_0)
	{
		if (4 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe long ABFKAYdGrZnYSeopJhSoceHMdPUp(int P_0)
	{
		if (8 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe ulong sFeazjyinYzBXuEpXXRmEQiVJXZe(int P_0)
	{
		if (8 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe float srMCprUewDLNSWEaxYYTGpuEKvZW(int P_0)
	{
		if (4 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe double xbWnEgDWPLHjQjtMppXkVlUDKLz(int P_0)
	{
		if (8 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0);
	}

	public unsafe void shidQJLwIDCPFAhUqVCNkOOstNlZ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_2 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_1 + P_2 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_0, P_2, P_3, P_1);
	}

	public unsafe void PdEzFqGnHdovfMlPvxPMNzusfLjd(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_3 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_2 + P_3 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_0, P_3, P_4, P_2);
	}

	public unsafe void qtmNSzRobfdxZZjJIhKGQSqxJviS(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		PdEzFqGnHdovfMlPvxPMNzusfLjd((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int YbQAYsoIOpNFsQEfoikzuGYmOAQJ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_2 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			P_1 = NiXOKQoJhrIwLIdFLyIcVZoNwFCd - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int hinNKUAzxSiNEYlDvdlDuDdqDGwF(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_3 + P_2 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			P_2 = NiXOKQoJhrIwLIdFLyIcVZoNwFCd - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int nuMeiTuSQEnoJqRMpAElkfjqAAyr(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return hinNKUAzxSiNEYlDvdlDuDdqDGwF((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void ebrrIfEDaskkmxOGZfoQmlcGbRcj(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void dGYRnuaDJWkZzNsTWRdHEeNSHuKl(byte P_0, int P_1)
	{
		if (1 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		YfnCrUnpMFAREFoCMxEgmqfSLZqF[P_1] = P_0;
	}

	public unsafe void cocpZdnQSHtCxVhkTynQMfJedcYu(short P_0, int P_1)
	{
		if (2 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void MBiyojzjWduflNdTsGFhBLMTkPebb(ushort P_0, int P_1)
	{
		if (2 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void zzJAfNKuSuVyYRGuvjegzgEyllQCb(int P_0, int P_1)
	{
		if (4 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void TiRDlvkmGaNtTYlhioBaODVSsWnZ(uint P_0, int P_1)
	{
		if (4 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void ObHvQnAyVOxcZjBtofZnjxkacrWl(long P_0, int P_1)
	{
		if (8 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void NwmenAQnWwslJXheITnMIVUGksXr(ulong P_0, int P_1)
	{
		if (8 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void xsYIopJbxfeMSiJlvYuXANTvtqznA(float P_0, int P_1)
	{
		if (4 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void liOoRjVfChiILKrtQJRTDVoFaAJac(double P_0, int P_1)
	{
		if (8 + P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(YfnCrUnpMFAREFoCMxEgmqfSLZqF + P_1) = P_0;
	}

	public unsafe void uwhZqFuCPIbLjDZBPjHehpJPLuMB(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_2 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_1 + P_2 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_3, P_2, P_1);
	}

	public unsafe void iJrgLezHxTJdilYyDDOdbaAcpqLv(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_3 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_2 + P_3 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(P_0, YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_4, P_3, P_2);
	}

	public unsafe void ZHvcmbLUXGDlzDWGZRgaKvTEBlslA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		iJrgLezHxTJdilYyDDOdbaAcpqLv((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int ZICEelgNnkicDHcOZOEXoIKlbksy(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_1 + P_2 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			P_1 = NiXOKQoJhrIwLIdFLyIcVZoNwFCd - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int dEGzBZyfznXpjeGjYisyVbUwZQGb(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
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
		if (P_2 + P_3 > NiXOKQoJhrIwLIdFLyIcVZoNwFCd)
		{
			P_2 = NiXOKQoJhrIwLIdFLyIcVZoNwFCd - P_3;
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(P_0, YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int dGMbKeBdSrhuZJvBHWiKxPDtjLCRA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return dEGzBZyfznXpjeGjYisyVbUwZQGb((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool gWfSyxShMfGLpVIaCRfCGcStSgMG(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (NiXOKQoJhrIwLIdFLyIcVZoNwFCd == P_0)
		{
			return true;
		}
		LVdfgWryyvicubTodEONCeDZBbHH();
		if (P_0 == 0)
		{
			return true;
		}
		NiXOKQoJhrIwLIdFLyIcVZoNwFCd = P_0;
		YfnCrUnpMFAREFoCMxEgmqfSLZqF = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		zZMWsAwrgKDnxtEiXLVKYJcNvdIg();
		return true;
	}

	public unsafe void zZMWsAwrgKDnxtEiXLVKYJcNvdIg()
	{
		if (NiXOKQoJhrIwLIdFLyIcVZoNwFCd != 0)
		{
			IPpGxGoGPNwPwoVzosbzleQVdbB.lLrZFPAbPDJHtUcGzegsjYKhiovqA(YfnCrUnpMFAREFoCMxEgmqfSLZqF, NiXOKQoJhrIwLIdFLyIcVZoNwFCd);
		}
	}

	public unsafe void LVdfgWryyvicubTodEONCeDZBbHH()
	{
		if (NiXOKQoJhrIwLIdFLyIcVZoNwFCd == 0)
		{
			return;
		}
		try
		{
			if (YfnCrUnpMFAREFoCMxEgmqfSLZqF != null)
			{
				Marshal.FreeHGlobal(QutFGsgABgGPfQNiUrMvVJIqbUBsA);
			}
		}
		catch
		{
		}
		YfnCrUnpMFAREFoCMxEgmqfSLZqF = null;
		NiXOKQoJhrIwLIdFLyIcVZoNwFCd = 0;
	}

	public virtual string CSbemypvxXIDGjEIKMLQROHUVggt()
	{
		string text = "";
		for (int i = 0; i < NiXOKQoJhrIwLIdFLyIcVZoNwFCd; i++)
		{
			text = text + hEOFoUwBtbcfbJOyGZIzWpDpHgXmA(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		ajlgsatfjmehXjZgtFmMaFFhPhBJA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void HwaxrDmwPWSkELdqumtSOMFggwOhA()
	{
		try
		{
			ajlgsatfjmehXjZgtFmMaFFhPhBJA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ajlgsatfjmehXjZgtFmMaFFhPhBJA(bool P_0)
	{
		if (!lZovCIQTCYpHoAQGCsueiqzasuiR)
		{
			LVdfgWryyvicubTodEONCeDZBbHH();
			lZovCIQTCYpHoAQGCsueiqzasuiR = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr iROEUBXKiHsLuFzmtEadvrVvfwBfA(WCkkisRdteszJrItqAKVBwrIDACB P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.YfnCrUnpMFAREFoCMxEgmqfSLZqF;
	}

	[SpecialName]
	public unsafe static void* iROEUBXKiHsLuFzmtEadvrVvfwBfA(WCkkisRdteszJrItqAKVBwrIDACB P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.YfnCrUnpMFAREFoCMxEgmqfSLZqF;
	}

	public unsafe static bool mKYhuTspAcuaClVTIAHoxGAQwkfB(WCkkisRdteszJrItqAKVBwrIDACB P_0, WCkkisRdteszJrItqAKVBwrIDACB P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.NiXOKQoJhrIwLIdFLyIcVZoNwFCd == 0)
		{
			P_1.LVdfgWryyvicubTodEONCeDZBbHH();
			return true;
		}
		if (P_1.gWfSyxShMfGLpVIaCRfCGcStSgMG(P_0.NiXOKQoJhrIwLIdFLyIcVZoNwFCd))
		{
			P_1.iJrgLezHxTJdilYyDDOdbaAcpqLv(P_0.YfnCrUnpMFAREFoCMxEgmqfSLZqF, P_0.NiXOKQoJhrIwLIdFLyIcVZoNwFCd, P_0.NiXOKQoJhrIwLIdFLyIcVZoNwFCd);
			return true;
		}
		return false;
	}
}
