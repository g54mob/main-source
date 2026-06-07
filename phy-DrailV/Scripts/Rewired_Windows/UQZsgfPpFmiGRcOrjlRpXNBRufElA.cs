using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class UQZsgfPpFmiGRcOrjlRpXNBRufElA : IDisposable
{
	private readonly byte[] njPEqelkqUAXHcVOBySkfuuGgySaA;

	public readonly int yIVYFnpBLClvFaTdWwokHpQgDIPu;

	private GCHandle iXafrGaJxrnLvEUDiasMbMuhAjsOB;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public bool RyZdnQpFhgUKLeMFBCKpaxsJsNUIA => iXafrGaJxrnLvEUDiasMbMuhAjsOB.IsAllocated;

	public byte uYZQJGUmbMuICFZWSqJprRCobGI
	{
		get
		{
			return njPEqelkqUAXHcVOBySkfuuGgySaA[P_0];
		}
		set
		{
			njPEqelkqUAXHcVOBySkfuuGgySaA[num] = b;
		}
	}

	public UQZsgfPpFmiGRcOrjlRpXNBRufElA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		yIVYFnpBLClvFaTdWwokHpQgDIPu = P_0;
		njPEqelkqUAXHcVOBySkfuuGgySaA = new byte[P_0];
	}

	public IntPtr mucAKgFlEagcRjYrysCczNcZUimT()
	{
		if (iXafrGaJxrnLvEUDiasMbMuhAjsOB.IsAllocated)
		{
			return iXafrGaJxrnLvEUDiasMbMuhAjsOB.AddrOfPinnedObject();
		}
		iXafrGaJxrnLvEUDiasMbMuhAjsOB = GCHandle.Alloc(njPEqelkqUAXHcVOBySkfuuGgySaA, GCHandleType.Pinned);
		return iXafrGaJxrnLvEUDiasMbMuhAjsOB.AddrOfPinnedObject();
	}

	public void RojSfCUTVkBCCbGielyDxeiEJuNv()
	{
		if (iXafrGaJxrnLvEUDiasMbMuhAjsOB.IsAllocated)
		{
			iXafrGaJxrnLvEUDiasMbMuhAjsOB.Free();
		}
	}

	public string qQPCHojGnYjVUwqoPmDjbXbEdhktB()
	{
		string text = "";
		for (int i = 0; i < yIVYFnpBLClvFaTdWwokHpQgDIPu; i++)
		{
			text = text + njPEqelkqUAXHcVOBySkfuuGgySaA[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool mWxBJRSErtjwVDxODMHEjbIeilQz(int P_0, byte P_1)
	{
		if (1 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (njPEqelkqUAXHcVOBySkfuuGgySaA[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte AsLQKAfZXZkJlbVpJJCmtqbyCAaS(int P_0)
	{
		if (1 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return njPEqelkqUAXHcVOBySkfuuGgySaA[P_0];
	}

	public unsafe short RiISkoazPRaZxcXsLTlNSLqPAeou(int P_0)
	{
		if (2 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort DckSMFvPleXwDJZMFVvwuAnBQfNw(int P_0)
	{
		if (2 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int GDwyxsLJpfpyVJsNvRwLItLTlydD(int P_0)
	{
		if (4 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint oZWOWBpfUuQogTrxyCllKeMHviDE(int P_0)
	{
		if (4 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long hLMPduUdNlDCLyMkHPRUAqyUmPSA(int P_0)
	{
		if (8 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong rNdwaJXHfaXAgaGwWiKYjkJiwnTk(int P_0)
	{
		if (8 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_2 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_1 + P_2 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(njPEqelkqUAXHcVOBySkfuuGgySaA, P_2, P_0, P_3, P_1);
	}

	public void xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_3 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_2 + P_3 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(njPEqelkqUAXHcVOBySkfuuGgySaA, P_0, P_3, P_4, P_2);
	}

	public int qeNroLlBSCyhrSLEgTvpSIOkaxaGA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_2 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			P_1 = yIVYFnpBLClvFaTdWwokHpQgDIPu - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(njPEqelkqUAXHcVOBySkfuuGgySaA, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int qeNroLlBSCyhrSLEgTvpSIOkaxaGA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_3 + P_2 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			P_2 = yIVYFnpBLClvFaTdWwokHpQgDIPu - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(njPEqelkqUAXHcVOBySkfuuGgySaA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void SXhpeDQySIupWNFTUijCFiMVZcAH(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			njPEqelkqUAXHcVOBySkfuuGgySaA[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			njPEqelkqUAXHcVOBySkfuuGgySaA[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void EvDntuhsTubUqbxfRrKDVdXsLcYv(byte P_0, int P_1)
	{
		if (1 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		njPEqelkqUAXHcVOBySkfuuGgySaA[P_1] = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(short P_0, int P_1)
	{
		if (2 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(ushort P_0, int P_1)
	{
		if (2 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(int P_0, int P_1)
	{
		if (4 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(uint P_0, int P_1)
	{
		if (4 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(long P_0, int P_1)
	{
		if (8 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(ulong P_0, int P_1)
	{
		if (8 + P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = njPEqelkqUAXHcVOBySkfuuGgySaA)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_2 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_1 + P_2 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, njPEqelkqUAXHcVOBySkfuuGgySaA, P_2, P_1);
	}

	public void EvDntuhsTubUqbxfRrKDVdXsLcYv(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_3 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_2 + P_3 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, njPEqelkqUAXHcVOBySkfuuGgySaA, P_4, P_3, P_2);
	}

	public int SXQFQqvxMovHIpJOhLVDcMlbtntt(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_1 + P_2 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			P_1 = yIVYFnpBLClvFaTdWwokHpQgDIPu - P_2;
		}
		Array.Copy(P_0, P_3, njPEqelkqUAXHcVOBySkfuuGgySaA, P_2, P_1);
		return P_1;
	}

	public int SXQFQqvxMovHIpJOhLVDcMlbtntt(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= yIVYFnpBLClvFaTdWwokHpQgDIPu)
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
		if (P_2 + P_3 > yIVYFnpBLClvFaTdWwokHpQgDIPu)
		{
			P_2 = yIVYFnpBLClvFaTdWwokHpQgDIPu - P_3;
		}
		NativeTools.CopyMemory(P_0, njPEqelkqUAXHcVOBySkfuuGgySaA, P_4, P_3, P_2);
		return P_2;
	}

	public void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		Array.Clear(njPEqelkqUAXHcVOBySkfuuGgySaA, 0, yIVYFnpBLClvFaTdWwokHpQgDIPu);
	}

	public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		string text = "";
		for (int i = 0; i < yIVYFnpBLClvFaTdWwokHpQgDIPu; i++)
		{
			text = text + this.qrIASlMGLGnVwTSBFkDWOwAXcvax(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			if (iXafrGaJxrnLvEUDiasMbMuhAjsOB.IsAllocated)
			{
				iXafrGaJxrnLvEUDiasMbMuhAjsOB.Free();
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	public static void ChDifTIOotSZLIgZsKvZAqJrlqkg(UQZsgfPpFmiGRcOrjlRpXNBRufElA P_0, UQZsgfPpFmiGRcOrjlRpXNBRufElA P_1, int P_2)
	{
		Array.Copy(P_0.njPEqelkqUAXHcVOBySkfuuGgySaA, P_1.njPEqelkqUAXHcVOBySkfuuGgySaA, P_2);
	}

	public static void ChDifTIOotSZLIgZsKvZAqJrlqkg(UQZsgfPpFmiGRcOrjlRpXNBRufElA P_0, int P_1, UQZsgfPpFmiGRcOrjlRpXNBRufElA P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.njPEqelkqUAXHcVOBySkfuuGgySaA, P_1, P_2.njPEqelkqUAXHcVOBySkfuuGgySaA, P_3, P_4);
	}
}
