using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class ORSKUsFUQMFbVqzYDhEFDxAETxpN : fuTAbCyJgOZBWWgBXmUSttFWWuoi
{
	protected struct ZfSdyTfpTJoTlWfkGbXUdYyHUehp : IEquatable<ZfSdyTfpTJoTlWfkGbXUdYyHUehp>
	{
		public LocalizedString NmUmjFVjvsfeLKeuxcGWcsbAUoEx;

		public int aATlyVMZfzbInxFRkgSBZcMommTT;

		public ZfSdyTfpTJoTlWfkGbXUdYyHUehp(LocalizedString P_0, int P_1)
		{
			NmUmjFVjvsfeLKeuxcGWcsbAUoEx = P_0;
			aATlyVMZfzbInxFRkgSBZcMommTT = P_1;
		}

		public bool GROfFMKPYRarzOePTORXjFjPUFHk(object P_0)
		{
			if (!(P_0 is ZfSdyTfpTJoTlWfkGbXUdYyHUehp zfSdyTfpTJoTlWfkGbXUdYyHUehp))
			{
				return false;
			}
			if (zfSdyTfpTJoTlWfkGbXUdYyHUehp.NmUmjFVjvsfeLKeuxcGWcsbAUoEx == NmUmjFVjvsfeLKeuxcGWcsbAUoEx)
			{
				return zfSdyTfpTJoTlWfkGbXUdYyHUehp.aATlyVMZfzbInxFRkgSBZcMommTT == aATlyVMZfzbInxFRkgSBZcMommTT;
			}
			return false;
		}

		public int VbzVoQsCxprXVoCfrhiyWohMGSNg()
		{
			return (17 * 29 + NmUmjFVjvsfeLKeuxcGWcsbAUoEx.GetHashCode()) * 29 + aATlyVMZfzbInxFRkgSBZcMommTT.GetHashCode();
		}

		public bool Equals(ZfSdyTfpTJoTlWfkGbXUdYyHUehp other)
		{
			if (NmUmjFVjvsfeLKeuxcGWcsbAUoEx == other.NmUmjFVjvsfeLKeuxcGWcsbAUoEx)
			{
				return aATlyVMZfzbInxFRkgSBZcMommTT == other.aATlyVMZfzbInxFRkgSBZcMommTT;
			}
			return false;
		}

		bool IEquatable<ZfSdyTfpTJoTlWfkGbXUdYyHUehp>.Equals(ZfSdyTfpTJoTlWfkGbXUdYyHUehp other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool LOSGvPdsidJotCRnDWgkaMUoeHHWb(ZfSdyTfpTJoTlWfkGbXUdYyHUehp P_0, ZfSdyTfpTJoTlWfkGbXUdYyHUehp P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool tCJGVVceVfVbXCOaaUDgEkYeLgpQA(ZfSdyTfpTJoTlWfkGbXUdYyHUehp P_0, ZfSdyTfpTJoTlWfkGbXUdYyHUehp P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private sZLAxvZSvDRmVjMjTVRhHfujppQp TyzuxlQSORfGJwBwbeWLxgRRdNmz;

	protected readonly LocalizedString nWuWHQKnzOaKYbmQWDumXtCiKAUgb;

	private Id ggutivrPqBszogIkIhHitTcjPzev;

	private readonly Dictionary<int, List<ZfSdyTfpTJoTlWfkGbXUdYyHUehp>> ciAufICAKUbbqIqVfPVVcojrwSCCA;

	private bool qULdnmEdRfQLIyzyFkEMSlyVWPLgA;

	protected bool YTNjhucxZBUFPcapkZGsvkaAnMyM => qULdnmEdRfQLIyzyFkEMSlyVWPLgA;

	public abstract string HKQoqutKkgeGtFcRmtcKMQqgsDoY { get; }

	protected ORSKUsFUQMFbVqzYDhEFDxAETxpN()
	{
		nWuWHQKnzOaKYbmQWDumXtCiKAUgb = new LocalizedString();
		ciAufICAKUbbqIqVfPVVcojrwSCCA = new Dictionary<int, List<ZfSdyTfpTJoTlWfkGbXUdYyHUehp>>();
	}

	protected ORSKUsFUQMFbVqzYDhEFDxAETxpN(sZLAxvZSvDRmVjMjTVRhHfujppQp P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		TyzuxlQSORfGJwBwbeWLxgRRdNmz = P_0;
	}

	public void skyFfjckDgbaQKrnxTdoqMuNhEKiA()
	{
		WJgJSaKVvFKuFOPjyWQQoEbqvZtr();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			xwVhfgkgqJaUdXIocRzzcWsTaSSK();
		}
	}

	protected virtual void WJgJSaKVvFKuFOPjyWQQoEbqvZtr()
	{
		UaKaFMRjDucmUkBnymRfnLXETvWV();
		paWEUOeYeWwEdUjOyvrRqUYOiDfOA();
		LocalizationManager.Add(this, ref ggutivrPqBszogIkIhHitTcjPzev);
		qULdnmEdRfQLIyzyFkEMSlyVWPLgA = true;
	}

	public virtual void UaKaFMRjDucmUkBnymRfnLXETvWV()
	{
		xeScNvMrWqLAFnQRTFynDfdfMKqv();
		LocalizationManager.Remove(ref ggutivrPqBszogIkIhHitTcjPzev);
		qULdnmEdRfQLIyzyFkEMSlyVWPLgA = false;
	}

	public virtual void GcNXeKljLqBwpXBtANTbgsUENESW(sZLAxvZSvDRmVjMjTVRhHfujppQp P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != TyzuxlQSORfGJwBwbeWLxgRRdNmz)
		{
			if (TyzuxlQSORfGJwBwbeWLxgRRdNmz != null)
			{
				xeScNvMrWqLAFnQRTFynDfdfMKqv();
			}
			TyzuxlQSORfGJwBwbeWLxgRRdNmz = P_0;
			skyFfjckDgbaQKrnxTdoqMuNhEKiA();
		}
	}

	public virtual void jTMhRUfClbiJAQhjtilGfcBvyqwjA()
	{
		nWuWHQKnzOaKYbmQWDumXtCiKAUgb.Clear();
	}

	public virtual void yrhZMBOdOtpQsbmxygSzAaWtnMDfb()
	{
		nWuWHQKnzOaKYbmQWDumXtCiKAUgb.Clear();
	}

	public virtual void XIvHPuMcrskwDDbqHcWqpyJRLTkr()
	{
		nWuWHQKnzOaKYbmQWDumXtCiKAUgb.Clear();
	}

	public virtual bool INYrIPNPQGAfMACMHLnoinKxNIiHb(ORSKUsFUQMFbVqzYDhEFDxAETxpN P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (TyzuxlQSORfGJwBwbeWLxgRRdNmz == null != (P_0.TyzuxlQSORfGJwBwbeWLxgRRdNmz == null))
		{
			return false;
		}
		if (TyzuxlQSORfGJwBwbeWLxgRRdNmz != null)
		{
			if (!string.Equals(TyzuxlQSORfGJwBwbeWLxgRRdNmz.keyCategory, P_0.TyzuxlQSORfGJwBwbeWLxgRRdNmz.keyCategory, StringComparison.Ordinal) || !string.Equals(TyzuxlQSORfGJwBwbeWLxgRRdNmz.scriptingName, P_0.TyzuxlQSORfGJwBwbeWLxgRRdNmz.scriptingName, StringComparison.Ordinal) || !string.Equals(TyzuxlQSORfGJwBwbeWLxgRRdNmz.key, P_0.TyzuxlQSORfGJwBwbeWLxgRRdNmz.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(TyzuxlQSORfGJwBwbeWLxgRRdNmz.nonLocalizedDescriptiveName, P_0.TyzuxlQSORfGJwBwbeWLxgRRdNmz.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void xeScNvMrWqLAFnQRTFynDfdfMKqv()
	{
		nWuWHQKnzOaKYbmQWDumXtCiKAUgb.Clear();
		ciAufICAKUbbqIqVfPVVcojrwSCCA.Clear();
	}

	protected sZLAxvZSvDRmVjMjTVRhHfujppQp ezuBKWkznYBOSXRGpqYrdiJDWPLoA()
	{
		return TyzuxlQSORfGJwBwbeWLxgRRdNmz;
	}

	protected virtual void xwVhfgkgqJaUdXIocRzzcWsTaSSK()
	{
		_ = HKQoqutKkgeGtFcRmtcKMQqgsDoY;
	}

	void fuTAbCyJgOZBWWgBXmUSttFWWuoi.Localize()
	{
		xwVhfgkgqJaUdXIocRzzcWsTaSSK();
	}

	protected virtual void ayoecbXLiRWxJCIQLeYmNzGLaduo(int P_0)
	{
	}

	protected virtual void paWEUOeYeWwEdUjOyvrRqUYOiDfOA()
	{
	}

	protected void jriVMgSVfNhJUCcVjmEMYoZYjhGW(int P_0, ZfSdyTfpTJoTlWfkGbXUdYyHUehp P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!ciAufICAKUbbqIqVfPVVcojrwSCCA.TryGetValue(num, out var value))
				{
					value = new List<ZfSdyTfpTJoTlWfkGbXUdYyHUehp>();
					ciAufICAKUbbqIqVfPVVcojrwSCCA[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected void pliBpJxTcDWQbQnQSnHFXyUAIJbq(int P_0, ZfSdyTfpTJoTlWfkGbXUdYyHUehp P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !ciAufICAKUbbqIqVfPVVcojrwSCCA.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (ZfSdyTfpTJoTlWfkGbXUdYyHUehp.LOSGvPdsidJotCRnDWgkaMUoeHHWb(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected void XFdvjghozpLZsrvkWgkIQqPrTeDD(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !ciAufICAKUbbqIqVfPVVcojrwSCCA.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].aATlyVMZfzbInxFRkgSBZcMommTT != 0)
				{
					ayoecbXLiRWxJCIQLeYmNzGLaduo(value[j].aATlyVMZfzbInxFRkgSBZcMommTT);
				}
				if (value[j].NmUmjFVjvsfeLKeuxcGWcsbAUoEx != null)
				{
					value[j].NmUmjFVjvsfeLKeuxcGWcsbAUoEx.Clear();
				}
			}
		}
	}
}
