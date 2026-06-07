using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class SqZwjDRwhKcCxONvuoofMgnRjPwU : ISteamControllerInternal
{
	private static Dictionary<string, ulong> NwEPQytHigobSlknfeBbhplJCFqI;

	private static Dictionary<string, ulong> uaLcPsasCbJGPhmGEnGBINTJrUbRb;

	private static Dictionary<string, ulong> rFSrNXwqjagovkPoojNRQYZJgNvg;

	private static Dictionary<ulong, string> hmFXjGGLHhnQSfdfaUDOFmcUjByr;

	private static Dictionary<ulong, string> LBVeJvxdcFBbDBHkjmEsoJJBmwpCA;

	private static Dictionary<ulong, string> puKeMuAYrQXbKoygGQQQORemdsEHA;

	public readonly ulong wrliJdDAtphFRVVhWxwiRLmqyWcJ;

	private QNnDsMEohOAnVcHRQmOihwspwTvk[] bbdtJKCviRajtCKZyDAPTrpQEUxs;

	private List<SteamControllerActionOrigin> cAcqWyVTfWKMzCMIisecdSYoDsLp;

	private ReadOnlyCollection<SteamControllerActionOrigin> WPAMYKyaCkVNffjsgSkBcdntSiTP;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => BilRPOcpavjBqhvaVCyimAHJPmXl.MHpONkllZLbsNcWRQdwRzfgLwlPN(wrliJdDAtphFRVVhWxwiRLmqyWcJ);

	public static void zbJMCLRkXQwfznXMvFagmmVQjwbe(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			NwEPQytHigobSlknfeBbhplJCFqI = P_0;
			hmFXjGGLHhnQSfdfaUDOFmcUjByr = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void GDSyEDXFGHLALaLHCBgdvijarOQn(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			uaLcPsasCbJGPhmGEnGBINTJrUbRb = P_0;
			LBVeJvxdcFBbDBHkjmEsoJJBmwpCA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void lQNyhJeBKjJpAIEdVFpouqNGCtuaA(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			rFSrNXwqjagovkPoojNRQYZJgNvg = P_0;
			puKeMuAYrQXbKoygGQQQORemdsEHA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public SqZwjDRwhKcCxONvuoofMgnRjPwU(ulong P_0)
	{
		wrliJdDAtphFRVVhWxwiRLmqyWcJ = P_0;
		bbdtJKCviRajtCKZyDAPTrpQEUxs = new QNnDsMEohOAnVcHRQmOihwspwTvk[8];
		cAcqWyVTfWKMzCMIisecdSYoDsLp = new List<SteamControllerActionOrigin>(8);
		WPAMYKyaCkVNffjsgSkBcdntSiTP = new ReadOnlyCollection<SteamControllerActionOrigin>(cAcqWyVTfWKMzCMIisecdSYoDsLp);
	}

	public string GetActionSetName(ulong handle)
	{
		return GrUvlvAryaKEFmKxqbwqeWaFrOJMA(hmFXjGGLHhnQSfdfaUDOFmcUjByr, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return GrUvlvAryaKEFmKxqbwqeWaFrOJMA(puKeMuAYrQXbKoygGQQQORemdsEHA, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return GrUvlvAryaKEFmKxqbwqeWaFrOJMA(LBVeJvxdcFBbDBHkjmEsoJJBmwpCA, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return yNQXMxAMWbFelzLXHbsdJMorBPmnA(NwEPQytHigobSlknfeBbhplJCFqI, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return yNQXMxAMWbFelzLXHbsdJMorBPmnA(rFSrNXwqjagovkPoojNRQYZJgNvg, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return yNQXMxAMWbFelzLXHbsdJMorBPmnA(uaLcPsasCbJGPhmGEnGBINTJrUbRb, ref actionName);
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
			FBdJjiWeLjIlwhijFcftREiJaiiqA fBdJjiWeLjIlwhijFcftREiJaiiqA = BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.foDrsCKJpdGcusnXKIIRIbafhPbR(wrliJdDAtphFRVVhWxwiRLmqyWcJ, actionHandle);
			if (!fBdJjiWeLjIlwhijFcftREiJaiiqA.ahKLJOeqXkjlfnFoWjezjzoEOIam)
			{
				return default(Vector2);
			}
			return new Vector2(fBdJjiWeLjIlwhijFcftREiJaiiqA.RZIkrqRjdvHkusDBeqfKAcFnTZnI, fBdJjiWeLjIlwhijFcftREiJaiiqA.tdgENQdjvTxcFSAmLJwopPEVRvujA);
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
			iXClOtCAHInDCTxerdObAKChKhpl iXClOtCAHInDCTxerdObAKChKhpl2 = BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.bxwImyomtzPMaQyXgombYRzFLVxN(wrliJdDAtphFRVVhWxwiRLmqyWcJ, actionHandle);
			Debug.Log(actionHandle + " state = " + iXClOtCAHInDCTxerdObAKChKhpl2.mmwGfYhjDfGaWzGOdHbVeUIudSUIA + " active = " + iXClOtCAHInDCTxerdObAKChKhpl2.RNpFHRkHkKgaekAsKJMuBSYTakFFA);
			return iXClOtCAHInDCTxerdObAKChKhpl2.RNpFHRkHkKgaekAsKJMuBSYTakFFA && iXClOtCAHInDCTxerdObAKChKhpl2.mmwGfYhjDfGaWzGOdHbVeUIudSUIA;
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
			BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.YUCNlTmOSdbZpBfuqNooclTWtPLib(wrliJdDAtphFRVVhWxwiRLmqyWcJ, actionSetHandle);
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
		return BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.gTmNtHwABYQVYbOYWDLuLwMBASRBA(wrliJdDAtphFRVVhWxwiRLmqyWcJ);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return GrUvlvAryaKEFmKxqbwqeWaFrOJMA(hmFXjGGLHhnQSfdfaUDOFmcUjByr, BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.gTmNtHwABYQVYbOYWDLuLwMBASRBA(wrliJdDAtphFRVVhWxwiRLmqyWcJ));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.iuTSNZseqsCJVaudnmCaJDGKUBovb(wrliJdDAtphFRVVhWxwiRLmqyWcJ);
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
		BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.ABODUQljOHcLNquwPHRdWTWPrJXW(wrliJdDAtphFRVVhWxwiRLmqyWcJ, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.ABODUQljOHcLNquwPHRdWTWPrJXW(wrliJdDAtphFRVVhWxwiRLmqyWcJ, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(yNQXMxAMWbFelzLXHbsdJMorBPmnA(NwEPQytHigobSlknfeBbhplJCFqI, ref actionSetName), yNQXMxAMWbFelzLXHbsdJMorBPmnA(rFSrNXwqjagovkPoojNRQYZJgNvg, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		cAcqWyVTfWKMzCMIisecdSYoDsLp.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return WPAMYKyaCkVNffjsgSkBcdntSiTP;
		}
		int num = BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.idCdgYKhgleXmrlzppAksoEVMMfG(wrliJdDAtphFRVVhWxwiRLmqyWcJ, actionSetHandle, actionHandle, bbdtJKCviRajtCKZyDAPTrpQEUxs);
		for (int i = 0; i < num; i++)
		{
			cAcqWyVTfWKMzCMIisecdSYoDsLp.Add((SteamControllerActionOrigin)bbdtJKCviRajtCKZyDAPTrpQEUxs[i]);
		}
		return WPAMYKyaCkVNffjsgSkBcdntSiTP;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(yNQXMxAMWbFelzLXHbsdJMorBPmnA(NwEPQytHigobSlknfeBbhplJCFqI, ref actionSetName), yNQXMxAMWbFelzLXHbsdJMorBPmnA(uaLcPsasCbJGPhmGEnGBINTJrUbRb, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		cAcqWyVTfWKMzCMIisecdSYoDsLp.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return WPAMYKyaCkVNffjsgSkBcdntSiTP;
		}
		int num = BilRPOcpavjBqhvaVCyimAHJPmXl.bagUcFItrUCRggIzWBKOGSPrsKhe.pihhBfheEgUhugYymTSmvtlwBxcO(wrliJdDAtphFRVVhWxwiRLmqyWcJ, actionSetHandle, actionHandle, bbdtJKCviRajtCKZyDAPTrpQEUxs);
		for (int i = 0; i < num; i++)
		{
			cAcqWyVTfWKMzCMIisecdSYoDsLp.Add((SteamControllerActionOrigin)bbdtJKCviRajtCKZyDAPTrpQEUxs[i]);
		}
		return WPAMYKyaCkVNffjsgSkBcdntSiTP;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong yNQXMxAMWbFelzLXHbsdJMorBPmnA(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string GrUvlvAryaKEFmKxqbwqeWaFrOJMA(Dictionary<ulong, string> P_0, ulong P_1)
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
