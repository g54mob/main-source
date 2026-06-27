using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class zjaGFxWobEvzfkfnDIafHMDeSyQp
{
	private int asUssIzvXuXdjcdayYzdtTRdUxNd;

	private int rhJDBTkGlBtNOhjRuonVuJvsGQoLA;

	private int UjOUAHnGstNcvFGOyriTwCinTyls;

	[CompilerGenerated]
	private Action m_YeWjEpYFmiaErkTfuJQxcFREviDXA;

	public float FdnMOOHJyNvOIoiYNtolKFnibDkk
	{
		get
		{
			return QSYbBYGVVFBGOAdCzwPKADZmDZAGA(asUssIzvXuXdjcdayYzdtTRdUxNd);
		}
		set
		{
			asUssIzvXuXdjcdayYzdtTRdUxNd = EAlggJbWCbFXEkNmkjxckGUFmVOS(num);
			if (this.YeWjEpYFmiaErkTfuJQxcFREviDXA != null)
			{
				this.YeWjEpYFmiaErkTfuJQxcFREviDXA();
			}
		}
	}

	public int OZyBFjtdbmGNdxlWalLBCWEMJQKG
	{
		get
		{
			return asUssIzvXuXdjcdayYzdtTRdUxNd;
		}
		set
		{
			asUssIzvXuXdjcdayYzdtTRdUxNd = num;
			if (this.YeWjEpYFmiaErkTfuJQxcFREviDXA != null)
			{
				this.YeWjEpYFmiaErkTfuJQxcFREviDXA();
			}
		}
	}

	public event Action YeWjEpYFmiaErkTfuJQxcFREviDXA
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_YeWjEpYFmiaErkTfuJQxcFREviDXA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_YeWjEpYFmiaErkTfuJQxcFREviDXA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_YeWjEpYFmiaErkTfuJQxcFREviDXA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_YeWjEpYFmiaErkTfuJQxcFREviDXA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public zjaGFxWobEvzfkfnDIafHMDeSyQp(int P_0, int P_1)
	{
		rhJDBTkGlBtNOhjRuonVuJvsGQoLA = P_0;
		UjOUAHnGstNcvFGOyriTwCinTyls = P_1;
	}

	private float QSYbBYGVVFBGOAdCzwPKADZmDZAGA(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)UjOUAHnGstNcvFGOyriTwCinTyls, 0f, 1f);
	}

	private int EAlggJbWCbFXEkNmkjxckGUFmVOS(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)UjOUAHnGstNcvFGOyriTwCinTyls), rhJDBTkGlBtNOhjRuonVuJvsGQoLA, UjOUAHnGstNcvFGOyriTwCinTyls);
	}
}
