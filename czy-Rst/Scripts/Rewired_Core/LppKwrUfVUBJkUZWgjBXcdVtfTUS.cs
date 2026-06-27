using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class LppKwrUfVUBJkUZWgjBXcdVtfTUS : goyuORzVCSsvhefHsgPEBCMfboVoA
{
	protected struct YZnlcOeKAPoAAuserPoAYphkWGQw : IEquatable<YZnlcOeKAPoAAuserPoAYphkWGQw>
	{
		public LocalizedString AXfBaIhEmyMRigckhEzKRLsOfWfHc;

		public int bcwuDMDWijTVGHxFXvoBqeHTaKiM;

		public YZnlcOeKAPoAAuserPoAYphkWGQw(LocalizedString P_0, int P_1)
		{
			AXfBaIhEmyMRigckhEzKRLsOfWfHc = P_0;
			bcwuDMDWijTVGHxFXvoBqeHTaKiM = P_1;
		}

		public bool XknIjDFCLXbSYawViXnPSnyaGakM(object P_0)
		{
			if (!(P_0 is YZnlcOeKAPoAAuserPoAYphkWGQw yZnlcOeKAPoAAuserPoAYphkWGQw))
			{
				return false;
			}
			if (yZnlcOeKAPoAAuserPoAYphkWGQw.AXfBaIhEmyMRigckhEzKRLsOfWfHc == AXfBaIhEmyMRigckhEzKRLsOfWfHc)
			{
				return yZnlcOeKAPoAAuserPoAYphkWGQw.bcwuDMDWijTVGHxFXvoBqeHTaKiM == bcwuDMDWijTVGHxFXvoBqeHTaKiM;
			}
			return false;
		}

		public int QIUDNVHbutHJijWnMzIgTdejyewaA()
		{
			return (17 * 29 + AXfBaIhEmyMRigckhEzKRLsOfWfHc.GetHashCode()) * 29 + bcwuDMDWijTVGHxFXvoBqeHTaKiM.GetHashCode();
		}

		public bool Equals(YZnlcOeKAPoAAuserPoAYphkWGQw other)
		{
			if (AXfBaIhEmyMRigckhEzKRLsOfWfHc == other.AXfBaIhEmyMRigckhEzKRLsOfWfHc)
			{
				return bcwuDMDWijTVGHxFXvoBqeHTaKiM == other.bcwuDMDWijTVGHxFXvoBqeHTaKiM;
			}
			return false;
		}

		bool IEquatable<YZnlcOeKAPoAAuserPoAYphkWGQw>.Equals(YZnlcOeKAPoAAuserPoAYphkWGQw other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool MQnnlIvlidEpWdrFvHqctNuFrEwd(YZnlcOeKAPoAAuserPoAYphkWGQw P_0, YZnlcOeKAPoAAuserPoAYphkWGQw P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool mAeDXGnQujPDmciLLgCmDFJFMxKi(YZnlcOeKAPoAAuserPoAYphkWGQw P_0, YZnlcOeKAPoAAuserPoAYphkWGQw P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private leeNpeIpkRWAaDYnewmtyKpQcRpw CDSnwwBReDoJgOclUvXVAQnyzyFD;

	protected readonly LocalizedString emHVZONsYrynZSEjcDgeCDhHqttB;

	private Id xVNcGgozpJLqZQudfmCyCrMULFBG;

	private readonly Dictionary<int, List<YZnlcOeKAPoAAuserPoAYphkWGQw>> hAfhsZNHfYXiDIRNOsDDPwFYqkhe;

	private bool tJuhehwjQlfnhDPomlyYOghcdLkH;

	protected bool TOobdfzwKXpykUqhHfSiEudxcfZi => tJuhehwjQlfnhDPomlyYOghcdLkH;

	public abstract string YYpaixksduwqUQfFFmPUzWfHjhDu { get; }

	protected LppKwrUfVUBJkUZWgjBXcdVtfTUS()
	{
		emHVZONsYrynZSEjcDgeCDhHqttB = new LocalizedString();
		hAfhsZNHfYXiDIRNOsDDPwFYqkhe = new Dictionary<int, List<YZnlcOeKAPoAAuserPoAYphkWGQw>>();
	}

	protected LppKwrUfVUBJkUZWgjBXcdVtfTUS(leeNpeIpkRWAaDYnewmtyKpQcRpw P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		CDSnwwBReDoJgOclUvXVAQnyzyFD = P_0;
	}

	public void vtJxVkbxQgQVbPknOGkynGbiyVxG()
	{
		VYBYejVSaBMrimVrXfEODZmJvEUk();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			oHuRhhpJfZCiQxskDQUbJrlwERnK();
		}
	}

	protected virtual void VYBYejVSaBMrimVrXfEODZmJvEUk()
	{
		LhzfaLGzSuAEbSnzPLunMZEfWZvQ();
		mihKjZDhhUkcOPuQLYqTvHJntkEi();
		LocalizationManager.Add(this, ref xVNcGgozpJLqZQudfmCyCrMULFBG);
		tJuhehwjQlfnhDPomlyYOghcdLkH = true;
	}

	public virtual void LhzfaLGzSuAEbSnzPLunMZEfWZvQ()
	{
		wFfoRsDxLwNowTPNgDVrqLmCaiRN();
		LocalizationManager.Remove(ref xVNcGgozpJLqZQudfmCyCrMULFBG);
		tJuhehwjQlfnhDPomlyYOghcdLkH = false;
	}

	public virtual void LGwfJRmzAybEYrAflsatLfLhagnEA(leeNpeIpkRWAaDYnewmtyKpQcRpw P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != CDSnwwBReDoJgOclUvXVAQnyzyFD)
		{
			if (CDSnwwBReDoJgOclUvXVAQnyzyFD != null)
			{
				wFfoRsDxLwNowTPNgDVrqLmCaiRN();
			}
			CDSnwwBReDoJgOclUvXVAQnyzyFD = P_0;
			vtJxVkbxQgQVbPknOGkynGbiyVxG();
		}
	}

	public virtual void sOnpvTwKynHrpiShYVQEZXEQqQDP()
	{
		emHVZONsYrynZSEjcDgeCDhHqttB.Clear();
	}

	public virtual void rGfGCTURtYyLPalJfxlbNDAOsgNA()
	{
		emHVZONsYrynZSEjcDgeCDhHqttB.Clear();
	}

	public virtual void GvKqFlBIauBSccpqkijaDCUIwlHHB()
	{
		emHVZONsYrynZSEjcDgeCDhHqttB.Clear();
	}

	public virtual bool TUhOKAWZDSFHneJYgWLgWaTMqqZh(LppKwrUfVUBJkUZWgjBXcdVtfTUS P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (CDSnwwBReDoJgOclUvXVAQnyzyFD == null != (P_0.CDSnwwBReDoJgOclUvXVAQnyzyFD == null))
		{
			return false;
		}
		if (CDSnwwBReDoJgOclUvXVAQnyzyFD != null)
		{
			if (!string.Equals(CDSnwwBReDoJgOclUvXVAQnyzyFD.keyCategory, P_0.CDSnwwBReDoJgOclUvXVAQnyzyFD.keyCategory, StringComparison.Ordinal) || !string.Equals(CDSnwwBReDoJgOclUvXVAQnyzyFD.scriptingName, P_0.CDSnwwBReDoJgOclUvXVAQnyzyFD.scriptingName, StringComparison.Ordinal) || !string.Equals(CDSnwwBReDoJgOclUvXVAQnyzyFD.key, P_0.CDSnwwBReDoJgOclUvXVAQnyzyFD.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(CDSnwwBReDoJgOclUvXVAQnyzyFD.nonLocalizedDescriptiveName, P_0.CDSnwwBReDoJgOclUvXVAQnyzyFD.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void wFfoRsDxLwNowTPNgDVrqLmCaiRN()
	{
		emHVZONsYrynZSEjcDgeCDhHqttB.Clear();
		hAfhsZNHfYXiDIRNOsDDPwFYqkhe.Clear();
	}

	protected leeNpeIpkRWAaDYnewmtyKpQcRpw teLIlNgcmKaxxnoSUdIdFnYabJsF()
	{
		return CDSnwwBReDoJgOclUvXVAQnyzyFD;
	}

	protected virtual void oHuRhhpJfZCiQxskDQUbJrlwERnK()
	{
		_ = YYpaixksduwqUQfFFmPUzWfHjhDu;
	}

	void goyuORzVCSsvhefHsgPEBCMfboVoA.Localize()
	{
		oHuRhhpJfZCiQxskDQUbJrlwERnK();
	}

	protected virtual void vDXiXmAQfZsHayWOczPuqqRqFqLh(int P_0)
	{
	}

	protected virtual void mihKjZDhhUkcOPuQLYqTvHJntkEi()
	{
	}

	protected virtual void wqTWbHLiuJlbKmBHEbeWhODjBobC(int P_0, YZnlcOeKAPoAAuserPoAYphkWGQw P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!hAfhsZNHfYXiDIRNOsDDPwFYqkhe.TryGetValue(num, out var value))
				{
					value = new List<YZnlcOeKAPoAAuserPoAYphkWGQw>();
					hAfhsZNHfYXiDIRNOsDDPwFYqkhe[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void utNnxIcynZReQsaSpxkNiNRrXlUX(int P_0, YZnlcOeKAPoAAuserPoAYphkWGQw P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !hAfhsZNHfYXiDIRNOsDDPwFYqkhe.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (YZnlcOeKAPoAAuserPoAYphkWGQw.MQnnlIvlidEpWdrFvHqctNuFrEwd(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void SxOitnieunZrHDRnvKLWhqjMgpgjA(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !hAfhsZNHfYXiDIRNOsDDPwFYqkhe.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].bcwuDMDWijTVGHxFXvoBqeHTaKiM != 0)
				{
					vDXiXmAQfZsHayWOczPuqqRqFqLh(value[j].bcwuDMDWijTVGHxFXvoBqeHTaKiM);
				}
				if (value[j].AXfBaIhEmyMRigckhEzKRLsOfWfHc != null)
				{
					value[j].AXfBaIhEmyMRigckhEzKRLsOfWfHc.Clear();
				}
			}
		}
	}
}
