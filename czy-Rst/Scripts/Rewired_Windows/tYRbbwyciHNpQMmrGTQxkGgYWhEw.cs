using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct tYRbbwyciHNpQMmrGTQxkGgYWhEw : IDisposable
{
	private unsafe byte* YFldFqxnyDhsJcBaknrFxywXzBeA;

	private int GQuqGBFclwIOSDSCKFIKfyjPMxXfA;

	private bool NJselxHmPPKYYjWjmmPKqjonCXwf;

	public unsafe byte* pjQPlkYpYDkvtgmOxGbOwgcpKINf => YFldFqxnyDhsJcBaknrFxywXzBeA;

	public unsafe IntPtr yFgDVQdHpyJWukipONRkXXiwKwGE => (IntPtr)YFldFqxnyDhsJcBaknrFxywXzBeA;

	public int MfgLvxVhjThmDMSRbLKFMDwAIxRf => GQuqGBFclwIOSDSCKFIKfyjPMxXfA;

	public unsafe byte xIeNlLLPfaANSxSHCfqjOpogIiML
	{
		get
		{
			if (P_0 < 0 || P_0 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
			{
				throw new IndexOutOfRangeException();
			}
			return YFldFqxnyDhsJcBaknrFxywXzBeA[P_0];
		}
		set
		{
			if (num < 0 || num >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
			{
				throw new IndexOutOfRangeException();
			}
			YFldFqxnyDhsJcBaknrFxywXzBeA[num] = b;
		}
	}

	public unsafe tYRbbwyciHNpQMmrGTQxkGgYWhEw(int P_0)
	{
		YFldFqxnyDhsJcBaknrFxywXzBeA = null;
		GQuqGBFclwIOSDSCKFIKfyjPMxXfA = 0;
		NJselxHmPPKYYjWjmmPKqjonCXwf = false;
		VbeisfvjlIuBLORJFVJLARnZIWjI(P_0);
	}

	public unsafe IntPtr TQjHXlXtKDevOocIXuiSzPUIBBbfA(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)YFldFqxnyDhsJcBaknrFxywXzBeA;
		}
		if (P_0 < 0 || P_0 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe string YroSAlyAoPKeRElmtDvriHztUHDVA()
	{
		string text = "";
		for (int i = 0; i < GQuqGBFclwIOSDSCKFIKfyjPMxXfA; i++)
		{
			text = text + YFldFqxnyDhsJcBaknrFxywXzBeA[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool ZBcQBxrTwMtEfuPRBkznTJOPoIfl(int P_0, byte P_1)
	{
		if (1 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (YFldFqxnyDhsJcBaknrFxywXzBeA[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte rwSoXdXMhMLQUTqqwPXUUOluSAxs(int P_0)
	{
		if (1 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return YFldFqxnyDhsJcBaknrFxywXzBeA[P_0];
	}

	public unsafe short MLOFSNfolixdyJUbDdMEPZXhYYpJA(int P_0)
	{
		if (2 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe ushort lELqQakRcDzlOHdxaocOPCJYqCyV(int P_0)
	{
		if (2 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe int GcENuwgcRqDewXjwgcgSaYSKrFaC(int P_0)
	{
		if (4 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe uint dRkigUofhAMYAPGHhNPNRSnwpjoc(int P_0)
	{
		if (4 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe long vRSQSPywfxnBZMegBenUAXQCHcMh(int P_0)
	{
		if (8 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe ulong UnKVFyBmpKlFOHJgXYhKjLGUdyLW(int P_0)
	{
		if (8 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_0);
	}

	public unsafe void FolHKMCjIIMdbwpkksbShOyVFcRx(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_2 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_1 + P_2 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)YFldFqxnyDhsJcBaknrFxywXzBeA, P_0, P_2, P_3, P_1);
	}

	public unsafe void ivqweIKyDzPzNjCnalHabJYlJIlC(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_3 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_2 + P_3 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(YFldFqxnyDhsJcBaknrFxywXzBeA, P_0, P_3, P_4, P_2);
	}

	public unsafe void EcMeeJeHpuwqrBrWHvgjVWKyogBt(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		ivqweIKyDzPzNjCnalHabJYlJIlC((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int erxALuDqnZmizCVIywcrbhuDXUZCA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_2 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			P_1 = GQuqGBFclwIOSDSCKFIKfyjPMxXfA - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)YFldFqxnyDhsJcBaknrFxywXzBeA, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int MpGLoNRZIsQPclQkjrFNZdzYBJGD(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_3 + P_2 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			P_2 = GQuqGBFclwIOSDSCKFIKfyjPMxXfA - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(YFldFqxnyDhsJcBaknrFxywXzBeA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int NBIDiQEBVMYvShEdoiftucjwMaQdA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return MpGLoNRZIsQPclQkjrFNZdzYBJGD((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void WwDItXxTwTXAlBdbrJaiagUwpleT(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = YFldFqxnyDhsJcBaknrFxywXzBeA + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = YFldFqxnyDhsJcBaknrFxywXzBeA + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void jNlJIVnoBCYmixFclfaLaNwvlSpHA(byte P_0, int P_1)
	{
		if (1 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		YFldFqxnyDhsJcBaknrFxywXzBeA[P_1] = P_0;
	}

	public unsafe void lyWjgkIwmlnmOBtAkJnYGcHUDiyz(short P_0, int P_1)
	{
		if (2 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_1) = P_0;
	}

	public unsafe void gNRTPvWPNUrQBNdosXVRdWDZDWoP(ushort P_0, int P_1)
	{
		if (2 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_1) = P_0;
	}

	public unsafe void SfuzjUYqOCXKfhQZqspDpmFoSTgE(int P_0, int P_1)
	{
		if (4 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_1) = P_0;
	}

	public unsafe void opHsTXCLPLhMjhOLkmjqDCxfZusE(uint P_0, int P_1)
	{
		if (4 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_1) = P_0;
	}

	public unsafe void bifGECXAhoFxlFIiSnKEBFSIIAuo(long P_0, int P_1)
	{
		if (8 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_1) = P_0;
	}

	public unsafe void gEPKBgrNDoaxQzneVZyrzIrxQPwb(ulong P_0, int P_1)
	{
		if (8 + P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(YFldFqxnyDhsJcBaknrFxywXzBeA + P_1) = P_0;
	}

	public unsafe void nxJSldnxongEGKvXMgdYMvMkwEPw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_2 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_1 + P_2 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)YFldFqxnyDhsJcBaknrFxywXzBeA, P_3, P_2, P_1);
	}

	public unsafe void aUtvJZEKspryoGxCWshAvHFPnVpr(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_3 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_2 + P_3 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(P_0, YFldFqxnyDhsJcBaknrFxywXzBeA, P_4, P_3, P_2);
	}

	public unsafe void COULLbwQNmOvtGoBtbqLmXImTEmt(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		aUtvJZEKspryoGxCWshAvHFPnVpr((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int iNiDnxoOmDdzoGytpPRsbKceviEE(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_1 + P_2 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			P_1 = GQuqGBFclwIOSDSCKFIKfyjPMxXfA - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)YFldFqxnyDhsJcBaknrFxywXzBeA, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int vdgXfLRoUfNuIcioaBNmgwmDWuNG(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
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
		if (P_2 + P_3 > GQuqGBFclwIOSDSCKFIKfyjPMxXfA)
		{
			P_2 = GQuqGBFclwIOSDSCKFIKfyjPMxXfA - P_3;
		}
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(P_0, YFldFqxnyDhsJcBaknrFxywXzBeA, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int fQgOAenlpjuBssSBDoGiASKZOZpp(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return vdgXfLRoUfNuIcioaBNmgwmDWuNG((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool VbeisfvjlIuBLORJFVJLARnZIWjI(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (GQuqGBFclwIOSDSCKFIKfyjPMxXfA == P_0)
		{
			return true;
		}
		sEQqgqRLPHZqPnyzVtKEHepjBEZJA();
		if (P_0 == 0)
		{
			return true;
		}
		GQuqGBFclwIOSDSCKFIKfyjPMxXfA = P_0;
		YFldFqxnyDhsJcBaknrFxywXzBeA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		WtnLlJCTJWeZfJGWhbfIRTLZxydm();
		return true;
	}

	public unsafe void WtnLlJCTJWeZfJGWhbfIRTLZxydm()
	{
		if (GQuqGBFclwIOSDSCKFIKfyjPMxXfA != 0)
		{
			IPpGxGoGPNwPwoVzosbzleQVdbB.lLrZFPAbPDJHtUcGzegsjYKhiovqA(YFldFqxnyDhsJcBaknrFxywXzBeA, GQuqGBFclwIOSDSCKFIKfyjPMxXfA);
		}
	}

	public unsafe void sEQqgqRLPHZqPnyzVtKEHepjBEZJA()
	{
		if (GQuqGBFclwIOSDSCKFIKfyjPMxXfA == 0)
		{
			return;
		}
		try
		{
			if (YFldFqxnyDhsJcBaknrFxywXzBeA != null)
			{
				Marshal.FreeHGlobal(yFgDVQdHpyJWukipONRkXXiwKwGE);
			}
		}
		catch
		{
		}
		YFldFqxnyDhsJcBaknrFxywXzBeA = null;
		GQuqGBFclwIOSDSCKFIKfyjPMxXfA = 0;
	}

	public string KdDOJeFuZHSyOsvKeTiOKUdiVcom()
	{
		string text = "";
		for (int i = 0; i < GQuqGBFclwIOSDSCKFIKfyjPMxXfA; i++)
		{
			text = text + rwSoXdXMhMLQUTqqwPXUUOluSAxs(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		NwQyKvHbdWwjbfaFmOfBNeAZfrjx(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void NwQyKvHbdWwjbfaFmOfBNeAZfrjx(bool P_0)
	{
		if (!NJselxHmPPKYYjWjmmPKqjonCXwf)
		{
			sEQqgqRLPHZqPnyzVtKEHepjBEZJA();
			NJselxHmPPKYYjWjmmPKqjonCXwf = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr TOHuqvXEmudFbgvYybKJKnCVBLIT(tYRbbwyciHNpQMmrGTQxkGgYWhEw P_0)
	{
		return (IntPtr)P_0.YFldFqxnyDhsJcBaknrFxywXzBeA;
	}

	[SpecialName]
	public unsafe static void* TOHuqvXEmudFbgvYybKJKnCVBLIT(tYRbbwyciHNpQMmrGTQxkGgYWhEw P_0)
	{
		return P_0.YFldFqxnyDhsJcBaknrFxywXzBeA;
	}

	public unsafe static bool sIXFKEKdvUIQOXJDziWaAceUOTZV(tYRbbwyciHNpQMmrGTQxkGgYWhEw P_0, tYRbbwyciHNpQMmrGTQxkGgYWhEw P_1)
	{
		if (P_0.GQuqGBFclwIOSDSCKFIKfyjPMxXfA == 0)
		{
			P_1.sEQqgqRLPHZqPnyzVtKEHepjBEZJA();
			return true;
		}
		if (P_1.VbeisfvjlIuBLORJFVJLARnZIWjI(P_0.GQuqGBFclwIOSDSCKFIKfyjPMxXfA))
		{
			P_1.aUtvJZEKspryoGxCWshAvHFPnVpr(P_0.YFldFqxnyDhsJcBaknrFxywXzBeA, P_0.GQuqGBFclwIOSDSCKFIKfyjPMxXfA, P_0.GQuqGBFclwIOSDSCKFIKfyjPMxXfA);
			return true;
		}
		return false;
	}
}
