using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class QJksuagGosrsxPeZMzvQjeSveRsf : IDisposable
{
	private unsafe byte* SSkIFxhWMmQxPxKHHpRQTdIfDarT;

	private int XKnGeiBqJiVtdLNrJPiVhPqseNmj;

	private bool truKyTqnolwKmjdCxIMxpTxXiGWb;

	public unsafe byte* ICAJmqiibKZnBeMamwppagxMBBqAA => SSkIFxhWMmQxPxKHHpRQTdIfDarT;

	public unsafe IntPtr CWATmlRNTAuuUMgHHgHVGAWglCER => (IntPtr)SSkIFxhWMmQxPxKHHpRQTdIfDarT;

	public int KZOKhrOzkHqxUZgzPSdIryPgABVI => XKnGeiBqJiVtdLNrJPiVhPqseNmj;

	public unsafe byte TGmqzuYlDGbeganFzdJoBzpDKKql
	{
		get
		{
			if (P_0 < 0 || P_0 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
			{
				throw new IndexOutOfRangeException();
			}
			return SSkIFxhWMmQxPxKHHpRQTdIfDarT[P_0];
		}
		set
		{
			if (num < 0 || num >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
			{
				throw new IndexOutOfRangeException();
			}
			SSkIFxhWMmQxPxKHHpRQTdIfDarT[num] = b;
		}
	}

	public QJksuagGosrsxPeZMzvQjeSveRsf(int P_0)
	{
		yUbZwpiEyvqmHeRFQQaYqAncKGIH(P_0);
	}

	public unsafe IntPtr TTMnuPdicaDtjEKQRrLWhrQNKvBy(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)SSkIFxhWMmQxPxKHHpRQTdIfDarT;
		}
		if (P_0 < 0 || P_0 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe string bjNCpOkuMDDNCcKMWzbLcxqLUAfX()
	{
		string text = "";
		for (int i = 0; i < XKnGeiBqJiVtdLNrJPiVhPqseNmj; i++)
		{
			text = text + SSkIFxhWMmQxPxKHHpRQTdIfDarT[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool XOouJHofYbsEVgmExlbZpTVUYvuK(int P_0, byte P_1)
	{
		if (1 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (SSkIFxhWMmQxPxKHHpRQTdIfDarT[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte WuxHIZPjIMIFiNfINICAmmlUUFBX(int P_0)
	{
		if (1 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return SSkIFxhWMmQxPxKHHpRQTdIfDarT[P_0];
	}

	public unsafe short YERcoBWqJbHizOIjENzehydIwKVt(int P_0)
	{
		if (2 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe ushort HNmHYwIrXqoydUgqBGdWIkbBVbhG(int P_0)
	{
		if (2 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe int pZawEVOEhEKmAyGbwfUMDPIsGnhe(int P_0)
	{
		if (4 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe uint IZOdqdeHkmvhjUapnSNOsHHPckkeA(int P_0)
	{
		if (4 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe long PZDPAartEJhJPGOSiUHSzSWDAieK(int P_0)
	{
		if (8 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe ulong jPYEtlIceSiznOtjgCDHIvTsiwhc(int P_0)
	{
		if (8 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0);
	}

	public unsafe void FMnKPRoBUfxchLzbyZPJBmxlxGub(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_2 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_1 + P_2 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_0, P_2, P_3, P_1);
	}

	public unsafe void iczbdBZxscByllmNPCCkeFDrNFDL(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_3 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_2 + P_3 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_0, P_3, P_4, P_2);
	}

	public unsafe void rptfEALcqjkxWdduWvTFPjdvGnAD(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		iczbdBZxscByllmNPCCkeFDrNFDL((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int XlVRaIsXEtlHdcTTtpoBoRLmQEOV(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_2 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			P_1 = XKnGeiBqJiVtdLNrJPiVhPqseNmj - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int BdjlHUvzluSnctnhCaWznEGyorFX(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_3 + P_2 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			P_2 = XKnGeiBqJiVtdLNrJPiVhPqseNmj - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int vfrxvNjKHGwItFMVMIZRqcpKiQgB(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return BdjlHUvzluSnctnhCaWznEGyorFX((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void UsbexhEQkWRUehtCxqgKCIJYRoUMA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void duwDjNerimGZcFrqATZQCzjglvkMD(byte P_0, int P_1)
	{
		if (1 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		SSkIFxhWMmQxPxKHHpRQTdIfDarT[P_1] = P_0;
	}

	public unsafe void dBxmidDKiNFhosYcoSTDuyujzPam(short P_0, int P_1)
	{
		if (2 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_1) = P_0;
	}

	public unsafe void pZDbYnTjcOJiYktUnhnQjOiNgZGS(ushort P_0, int P_1)
	{
		if (2 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_1) = P_0;
	}

	public unsafe void DuwFwxMYLWyoHXAjeeFPBLxUVffK(int P_0, int P_1)
	{
		if (4 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_1) = P_0;
	}

	public unsafe void QHvVhOitWFvDXrDtQEJyZLzQQlp(uint P_0, int P_1)
	{
		if (4 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_1) = P_0;
	}

	public unsafe void CyzOfqqrwEIbYWFlNklKhZqqHcNn(long P_0, int P_1)
	{
		if (8 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_1) = P_0;
	}

	public unsafe void sOeGRYGazMSQXBpJLOyvGGCdyGHac(ulong P_0, int P_1)
	{
		if (8 + P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(SSkIFxhWMmQxPxKHHpRQTdIfDarT + P_1) = P_0;
	}

	public unsafe void qeoXnqVyaRAiPlmzmoFgqgSLOmet(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_2 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_1 + P_2 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_3, P_2, P_1);
	}

	public unsafe void nFhVBpXStRncmGCGCkbjvaDCBLwP(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_3 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_2 + P_3 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(P_0, SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_4, P_3, P_2);
	}

	public unsafe void qYLNVIHasohqPEGILmCuTlQyYgPO(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		nFhVBpXStRncmGCGCkbjvaDCBLwP((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int cJXzVkkFTNESXLTKfPCOUcRIdmTK(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_1 + P_2 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			P_1 = XKnGeiBqJiVtdLNrJPiVhPqseNmj - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int FksIzFGWOXAYZjBNPYCpoLWihMK(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= XKnGeiBqJiVtdLNrJPiVhPqseNmj)
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
		if (P_2 + P_3 > XKnGeiBqJiVtdLNrJPiVhPqseNmj)
		{
			P_2 = XKnGeiBqJiVtdLNrJPiVhPqseNmj - P_3;
		}
		gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(P_0, SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int ujoJLveWVfivzOykBFtZYrYGMEfl(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return FksIzFGWOXAYZjBNPYCpoLWihMK((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool yUbZwpiEyvqmHeRFQQaYqAncKGIH(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (XKnGeiBqJiVtdLNrJPiVhPqseNmj == P_0)
		{
			return true;
		}
		EWCoZZWbECcTsjZQOCxeoSuJOybuA();
		if (P_0 == 0)
		{
			return true;
		}
		XKnGeiBqJiVtdLNrJPiVhPqseNmj = P_0;
		SSkIFxhWMmQxPxKHHpRQTdIfDarT = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		cgwCtFyawxBITihnZeiHflxvdNGI();
		return true;
	}

	public unsafe void cgwCtFyawxBITihnZeiHflxvdNGI()
	{
		if (XKnGeiBqJiVtdLNrJPiVhPqseNmj != 0)
		{
			gkeZAoVSdvnpEhiPWCalNOchbIMDA.FIpRwqifBWkeENHkDcWIQXtqBdtR(SSkIFxhWMmQxPxKHHpRQTdIfDarT, XKnGeiBqJiVtdLNrJPiVhPqseNmj);
		}
	}

	public unsafe void EWCoZZWbECcTsjZQOCxeoSuJOybuA()
	{
		if (XKnGeiBqJiVtdLNrJPiVhPqseNmj == 0)
		{
			return;
		}
		try
		{
			if (SSkIFxhWMmQxPxKHHpRQTdIfDarT != null)
			{
				Marshal.FreeHGlobal(CWATmlRNTAuuUMgHHgHVGAWglCER);
			}
		}
		catch
		{
		}
		SSkIFxhWMmQxPxKHHpRQTdIfDarT = null;
		XKnGeiBqJiVtdLNrJPiVhPqseNmj = 0;
	}

	public virtual string DlvpbYKRMuuoMknREEULWKVjgPJk()
	{
		string text = "";
		for (int i = 0; i < XKnGeiBqJiVtdLNrJPiVhPqseNmj; i++)
		{
			text = text + WuxHIZPjIMIFiNfINICAmmlUUFBX(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		gXiRRoZkijEjebQwQXTbAgSuccmVA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void iAUhljIQVwUtnFVWfxGJBEyeccvNA()
	{
		try
		{
			gXiRRoZkijEjebQwQXTbAgSuccmVA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void gXiRRoZkijEjebQwQXTbAgSuccmVA(bool P_0)
	{
		if (!truKyTqnolwKmjdCxIMxpTxXiGWb)
		{
			EWCoZZWbECcTsjZQOCxeoSuJOybuA();
			truKyTqnolwKmjdCxIMxpTxXiGWb = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr UEMLrcCffLIbYhsVtbQCeEhhaeQsB(QJksuagGosrsxPeZMzvQjeSveRsf P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.SSkIFxhWMmQxPxKHHpRQTdIfDarT;
	}

	[SpecialName]
	public unsafe static void* UEMLrcCffLIbYhsVtbQCeEhhaeQsB(QJksuagGosrsxPeZMzvQjeSveRsf P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.SSkIFxhWMmQxPxKHHpRQTdIfDarT;
	}

	public unsafe static bool kuQXLzDCyPyNlnaKAZUgAFuaDmjT(QJksuagGosrsxPeZMzvQjeSveRsf P_0, QJksuagGosrsxPeZMzvQjeSveRsf P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.XKnGeiBqJiVtdLNrJPiVhPqseNmj == 0)
		{
			P_1.EWCoZZWbECcTsjZQOCxeoSuJOybuA();
			return true;
		}
		if (P_1.yUbZwpiEyvqmHeRFQQaYqAncKGIH(P_0.XKnGeiBqJiVtdLNrJPiVhPqseNmj))
		{
			P_1.nFhVBpXStRncmGCGCkbjvaDCBLwP(P_0.SSkIFxhWMmQxPxKHHpRQTdIfDarT, P_0.XKnGeiBqJiVtdLNrJPiVhPqseNmj, P_0.XKnGeiBqJiVtdLNrJPiVhPqseNmj);
			return true;
		}
		return false;
	}
}
