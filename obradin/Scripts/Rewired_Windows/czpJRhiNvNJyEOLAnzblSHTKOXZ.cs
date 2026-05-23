using System.Collections.Generic;
using Rewired.Utils;

internal class czpJRhiNvNJyEOLAnzblSHTKOXZ : tDbEfRBvKQKUUajRFFcUkaQZPWTt
{
	private List<ajUREtsgqMboTruDDhvoVRJAART> CReCHYJvciLGtEZbzEYrgGScbCT;

	private ajUREtsgqMboTruDDhvoVRJAART[] JPJmJGCdMTKfGunZrcGmUqemfKrH;

	private bool YfBSCddQEujBvizXxbyhsMRcHkRR;

	public czpJRhiNvNJyEOLAnzblSHTKOXZ()
	{
		CReCHYJvciLGtEZbzEYrgGScbCT = new List<ajUREtsgqMboTruDDhvoVRJAART>();
	}

	public override void AddAxis(ajUREtsgqMboTruDDhvoVRJAART P_0)
	{
		CReCHYJvciLGtEZbzEYrgGScbCT.Add(P_0);
	}

	public float QkOJeQjNoGuvJJcCjzkxhFnepjH(int P_0)
	{
		if (P_0 < 0 || P_0 >= JPJmJGCdMTKfGunZrcGmUqemfKrH.Length)
		{
			return 0f;
		}
		return dmOmXokuwYPeqkLCCIorsBnvJVN(JPJmJGCdMTKfGunZrcGmUqemfKrH[P_0].value);
	}

	public int arvEFUcSVZvjLquKNhddYJHkpTS(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = -1874796881;
				while (true)
				{
					switch (num ^ -1874796882)
					{
					case 0:
						break;
					case 1:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= JPJmJGCdMTKfGunZrcGmUqemfKrH.Length)
					{
						num = -1874796884;
						continue;
					}
					return (int)JPJmJGCdMTKfGunZrcGmUqemfKrH[P_0].slcDutVbWmJxSkNwoiIYAENfAsLd;
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return 0;
	}

	public override void Finish()
	{
		if (YfBSCddQEujBvizXxbyhsMRcHkRR)
		{
			goto IL_0008;
		}
		goto IL_0036;
		IL_0008:
		int num = -627628403;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -627628404)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 4:
				goto IL_0036;
			case 0:
				CReCHYJvciLGtEZbzEYrgGScbCT = null;
				num = -627628401;
				continue;
			case 3:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0036:
		YfBSCddQEujBvizXxbyhsMRcHkRR = true;
		JPJmJGCdMTKfGunZrcGmUqemfKrH = CReCHYJvciLGtEZbzEYrgGScbCT.ToArray();
		num = -627628404;
		goto IL_000d;
	}

	private float dmOmXokuwYPeqkLCCIorsBnvJVN(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
