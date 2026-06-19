using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class vGJIEJxtBxddwvibNBDfOMIsSWt : IDisposable
{
	private readonly byte[] DBZCtHAzIvFuQOarCKsttoMaNgUG;

	public readonly int KyBrWGhjlptUSFhGBWQdYDaYhUF;

	private GCHandle QHuKofBhFMjkiEtyhXKJsRYiRhoA;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public bool IsPinned => QHuKofBhFMjkiEtyhXKJsRYiRhoA.IsAllocated;

	public byte this[int index]
	{
		get
		{
			return DBZCtHAzIvFuQOarCKsttoMaNgUG[index];
		}
		set
		{
			DBZCtHAzIvFuQOarCKsttoMaNgUG[index] = value;
		}
	}

	public vGJIEJxtBxddwvibNBDfOMIsSWt(int size)
	{
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		KyBrWGhjlptUSFhGBWQdYDaYhUF = size;
		DBZCtHAzIvFuQOarCKsttoMaNgUG = new byte[size];
	}

	public IntPtr SMkZaTVcNVZOQAUrzsJdcCPtkXs()
	{
		if (QHuKofBhFMjkiEtyhXKJsRYiRhoA.IsAllocated)
		{
			return QHuKofBhFMjkiEtyhXKJsRYiRhoA.AddrOfPinnedObject();
		}
		QHuKofBhFMjkiEtyhXKJsRYiRhoA = GCHandle.Alloc(DBZCtHAzIvFuQOarCKsttoMaNgUG, GCHandleType.Pinned);
		return QHuKofBhFMjkiEtyhXKJsRYiRhoA.AddrOfPinnedObject();
	}

	public void hYnnabOJnZhbPbQZztEUIeKuNePP()
	{
		if (QHuKofBhFMjkiEtyhXKJsRYiRhoA.IsAllocated)
		{
			QHuKofBhFMjkiEtyhXKJsRYiRhoA.Free();
		}
	}

	public string IOZECZAFJtVaFVoZUDfgUBDByhe()
	{
		string text = "";
		for (int i = 0; i < KyBrWGhjlptUSFhGBWQdYDaYhUF; i++)
		{
			text = text + DBZCtHAzIvFuQOarCKsttoMaNgUG[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool SftSuGxTUNXYwWlGMlHcDgCQzU(int P_0, byte P_1)
	{
		if (1 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (DBZCtHAzIvFuQOarCKsttoMaNgUG[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte uvHwBpvitgRiqEjSWjkdcpFUBKeK(int P_0)
	{
		if (1 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return DBZCtHAzIvFuQOarCKsttoMaNgUG[P_0];
	}

	public unsafe short zcKPvRkqjuuysJXPGTTSNkKdBqe(int P_0)
	{
		if (2 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			return *(short*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_0);
		}
	}

	public unsafe ushort xfiZZypNLNGXQexrAVLjxtRnVtD(int P_0)
	{
		if (2 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			return *(ushort*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_0);
		}
	}

	public unsafe int ecadHFZprMOkUiwLwxEGJETpbjd(int P_0)
	{
		if (4 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			return *(int*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_0);
		}
	}

	public unsafe uint UaONoalXTNhGlaOOjqLgZCKjxBH(int P_0)
	{
		if (4 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			return *(uint*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_0);
		}
	}

	public unsafe long ZHNUQUMwVegUJLTdnjrMHBWAikX(int P_0)
	{
		if (8 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			return *(long*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_0);
		}
	}

	public unsafe ulong NSlAxeZytXgkxLIPRQIBgJpYDwJ(int P_0)
	{
		if (8 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			return *(ulong*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_0);
		}
	}

	public void DTWqTxyQfjlbrIFGzfuUHiIHdt(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_2 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_1 + P_2 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(DBZCtHAzIvFuQOarCKsttoMaNgUG, P_2, P_0, P_3, P_1);
	}

	public void DTWqTxyQfjlbrIFGzfuUHiIHdt(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_3 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_2 + P_3 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(DBZCtHAzIvFuQOarCKsttoMaNgUG, P_0, P_3, P_4, P_2);
	}

	public int YcTavaBvopmAydprftBqiBcNIfcn(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_2 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			P_1 = KyBrWGhjlptUSFhGBWQdYDaYhUF - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(DBZCtHAzIvFuQOarCKsttoMaNgUG, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int YcTavaBvopmAydprftBqiBcNIfcn(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_3 + P_2 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			P_2 = KyBrWGhjlptUSFhGBWQdYDaYhUF - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(DBZCtHAzIvFuQOarCKsttoMaNgUG, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void icfuJaKhkvPCRwBmPIrNKHmxBwI(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			DBZCtHAzIvFuQOarCKsttoMaNgUG[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			DBZCtHAzIvFuQOarCKsttoMaNgUG[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void ujTUoJrkpPHtthAWMneMiOxOImEn(byte P_0, int P_1)
	{
		if (1 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		DBZCtHAzIvFuQOarCKsttoMaNgUG[P_1] = P_0;
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(short P_0, int P_1)
	{
		if (2 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			*(short*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_1) = P_0;
		}
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(ushort P_0, int P_1)
	{
		if (2 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			*(ushort*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_1) = P_0;
		}
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(int P_0, int P_1)
	{
		if (4 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			*(int*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_1) = P_0;
		}
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(uint P_0, int P_1)
	{
		if (4 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			*(uint*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_1) = P_0;
		}
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(long P_0, int P_1)
	{
		if (8 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			*(long*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_1) = P_0;
		}
	}

	public unsafe void ujTUoJrkpPHtthAWMneMiOxOImEn(ulong P_0, int P_1)
	{
		if (8 + P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
		{
			*(ulong*)(dBZCtHAzIvFuQOarCKsttoMaNgUG + P_1) = P_0;
		}
	}

	public void ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_2 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_1 + P_2 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, DBZCtHAzIvFuQOarCKsttoMaNgUG, P_2, P_1);
	}

	public void ujTUoJrkpPHtthAWMneMiOxOImEn(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_3 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_2 + P_3 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, DBZCtHAzIvFuQOarCKsttoMaNgUG, P_4, P_3, P_2);
	}

	public int epMaJBAdoLzeFFCbmvbUPnNNexnJ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_1 + P_2 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			P_1 = KyBrWGhjlptUSFhGBWQdYDaYhUF - P_2;
		}
		Array.Copy(P_0, P_3, DBZCtHAzIvFuQOarCKsttoMaNgUG, P_2, P_1);
		return P_1;
	}

	public int epMaJBAdoLzeFFCbmvbUPnNNexnJ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= KyBrWGhjlptUSFhGBWQdYDaYhUF)
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
		if (P_2 + P_3 > KyBrWGhjlptUSFhGBWQdYDaYhUF)
		{
			P_2 = KyBrWGhjlptUSFhGBWQdYDaYhUF - P_3;
		}
		NativeTools.CopyMemory(P_0, DBZCtHAzIvFuQOarCKsttoMaNgUG, P_4, P_3, P_2);
		return P_2;
	}

	public void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		Array.Clear(DBZCtHAzIvFuQOarCKsttoMaNgUG, 0, KyBrWGhjlptUSFhGBWQdYDaYhUF);
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < KyBrWGhjlptUSFhGBWQdYDaYhUF; i++)
		{
			text = text + this[i].ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~vGJIEJxtBxddwvibNBDfOMIsSWt()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			if (QHuKofBhFMjkiEtyhXKJsRYiRhoA.IsAllocated)
			{
				QHuKofBhFMjkiEtyhXKJsRYiRhoA.Free();
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	public static void mYXdNaYIlEpYEdwXrmCQZlkJhfc(vGJIEJxtBxddwvibNBDfOMIsSWt P_0, vGJIEJxtBxddwvibNBDfOMIsSWt P_1, int P_2)
	{
		Array.Copy(P_0.DBZCtHAzIvFuQOarCKsttoMaNgUG, P_1.DBZCtHAzIvFuQOarCKsttoMaNgUG, P_2);
	}

	public static void mYXdNaYIlEpYEdwXrmCQZlkJhfc(vGJIEJxtBxddwvibNBDfOMIsSWt P_0, int P_1, vGJIEJxtBxddwvibNBDfOMIsSWt P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.DBZCtHAzIvFuQOarCKsttoMaNgUG, P_1, P_2.DBZCtHAzIvFuQOarCKsttoMaNgUG, P_3, P_4);
	}
}
