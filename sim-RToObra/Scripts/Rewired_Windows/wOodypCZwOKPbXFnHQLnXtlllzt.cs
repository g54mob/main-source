using System;

internal class wOodypCZwOKPbXFnHQLnXtlllzt : IDisposable
{
	private readonly WwcwFFXrcgizEHXRtCqRIUJLIniV RlrDFPWlIVBjihBXNSARRWgibHv;

	private bool[] rEkZmQLoNORghIvEGrbUkmKiZPF;

	protected readonly int VHkRGSxSryPetgiAnsrTmnuLAVb;

	protected readonly int iUHbgjNVCGChwQiUTfqPepfoqGj;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public int ValueBitSize
	{
		get
		{
			return VHkRGSxSryPetgiAnsrTmnuLAVb;
		}
	}

	public int Length
	{
		get
		{
			return iUHbgjNVCGChwQiUTfqPepfoqGj;
		}
	}

	public bool[] ValueWorkBuffer
	{
		get
		{
			return rEkZmQLoNORghIvEGrbUkmKiZPF ?? (rEkZmQLoNORghIvEGrbUkmKiZPF = new bool[VHkRGSxSryPetgiAnsrTmnuLAVb]);
		}
	}

	public wOodypCZwOKPbXFnHQLnXtlllzt(int length, int valueBitSize)
	{
		if (length <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (valueBitSize <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		iUHbgjNVCGChwQiUTfqPepfoqGj = length;
		VHkRGSxSryPetgiAnsrTmnuLAVb = valueBitSize;
		int num = length * valueBitSize;
		RlrDFPWlIVBjihBXNSARRWgibHv = new WwcwFFXrcgizEHXRtCqRIUJLIniV(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < VHkRGSxSryPetgiAnsrTmnuLAVb)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + VHkRGSxSryPetgiAnsrTmnuLAVb + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < VHkRGSxSryPetgiAnsrTmnuLAVb; i++)
		{
			int num3;
			byte b;
			fTZfkbBylquSBYsQTjLyBzkzzWt(P_0, i, out num3, out b);
			P_1[i] = (RlrDFPWlIVBjihBXNSARRWgibHv.AAVpkejpNwDagxlDTRPbJKQANwj(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, ptr, 64);
		P_1 = b;
	}

	public void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out sbyte P_1)
	{
		byte b;
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, out b);
		P_1 = (sbyte)b;
	}

	public unsafe void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, ptr, 64);
		P_1 = num;
	}

	public void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out ushort P_1)
	{
		short num;
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, out num);
		P_1 = (ushort)num;
	}

	public unsafe void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, ptr, 64);
		P_1 = num;
	}

	public void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out uint P_1)
	{
		int num;
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, out num);
		P_1 = (uint)num;
	}

	public unsafe void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, ptr, 64);
		P_1 = num;
	}

	public void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, out ulong P_1)
	{
		long num;
		RZzHcRCDHCQzGYDTQTQpNOCsVOE(P_0, out num);
		P_1 = (ulong)num;
	}

	public void RZzHcRCDHCQzGYDTQTQpNOCsVOE(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < VHkRGSxSryPetgiAnsrTmnuLAVb)
		{
			throw new Exception("valueBuffer.Length must be >= " + VHkRGSxSryPetgiAnsrTmnuLAVb);
		}
		for (int i = 0; i < VHkRGSxSryPetgiAnsrTmnuLAVb; i++)
		{
			int num;
			byte b;
			fTZfkbBylquSBYsQTjLyBzkzzWt(P_0, i, out num, out b);
			P_1[i] = RlrDFPWlIVBjihBXNSARRWgibHv.AAVpkejpNwDagxlDTRPbJKQANwj(num, b);
		}
	}

	public unsafe void pXrImHlfStExpVgddvwXomgjtDU(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < VHkRGSxSryPetgiAnsrTmnuLAVb; i++)
		{
			int num3;
			byte b;
			fTZfkbBylquSBYsQTjLyBzkzzWt(P_0, i, out num3, out b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			RlrDFPWlIVBjihBXNSARRWgibHv.ecXmScdJkFcorHpSAyqpVxGlfUlM(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void pXrImHlfStExpVgddvwXomgjtDU(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		pXrImHlfStExpVgddvwXomgjtDU(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void pXrImHlfStExpVgddvwXomgjtDU(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		pXrImHlfStExpVgddvwXomgjtDU(P_0, ptr, 8);
	}

	public void pXrImHlfStExpVgddvwXomgjtDU(int P_0, sbyte P_1)
	{
		pXrImHlfStExpVgddvwXomgjtDU(P_0, (byte)P_1);
	}

	public unsafe void pXrImHlfStExpVgddvwXomgjtDU(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		pXrImHlfStExpVgddvwXomgjtDU(P_0, ptr, 16);
	}

	public void pXrImHlfStExpVgddvwXomgjtDU(int P_0, ushort P_1)
	{
		pXrImHlfStExpVgddvwXomgjtDU(P_0, (short)P_1);
	}

	public unsafe void pXrImHlfStExpVgddvwXomgjtDU(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		pXrImHlfStExpVgddvwXomgjtDU(P_0, ptr, 32);
	}

	public void pXrImHlfStExpVgddvwXomgjtDU(int P_0, uint P_1)
	{
		pXrImHlfStExpVgddvwXomgjtDU(P_0, (int)P_1);
	}

	public unsafe void pXrImHlfStExpVgddvwXomgjtDU(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		pXrImHlfStExpVgddvwXomgjtDU(P_0, ptr, 64);
	}

	public void pXrImHlfStExpVgddvwXomgjtDU(int P_0, ulong P_1)
	{
		pXrImHlfStExpVgddvwXomgjtDU(P_0, (long)P_1);
	}

	public void pXrImHlfStExpVgddvwXomgjtDU(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < VHkRGSxSryPetgiAnsrTmnuLAVb)
		{
			throw new Exception("valueBuffer.Length must be >= " + VHkRGSxSryPetgiAnsrTmnuLAVb);
		}
		for (int i = 0; i < VHkRGSxSryPetgiAnsrTmnuLAVb; i++)
		{
			int num;
			byte b;
			fTZfkbBylquSBYsQTjLyBzkzzWt(P_0, i, out num, out b);
			RlrDFPWlIVBjihBXNSARRWgibHv.ecXmScdJkFcorHpSAyqpVxGlfUlM(num, b, P_1[i]);
		}
	}

	private void fTZfkbBylquSBYsQTjLyBzkzzWt(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= VHkRGSxSryPetgiAnsrTmnuLAVb)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * VHkRGSxSryPetgiAnsrTmnuLAVb + P_1;
		P_2 = num / VHkRGSxSryPetgiAnsrTmnuLAVb;
		P_3 = (byte)(num - P_2 * VHkRGSxSryPetgiAnsrTmnuLAVb);
	}

	private int hiiahHZoIRCZMxemrJhsNigKoaU(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= iUHbgjNVCGChwQiUTfqPepfoqGj * VHkRGSxSryPetgiAnsrTmnuLAVb)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / VHkRGSxSryPetgiAnsrTmnuLAVb;
		P_1 = (byte)(P_0 - num * VHkRGSxSryPetgiAnsrTmnuLAVb);
		return num;
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~wOodypCZwOKPbXFnHQLnXtlllzt()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			if (P_0 && RlrDFPWlIVBjihBXNSARRWgibHv != null)
			{
				RlrDFPWlIVBjihBXNSARRWgibHv.Dispose();
			}
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}
}
