using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class ynsNWLqHUfktHdifyKAAkOjoGzXj
{
	private byte YRTfvuPJZqaMaWzMukkKuKurGfmh;

	private byte ElMFlpcAWahlIgtcftaarCvLWGOc;

	private byte eAkEhtoiakgkNwajBEnzNKLqiopu;

	[CompilerGenerated]
	private Action m_TeuAgAnGMXibjdWBvyDVpORKtNep;

	public float vPYcTtJfKLscQqLvSiAHqbypUWfkA
	{
		get
		{
			return (float)(int)YRTfvuPJZqaMaWzMukkKuKurGfmh / 255f;
		}
		set
		{
			mBcGJswVLOnTinvvOlCNUxHLUMIN = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float ecnCyygCnjapnBhBOGwNyniPFYSD
	{
		get
		{
			return (float)(int)ElMFlpcAWahlIgtcftaarCvLWGOc / 255f;
		}
		set
		{
			kIAhQAlGFQuDKowPUabgZjXgBlcV = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float SshhImoBPrhHQgNlYXqOEZnoeDjs
	{
		get
		{
			return (float)(int)eAkEhtoiakgkNwajBEnzNKLqiopu / 255f;
		}
		set
		{
			OEydJgYetgIWftEcdQvalqXIIXGw = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public byte mBcGJswVLOnTinvvOlCNUxHLUMIN
	{
		get
		{
			return YRTfvuPJZqaMaWzMukkKuKurGfmh;
		}
		set
		{
			YRTfvuPJZqaMaWzMukkKuKurGfmh = yRTfvuPJZqaMaWzMukkKuKurGfmh;
			if (this.TeuAgAnGMXibjdWBvyDVpORKtNep != null)
			{
				this.TeuAgAnGMXibjdWBvyDVpORKtNep();
			}
		}
	}

	public byte kIAhQAlGFQuDKowPUabgZjXgBlcV
	{
		get
		{
			return ElMFlpcAWahlIgtcftaarCvLWGOc;
		}
		set
		{
			ElMFlpcAWahlIgtcftaarCvLWGOc = elMFlpcAWahlIgtcftaarCvLWGOc;
			if (this.TeuAgAnGMXibjdWBvyDVpORKtNep != null)
			{
				this.TeuAgAnGMXibjdWBvyDVpORKtNep();
			}
		}
	}

	public byte OEydJgYetgIWftEcdQvalqXIIXGw
	{
		get
		{
			return eAkEhtoiakgkNwajBEnzNKLqiopu;
		}
		set
		{
			eAkEhtoiakgkNwajBEnzNKLqiopu = b;
			if (this.TeuAgAnGMXibjdWBvyDVpORKtNep != null)
			{
				this.TeuAgAnGMXibjdWBvyDVpORKtNep();
			}
		}
	}

	public event Action TeuAgAnGMXibjdWBvyDVpORKtNep
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_TeuAgAnGMXibjdWBvyDVpORKtNep;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_TeuAgAnGMXibjdWBvyDVpORKtNep, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_TeuAgAnGMXibjdWBvyDVpORKtNep;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_TeuAgAnGMXibjdWBvyDVpORKtNep, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public ynsNWLqHUfktHdifyKAAkOjoGzXj()
	{
	}

	public ynsNWLqHUfktHdifyKAAkOjoGzXj(byte P_0, byte P_1, byte P_2)
	{
		YRTfvuPJZqaMaWzMukkKuKurGfmh = P_0;
		ElMFlpcAWahlIgtcftaarCvLWGOc = P_1;
		eAkEhtoiakgkNwajBEnzNKLqiopu = P_2;
	}
}
