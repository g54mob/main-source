using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class tSkGCPxidsRshBOpBnQicfGGOeto : IPrefetch
{
	protected struct dLGaeuATPVHVASryTWPoHITyuTipA : IEquatable<dLGaeuATPVHVASryTWPoHITyuTipA>
	{
		public KeyedGlyph FAjCKlDimUZZNmVvyPdWiFiLMaeY;

		public int bEYYvCUFiINsHfMvATuCvkeJyrZS;

		public dLGaeuATPVHVASryTWPoHITyuTipA(KeyedGlyph P_0, int P_1)
		{
			FAjCKlDimUZZNmVvyPdWiFiLMaeY = P_0;
			bEYYvCUFiINsHfMvATuCvkeJyrZS = P_1;
		}

		public bool wjpBXXEPaYNqRWiQZFXQvlGcWIkF(object P_0)
		{
			if (!(P_0 is dLGaeuATPVHVASryTWPoHITyuTipA dLGaeuATPVHVASryTWPoHITyuTipA2))
			{
				return false;
			}
			if (dLGaeuATPVHVASryTWPoHITyuTipA2.FAjCKlDimUZZNmVvyPdWiFiLMaeY == FAjCKlDimUZZNmVvyPdWiFiLMaeY)
			{
				return dLGaeuATPVHVASryTWPoHITyuTipA2.bEYYvCUFiINsHfMvATuCvkeJyrZS == bEYYvCUFiINsHfMvATuCvkeJyrZS;
			}
			return false;
		}

		public int tHWlBRyQWrQwimBRsmJDyKlcEitGA()
		{
			return (17 * 29 + FAjCKlDimUZZNmVvyPdWiFiLMaeY.GetHashCode()) * 29 + bEYYvCUFiINsHfMvATuCvkeJyrZS.GetHashCode();
		}

		public bool Equals(dLGaeuATPVHVASryTWPoHITyuTipA other)
		{
			if (FAjCKlDimUZZNmVvyPdWiFiLMaeY == other.FAjCKlDimUZZNmVvyPdWiFiLMaeY)
			{
				return bEYYvCUFiINsHfMvATuCvkeJyrZS == other.bEYYvCUFiINsHfMvATuCvkeJyrZS;
			}
			return false;
		}

		bool IEquatable<dLGaeuATPVHVASryTWPoHITyuTipA>.Equals(dLGaeuATPVHVASryTWPoHITyuTipA other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool FsMMOweQxPUGCOOKPSHZpiIhcaRBA(dLGaeuATPVHVASryTWPoHITyuTipA P_0, dLGaeuATPVHVASryTWPoHITyuTipA P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool roTfOloNXOIAoQcqrQPJXUdsuHmd(dLGaeuATPVHVASryTWPoHITyuTipA P_0, dLGaeuATPVHVASryTWPoHITyuTipA P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private vfRBokPaPPEWJRenHDjJaOGZJkR jziWeqgBnQzryVqkSwmRGcDpOneE;

	protected readonly KeyedGlyph bNARKGXMIlcRIcXZjrxJAYKVesTO;

	private Id JnTPBsrGuwHGXKiGWjVBclfpGVcAb;

	private readonly Dictionary<int, List<dLGaeuATPVHVASryTWPoHITyuTipA>> ZjAHofaihkBTcYCOqCsXaEyLXFHH;

	private bool hwQfYsccbrmByAWyppHHjNxrgqVb;

	protected bool DShLcvvuuZpkPXiNebrPPVJOaxgs => hwQfYsccbrmByAWyppHHjNxrgqVb;

	public abstract object jwZyctvWJoSKAGduMIqPWqlcniZh { get; }

	public abstract string wMJOQsCSAeFAdwAuPcLuBvPnqplR { get; }

	protected tSkGCPxidsRshBOpBnQicfGGOeto()
	{
		bNARKGXMIlcRIcXZjrxJAYKVesTO = new KeyedGlyph();
		ZjAHofaihkBTcYCOqCsXaEyLXFHH = new Dictionary<int, List<dLGaeuATPVHVASryTWPoHITyuTipA>>();
	}

	protected tSkGCPxidsRshBOpBnQicfGGOeto(vfRBokPaPPEWJRenHDjJaOGZJkR P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		jziWeqgBnQzryVqkSwmRGcDpOneE = P_0;
	}

	public void jeWHxkqDoSyblDHEDmjJjFYBaowk()
	{
		qMHZgkJbhuOoCyGSmauehMMblTJT();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			DvBuhkbmxtOGnvpgTZDWNzIWvVT();
		}
	}

	protected virtual void qMHZgkJbhuOoCyGSmauehMMblTJT()
	{
		jOwcAbvcJbaOdUcVWVDStMxxdCAZ();
		YijtjFaCmrwaOLqaAFCaAKVpVuDMA();
		GlyphManager.Add(this, ref JnTPBsrGuwHGXKiGWjVBclfpGVcAb);
		hwQfYsccbrmByAWyppHHjNxrgqVb = true;
	}

	public virtual void jOwcAbvcJbaOdUcVWVDStMxxdCAZ()
	{
		JuNJbFqIdXjjqrIFQPfBwQtFyGcG();
		GlyphManager.Remove(ref JnTPBsrGuwHGXKiGWjVBclfpGVcAb);
		hwQfYsccbrmByAWyppHHjNxrgqVb = false;
	}

	public virtual void wrVdvyaMppSpOxPfMIMhdQJhfgZHA(vfRBokPaPPEWJRenHDjJaOGZJkR P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != jziWeqgBnQzryVqkSwmRGcDpOneE)
		{
			if (jziWeqgBnQzryVqkSwmRGcDpOneE != null)
			{
				JuNJbFqIdXjjqrIFQPfBwQtFyGcG();
			}
			jziWeqgBnQzryVqkSwmRGcDpOneE = P_0;
			jeWHxkqDoSyblDHEDmjJjFYBaowk();
		}
	}

	public virtual void BNGypuCJMYqPcFgMFgCNgiZTDWDgA()
	{
		bNARKGXMIlcRIcXZjrxJAYKVesTO.Clear();
	}

	public virtual bool SMKsDLNZUiOtugRfjQZesesScvJe(tSkGCPxidsRshBOpBnQicfGGOeto P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (jziWeqgBnQzryVqkSwmRGcDpOneE == null != (P_0.jziWeqgBnQzryVqkSwmRGcDpOneE == null))
		{
			return false;
		}
		if (jziWeqgBnQzryVqkSwmRGcDpOneE != null && (!string.Equals(jziWeqgBnQzryVqkSwmRGcDpOneE.keyCategory, P_0.jziWeqgBnQzryVqkSwmRGcDpOneE.keyCategory, StringComparison.Ordinal) || !string.Equals(jziWeqgBnQzryVqkSwmRGcDpOneE.key, P_0.jziWeqgBnQzryVqkSwmRGcDpOneE.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void JuNJbFqIdXjjqrIFQPfBwQtFyGcG()
	{
		bNARKGXMIlcRIcXZjrxJAYKVesTO.Clear();
		ZjAHofaihkBTcYCOqCsXaEyLXFHH.Clear();
	}

	protected vfRBokPaPPEWJRenHDjJaOGZJkR SCQsEZHFBGaOGHdrLNaADiCIdlJUB()
	{
		return jziWeqgBnQzryVqkSwmRGcDpOneE;
	}

	protected virtual void DvBuhkbmxtOGnvpgTZDWNzIWvVT()
	{
		_ = jwZyctvWJoSKAGduMIqPWqlcniZh;
	}

	void IPrefetch.Prefetch()
	{
		DvBuhkbmxtOGnvpgTZDWNzIWvVT();
	}

	protected virtual void AaTcTKHdnXRoVukWiLjbHWyeNxwpA(int P_0)
	{
	}

	protected virtual void YijtjFaCmrwaOLqaAFCaAKVpVuDMA()
	{
	}

	protected virtual void HOpcQSeuuNAfGMIjSqLRfSQlBZpmA(int P_0, dLGaeuATPVHVASryTWPoHITyuTipA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!ZjAHofaihkBTcYCOqCsXaEyLXFHH.TryGetValue(num, out var value))
				{
					value = new List<dLGaeuATPVHVASryTWPoHITyuTipA>();
					ZjAHofaihkBTcYCOqCsXaEyLXFHH[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void hACBEdXkhDVLHMefErOsgQMvBtfw(int P_0, dLGaeuATPVHVASryTWPoHITyuTipA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !ZjAHofaihkBTcYCOqCsXaEyLXFHH.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (dLGaeuATPVHVASryTWPoHITyuTipA.FsMMOweQxPUGCOOKPSHZpiIhcaRBA(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void khJGmLkqmPYzNLVRuANYwNIWGmgd(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !ZjAHofaihkBTcYCOqCsXaEyLXFHH.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].bEYYvCUFiINsHfMvATuCvkeJyrZS != 0)
				{
					AaTcTKHdnXRoVukWiLjbHWyeNxwpA(value[j].bEYYvCUFiINsHfMvATuCvkeJyrZS);
				}
				if (value[j].FAjCKlDimUZZNmVvyPdWiFiLMaeY != null)
				{
					value[j].FAjCKlDimUZZNmVvyPdWiFiLMaeY.Clear();
				}
			}
		}
	}
}
