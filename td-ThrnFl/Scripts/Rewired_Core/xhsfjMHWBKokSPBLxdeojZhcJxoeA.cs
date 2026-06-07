using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class xhsfjMHWBKokSPBLxdeojZhcJxoeA : IfopinoSAuQZnpEvFIfBnubyAxLB
{
	protected struct eHmaJdrNOVirmgtpoujzQtBnLiexA : IEquatable<eHmaJdrNOVirmgtpoujzQtBnLiexA>
	{
		public LocalizedString sigTNzHcEgiAMnBdNaAdaLOmuMJG;

		public int FodEZfUyahnacEwWYFigPPfEgiKo;

		public eHmaJdrNOVirmgtpoujzQtBnLiexA(LocalizedString P_0, int P_1)
		{
			sigTNzHcEgiAMnBdNaAdaLOmuMJG = P_0;
			FodEZfUyahnacEwWYFigPPfEgiKo = P_1;
		}

		public bool ptgMZuWoJFbKapeEhegmjQYvcCMo(object P_0)
		{
			if (!(P_0 is eHmaJdrNOVirmgtpoujzQtBnLiexA eHmaJdrNOVirmgtpoujzQtBnLiexA2))
			{
				return false;
			}
			if (eHmaJdrNOVirmgtpoujzQtBnLiexA2.sigTNzHcEgiAMnBdNaAdaLOmuMJG == sigTNzHcEgiAMnBdNaAdaLOmuMJG)
			{
				return eHmaJdrNOVirmgtpoujzQtBnLiexA2.FodEZfUyahnacEwWYFigPPfEgiKo == FodEZfUyahnacEwWYFigPPfEgiKo;
			}
			return false;
		}

		public int aNXgXaeuJjyqOBuUDBWHCEmgINSd()
		{
			return (17 * 29 + sigTNzHcEgiAMnBdNaAdaLOmuMJG.GetHashCode()) * 29 + FodEZfUyahnacEwWYFigPPfEgiKo.GetHashCode();
		}

		public bool Equals(eHmaJdrNOVirmgtpoujzQtBnLiexA other)
		{
			if (sigTNzHcEgiAMnBdNaAdaLOmuMJG == other.sigTNzHcEgiAMnBdNaAdaLOmuMJG)
			{
				return FodEZfUyahnacEwWYFigPPfEgiKo == other.FodEZfUyahnacEwWYFigPPfEgiKo;
			}
			return false;
		}

		bool IEquatable<eHmaJdrNOVirmgtpoujzQtBnLiexA>.Equals(eHmaJdrNOVirmgtpoujzQtBnLiexA other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool qKsbIdiwdhEhqmyecbEFAUxGfLGrA(eHmaJdrNOVirmgtpoujzQtBnLiexA P_0, eHmaJdrNOVirmgtpoujzQtBnLiexA P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool MPdDipHeOzOcSEhrHYrRjivsGeaIc(eHmaJdrNOVirmgtpoujzQtBnLiexA P_0, eHmaJdrNOVirmgtpoujzQtBnLiexA P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private LnhaMJXLiFbdSGpizhhMTtFDjtXy azTwGBYrNPZPABltTIiufVedbRjS;

	protected readonly LocalizedString IgMwwqYoaShFZDOHgCAHernAcSRVA;

	private Id NrMXHLfdbZaovDXzqsvZAtHJpdrCb;

	private readonly Dictionary<int, List<eHmaJdrNOVirmgtpoujzQtBnLiexA>> TUeZGsOpLSPolXhQPwvcaPYPfWXu;

	private bool FedCOQBhMfWCPHEbtJqrIfFpRXMpA;

	protected bool tFnDIYcJYPjQABQySAwBboLweIfv => FedCOQBhMfWCPHEbtJqrIfFpRXMpA;

	public abstract string qJkqRAxrrocPcPhIKAOpCMJUoZxfA { get; }

	protected xhsfjMHWBKokSPBLxdeojZhcJxoeA()
	{
		IgMwwqYoaShFZDOHgCAHernAcSRVA = new LocalizedString();
		TUeZGsOpLSPolXhQPwvcaPYPfWXu = new Dictionary<int, List<eHmaJdrNOVirmgtpoujzQtBnLiexA>>();
	}

	protected xhsfjMHWBKokSPBLxdeojZhcJxoeA(LnhaMJXLiFbdSGpizhhMTtFDjtXy P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		azTwGBYrNPZPABltTIiufVedbRjS = P_0;
	}

	public void DKMkEJwNUuDpLGWqVbXJUJJzEYRk()
	{
		fJEGjYShwDhlCtKiGggxusMUCXuo();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			WWbQWIkCrHILkmvtSGPWgKBbHyFQ();
		}
	}

	protected virtual void fJEGjYShwDhlCtKiGggxusMUCXuo()
	{
		dquBXsHhSopkZLPiWdkIhosotuBF();
		CDgdhocKjUGZulOPMnDajGfidFkIb();
		LocalizationManager.Add(this, ref NrMXHLfdbZaovDXzqsvZAtHJpdrCb);
		FedCOQBhMfWCPHEbtJqrIfFpRXMpA = true;
	}

	public virtual void dquBXsHhSopkZLPiWdkIhosotuBF()
	{
		CNyaoPIDHcxPGQLQdSOKLsUXDKbN();
		LocalizationManager.Remove(ref NrMXHLfdbZaovDXzqsvZAtHJpdrCb);
		FedCOQBhMfWCPHEbtJqrIfFpRXMpA = false;
	}

	public virtual void robwaoxSKinucgPcyrfEovhcOMTl(LnhaMJXLiFbdSGpizhhMTtFDjtXy P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != azTwGBYrNPZPABltTIiufVedbRjS)
		{
			if (azTwGBYrNPZPABltTIiufVedbRjS != null)
			{
				CNyaoPIDHcxPGQLQdSOKLsUXDKbN();
			}
			azTwGBYrNPZPABltTIiufVedbRjS = P_0;
			DKMkEJwNUuDpLGWqVbXJUJJzEYRk();
		}
	}

	public virtual void AeqSUmtDwbcYLrhaTtXtwzoJTozq()
	{
		IgMwwqYoaShFZDOHgCAHernAcSRVA.Clear();
	}

	public virtual void VFHulbCONdrHnQmgMqwKyHtRlYIr()
	{
		IgMwwqYoaShFZDOHgCAHernAcSRVA.Clear();
	}

	public virtual void wkNCiIKcomvvEiZxnJmXtmqxRPdW()
	{
		IgMwwqYoaShFZDOHgCAHernAcSRVA.Clear();
	}

	public virtual bool fnknzfXTJAiyPjhBrqRTlqnPySbr(xhsfjMHWBKokSPBLxdeojZhcJxoeA P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (azTwGBYrNPZPABltTIiufVedbRjS == null != (P_0.azTwGBYrNPZPABltTIiufVedbRjS == null))
		{
			return false;
		}
		if (azTwGBYrNPZPABltTIiufVedbRjS != null)
		{
			if (!string.Equals(azTwGBYrNPZPABltTIiufVedbRjS.keyCategory, P_0.azTwGBYrNPZPABltTIiufVedbRjS.keyCategory, StringComparison.Ordinal) || !string.Equals(azTwGBYrNPZPABltTIiufVedbRjS.scriptingName, P_0.azTwGBYrNPZPABltTIiufVedbRjS.scriptingName, StringComparison.Ordinal) || !string.Equals(azTwGBYrNPZPABltTIiufVedbRjS.key, P_0.azTwGBYrNPZPABltTIiufVedbRjS.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(azTwGBYrNPZPABltTIiufVedbRjS.nonLocalizedDescriptiveName, P_0.azTwGBYrNPZPABltTIiufVedbRjS.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void CNyaoPIDHcxPGQLQdSOKLsUXDKbN()
	{
		IgMwwqYoaShFZDOHgCAHernAcSRVA.Clear();
		TUeZGsOpLSPolXhQPwvcaPYPfWXu.Clear();
	}

	protected LnhaMJXLiFbdSGpizhhMTtFDjtXy RZKDbaDlqKvZBfkLJCkUzoaxqLAwA()
	{
		return azTwGBYrNPZPABltTIiufVedbRjS;
	}

	protected virtual void WWbQWIkCrHILkmvtSGPWgKBbHyFQ()
	{
		_ = qJkqRAxrrocPcPhIKAOpCMJUoZxfA;
	}

	void IfopinoSAuQZnpEvFIfBnubyAxLB.Localize()
	{
		WWbQWIkCrHILkmvtSGPWgKBbHyFQ();
	}

	protected virtual void PwEgDBNHpFGHYbdNfSmJVwtzcbhgA(int P_0)
	{
	}

	protected virtual void CDgdhocKjUGZulOPMnDajGfidFkIb()
	{
	}

	protected virtual void WfYxlWKheRqSPhxWVoclUcggslZQ(int P_0, eHmaJdrNOVirmgtpoujzQtBnLiexA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!TUeZGsOpLSPolXhQPwvcaPYPfWXu.TryGetValue(num, out var value))
				{
					value = new List<eHmaJdrNOVirmgtpoujzQtBnLiexA>();
					TUeZGsOpLSPolXhQPwvcaPYPfWXu[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void YhQEkrxfvLHQmbbDmDjyTijudHojA(int P_0, eHmaJdrNOVirmgtpoujzQtBnLiexA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !TUeZGsOpLSPolXhQPwvcaPYPfWXu.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (eHmaJdrNOVirmgtpoujzQtBnLiexA.qKsbIdiwdhEhqmyecbEFAUxGfLGrA(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void yEJKXEtRylKddSbgoiIxUFVZUTMX(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !TUeZGsOpLSPolXhQPwvcaPYPfWXu.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].FodEZfUyahnacEwWYFigPPfEgiKo != 0)
				{
					PwEgDBNHpFGHYbdNfSmJVwtzcbhgA(value[j].FodEZfUyahnacEwWYFigPPfEgiKo);
				}
				if (value[j].sigTNzHcEgiAMnBdNaAdaLOmuMJG != null)
				{
					value[j].sigTNzHcEgiAMnBdNaAdaLOmuMJG.Clear();
				}
			}
		}
	}
}
