using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class fFicYORCqoZwZowJIRdCWZeAXNjG : IDisposable
{
	private unsafe byte* hsdmYmvXIRvGqMIBamoctajCJFDx;

	private int eQZAwoslIrnpQHBirepufURLAelfb;

	private bool MNkPcuElLYMqMPYXqdvubHdoAcFW;

	public unsafe byte* eKYXFmvuithCeDklgGsWGYOTFcXm => hsdmYmvXIRvGqMIBamoctajCJFDx;

	public unsafe IntPtr htleiMGbKkdgXiYbwwHlpQSekWiiA => (IntPtr)hsdmYmvXIRvGqMIBamoctajCJFDx;

	public int NZCeieVIXcnmzZzFYorhUGIfBpphA => eQZAwoslIrnpQHBirepufURLAelfb;

	public unsafe byte vPORADaxQxLpHCkNuPGwayENdVYh
	{
		get
		{
			if (P_0 < 0 || P_0 >= eQZAwoslIrnpQHBirepufURLAelfb)
			{
				throw new IndexOutOfRangeException();
			}
			return hsdmYmvXIRvGqMIBamoctajCJFDx[P_0];
		}
		set
		{
			if (num < 0 || num >= eQZAwoslIrnpQHBirepufURLAelfb)
			{
				throw new IndexOutOfRangeException();
			}
			hsdmYmvXIRvGqMIBamoctajCJFDx[num] = b;
		}
	}

	public fFicYORCqoZwZowJIRdCWZeAXNjG(int P_0)
	{
		VLtiQJQnkxbtBGnNaIeMJFsfdSzX(P_0);
	}

	public unsafe IntPtr NaKJHAYGosNDXrFuXstxvOcyxUwc(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)hsdmYmvXIRvGqMIBamoctajCJFDx;
		}
		if (P_0 < 0 || P_0 >= eQZAwoslIrnpQHBirepufURLAelfb)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe string mtORsCPNlhaaTUGPRZNfWINxhvXX()
	{
		string text = "";
		for (int i = 0; i < eQZAwoslIrnpQHBirepufURLAelfb; i++)
		{
			text = text + hsdmYmvXIRvGqMIBamoctajCJFDx[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool NjIldxshPLOpSOLJpEUONQMYDjem(int P_0, byte P_1)
	{
		if (1 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (hsdmYmvXIRvGqMIBamoctajCJFDx[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte YYCfMwGmshiMXuLxyGJhayPjvikbb(int P_0)
	{
		if (1 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return hsdmYmvXIRvGqMIBamoctajCJFDx[P_0];
	}

	public unsafe short kkyQTkDfPsCdXywsuRxfgEVzIXhk(int P_0)
	{
		if (2 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe ushort KzUPVqRbmFnLkuznkQHEDBYBELbj(int P_0)
	{
		if (2 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe int WyXSZfslXCEJpphGFvbVgrhTfBuo(int P_0)
	{
		if (4 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe uint PCsHPTApgxdFTOqMVvBHElZjWQbGA(int P_0)
	{
		if (4 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe long zdVcyeCbkTedszrkhPuoofTAeFtXA(int P_0)
	{
		if (8 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe ulong FRsQrPksnMKnrbbBxKBmDLCTZkwG(int P_0)
	{
		if (8 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe float FOBLJoQdZJqkgHbbPDVvJwTEtaMc(int P_0)
	{
		if (4 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe double EtrcPcRBFTyaVycceAwJejfUJIyNA(int P_0)
	{
		if (8 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_0);
	}

	public unsafe void ZhgksdRvLRIabgOHOKXTDzUaDBQs(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_2 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_1 + P_2 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)hsdmYmvXIRvGqMIBamoctajCJFDx, P_0, P_2, P_3, P_1);
	}

	public unsafe void mfWaVOQpcvGHBANgVteUtOvmbzIjA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_3 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_2 + P_3 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(hsdmYmvXIRvGqMIBamoctajCJFDx, P_0, P_3, P_4, P_2);
	}

	public unsafe void JLwWsNFUoldGtGqQkcBQDYitOdFX(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		mfWaVOQpcvGHBANgVteUtOvmbzIjA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int lhCeFCwCLzCoGTXgCjtxpEKegIbDA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_2 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			P_1 = eQZAwoslIrnpQHBirepufURLAelfb - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)hsdmYmvXIRvGqMIBamoctajCJFDx, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int KQjdjeOBqEcDeVhyTSkNnyXouNNs(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_3 + P_2 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			P_2 = eQZAwoslIrnpQHBirepufURLAelfb - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(hsdmYmvXIRvGqMIBamoctajCJFDx, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int KnMAhhoCLUEktlYBRNIbvpUcUhJf(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return KQjdjeOBqEcDeVhyTSkNnyXouNNs((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void FXjZEREwdcToIqKTbcREbVcCvpBL(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > eQZAwoslIrnpQHBirepufURLAelfb || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = hsdmYmvXIRvGqMIBamoctajCJFDx + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = hsdmYmvXIRvGqMIBamoctajCJFDx + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void GcCtQCsVAWLLDUYUaKTJJCPYZinI(byte P_0, int P_1)
	{
		if (1 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		hsdmYmvXIRvGqMIBamoctajCJFDx[P_1] = P_0;
	}

	public unsafe void VjmXPNpELDEoROpzjhEYFZIssGlF(short P_0, int P_1)
	{
		if (2 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void xMyOOThnFfuOJAMWGnUzWpWNFTBaA(ushort P_0, int P_1)
	{
		if (2 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void OeBkHjuJJkYNoTmvJNbqttQcUrtu(int P_0, int P_1)
	{
		if (4 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void qgZjNVkHPoIGtiSaSdQokWTMZEIEA(uint P_0, int P_1)
	{
		if (4 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void vxBNAZSRjMSbboVuWgqbaCeggGzI(long P_0, int P_1)
	{
		if (8 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void eSyFLcDUXenWfoGbyksExHWGqciIA(ulong P_0, int P_1)
	{
		if (8 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void UwAcMRgZirSxkeMgXOnFeAXfnoQxA(float P_0, int P_1)
	{
		if (4 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void GWMwrXJLFfdttGagsZKFmQoqiMufb(double P_0, int P_1)
	{
		if (8 + P_1 > eQZAwoslIrnpQHBirepufURLAelfb || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(hsdmYmvXIRvGqMIBamoctajCJFDx + P_1) = P_0;
	}

	public unsafe void LlmdbMXfHJRSfYREzywTuinXXVHm(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_2 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_1 + P_2 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)hsdmYmvXIRvGqMIBamoctajCJFDx, P_3, P_2, P_1);
	}

	public unsafe void FutejKcvkRZKUAixpiJnweUqPkiDb(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_3 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_2 + P_3 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(P_0, hsdmYmvXIRvGqMIBamoctajCJFDx, P_4, P_3, P_2);
	}

	public unsafe void gFfKOZROOWhCLTaJhArsbeXUHzBBA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		FutejKcvkRZKUAixpiJnweUqPkiDb((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int kFMICLAquitLhIvFngJVHfCnQwTeb(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_1 + P_2 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			P_1 = eQZAwoslIrnpQHBirepufURLAelfb - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)hsdmYmvXIRvGqMIBamoctajCJFDx, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int GeYXwhgeajguHnNFyGjgCplWHRnFA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= eQZAwoslIrnpQHBirepufURLAelfb)
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
		if (P_2 + P_3 > eQZAwoslIrnpQHBirepufURLAelfb)
		{
			P_2 = eQZAwoslIrnpQHBirepufURLAelfb - P_3;
		}
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(P_0, hsdmYmvXIRvGqMIBamoctajCJFDx, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int WyWjmYldVzOPnclSpipOCyNnETvv(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return GeYXwhgeajguHnNFyGjgCplWHRnFA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool VLtiQJQnkxbtBGnNaIeMJFsfdSzX(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (eQZAwoslIrnpQHBirepufURLAelfb == P_0)
		{
			return true;
		}
		yCtLMmhxexTDSybvDHbZFyVXVNgH();
		if (P_0 == 0)
		{
			return true;
		}
		eQZAwoslIrnpQHBirepufURLAelfb = P_0;
		hsdmYmvXIRvGqMIBamoctajCJFDx = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		YhMmSocvHGwaHogVrYvGPEPHdphI();
		return true;
	}

	public unsafe void YhMmSocvHGwaHogVrYvGPEPHdphI()
	{
		if (eQZAwoslIrnpQHBirepufURLAelfb != 0)
		{
			byZcZqIHxDbsMlffPcbwjwzKCDShb.QWzjHjKKFDaDLHcBJvSqVPOlqHWH(hsdmYmvXIRvGqMIBamoctajCJFDx, eQZAwoslIrnpQHBirepufURLAelfb);
		}
	}

	public unsafe void yCtLMmhxexTDSybvDHbZFyVXVNgH()
	{
		if (eQZAwoslIrnpQHBirepufURLAelfb == 0)
		{
			return;
		}
		try
		{
			if (hsdmYmvXIRvGqMIBamoctajCJFDx != null)
			{
				Marshal.FreeHGlobal(htleiMGbKkdgXiYbwwHlpQSekWiiA);
			}
		}
		catch
		{
		}
		hsdmYmvXIRvGqMIBamoctajCJFDx = null;
		eQZAwoslIrnpQHBirepufURLAelfb = 0;
	}

	public virtual string pwzGKCideRJgqyqDcgUOyCPUHsHzA()
	{
		string text = "";
		for (int i = 0; i < eQZAwoslIrnpQHBirepufURLAelfb; i++)
		{
			text = text + YYCfMwGmshiMXuLxyGJhayPjvikbb(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		ZVjeQGhhwkqMjGMtBRlAoQRNhtgoB(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void gHqNRnuZWEQBoOJpMTeWFYLgaybS()
	{
		try
		{
			ZVjeQGhhwkqMjGMtBRlAoQRNhtgoB(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ZVjeQGhhwkqMjGMtBRlAoQRNhtgoB(bool P_0)
	{
		if (!MNkPcuElLYMqMPYXqdvubHdoAcFW)
		{
			yCtLMmhxexTDSybvDHbZFyVXVNgH();
			MNkPcuElLYMqMPYXqdvubHdoAcFW = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr RnOfsfFHtBeuEBYfBKvjaaPcnokEB(fFicYORCqoZwZowJIRdCWZeAXNjG P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.hsdmYmvXIRvGqMIBamoctajCJFDx;
	}

	[SpecialName]
	public unsafe static void* RnOfsfFHtBeuEBYfBKvjaaPcnokEB(fFicYORCqoZwZowJIRdCWZeAXNjG P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.hsdmYmvXIRvGqMIBamoctajCJFDx;
	}

	public unsafe static bool XXWAPSmnggCNEDkUahJPhoMcQwNCB(fFicYORCqoZwZowJIRdCWZeAXNjG P_0, fFicYORCqoZwZowJIRdCWZeAXNjG P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.eQZAwoslIrnpQHBirepufURLAelfb == 0)
		{
			P_1.yCtLMmhxexTDSybvDHbZFyVXVNgH();
			return true;
		}
		if (P_1.VLtiQJQnkxbtBGnNaIeMJFsfdSzX(P_0.eQZAwoslIrnpQHBirepufURLAelfb))
		{
			P_1.FutejKcvkRZKUAixpiJnweUqPkiDb(P_0.hsdmYmvXIRvGqMIBamoctajCJFDx, P_0.eQZAwoslIrnpQHBirepufURLAelfb, P_0.eQZAwoslIrnpQHBirepufURLAelfb);
			return true;
		}
		return false;
	}
}
