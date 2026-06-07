using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct hcPVReJyQiArmIHbOVqOGewAPSMF
{
	[FieldOffset(0)]
	private int IYoitPrufeDSLhVoGnmhfhtGawTr;

	[FieldOffset(0)]
	private long KceUfIQFiWpCmoCWTeuXEnhcczTAA;

	[FieldOffset(0)]
	private IntPtr jtsRzbdTBkUDRJYbcvLUyrybkKCT;

	private static readonly bool wRGclUjNqXAiPDhMAdGWWBVeQFWL;

	public static readonly int ymhBAEaPjmNhyGVrYXEalKTogmXeA;

	static hcPVReJyQiArmIHbOVqOGewAPSMF()
	{
		ymhBAEaPjmNhyGVrYXEalKTogmXeA = IntPtr.Size;
		wRGclUjNqXAiPDhMAdGWWBVeQFWL = ymhBAEaPjmNhyGVrYXEalKTogmXeA == 8;
	}

	public static hcPVReJyQiArmIHbOVqOGewAPSMF FKAjBPJoaIKMTxDdJfTzVdirMwAV(byte[] P_0, int P_1)
	{
		hcPVReJyQiArmIHbOVqOGewAPSMF result = default(hcPVReJyQiArmIHbOVqOGewAPSMF);
		if (wRGclUjNqXAiPDhMAdGWWBVeQFWL)
		{
			result.KceUfIQFiWpCmoCWTeuXEnhcczTAA = BitConverter.ToInt64(P_0, P_1);
			result.jtsRzbdTBkUDRJYbcvLUyrybkKCT = new IntPtr(result.KceUfIQFiWpCmoCWTeuXEnhcczTAA);
		}
		else
		{
			result.IYoitPrufeDSLhVoGnmhfhtGawTr = BitConverter.ToInt32(P_0, P_1);
			result.jtsRzbdTBkUDRJYbcvLUyrybkKCT = new IntPtr(result.IYoitPrufeDSLhVoGnmhfhtGawTr);
		}
		return result;
	}

	[SpecialName]
	public static hcPVReJyQiArmIHbOVqOGewAPSMF DNLblbiRZbcAUdOYIybyelqXmcnXB(IntPtr P_0)
	{
		hcPVReJyQiArmIHbOVqOGewAPSMF result = new hcPVReJyQiArmIHbOVqOGewAPSMF
		{
			jtsRzbdTBkUDRJYbcvLUyrybkKCT = P_0
		};
		if (wRGclUjNqXAiPDhMAdGWWBVeQFWL)
		{
			result.KceUfIQFiWpCmoCWTeuXEnhcczTAA = P_0.ToInt64();
		}
		else
		{
			result.IYoitPrufeDSLhVoGnmhfhtGawTr = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr eaeNsXREAABrOFAtpPSWJrzJcLFe(hcPVReJyQiArmIHbOVqOGewAPSMF P_0)
	{
		return P_0.jtsRzbdTBkUDRJYbcvLUyrybkKCT;
	}

	public string zVhcVKElTxyDmkHioRkAGQgUAmWEb()
	{
		if (wRGclUjNqXAiPDhMAdGWWBVeQFWL)
		{
			return KceUfIQFiWpCmoCWTeuXEnhcczTAA.ToString();
		}
		return IYoitPrufeDSLhVoGnmhfhtGawTr.ToString();
	}
}
