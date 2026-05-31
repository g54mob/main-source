using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class oWaAwGacrcpxHTEfaYhOhGhfHMfe : IDisposable
{
	private readonly byte[] MGmVOJiswkwnBAbvbGQwLtBdeEt;

	public readonly int ZlqkBHsBFcjMlbgSwtsQjPHHaWR;

	private GCHandle LXDCUiKbjPHeDVBwIruwccfrnje;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public bool IsPinned => LXDCUiKbjPHeDVBwIruwccfrnje.IsAllocated;

	public byte this[int index]
	{
		get
		{
			return MGmVOJiswkwnBAbvbGQwLtBdeEt[index];
		}
		set
		{
			MGmVOJiswkwnBAbvbGQwLtBdeEt[index] = value;
		}
	}

	public oWaAwGacrcpxHTEfaYhOhGhfHMfe(int size)
	{
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		ZlqkBHsBFcjMlbgSwtsQjPHHaWR = size;
		MGmVOJiswkwnBAbvbGQwLtBdeEt = new byte[size];
	}

	public IntPtr XbDjdMiSSYmTpccAQvEQEXncZuu()
	{
		if (LXDCUiKbjPHeDVBwIruwccfrnje.IsAllocated)
		{
			return LXDCUiKbjPHeDVBwIruwccfrnje.AddrOfPinnedObject();
		}
		LXDCUiKbjPHeDVBwIruwccfrnje = GCHandle.Alloc(MGmVOJiswkwnBAbvbGQwLtBdeEt, GCHandleType.Pinned);
		return LXDCUiKbjPHeDVBwIruwccfrnje.AddrOfPinnedObject();
	}

	public void iFCYJkNMDOrzeaxXMarbFFbvmqN()
	{
		if (LXDCUiKbjPHeDVBwIruwccfrnje.IsAllocated)
		{
			LXDCUiKbjPHeDVBwIruwccfrnje.Free();
		}
	}

	public string LEqeHSJdhugqmfaHteDBCdsCebcC()
	{
		string text = "";
		for (int i = 0; i < ZlqkBHsBFcjMlbgSwtsQjPHHaWR; i++)
		{
			text = text + MGmVOJiswkwnBAbvbGQwLtBdeEt[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool TXWAedgTpLjZfJInftZsrLTDnvGq(int P_0, byte P_1)
	{
		if (1 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (MGmVOJiswkwnBAbvbGQwLtBdeEt[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte vAkdmceCTtsDJaiAdkYQFEkPGMi(int P_0)
	{
		if (1 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return MGmVOJiswkwnBAbvbGQwLtBdeEt[P_0];
	}

	public unsafe short mKdFKWlRJvwjJfEFjjhhylfghsq(int P_0)
	{
		if (2 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			return *(short*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_0);
		}
	}

	public unsafe ushort irPhyzwxzIVtiYhFrnImUalyfRX(int P_0)
	{
		if (2 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			return *(ushort*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_0);
		}
	}

	public unsafe int rOZlFISvBLSEdGERNGDlicgwAdxh(int P_0)
	{
		if (4 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			return *(int*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_0);
		}
	}

	public unsafe uint XtzPvpcatItdOObUYWABaKlsghF(int P_0)
	{
		if (4 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			return *(uint*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_0);
		}
	}

	public unsafe long IyiFeXVKrxQasfhpQxPnoFnJgcDc(int P_0)
	{
		if (8 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			return *(long*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_0);
		}
	}

	public unsafe ulong SDCIFnYKTIEgCdEHuTesViSJbyN(int P_0)
	{
		if (8 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			return *(ulong*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_0);
		}
	}

	public void OyoZWUuiamgvSVRBhbJZhjZZxdr(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_2 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_1 + P_2 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(MGmVOJiswkwnBAbvbGQwLtBdeEt, P_2, P_0, P_3, P_1);
	}

	public void OyoZWUuiamgvSVRBhbJZhjZZxdr(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_3 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_2 + P_3 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(MGmVOJiswkwnBAbvbGQwLtBdeEt, P_0, P_3, P_4, P_2);
	}

	public int PomFOnmcQgClBNCxQerVwIDHIlac(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_2 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			P_1 = ZlqkBHsBFcjMlbgSwtsQjPHHaWR - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(MGmVOJiswkwnBAbvbGQwLtBdeEt, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int PomFOnmcQgClBNCxQerVwIDHIlac(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_3 + P_2 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			P_2 = ZlqkBHsBFcjMlbgSwtsQjPHHaWR - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(MGmVOJiswkwnBAbvbGQwLtBdeEt, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void vWMWKvHFGeWDgMauoWyodBVkfVY(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			MGmVOJiswkwnBAbvbGQwLtBdeEt[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			MGmVOJiswkwnBAbvbGQwLtBdeEt[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void xwyOTGiXUEnQReUfdMBlfOwNgvM(byte P_0, int P_1)
	{
		if (1 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		MGmVOJiswkwnBAbvbGQwLtBdeEt[P_1] = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(short P_0, int P_1)
	{
		if (2 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			*(short*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_1) = P_0;
		}
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(ushort P_0, int P_1)
	{
		if (2 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			*(ushort*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_1) = P_0;
		}
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(int P_0, int P_1)
	{
		if (4 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			*(int*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_1) = P_0;
		}
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(uint P_0, int P_1)
	{
		if (4 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			*(uint*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_1) = P_0;
		}
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(long P_0, int P_1)
	{
		if (8 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			*(long*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_1) = P_0;
		}
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(ulong P_0, int P_1)
	{
		if (8 + P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
		{
			*(ulong*)(mGmVOJiswkwnBAbvbGQwLtBdeEt + P_1) = P_0;
		}
	}

	public void xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_2 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_1 + P_2 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, MGmVOJiswkwnBAbvbGQwLtBdeEt, P_2, P_1);
	}

	public void xwyOTGiXUEnQReUfdMBlfOwNgvM(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_3 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_2 + P_3 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, MGmVOJiswkwnBAbvbGQwLtBdeEt, P_4, P_3, P_2);
	}

	public int dpRzKpmKAUkiSitZiXveOkUIvfw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_1 + P_2 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			P_1 = ZlqkBHsBFcjMlbgSwtsQjPHHaWR - P_2;
		}
		Array.Copy(P_0, P_3, MGmVOJiswkwnBAbvbGQwLtBdeEt, P_2, P_1);
		return P_1;
	}

	public int dpRzKpmKAUkiSitZiXveOkUIvfw(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
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
		if (P_2 + P_3 > ZlqkBHsBFcjMlbgSwtsQjPHHaWR)
		{
			P_2 = ZlqkBHsBFcjMlbgSwtsQjPHHaWR - P_3;
		}
		NativeTools.CopyMemory(P_0, MGmVOJiswkwnBAbvbGQwLtBdeEt, P_4, P_3, P_2);
		return P_2;
	}

	public void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		Array.Clear(MGmVOJiswkwnBAbvbGQwLtBdeEt, 0, ZlqkBHsBFcjMlbgSwtsQjPHHaWR);
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < ZlqkBHsBFcjMlbgSwtsQjPHHaWR; i++)
		{
			text = text + this[i].ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~oWaAwGacrcpxHTEfaYhOhGhfHMfe()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			if (LXDCUiKbjPHeDVBwIruwccfrnje.IsAllocated)
			{
				LXDCUiKbjPHeDVBwIruwccfrnje.Free();
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	public static void xMeWHvLnqZqxzXcqOwGvibOWPzq(oWaAwGacrcpxHTEfaYhOhGhfHMfe P_0, oWaAwGacrcpxHTEfaYhOhGhfHMfe P_1, int P_2)
	{
		Array.Copy(P_0.MGmVOJiswkwnBAbvbGQwLtBdeEt, P_1.MGmVOJiswkwnBAbvbGQwLtBdeEt, P_2);
	}

	public static void xMeWHvLnqZqxzXcqOwGvibOWPzq(oWaAwGacrcpxHTEfaYhOhGhfHMfe P_0, int P_1, oWaAwGacrcpxHTEfaYhOhGhfHMfe P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.MGmVOJiswkwnBAbvbGQwLtBdeEt, P_1, P_2.MGmVOJiswkwnBAbvbGQwLtBdeEt, P_3, P_4);
	}
}
