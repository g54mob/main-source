using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class VRvPQHmdsvpeRqEMyCcOXcbSDWZ
{
	[Flags]
	public enum XptGvbXPdiBqxZxYlCwVChUjjeu
	{
		DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
		fWukRdAdyKHOYqfRsegHsTUFHRj = 1,
		FawtDJycoEGHCgffFtoIeJAIHMJ = 2
	}

	private class pplICzuumWPOSfFFIOoUnfoSCUy
	{
		public bool snLSRKDXliQFKZBomfeQbvBRaPs;

		public bool rkAjkyfvoRxILmntHviwzcLqjma;

		public bool rLEAJNAyJYurJniyopxHAqtqLVvB;
	}

	private Dictionary<int, pplICzuumWPOSfFFIOoUnfoSCUy> cUSbpUmrLLGpqxWuVVAcKjBQLrX;

	public XptGvbXPdiBqxZxYlCwVChUjjeu ZAUBMcFMmeEjjaQOfbfZYIrnGYeS;

	private bool isValid => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public VRvPQHmdsvpeRqEMyCcOXcbSDWZ()
		: this(XptGvbXPdiBqxZxYlCwVChUjjeu.fWukRdAdyKHOYqfRsegHsTUFHRj | XptGvbXPdiBqxZxYlCwVChUjjeu.FawtDJycoEGHCgffFtoIeJAIHMJ)
	{
	}

	public VRvPQHmdsvpeRqEMyCcOXcbSDWZ(XptGvbXPdiBqxZxYlCwVChUjjeu targets)
	{
		ZAUBMcFMmeEjjaQOfbfZYIrnGYeS = targets;
		cUSbpUmrLLGpqxWuVVAcKjBQLrX = new Dictionary<int, pplICzuumWPOSfFFIOoUnfoSCUy>();
	}

	public void ZPsagkBaAfFubBAoNrUfTaaNrdjj(Transform P_0, bool P_1)
	{
		if (!isValid)
		{
			return;
		}
		if ((ZAUBMcFMmeEjjaQOfbfZYIrnGYeS & XptGvbXPdiBqxZxYlCwVChUjjeu.fWukRdAdyKHOYqfRsegHsTUFHRj) != XptGvbXPdiBqxZxYlCwVChUjjeu.DVDMTdEnkAaktJFJqNakDhECjSAS)
		{
			if ((ZAUBMcFMmeEjjaQOfbfZYIrnGYeS & XptGvbXPdiBqxZxYlCwVChUjjeu.FawtDJycoEGHCgffFtoIeJAIHMJ) != XptGvbXPdiBqxZxYlCwVChUjjeu.DVDMTdEnkAaktJFJqNakDhECjSAS)
			{
				fSSgAaOvHYAOQfheLmlvDbSidsYJ(P_0, P_1, cUSbpUmrLLGpqxWuVVAcKjBQLrX);
			}
			else
			{
				ZPsagkBaAfFubBAoNrUfTaaNrdjj(P_0, P_1, cUSbpUmrLLGpqxWuVVAcKjBQLrX);
			}
		}
		else if ((ZAUBMcFMmeEjjaQOfbfZYIrnGYeS & XptGvbXPdiBqxZxYlCwVChUjjeu.FawtDJycoEGHCgffFtoIeJAIHMJ) != XptGvbXPdiBqxZxYlCwVChUjjeu.DVDMTdEnkAaktJFJqNakDhECjSAS)
		{
			jqebqAfVNxMxGVOApFHhVWEpPpmL(P_0, P_1, cUSbpUmrLLGpqxWuVVAcKjBQLrX);
		}
	}

	public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
	{
		if (isValid)
		{
			cUSbpUmrLLGpqxWuVVAcKjBQLrX.Clear();
		}
	}

	private static void fSSgAaOvHYAOQfheLmlvDbSidsYJ(Transform P_0, bool P_1, Dictionary<int, pplICzuumWPOSfFFIOoUnfoSCUy> P_2)
	{
		if (!(P_0 == null))
		{
			ZPsagkBaAfFubBAoNrUfTaaNrdjj(P_0, P_1, P_2);
			jqebqAfVNxMxGVOApFHhVWEpPpmL(P_0, P_1, P_2);
		}
	}

	private static void jqebqAfVNxMxGVOApFHhVWEpPpmL(Transform P_0, bool P_1, Dictionary<int, pplICzuumWPOSfFFIOoUnfoSCUy> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				fSSgAaOvHYAOQfheLmlvDbSidsYJ(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void ZPsagkBaAfFubBAoNrUfTaaNrdjj(Transform P_0, bool P_1, Dictionary<int, pplICzuumWPOSfFFIOoUnfoSCUy> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		Graphic component = P_0.GetComponent<Graphic>();
		if (component == null)
		{
			return;
		}
		bool flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
		int instanceID = component.GetInstanceID();
		if (!P_2.TryGetValue(instanceID, out var value))
		{
			if (!flag)
			{
				return;
			}
			value = new pplICzuumWPOSfFFIOoUnfoSCUy();
			value.snLSRKDXliQFKZBomfeQbvBRaPs = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.rkAjkyfvoRxILmntHviwzcLqjma && flag == value.snLSRKDXliQFKZBomfeQbvBRaPs) || (!value.rkAjkyfvoRxILmntHviwzcLqjma && flag != value.snLSRKDXliQFKZBomfeQbvBRaPs))
		{
			value.rkAjkyfvoRxILmntHviwzcLqjma = false;
			value.rLEAJNAyJYurJniyopxHAqtqLVvB = false;
			value.snLSRKDXliQFKZBomfeQbvBRaPs = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.snLSRKDXliQFKZBomfeQbvBRaPs)
		{
			if (value.snLSRKDXliQFKZBomfeQbvBRaPs == P_1)
			{
				value.rkAjkyfvoRxILmntHviwzcLqjma = false;
				value.rLEAJNAyJYurJniyopxHAqtqLVvB = false;
			}
			else
			{
				value.rkAjkyfvoRxILmntHviwzcLqjma = true;
				value.rLEAJNAyJYurJniyopxHAqtqLVvB = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
