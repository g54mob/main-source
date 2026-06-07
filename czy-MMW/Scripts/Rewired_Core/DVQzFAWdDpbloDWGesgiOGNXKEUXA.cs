using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class DVQzFAWdDpbloDWGesgiOGNXKEUXA
{
	[Flags]
	public enum bqhDBtnGkhFgCdPyHYPLgZASnzPS
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class XPmqzaCQacWjklFkylyPUedChMLB
	{
		public bool ZmCDaxyeelgyqvaISbMvDFJUshvDA;

		public bool alWbCVrSXRbxNEwfVsUVaoOHulTk;

		public bool OZDrGtjKHTSNcWPZYpeCcXLOvswL;
	}

	private Dictionary<int, XPmqzaCQacWjklFkylyPUedChMLB> BDJjwAnqiDdexfcyXDsyiioClWgNA;

	public bqhDBtnGkhFgCdPyHYPLgZASnzPS RQXqqbmVxklQZZLmeXFLnZciuzfP;

	private bool YfGkeehJGmKnKcpmhfnwBLpvfBeYA => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public DVQzFAWdDpbloDWGesgiOGNXKEUXA()
		: this(bqhDBtnGkhFgCdPyHYPLgZASnzPS.Self | bqhDBtnGkhFgCdPyHYPLgZASnzPS.Children)
	{
	}

	public DVQzFAWdDpbloDWGesgiOGNXKEUXA(bqhDBtnGkhFgCdPyHYPLgZASnzPS P_0)
	{
		RQXqqbmVxklQZZLmeXFLnZciuzfP = P_0;
		BDJjwAnqiDdexfcyXDsyiioClWgNA = new Dictionary<int, XPmqzaCQacWjklFkylyPUedChMLB>();
	}

	public void ewYNmyWCNHNCHmZClXtNQtKxUcEK(Transform P_0, bool P_1)
	{
		if (!YfGkeehJGmKnKcpmhfnwBLpvfBeYA)
		{
			return;
		}
		if ((RQXqqbmVxklQZZLmeXFLnZciuzfP & bqhDBtnGkhFgCdPyHYPLgZASnzPS.Self) != bqhDBtnGkhFgCdPyHYPLgZASnzPS.None)
		{
			if ((RQXqqbmVxklQZZLmeXFLnZciuzfP & bqhDBtnGkhFgCdPyHYPLgZASnzPS.Children) != bqhDBtnGkhFgCdPyHYPLgZASnzPS.None)
			{
				IUVUTTnylGMXmPDnFqtgfZRdfOKf(P_0, P_1, BDJjwAnqiDdexfcyXDsyiioClWgNA);
			}
			else
			{
				aGxzPZahffzjPZKhQKLwyONeGQKdA(P_0, P_1, BDJjwAnqiDdexfcyXDsyiioClWgNA);
			}
		}
		else if ((RQXqqbmVxklQZZLmeXFLnZciuzfP & bqhDBtnGkhFgCdPyHYPLgZASnzPS.Children) != bqhDBtnGkhFgCdPyHYPLgZASnzPS.None)
		{
			eUGdHdDTFvCmQjewzAjmOUochPTkA(P_0, P_1, BDJjwAnqiDdexfcyXDsyiioClWgNA);
		}
	}

	public void BYQOPWTaxsiwkGnKZTnrGCxUQYTA()
	{
		if (YfGkeehJGmKnKcpmhfnwBLpvfBeYA)
		{
			BDJjwAnqiDdexfcyXDsyiioClWgNA.Clear();
		}
	}

	private static void IUVUTTnylGMXmPDnFqtgfZRdfOKf(Transform P_0, bool P_1, Dictionary<int, XPmqzaCQacWjklFkylyPUedChMLB> P_2)
	{
		if (!(P_0 == null))
		{
			aGxzPZahffzjPZKhQKLwyONeGQKdA(P_0, P_1, P_2);
			eUGdHdDTFvCmQjewzAjmOUochPTkA(P_0, P_1, P_2);
		}
	}

	private static void eUGdHdDTFvCmQjewzAjmOUochPTkA(Transform P_0, bool P_1, Dictionary<int, XPmqzaCQacWjklFkylyPUedChMLB> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				IUVUTTnylGMXmPDnFqtgfZRdfOKf(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void aGxzPZahffzjPZKhQKLwyONeGQKdA(Transform P_0, bool P_1, Dictionary<int, XPmqzaCQacWjklFkylyPUedChMLB> P_2)
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
			value = new XPmqzaCQacWjklFkylyPUedChMLB();
			value.ZmCDaxyeelgyqvaISbMvDFJUshvDA = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.alWbCVrSXRbxNEwfVsUVaoOHulTk && flag == value.ZmCDaxyeelgyqvaISbMvDFJUshvDA) || (!value.alWbCVrSXRbxNEwfVsUVaoOHulTk && flag != value.ZmCDaxyeelgyqvaISbMvDFJUshvDA))
		{
			value.alWbCVrSXRbxNEwfVsUVaoOHulTk = false;
			value.OZDrGtjKHTSNcWPZYpeCcXLOvswL = false;
			value.ZmCDaxyeelgyqvaISbMvDFJUshvDA = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.ZmCDaxyeelgyqvaISbMvDFJUshvDA)
		{
			if (value.ZmCDaxyeelgyqvaISbMvDFJUshvDA == P_1)
			{
				value.alWbCVrSXRbxNEwfVsUVaoOHulTk = false;
				value.OZDrGtjKHTSNcWPZYpeCcXLOvswL = false;
			}
			else
			{
				value.alWbCVrSXRbxNEwfVsUVaoOHulTk = true;
				value.OZDrGtjKHTSNcWPZYpeCcXLOvswL = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
