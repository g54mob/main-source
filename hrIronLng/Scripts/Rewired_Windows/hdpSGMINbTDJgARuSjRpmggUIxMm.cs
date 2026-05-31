using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class hdpSGMINbTDJgARuSjRpmggUIxMm : ISteamControllerInternal
{
	private static Dictionary<string, ulong> EwflVorDGunLtPPYnIUgPccYxvY;

	private static Dictionary<string, ulong> TvJmpmKgsvPPHCzQVFWNZLadWgv;

	private static Dictionary<string, ulong> ipgcwZVyKObsfRuIzgSxxMNIqys;

	private static Dictionary<ulong, string> WgbXySjnAPvDpvhUsCgdjzsoQSR;

	private static Dictionary<ulong, string> HmTFZzIDYmWOmzbEbAfPKwKsaLhQ;

	private static Dictionary<ulong, string> kSDbhsGVitBYUoGmXgJiYALUkCik;

	public readonly ulong ZfQSgjTtNKxNmtmNNcSxQmeCPZH;

	private dfHOwLZYtLOrEzGUorGcVMrwUIR[] iezgZCaJxGxyStdNBsvFUIftArL;

	private List<SteamControllerActionOrigin> peINqxaJqOYpdtpoQNjVYTosAHI;

	private ReadOnlyCollection<SteamControllerActionOrigin> AmIPNktzeGqBnAqBErJWnuMVGWt;

	public int MaxActionSourceCount => 8;

	public bool IsConnected => gKHMhZdHwqJUpaiflerqgESSKljH.gVLmCFAXrSMGqpOClklhxoLecpD(ZfQSgjTtNKxNmtmNNcSxQmeCPZH);

	public static void LivUSsuqZiKExgFtooruqyTLbQZ(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			EwflVorDGunLtPPYnIUgPccYxvY = P_0;
			WgbXySjnAPvDpvhUsCgdjzsoQSR = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void wqGwczIHKoADfffyxhKBEoeKlfH(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			TvJmpmKgsvPPHCzQVFWNZLadWgv = P_0;
			HmTFZzIDYmWOmzbEbAfPKwKsaLhQ = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void EXyCDfjRMHPROLZgZgynbJsGnoM(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			ipgcwZVyKObsfRuIzgSxxMNIqys = P_0;
			kSDbhsGVitBYUoGmXgJiYALUkCik = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public hdpSGMINbTDJgARuSjRpmggUIxMm(ulong handle)
	{
		ZfQSgjTtNKxNmtmNNcSxQmeCPZH = handle;
		iezgZCaJxGxyStdNBsvFUIftArL = new dfHOwLZYtLOrEzGUorGcVMrwUIR[8];
		peINqxaJqOYpdtpoQNjVYTosAHI = new List<SteamControllerActionOrigin>(8);
		AmIPNktzeGqBnAqBErJWnuMVGWt = new ReadOnlyCollection<SteamControllerActionOrigin>(peINqxaJqOYpdtpoQNjVYTosAHI);
	}

	public string GetActionSetName(ulong handle)
	{
		return GAcmNAoXbtlnjCpcWQtEWUhRNcN(WgbXySjnAPvDpvhUsCgdjzsoQSR, handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return GAcmNAoXbtlnjCpcWQtEWUhRNcN(kSDbhsGVitBYUoGmXgJiYALUkCik, handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return GAcmNAoXbtlnjCpcWQtEWUhRNcN(HmTFZzIDYmWOmzbEbAfPKwKsaLhQ, handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return oWNZRXrOKLKxBwCCBzSxlNmXvDx(EwflVorDGunLtPPYnIUgPccYxvY, ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return oWNZRXrOKLKxBwCCBzSxlNmXvDx(ipgcwZVyKObsfRuIzgSxxMNIqys, ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return oWNZRXrOKLKxBwCCBzSxlNmXvDx(TvJmpmKgsvPPHCzQVFWNZLadWgv, ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (actionHandle == 0)
		{
			return default(Vector2);
		}
		try
		{
			uRLbLvFjRcTKlrLqvARfyilEFYM uRLbLvFjRcTKlrLqvARfyilEFYM2 = gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.iLjgdFTeGqsnvtgOgHhDeZNHLBm(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, actionHandle);
			if (!uRLbLvFjRcTKlrLqvARfyilEFYM2.zPkcDRQvkDOmIuBMhGBzavBEqOfB)
			{
				return default(Vector2);
			}
			return new Vector2(uRLbLvFjRcTKlrLqvARfyilEFYM2.iyrAwKHmFdoTXpepDCReDBhghaPK, uRLbLvFjRcTKlrLqvARfyilEFYM2.MKmfDOCnKHHrcTKliSnMlRgSRZBd);
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
		if (actionHandle == 0)
		{
			return false;
		}
		try
		{
			ZVkxJmLmPFsWVUchVsSzyQXauiT zVkxJmLmPFsWVUchVsSzyQXauiT = gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.ECODrMCwqTpQeChuzTDpmtFFWho(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, actionHandle);
			Debug.Log(actionHandle + " state = " + zVkxJmLmPFsWVUchVsSzyQXauiT.VGNZWNClNrzbJQjuWBGXPbLjCbc + " active = " + zVkxJmLmPFsWVUchVsSzyQXauiT.zPkcDRQvkDOmIuBMhGBzavBEqOfB);
			return zVkxJmLmPFsWVUchVsSzyQXauiT.zPkcDRQvkDOmIuBMhGBzavBEqOfB && zVkxJmLmPFsWVUchVsSzyQXauiT.VGNZWNClNrzbJQjuWBGXPbLjCbc;
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
		if (actionSetHandle == 0)
		{
			return false;
		}
		try
		{
			gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.LXSADarPmMgOYMUlBNZajJoujjL(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, actionSetHandle);
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
		return gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.yStSxsGoZIuEFIVGWLPjPwVfWdK(ZfQSgjTtNKxNmtmNNcSxQmeCPZH);
	}

	public string GetActiveActionSetName()
	{
		return GAcmNAoXbtlnjCpcWQtEWUhRNcN(WgbXySjnAPvDpvhUsCgdjzsoQSR, gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.yStSxsGoZIuEFIVGWLPjPwVfWdK(ZfQSgjTtNKxNmtmNNcSxQmeCPZH));
	}

	public void ShowBindingPanel()
	{
		gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.ajycvjXHbkzSFOUHDnljNOiTSjG(ZfQSgjTtNKxNmtmNNcSxQmeCPZH);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.fzseLHdOtxXsQeLjtUBjTLWlBXgv(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.fzseLHdOtxXsQeLjtUBjTLWlBXgv(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, (uint)triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(oWNZRXrOKLKxBwCCBzSxlNmXvDx(EwflVorDGunLtPPYnIUgPccYxvY, ref actionSetName), oWNZRXrOKLKxBwCCBzSxlNmXvDx(ipgcwZVyKObsfRuIzgSxxMNIqys, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		peINqxaJqOYpdtpoQNjVYTosAHI.Clear();
		if (actionSetHandle == 0 || actionHandle == 0)
		{
			return AmIPNktzeGqBnAqBErJWnuMVGWt;
		}
		int num = gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.BvvwKwFJNUFDuGrOjlCLgbwOepCi(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, actionSetHandle, actionHandle, iezgZCaJxGxyStdNBsvFUIftArL);
		for (int i = 0; i < num; i++)
		{
			peINqxaJqOYpdtpoQNjVYTosAHI.Add((SteamControllerActionOrigin)iezgZCaJxGxyStdNBsvFUIftArL[i]);
		}
		return AmIPNktzeGqBnAqBErJWnuMVGWt;
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(oWNZRXrOKLKxBwCCBzSxlNmXvDx(EwflVorDGunLtPPYnIUgPccYxvY, ref actionSetName), oWNZRXrOKLKxBwCCBzSxlNmXvDx(TvJmpmKgsvPPHCzQVFWNZLadWgv, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		peINqxaJqOYpdtpoQNjVYTosAHI.Clear();
		if (actionSetHandle == 0 || actionHandle == 0)
		{
			return AmIPNktzeGqBnAqBErJWnuMVGWt;
		}
		int num = gKHMhZdHwqJUpaiflerqgESSKljH.ControllerManager.FvFasEBKzEESOjFCdgdvDpZOZzV(ZfQSgjTtNKxNmtmNNcSxQmeCPZH, actionSetHandle, actionHandle, iezgZCaJxGxyStdNBsvFUIftArL);
		for (int i = 0; i < num; i++)
		{
			peINqxaJqOYpdtpoQNjVYTosAHI.Add((SteamControllerActionOrigin)iezgZCaJxGxyStdNBsvFUIftArL[i]);
		}
		return AmIPNktzeGqBnAqBErJWnuMVGWt;
	}

	private ulong oWNZRXrOKLKxBwCCBzSxlNmXvDx(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string GAcmNAoXbtlnjCpcWQtEWUhRNcN(Dictionary<ulong, string> P_0, ulong P_1)
	{
		if (P_0 == null || P_1 == 0)
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
