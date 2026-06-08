using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class RvpFEucvSEfCvSDLylfXUdcnldG : IDisposable
{
	private unsafe byte* tIxoTeFDQZYEDabsYWCNYmpEcjU;

	private int JlMKgDHQdainfJANAPPVErSKXBae;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public unsafe byte* UnsafePointer => tIxoTeFDQZYEDabsYWCNYmpEcjU;

	public unsafe IntPtr Pointer => (IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU;

	public int Length => JlMKgDHQdainfJANAPPVErSKXBae;

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= JlMKgDHQdainfJANAPPVErSKXBae)
			{
				throw new IndexOutOfRangeException();
			}
			return tIxoTeFDQZYEDabsYWCNYmpEcjU[index];
		}
		set
		{
			if (index < 0 || index >= JlMKgDHQdainfJANAPPVErSKXBae)
			{
				throw new IndexOutOfRangeException();
			}
			tIxoTeFDQZYEDabsYWCNYmpEcjU[index] = value;
		}
	}

	public RvpFEucvSEfCvSDLylfXUdcnldG(int size)
	{
		PPkHTNAsCiNvnCMJzlWHndDevhO(size);
	}

	public unsafe IntPtr sHPeiUxxxfUfPcneOivbLFFJQEE(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU;
		}
		if (P_0 < 0 || P_0 >= JlMKgDHQdainfJANAPPVErSKXBae)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe string HLmcjaKSzxOaIZUbUNAIpnOnEixG()
	{
		string text = "";
		for (int i = 0; i < JlMKgDHQdainfJANAPPVErSKXBae; i++)
		{
			text = text + tIxoTeFDQZYEDabsYWCNYmpEcjU[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool FfUIlJEIfAGTVBuTHAIvVHnQieRM(int P_0, byte P_1)
	{
		if (1 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (tIxoTeFDQZYEDabsYWCNYmpEcjU[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte thogaUxaBqkNtSbmWXnRZFSaTPt(int P_0)
	{
		if (1 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return tIxoTeFDQZYEDabsYWCNYmpEcjU[P_0];
	}

	public unsafe short eEzCuuyuRukijTvVQwdqcANNppl(int P_0)
	{
		if (2 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe ushort qxDcmDbbIVTQJwLrQaDFKOUXqmI(int P_0)
	{
		if (2 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe int nVVPKsTjVWOUJqXzeICcohKBtss(int P_0)
	{
		if (4 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe uint LmvliBpxdHAtkmwmrSTAgjPRRkE(int P_0)
	{
		if (4 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe long KRiitvYTnydkONCFjjUebwBkSnOq(int P_0)
	{
		if (8 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe ulong AkAGQLNNNBDqkVLbJExtBhecPtC(int P_0)
	{
		if (8 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0);
	}

	public unsafe void AFeHJojxqfbjmBllWvAWerjcLiqH(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_2 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_1 + P_2 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_2, P_3, P_1);
	}

	public unsafe void AFeHJojxqfbjmBllWvAWerjcLiqH(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_3 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_2 + P_3 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_3, P_4, P_2);
	}

	public unsafe void AFeHJojxqfbjmBllWvAWerjcLiqH(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		AFeHJojxqfbjmBllWvAWerjcLiqH((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int DhaISRjAMlEKlpHHfedEmdxuyVp(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_2 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			P_1 = JlMKgDHQdainfJANAPPVErSKXBae - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int DhaISRjAMlEKlpHHfedEmdxuyVp(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_3 + P_2 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			P_2 = JlMKgDHQdainfJANAPPVErSKXBae - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int DhaISRjAMlEKlpHHfedEmdxuyVp(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return DhaISRjAMlEKlpHHfedEmdxuyVp((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void ddExXXSCOxlTMssMRshxxCrRWUR(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > JlMKgDHQdainfJANAPPVErSKXBae || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* intPtr = tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0;
			*intPtr |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* intPtr2 = tIxoTeFDQZYEDabsYWCNYmpEcjU + P_0;
			*intPtr2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(byte P_0, int P_1)
	{
		if (1 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		tIxoTeFDQZYEDabsYWCNYmpEcjU[P_1] = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(short P_0, int P_1)
	{
		if (2 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_1) = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(ushort P_0, int P_1)
	{
		if (2 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_1) = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(int P_0, int P_1)
	{
		if (4 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_1) = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(uint P_0, int P_1)
	{
		if (4 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_1) = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(long P_0, int P_1)
	{
		if (8 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_1) = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(ulong P_0, int P_1)
	{
		if (8 + P_1 > JlMKgDHQdainfJANAPPVErSKXBae || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(tIxoTeFDQZYEDabsYWCNYmpEcjU + P_1) = P_0;
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_2 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_1 + P_2 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_3, P_2, P_1);
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_3 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_2 + P_3 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(P_0, tIxoTeFDQZYEDabsYWCNYmpEcjU, P_4, P_3, P_2);
	}

	public unsafe void pqcPIshdVNrBiKWuGFpklSuavkZ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		pqcPIshdVNrBiKWuGFpklSuavkZ((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int zZzsGwjMBLoeIAhRqCUiKPGrylo(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_1 + P_2 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			P_1 = JlMKgDHQdainfJANAPPVErSKXBae - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int zZzsGwjMBLoeIAhRqCUiKPGrylo(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= JlMKgDHQdainfJANAPPVErSKXBae)
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
		if (P_2 + P_3 > JlMKgDHQdainfJANAPPVErSKXBae)
		{
			P_2 = JlMKgDHQdainfJANAPPVErSKXBae - P_3;
		}
		vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(P_0, tIxoTeFDQZYEDabsYWCNYmpEcjU, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int zZzsGwjMBLoeIAhRqCUiKPGrylo(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return zZzsGwjMBLoeIAhRqCUiKPGrylo((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool PPkHTNAsCiNvnCMJzlWHndDevhO(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (JlMKgDHQdainfJANAPPVErSKXBae == P_0)
		{
			return true;
		}
		GNKNryZxWSbdCoxyKkpOJfVDUEu();
		if (P_0 == 0)
		{
			return true;
		}
		JlMKgDHQdainfJANAPPVErSKXBae = P_0;
		tIxoTeFDQZYEDabsYWCNYmpEcjU = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		ibajyEOvcZaAVvqbaVIEPkwcIqx();
		return true;
	}

	public unsafe void ibajyEOvcZaAVvqbaVIEPkwcIqx()
	{
		if (JlMKgDHQdainfJANAPPVErSKXBae != 0)
		{
			vyfgviDXVLbCEkuBsyiiCaQjLPmW.kyyeCfFkgWJaJsXOxIgdYqEZXby(tIxoTeFDQZYEDabsYWCNYmpEcjU, JlMKgDHQdainfJANAPPVErSKXBae);
		}
	}

	public unsafe void GNKNryZxWSbdCoxyKkpOJfVDUEu()
	{
		if (JlMKgDHQdainfJANAPPVErSKXBae == 0)
		{
			return;
		}
		try
		{
			if (tIxoTeFDQZYEDabsYWCNYmpEcjU != null)
			{
				Marshal.FreeHGlobal(Pointer);
			}
		}
		catch
		{
		}
		tIxoTeFDQZYEDabsYWCNYmpEcjU = null;
		JlMKgDHQdainfJANAPPVErSKXBae = 0;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < JlMKgDHQdainfJANAPPVErSKXBae; i++)
		{
			text = text + thogaUxaBqkNtSbmWXnRZFSaTPt(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~RvpFEucvSEfCvSDLylfXUdcnldG()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			GNKNryZxWSbdCoxyKkpOJfVDUEu();
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}
	}

	public unsafe static implicit operator IntPtr(RvpFEucvSEfCvSDLylfXUdcnldG buffer)
	{
		if (buffer == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)buffer.tIxoTeFDQZYEDabsYWCNYmpEcjU;
	}

	public unsafe static implicit operator void*(RvpFEucvSEfCvSDLylfXUdcnldG buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		return buffer.tIxoTeFDQZYEDabsYWCNYmpEcjU;
	}

	public unsafe static bool zgyyMVIDkQpbHdLYtFvucCkjish(RvpFEucvSEfCvSDLylfXUdcnldG P_0, RvpFEucvSEfCvSDLylfXUdcnldG P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.JlMKgDHQdainfJANAPPVErSKXBae == 0)
		{
			P_1.GNKNryZxWSbdCoxyKkpOJfVDUEu();
			return true;
		}
		if (P_1.PPkHTNAsCiNvnCMJzlWHndDevhO(P_0.JlMKgDHQdainfJANAPPVErSKXBae))
		{
			P_1.pqcPIshdVNrBiKWuGFpklSuavkZ(P_0.tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0.JlMKgDHQdainfJANAPPVErSKXBae, P_0.JlMKgDHQdainfJANAPPVErSKXBae);
			return true;
		}
		return false;
	}
}
