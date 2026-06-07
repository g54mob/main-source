using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class SoDaUPyxhCljCRyOJyRmuMKFqYxD : IDisposable
{
	private unsafe byte* UPGvMgRDWwlhHHpXHBIuibQSseTK;

	private int iMbQTJZteBOjntOEHYCiZapZEdrJ;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public unsafe byte* vUidfUuOCrgwuglesiYAejgGCCKYb => UPGvMgRDWwlhHHpXHBIuibQSseTK;

	public unsafe IntPtr eRuooOpUXUMNyxAVfhJQXVsDGDql => (IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK;

	public int yIVYFnpBLClvFaTdWwokHpQgDIPu => iMbQTJZteBOjntOEHYCiZapZEdrJ;

	public unsafe byte uYZQJGUmbMuICFZWSqJprRCobGI
	{
		get
		{
			if (P_0 < 0 || P_0 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
			{
				throw new IndexOutOfRangeException();
			}
			return UPGvMgRDWwlhHHpXHBIuibQSseTK[P_0];
		}
		set
		{
			if (num < 0 || num >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
			{
				throw new IndexOutOfRangeException();
			}
			UPGvMgRDWwlhHHpXHBIuibQSseTK[num] = b;
		}
	}

	public SoDaUPyxhCljCRyOJyRmuMKFqYxD(int P_0)
	{
		ciNxePQCaXGCndIQgJjmJfiyBgXv(P_0);
	}

	public unsafe IntPtr FCcWDSlxbIQbTHkhZiFIrvyFFURI(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK;
		}
		if (P_0 < 0 || P_0 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe string qQPCHojGnYjVUwqoPmDjbXbEdhktB()
	{
		string text = "";
		for (int i = 0; i < iMbQTJZteBOjntOEHYCiZapZEdrJ; i++)
		{
			text = text + UPGvMgRDWwlhHHpXHBIuibQSseTK[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool mWxBJRSErtjwVDxODMHEjbIeilQz(int P_0, byte P_1)
	{
		if (1 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (UPGvMgRDWwlhHHpXHBIuibQSseTK[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte AsLQKAfZXZkJlbVpJJCmtqbyCAaS(int P_0)
	{
		if (1 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return UPGvMgRDWwlhHHpXHBIuibQSseTK[P_0];
	}

	public unsafe short RiISkoazPRaZxcXsLTlNSLqPAeou(int P_0)
	{
		if (2 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe ushort DckSMFvPleXwDJZMFVvwuAnBQfNw(int P_0)
	{
		if (2 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe int GDwyxsLJpfpyVJsNvRwLItLTlydD(int P_0)
	{
		if (4 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe uint oZWOWBpfUuQogTrxyCllKeMHviDE(int P_0)
	{
		if (4 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe long hLMPduUdNlDCLyMkHPRUAqyUmPSA(int P_0)
	{
		if (8 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe ulong rNdwaJXHfaXAgaGwWiKYjkJiwnTk(int P_0)
	{
		if (8 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe float iWhtKnJpNWgrChVpAWEKFoFWMOLA(int P_0)
	{
		if (4 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe double qGUKOiyFjiQSIwJNvwNrGqNjfuNhA(int P_0)
	{
		if (8 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0);
	}

	public unsafe void xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_2 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_1 + P_2 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_2, P_3, P_1);
	}

	public unsafe void xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_3 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_2 + P_3 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_3, P_4, P_2);
	}

	public unsafe void xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		xWPdFkhEuYbKoMqaTzNbLlMyFnpGA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int qeNroLlBSCyhrSLEgTvpSIOkaxaGA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_2 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			P_1 = iMbQTJZteBOjntOEHYCiZapZEdrJ - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int qeNroLlBSCyhrSLEgTvpSIOkaxaGA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_3 + P_2 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			P_2 = iMbQTJZteBOjntOEHYCiZapZEdrJ - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int qeNroLlBSCyhrSLEgTvpSIOkaxaGA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return qeNroLlBSCyhrSLEgTvpSIOkaxaGA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void SXhpeDQySIupWNFTUijCFiMVZcAH(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* intPtr = UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0;
			*intPtr |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* intPtr2 = UPGvMgRDWwlhHHpXHBIuibQSseTK + P_0;
			*intPtr2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(byte P_0, int P_1)
	{
		if (1 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		UPGvMgRDWwlhHHpXHBIuibQSseTK[P_1] = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(short P_0, int P_1)
	{
		if (2 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(ushort P_0, int P_1)
	{
		if (2 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(int P_0, int P_1)
	{
		if (4 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(uint P_0, int P_1)
	{
		if (4 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(long P_0, int P_1)
	{
		if (8 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(ulong P_0, int P_1)
	{
		if (8 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(float P_0, int P_1)
	{
		if (4 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(double P_0, int P_1)
	{
		if (8 + P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(UPGvMgRDWwlhHHpXHBIuibQSseTK + P_1) = P_0;
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_2 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_1 + P_2 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_3, P_2, P_1);
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_3 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_2 + P_3 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(P_0, UPGvMgRDWwlhHHpXHBIuibQSseTK, P_4, P_3, P_2);
	}

	public unsafe void EvDntuhsTubUqbxfRrKDVdXsLcYv(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		EvDntuhsTubUqbxfRrKDVdXsLcYv((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int SXQFQqvxMovHIpJOhLVDcMlbtntt(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_1 + P_2 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			P_1 = iMbQTJZteBOjntOEHYCiZapZEdrJ - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int SXQFQqvxMovHIpJOhLVDcMlbtntt(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= iMbQTJZteBOjntOEHYCiZapZEdrJ)
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
		if (P_2 + P_3 > iMbQTJZteBOjntOEHYCiZapZEdrJ)
		{
			P_2 = iMbQTJZteBOjntOEHYCiZapZEdrJ - P_3;
		}
		MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(P_0, UPGvMgRDWwlhHHpXHBIuibQSseTK, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int SXQFQqvxMovHIpJOhLVDcMlbtntt(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return SXQFQqvxMovHIpJOhLVDcMlbtntt((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool ciNxePQCaXGCndIQgJjmJfiyBgXv(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (iMbQTJZteBOjntOEHYCiZapZEdrJ == P_0)
		{
			return true;
		}
		hldVlmZiYtOAMBUhZgNvxGgZETbs();
		if (P_0 == 0)
		{
			return true;
		}
		iMbQTJZteBOjntOEHYCiZapZEdrJ = P_0;
		UPGvMgRDWwlhHHpXHBIuibQSseTK = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		DwNKXiEShimVDUzntAObjUXyaFmo();
		return true;
	}

	public unsafe void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		if (iMbQTJZteBOjntOEHYCiZapZEdrJ != 0)
		{
			MjelBjbhahSaBQQQQOiKWfHHDoKR.BzPycdFeBjNYJTPswhmQgfDRwXxd(UPGvMgRDWwlhHHpXHBIuibQSseTK, iMbQTJZteBOjntOEHYCiZapZEdrJ);
		}
	}

	public unsafe void hldVlmZiYtOAMBUhZgNvxGgZETbs()
	{
		if (iMbQTJZteBOjntOEHYCiZapZEdrJ == 0)
		{
			return;
		}
		try
		{
			if (UPGvMgRDWwlhHHpXHBIuibQSseTK != null)
			{
				Marshal.FreeHGlobal(eRuooOpUXUMNyxAVfhJQXVsDGDql);
			}
		}
		catch
		{
		}
		UPGvMgRDWwlhHHpXHBIuibQSseTK = null;
		iMbQTJZteBOjntOEHYCiZapZEdrJ = 0;
	}

	public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		string text = "";
		for (int i = 0; i < iMbQTJZteBOjntOEHYCiZapZEdrJ; i++)
		{
			text = text + AsLQKAfZXZkJlbVpJJCmtqbyCAaS(i).ToString("x2") + " ";
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
			hldVlmZiYtOAMBUhZgNvxGgZETbs();
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr bPhBTDiXwPSGeHgqUdzKHurTqKRxA(SoDaUPyxhCljCRyOJyRmuMKFqYxD P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK;
	}

	[SpecialName]
	public unsafe static void* bPhBTDiXwPSGeHgqUdzKHurTqKRxA(SoDaUPyxhCljCRyOJyRmuMKFqYxD P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK;
	}

	public unsafe static bool ChDifTIOotSZLIgZsKvZAqJrlqkg(SoDaUPyxhCljCRyOJyRmuMKFqYxD P_0, SoDaUPyxhCljCRyOJyRmuMKFqYxD P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.iMbQTJZteBOjntOEHYCiZapZEdrJ == 0)
		{
			P_1.hldVlmZiYtOAMBUhZgNvxGgZETbs();
			return true;
		}
		if (P_1.ciNxePQCaXGCndIQgJjmJfiyBgXv(P_0.iMbQTJZteBOjntOEHYCiZapZEdrJ))
		{
			P_1.EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0.iMbQTJZteBOjntOEHYCiZapZEdrJ, P_0.iMbQTJZteBOjntOEHYCiZapZEdrJ);
			return true;
		}
		return false;
	}
}
