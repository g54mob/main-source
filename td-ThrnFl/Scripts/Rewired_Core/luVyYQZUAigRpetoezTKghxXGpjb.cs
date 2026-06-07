using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class luVyYQZUAigRpetoezTKghxXGpjb
{
	private class hBayhzHvSjAuKbujosWiFHIWTwDv
	{
		private readonly AList<IControllerTemplate> UuRkNHfYhKlCWqyGWyWDDolNlBqF;

		private IList IAZfhoIzDJuVZKgSRlJEaLPeqfDKb;

		private IList ISddmkOhvMAHyFqfAnKGwuMjaFTjb;

		public readonly Type ekELwMHnuZWZkxTiuiPCIDNpCBtH;

		public hBayhzHvSjAuKbujosWiFHIWTwDv(Type P_0)
		{
			ekELwMHnuZWZkxTiuiPCIDNpCBtH = P_0;
			UuRkNHfYhKlCWqyGWyWDDolNlBqF = new AList<IControllerTemplate>();
		}

		public IList<_0001> pXbVtnzpjEZvphTtUurfRjdMWey<_0001>() where _0001 : IControllerTemplate
		{
			if (IAZfhoIzDJuVZKgSRlJEaLPeqfDKb == null)
			{
				OXlaTXxodAxxYojDHcEbrWBOXQOL<_0001>();
			}
			return ISddmkOhvMAHyFqfAnKGwuMjaFTjb as IList<_0001>;
		}

		public void PjwOQYpPhuOzWsxoPZxCUiPWjATF(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				UuRkNHfYhKlCWqyGWyWDDolNlBqF.Add(P_0);
				if (IAZfhoIzDJuVZKgSRlJEaLPeqfDKb != null)
				{
					IAZfhoIzDJuVZKgSRlJEaLPeqfDKb.Add(P_0);
				}
			}
		}

		public void hAegBlvEzXHKTDklMBriVzZbedHp(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				UuRkNHfYhKlCWqyGWyWDDolNlBqF.Remove(P_0);
				if (IAZfhoIzDJuVZKgSRlJEaLPeqfDKb != null)
				{
					IAZfhoIzDJuVZKgSRlJEaLPeqfDKb.Remove(P_0);
				}
			}
		}

		private void OXlaTXxodAxxYojDHcEbrWBOXQOL<_0001>() where _0001 : IControllerTemplate
		{
			IAZfhoIzDJuVZKgSRlJEaLPeqfDKb = new AList<_0001>();
			ISddmkOhvMAHyFqfAnKGwuMjaFTjb = new ReadOnlyCollection<_0001>((AList<_0001>)IAZfhoIzDJuVZKgSRlJEaLPeqfDKb);
			for (int i = 0; i < UuRkNHfYhKlCWqyGWyWDDolNlBqF._count; i++)
			{
				IAZfhoIzDJuVZKgSRlJEaLPeqfDKb.Add(UuRkNHfYhKlCWqyGWyWDDolNlBqF._items[i]);
			}
		}
	}

	private readonly AList<hBayhzHvSjAuKbujosWiFHIWTwDv> mozMvoiUQogXonSxfzVHUiwhGArl;

	private readonly Type[] WZsCxVKfIKgednEICWcYhHcglhNo;

	private readonly Type[] PAUdRrPMwBDjbCqxtvImFLIXxJhpA;

	private readonly int DusEUJsrjrmpfxLgnaZWLvGTqXJs;

	public luVyYQZUAigRpetoezTKghxXGpjb(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		WZsCxVKfIKgednEICWcYhHcglhNo = P_0;
		PAUdRrPMwBDjbCqxtvImFLIXxJhpA = P_1;
		DusEUJsrjrmpfxLgnaZWLvGTqXJs = WZsCxVKfIKgednEICWcYhHcglhNo.Length;
		mozMvoiUQogXonSxfzVHUiwhGArl = new AList<hBayhzHvSjAuKbujosWiFHIWTwDv>();
		for (int i = 0; i < DusEUJsrjrmpfxLgnaZWLvGTqXJs; i++)
		{
			mozMvoiUQogXonSxfzVHUiwhGArl.Add(new hBayhzHvSjAuKbujosWiFHIWTwDv(PAUdRrPMwBDjbCqxtvImFLIXxJhpA[i]));
		}
	}

	public void JtDcHaHpJBOhVcxCDTnbPglAlCNdc(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = UXRqqHmxXMhTowTaXvYldDoXfySp(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				zGUsTciRJsjnLbowzAhUFVaUWPyhb(type)?.PjwOQYpPhuOzWsxoPZxCUiPWjATF(controllerTemplate);
			}
		}
	}

	public void mcLDGeazCzmWxNKScdthBzTSViJc(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = UXRqqHmxXMhTowTaXvYldDoXfySp(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				zGUsTciRJsjnLbowzAhUFVaUWPyhb(type)?.hAegBlvEzXHKTDklMBriVzZbedHp(controllerTemplate);
			}
		}
	}

	public IList<_0001> btiRIkziHJeHEgVVxcNtCxMgrcSvb<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < mozMvoiUQogXonSxfzVHUiwhGArl._count; i++)
		{
			hBayhzHvSjAuKbujosWiFHIWTwDv hBayhzHvSjAuKbujosWiFHIWTwDv2 = mozMvoiUQogXonSxfzVHUiwhGArl._items[i];
			if ((object)hBayhzHvSjAuKbujosWiFHIWTwDv2.ekELwMHnuZWZkxTiuiPCIDNpCBtH == typeFromHandle)
			{
				return hBayhzHvSjAuKbujosWiFHIWTwDv2.pXbVtnzpjEZvphTtUurfRjdMWey<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < PAUdRrPMwBDjbCqxtvImFLIXxJhpA.Length; j++)
		{
			text += PAUdRrPMwBDjbCqxtvImFLIXxJhpA[j].Name;
			if (j != PAUdRrPMwBDjbCqxtvImFLIXxJhpA.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private hBayhzHvSjAuKbujosWiFHIWTwDv zGUsTciRJsjnLbowzAhUFVaUWPyhb(Type P_0)
	{
		for (int i = 0; i < mozMvoiUQogXonSxfzVHUiwhGArl._count; i++)
		{
			if ((object)P_0 == mozMvoiUQogXonSxfzVHUiwhGArl._items[i].ekELwMHnuZWZkxTiuiPCIDNpCBtH)
			{
				return mozMvoiUQogXonSxfzVHUiwhGArl._items[i];
			}
		}
		return null;
	}

	private Type UXRqqHmxXMhTowTaXvYldDoXfySp(Type P_0)
	{
		for (int i = 0; i < DusEUJsrjrmpfxLgnaZWLvGTqXJs; i++)
		{
			if ((object)WZsCxVKfIKgednEICWcYhHcglhNo[i] == P_0)
			{
				return PAUdRrPMwBDjbCqxtvImFLIXxJhpA[i];
			}
		}
		return null;
	}
}
