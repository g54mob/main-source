using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class mdablknhxlqhnfXBFVePbiPWuHs : IDisposable
{
	private readonly byte[] EAkChchgpneGPakFUTPVByHUjQB;

	public readonly int DEktClpMPdUrZZBcVpqTnEduNAK;

	private GCHandle JePRsKDzfKyifblWhjAzgrDWyvb;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public bool IsPinned => JePRsKDzfKyifblWhjAzgrDWyvb.IsAllocated;

	public byte this[int index]
	{
		get
		{
			return EAkChchgpneGPakFUTPVByHUjQB[index];
		}
		set
		{
			EAkChchgpneGPakFUTPVByHUjQB[index] = value;
		}
	}

	public mdablknhxlqhnfXBFVePbiPWuHs(int size)
	{
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		DEktClpMPdUrZZBcVpqTnEduNAK = size;
		EAkChchgpneGPakFUTPVByHUjQB = new byte[size];
	}

	public IntPtr LuBciafDYNqXXOpizxNBJMFLAtlI()
	{
		if (JePRsKDzfKyifblWhjAzgrDWyvb.IsAllocated)
		{
			return JePRsKDzfKyifblWhjAzgrDWyvb.AddrOfPinnedObject();
		}
		JePRsKDzfKyifblWhjAzgrDWyvb = GCHandle.Alloc(EAkChchgpneGPakFUTPVByHUjQB, GCHandleType.Pinned);
		return JePRsKDzfKyifblWhjAzgrDWyvb.AddrOfPinnedObject();
	}

	public void kzAFJIUOXJjhAOrrvrFaLeFIbnC()
	{
		if (JePRsKDzfKyifblWhjAzgrDWyvb.IsAllocated)
		{
			JePRsKDzfKyifblWhjAzgrDWyvb.Free();
		}
	}

	public string HLmcjaKSzxOaIZUbUNAIpnOnEixG()
	{
		string text = "";
		for (int i = 0; i < DEktClpMPdUrZZBcVpqTnEduNAK; i++)
		{
			text = text + EAkChchgpneGPakFUTPVByHUjQB[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool FfUIlJEIfAGTVBuTHAIvVHnQieRM(int P_0, byte P_1)
	{
		if (1 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (EAkChchgpneGPakFUTPVByHUjQB[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte thogaUxaBqkNtSbmWXnRZFSaTPt(int P_0)
	{
		if (1 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return EAkChchgpneGPakFUTPVByHUjQB[P_0];
	}

	public unsafe short eEzCuuyuRukijTvVQwdqcANNppl(int P_0)
	{
		if (2 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			return *(short*)(eAkChchgpneGPakFUTPVByHUjQB + P_0);
		}
	}

	public unsafe ushort qxDcmDbbIVTQJwLrQaDFKOUXqmI(int P_0)
	{
		if (2 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			return *(ushort*)(eAkChchgpneGPakFUTPVByHUjQB + P_0);
		}
	}

	public unsafe int nVVPKsTjVWOUJqXzeICcohKBtss(int P_0)
	{
		if (4 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			return *(int*)(eAkChchgpneGPakFUTPVByHUjQB + P_0);
		}
	}

	public unsafe uint LmvliBpxdHAtkmwmrSTAgjPRRkE(int P_0)
	{
		if (4 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			return *(uint*)(eAkChchgpneGPakFUTPVByHUjQB + P_0);
		}
	}

	public unsafe long KRiitvYTnydkONCFjjUebwBkSnOq(int P_0)
	{
		if (8 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			return *(long*)(eAkChchgpneGPakFUTPVByHUjQB + P_0);
		}
	}

	public unsafe ulong AkAGQLNNNBDqkVLbJExtBhecPtC(int P_0)
	{
		if (8 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			return *(ulong*)(eAkChchgpneGPakFUTPVByHUjQB + P_0);
		}
	}

	public void AFeHJojxqfbjmBllWvAWerjcLiqH(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_2 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_1 + P_2 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(EAkChchgpneGPakFUTPVByHUjQB, P_2, P_0, P_3, P_1);
	}

	public void AFeHJojxqfbjmBllWvAWerjcLiqH(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_3 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_2 + P_3 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(EAkChchgpneGPakFUTPVByHUjQB, P_0, P_3, P_4, P_2);
	}

	public int DhaISRjAMlEKlpHHfedEmdxuyVp(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_2 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			P_1 = DEktClpMPdUrZZBcVpqTnEduNAK - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(EAkChchgpneGPakFUTPVByHUjQB, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int DhaISRjAMlEKlpHHfedEmdxuyVp(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_3 + P_2 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			P_2 = DEktClpMPdUrZZBcVpqTnEduNAK - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(EAkChchgpneGPakFUTPVByHUjQB, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void ddExXXSCOxlTMssMRshxxCrRWUR(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > DEktClpMPdUrZZBcVpqTnEduNAK || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			EAkChchgpneGPakFUTPVByHUjQB[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			EAkChchgpneGPakFUTPVByHUjQB[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void pqcPIshdVNrBiKWuGFpklSuavkZ(byte P_0, int P_1)
	{
		if (1 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		EAkChchgpneGPakFUTPVByHUjQB[P_1] = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(short P_0, int P_1)
	{
		if (2 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			*(short*)(eAkChchgpneGPakFUTPVByHUjQB + P_1) = P_0;
		}
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(ushort P_0, int P_1)
	{
		if (2 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			*(ushort*)(eAkChchgpneGPakFUTPVByHUjQB + P_1) = P_0;
		}
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(int P_0, int P_1)
	{
		if (4 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			*(int*)(eAkChchgpneGPakFUTPVByHUjQB + P_1) = P_0;
		}
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(uint P_0, int P_1)
	{
		if (4 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			*(uint*)(eAkChchgpneGPakFUTPVByHUjQB + P_1) = P_0;
		}
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(long P_0, int P_1)
	{
		if (8 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			*(long*)(eAkChchgpneGPakFUTPVByHUjQB + P_1) = P_0;
		}
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(ulong P_0, int P_1)
	{
		if (8 + P_1 > DEktClpMPdUrZZBcVpqTnEduNAK || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* eAkChchgpneGPakFUTPVByHUjQB = EAkChchgpneGPakFUTPVByHUjQB)
		{
			*(ulong*)(eAkChchgpneGPakFUTPVByHUjQB + P_1) = P_0;
		}
	}

	public void pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_2 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_1 + P_2 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, EAkChchgpneGPakFUTPVByHUjQB, P_2, P_1);
	}

	public void pqcPIshdVNrBiKWuGFpklSuavkZ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_3 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_2 + P_3 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, EAkChchgpneGPakFUTPVByHUjQB, P_4, P_3, P_2);
	}

	public int zZzsGwjMBLoeIAhRqCUiKPGrylo(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_1 + P_2 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			P_1 = DEktClpMPdUrZZBcVpqTnEduNAK - P_2;
		}
		Array.Copy(P_0, P_3, EAkChchgpneGPakFUTPVByHUjQB, P_2, P_1);
		return P_1;
	}

	public int zZzsGwjMBLoeIAhRqCUiKPGrylo(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= DEktClpMPdUrZZBcVpqTnEduNAK)
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
		if (P_2 + P_3 > DEktClpMPdUrZZBcVpqTnEduNAK)
		{
			P_2 = DEktClpMPdUrZZBcVpqTnEduNAK - P_3;
		}
		NativeTools.CopyMemory(P_0, EAkChchgpneGPakFUTPVByHUjQB, P_4, P_3, P_2);
		return P_2;
	}

	public void ibajyEOvcZaAVvqbaVIEPkwcIqx()
	{
		Array.Clear(EAkChchgpneGPakFUTPVByHUjQB, 0, DEktClpMPdUrZZBcVpqTnEduNAK);
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < DEktClpMPdUrZZBcVpqTnEduNAK; i++)
		{
			text = text + this[i].ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~mdablknhxlqhnfXBFVePbiPWuHs()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			if (JePRsKDzfKyifblWhjAzgrDWyvb.IsAllocated)
			{
				JePRsKDzfKyifblWhjAzgrDWyvb.Free();
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}
	}

	public static void zgyyMVIDkQpbHdLYtFvucCkjish(mdablknhxlqhnfXBFVePbiPWuHs P_0, mdablknhxlqhnfXBFVePbiPWuHs P_1, int P_2)
	{
		Array.Copy(P_0.EAkChchgpneGPakFUTPVByHUjQB, P_1.EAkChchgpneGPakFUTPVByHUjQB, P_2);
	}

	public static void zgyyMVIDkQpbHdLYtFvucCkjish(mdablknhxlqhnfXBFVePbiPWuHs P_0, int P_1, mdablknhxlqhnfXBFVePbiPWuHs P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.EAkChchgpneGPakFUTPVByHUjQB, P_1, P_2.EAkChchgpneGPakFUTPVByHUjQB, P_3, P_4);
	}
}
