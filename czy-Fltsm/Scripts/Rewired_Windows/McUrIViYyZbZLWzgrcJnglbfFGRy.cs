using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class McUrIViYyZbZLWzgrcJnglbfFGRy : ISteamControllerInternal
{
	private static Dictionary<string, ulong> JONydiMCYhsFcnuewWLtBftbtHDw;

	private static Dictionary<string, ulong> aEKvaPDLzelhZgXgTbNQpNhDPhSd;

	private static Dictionary<string, ulong> fzFLLNXJkxNPJeYdnpAPqnFjGpSKA;

	private static Dictionary<ulong, string> dTMHSSpiWirncjHajgOSbIscIgDI;

	private static Dictionary<ulong, string> DtKkjrWKrCOMnHhtcGlaDlVpsxGAA;

	private static Dictionary<ulong, string> ryBcsGlooHCcMspaNbeQsgKQlwte;

	public readonly ulong adeBOzhkuszQxATcVJYohnqMypRcA;

	private AecQSKzHaZBOdsxUXFlyXAcNubIn[] bOmzbUfavMASTMXIzrJNvbfuBjKf;

	private List<SteamControllerActionOrigin> aGfqeioCaVCpHKcTvmJmHlMCazeK;

	private ReadOnlyCollection<SteamControllerActionOrigin> EBZwxOXjVriCNrXhxZIHEnfBxdcH;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => HckNzGNcbwxQCjtnMqvuMlPtZUiQ.IxyrakKSGYHczglKVXkFVBwrbgir(adeBOzhkuszQxATcVJYohnqMypRcA);

	public static void dwKDsJdoxPcDPXdQeegsqYsiiuSHA(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			JONydiMCYhsFcnuewWLtBftbtHDw = P_0;
			dTMHSSpiWirncjHajgOSbIscIgDI = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void YORaDFcfXIxvpaaUBJkhREzARRxJ(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			aEKvaPDLzelhZgXgTbNQpNhDPhSd = P_0;
			DtKkjrWKrCOMnHhtcGlaDlVpsxGAA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void bGWxINTPLiFkcHQgMEGwvIRggwPBb(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			fzFLLNXJkxNPJeYdnpAPqnFjGpSKA = P_0;
			ryBcsGlooHCcMspaNbeQsgKQlwte = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public McUrIViYyZbZLWzgrcJnglbfFGRy(ulong P_0)
	{
		adeBOzhkuszQxATcVJYohnqMypRcA = P_0;
		bOmzbUfavMASTMXIzrJNvbfuBjKf = new AecQSKzHaZBOdsxUXFlyXAcNubIn[8];
		aGfqeioCaVCpHKcTvmJmHlMCazeK = new List<SteamControllerActionOrigin>(8);
		EBZwxOXjVriCNrXhxZIHEnfBxdcH = new ReadOnlyCollection<SteamControllerActionOrigin>(aGfqeioCaVCpHKcTvmJmHlMCazeK);
	}

	public string GetActionSetName(ulong handle)
	{
		return CCBTfdrDprhmzwCsdHdocgydLuuL(dTMHSSpiWirncjHajgOSbIscIgDI, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return CCBTfdrDprhmzwCsdHdocgydLuuL(ryBcsGlooHCcMspaNbeQsgKQlwte, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return CCBTfdrDprhmzwCsdHdocgydLuuL(DtKkjrWKrCOMnHhtcGlaDlVpsxGAA, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return kRRwSfjkLoDxDxSSGBGfyHkPAEHS(JONydiMCYhsFcnuewWLtBftbtHDw, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return kRRwSfjkLoDxDxSSGBGfyHkPAEHS(fzFLLNXJkxNPJeYdnpAPqnFjGpSKA, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return kRRwSfjkLoDxDxSSGBGfyHkPAEHS(aEKvaPDLzelhZgXgTbNQpNhDPhSd, ref actionName);
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
			LQgaTmpPCkIYMyAmEnWzeWcljdPW lQgaTmpPCkIYMyAmEnWzeWcljdPW = HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.bWEEBKfDimJDSmlEVfdVKueFKWATA(adeBOzhkuszQxATcVJYohnqMypRcA, actionHandle);
			if (!lQgaTmpPCkIYMyAmEnWzeWcljdPW.uXDnbOLhGtmGTvmzLJKnDqwmbPPEA)
			{
				return default(Vector2);
			}
			return new Vector2(lQgaTmpPCkIYMyAmEnWzeWcljdPW.XOPVEmeDuguiGsRKbPNKoePTlAAT, lQgaTmpPCkIYMyAmEnWzeWcljdPW.xOnhUMScySXpKSjmURqXjYqhgHKB);
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
			sRPyBxxmGNdGsVrhyGEnivKBBBUFA sRPyBxxmGNdGsVrhyGEnivKBBBUFA2 = HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.vNldIyPTgkHzGOaYjSZdyklnuCIt(adeBOzhkuszQxATcVJYohnqMypRcA, actionHandle);
			Debug.Log(actionHandle + " state = " + sRPyBxxmGNdGsVrhyGEnivKBBBUFA2.aCzVxGWCIoEBklMHwBGNQsAMJsfK + " active = " + sRPyBxxmGNdGsVrhyGEnivKBBBUFA2.BeknETRGjLIDUQppLEbclCMlWduX);
			return sRPyBxxmGNdGsVrhyGEnivKBBBUFA2.BeknETRGjLIDUQppLEbclCMlWduX && sRPyBxxmGNdGsVrhyGEnivKBBBUFA2.aCzVxGWCIoEBklMHwBGNQsAMJsfK;
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
			HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.McHJEXZbDcBoTlVvlkRiNnTwTAuT(adeBOzhkuszQxATcVJYohnqMypRcA, actionSetHandle);
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
		return HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.yYjXQHTmSLiDqxVNRyQkrKvxLfsf(adeBOzhkuszQxATcVJYohnqMypRcA);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return CCBTfdrDprhmzwCsdHdocgydLuuL(dTMHSSpiWirncjHajgOSbIscIgDI, HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.yYjXQHTmSLiDqxVNRyQkrKvxLfsf(adeBOzhkuszQxATcVJYohnqMypRcA));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.aHWhSLXhYnkWlmmZirPwpIewGRDe(adeBOzhkuszQxATcVJYohnqMypRcA);
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
		HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.MtRKgECMXKBsricnQaqtQsAlUIoSA(adeBOzhkuszQxATcVJYohnqMypRcA, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.MtRKgECMXKBsricnQaqtQsAlUIoSA(adeBOzhkuszQxATcVJYohnqMypRcA, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(kRRwSfjkLoDxDxSSGBGfyHkPAEHS(JONydiMCYhsFcnuewWLtBftbtHDw, ref actionSetName), kRRwSfjkLoDxDxSSGBGfyHkPAEHS(fzFLLNXJkxNPJeYdnpAPqnFjGpSKA, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		aGfqeioCaVCpHKcTvmJmHlMCazeK.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return EBZwxOXjVriCNrXhxZIHEnfBxdcH;
		}
		int num = HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.aQJVRUnyleFVGpjagxKoWROzFHOo(adeBOzhkuszQxATcVJYohnqMypRcA, actionSetHandle, actionHandle, bOmzbUfavMASTMXIzrJNvbfuBjKf);
		for (int i = 0; i < num; i++)
		{
			aGfqeioCaVCpHKcTvmJmHlMCazeK.Add((SteamControllerActionOrigin)bOmzbUfavMASTMXIzrJNvbfuBjKf[i]);
		}
		return EBZwxOXjVriCNrXhxZIHEnfBxdcH;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(kRRwSfjkLoDxDxSSGBGfyHkPAEHS(JONydiMCYhsFcnuewWLtBftbtHDw, ref actionSetName), kRRwSfjkLoDxDxSSGBGfyHkPAEHS(aEKvaPDLzelhZgXgTbNQpNhDPhSd, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		aGfqeioCaVCpHKcTvmJmHlMCazeK.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return EBZwxOXjVriCNrXhxZIHEnfBxdcH;
		}
		int num = HckNzGNcbwxQCjtnMqvuMlPtZUiQ.lxnDeNdlkFbrWOcJTzuOHmURGzQRA.hWgdonQzXzSjYiPbjzssBNzMuCJl(adeBOzhkuszQxATcVJYohnqMypRcA, actionSetHandle, actionHandle, bOmzbUfavMASTMXIzrJNvbfuBjKf);
		for (int i = 0; i < num; i++)
		{
			aGfqeioCaVCpHKcTvmJmHlMCazeK.Add((SteamControllerActionOrigin)bOmzbUfavMASTMXIzrJNvbfuBjKf[i]);
		}
		return EBZwxOXjVriCNrXhxZIHEnfBxdcH;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong kRRwSfjkLoDxDxSSGBGfyHkPAEHS(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string CCBTfdrDprhmzwCsdHdocgydLuuL(Dictionary<ulong, string> P_0, ulong P_1)
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
