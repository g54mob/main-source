using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class HzVIQCREYHZKnIVBMAJjqUnIsmmT
{
	[Flags]
	public enum nJsUcxybJJDrPbfvfkBSWmtNFGhE
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class PeIjPhXmNAdzyrrQWOepymUPZLwf
	{
		public bool NPFYDnfrKDXajtbDsdyopRdTTfTi;

		public bool wDczTwrSfUVCSnqpRCACweIIkdg;

		public bool EWWFFlaUIfFizYTEocNHHEvRqHUmA;
	}

	private Dictionary<int, PeIjPhXmNAdzyrrQWOepymUPZLwf> FkCzrOmwfzcZwhiphcZfUgQFEwCU;

	public nJsUcxybJJDrPbfvfkBSWmtNFGhE DNCGdbhjoIkxWBZtCFkONHWbiPREb;

	private bool YBFyxeoZLIkCLcIvFnEzpcJcHhYHA => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public HzVIQCREYHZKnIVBMAJjqUnIsmmT()
		: this(nJsUcxybJJDrPbfvfkBSWmtNFGhE.Self | nJsUcxybJJDrPbfvfkBSWmtNFGhE.Children)
	{
	}

	public HzVIQCREYHZKnIVBMAJjqUnIsmmT(nJsUcxybJJDrPbfvfkBSWmtNFGhE P_0)
	{
		DNCGdbhjoIkxWBZtCFkONHWbiPREb = P_0;
		FkCzrOmwfzcZwhiphcZfUgQFEwCU = new Dictionary<int, PeIjPhXmNAdzyrrQWOepymUPZLwf>();
	}

	public void mCVECeXIEnTqWyaJNBwKcguewsyPA(Transform P_0, bool P_1)
	{
		if (!YBFyxeoZLIkCLcIvFnEzpcJcHhYHA)
		{
			return;
		}
		if ((DNCGdbhjoIkxWBZtCFkONHWbiPREb & nJsUcxybJJDrPbfvfkBSWmtNFGhE.Self) != nJsUcxybJJDrPbfvfkBSWmtNFGhE.None)
		{
			if ((DNCGdbhjoIkxWBZtCFkONHWbiPREb & nJsUcxybJJDrPbfvfkBSWmtNFGhE.Children) != nJsUcxybJJDrPbfvfkBSWmtNFGhE.None)
			{
				SXUiYXanggnuzRBwliJpJmxygFuGA(P_0, P_1, FkCzrOmwfzcZwhiphcZfUgQFEwCU);
			}
			else
			{
				akgIWBzjcXmOOLRemlijUnzzyXsl(P_0, P_1, FkCzrOmwfzcZwhiphcZfUgQFEwCU);
			}
		}
		else if ((DNCGdbhjoIkxWBZtCFkONHWbiPREb & nJsUcxybJJDrPbfvfkBSWmtNFGhE.Children) != nJsUcxybJJDrPbfvfkBSWmtNFGhE.None)
		{
			eyHKKzOEKXFDXlmlBQMnuVYhnRlg(P_0, P_1, FkCzrOmwfzcZwhiphcZfUgQFEwCU);
		}
	}

	public void BPLLZVQfnDZCnQzmgiGmwLcmmkgm()
	{
		if (YBFyxeoZLIkCLcIvFnEzpcJcHhYHA)
		{
			FkCzrOmwfzcZwhiphcZfUgQFEwCU.Clear();
		}
	}

	private static void SXUiYXanggnuzRBwliJpJmxygFuGA(Transform P_0, bool P_1, Dictionary<int, PeIjPhXmNAdzyrrQWOepymUPZLwf> P_2)
	{
		if (!(P_0 == null))
		{
			akgIWBzjcXmOOLRemlijUnzzyXsl(P_0, P_1, P_2);
			eyHKKzOEKXFDXlmlBQMnuVYhnRlg(P_0, P_1, P_2);
		}
	}

	private static void eyHKKzOEKXFDXlmlBQMnuVYhnRlg(Transform P_0, bool P_1, Dictionary<int, PeIjPhXmNAdzyrrQWOepymUPZLwf> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				SXUiYXanggnuzRBwliJpJmxygFuGA(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void akgIWBzjcXmOOLRemlijUnzzyXsl(Transform P_0, bool P_1, Dictionary<int, PeIjPhXmNAdzyrrQWOepymUPZLwf> P_2)
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
			value = new PeIjPhXmNAdzyrrQWOepymUPZLwf();
			value.NPFYDnfrKDXajtbDsdyopRdTTfTi = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.wDczTwrSfUVCSnqpRCACweIIkdg && flag == value.NPFYDnfrKDXajtbDsdyopRdTTfTi) || (!value.wDczTwrSfUVCSnqpRCACweIIkdg && flag != value.NPFYDnfrKDXajtbDsdyopRdTTfTi))
		{
			value.wDczTwrSfUVCSnqpRCACweIIkdg = false;
			value.EWWFFlaUIfFizYTEocNHHEvRqHUmA = false;
			value.NPFYDnfrKDXajtbDsdyopRdTTfTi = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.NPFYDnfrKDXajtbDsdyopRdTTfTi)
		{
			if (value.NPFYDnfrKDXajtbDsdyopRdTTfTi == P_1)
			{
				value.wDczTwrSfUVCSnqpRCACweIIkdg = false;
				value.EWWFFlaUIfFizYTEocNHHEvRqHUmA = false;
			}
			else
			{
				value.wDczTwrSfUVCSnqpRCACweIIkdg = true;
				value.EWWFFlaUIfFizYTEocNHHEvRqHUmA = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
