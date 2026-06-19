using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class CrEdIhdRuEefdCHiQoLwiMECdkdvB : nYVWMTKfnKjTqnJzQqfdswXfeTcY
{
	protected struct BKckUJBjHlyNjLMNcSvupioWhbq : IEquatable<BKckUJBjHlyNjLMNcSvupioWhbq>
	{
		public LocalizedString DjGcOGzVTgfPpfASudPfdptdepSkA;

		public int qgVDeAEkFdUtVgYlhFXwAjAVYpXv;

		public BKckUJBjHlyNjLMNcSvupioWhbq(LocalizedString P_0, int P_1)
		{
			DjGcOGzVTgfPpfASudPfdptdepSkA = P_0;
			qgVDeAEkFdUtVgYlhFXwAjAVYpXv = P_1;
		}

		public bool KvCdbLsdaNaUJzCrWBOisczgBwJj(object P_0)
		{
			if (!(P_0 is BKckUJBjHlyNjLMNcSvupioWhbq bKckUJBjHlyNjLMNcSvupioWhbq))
			{
				return false;
			}
			if (bKckUJBjHlyNjLMNcSvupioWhbq.DjGcOGzVTgfPpfASudPfdptdepSkA == DjGcOGzVTgfPpfASudPfdptdepSkA)
			{
				return bKckUJBjHlyNjLMNcSvupioWhbq.qgVDeAEkFdUtVgYlhFXwAjAVYpXv == qgVDeAEkFdUtVgYlhFXwAjAVYpXv;
			}
			return false;
		}

		public int BExZeLYOPbdXnFeDsimXTqrdHvTf()
		{
			return (17 * 29 + DjGcOGzVTgfPpfASudPfdptdepSkA.GetHashCode()) * 29 + qgVDeAEkFdUtVgYlhFXwAjAVYpXv.GetHashCode();
		}

		public bool Equals(BKckUJBjHlyNjLMNcSvupioWhbq other)
		{
			if (DjGcOGzVTgfPpfASudPfdptdepSkA == other.DjGcOGzVTgfPpfASudPfdptdepSkA)
			{
				return qgVDeAEkFdUtVgYlhFXwAjAVYpXv == other.qgVDeAEkFdUtVgYlhFXwAjAVYpXv;
			}
			return false;
		}

		bool IEquatable<BKckUJBjHlyNjLMNcSvupioWhbq>.Equals(BKckUJBjHlyNjLMNcSvupioWhbq other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool XiEhnEEVOlbkNwLBZxbBDJQBcOJO(BKckUJBjHlyNjLMNcSvupioWhbq P_0, BKckUJBjHlyNjLMNcSvupioWhbq P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool rDPeNCSpbbdflzxEdISTdQIJGnht(BKckUJBjHlyNjLMNcSvupioWhbq P_0, BKckUJBjHlyNjLMNcSvupioWhbq P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private gDrCmzJNXwFvGTMAYKGQspUqeYD DVbrjmqfkNTYbLVWiRTqaEDitQaO;

	protected readonly LocalizedString xReLXRqoDCNUkVraDkxZoEUHpFYT;

	private Id adesacVtAZHjUFgKTsQNalaAFaiW;

	private readonly Dictionary<int, List<BKckUJBjHlyNjLMNcSvupioWhbq>> aeMqzFsasKbbWHHnyzWoLffKJVIBA;

	private bool ioVFppHlthGPwcIAMNLvKiakpQLHA;

	protected bool WRFezhhGdRvZlGXJhyNRmimtWHenA => ioVFppHlthGPwcIAMNLvKiakpQLHA;

	public abstract string LoGZqdROKyuYHJXdnhuxPciDQjeL { get; }

	protected CrEdIhdRuEefdCHiQoLwiMECdkdvB()
	{
		xReLXRqoDCNUkVraDkxZoEUHpFYT = new LocalizedString();
		aeMqzFsasKbbWHHnyzWoLffKJVIBA = new Dictionary<int, List<BKckUJBjHlyNjLMNcSvupioWhbq>>();
	}

	protected CrEdIhdRuEefdCHiQoLwiMECdkdvB(gDrCmzJNXwFvGTMAYKGQspUqeYD P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		DVbrjmqfkNTYbLVWiRTqaEDitQaO = P_0;
	}

	public void ejeFbwGIxeayeqIPgvoDbHsqwDGGA()
	{
		EOsBMvgyLZkglvtZbrXbItvVoQpDb();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			fsJzDjYGZNEsXoOdrgfUlDksvlUG();
		}
	}

	protected virtual void EOsBMvgyLZkglvtZbrXbItvVoQpDb()
	{
		UCSkcNrKdqaNcHPPxWSMyDHniNEK();
		jvQfGRmIEUzWNCSwhlusRDAfCCjdA();
		LocalizationManager.Add(this, ref adesacVtAZHjUFgKTsQNalaAFaiW);
		ioVFppHlthGPwcIAMNLvKiakpQLHA = true;
	}

	public virtual void UCSkcNrKdqaNcHPPxWSMyDHniNEK()
	{
		fYXugwwcuInxCcvEfNIGnrIJqcf();
		LocalizationManager.Remove(ref adesacVtAZHjUFgKTsQNalaAFaiW);
		ioVFppHlthGPwcIAMNLvKiakpQLHA = false;
	}

	public virtual void GDNPdTRkvkcYBsFVTOaYnLSpXXKh(gDrCmzJNXwFvGTMAYKGQspUqeYD P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != DVbrjmqfkNTYbLVWiRTqaEDitQaO)
		{
			if (DVbrjmqfkNTYbLVWiRTqaEDitQaO != null)
			{
				fYXugwwcuInxCcvEfNIGnrIJqcf();
			}
			DVbrjmqfkNTYbLVWiRTqaEDitQaO = P_0;
			ejeFbwGIxeayeqIPgvoDbHsqwDGGA();
		}
	}

	public virtual void nSsfNaXHvQVyfjDkGwnFvNcSnmvb()
	{
		xReLXRqoDCNUkVraDkxZoEUHpFYT.Clear();
	}

	public virtual void wmroSGiryndOGMmBfWDEbJMKrRBv()
	{
		xReLXRqoDCNUkVraDkxZoEUHpFYT.Clear();
	}

	public virtual void TebLFfuNscsSdmSSCRmDmNccAdoF()
	{
		xReLXRqoDCNUkVraDkxZoEUHpFYT.Clear();
	}

	public virtual bool QlMvYOrrkGobkvjoAMgNaIOEePwJA(CrEdIhdRuEefdCHiQoLwiMECdkdvB P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (DVbrjmqfkNTYbLVWiRTqaEDitQaO == null != (P_0.DVbrjmqfkNTYbLVWiRTqaEDitQaO == null))
		{
			return false;
		}
		if (DVbrjmqfkNTYbLVWiRTqaEDitQaO != null)
		{
			if (!string.Equals(DVbrjmqfkNTYbLVWiRTqaEDitQaO.keyCategory, P_0.DVbrjmqfkNTYbLVWiRTqaEDitQaO.keyCategory, StringComparison.Ordinal) || !string.Equals(DVbrjmqfkNTYbLVWiRTqaEDitQaO.scriptingName, P_0.DVbrjmqfkNTYbLVWiRTqaEDitQaO.scriptingName, StringComparison.Ordinal) || !string.Equals(DVbrjmqfkNTYbLVWiRTqaEDitQaO.key, P_0.DVbrjmqfkNTYbLVWiRTqaEDitQaO.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(DVbrjmqfkNTYbLVWiRTqaEDitQaO.nonLocalizedDescriptiveName, P_0.DVbrjmqfkNTYbLVWiRTqaEDitQaO.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void fYXugwwcuInxCcvEfNIGnrIJqcf()
	{
		xReLXRqoDCNUkVraDkxZoEUHpFYT.Clear();
		aeMqzFsasKbbWHHnyzWoLffKJVIBA.Clear();
	}

	protected gDrCmzJNXwFvGTMAYKGQspUqeYD qUiJUHBRFEvMwwcmkRXSpLZcYrJm()
	{
		return DVbrjmqfkNTYbLVWiRTqaEDitQaO;
	}

	protected virtual void fsJzDjYGZNEsXoOdrgfUlDksvlUG()
	{
		_ = LoGZqdROKyuYHJXdnhuxPciDQjeL;
	}

	void nYVWMTKfnKjTqnJzQqfdswXfeTcY.Localize()
	{
		fsJzDjYGZNEsXoOdrgfUlDksvlUG();
	}

	protected virtual void syiGaqDjCDHGvEfcaAPFXYWuRyyVA(int P_0)
	{
	}

	protected virtual void jvQfGRmIEUzWNCSwhlusRDAfCCjdA()
	{
	}

	protected virtual void nUmRSnqJXLfZyjJvcbTdXNBpBiEX(int P_0, BKckUJBjHlyNjLMNcSvupioWhbq P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!aeMqzFsasKbbWHHnyzWoLffKJVIBA.TryGetValue(num, out var value))
				{
					value = new List<BKckUJBjHlyNjLMNcSvupioWhbq>();
					aeMqzFsasKbbWHHnyzWoLffKJVIBA[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void xEcbIGVGGTSFZjibHIsqGCqnILrC(int P_0, BKckUJBjHlyNjLMNcSvupioWhbq P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !aeMqzFsasKbbWHHnyzWoLffKJVIBA.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (BKckUJBjHlyNjLMNcSvupioWhbq.XiEhnEEVOlbkNwLBZxbBDJQBcOJO(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void ZHfrtfTBXdLnGOfNRdLnBGkKHMRQ(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !aeMqzFsasKbbWHHnyzWoLffKJVIBA.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].qgVDeAEkFdUtVgYlhFXwAjAVYpXv != 0)
				{
					syiGaqDjCDHGvEfcaAPFXYWuRyyVA(value[j].qgVDeAEkFdUtVgYlhFXwAjAVYpXv);
				}
				if (value[j].DjGcOGzVTgfPpfASudPfdptdepSkA != null)
				{
					value[j].DjGcOGzVTgfPpfASudPfdptdepSkA.Clear();
				}
			}
		}
	}
}
