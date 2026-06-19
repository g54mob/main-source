using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class OuyedDeYgCfMJhRepxbdANVcvqtM
{
	private int XfCOxwdDsuiORnwzOPYpwtTbWkkF;

	private int AHRjdpOiuLewcesCOneLDGfesSXBA;

	private int luOpatzavdjNRSADWrpLfKajYyIU;

	[CompilerGenerated]
	private Action m_hzMbcPJOtgkpFhGaEaJpzIVCRwkNA;

	public float kebuKyNPnNUAwnkFlyJfDbfeAhBW
	{
		get
		{
			return lEAxqmWOXTvaBPPRTWKIRLeTTtqA(XfCOxwdDsuiORnwzOPYpwtTbWkkF);
		}
		set
		{
			XfCOxwdDsuiORnwzOPYpwtTbWkkF = jdhGEnCvTtTcenjvWEyyEzITMXjgb(num);
			if (this.hzMbcPJOtgkpFhGaEaJpzIVCRwkNA != null)
			{
				this.hzMbcPJOtgkpFhGaEaJpzIVCRwkNA();
			}
		}
	}

	public int rXanWTxGcklOZyeDGcMFZMCGBbhL
	{
		get
		{
			return XfCOxwdDsuiORnwzOPYpwtTbWkkF;
		}
		set
		{
			XfCOxwdDsuiORnwzOPYpwtTbWkkF = xfCOxwdDsuiORnwzOPYpwtTbWkkF;
			if (this.hzMbcPJOtgkpFhGaEaJpzIVCRwkNA != null)
			{
				this.hzMbcPJOtgkpFhGaEaJpzIVCRwkNA();
			}
		}
	}

	public event Action hzMbcPJOtgkpFhGaEaJpzIVCRwkNA
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_hzMbcPJOtgkpFhGaEaJpzIVCRwkNA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_hzMbcPJOtgkpFhGaEaJpzIVCRwkNA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_hzMbcPJOtgkpFhGaEaJpzIVCRwkNA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_hzMbcPJOtgkpFhGaEaJpzIVCRwkNA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public OuyedDeYgCfMJhRepxbdANVcvqtM(int P_0, int P_1)
	{
		AHRjdpOiuLewcesCOneLDGfesSXBA = P_0;
		luOpatzavdjNRSADWrpLfKajYyIU = P_1;
	}

	private float lEAxqmWOXTvaBPPRTWKIRLeTTtqA(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)luOpatzavdjNRSADWrpLfKajYyIU, 0f, 1f);
	}

	private int jdhGEnCvTtTcenjvWEyyEzITMXjgb(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)luOpatzavdjNRSADWrpLfKajYyIU), AHRjdpOiuLewcesCOneLDGfesSXBA, luOpatzavdjNRSADWrpLfKajYyIU);
	}
}
