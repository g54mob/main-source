using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class OrGbzVsUcUYnmShreCvhbuxVmzF : IDisposable
{
	private unsafe byte* qQYuLTZsgJCxImVGAnRthYmmwjT;

	private int IMjTFiJIFmfpyGTzGakvQvNrmCr;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public unsafe byte* UnsafePointer => qQYuLTZsgJCxImVGAnRthYmmwjT;

	public unsafe IntPtr Pointer => (IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT;

	public int Length => IMjTFiJIFmfpyGTzGakvQvNrmCr;

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
			{
				throw new IndexOutOfRangeException();
			}
			return qQYuLTZsgJCxImVGAnRthYmmwjT[index];
		}
		set
		{
			if (index < 0 || index >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
			{
				throw new IndexOutOfRangeException();
			}
			qQYuLTZsgJCxImVGAnRthYmmwjT[index] = value;
		}
	}

	public OrGbzVsUcUYnmShreCvhbuxVmzF(int size)
	{
		OzBqWySwcghOwQUvdbhpKDAOcuF(size);
	}

	public unsafe IntPtr txgCPphKDpadCgaWUWINMaMzzNRR(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT;
		}
		if (P_0 < 0 || P_0 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe string IOZECZAFJtVaFVoZUDfgUBDByhe()
	{
		string text = "";
		for (int i = 0; i < IMjTFiJIFmfpyGTzGakvQvNrmCr; i++)
		{
			text = text + qQYuLTZsgJCxImVGAnRthYmmwjT[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool SftSuGxTUNXYwWlGMlHcDgCQzU(int P_0, byte P_1)
	{
		if (1 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (qQYuLTZsgJCxImVGAnRthYmmwjT[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte uvHwBpvitgRiqEjSWjkdcpFUBKeK(int P_0)
	{
		if (1 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return qQYuLTZsgJCxImVGAnRthYmmwjT[P_0];
	}

	public unsafe short zcKPvRkqjuuysJXPGTTSNkKdBqe(int P_0)
	{
		if (2 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe ushort xfiZZypNLNGXQexrAVLjxtRnVtD(int P_0)
	{
		if (2 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe int ecadHFZprMOkUiwLwxEGJETpbjd(int P_0)
	{
		if (4 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe uint UaONoalXTNhGlaOOjqLgZCKjxBH(int P_0)
	{
		if (4 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe long ZHNUQUMwVegUJLTdnjrMHBWAikX(int P_0)
	{
		if (8 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe ulong NSlAxeZytXgkxLIPRQIBgJpYDwJ(int P_0)
	{
		if (8 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_0);
	}

	public unsafe void DTWqTxyQfjlbrIFGzfuUHiIHdt(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_2 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_1 + P_2 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_2, P_3, P_1);
	}

	public unsafe void DTWqTxyQfjlbrIFGzfuUHiIHdt(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_3 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_2 + P_3 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_3, P_4, P_2);
	}

	public unsafe void DTWqTxyQfjlbrIFGzfuUHiIHdt(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		DTWqTxyQfjlbrIFGzfuUHiIHdt((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int YcTavaBvopmAydprftBqiBcNIfcn(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_2 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			P_1 = IMjTFiJIFmfpyGTzGakvQvNrmCr - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int YcTavaBvopmAydprftBqiBcNIfcn(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_3 + P_2 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			P_2 = IMjTFiJIFmfpyGTzGakvQvNrmCr - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int YcTavaBvopmAydprftBqiBcNIfcn(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return YcTavaBvopmAydprftBqiBcNIfcn((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void icfuJaKhkvPCRwBmPIrNKHmxBwI(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* intPtr = qQYuLTZsgJCxImVGAnRthYmmwjT + P_0;
			*intPtr |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* intPtr2 = qQYuLTZsgJCxImVGAnRthYmmwjT + P_0;
			*intPtr2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(byte P_0, int P_1)
	{
		if (1 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		qQYuLTZsgJCxImVGAnRthYmmwjT[P_1] = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(short P_0, int P_1)
	{
		if (2 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_1) = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(ushort P_0, int P_1)
	{
		if (2 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_1) = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(int P_0, int P_1)
	{
		if (4 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_1) = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(uint P_0, int P_1)
	{
		if (4 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_1) = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(long P_0, int P_1)
	{
		if (8 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_1) = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(ulong P_0, int P_1)
	{
		if (8 + P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(qQYuLTZsgJCxImVGAnRthYmmwjT + P_1) = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_2 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_1 + P_2 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_3, P_2, P_1);
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_3 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_2 + P_3 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(P_0, qQYuLTZsgJCxImVGAnRthYmmwjT, P_4, P_3, P_2);
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		ujTUoJrkpPHtthAWMneMiOxOImEn((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int epMaJBAdoLzeFFCbmvbUPnNNexnJ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_1 + P_2 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			P_1 = IMjTFiJIFmfpyGTzGakvQvNrmCr - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int epMaJBAdoLzeFFCbmvbUPnNNexnJ(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= IMjTFiJIFmfpyGTzGakvQvNrmCr)
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
		if (P_2 + P_3 > IMjTFiJIFmfpyGTzGakvQvNrmCr)
		{
			P_2 = IMjTFiJIFmfpyGTzGakvQvNrmCr - P_3;
		}
		oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(P_0, qQYuLTZsgJCxImVGAnRthYmmwjT, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int epMaJBAdoLzeFFCbmvbUPnNNexnJ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return epMaJBAdoLzeFFCbmvbUPnNNexnJ((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool OzBqWySwcghOwQUvdbhpKDAOcuF(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (IMjTFiJIFmfpyGTzGakvQvNrmCr == P_0)
		{
			return true;
		}
		VVlOPBBNqGjoVyzKMEmgidCtaHv();
		if (P_0 == 0)
		{
			return true;
		}
		IMjTFiJIFmfpyGTzGakvQvNrmCr = P_0;
		qQYuLTZsgJCxImVGAnRthYmmwjT = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		rKJfCRBWFLQsKCjGykmcumzKLPwE();
		return true;
	}

	public unsafe void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		if (IMjTFiJIFmfpyGTzGakvQvNrmCr != 0)
		{
			oCGEXVhAHCOVsdbcLXOHRPRMXp.zbXcjYVUEMeyWwienlZHtNPzsup(qQYuLTZsgJCxImVGAnRthYmmwjT, IMjTFiJIFmfpyGTzGakvQvNrmCr);
		}
	}

	public unsafe void VVlOPBBNqGjoVyzKMEmgidCtaHv()
	{
		if (IMjTFiJIFmfpyGTzGakvQvNrmCr == 0)
		{
			return;
		}
		try
		{
			if (qQYuLTZsgJCxImVGAnRthYmmwjT != null)
			{
				Marshal.FreeHGlobal(Pointer);
			}
		}
		catch
		{
		}
		qQYuLTZsgJCxImVGAnRthYmmwjT = null;
		IMjTFiJIFmfpyGTzGakvQvNrmCr = 0;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < IMjTFiJIFmfpyGTzGakvQvNrmCr; i++)
		{
			text = text + uvHwBpvitgRiqEjSWjkdcpFUBKeK(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~OrGbzVsUcUYnmShreCvhbuxVmzF()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			VVlOPBBNqGjoVyzKMEmgidCtaHv();
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	public unsafe static implicit operator IntPtr(OrGbzVsUcUYnmShreCvhbuxVmzF buffer)
	{
		if (buffer == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)buffer.qQYuLTZsgJCxImVGAnRthYmmwjT;
	}

	public unsafe static implicit operator void*(OrGbzVsUcUYnmShreCvhbuxVmzF buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		return buffer.qQYuLTZsgJCxImVGAnRthYmmwjT;
	}

	public unsafe static bool mYXdNaYIlEpYEdwXrmCQZlkJhfc(OrGbzVsUcUYnmShreCvhbuxVmzF P_0, OrGbzVsUcUYnmShreCvhbuxVmzF P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.IMjTFiJIFmfpyGTzGakvQvNrmCr == 0)
		{
			P_1.VVlOPBBNqGjoVyzKMEmgidCtaHv();
			return true;
		}
		if (P_1.OzBqWySwcghOwQUvdbhpKDAOcuF(P_0.IMjTFiJIFmfpyGTzGakvQvNrmCr))
		{
			P_1.ujTUoJrkpPHtthAWMneMiOxOImEn(P_0.qQYuLTZsgJCxImVGAnRthYmmwjT, P_0.IMjTFiJIFmfpyGTzGakvQvNrmCr, P_0.IMjTFiJIFmfpyGTzGakvQvNrmCr);
			return true;
		}
		return false;
	}
}
