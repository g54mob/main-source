using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class rTJgTxMejKLMRUmSvWOxEnqbcNsC
{
	private int yGpjZMtwggCdRCylQDkjwBruaWlBA;

	private int zFwmTLEkgRfPkFVKCBTJIVXlCyId;

	private int OrbfNZjGbxIUJdyRSMMLxMOqpiPx;

	[CompilerGenerated]
	private Action m_WzdlTpQpSqeyLlyDKcyfIzFLadvf;

	public float PvKIhOBqjFDTufSBvzXfLPDhKvGfb
	{
		get
		{
			return EvtwsOMvYRSuuaqNLBbKDPxtWDiSA(yGpjZMtwggCdRCylQDkjwBruaWlBA);
		}
		set
		{
			yGpjZMtwggCdRCylQDkjwBruaWlBA = UiSHRZpBjvrhqOlpSNauzaoOVAie(num);
			if (this.WzdlTpQpSqeyLlyDKcyfIzFLadvf != null)
			{
				this.WzdlTpQpSqeyLlyDKcyfIzFLadvf();
			}
		}
	}

	public int SzNjajnXuqTkLVKNUlPZHTgLWZsS
	{
		get
		{
			return yGpjZMtwggCdRCylQDkjwBruaWlBA;
		}
		set
		{
			yGpjZMtwggCdRCylQDkjwBruaWlBA = num;
			if (this.WzdlTpQpSqeyLlyDKcyfIzFLadvf != null)
			{
				this.WzdlTpQpSqeyLlyDKcyfIzFLadvf();
			}
		}
	}

	public event Action WzdlTpQpSqeyLlyDKcyfIzFLadvf
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_WzdlTpQpSqeyLlyDKcyfIzFLadvf;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_WzdlTpQpSqeyLlyDKcyfIzFLadvf, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_WzdlTpQpSqeyLlyDKcyfIzFLadvf;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_WzdlTpQpSqeyLlyDKcyfIzFLadvf, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public rTJgTxMejKLMRUmSvWOxEnqbcNsC(int P_0, int P_1)
	{
		zFwmTLEkgRfPkFVKCBTJIVXlCyId = P_0;
		OrbfNZjGbxIUJdyRSMMLxMOqpiPx = P_1;
	}

	private float EvtwsOMvYRSuuaqNLBbKDPxtWDiSA(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)OrbfNZjGbxIUJdyRSMMLxMOqpiPx, 0f, 1f);
	}

	private int UiSHRZpBjvrhqOlpSNauzaoOVAie(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)OrbfNZjGbxIUJdyRSMMLxMOqpiPx), zFwmTLEkgRfPkFVKCBTJIVXlCyId, OrbfNZjGbxIUJdyRSMMLxMOqpiPx);
	}
}
