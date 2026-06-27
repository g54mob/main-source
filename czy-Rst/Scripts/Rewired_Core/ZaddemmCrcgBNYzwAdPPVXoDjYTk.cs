using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class ZaddemmCrcgBNYzwAdPPVXoDjYTk : IPrefetch
{
	protected struct ZrZHrHYDCTemgupLAGeHjdvzlMKK : IEquatable<ZrZHrHYDCTemgupLAGeHjdvzlMKK>
	{
		public KeyedGlyph fRqNjGIOcGWgldQadvwzBIACgCWw;

		public int NQDGtgVknUNfwkqmBdjTCYmEVdkc;

		public ZrZHrHYDCTemgupLAGeHjdvzlMKK(KeyedGlyph P_0, int P_1)
		{
			fRqNjGIOcGWgldQadvwzBIACgCWw = P_0;
			NQDGtgVknUNfwkqmBdjTCYmEVdkc = P_1;
		}

		public bool OusKeeNDgOFenAXtMvOzKCTbjsAuA(object P_0)
		{
			if (!(P_0 is ZrZHrHYDCTemgupLAGeHjdvzlMKK zrZHrHYDCTemgupLAGeHjdvzlMKK))
			{
				return false;
			}
			if (zrZHrHYDCTemgupLAGeHjdvzlMKK.fRqNjGIOcGWgldQadvwzBIACgCWw == fRqNjGIOcGWgldQadvwzBIACgCWw)
			{
				return zrZHrHYDCTemgupLAGeHjdvzlMKK.NQDGtgVknUNfwkqmBdjTCYmEVdkc == NQDGtgVknUNfwkqmBdjTCYmEVdkc;
			}
			return false;
		}

		public int TQZeowxbKraXInyWjOKqRNTvXMZv()
		{
			return (17 * 29 + fRqNjGIOcGWgldQadvwzBIACgCWw.GetHashCode()) * 29 + NQDGtgVknUNfwkqmBdjTCYmEVdkc.GetHashCode();
		}

		public bool Equals(ZrZHrHYDCTemgupLAGeHjdvzlMKK other)
		{
			if (fRqNjGIOcGWgldQadvwzBIACgCWw == other.fRqNjGIOcGWgldQadvwzBIACgCWw)
			{
				return NQDGtgVknUNfwkqmBdjTCYmEVdkc == other.NQDGtgVknUNfwkqmBdjTCYmEVdkc;
			}
			return false;
		}

		bool IEquatable<ZrZHrHYDCTemgupLAGeHjdvzlMKK>.Equals(ZrZHrHYDCTemgupLAGeHjdvzlMKK other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool bgJnHBrBjDizuRXREvMmCogkHUpaA(ZrZHrHYDCTemgupLAGeHjdvzlMKK P_0, ZrZHrHYDCTemgupLAGeHjdvzlMKK P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool NcQyQttjJCdbaCHdqMBoRwmfVQAuA(ZrZHrHYDCTemgupLAGeHjdvzlMKK P_0, ZrZHrHYDCTemgupLAGeHjdvzlMKK P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private VXuSsTlJoBHbugAzwdYIdycaHtQaB NtrxvDjVDAoYSQbzTDtslOSorsMW;

	protected readonly KeyedGlyph TwXbrjGSKrwyixcEmwywzByGnMbr;

	private Id tXQIaVaMyiNjtXBDBUYiAcRiRvCQ;

	private readonly Dictionary<int, List<ZrZHrHYDCTemgupLAGeHjdvzlMKK>> zyZggGbprgmwUDRDvxBkdDGAEzpVb;

	private bool HlXyYprzuxRXKBJBmdkuYbjoTUWw;

	protected bool dJeDyAcEcZBSpWSEfloeehxBqVCt => HlXyYprzuxRXKBJBmdkuYbjoTUWw;

	public abstract object DOWjBOgoZsencABrFfHqopRtxZvy { get; }

	public abstract string QfGGjPDMKogvJjFpIQxHufrcaNNt { get; }

	protected ZaddemmCrcgBNYzwAdPPVXoDjYTk()
	{
		TwXbrjGSKrwyixcEmwywzByGnMbr = new KeyedGlyph();
		zyZggGbprgmwUDRDvxBkdDGAEzpVb = new Dictionary<int, List<ZrZHrHYDCTemgupLAGeHjdvzlMKK>>();
	}

	protected ZaddemmCrcgBNYzwAdPPVXoDjYTk(VXuSsTlJoBHbugAzwdYIdycaHtQaB P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		NtrxvDjVDAoYSQbzTDtslOSorsMW = P_0;
	}

	public void FsVdsLBrXYJDJLKPABbiLAgUrSEKA()
	{
		ChGCmZdSleMbiGlTpNvJfMkgbtxcb();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			bLmUVOwGixSluchaznCmnnJJhTdw();
		}
	}

	protected virtual void ChGCmZdSleMbiGlTpNvJfMkgbtxcb()
	{
		BZdjNIkOXrChHHvALAYhGGFekwyX();
		uwSCoIvwpjFmqAdXgVZIfziOUxXA();
		GlyphManager.Add(this, ref tXQIaVaMyiNjtXBDBUYiAcRiRvCQ);
		HlXyYprzuxRXKBJBmdkuYbjoTUWw = true;
	}

	public virtual void BZdjNIkOXrChHHvALAYhGGFekwyX()
	{
		voSzyypQCVpGImGRNGGydDqSAOYvA();
		GlyphManager.Remove(ref tXQIaVaMyiNjtXBDBUYiAcRiRvCQ);
		HlXyYprzuxRXKBJBmdkuYbjoTUWw = false;
	}

	public virtual void OcYtYNxzhxSQwaOaRJuYQmbgOqtf(VXuSsTlJoBHbugAzwdYIdycaHtQaB P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != NtrxvDjVDAoYSQbzTDtslOSorsMW)
		{
			if (NtrxvDjVDAoYSQbzTDtslOSorsMW != null)
			{
				voSzyypQCVpGImGRNGGydDqSAOYvA();
			}
			NtrxvDjVDAoYSQbzTDtslOSorsMW = P_0;
			FsVdsLBrXYJDJLKPABbiLAgUrSEKA();
		}
	}

	public virtual void bENgBTTNIMNBYIKTKIBgTqbSxety()
	{
		TwXbrjGSKrwyixcEmwywzByGnMbr.Clear();
	}

	public virtual bool oYRjHeCgOqlvQrMwuJiBJiMXaGfn(ZaddemmCrcgBNYzwAdPPVXoDjYTk P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (NtrxvDjVDAoYSQbzTDtslOSorsMW == null != (P_0.NtrxvDjVDAoYSQbzTDtslOSorsMW == null))
		{
			return false;
		}
		if (NtrxvDjVDAoYSQbzTDtslOSorsMW != null && (!string.Equals(NtrxvDjVDAoYSQbzTDtslOSorsMW.keyCategory, P_0.NtrxvDjVDAoYSQbzTDtslOSorsMW.keyCategory, StringComparison.Ordinal) || !string.Equals(NtrxvDjVDAoYSQbzTDtslOSorsMW.key, P_0.NtrxvDjVDAoYSQbzTDtslOSorsMW.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void voSzyypQCVpGImGRNGGydDqSAOYvA()
	{
		TwXbrjGSKrwyixcEmwywzByGnMbr.Clear();
		zyZggGbprgmwUDRDvxBkdDGAEzpVb.Clear();
	}

	protected VXuSsTlJoBHbugAzwdYIdycaHtQaB oQVcjeUcPIxziqYkQkfxTLecSBhr()
	{
		return NtrxvDjVDAoYSQbzTDtslOSorsMW;
	}

	protected virtual void bLmUVOwGixSluchaznCmnnJJhTdw()
	{
		_ = DOWjBOgoZsencABrFfHqopRtxZvy;
	}

	void IPrefetch.Prefetch()
	{
		bLmUVOwGixSluchaznCmnnJJhTdw();
	}

	protected virtual void kEScdjuhuPPyvjVtvoHAdGslPQYC(int P_0)
	{
	}

	protected virtual void uwSCoIvwpjFmqAdXgVZIfziOUxXA()
	{
	}

	protected virtual void hZivPvpkINCzgJiHXGTipewcxIBD(int P_0, ZrZHrHYDCTemgupLAGeHjdvzlMKK P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!zyZggGbprgmwUDRDvxBkdDGAEzpVb.TryGetValue(num, out var value))
				{
					value = new List<ZrZHrHYDCTemgupLAGeHjdvzlMKK>();
					zyZggGbprgmwUDRDvxBkdDGAEzpVb[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void PRJphYKljZAgzINqDJRLLPamuRDSA(int P_0, ZrZHrHYDCTemgupLAGeHjdvzlMKK P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !zyZggGbprgmwUDRDvxBkdDGAEzpVb.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (ZrZHrHYDCTemgupLAGeHjdvzlMKK.bgJnHBrBjDizuRXREvMmCogkHUpaA(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void KwGbjejliVubzoOCfsXlDJhXdaGfA(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !zyZggGbprgmwUDRDvxBkdDGAEzpVb.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].NQDGtgVknUNfwkqmBdjTCYmEVdkc != 0)
				{
					kEScdjuhuPPyvjVtvoHAdGslPQYC(value[j].NQDGtgVknUNfwkqmBdjTCYmEVdkc);
				}
				if (value[j].fRqNjGIOcGWgldQadvwzBIACgCWw != null)
				{
					value[j].fRqNjGIOcGWgldQadvwzBIACgCWw.Clear();
				}
			}
		}
	}
}
