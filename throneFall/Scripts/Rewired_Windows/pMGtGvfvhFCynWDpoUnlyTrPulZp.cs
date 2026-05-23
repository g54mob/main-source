using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class pMGtGvfvhFCynWDpoUnlyTrPulZp
{
	private int yvuadOEbpzZMjCIqTyHbYWfIWZGM;

	private int zqtnKRjJhIAYWiDZLPgTywZRbBbz;

	private int UkyeDBOMmqJlrvmUFfzJXuAWvnuT;

	[CompilerGenerated]
	private Action m_AvoxNtfnozFNrfrnTlHdoendJzWW;

	public float VkXdVAiMyWDgMKEYwLoxttDNIods
	{
		get
		{
			return GcaEmCdiPYJJCeIIMkYEzctXtORW(yvuadOEbpzZMjCIqTyHbYWfIWZGM);
		}
		set
		{
			yvuadOEbpzZMjCIqTyHbYWfIWZGM = KyXtfJMoCsVQIMXqHjiwBAgqbGBiA(num);
			if (this.AvoxNtfnozFNrfrnTlHdoendJzWW != null)
			{
				this.AvoxNtfnozFNrfrnTlHdoendJzWW();
			}
		}
	}

	public int IqUCAdAupfvNpXYQVecZbYudoQHV
	{
		get
		{
			return yvuadOEbpzZMjCIqTyHbYWfIWZGM;
		}
		set
		{
			yvuadOEbpzZMjCIqTyHbYWfIWZGM = num;
			if (this.AvoxNtfnozFNrfrnTlHdoendJzWW != null)
			{
				this.AvoxNtfnozFNrfrnTlHdoendJzWW();
			}
		}
	}

	public event Action AvoxNtfnozFNrfrnTlHdoendJzWW
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_AvoxNtfnozFNrfrnTlHdoendJzWW;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_AvoxNtfnozFNrfrnTlHdoendJzWW, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_AvoxNtfnozFNrfrnTlHdoendJzWW;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_AvoxNtfnozFNrfrnTlHdoendJzWW, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public pMGtGvfvhFCynWDpoUnlyTrPulZp(int P_0, int P_1)
	{
		zqtnKRjJhIAYWiDZLPgTywZRbBbz = P_0;
		UkyeDBOMmqJlrvmUFfzJXuAWvnuT = P_1;
	}

	private float GcaEmCdiPYJJCeIIMkYEzctXtORW(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)UkyeDBOMmqJlrvmUFfzJXuAWvnuT, 0f, 1f);
	}

	private int KyXtfJMoCsVQIMXqHjiwBAgqbGBiA(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)UkyeDBOMmqJlrvmUFfzJXuAWvnuT), zqtnKRjJhIAYWiDZLPgTywZRbBbz, UkyeDBOMmqJlrvmUFfzJXuAWvnuT);
	}
}
