using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class MHoAjyzCdSiDugUBvCjLClWaEtUx : ISteamControllerInternal
{
	private static Dictionary<string, ulong> tGkbrKJMSjNjjpqvShiUGvKDgrMoB;

	private static Dictionary<string, ulong> qFGcoOCrgqJNLRjzkAdrinUETCzZB;

	private static Dictionary<string, ulong> PNfgoxEgaJSnnguHQtEJYTmigwmuA;

	private static Dictionary<ulong, string> ltuVBMUpzMWpVQHKTroYTvZWPGQn;

	private static Dictionary<ulong, string> qZWBzDhvEzKKcKexCaDzAiuChHxBA;

	private static Dictionary<ulong, string> ViMjvMydeoIWIpiDaviSenzqUKij;

	public readonly ulong ytFicPsJEHJfmUguecSBojUeBqDm;

	private WiEqGjowrKJYWKAlTkLAhDBCOMTM[] NzeXsmDtCFiSESiziAKlgVZPbGXd;

	private List<SteamControllerActionOrigin> KjHcuZBKaPjfrGGBdjXrbaSJQZUyB;

	private ReadOnlyCollection<SteamControllerActionOrigin> vrHaJIUXcJtJvzTcnjueXganGxbl;

	public int MaxActionSourceCount => 8;

	public bool IsConnected => BcUfdxCGwnuCjDnMOhTMJkamnbnDb.RpWdGzdwrHwYwYJbGhPHHThEjjBS(ytFicPsJEHJfmUguecSBojUeBqDm);

	public static void iQiCQJJXphUxtVUBZUWyQfQvjZhc(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			tGkbrKJMSjNjjpqvShiUGvKDgrMoB = P_0;
			ltuVBMUpzMWpVQHKTroYTvZWPGQn = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void LjPvcSnjTrnADULISxHauXUcpbZr(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			qFGcoOCrgqJNLRjzkAdrinUETCzZB = P_0;
			qZWBzDhvEzKKcKexCaDzAiuChHxBA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void pfjMHLKqKARJYeORgUCFVaGgesEEA(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			PNfgoxEgaJSnnguHQtEJYTmigwmuA = P_0;
			ViMjvMydeoIWIpiDaviSenzqUKij = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public MHoAjyzCdSiDugUBvCjLClWaEtUx(ulong P_0)
	{
		ytFicPsJEHJfmUguecSBojUeBqDm = P_0;
		NzeXsmDtCFiSESiziAKlgVZPbGXd = new WiEqGjowrKJYWKAlTkLAhDBCOMTM[8];
		KjHcuZBKaPjfrGGBdjXrbaSJQZUyB = new List<SteamControllerActionOrigin>(8);
		vrHaJIUXcJtJvzTcnjueXganGxbl = new ReadOnlyCollection<SteamControllerActionOrigin>(KjHcuZBKaPjfrGGBdjXrbaSJQZUyB);
	}

	public string GetActionSetName(ulong handle)
	{
		return flrFvoXCfipKddBXtHokkeRbIkRM(ltuVBMUpzMWpVQHKTroYTvZWPGQn, handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return flrFvoXCfipKddBXtHokkeRbIkRM(ViMjvMydeoIWIpiDaviSenzqUKij, handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return flrFvoXCfipKddBXtHokkeRbIkRM(qZWBzDhvEzKKcKexCaDzAiuChHxBA, handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(tGkbrKJMSjNjjpqvShiUGvKDgrMoB, ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(PNfgoxEgaJSnnguHQtEJYTmigwmuA, ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(qFGcoOCrgqJNLRjzkAdrinUETCzZB, ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return default(Vector2);
		}
		try
		{
			ZSGmPXcKHrMChSHJAPwBWzVcbQAu zSGmPXcKHrMChSHJAPwBWzVcbQAu = BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.RBahylcwCpcyrcQxTXhxYGxvIVwAA(ytFicPsJEHJfmUguecSBojUeBqDm, actionHandle);
			if (!zSGmPXcKHrMChSHJAPwBWzVcbQAu.AXzKHxrwiWqyUPFlYsxPNmdkFAjV)
			{
				return default(Vector2);
			}
			return new Vector2(zSGmPXcKHrMChSHJAPwBWzVcbQAu.HMqOacmZPahaVGMKoLtIrGLGaiBbA, zSGmPXcKHrMChSHJAPwBWzVcbQAu.jZtHLoGOcKxeqtCGBTnilRCaJNPG);
		}
		catch
		{
			return default(Vector2);
		}
	}

	public Vector2 GetAnalogActionValue(ref string actionName)
	{
		ulong analogActionHandle = GetAnalogActionHandle(ref actionName);
		return GetAnalogActionValue(analogActionHandle);
	}

	public bool GetDigitalActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return false;
		}
		try
		{
			aFrTELyDLGQFVzQRusJSCbWEqXnb aFrTELyDLGQFVzQRusJSCbWEqXnb2 = BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.pkXLvkdveGTIivjBStzVCojrOpaN(ytFicPsJEHJfmUguecSBojUeBqDm, actionHandle);
			Debug.Log(actionHandle + " state = " + aFrTELyDLGQFVzQRusJSCbWEqXnb2.geSiLhKdruhxXfhShTtxkpdVsYsfb + " active = " + aFrTELyDLGQFVzQRusJSCbWEqXnb2.AXzKHxrwiWqyUPFlYsxPNmdkFAjV);
			return aFrTELyDLGQFVzQRusJSCbWEqXnb2.AXzKHxrwiWqyUPFlYsxPNmdkFAjV && aFrTELyDLGQFVzQRusJSCbWEqXnb2.geSiLhKdruhxXfhShTtxkpdVsYsfb;
		}
		catch
		{
			return false;
		}
	}

	public bool GetDigitalActionValue(ref string actionName)
	{
		ulong digitalActionHandle = GetDigitalActionHandle(ref actionName);
		return GetDigitalActionValue(digitalActionHandle);
	}

	public bool SetActiveActionSet(ulong actionSetHandle)
	{
		if (actionSetHandle == 0L)
		{
			return false;
		}
		try
		{
			BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.ebFkICYMuBiyUhsvqEdKRepKSpVr(ytFicPsJEHJfmUguecSBojUeBqDm, actionSetHandle);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool SetActiveActionSet(ref string actionSetName)
	{
		ulong actionSetHandle = GetActionSetHandle(ref actionSetName);
		return SetActiveActionSet(actionSetHandle);
	}

	public ulong GetActiveActionSetHandle()
	{
		return BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.PBZZODHKoYyoOjSwrmbztPIhBQbiA(ytFicPsJEHJfmUguecSBojUeBqDm);
	}

	public string GetActiveActionSetName()
	{
		return flrFvoXCfipKddBXtHokkeRbIkRM(ltuVBMUpzMWpVQHKTroYTvZWPGQn, BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.PBZZODHKoYyoOjSwrmbztPIhBQbiA(ytFicPsJEHJfmUguecSBojUeBqDm));
	}

	public void ShowBindingPanel()
	{
		BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.PDdPrLwIlxFERKvmomLZgjUdTnYDA(ytFicPsJEHJfmUguecSBojUeBqDm);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.CNpBdbxkniunKwDGQdtHxIuDKVgu(ytFicPsJEHJfmUguecSBojUeBqDm, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.CNpBdbxkniunKwDGQdtHxIuDKVgu(ytFicPsJEHJfmUguecSBojUeBqDm, (uint)triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(tGkbrKJMSjNjjpqvShiUGvKDgrMoB, ref actionSetName), ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(PNfgoxEgaJSnnguHQtEJYTmigwmuA, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		KjHcuZBKaPjfrGGBdjXrbaSJQZUyB.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return vrHaJIUXcJtJvzTcnjueXganGxbl;
		}
		int num = BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.cEcQCfsBdHRGcvdBYqTbCYyoziEE(ytFicPsJEHJfmUguecSBojUeBqDm, actionSetHandle, actionHandle, NzeXsmDtCFiSESiziAKlgVZPbGXd);
		for (int i = 0; i < num; i++)
		{
			KjHcuZBKaPjfrGGBdjXrbaSJQZUyB.Add((SteamControllerActionOrigin)NzeXsmDtCFiSESiziAKlgVZPbGXd[i]);
		}
		return vrHaJIUXcJtJvzTcnjueXganGxbl;
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(tGkbrKJMSjNjjpqvShiUGvKDgrMoB, ref actionSetName), ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(qFGcoOCrgqJNLRjzkAdrinUETCzZB, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		KjHcuZBKaPjfrGGBdjXrbaSJQZUyB.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return vrHaJIUXcJtJvzTcnjueXganGxbl;
		}
		int num = BcUfdxCGwnuCjDnMOhTMJkamnbnDb.viafXYqFbshOsTTimOzwXCWMZRZF.kPGPoyaJzPHKSMftAGFLjndicnPbb(ytFicPsJEHJfmUguecSBojUeBqDm, actionSetHandle, actionHandle, NzeXsmDtCFiSESiziAKlgVZPbGXd);
		for (int i = 0; i < num; i++)
		{
			KjHcuZBKaPjfrGGBdjXrbaSJQZUyB.Add((SteamControllerActionOrigin)NzeXsmDtCFiSESiziAKlgVZPbGXd[i]);
		}
		return vrHaJIUXcJtJvzTcnjueXganGxbl;
	}

	private ulong ZmCHRfSjSIdCJiXpwsPRpTQtTfxlA(Dictionary<string, ulong> P_0, ref string P_1)
	{
		if (P_0 == null || string.IsNullOrEmpty(P_1))
		{
			return 0uL;
		}
		if (!P_0.TryGetValue(P_1, out var value))
		{
			return 0uL;
		}
		return value;
	}

	private string flrFvoXCfipKddBXtHokkeRbIkRM(Dictionary<ulong, string> P_0, ulong P_1)
	{
		if (P_0 == null || P_1 == 0L)
		{
			return string.Empty;
		}
		if (!P_0.TryGetValue(P_1, out var value))
		{
			return string.Empty;
		}
		return value;
	}
}
