using System.Collections.Generic;
using Rewired.Utils;

internal class tWkKNCXIrnFwxZTVcetdQCqcJSr : gjqxeaurskCrrKdTQKtANktjOGhz
{
	private List<pyZQbMTATyVfguiHEyKaPAqwFRx> FPzLzviOPQchOFElsPhvskvOzBt;

	private pyZQbMTATyVfguiHEyKaPAqwFRx[] YxUvwfrqovAlnnTgiXHkITWKOAH;

	private bool JHGJHOSVuGeaQoWFwlnlCJwKAen;

	public tWkKNCXIrnFwxZTVcetdQCqcJSr()
	{
		FPzLzviOPQchOFElsPhvskvOzBt = new List<pyZQbMTATyVfguiHEyKaPAqwFRx>();
	}

	public override void sSTehkbZdOwHeleDDlmiNnnpynDk(pyZQbMTATyVfguiHEyKaPAqwFRx P_0)
	{
		FPzLzviOPQchOFElsPhvskvOzBt.Add(P_0);
	}

	public float LaNWitWQqyZMqUSPioBpzBMOpwf(int P_0)
	{
		if (P_0 < 0 || P_0 >= YxUvwfrqovAlnnTgiXHkITWKOAH.Length)
		{
			return 0f;
		}
		return oMNnXrBObsqXntKHDHpZyOhNBhe(YxUvwfrqovAlnnTgiXHkITWKOAH[P_0].value);
	}

	public int zPyoQbZsbhrGwxLWYeqdGHaGfFs(int P_0)
	{
		if (P_0 < 0 || P_0 >= YxUvwfrqovAlnnTgiXHkITWKOAH.Length)
		{
			return 0;
		}
		return (int)YxUvwfrqovAlnnTgiXHkITWKOAH[P_0].lGpyvYcIyUaWjAtqbNROdSiPlaxt;
	}

	public override void MMUwIhsISnTbkkxIVKgbRXyiSqf()
	{
		if (JHGJHOSVuGeaQoWFwlnlCJwKAen)
		{
			return;
		}
		while (true)
		{
			JHGJHOSVuGeaQoWFwlnlCJwKAen = true;
			YxUvwfrqovAlnnTgiXHkITWKOAH = FPzLzviOPQchOFElsPhvskvOzBt.ToArray();
			int num = 52688300;
			while (true)
			{
				switch (num ^ 0x323F5AE)
				{
				case 0:
					num = 52688301;
					continue;
				default:
					return;
				case 3:
					break;
				case 2:
					FPzLzviOPQchOFElsPhvskvOzBt = null;
					num = 52688303;
					continue;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private float oMNnXrBObsqXntKHDHpZyOhNBhe(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
