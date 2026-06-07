using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class eOTDyXEaLnqMzCVeUQsYyxDdlUnRA
{
	private byte OFqMziTMqeOiWmPEOKOEpiimUCEh;

	private byte QLKokhiZVYLPVIewNlPokzoAWUcR;

	private byte qfLEvryOtmAGtIWsvVXphAhpmoNSA;

	[CompilerGenerated]
	private Action m_VjNtNSvDDNOJXHSCDSpNyyrXKTOM;

	public float bmxoAjzsPVSTcbpsoalZqgIkhIBt
	{
		get
		{
			return (float)(int)OFqMziTMqeOiWmPEOKOEpiimUCEh / 255f;
		}
		set
		{
			icHctacIJMzVGXgZeecHBnvYQQyD = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float uGGffweBZbyGJjlgwJeLbWHGERux
	{
		get
		{
			return (float)(int)QLKokhiZVYLPVIewNlPokzoAWUcR / 255f;
		}
		set
		{
			sxriMIpQSAKUwYKSoWWkEypbExKV = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float QiEWCumzGtErsUfsoqUSBOXdNDVn
	{
		get
		{
			return (float)(int)qfLEvryOtmAGtIWsvVXphAhpmoNSA / 255f;
		}
		set
		{
			GhRUEqUmyuxeFVpnBfPmcoxXDHeUA = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public byte icHctacIJMzVGXgZeecHBnvYQQyD
	{
		get
		{
			return OFqMziTMqeOiWmPEOKOEpiimUCEh;
		}
		set
		{
			OFqMziTMqeOiWmPEOKOEpiimUCEh = oFqMziTMqeOiWmPEOKOEpiimUCEh;
			if (this.VjNtNSvDDNOJXHSCDSpNyyrXKTOM != null)
			{
				this.VjNtNSvDDNOJXHSCDSpNyyrXKTOM();
			}
		}
	}

	public byte sxriMIpQSAKUwYKSoWWkEypbExKV
	{
		get
		{
			return QLKokhiZVYLPVIewNlPokzoAWUcR;
		}
		set
		{
			QLKokhiZVYLPVIewNlPokzoAWUcR = qLKokhiZVYLPVIewNlPokzoAWUcR;
			if (this.VjNtNSvDDNOJXHSCDSpNyyrXKTOM != null)
			{
				this.VjNtNSvDDNOJXHSCDSpNyyrXKTOM();
			}
		}
	}

	public byte GhRUEqUmyuxeFVpnBfPmcoxXDHeUA
	{
		get
		{
			return qfLEvryOtmAGtIWsvVXphAhpmoNSA;
		}
		set
		{
			qfLEvryOtmAGtIWsvVXphAhpmoNSA = b;
			if (this.VjNtNSvDDNOJXHSCDSpNyyrXKTOM != null)
			{
				this.VjNtNSvDDNOJXHSCDSpNyyrXKTOM();
			}
		}
	}

	public event Action VjNtNSvDDNOJXHSCDSpNyyrXKTOM
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_VjNtNSvDDNOJXHSCDSpNyyrXKTOM;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_VjNtNSvDDNOJXHSCDSpNyyrXKTOM, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_VjNtNSvDDNOJXHSCDSpNyyrXKTOM;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_VjNtNSvDDNOJXHSCDSpNyyrXKTOM, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public eOTDyXEaLnqMzCVeUQsYyxDdlUnRA()
	{
	}

	public eOTDyXEaLnqMzCVeUQsYyxDdlUnRA(byte P_0, byte P_1, byte P_2)
	{
		OFqMziTMqeOiWmPEOKOEpiimUCEh = P_0;
		QLKokhiZVYLPVIewNlPokzoAWUcR = P_1;
		qfLEvryOtmAGtIWsvVXphAhpmoNSA = P_2;
	}
}
