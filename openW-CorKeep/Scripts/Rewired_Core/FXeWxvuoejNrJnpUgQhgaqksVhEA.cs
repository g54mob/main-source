using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class FXeWxvuoejNrJnpUgQhgaqksVhEA
{
	[Flags]
	public enum dQkDUAGOZkUuXebBtDzAYLfxHmmN
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class FlAzfGjgzdxsiiVuQELboKBleepW
	{
		public bool DWHDOQPgDmnMzattiNyatGsnCuQw;

		public bool ayTIgwAnyOOVUJxUxFASWdhyatebA;

		public bool UdCTsWCGaMAnnLEymyUHKaizEyVAA;
	}

	private Dictionary<int, FlAzfGjgzdxsiiVuQELboKBleepW> HdKzRvWtPCGImwZXrQGlQrXxPuRH;

	public dQkDUAGOZkUuXebBtDzAYLfxHmmN XmWrLKTCKxFyQYFHSmpAVlDZAkEx;

	private bool IwJlXHUHrtJUTzBRXTltnEEIGSBt => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public FXeWxvuoejNrJnpUgQhgaqksVhEA()
		: this(dQkDUAGOZkUuXebBtDzAYLfxHmmN.Self | dQkDUAGOZkUuXebBtDzAYLfxHmmN.Children)
	{
	}

	public FXeWxvuoejNrJnpUgQhgaqksVhEA(dQkDUAGOZkUuXebBtDzAYLfxHmmN P_0)
	{
		XmWrLKTCKxFyQYFHSmpAVlDZAkEx = P_0;
		HdKzRvWtPCGImwZXrQGlQrXxPuRH = new Dictionary<int, FlAzfGjgzdxsiiVuQELboKBleepW>();
	}

	public void yoHcYTHfsAHxQAbnJqlQwudSzNtU(Transform P_0, bool P_1)
	{
		if (!IwJlXHUHrtJUTzBRXTltnEEIGSBt)
		{
			return;
		}
		if ((XmWrLKTCKxFyQYFHSmpAVlDZAkEx & dQkDUAGOZkUuXebBtDzAYLfxHmmN.Self) != dQkDUAGOZkUuXebBtDzAYLfxHmmN.None)
		{
			if ((XmWrLKTCKxFyQYFHSmpAVlDZAkEx & dQkDUAGOZkUuXebBtDzAYLfxHmmN.Children) != dQkDUAGOZkUuXebBtDzAYLfxHmmN.None)
			{
				YLOGyoUYmRexnAYslGbODkmKcpZB(P_0, P_1, HdKzRvWtPCGImwZXrQGlQrXxPuRH);
			}
			else
			{
				eCuSmyZEHqBMPSEFglpzGyGTPvqc(P_0, P_1, HdKzRvWtPCGImwZXrQGlQrXxPuRH);
			}
		}
		else if ((XmWrLKTCKxFyQYFHSmpAVlDZAkEx & dQkDUAGOZkUuXebBtDzAYLfxHmmN.Children) != dQkDUAGOZkUuXebBtDzAYLfxHmmN.None)
		{
			glLLEQuImwHWBhoPPhNfemFcVQmzB(P_0, P_1, HdKzRvWtPCGImwZXrQGlQrXxPuRH);
		}
	}

	public void BqVxZaiQDoOWbRDQwEhcmklEDJnq()
	{
		if (IwJlXHUHrtJUTzBRXTltnEEIGSBt)
		{
			HdKzRvWtPCGImwZXrQGlQrXxPuRH.Clear();
		}
	}

	private static void YLOGyoUYmRexnAYslGbODkmKcpZB(Transform P_0, bool P_1, Dictionary<int, FlAzfGjgzdxsiiVuQELboKBleepW> P_2)
	{
		if (!(P_0 == null))
		{
			eCuSmyZEHqBMPSEFglpzGyGTPvqc(P_0, P_1, P_2);
			glLLEQuImwHWBhoPPhNfemFcVQmzB(P_0, P_1, P_2);
		}
	}

	private static void glLLEQuImwHWBhoPPhNfemFcVQmzB(Transform P_0, bool P_1, Dictionary<int, FlAzfGjgzdxsiiVuQELboKBleepW> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				YLOGyoUYmRexnAYslGbODkmKcpZB(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void eCuSmyZEHqBMPSEFglpzGyGTPvqc(Transform P_0, bool P_1, Dictionary<int, FlAzfGjgzdxsiiVuQELboKBleepW> P_2)
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
			value = new FlAzfGjgzdxsiiVuQELboKBleepW();
			value.DWHDOQPgDmnMzattiNyatGsnCuQw = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.ayTIgwAnyOOVUJxUxFASWdhyatebA && flag == value.DWHDOQPgDmnMzattiNyatGsnCuQw) || (!value.ayTIgwAnyOOVUJxUxFASWdhyatebA && flag != value.DWHDOQPgDmnMzattiNyatGsnCuQw))
		{
			value.ayTIgwAnyOOVUJxUxFASWdhyatebA = false;
			value.UdCTsWCGaMAnnLEymyUHKaizEyVAA = false;
			value.DWHDOQPgDmnMzattiNyatGsnCuQw = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.DWHDOQPgDmnMzattiNyatGsnCuQw)
		{
			if (value.DWHDOQPgDmnMzattiNyatGsnCuQw == P_1)
			{
				value.ayTIgwAnyOOVUJxUxFASWdhyatebA = false;
				value.UdCTsWCGaMAnnLEymyUHKaizEyVAA = false;
			}
			else
			{
				value.ayTIgwAnyOOVUJxUxFASWdhyatebA = true;
				value.UdCTsWCGaMAnnLEymyUHKaizEyVAA = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
