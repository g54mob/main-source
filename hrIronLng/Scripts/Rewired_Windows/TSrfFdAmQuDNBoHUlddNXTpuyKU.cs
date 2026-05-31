using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct TSrfFdAmQuDNBoHUlddNXTpuyKU
{
	[FieldOffset(0)]
	private uint yaCvtuEtQLRAFEeKpKbwXkYKXBN;

	[FieldOffset(0)]
	private ulong zIsCOhjRpOMBMdRIzEmpRqUXWvlB;

	[FieldOffset(0)]
	private IntPtr liyFxFisQZBQNxxTQkRysusdIDxP;

	private static readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	public static readonly int iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	static TSrfFdAmQuDNBoHUlddNXTpuyKU()
	{
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = IntPtr.Size;
		GupIFSTVSLnhDwDGCsKLmLgUDLU = iiCeZsFqsCMgMBWpCvqNRTNxrPf == 8;
	}

	public static TSrfFdAmQuDNBoHUlddNXTpuyKU IFUvyfjjlmiTRXvpbkTSGARqaVO(byte[] P_0, int P_1)
	{
		TSrfFdAmQuDNBoHUlddNXTpuyKU result = default(TSrfFdAmQuDNBoHUlddNXTpuyKU);
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB = BitConverter.ToUInt64(P_0, P_1);
			result.liyFxFisQZBQNxxTQkRysusdIDxP = new IntPtr((long)result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB);
		}
		else
		{
			result.yaCvtuEtQLRAFEeKpKbwXkYKXBN = BitConverter.ToUInt32(P_0, P_1);
			result.liyFxFisQZBQNxxTQkRysusdIDxP = new IntPtr((int)result.yaCvtuEtQLRAFEeKpKbwXkYKXBN);
		}
		return result;
	}

	public static implicit operator IntPtr(TSrfFdAmQuDNBoHUlddNXTpuyKU obj)
	{
		return obj.liyFxFisQZBQNxxTQkRysusdIDxP;
	}

	public static implicit operator TSrfFdAmQuDNBoHUlddNXTpuyKU(IntPtr obj)
	{
		TSrfFdAmQuDNBoHUlddNXTpuyKU result = new TSrfFdAmQuDNBoHUlddNXTpuyKU
		{
			liyFxFisQZBQNxxTQkRysusdIDxP = obj
		};
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB = (ulong)obj.ToInt64();
		}
		else
		{
			result.yaCvtuEtQLRAFEeKpKbwXkYKXBN = (uint)obj.ToInt32();
		}
		return result;
	}

	public override string ToString()
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return zIsCOhjRpOMBMdRIzEmpRqUXWvlB.ToString();
		}
		return yaCvtuEtQLRAFEeKpKbwXkYKXBN.ToString();
	}

	public int VzFdrrrBHTiSjrJDNAldwssKOYa()
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return (int)zIsCOhjRpOMBMdRIzEmpRqUXWvlB;
		}
		return (int)yaCvtuEtQLRAFEeKpKbwXkYKXBN;
	}
}
