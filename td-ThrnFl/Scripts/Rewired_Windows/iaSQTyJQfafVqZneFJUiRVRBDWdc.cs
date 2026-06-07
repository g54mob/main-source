using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class iaSQTyJQfafVqZneFJUiRVRBDWdc
{
	private byte WzxumcqORlDdokZGHzuAXaeUPQfl;

	private byte AyDUevXJMRksxEGrWmJgWWgoFkBi;

	private byte kmEJmzLBcfdzJEkneEuzwSbFvxyR;

	[CompilerGenerated]
	private Action m_TnMtrKGOeSsLjFPJAGfRQtnlOdlF;

	public float bFcLWhUVQYrhAtojtbBTOwUMnPuo
	{
		get
		{
			return (float)(int)WzxumcqORlDdokZGHzuAXaeUPQfl / 255f;
		}
		set
		{
			iPItKgFTHBtGuRUztlDNfIvkSBLr = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float cPTNHiJyYcdHppnnfDGHBtVeMsBm
	{
		get
		{
			return (float)(int)AyDUevXJMRksxEGrWmJgWWgoFkBi / 255f;
		}
		set
		{
			oEsbyWGtXRtvGKQJpHjyopbJnsxS = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float UWJkPgTZOsCYAYhmbdbUfaNJAMak
	{
		get
		{
			return (float)(int)kmEJmzLBcfdzJEkneEuzwSbFvxyR / 255f;
		}
		set
		{
			SMEmhyfAzxVApXucSoIcGVvjYfNI = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public byte iPItKgFTHBtGuRUztlDNfIvkSBLr
	{
		get
		{
			return WzxumcqORlDdokZGHzuAXaeUPQfl;
		}
		set
		{
			WzxumcqORlDdokZGHzuAXaeUPQfl = wzxumcqORlDdokZGHzuAXaeUPQfl;
			if (this.TnMtrKGOeSsLjFPJAGfRQtnlOdlF != null)
			{
				this.TnMtrKGOeSsLjFPJAGfRQtnlOdlF();
			}
		}
	}

	public byte oEsbyWGtXRtvGKQJpHjyopbJnsxS
	{
		get
		{
			return AyDUevXJMRksxEGrWmJgWWgoFkBi;
		}
		set
		{
			AyDUevXJMRksxEGrWmJgWWgoFkBi = ayDUevXJMRksxEGrWmJgWWgoFkBi;
			if (this.TnMtrKGOeSsLjFPJAGfRQtnlOdlF != null)
			{
				this.TnMtrKGOeSsLjFPJAGfRQtnlOdlF();
			}
		}
	}

	public byte SMEmhyfAzxVApXucSoIcGVvjYfNI
	{
		get
		{
			return kmEJmzLBcfdzJEkneEuzwSbFvxyR;
		}
		set
		{
			kmEJmzLBcfdzJEkneEuzwSbFvxyR = b;
			if (this.TnMtrKGOeSsLjFPJAGfRQtnlOdlF != null)
			{
				this.TnMtrKGOeSsLjFPJAGfRQtnlOdlF();
			}
		}
	}

	public event Action TnMtrKGOeSsLjFPJAGfRQtnlOdlF
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_TnMtrKGOeSsLjFPJAGfRQtnlOdlF;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_TnMtrKGOeSsLjFPJAGfRQtnlOdlF, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_TnMtrKGOeSsLjFPJAGfRQtnlOdlF;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_TnMtrKGOeSsLjFPJAGfRQtnlOdlF, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public iaSQTyJQfafVqZneFJUiRVRBDWdc()
	{
	}

	public iaSQTyJQfafVqZneFJUiRVRBDWdc(byte P_0, byte P_1, byte P_2)
	{
		WzxumcqORlDdokZGHzuAXaeUPQfl = P_0;
		AyDUevXJMRksxEGrWmJgWWgoFkBi = P_1;
		kmEJmzLBcfdzJEkneEuzwSbFvxyR = P_2;
	}
}
