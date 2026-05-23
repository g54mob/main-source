using System;

internal struct wJrSyvYdkPHxsGGDKDdQQmHQnped
{
	private uint lsJvTfkqFyisIbPwVCJtLGJLQLk;

	private ulong ykjlEijFXbSqLcfiBSamguLGOuQ;

	private static readonly bool LYsVNLhRiifOKHqsgjYAquxHdMr;

	public static readonly int lqTmJvWoCjJVTvmDeCmOJTAiWOQ;

	static wJrSyvYdkPHxsGGDKDdQQmHQnped()
	{
		LYsVNLhRiifOKHqsgjYAquxHdMr = IntPtr.Size == 8;
		lqTmJvWoCjJVTvmDeCmOJTAiWOQ = (LYsVNLhRiifOKHqsgjYAquxHdMr ? 8 : 4);
	}

	public static wJrSyvYdkPHxsGGDKDdQQmHQnped HNLDkkXWZHkaKqwPVcaROpYlMtv(byte[] P_0, int P_1)
	{
		wJrSyvYdkPHxsGGDKDdQQmHQnped result = default(wJrSyvYdkPHxsGGDKDdQQmHQnped);
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			result.ykjlEijFXbSqLcfiBSamguLGOuQ = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.lsJvTfkqFyisIbPwVCJtLGJLQLk = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator uint(wJrSyvYdkPHxsGGDKDdQQmHQnped obj)
	{
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			return (uint)obj.ykjlEijFXbSqLcfiBSamguLGOuQ;
		}
		return obj.lsJvTfkqFyisIbPwVCJtLGJLQLk;
	}

	public static implicit operator ulong(wJrSyvYdkPHxsGGDKDdQQmHQnped obj)
	{
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			return obj.ykjlEijFXbSqLcfiBSamguLGOuQ;
		}
		return obj.lsJvTfkqFyisIbPwVCJtLGJLQLk;
	}

	public override string ToString()
	{
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			return ykjlEijFXbSqLcfiBSamguLGOuQ.ToString();
		}
		return lsJvTfkqFyisIbPwVCJtLGJLQLk.ToString();
	}
}
