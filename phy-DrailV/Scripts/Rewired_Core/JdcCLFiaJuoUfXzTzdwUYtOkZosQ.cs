using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class JdcCLFiaJuoUfXzTzdwUYtOkZosQ : gPdbPvViIcfmuVJElIIVfiLqZVrDA
{
	protected struct WkflcJKKhlDFbBrbgxTHkqcdvDwd : IEquatable<WkflcJKKhlDFbBrbgxTHkqcdvDwd>
	{
		public LocalizedString LTGLdhEbjhgPoerZJGmVXTZoYKUIA;

		public int bEObyXQRTpcIEjHdzVovOMlzkufCA;

		public WkflcJKKhlDFbBrbgxTHkqcdvDwd(LocalizedString P_0, int P_1)
		{
			LTGLdhEbjhgPoerZJGmVXTZoYKUIA = P_0;
			bEObyXQRTpcIEjHdzVovOMlzkufCA = P_1;
		}

		public bool gEZzHVTSbDWAkBDNwKSzaMrNdeacA(object P_0)
		{
			if (!(P_0 is WkflcJKKhlDFbBrbgxTHkqcdvDwd wkflcJKKhlDFbBrbgxTHkqcdvDwd))
			{
				return false;
			}
			if (wkflcJKKhlDFbBrbgxTHkqcdvDwd.LTGLdhEbjhgPoerZJGmVXTZoYKUIA == LTGLdhEbjhgPoerZJGmVXTZoYKUIA)
			{
				return wkflcJKKhlDFbBrbgxTHkqcdvDwd.bEObyXQRTpcIEjHdzVovOMlzkufCA == bEObyXQRTpcIEjHdzVovOMlzkufCA;
			}
			return false;
		}

		public int OUGUbLMNttjKmzEBoSdMtBkhdBDR()
		{
			return (17 * 29 + LTGLdhEbjhgPoerZJGmVXTZoYKUIA.GetHashCode()) * 29 + bEObyXQRTpcIEjHdzVovOMlzkufCA.GetHashCode();
		}

		public bool Equals(WkflcJKKhlDFbBrbgxTHkqcdvDwd other)
		{
			if (LTGLdhEbjhgPoerZJGmVXTZoYKUIA == other.LTGLdhEbjhgPoerZJGmVXTZoYKUIA)
			{
				return bEObyXQRTpcIEjHdzVovOMlzkufCA == other.bEObyXQRTpcIEjHdzVovOMlzkufCA;
			}
			return false;
		}

		[SpecialName]
		public static bool vdnDEStJwzgDPNDdxCDXqtnrouxE(WkflcJKKhlDFbBrbgxTHkqcdvDwd P_0, WkflcJKKhlDFbBrbgxTHkqcdvDwd P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool ZgZSZRyMUzENffqUWKcCdKJsPzMs(WkflcJKKhlDFbBrbgxTHkqcdvDwd P_0, WkflcJKKhlDFbBrbgxTHkqcdvDwd P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private jtAeQMwqfCHdCmeHvhaRCqwDmBxb CLFHWOuPSRLahPSSrSHZoiqMbYrk;

	protected readonly LocalizedString pBHGSdiKqWIcVIxiLTzkoXwKRJelA;

	private Id BMmCqjLBHrboGKEEzSbNzygvlqXwA;

	private readonly Dictionary<int, List<WkflcJKKhlDFbBrbgxTHkqcdvDwd>> iHBceenvrwiBiITHsrPEqOxcPMeG;

	private bool UKOJIKREswByZtkIQEUQJcfFaZxF;

	protected bool DlyzgeEtPbGSRivIvEmZhBSIEqiU => UKOJIKREswByZtkIQEUQJcfFaZxF;

	public abstract string jXwgbYbEpdqHGeBdCbXEcskUaWaFA { get; }

	protected JdcCLFiaJuoUfXzTzdwUYtOkZosQ()
	{
		pBHGSdiKqWIcVIxiLTzkoXwKRJelA = new LocalizedString();
		iHBceenvrwiBiITHsrPEqOxcPMeG = new Dictionary<int, List<WkflcJKKhlDFbBrbgxTHkqcdvDwd>>();
	}

	protected JdcCLFiaJuoUfXzTzdwUYtOkZosQ(jtAeQMwqfCHdCmeHvhaRCqwDmBxb P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		CLFHWOuPSRLahPSSrSHZoiqMbYrk = P_0;
	}

	public void TlzckGoQDITHcUYaslQXPQBOhTwq()
	{
		izqgVCmGioijeoXrjYwAEVccIJMK();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			KMlMwaGRrxQYwdSiVNXyPVZXKreA();
		}
	}

	protected virtual void izqgVCmGioijeoXrjYwAEVccIJMK()
	{
		kyWIlHEmRhbwWcOOzxXKRMJIXukt();
		IOIteHoWYMIdXUPYMcUTgwJmPXpoA();
		LocalizationManager.Add(this, ref BMmCqjLBHrboGKEEzSbNzygvlqXwA);
		UKOJIKREswByZtkIQEUQJcfFaZxF = true;
	}

	public virtual void kyWIlHEmRhbwWcOOzxXKRMJIXukt()
	{
		wJjPIIRJfHhEbGedUconecGfiwzgB();
		LocalizationManager.Remove(ref BMmCqjLBHrboGKEEzSbNzygvlqXwA);
		UKOJIKREswByZtkIQEUQJcfFaZxF = false;
	}

	public virtual void yCbnuYjPdoDSWlofAupfOuHlfNOG(jtAeQMwqfCHdCmeHvhaRCqwDmBxb P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != CLFHWOuPSRLahPSSrSHZoiqMbYrk)
		{
			if (CLFHWOuPSRLahPSSrSHZoiqMbYrk != null)
			{
				wJjPIIRJfHhEbGedUconecGfiwzgB();
			}
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = P_0;
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}
	}

	public virtual void ijtdeCdNfQFeopbwLHgQcRDjMsVz()
	{
		pBHGSdiKqWIcVIxiLTzkoXwKRJelA.Clear();
	}

	public virtual void OXcBXtPnTqYHpiucqKbwxkVzPkjf()
	{
		pBHGSdiKqWIcVIxiLTzkoXwKRJelA.Clear();
	}

	public virtual void dsySnzlaDCdVTBdBHhqcOjWsSalGA()
	{
		pBHGSdiKqWIcVIxiLTzkoXwKRJelA.Clear();
	}

	public virtual bool TUibHCXgdJpNwgxVPYRazOMZLYAI(JdcCLFiaJuoUfXzTzdwUYtOkZosQ P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (CLFHWOuPSRLahPSSrSHZoiqMbYrk == null != (P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk == null))
		{
			return false;
		}
		if (CLFHWOuPSRLahPSSrSHZoiqMbYrk != null)
		{
			if (!string.Equals(CLFHWOuPSRLahPSSrSHZoiqMbYrk.keyCategory, P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk.keyCategory, StringComparison.Ordinal) || !string.Equals(CLFHWOuPSRLahPSSrSHZoiqMbYrk.scriptingName, P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk.scriptingName, StringComparison.Ordinal) || !string.Equals(CLFHWOuPSRLahPSSrSHZoiqMbYrk.key, P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(CLFHWOuPSRLahPSSrSHZoiqMbYrk.nonLocalizedDescriptiveName, P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		pBHGSdiKqWIcVIxiLTzkoXwKRJelA.Clear();
		iHBceenvrwiBiITHsrPEqOxcPMeG.Clear();
	}

	protected jtAeQMwqfCHdCmeHvhaRCqwDmBxb jfPgAiHCXDOsCqPqzSwgbROIKKdw()
	{
		return CLFHWOuPSRLahPSSrSHZoiqMbYrk;
	}

	protected virtual void KMlMwaGRrxQYwdSiVNXyPVZXKreA()
	{
		_ = jXwgbYbEpdqHGeBdCbXEcskUaWaFA;
	}

	void gPdbPvViIcfmuVJElIIVfiLqZVrDA.Localize()
	{
		KMlMwaGRrxQYwdSiVNXyPVZXKreA();
	}

	protected virtual void LiXAHjDsSjcjuheRSvInddHJDOVCA(int P_0)
	{
	}

	protected virtual void IOIteHoWYMIdXUPYMcUTgwJmPXpoA()
	{
	}

	protected virtual void hdKvZSMBobFalOMlTkDjSeXHEDLKA(int P_0, WkflcJKKhlDFbBrbgxTHkqcdvDwd P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!iHBceenvrwiBiITHsrPEqOxcPMeG.TryGetValue(num, out var value))
				{
					value = new List<WkflcJKKhlDFbBrbgxTHkqcdvDwd>();
					iHBceenvrwiBiITHsrPEqOxcPMeG[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void skAbmUhWGuZkutVnXmaWBFZFkKpic(int P_0, WkflcJKKhlDFbBrbgxTHkqcdvDwd P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !iHBceenvrwiBiITHsrPEqOxcPMeG.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (WkflcJKKhlDFbBrbgxTHkqcdvDwd.vdnDEStJwzgDPNDdxCDXqtnrouxE(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void UADvwlynuwapiHLmAmTBEEeQFLafA(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !iHBceenvrwiBiITHsrPEqOxcPMeG.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].bEObyXQRTpcIEjHdzVovOMlzkufCA != 0)
				{
					LiXAHjDsSjcjuheRSvInddHJDOVCA(value[j].bEObyXQRTpcIEjHdzVovOMlzkufCA);
				}
				if (value[j].LTGLdhEbjhgPoerZJGmVXTZoYKUIA != null)
				{
					value[j].LTGLdhEbjhgPoerZJGmVXTZoYKUIA.Clear();
				}
			}
		}
	}
}
