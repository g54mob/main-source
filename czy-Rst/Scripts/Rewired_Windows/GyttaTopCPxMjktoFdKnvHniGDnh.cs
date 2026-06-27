using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class GyttaTopCPxMjktoFdKnvHniGDnh : ISteamControllerInternal
{
	private static Dictionary<string, ulong> HYqAQyAAFbZxYPYnGOlzQhPglBty;

	private static Dictionary<string, ulong> wUvLIuHqAieDFEsMhDZFAmbYSPqHb;

	private static Dictionary<string, ulong> xcAiBJihrvbzSiqBkkRpNlucryt;

	private static Dictionary<ulong, string> dghjkWdeNkQXWLslPiEMyGGrgGfcA;

	private static Dictionary<ulong, string> LQvYyrMuCCiQJvwuCBHcszTwnGqe;

	private static Dictionary<ulong, string> vBcuHepofHKsMIkipFVUnHCHIlBKA;

	public readonly ulong aDPBdzgdrstsBfnzbQkyikCDkplN;

	private EDVVlWhtjXemJYKLlYLqGKEQOjwR[] fvFCOOzukOcgjemXROXXhwDluHggA;

	private List<SteamControllerActionOrigin> yaKiTaksvDlHzjmShTnwqEaGTjhSd;

	private ReadOnlyCollection<SteamControllerActionOrigin> UfcePKdFOtlGzHHaATpDQNDkKlMjc;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => FDpUYRsekgyeNpuqDTyFznyUiWj.KlBcScaSHKTvHLCFzafJTQAsmwYzA(aDPBdzgdrstsBfnzbQkyikCDkplN);

	public static void tRhZVLqUoLbXjPbZQEWoRIGfaIsL(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			HYqAQyAAFbZxYPYnGOlzQhPglBty = P_0;
			dghjkWdeNkQXWLslPiEMyGGrgGfcA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void WQiIDByKMKsBBUmBxNhtYWDVwBDM(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			wUvLIuHqAieDFEsMhDZFAmbYSPqHb = P_0;
			LQvYyrMuCCiQJvwuCBHcszTwnGqe = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void lBbflHZtGeEYUkFhyFqeRQphKcno(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			xcAiBJihrvbzSiqBkkRpNlucryt = P_0;
			vBcuHepofHKsMIkipFVUnHCHIlBKA = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public GyttaTopCPxMjktoFdKnvHniGDnh(ulong P_0)
	{
		aDPBdzgdrstsBfnzbQkyikCDkplN = P_0;
		fvFCOOzukOcgjemXROXXhwDluHggA = new EDVVlWhtjXemJYKLlYLqGKEQOjwR[8];
		yaKiTaksvDlHzjmShTnwqEaGTjhSd = new List<SteamControllerActionOrigin>(8);
		UfcePKdFOtlGzHHaATpDQNDkKlMjc = new ReadOnlyCollection<SteamControllerActionOrigin>(yaKiTaksvDlHzjmShTnwqEaGTjhSd);
	}

	public string GetActionSetName(ulong handle)
	{
		return IHsDifbYutQLXMudVrjsjUCcJFKo(dghjkWdeNkQXWLslPiEMyGGrgGfcA, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return IHsDifbYutQLXMudVrjsjUCcJFKo(vBcuHepofHKsMIkipFVUnHCHIlBKA, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return IHsDifbYutQLXMudVrjsjUCcJFKo(LQvYyrMuCCiQJvwuCBHcszTwnGqe, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return iGsjVnbrAkpxxHFFcftlpkQOkEdN(HYqAQyAAFbZxYPYnGOlzQhPglBty, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return iGsjVnbrAkpxxHFFcftlpkQOkEdN(xcAiBJihrvbzSiqBkkRpNlucryt, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return iGsjVnbrAkpxxHFFcftlpkQOkEdN(wUvLIuHqAieDFEsMhDZFAmbYSPqHb, ref actionName);
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
			DtVxayjmPwZyyWcrudcrhtQawzreA dtVxayjmPwZyyWcrudcrhtQawzreA = FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.zkvEjKavhontibSNpEBRXnEErCstA(aDPBdzgdrstsBfnzbQkyikCDkplN, actionHandle);
			if (!dtVxayjmPwZyyWcrudcrhtQawzreA.goGSIBIZprqlVtgzuqdELSzFRdX)
			{
				return default(Vector2);
			}
			return new Vector2(dtVxayjmPwZyyWcrudcrhtQawzreA.ZMszPceIzuCSuYbFVIxGDjlGQEsnA, dtVxayjmPwZyyWcrudcrhtQawzreA.tqOQWEIZjSJtJixycMnkqAwaCopY);
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
			uPoAslrQZLkxUtAyEqNffemIiDaO uPoAslrQZLkxUtAyEqNffemIiDaO2 = FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.baAyloTVbgMZgiWTDonxvfNqOCuo(aDPBdzgdrstsBfnzbQkyikCDkplN, actionHandle);
			Debug.Log(actionHandle + " state = " + uPoAslrQZLkxUtAyEqNffemIiDaO2.efQscWAdZimpEVvMQveNDFgTHBTjA + " active = " + uPoAslrQZLkxUtAyEqNffemIiDaO2.FDFwYFLfiXZjkwCqzxRqsIaiYbOv);
			return uPoAslrQZLkxUtAyEqNffemIiDaO2.FDFwYFLfiXZjkwCqzxRqsIaiYbOv && uPoAslrQZLkxUtAyEqNffemIiDaO2.efQscWAdZimpEVvMQveNDFgTHBTjA;
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
			FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.GgiiaRjZOcHYhViiJGduBYnfZCKw(aDPBdzgdrstsBfnzbQkyikCDkplN, actionSetHandle);
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
		return FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.ycMHyDBVZTSSSENQzcQwuqqgxFIBA(aDPBdzgdrstsBfnzbQkyikCDkplN);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return IHsDifbYutQLXMudVrjsjUCcJFKo(dghjkWdeNkQXWLslPiEMyGGrgGfcA, FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.ycMHyDBVZTSSSENQzcQwuqqgxFIBA(aDPBdzgdrstsBfnzbQkyikCDkplN));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.ixveEJNmyhxCFSQtQqXuqqkzFQxv(aDPBdzgdrstsBfnzbQkyikCDkplN);
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
		FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.YQaXcMIiWKWCHScaikQvrCoySQAu(aDPBdzgdrstsBfnzbQkyikCDkplN, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.YQaXcMIiWKWCHScaikQvrCoySQAu(aDPBdzgdrstsBfnzbQkyikCDkplN, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(iGsjVnbrAkpxxHFFcftlpkQOkEdN(HYqAQyAAFbZxYPYnGOlzQhPglBty, ref actionSetName), iGsjVnbrAkpxxHFFcftlpkQOkEdN(xcAiBJihrvbzSiqBkkRpNlucryt, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		yaKiTaksvDlHzjmShTnwqEaGTjhSd.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return UfcePKdFOtlGzHHaATpDQNDkKlMjc;
		}
		int num = FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.wQimPSrayiAvkVMtACaoZfsmbXkdA(aDPBdzgdrstsBfnzbQkyikCDkplN, actionSetHandle, actionHandle, fvFCOOzukOcgjemXROXXhwDluHggA);
		for (int i = 0; i < num; i++)
		{
			yaKiTaksvDlHzjmShTnwqEaGTjhSd.Add((SteamControllerActionOrigin)fvFCOOzukOcgjemXROXXhwDluHggA[i]);
		}
		return UfcePKdFOtlGzHHaATpDQNDkKlMjc;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(iGsjVnbrAkpxxHFFcftlpkQOkEdN(HYqAQyAAFbZxYPYnGOlzQhPglBty, ref actionSetName), iGsjVnbrAkpxxHFFcftlpkQOkEdN(wUvLIuHqAieDFEsMhDZFAmbYSPqHb, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		yaKiTaksvDlHzjmShTnwqEaGTjhSd.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return UfcePKdFOtlGzHHaATpDQNDkKlMjc;
		}
		int num = FDpUYRsekgyeNpuqDTyFznyUiWj.tQENwRjUtHHLyKgGpQeAfDoSIfoy.fLBSCrAiOtyUuIWyLRBwWcXXmVrl(aDPBdzgdrstsBfnzbQkyikCDkplN, actionSetHandle, actionHandle, fvFCOOzukOcgjemXROXXhwDluHggA);
		for (int i = 0; i < num; i++)
		{
			yaKiTaksvDlHzjmShTnwqEaGTjhSd.Add((SteamControllerActionOrigin)fvFCOOzukOcgjemXROXXhwDluHggA[i]);
		}
		return UfcePKdFOtlGzHHaATpDQNDkKlMjc;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong iGsjVnbrAkpxxHFFcftlpkQOkEdN(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string IHsDifbYutQLXMudVrjsjUCcJFKo(Dictionary<ulong, string> P_0, ulong P_1)
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
