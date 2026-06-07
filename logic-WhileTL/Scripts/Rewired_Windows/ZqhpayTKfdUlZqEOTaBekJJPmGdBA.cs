using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class ZqhpayTKfdUlZqEOTaBekJJPmGdBA : IDisposable
{
	private readonly byte[] pshxLsVBaxPobdRQOPmmlqHPIgYt;

	public readonly int eohFsdVkRvyEdEIhDuGsBlzpfOFx;

	private GCHandle ymOoSEjKtQPwHyzBjjQSQuZDFbsy;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public bool JFlMCUNgdZbxbGsBMkhvdxJMZiWK => ymOoSEjKtQPwHyzBjjQSQuZDFbsy.IsAllocated;

	public byte uwmaNFaseKnqmacVHofPxXyRyWCh
	{
		get
		{
			return pshxLsVBaxPobdRQOPmmlqHPIgYt[P_0];
		}
		set
		{
			pshxLsVBaxPobdRQOPmmlqHPIgYt[num] = b;
		}
	}

	public ZqhpayTKfdUlZqEOTaBekJJPmGdBA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		eohFsdVkRvyEdEIhDuGsBlzpfOFx = P_0;
		pshxLsVBaxPobdRQOPmmlqHPIgYt = new byte[P_0];
	}

	public IntPtr qIKtTitANZTazFDzrqgkjmZQkBkK()
	{
		if (ymOoSEjKtQPwHyzBjjQSQuZDFbsy.IsAllocated)
		{
			return ymOoSEjKtQPwHyzBjjQSQuZDFbsy.AddrOfPinnedObject();
		}
		ymOoSEjKtQPwHyzBjjQSQuZDFbsy = GCHandle.Alloc(pshxLsVBaxPobdRQOPmmlqHPIgYt, GCHandleType.Pinned);
		return ymOoSEjKtQPwHyzBjjQSQuZDFbsy.AddrOfPinnedObject();
	}

	public void ZTPGKGqUBTqfkZIcpZWTvrBVkoJT()
	{
		if (ymOoSEjKtQPwHyzBjjQSQuZDFbsy.IsAllocated)
		{
			ymOoSEjKtQPwHyzBjjQSQuZDFbsy.Free();
		}
	}

	public string sYtqsiedrxoisUJoWhfbeFEoajgSA()
	{
		string text = "";
		for (int i = 0; i < eohFsdVkRvyEdEIhDuGsBlzpfOFx; i++)
		{
			text = text + pshxLsVBaxPobdRQOPmmlqHPIgYt[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool oOHyUBktSMJXfbCdChgYfvxvbFGf(int P_0, byte P_1)
	{
		if (1 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (pshxLsVBaxPobdRQOPmmlqHPIgYt[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte OafCdSHtDqYqFRHvGdykrtYxVUuo(int P_0)
	{
		if (1 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return pshxLsVBaxPobdRQOPmmlqHPIgYt[P_0];
	}

	public unsafe short HyoGRqCMTgzwHQouSETFUOJAoXoK(int P_0)
	{
		if (2 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort XJCdnLbDlNvRpLhMGaHmZyAMetZCb(int P_0)
	{
		if (2 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int KmOBBotwDUQQhfIgeStTOIKMmrnM(int P_0)
	{
		if (4 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint wrsnkRHalVtRAfehvDczAcBClnZU(int P_0)
	{
		if (4 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long fdteAxyAfeBoeGmIhBtJHIRxLgVQA(int P_0)
	{
		if (8 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong dVXTyNnPrRiyWCmCTUNAnyYlonZd(int P_0)
	{
		if (8 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void lpzCMyRwfnpZCqiMQhipRjGrjZfC(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_2 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_1 + P_2 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(pshxLsVBaxPobdRQOPmmlqHPIgYt, P_2, P_0, P_3, P_1);
	}

	public void lpzCMyRwfnpZCqiMQhipRjGrjZfC(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_3 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_2 + P_3 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(pshxLsVBaxPobdRQOPmmlqHPIgYt, P_0, P_3, P_4, P_2);
	}

	public int eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_2 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			P_1 = eohFsdVkRvyEdEIhDuGsBlzpfOFx - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(pshxLsVBaxPobdRQOPmmlqHPIgYt, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_3 + P_2 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			P_2 = eohFsdVkRvyEdEIhDuGsBlzpfOFx - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(pshxLsVBaxPobdRQOPmmlqHPIgYt, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void KfPSZwqWNtVwJjVAFSAYVlVIHIub(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			pshxLsVBaxPobdRQOPmmlqHPIgYt[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			pshxLsVBaxPobdRQOPmmlqHPIgYt[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void EGngQqDBRXlpYmNfKVeBqXohueYWA(byte P_0, int P_1)
	{
		if (1 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		pshxLsVBaxPobdRQOPmmlqHPIgYt[P_1] = P_0;
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(short P_0, int P_1)
	{
		if (2 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(ushort P_0, int P_1)
	{
		if (2 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(int P_0, int P_1)
	{
		if (4 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(uint P_0, int P_1)
	{
		if (4 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(long P_0, int P_1)
	{
		if (8 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EGngQqDBRXlpYmNfKVeBqXohueYWA(ulong P_0, int P_1)
	{
		if (8 + P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = pshxLsVBaxPobdRQOPmmlqHPIgYt)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void EGngQqDBRXlpYmNfKVeBqXohueYWA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_2 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_1 + P_2 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, pshxLsVBaxPobdRQOPmmlqHPIgYt, P_2, P_1);
	}

	public void EGngQqDBRXlpYmNfKVeBqXohueYWA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_3 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_2 + P_3 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, pshxLsVBaxPobdRQOPmmlqHPIgYt, P_4, P_3, P_2);
	}

	public int USkYhwVnEVvwgNsEgQdHaEKaErnhA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_1 + P_2 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			P_1 = eohFsdVkRvyEdEIhDuGsBlzpfOFx - P_2;
		}
		Array.Copy(P_0, P_3, pshxLsVBaxPobdRQOPmmlqHPIgYt, P_2, P_1);
		return P_1;
	}

	public int USkYhwVnEVvwgNsEgQdHaEKaErnhA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= eohFsdVkRvyEdEIhDuGsBlzpfOFx)
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
		if (P_2 + P_3 > eohFsdVkRvyEdEIhDuGsBlzpfOFx)
		{
			P_2 = eohFsdVkRvyEdEIhDuGsBlzpfOFx - P_3;
		}
		NativeTools.CopyMemory(P_0, pshxLsVBaxPobdRQOPmmlqHPIgYt, P_4, P_3, P_2);
		return P_2;
	}

	public void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		Array.Clear(pshxLsVBaxPobdRQOPmmlqHPIgYt, 0, eohFsdVkRvyEdEIhDuGsBlzpfOFx);
	}

	public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		string text = "";
		for (int i = 0; i < eohFsdVkRvyEdEIhDuGsBlzpfOFx; i++)
		{
			text = text + this.kgwdsbyPYraFCzTnGhgMYpoQdzaC(i).ToString("x2") + " ";
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
			if (ymOoSEjKtQPwHyzBjjQSQuZDFbsy.IsAllocated)
			{
				ymOoSEjKtQPwHyzBjjQSQuZDFbsy.Free();
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	public static void WOxPZyqaQAxfKyREtyXyUsgojyvb(ZqhpayTKfdUlZqEOTaBekJJPmGdBA P_0, ZqhpayTKfdUlZqEOTaBekJJPmGdBA P_1, int P_2)
	{
		Array.Copy(P_0.pshxLsVBaxPobdRQOPmmlqHPIgYt, P_1.pshxLsVBaxPobdRQOPmmlqHPIgYt, P_2);
	}

	public static void WOxPZyqaQAxfKyREtyXyUsgojyvb(ZqhpayTKfdUlZqEOTaBekJJPmGdBA P_0, int P_1, ZqhpayTKfdUlZqEOTaBekJJPmGdBA P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.pshxLsVBaxPobdRQOPmmlqHPIgYt, P_1, P_2.pshxLsVBaxPobdRQOPmmlqHPIgYt, P_3, P_4);
	}
}
