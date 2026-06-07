using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class VNmGeGFSdUUKSjRvPzQEfrbImtru : IPrefetch
{
	protected struct ZDOHKxiITjftpRcmToJGFSyiYFok : IEquatable<ZDOHKxiITjftpRcmToJGFSyiYFok>
	{
		public KeyedGlyph QOQCmrIxdYGkZJJkjlLjSsjiCHJDA;

		public int bEObyXQRTpcIEjHdzVovOMlzkufCA;

		public ZDOHKxiITjftpRcmToJGFSyiYFok(KeyedGlyph P_0, int P_1)
		{
			QOQCmrIxdYGkZJJkjlLjSsjiCHJDA = P_0;
			bEObyXQRTpcIEjHdzVovOMlzkufCA = P_1;
		}

		public bool gEZzHVTSbDWAkBDNwKSzaMrNdeacA(object P_0)
		{
			if (!(P_0 is ZDOHKxiITjftpRcmToJGFSyiYFok zDOHKxiITjftpRcmToJGFSyiYFok))
			{
				return false;
			}
			if (zDOHKxiITjftpRcmToJGFSyiYFok.QOQCmrIxdYGkZJJkjlLjSsjiCHJDA == QOQCmrIxdYGkZJJkjlLjSsjiCHJDA)
			{
				return zDOHKxiITjftpRcmToJGFSyiYFok.bEObyXQRTpcIEjHdzVovOMlzkufCA == bEObyXQRTpcIEjHdzVovOMlzkufCA;
			}
			return false;
		}

		public int OUGUbLMNttjKmzEBoSdMtBkhdBDR()
		{
			return (17 * 29 + QOQCmrIxdYGkZJJkjlLjSsjiCHJDA.GetHashCode()) * 29 + bEObyXQRTpcIEjHdzVovOMlzkufCA.GetHashCode();
		}

		public bool Equals(ZDOHKxiITjftpRcmToJGFSyiYFok other)
		{
			if (QOQCmrIxdYGkZJJkjlLjSsjiCHJDA == other.QOQCmrIxdYGkZJJkjlLjSsjiCHJDA)
			{
				return bEObyXQRTpcIEjHdzVovOMlzkufCA == other.bEObyXQRTpcIEjHdzVovOMlzkufCA;
			}
			return false;
		}

		[SpecialName]
		public static bool vdnDEStJwzgDPNDdxCDXqtnrouxE(ZDOHKxiITjftpRcmToJGFSyiYFok P_0, ZDOHKxiITjftpRcmToJGFSyiYFok P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool ZgZSZRyMUzENffqUWKcCdKJsPzMs(ZDOHKxiITjftpRcmToJGFSyiYFok P_0, ZDOHKxiITjftpRcmToJGFSyiYFok P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private LFxfRtFXyxgAjxbmpHDNQNxOPKov CLFHWOuPSRLahPSSrSHZoiqMbYrk;

	protected readonly KeyedGlyph JALtjzLAfYjDcRrTEIAEmeFwxGEN;

	private Id BMmCqjLBHrboGKEEzSbNzygvlqXwA;

	private readonly Dictionary<int, List<ZDOHKxiITjftpRcmToJGFSyiYFok>> iHBceenvrwiBiITHsrPEqOxcPMeG;

	private bool UKOJIKREswByZtkIQEUQJcfFaZxF;

	protected bool DlyzgeEtPbGSRivIvEmZhBSIEqiU => UKOJIKREswByZtkIQEUQJcfFaZxF;

	public abstract object OVQhivfSVMBpQMWuxTSgKFUzmyCh { get; }

	public abstract string BgDsdJaeWVGoMCQvooPYEudaIQDRB { get; }

	protected VNmGeGFSdUUKSjRvPzQEfrbImtru()
	{
		JALtjzLAfYjDcRrTEIAEmeFwxGEN = new KeyedGlyph();
		iHBceenvrwiBiITHsrPEqOxcPMeG = new Dictionary<int, List<ZDOHKxiITjftpRcmToJGFSyiYFok>>();
	}

	protected VNmGeGFSdUUKSjRvPzQEfrbImtru(LFxfRtFXyxgAjxbmpHDNQNxOPKov P_0)
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
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			kakEANoxNEASOrgsQDjgagRjuxdPA();
		}
	}

	protected virtual void izqgVCmGioijeoXrjYwAEVccIJMK()
	{
		kyWIlHEmRhbwWcOOzxXKRMJIXukt();
		IOIteHoWYMIdXUPYMcUTgwJmPXpoA();
		GlyphManager.Add(this, ref BMmCqjLBHrboGKEEzSbNzygvlqXwA);
		UKOJIKREswByZtkIQEUQJcfFaZxF = true;
	}

	public virtual void kyWIlHEmRhbwWcOOzxXKRMJIXukt()
	{
		wJjPIIRJfHhEbGedUconecGfiwzgB();
		GlyphManager.Remove(ref BMmCqjLBHrboGKEEzSbNzygvlqXwA);
		UKOJIKREswByZtkIQEUQJcfFaZxF = false;
	}

	public virtual void yCbnuYjPdoDSWlofAupfOuHlfNOG(LFxfRtFXyxgAjxbmpHDNQNxOPKov P_0)
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

	public virtual void OXcBXtPnTqYHpiucqKbwxkVzPkjf()
	{
		JALtjzLAfYjDcRrTEIAEmeFwxGEN.Clear();
	}

	public virtual bool TUibHCXgdJpNwgxVPYRazOMZLYAI(VNmGeGFSdUUKSjRvPzQEfrbImtru P_0)
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
		if (CLFHWOuPSRLahPSSrSHZoiqMbYrk != null && (!string.Equals(CLFHWOuPSRLahPSSrSHZoiqMbYrk.keyCategory, P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk.keyCategory, StringComparison.Ordinal) || !string.Equals(CLFHWOuPSRLahPSSrSHZoiqMbYrk.key, P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		JALtjzLAfYjDcRrTEIAEmeFwxGEN.Clear();
		iHBceenvrwiBiITHsrPEqOxcPMeG.Clear();
	}

	protected LFxfRtFXyxgAjxbmpHDNQNxOPKov jfPgAiHCXDOsCqPqzSwgbROIKKdw()
	{
		return CLFHWOuPSRLahPSSrSHZoiqMbYrk;
	}

	protected virtual void kakEANoxNEASOrgsQDjgagRjuxdPA()
	{
		_ = OVQhivfSVMBpQMWuxTSgKFUzmyCh;
	}

	void IPrefetch.Prefetch()
	{
		kakEANoxNEASOrgsQDjgagRjuxdPA();
	}

	protected virtual void LiXAHjDsSjcjuheRSvInddHJDOVCA(int P_0)
	{
	}

	protected virtual void IOIteHoWYMIdXUPYMcUTgwJmPXpoA()
	{
	}

	protected virtual void hdKvZSMBobFalOMlTkDjSeXHEDLKA(int P_0, ZDOHKxiITjftpRcmToJGFSyiYFok P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!iHBceenvrwiBiITHsrPEqOxcPMeG.TryGetValue(num, out var value))
				{
					value = new List<ZDOHKxiITjftpRcmToJGFSyiYFok>();
					iHBceenvrwiBiITHsrPEqOxcPMeG[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void skAbmUhWGuZkutVnXmaWBFZFkKpic(int P_0, ZDOHKxiITjftpRcmToJGFSyiYFok P_1)
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
				if (ZDOHKxiITjftpRcmToJGFSyiYFok.vdnDEStJwzgDPNDdxCDXqtnrouxE(value[num2], P_1))
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
				if (value[j].QOQCmrIxdYGkZJJkjlLjSsjiCHJDA != null)
				{
					value[j].QOQCmrIxdYGkZJJkjlLjSsjiCHJDA.Clear();
				}
			}
		}
	}
}
