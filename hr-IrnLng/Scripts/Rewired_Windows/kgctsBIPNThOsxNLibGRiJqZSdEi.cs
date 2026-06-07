using System;

internal struct kgctsBIPNThOsxNLibGRiJqZSdEi
{
	private int yaCvtuEtQLRAFEeKpKbwXkYKXBN;

	private long zIsCOhjRpOMBMdRIzEmpRqUXWvlB;

	private static readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	public static readonly int iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	static kgctsBIPNThOsxNLibGRiJqZSdEi()
	{
		GupIFSTVSLnhDwDGCsKLmLgUDLU = IntPtr.Size == 8;
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = (GupIFSTVSLnhDwDGCsKLmLgUDLU ? 8 : 4);
	}

	public static kgctsBIPNThOsxNLibGRiJqZSdEi IFUvyfjjlmiTRXvpbkTSGARqaVO(byte[] P_0, int P_1)
	{
		kgctsBIPNThOsxNLibGRiJqZSdEi result = default(kgctsBIPNThOsxNLibGRiJqZSdEi);
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.yaCvtuEtQLRAFEeKpKbwXkYKXBN = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator int(kgctsBIPNThOsxNLibGRiJqZSdEi obj)
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return (int)obj.zIsCOhjRpOMBMdRIzEmpRqUXWvlB;
		}
		return obj.yaCvtuEtQLRAFEeKpKbwXkYKXBN;
	}

	public static implicit operator long(kgctsBIPNThOsxNLibGRiJqZSdEi obj)
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
