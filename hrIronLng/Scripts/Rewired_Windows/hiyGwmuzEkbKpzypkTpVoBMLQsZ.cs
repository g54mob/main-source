using System;

internal struct hiyGwmuzEkbKpzypkTpVoBMLQsZ
{
	private uint yaCvtuEtQLRAFEeKpKbwXkYKXBN;

	private ulong zIsCOhjRpOMBMdRIzEmpRqUXWvlB;

	private static readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	public static readonly int iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	static hiyGwmuzEkbKpzypkTpVoBMLQsZ()
	{
		GupIFSTVSLnhDwDGCsKLmLgUDLU = IntPtr.Size == 8;
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = (GupIFSTVSLnhDwDGCsKLmLgUDLU ? 8 : 4);
	}

	public static hiyGwmuzEkbKpzypkTpVoBMLQsZ IFUvyfjjlmiTRXvpbkTSGARqaVO(byte[] P_0, int P_1)
	{
		hiyGwmuzEkbKpzypkTpVoBMLQsZ result = default(hiyGwmuzEkbKpzypkTpVoBMLQsZ);
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.yaCvtuEtQLRAFEeKpKbwXkYKXBN = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator uint(hiyGwmuzEkbKpzypkTpVoBMLQsZ obj)
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return (uint)obj.zIsCOhjRpOMBMdRIzEmpRqUXWvlB;
		}
		return obj.yaCvtuEtQLRAFEeKpKbwXkYKXBN;
	}

	public static implicit operator ulong(hiyGwmuzEkbKpzypkTpVoBMLQsZ obj)
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return obj.zIsCOhjRpOMBMdRIzEmpRqUXWvlB;
		}
		return obj.yaCvtuEtQLRAFEeKpKbwXkYKXBN;
	}

	public override string ToString()
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return zIsCOhjRpOMBMdRIzEmpRqUXWvlB.ToString();
		}
		return yaCvtuEtQLRAFEeKpKbwXkYKXBN.ToString();
	}
}
