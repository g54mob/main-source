using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class VDeffWaGDSfcvgvnoQBsibVyDGRsA : ISteamControllerInternal
{
	private static Dictionary<string, ulong> GLjdCviEzqniOHIntVRoUQNaoRJIA;

	private static Dictionary<string, ulong> dIcEUhBKgjElPNiOYvJUcFnYgZAV;

	private static Dictionary<string, ulong> svhjiKJnNweijBKscRWSrYjshUEk;

	private static Dictionary<ulong, string> yoDkPYvfzTGMdQneQuBCuSFfKFmB;

	private static Dictionary<ulong, string> YqgpKuYgIVEtNmWydWhbcizuZvMp;

	private static Dictionary<ulong, string> iBxFmhnLPKreGPkLQlJPbShTnprC;

	public readonly ulong rGCenudqTjnhDWchSqSpowGRazLVA;

	private PaEvfTjDFAjvDBMDKOvjEKSCVnCQ[] ylIaKRhVKZjbbbPTaGhCkbVdDXYFA;

	private List<SteamControllerActionOrigin> pJDDsbqiFCKUhbRIaxDdSEkPcnmCA;

	private ReadOnlyCollection<SteamControllerActionOrigin> XZrDTTNDguaVjELyuqJATpHAHdudA;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => OYOIGRBdSvtlcCDiNolhDzvqhYiM.XvOcGrYftVRkVDzXWAXGCAMsFesY(rGCenudqTjnhDWchSqSpowGRazLVA);

	public static void essTRSuMSWXanKkXjvwfBvCniwCR(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			GLjdCviEzqniOHIntVRoUQNaoRJIA = P_0;
			yoDkPYvfzTGMdQneQuBCuSFfKFmB = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void BhDJOaRgZiGJZxJGXZgMyBTtTdO(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			dIcEUhBKgjElPNiOYvJUcFnYgZAV = P_0;
			YqgpKuYgIVEtNmWydWhbcizuZvMp = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void oJuZdWJoiblHYdPjLnQpXBljSqTM(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			svhjiKJnNweijBKscRWSrYjshUEk = P_0;
			iBxFmhnLPKreGPkLQlJPbShTnprC = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public VDeffWaGDSfcvgvnoQBsibVyDGRsA(ulong P_0)
	{
		rGCenudqTjnhDWchSqSpowGRazLVA = P_0;
		ylIaKRhVKZjbbbPTaGhCkbVdDXYFA = new PaEvfTjDFAjvDBMDKOvjEKSCVnCQ[8];
		pJDDsbqiFCKUhbRIaxDdSEkPcnmCA = new List<SteamControllerActionOrigin>(8);
		XZrDTTNDguaVjELyuqJATpHAHdudA = new ReadOnlyCollection<SteamControllerActionOrigin>(pJDDsbqiFCKUhbRIaxDdSEkPcnmCA);
	}

	public string GetActionSetName(ulong handle)
	{
		return PzfeimxStcEARPlOgBGhvAIiRgyC(yoDkPYvfzTGMdQneQuBCuSFfKFmB, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return PzfeimxStcEARPlOgBGhvAIiRgyC(iBxFmhnLPKreGPkLQlJPbShTnprC, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return PzfeimxStcEARPlOgBGhvAIiRgyC(YqgpKuYgIVEtNmWydWhbcizuZvMp, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return hzwDkOdmrKsbUKDVKNcBrUCAIRyA(GLjdCviEzqniOHIntVRoUQNaoRJIA, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return hzwDkOdmrKsbUKDVKNcBrUCAIRyA(svhjiKJnNweijBKscRWSrYjshUEk, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return hzwDkOdmrKsbUKDVKNcBrUCAIRyA(dIcEUhBKgjElPNiOYvJUcFnYgZAV, ref actionName);
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
			CmOeCrzvzdpDwNGtDMNmjeAeFrPS cmOeCrzvzdpDwNGtDMNmjeAeFrPS = OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.oZcpMDvHXpAkqTKXUbbEniKQQKMS(rGCenudqTjnhDWchSqSpowGRazLVA, actionHandle);
			if (!cmOeCrzvzdpDwNGtDMNmjeAeFrPS.fufKSLHknwGlfGGkYqKkZQUpDZNtA)
			{
				return default(Vector2);
			}
			return new Vector2(cmOeCrzvzdpDwNGtDMNmjeAeFrPS.IThFzfHiPvgJyFDRhgTBcjtiICGEC, cmOeCrzvzdpDwNGtDMNmjeAeFrPS.yLJUUJILUPokRpkzLVHnyyHcsUHE);
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
			bPldcedrfQKxEtcopnYafhgCgNGlA bPldcedrfQKxEtcopnYafhgCgNGlA2 = OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.wJTjRfFsBpIrctmBgXmqbJHeSmQf(rGCenudqTjnhDWchSqSpowGRazLVA, actionHandle);
			Debug.Log(actionHandle + " state = " + bPldcedrfQKxEtcopnYafhgCgNGlA2.lYDkaHYirpdsUIsQnqASHsyPrRrX + " active = " + bPldcedrfQKxEtcopnYafhgCgNGlA2.OaMOTIJSYAuqkzimSlUruBqcjZmF);
			return bPldcedrfQKxEtcopnYafhgCgNGlA2.OaMOTIJSYAuqkzimSlUruBqcjZmF && bPldcedrfQKxEtcopnYafhgCgNGlA2.lYDkaHYirpdsUIsQnqASHsyPrRrX;
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
			OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.XffqsEVyydRLbAnecNOfCbtdBQaY(rGCenudqTjnhDWchSqSpowGRazLVA, actionSetHandle);
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
		return OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.tCFkoWBAjKfNUAmKIgivHamsJTiBb(rGCenudqTjnhDWchSqSpowGRazLVA);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return PzfeimxStcEARPlOgBGhvAIiRgyC(yoDkPYvfzTGMdQneQuBCuSFfKFmB, OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.tCFkoWBAjKfNUAmKIgivHamsJTiBb(rGCenudqTjnhDWchSqSpowGRazLVA));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.dDyMHEPQHmNcTTKtzdfjsfudGMRW(rGCenudqTjnhDWchSqSpowGRazLVA);
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
		OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.PqnPFJYtcDuDFVRkDHqapRooEMiy(rGCenudqTjnhDWchSqSpowGRazLVA, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.PqnPFJYtcDuDFVRkDHqapRooEMiy(rGCenudqTjnhDWchSqSpowGRazLVA, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(hzwDkOdmrKsbUKDVKNcBrUCAIRyA(GLjdCviEzqniOHIntVRoUQNaoRJIA, ref actionSetName), hzwDkOdmrKsbUKDVKNcBrUCAIRyA(svhjiKJnNweijBKscRWSrYjshUEk, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		pJDDsbqiFCKUhbRIaxDdSEkPcnmCA.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return XZrDTTNDguaVjELyuqJATpHAHdudA;
		}
		int num = OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.dUbFuVgbGbakqoUrtiClgRyofBGab(rGCenudqTjnhDWchSqSpowGRazLVA, actionSetHandle, actionHandle, ylIaKRhVKZjbbbPTaGhCkbVdDXYFA);
		for (int i = 0; i < num; i++)
		{
			pJDDsbqiFCKUhbRIaxDdSEkPcnmCA.Add((SteamControllerActionOrigin)ylIaKRhVKZjbbbPTaGhCkbVdDXYFA[i]);
		}
		return XZrDTTNDguaVjELyuqJATpHAHdudA;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(hzwDkOdmrKsbUKDVKNcBrUCAIRyA(GLjdCviEzqniOHIntVRoUQNaoRJIA, ref actionSetName), hzwDkOdmrKsbUKDVKNcBrUCAIRyA(dIcEUhBKgjElPNiOYvJUcFnYgZAV, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		pJDDsbqiFCKUhbRIaxDdSEkPcnmCA.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return XZrDTTNDguaVjELyuqJATpHAHdudA;
		}
		int num = OYOIGRBdSvtlcCDiNolhDzvqhYiM.etVTZAnADSaYoFXACbePQlgKtnUIA.aTIQayYxgijXyTaichAjAgHPeaPP(rGCenudqTjnhDWchSqSpowGRazLVA, actionSetHandle, actionHandle, ylIaKRhVKZjbbbPTaGhCkbVdDXYFA);
		for (int i = 0; i < num; i++)
		{
			pJDDsbqiFCKUhbRIaxDdSEkPcnmCA.Add((SteamControllerActionOrigin)ylIaKRhVKZjbbbPTaGhCkbVdDXYFA[i]);
		}
		return XZrDTTNDguaVjELyuqJATpHAHdudA;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong hzwDkOdmrKsbUKDVKNcBrUCAIRyA(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string PzfeimxStcEARPlOgBGhvAIiRgyC(Dictionary<ulong, string> P_0, ulong P_1)
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
