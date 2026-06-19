using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class TlkpubcBJbLfvkJeODXKdsluGNyG
{
	private byte hVPFTUaVIimBUrJDOEpGjbKdxSNzB;

	private byte fQtbjRmwLUjWXpswHousqyGDUAju;

	private byte FiiyuHqojgHyjbvypuZpKDHgkVAF;

	[CompilerGenerated]
	private Action m_ieqOaerHmHMqFmIjZGBVkdVIFYNf;

	public float OYKivTjERXZRaQCccSXNqDmvhGKCA
	{
		get
		{
			return (float)(int)hVPFTUaVIimBUrJDOEpGjbKdxSNzB / 255f;
		}
		set
		{
			LLchhSHiYWLgKJawqrLLaTDNyKxcA = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float TfziCEmzXhXLDQWicRELpXxNVlrg
	{
		get
		{
			return (float)(int)fQtbjRmwLUjWXpswHousqyGDUAju / 255f;
		}
		set
		{
			HqCVfkrMQUVRcbdOevdmSmRmtWNj = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float xOpRkCySihaekhawqhWWFspcFMSF
	{
		get
		{
			return (float)(int)FiiyuHqojgHyjbvypuZpKDHgkVAF / 255f;
		}
		set
		{
			jSiVbYCgDkpLtoziFaBcgRJEJmvE = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public byte LLchhSHiYWLgKJawqrLLaTDNyKxcA
	{
		get
		{
			return hVPFTUaVIimBUrJDOEpGjbKdxSNzB;
		}
		set
		{
			hVPFTUaVIimBUrJDOEpGjbKdxSNzB = b;
			if (this.ieqOaerHmHMqFmIjZGBVkdVIFYNf != null)
			{
				this.ieqOaerHmHMqFmIjZGBVkdVIFYNf();
			}
		}
	}

	public byte HqCVfkrMQUVRcbdOevdmSmRmtWNj
	{
		get
		{
			return fQtbjRmwLUjWXpswHousqyGDUAju;
		}
		set
		{
			fQtbjRmwLUjWXpswHousqyGDUAju = b;
			if (this.ieqOaerHmHMqFmIjZGBVkdVIFYNf != null)
			{
				this.ieqOaerHmHMqFmIjZGBVkdVIFYNf();
			}
		}
	}

	public byte jSiVbYCgDkpLtoziFaBcgRJEJmvE
	{
		get
		{
			return FiiyuHqojgHyjbvypuZpKDHgkVAF;
		}
		set
		{
			FiiyuHqojgHyjbvypuZpKDHgkVAF = fiiyuHqojgHyjbvypuZpKDHgkVAF;
			if (this.ieqOaerHmHMqFmIjZGBVkdVIFYNf != null)
			{
				this.ieqOaerHmHMqFmIjZGBVkdVIFYNf();
			}
		}
	}

	public event Action ieqOaerHmHMqFmIjZGBVkdVIFYNf
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_ieqOaerHmHMqFmIjZGBVkdVIFYNf;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_ieqOaerHmHMqFmIjZGBVkdVIFYNf, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_ieqOaerHmHMqFmIjZGBVkdVIFYNf;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_ieqOaerHmHMqFmIjZGBVkdVIFYNf, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public TlkpubcBJbLfvkJeODXKdsluGNyG()
	{
	}

	public TlkpubcBJbLfvkJeODXKdsluGNyG(byte P_0, byte P_1, byte P_2)
	{
		hVPFTUaVIimBUrJDOEpGjbKdxSNzB = P_0;
		fQtbjRmwLUjWXpswHousqyGDUAju = P_1;
		FiiyuHqojgHyjbvypuZpKDHgkVAF = P_2;
	}
}
