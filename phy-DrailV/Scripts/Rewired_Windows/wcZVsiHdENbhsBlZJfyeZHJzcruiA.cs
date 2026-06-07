using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class wcZVsiHdENbhsBlZJfyeZHJzcruiA
{
	private byte VPpExkGklhhQdvmtqeSXCDGiFRTGc;

	private byte lVyBLgWckyecHspRhhvhRhshgBNu;

	private byte QVgdBYMqeVHvQEPMfeOFWobLFMdXA;

	[CompilerGenerated]
	private Action m_jbfGSranhZTjcNFJQWUMIeosJyxS;

	public float XuilfXHvQLvtozMStdIqbvBZEvHA
	{
		get
		{
			return (float)(int)VPpExkGklhhQdvmtqeSXCDGiFRTGc / 255f;
		}
		set
		{
			qliHrwMycrHSwdrYkWwBtKZLSFkj = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float QvbgjVpFXGFLuKKcqiINoDxhmJdy
	{
		get
		{
			return (float)(int)lVyBLgWckyecHspRhhvhRhshgBNu / 255f;
		}
		set
		{
			lVKGsWgUBkpHMUSOdQPuLcJjaZjiA = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float KZjAKBRCqWvItsiSidTaxzXnlvlP
	{
		get
		{
			return (float)(int)QVgdBYMqeVHvQEPMfeOFWobLFMdXA / 255f;
		}
		set
		{
			pkPiWyPinEsSkuGqQARVqCeMkJuv = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public byte qliHrwMycrHSwdrYkWwBtKZLSFkj
	{
		get
		{
			return VPpExkGklhhQdvmtqeSXCDGiFRTGc;
		}
		set
		{
			VPpExkGklhhQdvmtqeSXCDGiFRTGc = vPpExkGklhhQdvmtqeSXCDGiFRTGc;
			if (this.jbfGSranhZTjcNFJQWUMIeosJyxS != null)
			{
				this.jbfGSranhZTjcNFJQWUMIeosJyxS();
			}
		}
	}

	public byte lVKGsWgUBkpHMUSOdQPuLcJjaZjiA
	{
		get
		{
			return lVyBLgWckyecHspRhhvhRhshgBNu;
		}
		set
		{
			lVyBLgWckyecHspRhhvhRhshgBNu = b;
			if (this.jbfGSranhZTjcNFJQWUMIeosJyxS != null)
			{
				this.jbfGSranhZTjcNFJQWUMIeosJyxS();
			}
		}
	}

	public byte pkPiWyPinEsSkuGqQARVqCeMkJuv
	{
		get
		{
			return QVgdBYMqeVHvQEPMfeOFWobLFMdXA;
		}
		set
		{
			QVgdBYMqeVHvQEPMfeOFWobLFMdXA = qVgdBYMqeVHvQEPMfeOFWobLFMdXA;
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

	public wcZVsiHdENbhsBlZJfyeZHJzcruiA()
	{
	}

	public wcZVsiHdENbhsBlZJfyeZHJzcruiA(byte P_0, byte P_1, byte P_2)
	{
		VPpExkGklhhQdvmtqeSXCDGiFRTGc = P_0;
		lVyBLgWckyecHspRhhvhRhshgBNu = P_1;
		QVgdBYMqeVHvQEPMfeOFWobLFMdXA = P_2;
	}
}
