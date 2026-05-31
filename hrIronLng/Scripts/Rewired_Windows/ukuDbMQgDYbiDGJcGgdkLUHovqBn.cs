using System;

internal struct ukuDbMQgDYbiDGJcGgdkLUHovqBn
{
	private uint yaCvtuEtQLRAFEeKpKbwXkYKXBN;

	private ulong zIsCOhjRpOMBMdRIzEmpRqUXWvlB;

	private static readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	public static readonly int iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	static ukuDbMQgDYbiDGJcGgdkLUHovqBn()
	{
		GupIFSTVSLnhDwDGCsKLmLgUDLU = IntPtr.Size == 8;
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = (GupIFSTVSLnhDwDGCsKLmLgUDLU ? 8 : 4);
	}

	public static ukuDbMQgDYbiDGJcGgdkLUHovqBn IFUvyfjjlmiTRXvpbkTSGARqaVO(byte[] P_0, int P_1)
	{
		ukuDbMQgDYbiDGJcGgdkLUHovqBn result = default(ukuDbMQgDYbiDGJcGgdkLUHovqBn);
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

	public static implicit operator uint(ukuDbMQgDYbiDGJcGgdkLUHovqBn obj)
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return (uint)obj.zIsCOhjRpOMBMdRIzEmpRqUXWvlB;
		}
		return obj.yaCvtuEtQLRAFEeKpKbwXkYKXBN;
	}

	public static implicit operator ulong(ukuDbMQgDYbiDGJcGgdkLUHovqBn obj)
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
