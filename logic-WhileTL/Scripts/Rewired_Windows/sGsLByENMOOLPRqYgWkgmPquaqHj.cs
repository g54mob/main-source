using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class sGsLByENMOOLPRqYgWkgmPquaqHj : IDisposable
{
	private unsafe byte* CAwQSgnEMPQXllGnSidiuDnNgeFBA;

	private int qvNnbHxDpgklNDwSUOwyDbSANInv;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public unsafe byte* lJAEFSAExMFfSRjgdarUvoDZOKAI => CAwQSgnEMPQXllGnSidiuDnNgeFBA;

	public unsafe IntPtr kWRTOHULzKpCRgNuSFABYNYVScy => (IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA;

	public int eohFsdVkRvyEdEIhDuGsBlzpfOFx => qvNnbHxDpgklNDwSUOwyDbSANInv;

	public unsafe byte uwmaNFaseKnqmacVHofPxXyRyWCh
	{
		get
		{
			if (P_0 < 0 || P_0 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
			{
				throw new IndexOutOfRangeException();
			}
			return CAwQSgnEMPQXllGnSidiuDnNgeFBA[P_0];
		}
		set
		{
			if (num < 0 || num >= qvNnbHxDpgklNDwSUOwyDbSANInv)
			{
				throw new IndexOutOfRangeException();
			}
			CAwQSgnEMPQXllGnSidiuDnNgeFBA[num] = b;
		}
	}

	public sGsLByENMOOLPRqYgWkgmPquaqHj(int P_0)
	{
		cCjKuDgROonfNLMAfvwwFPJvqRHJ(P_0);
	}

	public unsafe IntPtr FnOpUWBfNjxXtflJSWkGzVfQFQVe(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA;
		}
		if (P_0 < 0 || P_0 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe string sYtqsiedrxoisUJoWhfbeFEoajgSA()
	{
		string text = "";
		for (int i = 0; i < qvNnbHxDpgklNDwSUOwyDbSANInv; i++)
		{
			text = text + CAwQSgnEMPQXllGnSidiuDnNgeFBA[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool oOHyUBktSMJXfbCdChgYfvxvbFGf(int P_0, byte P_1)
	{
		if (1 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (CAwQSgnEMPQXllGnSidiuDnNgeFBA[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte OafCdSHtDqYqFRHvGdykrtYxVUuo(int P_0)
	{
		if (1 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return CAwQSgnEMPQXllGnSidiuDnNgeFBA[P_0];
	}

	public unsafe short HyoGRqCMTgzwHQouSETFUOJAoXoK(int P_0)
	{
		if (2 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe ushort XJCdnLbDlNvRpLhMGaHmZyAMetZCb(int P_0)
	{
		if (2 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe int KmOBBotwDUQQhfIgeStTOIKMmrnM(int P_0)
	{
		if (4 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe uint wrsnkRHalVtRAfehvDczAcBClnZU(int P_0)
	{
		if (4 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe long fdteAxyAfeBoeGmIhBtJHIRxLgVQA(int P_0)
	{
		if (8 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe ulong dVXTyNnPrRiyWCmCTUNAnyYlonZd(int P_0)
	{
		if (8 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0);
	}

	public unsafe void lpzCMyRwfnpZCqiMQhipRjGrjZfC(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_2 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_1 + P_2 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_2, P_3, P_1);
	}

	public unsafe void lpzCMyRwfnpZCqiMQhipRjGrjZfC(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_3 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_2 + P_3 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_3, P_4, P_2);
	}

	public unsafe void lpzCMyRwfnpZCqiMQhipRjGrjZfC(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		lpzCMyRwfnpZCqiMQhipRjGrjZfC((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_2 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			P_1 = qvNnbHxDpgklNDwSUOwyDbSANInv - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_3 + P_2 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			P_2 = qvNnbHxDpgklNDwSUOwyDbSANInv - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return eYvBZBVlKdXWRcNEjwXxUBhbbrcEA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void KfPSZwqWNtVwJjVAFSAYVlVIHIub(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(byte P_0, int P_1)
	{
		if (1 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		CAwQSgnEMPQXllGnSidiuDnNgeFBA[P_1] = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(short P_0, int P_1)
	{
		if (2 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_1) = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(ushort P_0, int P_1)
	{
		if (2 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_1) = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(int P_0, int P_1)
	{
		if (4 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_1) = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(uint P_0, int P_1)
	{
		if (4 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_1) = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(long P_0, int P_1)
	{
		if (8 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_1) = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(ulong P_0, int P_1)
	{
		if (8 + P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(CAwQSgnEMPQXllGnSidiuDnNgeFBA + P_1) = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_2 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_1 + P_2 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_3, P_2, P_1);
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_3 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_2 + P_3 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(P_0, CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_4, P_3, P_2);
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		EGngQqDBRXlpYmNfKVeBqXohueYWA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int USkYhwVnEVvwgNsEgQdHaEKaErnhA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_1 + P_2 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			P_1 = qvNnbHxDpgklNDwSUOwyDbSANInv - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int USkYhwVnEVvwgNsEgQdHaEKaErnhA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= qvNnbHxDpgklNDwSUOwyDbSANInv)
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
		if (P_2 + P_3 > qvNnbHxDpgklNDwSUOwyDbSANInv)
		{
			P_2 = qvNnbHxDpgklNDwSUOwyDbSANInv - P_3;
		}
		OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(P_0, CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int USkYhwVnEVvwgNsEgQdHaEKaErnhA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return USkYhwVnEVvwgNsEgQdHaEKaErnhA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool cCjKuDgROonfNLMAfvwwFPJvqRHJ(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (qvNnbHxDpgklNDwSUOwyDbSANInv == P_0)
		{
			return true;
		}
		rfJkWsvxGMlRenLlOOBdfCJYbZrT();
		if (P_0 == 0)
		{
			return true;
		}
		qvNnbHxDpgklNDwSUOwyDbSANInv = P_0;
		CAwQSgnEMPQXllGnSidiuDnNgeFBA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		PNnwosyJbZAkbwObisgdtMytZJol();
		return true;
	}

	public unsafe void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		if (qvNnbHxDpgklNDwSUOwyDbSANInv != 0)
		{
			OLserehNWHIbghIOsZgXEwMqColl.FJjDIrhOqYyHrnbHvbLOaYKUEctM(CAwQSgnEMPQXllGnSidiuDnNgeFBA, qvNnbHxDpgklNDwSUOwyDbSANInv);
		}
	}

	public unsafe void rfJkWsvxGMlRenLlOOBdfCJYbZrT()
	{
		if (qvNnbHxDpgklNDwSUOwyDbSANInv == 0)
		{
			return;
		}
		try
		{
			if (CAwQSgnEMPQXllGnSidiuDnNgeFBA != null)
			{
				Marshal.FreeHGlobal(kWRTOHULzKpCRgNuSFABYNYVScy);
			}
		}
		catch
		{
		}
		CAwQSgnEMPQXllGnSidiuDnNgeFBA = null;
		qvNnbHxDpgklNDwSUOwyDbSANInv = 0;
	}

	public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		string text = "";
		for (int i = 0; i < qvNnbHxDpgklNDwSUOwyDbSANInv; i++)
		{
			text = text + OafCdSHtDqYqFRHvGdykrtYxVUuo(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			rfJkWsvxGMlRenLlOOBdfCJYbZrT();
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr hWHeOZGaMchoUxcjVNFKgCLOCcPd(sGsLByENMOOLPRqYgWkgmPquaqHj P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA;
	}

	[SpecialName]
	public unsafe static void* hWHeOZGaMchoUxcjVNFKgCLOCcPd(sGsLByENMOOLPRqYgWkgmPquaqHj P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA;
	}

	public unsafe static bool WOxPZyqaQAxfKyREtyXyUsgojyvb(sGsLByENMOOLPRqYgWkgmPquaqHj P_0, sGsLByENMOOLPRqYgWkgmPquaqHj P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.qvNnbHxDpgklNDwSUOwyDbSANInv == 0)
		{
			P_1.rfJkWsvxGMlRenLlOOBdfCJYbZrT();
			return true;
		}
		if (P_1.cCjKuDgROonfNLMAfvwwFPJvqRHJ(P_0.qvNnbHxDpgklNDwSUOwyDbSANInv))
		{
			P_1.EGngQqDBRXlpYmNfKVeBqXohueYWA(P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0.qvNnbHxDpgklNDwSUOwyDbSANInv, P_0.qvNnbHxDpgklNDwSUOwyDbSANInv);
			return true;
		}
		return false;
	}
}
