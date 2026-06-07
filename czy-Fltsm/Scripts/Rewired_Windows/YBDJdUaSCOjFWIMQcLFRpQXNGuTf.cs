using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class YBDJdUaSCOjFWIMQcLFRpQXNGuTf : IDisposable
{
	private readonly byte[] sFdUkLtumgOmVrEiPmwhCYyxHGhm;

	public readonly int yTxClVADKTBYWghqvWHruhgXSieR;

	private GCHandle saFhllbCVfztqHJGrTuMRBmTraeF;

	private bool vDLrMdnAlRDQlhJybCoWWKehGNoe;

	public bool bsmHvjivjYgROzUhHeMVxikOLBWN => saFhllbCVfztqHJGrTuMRBmTraeF.IsAllocated;

	public byte sgIXvUNvnFiQUWurdSPDZGTZuPd
	{
		get
		{
			return sFdUkLtumgOmVrEiPmwhCYyxHGhm[P_0];
		}
		set
		{
			sFdUkLtumgOmVrEiPmwhCYyxHGhm[num] = b;
		}
	}

	public YBDJdUaSCOjFWIMQcLFRpQXNGuTf(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		yTxClVADKTBYWghqvWHruhgXSieR = P_0;
		sFdUkLtumgOmVrEiPmwhCYyxHGhm = new byte[P_0];
	}

	public IntPtr koTekauGKqAFIczjeEtWnViaCyVe()
	{
		if (saFhllbCVfztqHJGrTuMRBmTraeF.IsAllocated)
		{
			return saFhllbCVfztqHJGrTuMRBmTraeF.AddrOfPinnedObject();
		}
		saFhllbCVfztqHJGrTuMRBmTraeF = GCHandle.Alloc(sFdUkLtumgOmVrEiPmwhCYyxHGhm, GCHandleType.Pinned);
		return saFhllbCVfztqHJGrTuMRBmTraeF.AddrOfPinnedObject();
	}

	public void IWsVekACoalvsiKFHcVUqXszhdMx()
	{
		if (saFhllbCVfztqHJGrTuMRBmTraeF.IsAllocated)
		{
			saFhllbCVfztqHJGrTuMRBmTraeF.Free();
		}
	}

	public string pmPnaFsiFZBYGCzaVfpGbAckxTFL()
	{
		string text = "";
		for (int i = 0; i < yTxClVADKTBYWghqvWHruhgXSieR; i++)
		{
			text = text + sFdUkLtumgOmVrEiPmwhCYyxHGhm[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool fdUEOxbRVqIZAhmPwUCMUhvNjMjm(int P_0, byte P_1)
	{
		if (1 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (sFdUkLtumgOmVrEiPmwhCYyxHGhm[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte smgeKPbcSCFKEKwultvlrDGlLUeu(int P_0)
	{
		if (1 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return sFdUkLtumgOmVrEiPmwhCYyxHGhm[P_0];
	}

	public unsafe short yeeIaALOlMaeTdIILvJTjMyhmowxA(int P_0)
	{
		if (2 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort XXDqBiNjMvIsjPblzGQkLwZrFovFA(int P_0)
	{
		if (2 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int kywVuLuCLRQBYjYeLrOZoenWzNjS(int P_0)
	{
		if (4 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint eXLecQehairqjgDFerhtpntQEewIc(int P_0)
	{
		if (4 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long sXSRkeaEVfFJWdKDJJqkMmNVbOVU(int P_0)
	{
		if (8 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong zlvhMtgaAbhYjFkabvEzHdpphEPhb(int P_0)
	{
		if (8 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void upusjBjpzoETzxttqAXynsqyGrJO(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_2 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_1 + P_2 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_2, P_0, P_3, P_1);
	}

	public void FaAUttvvRgdHjSEJJWhJxNuHcrFL(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_3 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_2 + P_3 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_0, P_3, P_4, P_2);
	}

	public int BHTNPFsnsSbBvTeGtQhxNCxNgQzV(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_2 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			P_1 = yTxClVADKTBYWghqvWHruhgXSieR - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int oWWmVCUkjXQdhwUhUnjMzccqTPuB(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_3 + P_2 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			P_2 = yTxClVADKTBYWghqvWHruhgXSieR - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void ZIFJrZYffEJFaIyoJsYxfauUfwUCA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > yTxClVADKTBYWghqvWHruhgXSieR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			sFdUkLtumgOmVrEiPmwhCYyxHGhm[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			sFdUkLtumgOmVrEiPmwhCYyxHGhm[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void xzCHBbvQhjGdOcWNNelTrLoekHtl(byte P_0, int P_1)
	{
		if (1 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		sFdUkLtumgOmVrEiPmwhCYyxHGhm[P_1] = P_0;
	}

	public unsafe void yLEyCXfsCbkSXnnOivXrcIDIpCul(short P_0, int P_1)
	{
		if (2 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void oUDGJSPbfWydCbOmcvPPLdbRsPLA(ushort P_0, int P_1)
	{
		if (2 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void QCCcznhmMiIIiZKKbuFcSnRqbgHR(int P_0, int P_1)
	{
		if (4 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void RapsolPvRSKgsejuEmuLgDnbGIeaA(uint P_0, int P_1)
	{
		if (4 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void rHhxkSNYwPEDqPGJMiVndSmIoKet(long P_0, int P_1)
	{
		if (8 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void YDYEoBMNuBNTcVGaBihFoJHoGoqB(ulong P_0, int P_1)
	{
		if (8 + P_1 > yTxClVADKTBYWghqvWHruhgXSieR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = sFdUkLtumgOmVrEiPmwhCYyxHGhm)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void JKZbGZDCtWgGsFRdqhsialKDZaLtb(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_2 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_1 + P_2 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_2, P_1);
	}

	public void HLgUeqCKkDLWcLIbnowwXANLmyCl(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_3 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_2 + P_3 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_4, P_3, P_2);
	}

	public int jIMrikKandNASupxEbZfArEmbAFW(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_1 + P_2 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			P_1 = yTxClVADKTBYWghqvWHruhgXSieR - P_2;
		}
		Array.Copy(P_0, P_3, sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_2, P_1);
		return P_1;
	}

	public int XNrIPaeTqEeaukaLEOSdDwokjsPM(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= yTxClVADKTBYWghqvWHruhgXSieR)
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
		if (P_2 + P_3 > yTxClVADKTBYWghqvWHruhgXSieR)
		{
			P_2 = yTxClVADKTBYWghqvWHruhgXSieR - P_3;
		}
		NativeTools.CopyMemory(P_0, sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_4, P_3, P_2);
		return P_2;
	}

	public void IPqHPczjfcxiDEYIBRyrxCUcJICW()
	{
		Array.Clear(sFdUkLtumgOmVrEiPmwhCYyxHGhm, 0, yTxClVADKTBYWghqvWHruhgXSieR);
	}

	public virtual string bbvjGfpkSYVlMnFzzWMHmCynOzIv()
	{
		string text = "";
		for (int i = 0; i < yTxClVADKTBYWghqvWHruhgXSieR; i++)
		{
			text = text + this.VkKUOcDYfTRKhfvJytiaFSaPBTPaA(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		CrlIHsyrYJxnoTnUOvuYUCPuKSZD(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void olTovnrBnxsawucoCzxAEZNWcNsC()
	{
		try
		{
			CrlIHsyrYJxnoTnUOvuYUCPuKSZD(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void CrlIHsyrYJxnoTnUOvuYUCPuKSZD(bool P_0)
	{
		if (!vDLrMdnAlRDQlhJybCoWWKehGNoe)
		{
			if (saFhllbCVfztqHJGrTuMRBmTraeF.IsAllocated)
			{
				saFhllbCVfztqHJGrTuMRBmTraeF.Free();
			}
			vDLrMdnAlRDQlhJybCoWWKehGNoe = true;
		}
	}

	public static void aySZPWUziyTxaeXEAPPSwNQERPzF(YBDJdUaSCOjFWIMQcLFRpQXNGuTf P_0, YBDJdUaSCOjFWIMQcLFRpQXNGuTf P_1, int P_2)
	{
		Array.Copy(P_0.sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_1.sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_2);
	}

	public static void CacNbFRxuKriygArXCwFfdZDxrHP(YBDJdUaSCOjFWIMQcLFRpQXNGuTf P_0, int P_1, YBDJdUaSCOjFWIMQcLFRpQXNGuTf P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_1, P_2.sFdUkLtumgOmVrEiPmwhCYyxHGhm, P_3, P_4);
	}
}
