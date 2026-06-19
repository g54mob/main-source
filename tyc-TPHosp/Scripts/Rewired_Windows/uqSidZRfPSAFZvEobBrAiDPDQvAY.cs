using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class uqSidZRfPSAFZvEobBrAiDPDQvAY : ISteamControllerInternal
{
	private static Dictionary<string, ulong> XpQXXfytmnljGfaAQXaXqHJFPxY;

	private static Dictionary<string, ulong> GOgyAjHEYcRBagsEewzyyNVsGKr;

	private static Dictionary<string, ulong> bITSMSEQAFepUvWsWZUMYYbDpio;

	private static Dictionary<ulong, string> ZcKejjHyZGMvyNVrNEwBpKArUWCh;

	private static Dictionary<ulong, string> KVyfgoLCkbCGBHLUQODyTqtzePh;

	private static Dictionary<ulong, string> rkFonQAWeKwtgQuezlTfHeXOqi;

	public readonly ulong QKfWUmQrhZXRTJJoiytOzVINFbH;

	private iqoHqKYmDCfGdPlCBGXPeaMvHATv[] jPGtTmvTeHevCRJEiAIkzKuonPV;

	private List<SteamControllerActionOrigin> qmlCrqnwAHnSCNQgbDTivOZfFXU;

	private ReadOnlyCollection<SteamControllerActionOrigin> TzttXfoSVBRbMsRwzpYlIvgGMVj;

	public int MaxActionSourceCount => 8;

	public bool IsConnected => jRkZySmBQrODEOSdUXsFbRxPnwx.dkeoaMLMDHGpXPOSODLWIVcrjDF(QKfWUmQrhZXRTJJoiytOzVINFbH);

	public static void IvAuvdvhHlYBQKAdRESVFdeMtoJ(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			XpQXXfytmnljGfaAQXaXqHJFPxY = P_0;
			ZcKejjHyZGMvyNVrNEwBpKArUWCh = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void jgdgEhHujrGWwaFvCxFbRpLBkfPg(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			GOgyAjHEYcRBagsEewzyyNVsGKr = P_0;
			KVyfgoLCkbCGBHLUQODyTqtzePh = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void XNJIleoRySLnrzcssFEMClPFtoO(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			bITSMSEQAFepUvWsWZUMYYbDpio = P_0;
			rkFonQAWeKwtgQuezlTfHeXOqi = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public uqSidZRfPSAFZvEobBrAiDPDQvAY(ulong handle)
	{
		QKfWUmQrhZXRTJJoiytOzVINFbH = handle;
		jPGtTmvTeHevCRJEiAIkzKuonPV = new iqoHqKYmDCfGdPlCBGXPeaMvHATv[8];
		qmlCrqnwAHnSCNQgbDTivOZfFXU = new List<SteamControllerActionOrigin>(8);
		TzttXfoSVBRbMsRwzpYlIvgGMVj = new ReadOnlyCollection<SteamControllerActionOrigin>(qmlCrqnwAHnSCNQgbDTivOZfFXU);
	}

	public string GetActionSetName(ulong handle)
	{
		return NQJCzHfWJaOfMaZqpCVxvnKYhcH(ZcKejjHyZGMvyNVrNEwBpKArUWCh, handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return NQJCzHfWJaOfMaZqpCVxvnKYhcH(rkFonQAWeKwtgQuezlTfHeXOqi, handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return NQJCzHfWJaOfMaZqpCVxvnKYhcH(KVyfgoLCkbCGBHLUQODyTqtzePh, handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return jJsPvWsFcCmImQeKqNRKUjHOobh(XpQXXfytmnljGfaAQXaXqHJFPxY, ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return jJsPvWsFcCmImQeKqNRKUjHOobh(bITSMSEQAFepUvWsWZUMYYbDpio, ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return jJsPvWsFcCmImQeKqNRKUjHOobh(GOgyAjHEYcRBagsEewzyyNVsGKr, ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (actionHandle == 0)
		{
			return default(Vector2);
		}
		try
		{
			xBcnlmYIpneCCKTuAViMHXUXMWA xBcnlmYIpneCCKTuAViMHXUXMWA2 = jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.xEGVEQEjidBiSPxYRixuPvgKNPa(QKfWUmQrhZXRTJJoiytOzVINFbH, actionHandle);
			if (!xBcnlmYIpneCCKTuAViMHXUXMWA2.ebBMxMFWYOIirUJCWUhIEMsXyUl)
			{
				return default(Vector2);
			}
			return new Vector2(xBcnlmYIpneCCKTuAViMHXUXMWA2.piYIQHIxjkcqcJLfkQtPcRIracF, xBcnlmYIpneCCKTuAViMHXUXMWA2.PUThFkwsTStPGwrINLnQiDQBLHl);
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
			YcNnJfWfSCIgoqbtiurKVTqdqnN ycNnJfWfSCIgoqbtiurKVTqdqnN = jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.PSvkFRPUYSmYNogmQVlEHYeKpSa(QKfWUmQrhZXRTJJoiytOzVINFbH, actionHandle);
			Debug.Log(actionHandle + " state = " + ycNnJfWfSCIgoqbtiurKVTqdqnN.STiSrIPnNwqjywRlhNvqolksgMa + " active = " + ycNnJfWfSCIgoqbtiurKVTqdqnN.ebBMxMFWYOIirUJCWUhIEMsXyUl);
			return ycNnJfWfSCIgoqbtiurKVTqdqnN.ebBMxMFWYOIirUJCWUhIEMsXyUl && ycNnJfWfSCIgoqbtiurKVTqdqnN.STiSrIPnNwqjywRlhNvqolksgMa;
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
			jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.EKznepqjATpabysMuFlXIYelqhPb(QKfWUmQrhZXRTJJoiytOzVINFbH, actionSetHandle);
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
		return jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.dybBqwDrOEOonNsHhKvsUqTGfUrW(QKfWUmQrhZXRTJJoiytOzVINFbH);
	}

	public string GetActiveActionSetName()
	{
		return NQJCzHfWJaOfMaZqpCVxvnKYhcH(ZcKejjHyZGMvyNVrNEwBpKArUWCh, jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.dybBqwDrOEOonNsHhKvsUqTGfUrW(QKfWUmQrhZXRTJJoiytOzVINFbH));
	}

	public void ShowBindingPanel()
	{
		jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.pzHGVyEKHrOYwagBsbZKsdHMOjI(QKfWUmQrhZXRTJJoiytOzVINFbH);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.oeXjMUTDFiqebnlsGvvYuhScZns(QKfWUmQrhZXRTJJoiytOzVINFbH, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.oeXjMUTDFiqebnlsGvvYuhScZns(QKfWUmQrhZXRTJJoiytOzVINFbH, (uint)triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(jJsPvWsFcCmImQeKqNRKUjHOobh(XpQXXfytmnljGfaAQXaXqHJFPxY, ref actionSetName), jJsPvWsFcCmImQeKqNRKUjHOobh(bITSMSEQAFepUvWsWZUMYYbDpio, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		qmlCrqnwAHnSCNQgbDTivOZfFXU.Clear();
		if (actionSetHandle == 0 || actionHandle == 0)
		{
			return TzttXfoSVBRbMsRwzpYlIvgGMVj;
		}
		int num = jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.EBYenzSfXBTgFqMQWsfoLgNPjaY(QKfWUmQrhZXRTJJoiytOzVINFbH, actionSetHandle, actionHandle, jPGtTmvTeHevCRJEiAIkzKuonPV);
		for (int i = 0; i < num; i++)
		{
			qmlCrqnwAHnSCNQgbDTivOZfFXU.Add((SteamControllerActionOrigin)jPGtTmvTeHevCRJEiAIkzKuonPV[i]);
		}
		return TzttXfoSVBRbMsRwzpYlIvgGMVj;
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(jJsPvWsFcCmImQeKqNRKUjHOobh(XpQXXfytmnljGfaAQXaXqHJFPxY, ref actionSetName), jJsPvWsFcCmImQeKqNRKUjHOobh(GOgyAjHEYcRBagsEewzyyNVsGKr, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		qmlCrqnwAHnSCNQgbDTivOZfFXU.Clear();
		if (actionSetHandle == 0 || actionHandle == 0)
		{
			return TzttXfoSVBRbMsRwzpYlIvgGMVj;
		}
		int num = jRkZySmBQrODEOSdUXsFbRxPnwx.ControllerManager.WgijENYaNZOCtJLOWfXCstiTfzP(QKfWUmQrhZXRTJJoiytOzVINFbH, actionSetHandle, actionHandle, jPGtTmvTeHevCRJEiAIkzKuonPV);
		for (int i = 0; i < num; i++)
		{
			qmlCrqnwAHnSCNQgbDTivOZfFXU.Add((SteamControllerActionOrigin)jPGtTmvTeHevCRJEiAIkzKuonPV[i]);
		}
		return TzttXfoSVBRbMsRwzpYlIvgGMVj;
	}

	private ulong jJsPvWsFcCmImQeKqNRKUjHOobh(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string NQJCzHfWJaOfMaZqpCVxvnKYhcH(Dictionary<ulong, string> P_0, ulong P_1)
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
