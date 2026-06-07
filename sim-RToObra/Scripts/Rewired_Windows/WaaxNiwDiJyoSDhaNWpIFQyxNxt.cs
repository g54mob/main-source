using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct WaaxNiwDiJyoSDhaNWpIFQyxNxt
{
	[FieldOffset(0)]
	private uint lsJvTfkqFyisIbPwVCJtLGJLQLk;

	[FieldOffset(0)]
	private ulong ykjlEijFXbSqLcfiBSamguLGOuQ;

	[FieldOffset(0)]
	private IntPtr mnzRxGEYyoBpICxbkBJpqojoBGOF;

	private static readonly bool LYsVNLhRiifOKHqsgjYAquxHdMr;

	public static readonly int lqTmJvWoCjJVTvmDeCmOJTAiWOQ;

	static WaaxNiwDiJyoSDhaNWpIFQyxNxt()
	{
		lqTmJvWoCjJVTvmDeCmOJTAiWOQ = IntPtr.Size;
		LYsVNLhRiifOKHqsgjYAquxHdMr = lqTmJvWoCjJVTvmDeCmOJTAiWOQ == 8;
	}

	public static WaaxNiwDiJyoSDhaNWpIFQyxNxt HNLDkkXWZHkaKqwPVcaROpYlMtv(byte[] P_0, int P_1)
	{
		WaaxNiwDiJyoSDhaNWpIFQyxNxt result = default(WaaxNiwDiJyoSDhaNWpIFQyxNxt);
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			goto IL_000f;
		}
		goto IL_0039;
		IL_000f:
		int num = -1821231172;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ -1821231170)
			{
			case 5:
				break;
			case 1:
				goto IL_0039;
			case 3:
				num = -1821231170;
				continue;
			case 2:
				result.ykjlEijFXbSqLcfiBSamguLGOuQ = BitConverter.ToUInt64(P_0, P_1);
				result.mnzRxGEYyoBpICxbkBJpqojoBGOF = new IntPtr((long)result.ykjlEijFXbSqLcfiBSamguLGOuQ);
				num = -1821231171;
				continue;
			case 4:
				result.mnzRxGEYyoBpICxbkBJpqojoBGOF = new IntPtr((int)result.lsJvTfkqFyisIbPwVCJtLGJLQLk);
				num = -1821231170;
				continue;
			default:
				return result;
			}
			break;
		}
		goto IL_000f;
		IL_0039:
		result.lsJvTfkqFyisIbPwVCJtLGJLQLk = BitConverter.ToUInt32(P_0, P_1);
		num = -1821231174;
		goto IL_0014;
	}

	public static implicit operator IntPtr(WaaxNiwDiJyoSDhaNWpIFQyxNxt obj)
	{
		return obj.mnzRxGEYyoBpICxbkBJpqojoBGOF;
	}

	public static implicit operator WaaxNiwDiJyoSDhaNWpIFQyxNxt(IntPtr obj)
	{
		WaaxNiwDiJyoSDhaNWpIFQyxNxt result = new WaaxNiwDiJyoSDhaNWpIFQyxNxt
		{
			mnzRxGEYyoBpICxbkBJpqojoBGOF = obj
		};
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			result.ykjlEijFXbSqLcfiBSamguLGOuQ = (ulong)obj.ToInt64();
		}
		else
		{
			while (true)
			{
				result.lsJvTfkqFyisIbPwVCJtLGJLQLk = (uint)obj.ToInt32();
				int num = -543099552;
				while (true)
				{
					switch (num ^ -543099551)
					{
					case 0:
						num = -543099549;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0045;
					}
					break;
				}
				continue;
				end_IL_0045:
				break;
			}
		}
		return result;
	}

	public override string ToString()
	{
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			return ykjlEijFXbSqLcfiBSamguLGOuQ.ToString();
		}
		return lsJvTfkqFyisIbPwVCJtLGJLQLk.ToString();
	}

	public int ETSAnqPdvcDXsHYvrvYecKtFgRXh()
	{
		if (LYsVNLhRiifOKHqsgjYAquxHdMr)
		{
			return (int)ykjlEijFXbSqLcfiBSamguLGOuQ;
		}
		return (int)lsJvTfkqFyisIbPwVCJtLGJLQLk;
	}
}
