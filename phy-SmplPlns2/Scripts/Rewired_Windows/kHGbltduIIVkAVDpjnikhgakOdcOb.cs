using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct kHGbltduIIVkAVDpjnikhgakOdcOb : IDisposable
{
	private unsafe byte* ZTUIxGkXNdKyunoBJqRatSscvrft;

	private int TMhKuUFJKxDdOUaYhszHeuhNjqxf;

	private bool CrbdJyXxnSLEWcdsLWFRkwolEIQG;

	public unsafe byte* kzVrLhGiXGrpzpVgKEgRcokxNMnt => ZTUIxGkXNdKyunoBJqRatSscvrft;

	public unsafe IntPtr twrQBBdfxzjOqhBgtFlriFTgqGoEb => (IntPtr)ZTUIxGkXNdKyunoBJqRatSscvrft;

	public int NyhmBcXNHUxiDFMBMZbMYnsMACpV => TMhKuUFJKxDdOUaYhszHeuhNjqxf;

	public unsafe byte oZrWTATKHpAPEigHfMHyCWksiOku
	{
		get
		{
			if (P_0 < 0 || P_0 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
			{
				throw new IndexOutOfRangeException();
			}
			return ZTUIxGkXNdKyunoBJqRatSscvrft[P_0];
		}
		set
		{
			if (num < 0 || num >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
			{
				throw new IndexOutOfRangeException();
			}
			ZTUIxGkXNdKyunoBJqRatSscvrft[num] = b;
		}
	}

	public unsafe kHGbltduIIVkAVDpjnikhgakOdcOb(int P_0)
	{
		ZTUIxGkXNdKyunoBJqRatSscvrft = null;
		TMhKuUFJKxDdOUaYhszHeuhNjqxf = 0;
		CrbdJyXxnSLEWcdsLWFRkwolEIQG = false;
		AhvNkkxLPFZfDLSLgbvMYcnVJURU(P_0);
	}

	public unsafe IntPtr SJoJoNHmFMaUxlCKwIRBrEXCLBnb(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)ZTUIxGkXNdKyunoBJqRatSscvrft;
		}
		if (P_0 < 0 || P_0 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe string NrlSOumGOEDbJGJaSFDsGNtvSNjgb()
	{
		string text = "";
		for (int i = 0; i < TMhKuUFJKxDdOUaYhszHeuhNjqxf; i++)
		{
			text = text + ZTUIxGkXNdKyunoBJqRatSscvrft[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool UBpZAmjQYPkNztyBiGYiNIMZszZi(int P_0, byte P_1)
	{
		if (1 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (ZTUIxGkXNdKyunoBJqRatSscvrft[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte wFFVjgXLWRFZEAgjFxzLIrWoUvRD(int P_0)
	{
		if (1 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return ZTUIxGkXNdKyunoBJqRatSscvrft[P_0];
	}

	public unsafe short FYBCtIaHJtdcmDZdkxqNPuThhQZn(int P_0)
	{
		if (2 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe ushort kDYIDjegEQcqWGrfFGMLXeXYMyIH(int P_0)
	{
		if (2 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe int LaVSBpqYKpnKgQYdHCGLmIUYqrCw(int P_0)
	{
		if (4 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe uint ukdegDeqBBOJWUHYCdnEDJCcqjVjb(int P_0)
	{
		if (4 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe long cpHhODeTUclcRTBeiNYXKQVMOZkT(int P_0)
	{
		if (8 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe ulong VqBPsnDUJXUZGWBioFOBxQWSsUrj(int P_0)
	{
		if (8 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_0);
	}

	public unsafe void CRcARGMgmZopTjesJRBltueVyApD(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_2 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_1 + P_2 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)ZTUIxGkXNdKyunoBJqRatSscvrft, P_0, P_2, P_3, P_1);
	}

	public unsafe void zkrDyHAvMsgGBsUAJMXbrwXpNBBr(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_3 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_2 + P_3 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(ZTUIxGkXNdKyunoBJqRatSscvrft, P_0, P_3, P_4, P_2);
	}

	public unsafe void JiVBgQJHNzBnjKWWeBYeDVIiMozp(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		zkrDyHAvMsgGBsUAJMXbrwXpNBBr((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int zpkbNhgkTEVzlCTGTBCorvaNMwtk(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_2 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			P_1 = TMhKuUFJKxDdOUaYhszHeuhNjqxf - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)ZTUIxGkXNdKyunoBJqRatSscvrft, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int JtLRDIVDvxKNmajSQmTOJnrQRFeq(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_3 + P_2 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			P_2 = TMhKuUFJKxDdOUaYhszHeuhNjqxf - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(ZTUIxGkXNdKyunoBJqRatSscvrft, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int EINbkDPOdXXkUXzbJNXigdbqYgcM(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return JtLRDIVDvxKNmajSQmTOJnrQRFeq((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void TmYVGMzqEWHCtEmhGgEndgAgUdSsA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = ZTUIxGkXNdKyunoBJqRatSscvrft + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = ZTUIxGkXNdKyunoBJqRatSscvrft + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void oiPMYrdrVMrwqciEOYABRgDbAFub(byte P_0, int P_1)
	{
		if (1 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		ZTUIxGkXNdKyunoBJqRatSscvrft[P_1] = P_0;
	}

	public unsafe void aJnsrSYCkOxEQhILTTDKFRKFwMaA(short P_0, int P_1)
	{
		if (2 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_1) = P_0;
	}

	public unsafe void fvSJuwGQnDXPFQeiTBnGxlBRdIMq(ushort P_0, int P_1)
	{
		if (2 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_1) = P_0;
	}

	public unsafe void HdjTzVEGYHhGjopGZoIKnygunQUr(int P_0, int P_1)
	{
		if (4 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_1) = P_0;
	}

	public unsafe void ltUquOMDxSasvgmELdQbnBQvHRKEb(uint P_0, int P_1)
	{
		if (4 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_1) = P_0;
	}

	public unsafe void izwNYBHZPvYvtQFkfEHRLNEGGQAz(long P_0, int P_1)
	{
		if (8 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_1) = P_0;
	}

	public unsafe void rILIEKfeztatfGyfmVrtRtIzsGnAA(ulong P_0, int P_1)
	{
		if (8 + P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(ZTUIxGkXNdKyunoBJqRatSscvrft + P_1) = P_0;
	}

	public unsafe void ylQnZohPAuDySPuJpFuFAPOyOWrJ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_2 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_1 + P_2 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)ZTUIxGkXNdKyunoBJqRatSscvrft, P_3, P_2, P_1);
	}

	public unsafe void powPnAKmSypPeJAUpgBFlGPTNNDw(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_3 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_2 + P_3 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(P_0, ZTUIxGkXNdKyunoBJqRatSscvrft, P_4, P_3, P_2);
	}

	public unsafe void XODHVqkKbbaGjDpTUKvAgFOwGHIk(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		powPnAKmSypPeJAUpgBFlGPTNNDw((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int vPzMBwcLqIcsyNtuUNbSxpGuobeW(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_1 + P_2 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			P_1 = TMhKuUFJKxDdOUaYhszHeuhNjqxf - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)ZTUIxGkXNdKyunoBJqRatSscvrft, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int gBxaPMDLcqnMWhxeBIltdyiHaCrBA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= TMhKuUFJKxDdOUaYhszHeuhNjqxf)
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
		if (P_2 + P_3 > TMhKuUFJKxDdOUaYhszHeuhNjqxf)
		{
			P_2 = TMhKuUFJKxDdOUaYhszHeuhNjqxf - P_3;
		}
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(P_0, ZTUIxGkXNdKyunoBJqRatSscvrft, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int iQzQUltHlaEiulTJmgbjWYLPTaRG(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return gBxaPMDLcqnMWhxeBIltdyiHaCrBA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool AhvNkkxLPFZfDLSLgbvMYcnVJURU(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (TMhKuUFJKxDdOUaYhszHeuhNjqxf == P_0)
		{
			return true;
		}
		rcJwFlFJlOdCHoPngsYBLVtvCjzF();
		if (P_0 == 0)
		{
			return true;
		}
		TMhKuUFJKxDdOUaYhszHeuhNjqxf = P_0;
		ZTUIxGkXNdKyunoBJqRatSscvrft = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		HkubsIAhhLUinUFEUFWJFzBTyPFH();
		return true;
	}

	public unsafe void HkubsIAhhLUinUFEUFWJFzBTyPFH()
	{
		if (TMhKuUFJKxDdOUaYhszHeuhNjqxf != 0)
		{
			TbAntJIfSSmAyfyyGIMdtrdGaNBT.oZggRQgOfULUnGHOdGGtmCQIzwaVe(ZTUIxGkXNdKyunoBJqRatSscvrft, TMhKuUFJKxDdOUaYhszHeuhNjqxf);
		}
	}

	public unsafe void rcJwFlFJlOdCHoPngsYBLVtvCjzF()
	{
		if (TMhKuUFJKxDdOUaYhszHeuhNjqxf == 0)
		{
			return;
		}
		try
		{
			if (ZTUIxGkXNdKyunoBJqRatSscvrft != null)
			{
				Marshal.FreeHGlobal(twrQBBdfxzjOqhBgtFlriFTgqGoEb);
			}
		}
		catch
		{
		}
		ZTUIxGkXNdKyunoBJqRatSscvrft = null;
		TMhKuUFJKxDdOUaYhszHeuhNjqxf = 0;
	}

	public string FFUYQbJgdIELSklWNDvBPEbesFClA()
	{
		string text = "";
		for (int i = 0; i < TMhKuUFJKxDdOUaYhszHeuhNjqxf; i++)
		{
			text = text + wFFVjgXLWRFZEAgjFxzLIrWoUvRD(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		ImLMuaZHTLApdekZXLeIyPQZVbXJA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void ImLMuaZHTLApdekZXLeIyPQZVbXJA(bool P_0)
	{
		if (!CrbdJyXxnSLEWcdsLWFRkwolEIQG)
		{
			rcJwFlFJlOdCHoPngsYBLVtvCjzF();
			CrbdJyXxnSLEWcdsLWFRkwolEIQG = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr UvMfiyEROpxChFtQDSsAoOMLFBmEb(kHGbltduIIVkAVDpjnikhgakOdcOb P_0)
	{
		return (IntPtr)P_0.ZTUIxGkXNdKyunoBJqRatSscvrft;
	}

	[SpecialName]
	public unsafe static void* UvMfiyEROpxChFtQDSsAoOMLFBmEb(kHGbltduIIVkAVDpjnikhgakOdcOb P_0)
	{
		return P_0.ZTUIxGkXNdKyunoBJqRatSscvrft;
	}

	public unsafe static bool ftCUDVYTXFPoEIRNEsfsYoUQBzFB(kHGbltduIIVkAVDpjnikhgakOdcOb P_0, kHGbltduIIVkAVDpjnikhgakOdcOb P_1)
	{
		if (P_0.TMhKuUFJKxDdOUaYhszHeuhNjqxf == 0)
		{
			P_1.rcJwFlFJlOdCHoPngsYBLVtvCjzF();
			return true;
		}
		if (P_1.AhvNkkxLPFZfDLSLgbvMYcnVJURU(P_0.TMhKuUFJKxDdOUaYhszHeuhNjqxf))
		{
			P_1.powPnAKmSypPeJAUpgBFlGPTNNDw(P_0.ZTUIxGkXNdKyunoBJqRatSscvrft, P_0.TMhKuUFJKxDdOUaYhszHeuhNjqxf, P_0.TMhKuUFJKxDdOUaYhszHeuhNjqxf);
			return true;
		}
		return false;
	}
}
