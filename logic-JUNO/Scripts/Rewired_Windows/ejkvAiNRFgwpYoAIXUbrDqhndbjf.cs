using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class ejkvAiNRFgwpYoAIXUbrDqhndbjf : ISteamControllerInternal
{
	private static Dictionary<string, ulong> bDhdWLrppGTufRaUQxGnkgilRqrT;

	private static Dictionary<string, ulong> QFmLKDmbcJSEuKOjnhoDiCEXKgswA;

	private static Dictionary<string, ulong> XjxquclXAcVUGvXHRkZNNUdKKsJ;

	private static Dictionary<ulong, string> ZrghijSSlJBYnPrAXjrISKhexwfl;

	private static Dictionary<ulong, string> vFuIjEfDYhbysxVAKuLqMSPzAgJc;

	private static Dictionary<ulong, string> BnhrJTUzBscvtKLFvjaGVohKcSNW;

	public readonly ulong GYObWMJdHLdsmlDQzHHcSlxOAWpZ;

	private uiWvflSGPwNlsWjatZgmgmfVvYqq[] BJUEGbEEEbnfSeogBDmFYGskVycsA;

	private List<SteamControllerActionOrigin> KvPfBNhXJuaGCxmfZuMyAsROmYQCA;

	private ReadOnlyCollection<SteamControllerActionOrigin> eKbEXfmryWDJIjLPXAODBzibDWCAB;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => xANCvfeUFnvBaPXgIoyfrYbxtOgB.iqCBCPffjfLuaCxsnyILoBlrmTQm(GYObWMJdHLdsmlDQzHHcSlxOAWpZ);

	public static void TxyVTuPTOwoJMHpcAjSknkliNhwH(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			bDhdWLrppGTufRaUQxGnkgilRqrT = P_0;
			ZrghijSSlJBYnPrAXjrISKhexwfl = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void wwrITuPNkzcYwEwmraOloZiOcgHO(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			QFmLKDmbcJSEuKOjnhoDiCEXKgswA = P_0;
			vFuIjEfDYhbysxVAKuLqMSPzAgJc = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void FMkCfoiEwXPBjwSKmJXsjdOeBNhM(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			XjxquclXAcVUGvXHRkZNNUdKKsJ = P_0;
			BnhrJTUzBscvtKLFvjaGVohKcSNW = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public ejkvAiNRFgwpYoAIXUbrDqhndbjf(ulong P_0)
	{
		GYObWMJdHLdsmlDQzHHcSlxOAWpZ = P_0;
		BJUEGbEEEbnfSeogBDmFYGskVycsA = new uiWvflSGPwNlsWjatZgmgmfVvYqq[8];
		KvPfBNhXJuaGCxmfZuMyAsROmYQCA = new List<SteamControllerActionOrigin>(8);
		eKbEXfmryWDJIjLPXAODBzibDWCAB = new ReadOnlyCollection<SteamControllerActionOrigin>(KvPfBNhXJuaGCxmfZuMyAsROmYQCA);
	}

	public string GetActionSetName(ulong handle)
	{
		return ywlDkSOJYSxIqKSGRlIsNszzOkMM(ZrghijSSlJBYnPrAXjrISKhexwfl, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return ywlDkSOJYSxIqKSGRlIsNszzOkMM(BnhrJTUzBscvtKLFvjaGVohKcSNW, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return ywlDkSOJYSxIqKSGRlIsNszzOkMM(vFuIjEfDYhbysxVAKuLqMSPzAgJc, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return EsdhFYYQwBSiIPDewxYjZwlVolrn(bDhdWLrppGTufRaUQxGnkgilRqrT, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return EsdhFYYQwBSiIPDewxYjZwlVolrn(XjxquclXAcVUGvXHRkZNNUdKKsJ, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return EsdhFYYQwBSiIPDewxYjZwlVolrn(QFmLKDmbcJSEuKOjnhoDiCEXKgswA, ref actionName);
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
			vxCXqNMOlBTbDGsMihLzcRhpbEvgb vxCXqNMOlBTbDGsMihLzcRhpbEvgb2 = xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.TveCdtcIBDBqZZQofagHvLtHnlohA(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, actionHandle);
			if (!vxCXqNMOlBTbDGsMihLzcRhpbEvgb2.KfdShgmtMzpASXTxRDziirmwehJA)
			{
				return default(Vector2);
			}
			return new Vector2(vxCXqNMOlBTbDGsMihLzcRhpbEvgb2.niltqNHEHFiRPCAiJCUMbHERKtyUA, vxCXqNMOlBTbDGsMihLzcRhpbEvgb2.TUHQCvzyXzAqokYPkNEcSAZpKXlO);
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
			SEfdcWEofyUftbzTINRpPpFHstyJ sEfdcWEofyUftbzTINRpPpFHstyJ = xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.BFJynXweTJGYDGgqTvCviJehSjulA(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, actionHandle);
			Debug.Log(actionHandle + " state = " + sEfdcWEofyUftbzTINRpPpFHstyJ.ATPSwhvBdZWmpRwrCRRZthDScwXv + " active = " + sEfdcWEofyUftbzTINRpPpFHstyJ.viCWOqurKcrkFsDHfbcaKwJnfIMGA);
			return sEfdcWEofyUftbzTINRpPpFHstyJ.viCWOqurKcrkFsDHfbcaKwJnfIMGA && sEfdcWEofyUftbzTINRpPpFHstyJ.ATPSwhvBdZWmpRwrCRRZthDScwXv;
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
			xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.oQnfikEycZIVQIDXRRKmGyAuntEUA(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, actionSetHandle);
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
		return xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.OoNFwoqsxuYTnVpntSxkQSTremQQ(GYObWMJdHLdsmlDQzHHcSlxOAWpZ);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return ywlDkSOJYSxIqKSGRlIsNszzOkMM(ZrghijSSlJBYnPrAXjrISKhexwfl, xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.OoNFwoqsxuYTnVpntSxkQSTremQQ(GYObWMJdHLdsmlDQzHHcSlxOAWpZ));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.MLahMcgrUKTFoWPOCWuaMCNgXbdx(GYObWMJdHLdsmlDQzHHcSlxOAWpZ);
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
		xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.gFbJMxnEgdDsqOfNmbwfBtZjrCQj(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.gFbJMxnEgdDsqOfNmbwfBtZjrCQj(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(EsdhFYYQwBSiIPDewxYjZwlVolrn(bDhdWLrppGTufRaUQxGnkgilRqrT, ref actionSetName), EsdhFYYQwBSiIPDewxYjZwlVolrn(XjxquclXAcVUGvXHRkZNNUdKKsJ, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		KvPfBNhXJuaGCxmfZuMyAsROmYQCA.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return eKbEXfmryWDJIjLPXAODBzibDWCAB;
		}
		int num = xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.ILreQdQBGJksBXoWWNEcxzTrgyuH(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, actionSetHandle, actionHandle, BJUEGbEEEbnfSeogBDmFYGskVycsA);
		for (int i = 0; i < num; i++)
		{
			KvPfBNhXJuaGCxmfZuMyAsROmYQCA.Add((SteamControllerActionOrigin)BJUEGbEEEbnfSeogBDmFYGskVycsA[i]);
		}
		return eKbEXfmryWDJIjLPXAODBzibDWCAB;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(EsdhFYYQwBSiIPDewxYjZwlVolrn(bDhdWLrppGTufRaUQxGnkgilRqrT, ref actionSetName), EsdhFYYQwBSiIPDewxYjZwlVolrn(QFmLKDmbcJSEuKOjnhoDiCEXKgswA, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		KvPfBNhXJuaGCxmfZuMyAsROmYQCA.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return eKbEXfmryWDJIjLPXAODBzibDWCAB;
		}
		int num = xANCvfeUFnvBaPXgIoyfrYbxtOgB.VVXJugOVRqUILSgjrEtERjLHcSaGA.LQISMEpyqSIrTYSFBSagisuWeZxK(GYObWMJdHLdsmlDQzHHcSlxOAWpZ, actionSetHandle, actionHandle, BJUEGbEEEbnfSeogBDmFYGskVycsA);
		for (int i = 0; i < num; i++)
		{
			KvPfBNhXJuaGCxmfZuMyAsROmYQCA.Add((SteamControllerActionOrigin)BJUEGbEEEbnfSeogBDmFYGskVycsA[i]);
		}
		return eKbEXfmryWDJIjLPXAODBzibDWCAB;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong EsdhFYYQwBSiIPDewxYjZwlVolrn(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string ywlDkSOJYSxIqKSGRlIsNszzOkMM(Dictionary<ulong, string> P_0, ulong P_1)
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
