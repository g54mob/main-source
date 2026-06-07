using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class StcRXHeXGKmrcfQEptFjeyDpLqUb
{
	[Flags]
	public enum yLUeRqJOeIPrHMpwAzQeUphmAghEA
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class QUexciiKGHePyYVZpgcFeQLqemeHA
	{
		public bool zOXWUFBfNLJfFEJjtYDjAFdycYUi;

		public bool cEIdbxftAwnmQnPxQnEBCtZRnTEK;

		public bool cmMGBUkkbjKuQNfcvbEusZbPFDRnA;
	}

	private Dictionary<int, QUexciiKGHePyYVZpgcFeQLqemeHA> fbCfhDIgteQstCsgUvhJxpXlSrjKA;

	public yLUeRqJOeIPrHMpwAzQeUphmAghEA UGMVIjCfUHNgiPvWofCoffnfZUMr;

	private bool fQVLMDvJBcnHZEGkyNSlcOeNSOBJ => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public StcRXHeXGKmrcfQEptFjeyDpLqUb()
		: this(yLUeRqJOeIPrHMpwAzQeUphmAghEA.Self | yLUeRqJOeIPrHMpwAzQeUphmAghEA.Children)
	{
	}

	public StcRXHeXGKmrcfQEptFjeyDpLqUb(yLUeRqJOeIPrHMpwAzQeUphmAghEA P_0)
	{
		UGMVIjCfUHNgiPvWofCoffnfZUMr = P_0;
		fbCfhDIgteQstCsgUvhJxpXlSrjKA = new Dictionary<int, QUexciiKGHePyYVZpgcFeQLqemeHA>();
	}

	public void WpiqHjRcuWGpcXTsCkpIPZokatTs(Transform P_0, bool P_1)
	{
		if (!fQVLMDvJBcnHZEGkyNSlcOeNSOBJ)
		{
			return;
		}
		if ((UGMVIjCfUHNgiPvWofCoffnfZUMr & yLUeRqJOeIPrHMpwAzQeUphmAghEA.Self) != yLUeRqJOeIPrHMpwAzQeUphmAghEA.None)
		{
			if ((UGMVIjCfUHNgiPvWofCoffnfZUMr & yLUeRqJOeIPrHMpwAzQeUphmAghEA.Children) != yLUeRqJOeIPrHMpwAzQeUphmAghEA.None)
			{
				qQICSfGKjlVRBTkaIcWQVKAKisuxA(P_0, P_1, fbCfhDIgteQstCsgUvhJxpXlSrjKA);
			}
			else
			{
				WpiqHjRcuWGpcXTsCkpIPZokatTs(P_0, P_1, fbCfhDIgteQstCsgUvhJxpXlSrjKA);
			}
		}
		else if ((UGMVIjCfUHNgiPvWofCoffnfZUMr & yLUeRqJOeIPrHMpwAzQeUphmAghEA.Children) != yLUeRqJOeIPrHMpwAzQeUphmAghEA.None)
		{
			gVqckXcHfGdeLbXAwouWAzIgUdGLc(P_0, P_1, fbCfhDIgteQstCsgUvhJxpXlSrjKA);
		}
	}

	public void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		if (fQVLMDvJBcnHZEGkyNSlcOeNSOBJ)
		{
			fbCfhDIgteQstCsgUvhJxpXlSrjKA.Clear();
		}
	}

	private static void qQICSfGKjlVRBTkaIcWQVKAKisuxA(Transform P_0, bool P_1, Dictionary<int, QUexciiKGHePyYVZpgcFeQLqemeHA> P_2)
	{
		if (!(P_0 == null))
		{
			WpiqHjRcuWGpcXTsCkpIPZokatTs(P_0, P_1, P_2);
			gVqckXcHfGdeLbXAwouWAzIgUdGLc(P_0, P_1, P_2);
		}
	}

	private static void gVqckXcHfGdeLbXAwouWAzIgUdGLc(Transform P_0, bool P_1, Dictionary<int, QUexciiKGHePyYVZpgcFeQLqemeHA> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				qQICSfGKjlVRBTkaIcWQVKAKisuxA(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void WpiqHjRcuWGpcXTsCkpIPZokatTs(Transform P_0, bool P_1, Dictionary<int, QUexciiKGHePyYVZpgcFeQLqemeHA> P_2)
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
			value = new QUexciiKGHePyYVZpgcFeQLqemeHA();
			value.zOXWUFBfNLJfFEJjtYDjAFdycYUi = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.cEIdbxftAwnmQnPxQnEBCtZRnTEK && flag == value.zOXWUFBfNLJfFEJjtYDjAFdycYUi) || (!value.cEIdbxftAwnmQnPxQnEBCtZRnTEK && flag != value.zOXWUFBfNLJfFEJjtYDjAFdycYUi))
		{
			value.cEIdbxftAwnmQnPxQnEBCtZRnTEK = false;
			value.cmMGBUkkbjKuQNfcvbEusZbPFDRnA = false;
			value.zOXWUFBfNLJfFEJjtYDjAFdycYUi = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.zOXWUFBfNLJfFEJjtYDjAFdycYUi)
		{
			if (value.zOXWUFBfNLJfFEJjtYDjAFdycYUi == P_1)
			{
				value.cEIdbxftAwnmQnPxQnEBCtZRnTEK = false;
				value.cmMGBUkkbjKuQNfcvbEusZbPFDRnA = false;
			}
			else
			{
				value.cEIdbxftAwnmQnPxQnEBCtZRnTEK = true;
				value.cmMGBUkkbjKuQNfcvbEusZbPFDRnA = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
