using System;

internal struct bowJCqyiWhSmDnVoNMlNDlbAKkl
{
	private int yaCvtuEtQLRAFEeKpKbwXkYKXBN;

	private long zIsCOhjRpOMBMdRIzEmpRqUXWvlB;

	private static readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	public static readonly int iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	static bowJCqyiWhSmDnVoNMlNDlbAKkl()
	{
		GupIFSTVSLnhDwDGCsKLmLgUDLU = IntPtr.Size == 8;
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = (GupIFSTVSLnhDwDGCsKLmLgUDLU ? 8 : 4);
	}

	public static bowJCqyiWhSmDnVoNMlNDlbAKkl IFUvyfjjlmiTRXvpbkTSGARqaVO(byte[] P_0, int P_1)
	{
		bowJCqyiWhSmDnVoNMlNDlbAKkl result = default(bowJCqyiWhSmDnVoNMlNDlbAKkl);
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

	public static implicit operator int(bowJCqyiWhSmDnVoNMlNDlbAKkl obj)
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return (int)obj.zIsCOhjRpOMBMdRIzEmpRqUXWvlB;
		}
		return obj.yaCvtuEtQLRAFEeKpKbwXkYKXBN;
	}

	public static implicit operator long(bowJCqyiWhSmDnVoNMlNDlbAKkl obj)
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
