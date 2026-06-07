using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class pmTlTYxlhgTeYOMZqBSNaIrfQJzO
{
	private int AxMGGTYupVINSLjoZGaxDYtyPWsE;

	private int JcojvpDihKzNoVnmysHPQomDflGAb;

	private int ZhtPOkxiSGdNQjBCwpOgEbljgRrJA;

	[CompilerGenerated]
	private Action m_jbfGSranhZTjcNFJQWUMIeosJyxS;

	public float EFmUVEpUcrIwRWHZCDJnLnIbiwvAA
	{
		get
		{
			return kijzFGdSruIYXnEfsFPheulQGGFs(AxMGGTYupVINSLjoZGaxDYtyPWsE);
		}
		set
		{
			AxMGGTYupVINSLjoZGaxDYtyPWsE = ZLFzubpCphltBRCQHQvNTXBPPhhF(num);
			if (this.jbfGSranhZTjcNFJQWUMIeosJyxS != null)
			{
				this.jbfGSranhZTjcNFJQWUMIeosJyxS();
			}
		}
	}

	public int WPYNyFAdjBraRLgEqCcHbcfbsIkf
	{
		get
		{
			return AxMGGTYupVINSLjoZGaxDYtyPWsE;
		}
		set
		{
			AxMGGTYupVINSLjoZGaxDYtyPWsE = axMGGTYupVINSLjoZGaxDYtyPWsE;
			if (this.jbfGSranhZTjcNFJQWUMIeosJyxS != null)
			{
				this.jbfGSranhZTjcNFJQWUMIeosJyxS();
			}
		}
	}

	public event Action jbfGSranhZTjcNFJQWUMIeosJyxS
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_jbfGSranhZTjcNFJQWUMIeosJyxS;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_jbfGSranhZTjcNFJQWUMIeosJyxS, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_jbfGSranhZTjcNFJQWUMIeosJyxS;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_jbfGSranhZTjcNFJQWUMIeosJyxS, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public pmTlTYxlhgTeYOMZqBSNaIrfQJzO(int P_0, int P_1)
	{
		JcojvpDihKzNoVnmysHPQomDflGAb = P_0;
		ZhtPOkxiSGdNQjBCwpOgEbljgRrJA = P_1;
	}

	private float kijzFGdSruIYXnEfsFPheulQGGFs(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)ZhtPOkxiSGdNQjBCwpOgEbljgRrJA, 0f, 1f);
	}

	private int ZLFzubpCphltBRCQHQvNTXBPPhhF(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)ZhtPOkxiSGdNQjBCwpOgEbljgRrJA), JcojvpDihKzNoVnmysHPQomDflGAb, ZhtPOkxiSGdNQjBCwpOgEbljgRrJA);
	}
}
