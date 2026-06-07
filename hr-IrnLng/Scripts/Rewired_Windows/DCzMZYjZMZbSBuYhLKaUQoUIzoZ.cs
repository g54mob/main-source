using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class DCzMZYjZMZbSBuYhLKaUQoUIzoZ : IDisposable
{
	private unsafe byte* vchQMUGnIIHSpgACjOTIdULpWgNC;

	private int NeCFvbKZnjntXirjrLSYpVwsgCt;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public unsafe byte* UnsafePointer => vchQMUGnIIHSpgACjOTIdULpWgNC;

	public unsafe IntPtr Pointer => (IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC;

	public int Length => NeCFvbKZnjntXirjrLSYpVwsgCt;

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= NeCFvbKZnjntXirjrLSYpVwsgCt)
			{
				throw new IndexOutOfRangeException();
			}
			return vchQMUGnIIHSpgACjOTIdULpWgNC[index];
		}
		set
		{
			if (index < 0 || index >= NeCFvbKZnjntXirjrLSYpVwsgCt)
			{
				throw new IndexOutOfRangeException();
			}
			vchQMUGnIIHSpgACjOTIdULpWgNC[index] = value;
		}
	}

	public DCzMZYjZMZbSBuYhLKaUQoUIzoZ(int size)
	{
		RjqJMpDJGfDpTKkpEeJAjxfFqoVz(size);
	}

	public unsafe IntPtr oODJxsuFfuLbfIsUzNqqJojaBPVf(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC;
		}
		if (P_0 < 0 || P_0 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe string LEqeHSJdhugqmfaHteDBCdsCebcC()
	{
		string text = "";
		for (int i = 0; i < NeCFvbKZnjntXirjrLSYpVwsgCt; i++)
		{
			text = text + vchQMUGnIIHSpgACjOTIdULpWgNC[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool TXWAedgTpLjZfJInftZsrLTDnvGq(int P_0, byte P_1)
	{
		if (1 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (vchQMUGnIIHSpgACjOTIdULpWgNC[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte vAkdmceCTtsDJaiAdkYQFEkPGMi(int P_0)
	{
		if (1 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return vchQMUGnIIHSpgACjOTIdULpWgNC[P_0];
	}

	public unsafe short mKdFKWlRJvwjJfEFjjhhylfghsq(int P_0)
	{
		if (2 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe ushort irPhyzwxzIVtiYhFrnImUalyfRX(int P_0)
	{
		if (2 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe int rOZlFISvBLSEdGERNGDlicgwAdxh(int P_0)
	{
		if (4 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe uint XtzPvpcatItdOObUYWABaKlsghF(int P_0)
	{
		if (4 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe long IyiFeXVKrxQasfhpQxPnoFnJgcDc(int P_0)
	{
		if (8 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe ulong SDCIFnYKTIEgCdEHuTesViSJbyN(int P_0)
	{
		if (8 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_0);
	}

	public unsafe void OyoZWUuiamgvSVRBhbJZhjZZxdr(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_2 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_1 + P_2 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_2, P_3, P_1);
	}

	public unsafe void OyoZWUuiamgvSVRBhbJZhjZZxdr(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_3 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_2 + P_3 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_3, P_4, P_2);
	}

	public unsafe void OyoZWUuiamgvSVRBhbJZhjZZxdr(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		OyoZWUuiamgvSVRBhbJZhjZZxdr((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int PomFOnmcQgClBNCxQerVwIDHIlac(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_2 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			P_1 = NeCFvbKZnjntXirjrLSYpVwsgCt - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int PomFOnmcQgClBNCxQerVwIDHIlac(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_3 + P_2 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			P_2 = NeCFvbKZnjntXirjrLSYpVwsgCt - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int PomFOnmcQgClBNCxQerVwIDHIlac(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return PomFOnmcQgClBNCxQerVwIDHIlac((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void vWMWKvHFGeWDgMauoWyodBVkfVY(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* intPtr = vchQMUGnIIHSpgACjOTIdULpWgNC + P_0;
			*intPtr |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* intPtr2 = vchQMUGnIIHSpgACjOTIdULpWgNC + P_0;
			*intPtr2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(byte P_0, int P_1)
	{
		if (1 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		vchQMUGnIIHSpgACjOTIdULpWgNC[P_1] = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(short P_0, int P_1)
	{
		if (2 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_1) = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(ushort P_0, int P_1)
	{
		if (2 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_1) = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(int P_0, int P_1)
	{
		if (4 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_1) = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(uint P_0, int P_1)
	{
		if (4 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_1) = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(long P_0, int P_1)
	{
		if (8 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_1) = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(ulong P_0, int P_1)
	{
		if (8 + P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(vchQMUGnIIHSpgACjOTIdULpWgNC + P_1) = P_0;
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_2 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_1 + P_2 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_3, P_2, P_1);
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_3 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_2 + P_3 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(P_0, vchQMUGnIIHSpgACjOTIdULpWgNC, P_4, P_3, P_2);
	}

	public unsafe void xwyOTGiXUEnQReUfdMBlfOwNgvM(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		xwyOTGiXUEnQReUfdMBlfOwNgvM((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int dpRzKpmKAUkiSitZiXveOkUIvfw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_1 + P_2 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			P_1 = NeCFvbKZnjntXirjrLSYpVwsgCt - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int dpRzKpmKAUkiSitZiXveOkUIvfw(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= NeCFvbKZnjntXirjrLSYpVwsgCt)
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
		if (P_2 + P_3 > NeCFvbKZnjntXirjrLSYpVwsgCt)
		{
			P_2 = NeCFvbKZnjntXirjrLSYpVwsgCt - P_3;
		}
		jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(P_0, vchQMUGnIIHSpgACjOTIdULpWgNC, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int dpRzKpmKAUkiSitZiXveOkUIvfw(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return dpRzKpmKAUkiSitZiXveOkUIvfw((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool RjqJMpDJGfDpTKkpEeJAjxfFqoVz(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (NeCFvbKZnjntXirjrLSYpVwsgCt == P_0)
		{
			return true;
		}
		YhGqcOYjANTtgKCQfFoFiVfqeBpx();
		if (P_0 == 0)
		{
			return true;
		}
		NeCFvbKZnjntXirjrLSYpVwsgCt = P_0;
		vchQMUGnIIHSpgACjOTIdULpWgNC = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		avkcOhFlGGeHrNSdTQlLZUnJDbw();
		return true;
	}

	public unsafe void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		if (NeCFvbKZnjntXirjrLSYpVwsgCt != 0)
		{
			jrpbiUWSBQEMcGMhBQbhkaeULUlm.mRuGPTMmoPyrhOguOAfkSRsaMuj(vchQMUGnIIHSpgACjOTIdULpWgNC, NeCFvbKZnjntXirjrLSYpVwsgCt);
		}
	}

	public unsafe void YhGqcOYjANTtgKCQfFoFiVfqeBpx()
	{
		if (NeCFvbKZnjntXirjrLSYpVwsgCt == 0)
		{
			return;
		}
		try
		{
			if (vchQMUGnIIHSpgACjOTIdULpWgNC != null)
			{
				Marshal.FreeHGlobal(Pointer);
			}
		}
		catch
		{
		}
		vchQMUGnIIHSpgACjOTIdULpWgNC = null;
		NeCFvbKZnjntXirjrLSYpVwsgCt = 0;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < NeCFvbKZnjntXirjrLSYpVwsgCt; i++)
		{
			text = text + vAkdmceCTtsDJaiAdkYQFEkPGMi(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~DCzMZYjZMZbSBuYhLKaUQoUIzoZ()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			YhGqcOYjANTtgKCQfFoFiVfqeBpx();
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	public unsafe static implicit operator IntPtr(DCzMZYjZMZbSBuYhLKaUQoUIzoZ buffer)
	{
		if (buffer == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)buffer.vchQMUGnIIHSpgACjOTIdULpWgNC;
	}

	public unsafe static implicit operator void*(DCzMZYjZMZbSBuYhLKaUQoUIzoZ buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		return buffer.vchQMUGnIIHSpgACjOTIdULpWgNC;
	}

	public unsafe static bool xMeWHvLnqZqxzXcqOwGvibOWPzq(DCzMZYjZMZbSBuYhLKaUQoUIzoZ P_0, DCzMZYjZMZbSBuYhLKaUQoUIzoZ P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.NeCFvbKZnjntXirjrLSYpVwsgCt == 0)
		{
			P_1.YhGqcOYjANTtgKCQfFoFiVfqeBpx();
			return true;
		}
		if (P_1.RjqJMpDJGfDpTKkpEeJAjxfFqoVz(P_0.NeCFvbKZnjntXirjrLSYpVwsgCt))
		{
			P_1.xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0.vchQMUGnIIHSpgACjOTIdULpWgNC, P_0.NeCFvbKZnjntXirjrLSYpVwsgCt, P_0.NeCFvbKZnjntXirjrLSYpVwsgCt);
			return true;
		}
		return false;
	}
}
