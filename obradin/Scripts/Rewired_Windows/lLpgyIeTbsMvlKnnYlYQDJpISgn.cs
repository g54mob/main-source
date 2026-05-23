using System;

internal struct lLpgyIeTbsMvlKnnYlYQDJpISgn
{
	private int lsJvTfkqFyisIbPwVCJtLGJLQLk;

	private long ykjlEijFXbSqLcfiBSamguLGOuQ;

	private static readonly bool LYsVNLhRiifOKHqsgjYAquxHdMr;

	public static readonly int lqTmJvWoCjJVTvmDeCmOJTAiWOQ;

	static lLpgyIeTbsMvlKnnYlYQDJpISgn()
	{
		LYsVNLhRiifOKHqsgjYAquxHdMr = IntPtr.Size == 8;
		lqTmJvWoCjJVTvmDeCmOJTAiWOQ = (LYsVNLhRiifOKHqsgjYAquxHdMr ? 8 : 4);
	}

	public static lLpgyIeTbsMvlKnnYlYQDJpISgn HNLDkkXWZHkaKqwPVcaROpYlMtv(byte[] P_0, int P_1)
	{
		lLpgyIeTbsMvlKnnYlYQDJpISgn result = default(lLpgyIeTbsMvlKnnYlYQDJpISgn);
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			result.ykjlEijFXbSqLcfiBSamguLGOuQ = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.lsJvTfkqFyisIbPwVCJtLGJLQLk = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator int(lLpgyIeTbsMvlKnnYlYQDJpISgn obj)
	{
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			return (int)obj.ykjlEijFXbSqLcfiBSamguLGOuQ;
		}
		return obj.lsJvTfkqFyisIbPwVCJtLGJLQLk;
	}

	public static implicit operator long(lLpgyIeTbsMvlKnnYlYQDJpISgn obj)
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
