using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class OFmcyCosFIeFqByXUQtHtcpErUbLA : IDisposable
{
	private readonly byte[] gbENwNzXjuYlzBDzrFEjZzCuvPJT;

	public readonly int umSUfFObJDVqmQNdVClhvdGYZaQM;

	private GCHandle ieqrKjjnRrgPWgfMPPfIXOfScvCyA;

	private bool jgiHAhraRPrpBTOWDXoQVpgaqUWq;

	public bool pnTCLdyicOlLcVEqfgXJyPSNLtij => ieqrKjjnRrgPWgfMPPfIXOfScvCyA.IsAllocated;

	public byte udPOzvKwEjRvaqDBBpBFGopEbVleA
	{
		get
		{
			return gbENwNzXjuYlzBDzrFEjZzCuvPJT[P_0];
		}
		set
		{
			gbENwNzXjuYlzBDzrFEjZzCuvPJT[num] = b;
		}
	}

	public OFmcyCosFIeFqByXUQtHtcpErUbLA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		umSUfFObJDVqmQNdVClhvdGYZaQM = P_0;
		gbENwNzXjuYlzBDzrFEjZzCuvPJT = new byte[P_0];
	}

	public IntPtr yqmHTceBJsZsaSyaUuuIsrjrBUvo()
	{
		if (ieqrKjjnRrgPWgfMPPfIXOfScvCyA.IsAllocated)
		{
			return ieqrKjjnRrgPWgfMPPfIXOfScvCyA.AddrOfPinnedObject();
		}
		ieqrKjjnRrgPWgfMPPfIXOfScvCyA = GCHandle.Alloc(gbENwNzXjuYlzBDzrFEjZzCuvPJT, GCHandleType.Pinned);
		return ieqrKjjnRrgPWgfMPPfIXOfScvCyA.AddrOfPinnedObject();
	}

	public void SRBDPaYBpmcTOeSIrFdCTfEiIvedb()
	{
		if (ieqrKjjnRrgPWgfMPPfIXOfScvCyA.IsAllocated)
		{
			ieqrKjjnRrgPWgfMPPfIXOfScvCyA.Free();
		}
	}

	public string vcafATHcIFGiqtunxLDKTgAhGlbMA()
	{
		string text = "";
		for (int i = 0; i < umSUfFObJDVqmQNdVClhvdGYZaQM; i++)
		{
			text = text + gbENwNzXjuYlzBDzrFEjZzCuvPJT[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool pvtIpxbGUgCegCJvKgeSdJPDSxZgc(int P_0, byte P_1)
	{
		if (1 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (gbENwNzXjuYlzBDzrFEjZzCuvPJT[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte qoBxDXtIPWMekaNzJBHpwsquUIMu(int P_0)
	{
		if (1 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return gbENwNzXjuYlzBDzrFEjZzCuvPJT[P_0];
	}

	public unsafe short wzDTOILJiKKjrmCHldrRVQOicoQO(int P_0)
	{
		if (2 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort PegEXmBpFhaGRFnsJKcoIMhBoiFVb(int P_0)
	{
		if (2 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int cJXdZDaQUVLlgVUppicJxkTFuVXx(int P_0)
	{
		if (4 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint wQcNyClQjqYWZvGMBVSrwmRZwlKJ(int P_0)
	{
		if (4 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long skhUqsqNMzMhkFvQjNKiPLdQFQdhA(int P_0)
	{
		if (8 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong dtIfLneJspavFIrvRmtfmBSwYcbC(int P_0)
	{
		if (8 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void gnVOXJbcksnXPHaqQEvyoFIpXtzQ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_2 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_1 + P_2 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_2, P_0, P_3, P_1);
	}

	public void DzzQfbvCPafRseWCbHiXqEROkode(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_3 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_2 + P_3 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_0, P_3, P_4, P_2);
	}

	public int JxuIgPkJeWLBFfURZbqhIJTUXMHw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_2 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			P_1 = umSUfFObJDVqmQNdVClhvdGYZaQM - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int ggllBLWLtxueDYpRiLHzgyGtrZlr(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_3 + P_2 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			P_2 = umSUfFObJDVqmQNdVClhvdGYZaQM - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void HYutsDYgmQAfWmsphYmxsMUNoQaL(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			gbENwNzXjuYlzBDzrFEjZzCuvPJT[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			gbENwNzXjuYlzBDzrFEjZzCuvPJT[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void fnpZcfzYojwkgIcWblUZuOCrykJN(byte P_0, int P_1)
	{
		if (1 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		gbENwNzXjuYlzBDzrFEjZzCuvPJT[P_1] = P_0;
	}

	public unsafe void yplcJXrwRvGMljDVSOFpXlxXKjQaA(short P_0, int P_1)
	{
		if (2 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void cirpjVJVanGAXRoJGZDNSVNoOizp(ushort P_0, int P_1)
	{
		if (2 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void OExBSlGlXiUoASfRFjpshZblqubjA(int P_0, int P_1)
	{
		if (4 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void VJAJFzVEXOGWYArniIPQzZcuYeOD(uint P_0, int P_1)
	{
		if (4 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void xZCUKABIzZpeEtSAwfVnafMHgSIy(long P_0, int P_1)
	{
		if (8 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void SownpcNQEiKnzrqNCzCtfpfxpOEU(ulong P_0, int P_1)
	{
		if (8 + P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = gbENwNzXjuYlzBDzrFEjZzCuvPJT)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void FxswnJDFwKpsYdzqKQCamFkEisxiA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_2 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_1 + P_2 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_2, P_1);
	}

	public void NWTDKcSXzTyiKdNuLUiuKZrOaduK(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_3 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_2 + P_3 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_4, P_3, P_2);
	}

	public int hUlTaiYaAdmMaSqIofcfPDaxGwzH(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_1 + P_2 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			P_1 = umSUfFObJDVqmQNdVClhvdGYZaQM - P_2;
		}
		Array.Copy(P_0, P_3, gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_2, P_1);
		return P_1;
	}

	public int RVYoeuiHvSOKWWUqggYfKYebaypC(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= umSUfFObJDVqmQNdVClhvdGYZaQM)
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
		if (P_2 + P_3 > umSUfFObJDVqmQNdVClhvdGYZaQM)
		{
			P_2 = umSUfFObJDVqmQNdVClhvdGYZaQM - P_3;
		}
		NativeTools.CopyMemory(P_0, gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_4, P_3, P_2);
		return P_2;
	}

	public void GNTcmcpukkCIveBpvEHveuHrWmad()
	{
		Array.Clear(gbENwNzXjuYlzBDzrFEjZzCuvPJT, 0, umSUfFObJDVqmQNdVClhvdGYZaQM);
	}

	public virtual string nYEjThhdPULXeJRiZwyHbPUmjrkI()
	{
		string text = "";
		for (int i = 0; i < umSUfFObJDVqmQNdVClhvdGYZaQM; i++)
		{
			text = text + this.ZXptJwTZqLyBLLAYUKEsSzAYNXlj(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		YhSqncogcHQPGvCumDHATXcxiKxcA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void cNuEVfdcSryUOMKdqAZIHZbBquWNA()
	{
		try
		{
			YhSqncogcHQPGvCumDHATXcxiKxcA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void YhSqncogcHQPGvCumDHATXcxiKxcA(bool P_0)
	{
		if (!jgiHAhraRPrpBTOWDXoQVpgaqUWq)
		{
			if (ieqrKjjnRrgPWgfMPPfIXOfScvCyA.IsAllocated)
			{
				ieqrKjjnRrgPWgfMPPfIXOfScvCyA.Free();
			}
			jgiHAhraRPrpBTOWDXoQVpgaqUWq = true;
		}
	}

	public static void eHnkOIQpdcxzSANVovDWdCoFiRTx(OFmcyCosFIeFqByXUQtHtcpErUbLA P_0, OFmcyCosFIeFqByXUQtHtcpErUbLA P_1, int P_2)
	{
		Array.Copy(P_0.gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_1.gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_2);
	}

	public static void UbFhaDBJrAvHWKIwpEUBIszMrlhLA(OFmcyCosFIeFqByXUQtHtcpErUbLA P_0, int P_1, OFmcyCosFIeFqByXUQtHtcpErUbLA P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_1, P_2.gbENwNzXjuYlzBDzrFEjZzCuvPJT, P_3, P_4);
	}
}
