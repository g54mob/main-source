using System.Collections.Generic;
using Rewired.Utils;

internal class qOWNeWiQdvONIuaeCdEikuUBUJEl : AdYqxsvyKqsMtDQSffNaPkmWadDA
{
	private List<BIUFirtDzMADIWxqZXbAvAoAAtDgA> EYLhoyJXbUVgwPgJOlmorepxcLzbA;

	private BIUFirtDzMADIWxqZXbAvAoAAtDgA[] qwZegseZiNdlATkFwLaNIgtpiULAb;

	private bool mQrFkIpIASScsdogRDCBwygtuuMx;

	public qOWNeWiQdvONIuaeCdEikuUBUJEl()
	{
		EYLhoyJXbUVgwPgJOlmorepxcLzbA = new List<BIUFirtDzMADIWxqZXbAvAoAAtDgA>();
	}

	public virtual void EMFIdHWZyOPsLbaGiBVNAYEsFLfJ(BIUFirtDzMADIWxqZXbAvAoAAtDgA P_0)
	{
		EYLhoyJXbUVgwPgJOlmorepxcLzbA.Add(P_0);
	}

	public float FEwzcuOSWJbRpUsfxTtQBSrREWUG(int P_0)
	{
		if (P_0 < 0 || P_0 >= qwZegseZiNdlATkFwLaNIgtpiULAb.Length)
		{
			return 0f;
		}
		return wHOCZBWUTgUFVsxjvNahWADPDXam(qwZegseZiNdlATkFwLaNIgtpiULAb[P_0].qlZfvRdFBAIdvVGeuQXSIcEIxUh);
	}

	public int qHYmLjQbAVMgsUKQcxNcxNHFceqo(int P_0)
	{
		if (P_0 < 0 || P_0 >= qwZegseZiNdlATkFwLaNIgtpiULAb.Length)
		{
			return 0;
		}
		return (int)qwZegseZiNdlATkFwLaNIgtpiULAb[P_0].vGayQAeBuTTBfLwzaPIVaWKbPzEw;
	}

	public virtual void RBMmGfJOKRETPdVfKtazUKwvonYb()
	{
		if (!mQrFkIpIASScsdogRDCBwygtuuMx)
		{
			mQrFkIpIASScsdogRDCBwygtuuMx = true;
			qwZegseZiNdlATkFwLaNIgtpiULAb = EYLhoyJXbUVgwPgJOlmorepxcLzbA.ToArray();
			EYLhoyJXbUVgwPgJOlmorepxcLzbA = null;
		}
	}

	private static float wHOCZBWUTgUFVsxjvNahWADPDXam(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
