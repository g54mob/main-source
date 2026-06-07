using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct jLFEcVyWEgJATAvbnSKLbjtayCE
{
	[FieldOffset(0)]
	private int lsJvTfkqFyisIbPwVCJtLGJLQLk;

	[FieldOffset(0)]
	private long ykjlEijFXbSqLcfiBSamguLGOuQ;

	[FieldOffset(0)]
	private IntPtr mnzRxGEYyoBpICxbkBJpqojoBGOF;

	private static readonly bool LYsVNLhRiifOKHqsgjYAquxHdMr;

	public static readonly int lqTmJvWoCjJVTvmDeCmOJTAiWOQ;

	static jLFEcVyWEgJATAvbnSKLbjtayCE()
	{
		lqTmJvWoCjJVTvmDeCmOJTAiWOQ = IntPtr.Size;
		LYsVNLhRiifOKHqsgjYAquxHdMr = lqTmJvWoCjJVTvmDeCmOJTAiWOQ == 8;
	}

	public static jLFEcVyWEgJATAvbnSKLbjtayCE HNLDkkXWZHkaKqwPVcaROpYlMtv(byte[] P_0, int P_1)
	{
		jLFEcVyWEgJATAvbnSKLbjtayCE result = default(jLFEcVyWEgJATAvbnSKLbjtayCE);
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			goto IL_000f;
		}
		goto IL_0082;
		IL_000f:
		int num = -1523948828;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ -1523948827)
			{
			case 3:
				break;
			case 2:
				result.mnzRxGEYyoBpICxbkBJpqojoBGOF = new IntPtr(result.lsJvTfkqFyisIbPwVCJtLGJLQLk);
				num = -1523948827;
				continue;
			case 4:
				result.mnzRxGEYyoBpICxbkBJpqojoBGOF = new IntPtr(result.ykjlEijFXbSqLcfiBSamguLGOuQ);
				num = -1523948827;
				continue;
			case 1:
				result.ykjlEijFXbSqLcfiBSamguLGOuQ = BitConverter.ToInt64(P_0, P_1);
				num = -1523948831;
				continue;
			case 5:
				goto IL_0082;
			default:
				return result;
			}
			break;
		}
		goto IL_000f;
		IL_0082:
		result.lsJvTfkqFyisIbPwVCJtLGJLQLk = BitConverter.ToInt32(P_0, P_1);
		num = -1523948825;
		goto IL_0014;
	}

	public static implicit operator jLFEcVyWEgJATAvbnSKLbjtayCE(IntPtr obj)
	{
		jLFEcVyWEgJATAvbnSKLbjtayCE result = default(jLFEcVyWEgJATAvbnSKLbjtayCE);
		while (true)
		{
			int num = -769509278;
			while (true)
			{
				switch (num ^ -769509276)
				{
				case 4:
					break;
				case 6:
					result.mnzRxGEYyoBpICxbkBJpqojoBGOF = obj;
					num = -769509273;
					continue;
				case 3:
				{
					int num2;
					if (!LYsVNLhRiifOKHqsgjYAquxHdMr)
					{
						num = -769509275;
						num2 = num;
					}
					else
					{
						num = -769509276;
						num2 = num;
					}
					continue;
				}
				case 1:
					result.lsJvTfkqFyisIbPwVCJtLGJLQLk = obj.ToInt32();
					num = -769509279;
					continue;
				case 2:
					num = -769509279;
					continue;
				case 0:
					result.ykjlEijFXbSqLcfiBSamguLGOuQ = obj.ToInt64();
					num = -769509274;
					continue;
				default:
					return result;
				}
				break;
			}
		}
	}

	public static implicit operator IntPtr(jLFEcVyWEgJATAvbnSKLbjtayCE obj)
	{
		return obj.mnzRxGEYyoBpICxbkBJpqojoBGOF;
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
