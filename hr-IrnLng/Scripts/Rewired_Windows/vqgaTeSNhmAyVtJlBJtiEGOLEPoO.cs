using System.Collections.Generic;
using Rewired.Utils;

internal class vqgaTeSNhmAyVtJlBJtiEGOLEPoO : opovrWrkmvbvBEFbrSmBIkHOqTyF
{
	private List<xeDXAkGcMzNhIAYbhjotXWERSKg> NVfCsRdAtDuOmzNHDWIckHRdmfm;

	private xeDXAkGcMzNhIAYbhjotXWERSKg[] WDUyyBeepmAhJTpKLUMjSdNhRHS;

	private bool RNIGAuZimHpqkKdtRGmsDYGlXri;

	public vqgaTeSNhmAyVtJlBJtiEGOLEPoO()
	{
		NVfCsRdAtDuOmzNHDWIckHRdmfm = new List<xeDXAkGcMzNhIAYbhjotXWERSKg>();
	}

	public override void qzPBsOcOtJOBUdAbauhtohXZIuQL(xeDXAkGcMzNhIAYbhjotXWERSKg P_0)
	{
		NVfCsRdAtDuOmzNHDWIckHRdmfm.Add(P_0);
	}

	public float TgLPLRPKTlXSaoodLpemjkZzehs(int P_0)
	{
		if (P_0 < 0 || P_0 >= WDUyyBeepmAhJTpKLUMjSdNhRHS.Length)
		{
			return 0f;
		}
		return gGNoAhCUXzgDbDcskWksokriYti(WDUyyBeepmAhJTpKLUMjSdNhRHS[P_0].value);
	}

	public int bJeQDLCZhwsCMRQohStcMgMhoQx(int P_0)
	{
		if (P_0 < 0 || P_0 >= WDUyyBeepmAhJTpKLUMjSdNhRHS.Length)
		{
			return 0;
		}
		return (int)WDUyyBeepmAhJTpKLUMjSdNhRHS[P_0].tMdVaanieZgMNBPWABQFUSWqJtyN;
	}

	public override void OgIYPHrzCuzrIWGschTmFAMXkfm()
	{
		if (!RNIGAuZimHpqkKdtRGmsDYGlXri)
		{
			RNIGAuZimHpqkKdtRGmsDYGlXri = true;
			WDUyyBeepmAhJTpKLUMjSdNhRHS = NVfCsRdAtDuOmzNHDWIckHRdmfm.ToArray();
			NVfCsRdAtDuOmzNHDWIckHRdmfm = null;
		}
	}

	private float gGNoAhCUXzgDbDcskWksokriYti(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
