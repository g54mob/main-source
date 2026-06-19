using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class QcAIbyiZKqNrYORSslhiNfzBOxmDb : IPrefetch
{
	protected struct KGqiNNbccNiMxnrDiZaeNlmjIUxHA : IEquatable<KGqiNNbccNiMxnrDiZaeNlmjIUxHA>
	{
		public KeyedGlyph koFjeYvFWOCoiuKRXGKIvVrMbrPb;

		public int QTsQUnodDSFtecbAxNFSiiLaScSwB;

		public KGqiNNbccNiMxnrDiZaeNlmjIUxHA(KeyedGlyph P_0, int P_1)
		{
			koFjeYvFWOCoiuKRXGKIvVrMbrPb = P_0;
			QTsQUnodDSFtecbAxNFSiiLaScSwB = P_1;
		}

		public bool DfZuPmccJGYhgOXRqkDQemGvTWnf(object P_0)
		{
			if (!(P_0 is KGqiNNbccNiMxnrDiZaeNlmjIUxHA kGqiNNbccNiMxnrDiZaeNlmjIUxHA))
			{
				return false;
			}
			if (kGqiNNbccNiMxnrDiZaeNlmjIUxHA.koFjeYvFWOCoiuKRXGKIvVrMbrPb == koFjeYvFWOCoiuKRXGKIvVrMbrPb)
			{
				return kGqiNNbccNiMxnrDiZaeNlmjIUxHA.QTsQUnodDSFtecbAxNFSiiLaScSwB == QTsQUnodDSFtecbAxNFSiiLaScSwB;
			}
			return false;
		}

		public int WPaxssCczhZvRooyVnoXplQhynkM()
		{
			return (17 * 29 + koFjeYvFWOCoiuKRXGKIvVrMbrPb.GetHashCode()) * 29 + QTsQUnodDSFtecbAxNFSiiLaScSwB.GetHashCode();
		}

		public bool Equals(KGqiNNbccNiMxnrDiZaeNlmjIUxHA other)
		{
			if (koFjeYvFWOCoiuKRXGKIvVrMbrPb == other.koFjeYvFWOCoiuKRXGKIvVrMbrPb)
			{
				return QTsQUnodDSFtecbAxNFSiiLaScSwB == other.QTsQUnodDSFtecbAxNFSiiLaScSwB;
			}
			return false;
		}

		bool IEquatable<KGqiNNbccNiMxnrDiZaeNlmjIUxHA>.Equals(KGqiNNbccNiMxnrDiZaeNlmjIUxHA other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool qgkVrRWeGPwPdIrdswqBgofwHtGeA(KGqiNNbccNiMxnrDiZaeNlmjIUxHA P_0, KGqiNNbccNiMxnrDiZaeNlmjIUxHA P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool UavDUzADuQEVvBQXEjxDPSpbVxlNA(KGqiNNbccNiMxnrDiZaeNlmjIUxHA P_0, KGqiNNbccNiMxnrDiZaeNlmjIUxHA P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private AIHwxHYiZBEVvZOJUhghGWlTpYhGA IuAvXFMGiKyrZDdNfHPZJmVkrTxq;

	protected readonly KeyedGlyph AKqyjnfzddUWfsMqMICBLoxSnrQx;

	private Id igvoMJXjVgJmuWcjhayJgTSqYOpH;

	private readonly Dictionary<int, List<KGqiNNbccNiMxnrDiZaeNlmjIUxHA>> aegaAOWCMwjUPSldRCtNBbTORGAhA;

	private bool MVybOjGHXnplLCUlULOBubkcTrhq;

	protected bool uvJyNKBBJDmYuHyzREQDGonXmvvC => MVybOjGHXnplLCUlULOBubkcTrhq;

	public abstract object GVrZzAJiAcZtdOTSfvBJJUYlefGD { get; }

	public abstract string BffrlRgrmyGwIkHNgqwsEclmiqed { get; }

	protected QcAIbyiZKqNrYORSslhiNfzBOxmDb()
	{
		AKqyjnfzddUWfsMqMICBLoxSnrQx = new KeyedGlyph();
		aegaAOWCMwjUPSldRCtNBbTORGAhA = new Dictionary<int, List<KGqiNNbccNiMxnrDiZaeNlmjIUxHA>>();
	}

	protected QcAIbyiZKqNrYORSslhiNfzBOxmDb(AIHwxHYiZBEVvZOJUhghGWlTpYhGA P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		IuAvXFMGiKyrZDdNfHPZJmVkrTxq = P_0;
	}

	public void ApqgeVMSiIfuORfliNPTaNnErvhi()
	{
		XgnqzXvcYyHclqFdRVjgcRxuGNMI();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			gwPRnOZcHdIDjrpMDbeRVuCDFsCcA();
		}
	}

	protected virtual void XgnqzXvcYyHclqFdRVjgcRxuGNMI()
	{
		WaQBoCDCspDfKUhotdwKixGmlDHu();
		bpJOGsKmDrXrdTvNvkleFLouIzQt();
		GlyphManager.Add(this, ref igvoMJXjVgJmuWcjhayJgTSqYOpH);
		MVybOjGHXnplLCUlULOBubkcTrhq = true;
	}

	public virtual void WaQBoCDCspDfKUhotdwKixGmlDHu()
	{
		izxexaYcjFamDxBtzfkFdzvGOrjdA();
		GlyphManager.Remove(ref igvoMJXjVgJmuWcjhayJgTSqYOpH);
		MVybOjGHXnplLCUlULOBubkcTrhq = false;
	}

	public virtual void JBtKTUACafaihxMYlnsjoyoqpDOe(AIHwxHYiZBEVvZOJUhghGWlTpYhGA P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != IuAvXFMGiKyrZDdNfHPZJmVkrTxq)
		{
			if (IuAvXFMGiKyrZDdNfHPZJmVkrTxq != null)
			{
				izxexaYcjFamDxBtzfkFdzvGOrjdA();
			}
			IuAvXFMGiKyrZDdNfHPZJmVkrTxq = P_0;
			ApqgeVMSiIfuORfliNPTaNnErvhi();
		}
	}

	public virtual void wfgJoBerFWpoNZpMurRJxsoCVyED()
	{
		AKqyjnfzddUWfsMqMICBLoxSnrQx.Clear();
	}

	public virtual bool tFwNistcfiNLBsTMMnssjhRVlqOG(QcAIbyiZKqNrYORSslhiNfzBOxmDb P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (IuAvXFMGiKyrZDdNfHPZJmVkrTxq == null != (P_0.IuAvXFMGiKyrZDdNfHPZJmVkrTxq == null))
		{
			return false;
		}
		if (IuAvXFMGiKyrZDdNfHPZJmVkrTxq != null && (!string.Equals(IuAvXFMGiKyrZDdNfHPZJmVkrTxq.keyCategory, P_0.IuAvXFMGiKyrZDdNfHPZJmVkrTxq.keyCategory, StringComparison.Ordinal) || !string.Equals(IuAvXFMGiKyrZDdNfHPZJmVkrTxq.key, P_0.IuAvXFMGiKyrZDdNfHPZJmVkrTxq.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void izxexaYcjFamDxBtzfkFdzvGOrjdA()
	{
		AKqyjnfzddUWfsMqMICBLoxSnrQx.Clear();
		aegaAOWCMwjUPSldRCtNBbTORGAhA.Clear();
	}

	protected AIHwxHYiZBEVvZOJUhghGWlTpYhGA rwuWfypFyCRXrrqMgjBCxLhqsyKs()
	{
		return IuAvXFMGiKyrZDdNfHPZJmVkrTxq;
	}

	protected virtual void gwPRnOZcHdIDjrpMDbeRVuCDFsCcA()
	{
		_ = GVrZzAJiAcZtdOTSfvBJJUYlefGD;
	}

	void IPrefetch.Prefetch()
	{
		gwPRnOZcHdIDjrpMDbeRVuCDFsCcA();
	}

	protected virtual void fuzfufFdSVLzeutlRGUbFcBbaspv(int P_0)
	{
	}

	protected virtual void bpJOGsKmDrXrdTvNvkleFLouIzQt()
	{
	}

	protected virtual void ifDFbrYaRPQixSjSvfqZeDdmXSyFA(int P_0, KGqiNNbccNiMxnrDiZaeNlmjIUxHA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!aegaAOWCMwjUPSldRCtNBbTORGAhA.TryGetValue(num, out var value))
				{
					value = new List<KGqiNNbccNiMxnrDiZaeNlmjIUxHA>();
					aegaAOWCMwjUPSldRCtNBbTORGAhA[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void UokfKKtEmVQHqMCJdnXgztMkqVoD(int P_0, KGqiNNbccNiMxnrDiZaeNlmjIUxHA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !aegaAOWCMwjUPSldRCtNBbTORGAhA.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (KGqiNNbccNiMxnrDiZaeNlmjIUxHA.qgkVrRWeGPwPdIrdswqBgofwHtGeA(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void PfffRuGSBVHZeTueHdEAfaiDfBjW(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !aegaAOWCMwjUPSldRCtNBbTORGAhA.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].QTsQUnodDSFtecbAxNFSiiLaScSwB != 0)
				{
					fuzfufFdSVLzeutlRGUbFcBbaspv(value[j].QTsQUnodDSFtecbAxNFSiiLaScSwB);
				}
				if (value[j].koFjeYvFWOCoiuKRXGKIvVrMbrPb != null)
				{
					value[j].koFjeYvFWOCoiuKRXGKIvVrMbrPb.Clear();
				}
			}
		}
	}
}
