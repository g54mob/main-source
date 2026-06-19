using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class dKvVPxoEiTgONpLgbZuhwXBucAYy : ISteamControllerInternal
{
	private static Dictionary<string, ulong> iIoiARQIJhWiOOsDoeezFFdcLYIE;

	private static Dictionary<string, ulong> NTpYiGTJHsyvfJBFZEKPxGpMPJXu;

	private static Dictionary<string, ulong> SBiDIlXomtqQTZqfpabNwbnuipNiA;

	private static Dictionary<ulong, string> GIvdIccdUyOaoyYyhWTMPhUvhWYjA;

	private static Dictionary<ulong, string> uGjmtBYUnQDypgVnqWnmnVvmdPNj;

	private static Dictionary<ulong, string> OMuthStRkRFDqJOxPdGCsAGXObmV;

	public readonly ulong FRVZXlguaoFrSoaBzzuEvWFNzYcA;

	private tJDRLibngNjXpBeQDgYuaBUYQtHLA[] MJNiqilrjYiTFvgApNYJlzDvBVPw;

	private List<SteamControllerActionOrigin> HdMfvAuHcPIuLGlHfLocaBaJVltvB;

	private ReadOnlyCollection<SteamControllerActionOrigin> diyirgFzFhAxZYcpfXoZEIDSAprm;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => eADEuoPmtmgJQEJbGjOcMOriLOrQ.hDXluYShWSfIlVuMPicZBlOoiufm(FRVZXlguaoFrSoaBzzuEvWFNzYcA);

	public static void IQhpwfcdNLOmVOAisFZcYCWtabZe(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			iIoiARQIJhWiOOsDoeezFFdcLYIE = P_0;
			GIvdIccdUyOaoyYyhWTMPhUvhWYjA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void nXkBbfFeXMeetBLEkZanlXPBFVkUB(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			NTpYiGTJHsyvfJBFZEKPxGpMPJXu = P_0;
			uGjmtBYUnQDypgVnqWnmnVvmdPNj = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void QvGLxPnJctVqdasSFzyGJpdPgKQ(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			SBiDIlXomtqQTZqfpabNwbnuipNiA = P_0;
			OMuthStRkRFDqJOxPdGCsAGXObmV = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public dKvVPxoEiTgONpLgbZuhwXBucAYy(ulong P_0)
	{
		FRVZXlguaoFrSoaBzzuEvWFNzYcA = P_0;
		MJNiqilrjYiTFvgApNYJlzDvBVPw = new tJDRLibngNjXpBeQDgYuaBUYQtHLA[8];
		HdMfvAuHcPIuLGlHfLocaBaJVltvB = new List<SteamControllerActionOrigin>(8);
		diyirgFzFhAxZYcpfXoZEIDSAprm = new ReadOnlyCollection<SteamControllerActionOrigin>(HdMfvAuHcPIuLGlHfLocaBaJVltvB);
	}

	public string GetActionSetName(ulong handle)
	{
		return rxqGGFitltusjfPedbiwIiEJcTdkB(GIvdIccdUyOaoyYyhWTMPhUvhWYjA, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return rxqGGFitltusjfPedbiwIiEJcTdkB(OMuthStRkRFDqJOxPdGCsAGXObmV, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return rxqGGFitltusjfPedbiwIiEJcTdkB(uGjmtBYUnQDypgVnqWnmnVvmdPNj, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return PGgDtTtuVuASDECIIcobsoEQNCQcA(iIoiARQIJhWiOOsDoeezFFdcLYIE, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return PGgDtTtuVuASDECIIcobsoEQNCQcA(SBiDIlXomtqQTZqfpabNwbnuipNiA, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return PGgDtTtuVuASDECIIcobsoEQNCQcA(NTpYiGTJHsyvfJBFZEKPxGpMPJXu, ref actionName);
	}

	ulong ISteamControllerInternal.GetAnalogActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionHandle
		return this.GetAnalogActionHandle(ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return default(Vector2);
		}
		try
		{
			oVZMAKfIUyUPCNkwCbfncTMqclMjA oVZMAKfIUyUPCNkwCbfncTMqclMjA2 = eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.YCfiLgfluwIwGPgEDjEDcGSMbEBJA(FRVZXlguaoFrSoaBzzuEvWFNzYcA, actionHandle);
			if (!oVZMAKfIUyUPCNkwCbfncTMqclMjA2.JAyEssLOMpTHTENnZBxdFNOvWJKTA)
			{
				return default(Vector2);
			}
			return new Vector2(oVZMAKfIUyUPCNkwCbfncTMqclMjA2.kLmXaUwytgliYLIchsgQszSYMoVE, oVZMAKfIUyUPCNkwCbfncTMqclMjA2.ExUTwoMdmSrIlvOvKgwyjjygvyWO);
		}
		catch
		{
			return default(Vector2);
		}
	}

	Vector2 ISteamControllerInternal.GetAnalogActionValue(ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionValue
		return this.GetAnalogActionValue(actionHandle);
	}

	public Vector2 GetAnalogActionValue(ref string actionName)
	{
		ulong analogActionHandle = GetAnalogActionHandle(ref actionName);
		return GetAnalogActionValue(analogActionHandle);
	}

	Vector2 ISteamControllerInternal.GetAnalogActionValue(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionValue
		return this.GetAnalogActionValue(ref actionName);
	}

	public bool GetDigitalActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return false;
		}
		try
		{
			DHqKNJfWeJFkpqlnwlrlycqGRZIc dHqKNJfWeJFkpqlnwlrlycqGRZIc = eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.IOQOLYJZukpoIvnKtCitIqDwtCZpA(FRVZXlguaoFrSoaBzzuEvWFNzYcA, actionHandle);
			Debug.Log(actionHandle + " state = " + dHqKNJfWeJFkpqlnwlrlycqGRZIc.BYMRCiQWOwcYkENJwlxHAFcJoVgs + " active = " + dHqKNJfWeJFkpqlnwlrlycqGRZIc.sJFQyvXYtHlSIzKzBSKgbCimTnnX);
			return dHqKNJfWeJFkpqlnwlrlycqGRZIc.sJFQyvXYtHlSIzKzBSKgbCimTnnX && dHqKNJfWeJFkpqlnwlrlycqGRZIc.BYMRCiQWOwcYkENJwlxHAFcJoVgs;
		}
		catch
		{
			return false;
		}
	}

	bool ISteamControllerInternal.GetDigitalActionValue(ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionValue
		return this.GetDigitalActionValue(actionHandle);
	}

	public bool GetDigitalActionValue(ref string actionName)
	{
		ulong digitalActionHandle = GetDigitalActionHandle(ref actionName);
		return GetDigitalActionValue(digitalActionHandle);
	}

	bool ISteamControllerInternal.GetDigitalActionValue(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionValue
		return this.GetDigitalActionValue(ref actionName);
	}

	public bool SetActiveActionSet(ulong actionSetHandle)
	{
		if (actionSetHandle == 0L)
		{
			return false;
		}
		try
		{
			eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.lIofCpBPRmCpTYXjpBqyJBzzMQvPA(FRVZXlguaoFrSoaBzzuEvWFNzYcA, actionSetHandle);
			return true;
		}
		catch
		{
			return false;
		}
	}

	bool ISteamControllerInternal.SetActiveActionSet(ulong actionSetHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetActiveActionSet
		return this.SetActiveActionSet(actionSetHandle);
	}

	public bool SetActiveActionSet(ref string actionSetName)
	{
		ulong actionSetHandle = GetActionSetHandle(ref actionSetName);
		return SetActiveActionSet(actionSetHandle);
	}

	bool ISteamControllerInternal.SetActiveActionSet(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetActiveActionSet
		return this.SetActiveActionSet(ref actionSetName);
	}

	public ulong GetActiveActionSetHandle()
	{
		return eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.ZKOEAzHOINRlmAUFLpDwlgogrDvM(FRVZXlguaoFrSoaBzzuEvWFNzYcA);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return rxqGGFitltusjfPedbiwIiEJcTdkB(GIvdIccdUyOaoyYyhWTMPhUvhWYjA, eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.ZKOEAzHOINRlmAUFLpDwlgogrDvM(FRVZXlguaoFrSoaBzzuEvWFNzYcA));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.FGhgclILlrzjzoFmqJIkdfwgvAWnc(FRVZXlguaoFrSoaBzzuEvWFNzYcA);
	}

	void ISteamControllerInternal.ShowBindingPanel()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ShowBindingPanel
		this.ShowBindingPanel();
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.zgcrPwYLFQhCtTXxGFttsCauAJlH(FRVZXlguaoFrSoaBzzuEvWFNzYcA, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.zgcrPwYLFQhCtTXxGFttsCauAJlH(FRVZXlguaoFrSoaBzzuEvWFNzYcA, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(PGgDtTtuVuASDECIIcobsoEQNCQcA(iIoiARQIJhWiOOsDoeezFFdcLYIE, ref actionSetName), PGgDtTtuVuASDECIIcobsoEQNCQcA(SBiDIlXomtqQTZqfpabNwbnuipNiA, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		HdMfvAuHcPIuLGlHfLocaBaJVltvB.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return diyirgFzFhAxZYcpfXoZEIDSAprm;
		}
		int num = eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.NHgKamhdpwMEKCIokhooASqmNZBJ(FRVZXlguaoFrSoaBzzuEvWFNzYcA, actionSetHandle, actionHandle, MJNiqilrjYiTFvgApNYJlzDvBVPw);
		for (int i = 0; i < num; i++)
		{
			HdMfvAuHcPIuLGlHfLocaBaJVltvB.Add((SteamControllerActionOrigin)MJNiqilrjYiTFvgApNYJlzDvBVPw[i]);
		}
		return diyirgFzFhAxZYcpfXoZEIDSAprm;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(PGgDtTtuVuASDECIIcobsoEQNCQcA(iIoiARQIJhWiOOsDoeezFFdcLYIE, ref actionSetName), PGgDtTtuVuASDECIIcobsoEQNCQcA(NTpYiGTJHsyvfJBFZEKPxGpMPJXu, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		HdMfvAuHcPIuLGlHfLocaBaJVltvB.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return diyirgFzFhAxZYcpfXoZEIDSAprm;
		}
		int num = eADEuoPmtmgJQEJbGjOcMOriLOrQ.QRIdWlxczTabWVXVXXUnmyHQbaFE.EdRucFMQDlBJUFnvhYGqVzXTEqMq(FRVZXlguaoFrSoaBzzuEvWFNzYcA, actionSetHandle, actionHandle, MJNiqilrjYiTFvgApNYJlzDvBVPw);
		for (int i = 0; i < num; i++)
		{
			HdMfvAuHcPIuLGlHfLocaBaJVltvB.Add((SteamControllerActionOrigin)MJNiqilrjYiTFvgApNYJlzDvBVPw[i]);
		}
		return diyirgFzFhAxZYcpfXoZEIDSAprm;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong PGgDtTtuVuASDECIIcobsoEQNCQcA(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string rxqGGFitltusjfPedbiwIiEJcTdkB(Dictionary<ulong, string> P_0, ulong P_1)
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
