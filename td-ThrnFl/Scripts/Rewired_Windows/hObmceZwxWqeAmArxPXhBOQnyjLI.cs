using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct hObmceZwxWqeAmArxPXhBOQnyjLI : IDisposable
{
	private unsafe byte* KdfgqZFTbrwiiIJNTwkjIhUVsiCF;

	private int AdYfXDDqnlnJAcpYdAJCcRLqugSgb;

	private bool HkOvsnurTQBZUBajXmnAVDSEnVvR;

	public unsafe byte* xisOtwdWpIzYlADiMBoGRKGIBJIi => KdfgqZFTbrwiiIJNTwkjIhUVsiCF;

	public unsafe IntPtr qGWYwCEcNjkGyGesfgEqaklRfFLTA => (IntPtr)KdfgqZFTbrwiiIJNTwkjIhUVsiCF;

	public int KKYcQpomhKWqLapPAXGBdUUvkHCU => AdYfXDDqnlnJAcpYdAJCcRLqugSgb;

	public unsafe byte hQvCZaRdrvHANDZhpmnvgOReJNHA
	{
		get
		{
			if (P_0 < 0 || P_0 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
			{
				throw new IndexOutOfRangeException();
			}
			return KdfgqZFTbrwiiIJNTwkjIhUVsiCF[P_0];
		}
		set
		{
			if (num < 0 || num >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
			{
				throw new IndexOutOfRangeException();
			}
			KdfgqZFTbrwiiIJNTwkjIhUVsiCF[num] = b;
		}
	}

	public unsafe hObmceZwxWqeAmArxPXhBOQnyjLI(int P_0)
	{
		KdfgqZFTbrwiiIJNTwkjIhUVsiCF = null;
		AdYfXDDqnlnJAcpYdAJCcRLqugSgb = 0;
		HkOvsnurTQBZUBajXmnAVDSEnVvR = false;
		BrIdjfQXzNSnHkvDyDUPxEBawRcw(P_0);
	}

	public unsafe IntPtr NbJBWrqhACYcAGVGcixGYsavWrem(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)KdfgqZFTbrwiiIJNTwkjIhUVsiCF;
		}
		if (P_0 < 0 || P_0 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe string SBQHHjXgMExbXuinGsEdkHZKSvMf()
	{
		string text = "";
		for (int i = 0; i < AdYfXDDqnlnJAcpYdAJCcRLqugSgb; i++)
		{
			text = text + KdfgqZFTbrwiiIJNTwkjIhUVsiCF[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool PjIDnkUyeBufbUPMevcfcqAmbEmh(int P_0, byte P_1)
	{
		if (1 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (KdfgqZFTbrwiiIJNTwkjIhUVsiCF[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte rxiECniwdHBDCIngaZECczHFNTuGc(int P_0)
	{
		if (1 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return KdfgqZFTbrwiiIJNTwkjIhUVsiCF[P_0];
	}

	public unsafe short SpeqDRBtjrSkuccjsePSfwvOCPgZA(int P_0)
	{
		if (2 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe ushort tTpfRkGLaOAmGnllRlhIWwtndFjDb(int P_0)
	{
		if (2 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe int GngASaXMudfQsbxlRlxEhHulaonFb(int P_0)
	{
		if (4 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe uint vuQtPAFOlTNBCryQSOUDaOkJcQwK(int P_0)
	{
		if (4 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe long bBgLNYXWqmocDkimihrWvefdCCVx(int P_0)
	{
		if (8 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe ulong WDcDGsaXnDHKQvSekMyQKLenjpAn(int P_0)
	{
		if (8 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0);
	}

	public unsafe void JiRuJAraINcidbKyDnuKUEKortCIA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_2 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_1 + P_2 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_0, P_2, P_3, P_1);
	}

	public unsafe void iyCdtAlnikAHTRNWXmBqIofSQwwF(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_3 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_2 + P_3 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_0, P_3, P_4, P_2);
	}

	public unsafe void KVkMjLsGxhrfrlzWexHtsBuJatKQ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		iyCdtAlnikAHTRNWXmBqIofSQwwF((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int meDPKiHZnGwrhhrMRbUzEyQmHMIG(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_2 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			P_1 = AdYfXDDqnlnJAcpYdAJCcRLqugSgb - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int SEcCuVmxRpPdwFAOUcaXkEJvuITO(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_3 + P_2 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			P_2 = AdYfXDDqnlnJAcpYdAJCcRLqugSgb - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int HwsnjMaUDJwcCqenPxwhZAZHMlPN(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return SEcCuVmxRpPdwFAOUcaXkEJvuITO((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void AUrNeZKgBCSMrfpIGxeyHeeTiIlg(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void xjVzBZOhHJClkEFwKmzDhwAWGHajb(byte P_0, int P_1)
	{
		if (1 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		KdfgqZFTbrwiiIJNTwkjIhUVsiCF[P_1] = P_0;
	}

	public unsafe void tboxzcxoeetfYnOUHTaYfndnVdjp(short P_0, int P_1)
	{
		if (2 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_1) = P_0;
	}

	public unsafe void elxiMfhxHLlFFdekXXKHMXdsnFbp(ushort P_0, int P_1)
	{
		if (2 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_1) = P_0;
	}

	public unsafe void QOCuwMdYoZYpxJiQRnmRSCRDBYtD(int P_0, int P_1)
	{
		if (4 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_1) = P_0;
	}

	public unsafe void uEjAtFvjJSrclDkAPjlafgoMzQrhA(uint P_0, int P_1)
	{
		if (4 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_1) = P_0;
	}

	public unsafe void fmLHOCeGxrhKftMgligSdemjCLdMA(long P_0, int P_1)
	{
		if (8 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_1) = P_0;
	}

	public unsafe void aUgBiREMLnjpdVRfoSboGRmUZLMK(ulong P_0, int P_1)
	{
		if (8 + P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(KdfgqZFTbrwiiIJNTwkjIhUVsiCF + P_1) = P_0;
	}

	public unsafe void zbjGipMOkyOXEkCZzscQxgoBQTSx(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_2 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_1 + P_2 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_3, P_2, P_1);
	}

	public unsafe void eCRLKFdHaqlnowSYvPsWYpzmNIqU(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_3 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_2 + P_3 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(P_0, KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_4, P_3, P_2);
	}

	public unsafe void QekcGdgHJrcavZeLIUfVlJuVDJxOA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		eCRLKFdHaqlnowSYvPsWYpzmNIqU((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int uZIYTjDgCGHaaaKsKvSXQCoVAcHkA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_1 + P_2 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			P_1 = AdYfXDDqnlnJAcpYdAJCcRLqugSgb - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int nkAMFemYbkCBWMgALCEeVhGoTISj(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
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
		if (P_2 + P_3 > AdYfXDDqnlnJAcpYdAJCcRLqugSgb)
		{
			P_2 = AdYfXDDqnlnJAcpYdAJCcRLqugSgb - P_3;
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(P_0, KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int nJSBRodIbqLQqtUBmMFeHtoiKImBA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return nkAMFemYbkCBWMgALCEeVhGoTISj((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool BrIdjfQXzNSnHkvDyDUPxEBawRcw(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (AdYfXDDqnlnJAcpYdAJCcRLqugSgb == P_0)
		{
			return true;
		}
		iwufxigwFERdFgVjqpPKbmBIMLKtb();
		if (P_0 == 0)
		{
			return true;
		}
		AdYfXDDqnlnJAcpYdAJCcRLqugSgb = P_0;
		KdfgqZFTbrwiiIJNTwkjIhUVsiCF = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		AZLaqRbTDVzMxjyCSrsGkXbqprmN();
		return true;
	}

	public unsafe void AZLaqRbTDVzMxjyCSrsGkXbqprmN()
	{
		if (AdYfXDDqnlnJAcpYdAJCcRLqugSgb != 0)
		{
			EKnkiWpmsWIwmATuShvoOkPhQPyF.viXKbDlkVMGfteQQGzswfJwIvJei(KdfgqZFTbrwiiIJNTwkjIhUVsiCF, AdYfXDDqnlnJAcpYdAJCcRLqugSgb);
		}
	}

	public unsafe void iwufxigwFERdFgVjqpPKbmBIMLKtb()
	{
		if (AdYfXDDqnlnJAcpYdAJCcRLqugSgb == 0)
		{
			return;
		}
		try
		{
			if (KdfgqZFTbrwiiIJNTwkjIhUVsiCF != null)
			{
				Marshal.FreeHGlobal(qGWYwCEcNjkGyGesfgEqaklRfFLTA);
			}
		}
		catch
		{
		}
		KdfgqZFTbrwiiIJNTwkjIhUVsiCF = null;
		AdYfXDDqnlnJAcpYdAJCcRLqugSgb = 0;
	}

	public string YjkViDmVOkRAwIELbMQTjBXoGfYA()
	{
		string text = "";
		for (int i = 0; i < AdYfXDDqnlnJAcpYdAJCcRLqugSgb; i++)
		{
			text = text + rxiECniwdHBDCIngaZECczHFNTuGc(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		HYwjUxifxNfzrVMXRsJBsweilywT(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void HYwjUxifxNfzrVMXRsJBsweilywT(bool P_0)
	{
		if (!HkOvsnurTQBZUBajXmnAVDSEnVvR)
		{
			iwufxigwFERdFgVjqpPKbmBIMLKtb();
			HkOvsnurTQBZUBajXmnAVDSEnVvR = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr PCblGxsbqxWvvKRWFRXXfeJgMDPg(hObmceZwxWqeAmArxPXhBOQnyjLI P_0)
	{
		return (IntPtr)P_0.KdfgqZFTbrwiiIJNTwkjIhUVsiCF;
	}

	[SpecialName]
	public unsafe static void* PCblGxsbqxWvvKRWFRXXfeJgMDPg(hObmceZwxWqeAmArxPXhBOQnyjLI P_0)
	{
		return P_0.KdfgqZFTbrwiiIJNTwkjIhUVsiCF;
	}

	public unsafe static bool yinwJMbkrNrLYnWZEgJotdOzXGIX(hObmceZwxWqeAmArxPXhBOQnyjLI P_0, hObmceZwxWqeAmArxPXhBOQnyjLI P_1)
	{
		if (P_0.AdYfXDDqnlnJAcpYdAJCcRLqugSgb == 0)
		{
			P_1.iwufxigwFERdFgVjqpPKbmBIMLKtb();
			return true;
		}
		if (P_1.BrIdjfQXzNSnHkvDyDUPxEBawRcw(P_0.AdYfXDDqnlnJAcpYdAJCcRLqugSgb))
		{
			P_1.eCRLKFdHaqlnowSYvPsWYpzmNIqU(P_0.KdfgqZFTbrwiiIJNTwkjIhUVsiCF, P_0.AdYfXDDqnlnJAcpYdAJCcRLqugSgb, P_0.AdYfXDDqnlnJAcpYdAJCcRLqugSgb);
			return true;
		}
		return false;
	}
}
