using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class OPSbyaVxJhyRCGPHwBCJIehphDYL : ISteamControllerInternal
{
	private static Dictionary<string, ulong> lwGPEWoxKKGINEXhPlQUrIlrMjAW;

	private static Dictionary<string, ulong> sXkOHONKuRzaxLFjjwBdfHjOFUxGA;

	private static Dictionary<string, ulong> JCJPZhQogakQBKPTFbsVPkVzyWol;

	private static Dictionary<ulong, string> jkCDaAcJjlMYjoeACwQGNtqFRMOp;

	private static Dictionary<ulong, string> yeqeFJTKzUrSKqhAPpFvCXlZRxbC;

	private static Dictionary<ulong, string> BCwCVMUekLBlgRXNzKTOcpEzHSyQ;

	public readonly ulong uNlFkVYKZoatWcCgpCOZkOxrJyJj;

	private IqmAtnKCbdidswcxQNdWcpcJTEVXB[] RRYCkgrApaGRwhqqruezWmiOobVqA;

	private List<SteamControllerActionOrigin> IohFLLledoEQLaLLmvvzurwJHWrB;

	private ReadOnlyCollection<SteamControllerActionOrigin> hghsUAqmYqcMDBcMkRakDFwoQGpf;

	public int MaxActionSourceCount => 8;

	public bool IsConnected => VGeCGxkGsAvcDpaEHgxGyULfSbjr.RWgdqvZtporWUmvpXdNRJOfRtvDE(uNlFkVYKZoatWcCgpCOZkOxrJyJj);

	public static void sKStUWlBTInWVtuYOsfWQOuytyJC(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			lwGPEWoxKKGINEXhPlQUrIlrMjAW = P_0;
			jkCDaAcJjlMYjoeACwQGNtqFRMOp = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void NbdLVYTXLOmzzglCNDzioTndNvZM(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			sXkOHONKuRzaxLFjjwBdfHjOFUxGA = P_0;
			yeqeFJTKzUrSKqhAPpFvCXlZRxbC = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void pXBeoFgoMtCuoQURlQsFeLxzauEfb(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			JCJPZhQogakQBKPTFbsVPkVzyWol = P_0;
			BCwCVMUekLBlgRXNzKTOcpEzHSyQ = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public OPSbyaVxJhyRCGPHwBCJIehphDYL(ulong P_0)
	{
		uNlFkVYKZoatWcCgpCOZkOxrJyJj = P_0;
		RRYCkgrApaGRwhqqruezWmiOobVqA = new IqmAtnKCbdidswcxQNdWcpcJTEVXB[8];
		IohFLLledoEQLaLLmvvzurwJHWrB = new List<SteamControllerActionOrigin>(8);
		hghsUAqmYqcMDBcMkRakDFwoQGpf = new ReadOnlyCollection<SteamControllerActionOrigin>(IohFLLledoEQLaLLmvvzurwJHWrB);
	}

	public string GetActionSetName(ulong handle)
	{
		return drDqkhvpuNWDlBTeejkcwkWmcXXB(jkCDaAcJjlMYjoeACwQGNtqFRMOp, handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return drDqkhvpuNWDlBTeejkcwkWmcXXB(BCwCVMUekLBlgRXNzKTOcpEzHSyQ, handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return drDqkhvpuNWDlBTeejkcwkWmcXXB(yeqeFJTKzUrSKqhAPpFvCXlZRxbC, handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return ZXozktcbMhqjpdxrfBbJTKzgmppP(lwGPEWoxKKGINEXhPlQUrIlrMjAW, ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return ZXozktcbMhqjpdxrfBbJTKzgmppP(JCJPZhQogakQBKPTFbsVPkVzyWol, ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return ZXozktcbMhqjpdxrfBbJTKzgmppP(sXkOHONKuRzaxLFjjwBdfHjOFUxGA, ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return default(Vector2);
		}
		try
		{
			VekEuZOXXYwfZefVJWOZSEufjKWs vekEuZOXXYwfZefVJWOZSEufjKWs = VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.PGOmBtQNSYfHZCwtORRjlWOyuZcpA(uNlFkVYKZoatWcCgpCOZkOxrJyJj, actionHandle);
			if (!vekEuZOXXYwfZefVJWOZSEufjKWs.AgLFgxDXotCHwfnxXBTNWTStvCjwA)
			{
				return default(Vector2);
			}
			return new Vector2(vekEuZOXXYwfZefVJWOZSEufjKWs.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb, vekEuZOXXYwfZefVJWOZSEufjKWs.hKNBoqqlWhZEGDOSGavmrJzzANJX);
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
			iyFogUECLjdbnFZStROFYTKNfsNo iyFogUECLjdbnFZStROFYTKNfsNo2 = VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.pSxcAsFVsvQxWFXNBUFDgMGqxrkNA(uNlFkVYKZoatWcCgpCOZkOxrJyJj, actionHandle);
			Debug.Log(actionHandle + " state = " + iyFogUECLjdbnFZStROFYTKNfsNo2.cLkPohFwfXOubFZSoTvvbBUMATcH + " active = " + iyFogUECLjdbnFZStROFYTKNfsNo2.AgLFgxDXotCHwfnxXBTNWTStvCjwA);
			return iyFogUECLjdbnFZStROFYTKNfsNo2.AgLFgxDXotCHwfnxXBTNWTStvCjwA && iyFogUECLjdbnFZStROFYTKNfsNo2.cLkPohFwfXOubFZSoTvvbBUMATcH;
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
			VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.svxuhAaAykgZggXjtdZKVHCNFpTfb(uNlFkVYKZoatWcCgpCOZkOxrJyJj, actionSetHandle);
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
		return VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.RGbhjNbcypnTuFFwkOJbpkrqAKvEA(uNlFkVYKZoatWcCgpCOZkOxrJyJj);
	}

	public string GetActiveActionSetName()
	{
		return drDqkhvpuNWDlBTeejkcwkWmcXXB(jkCDaAcJjlMYjoeACwQGNtqFRMOp, VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.RGbhjNbcypnTuFFwkOJbpkrqAKvEA(uNlFkVYKZoatWcCgpCOZkOxrJyJj));
	}

	public void ShowBindingPanel()
	{
		VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.JMDgIBDOjEQtfvZmlilRrvrqJrUtA(uNlFkVYKZoatWcCgpCOZkOxrJyJj);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.EWNdgxXgpRjLwBCETLZPErLGjLwQA(uNlFkVYKZoatWcCgpCOZkOxrJyJj, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.EWNdgxXgpRjLwBCETLZPErLGjLwQA(uNlFkVYKZoatWcCgpCOZkOxrJyJj, (uint)triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(ZXozktcbMhqjpdxrfBbJTKzgmppP(lwGPEWoxKKGINEXhPlQUrIlrMjAW, ref actionSetName), ZXozktcbMhqjpdxrfBbJTKzgmppP(JCJPZhQogakQBKPTFbsVPkVzyWol, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		IohFLLledoEQLaLLmvvzurwJHWrB.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return hghsUAqmYqcMDBcMkRakDFwoQGpf;
		}
		int num = VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.mZSbbIADHyCkWFcvHWGfMAjxXfAq(uNlFkVYKZoatWcCgpCOZkOxrJyJj, actionSetHandle, actionHandle, RRYCkgrApaGRwhqqruezWmiOobVqA);
		for (int i = 0; i < num; i++)
		{
			IohFLLledoEQLaLLmvvzurwJHWrB.Add((SteamControllerActionOrigin)RRYCkgrApaGRwhqqruezWmiOobVqA[i]);
		}
		return hghsUAqmYqcMDBcMkRakDFwoQGpf;
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(ZXozktcbMhqjpdxrfBbJTKzgmppP(lwGPEWoxKKGINEXhPlQUrIlrMjAW, ref actionSetName), ZXozktcbMhqjpdxrfBbJTKzgmppP(sXkOHONKuRzaxLFjjwBdfHjOFUxGA, ref actionName));
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		IohFLLledoEQLaLLmvvzurwJHWrB.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return hghsUAqmYqcMDBcMkRakDFwoQGpf;
		}
		int num = VGeCGxkGsAvcDpaEHgxGyULfSbjr.loASIGQzVFOAhbaXjcymJxKFJHIB.kbeIVeFMdgqxgWyzDzvBUxElhjRnA(uNlFkVYKZoatWcCgpCOZkOxrJyJj, actionSetHandle, actionHandle, RRYCkgrApaGRwhqqruezWmiOobVqA);
		for (int i = 0; i < num; i++)
		{
			IohFLLledoEQLaLLmvvzurwJHWrB.Add((SteamControllerActionOrigin)RRYCkgrApaGRwhqqruezWmiOobVqA[i]);
		}
		return hghsUAqmYqcMDBcMkRakDFwoQGpf;
	}

	private ulong ZXozktcbMhqjpdxrfBbJTKzgmppP(Dictionary<string, ulong> P_0, ref string P_1)
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

	private string drDqkhvpuNWDlBTeejkcwkWmcXXB(Dictionary<ulong, string> P_0, ulong P_1)
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
