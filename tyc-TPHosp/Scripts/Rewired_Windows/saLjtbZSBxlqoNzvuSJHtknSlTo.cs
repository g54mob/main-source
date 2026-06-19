using System.Collections.Generic;
using Rewired.Utils;

internal class saLjtbZSBxlqoNzvuSJHtknSlTo : bbDFITqKYezHstfvOWFmFoaPRag
{
	private List<wYoTldBjcmEPzkyhATJSjejWGKaQ> EkWwqEgtuKlqDNhRiNcZNHiyggqh;

	private wYoTldBjcmEPzkyhATJSjejWGKaQ[] ZQbxKSnjGxzGcpbtuzqAzNMgbPY;

	private bool YcdaavGlYWkoJqXraKHDlDjmJrc;

	public saLjtbZSBxlqoNzvuSJHtknSlTo()
	{
		EkWwqEgtuKlqDNhRiNcZNHiyggqh = new List<wYoTldBjcmEPzkyhATJSjejWGKaQ>();
	}

	public override void tecUHhDRfADhQiduDHCWMmKBoGW(wYoTldBjcmEPzkyhATJSjejWGKaQ P_0)
	{
		EkWwqEgtuKlqDNhRiNcZNHiyggqh.Add(P_0);
	}

	public float CCwCnYhEmaFZrOQeiMBHgUHikwcc(int P_0)
	{
		if (P_0 < 0 || P_0 >= ZQbxKSnjGxzGcpbtuzqAzNMgbPY.Length)
		{
			return 0f;
		}
		return jBwGMgeXcypsIUbeXmoFAFFnKCeq(ZQbxKSnjGxzGcpbtuzqAzNMgbPY[P_0].value);
	}

	public int gWNdpELwLzAIjnXgQVPDfgfuiQr(int P_0)
	{
		if (P_0 < 0 || P_0 >= ZQbxKSnjGxzGcpbtuzqAzNMgbPY.Length)
		{
			return 0;
		}
		return (int)ZQbxKSnjGxzGcpbtuzqAzNMgbPY[P_0].aYGIRtcEyUWEkvIdlycgzgpxzSs;
	}

	public override void TRbpaMuAmxtxjkBcFVvXejQApcy()
	{
		if (!YcdaavGlYWkoJqXraKHDlDjmJrc)
		{
			YcdaavGlYWkoJqXraKHDlDjmJrc = true;
			ZQbxKSnjGxzGcpbtuzqAzNMgbPY = EkWwqEgtuKlqDNhRiNcZNHiyggqh.ToArray();
			EkWwqEgtuKlqDNhRiNcZNHiyggqh = null;
		}
	}

	private float jBwGMgeXcypsIUbeXmoFAFFnKCeq(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
