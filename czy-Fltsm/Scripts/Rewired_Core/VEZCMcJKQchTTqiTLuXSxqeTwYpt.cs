using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class VEZCMcJKQchTTqiTLuXSxqeTwYpt
{
	[Flags]
	public enum jVydMLcevmhOzJLxuMwzCDjGBfkXA
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class JMMlzDXgXfzoARWWXFGIrfDSodty
	{
		public bool ZBBgMZiphiLQRiHFjknVAgqGQhMTB;

		public bool uDTDwpwlYCzNyyowqEVhLjrPAuiCA;

		public bool EXUNNfwSSOdVNuQChDagVkUYnZhc;
	}

	private Dictionary<int, JMMlzDXgXfzoARWWXFGIrfDSodty> BaEfZayjrMQTELTzsBlMNpTKAjJl;

	public jVydMLcevmhOzJLxuMwzCDjGBfkXA FoOxPnnqCbqsqpxcJiJtIXZwfUSe;

	private bool KsBlSKeiZhNypEFpCSRSeVWlDmJH => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public VEZCMcJKQchTTqiTLuXSxqeTwYpt()
		: this(jVydMLcevmhOzJLxuMwzCDjGBfkXA.Self | jVydMLcevmhOzJLxuMwzCDjGBfkXA.Children)
	{
	}

	public VEZCMcJKQchTTqiTLuXSxqeTwYpt(jVydMLcevmhOzJLxuMwzCDjGBfkXA P_0)
	{
		FoOxPnnqCbqsqpxcJiJtIXZwfUSe = P_0;
		BaEfZayjrMQTELTzsBlMNpTKAjJl = new Dictionary<int, JMMlzDXgXfzoARWWXFGIrfDSodty>();
	}

	public void uJXjGGBcSMxjsMURAFenrCltnOrV(Transform P_0, bool P_1)
	{
		if (!KsBlSKeiZhNypEFpCSRSeVWlDmJH)
		{
			return;
		}
		if ((FoOxPnnqCbqsqpxcJiJtIXZwfUSe & jVydMLcevmhOzJLxuMwzCDjGBfkXA.Self) != jVydMLcevmhOzJLxuMwzCDjGBfkXA.None)
		{
			if ((FoOxPnnqCbqsqpxcJiJtIXZwfUSe & jVydMLcevmhOzJLxuMwzCDjGBfkXA.Children) != jVydMLcevmhOzJLxuMwzCDjGBfkXA.None)
			{
				QrMbKhemmLDmVkpayLVIGIylcllrA(P_0, P_1, BaEfZayjrMQTELTzsBlMNpTKAjJl);
			}
			else
			{
				cCwFGfhHqwPZszZyncvGDUmsQfhi(P_0, P_1, BaEfZayjrMQTELTzsBlMNpTKAjJl);
			}
		}
		else if ((FoOxPnnqCbqsqpxcJiJtIXZwfUSe & jVydMLcevmhOzJLxuMwzCDjGBfkXA.Children) != jVydMLcevmhOzJLxuMwzCDjGBfkXA.None)
		{
			qiJzCXQwQwtGzFydEoWWhsPgPDcs(P_0, P_1, BaEfZayjrMQTELTzsBlMNpTKAjJl);
		}
	}

	public void PlLOLvKAzmLUFcmoxeiBdhbprIjBA()
	{
		if (KsBlSKeiZhNypEFpCSRSeVWlDmJH)
		{
			BaEfZayjrMQTELTzsBlMNpTKAjJl.Clear();
		}
	}

	private static void QrMbKhemmLDmVkpayLVIGIylcllrA(Transform P_0, bool P_1, Dictionary<int, JMMlzDXgXfzoARWWXFGIrfDSodty> P_2)
	{
		if (!(P_0 == null))
		{
			cCwFGfhHqwPZszZyncvGDUmsQfhi(P_0, P_1, P_2);
			qiJzCXQwQwtGzFydEoWWhsPgPDcs(P_0, P_1, P_2);
		}
	}

	private static void qiJzCXQwQwtGzFydEoWWhsPgPDcs(Transform P_0, bool P_1, Dictionary<int, JMMlzDXgXfzoARWWXFGIrfDSodty> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				QrMbKhemmLDmVkpayLVIGIylcllrA(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void cCwFGfhHqwPZszZyncvGDUmsQfhi(Transform P_0, bool P_1, Dictionary<int, JMMlzDXgXfzoARWWXFGIrfDSodty> P_2)
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
			value = new JMMlzDXgXfzoARWWXFGIrfDSodty();
			value.ZBBgMZiphiLQRiHFjknVAgqGQhMTB = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.uDTDwpwlYCzNyyowqEVhLjrPAuiCA && flag == value.ZBBgMZiphiLQRiHFjknVAgqGQhMTB) || (!value.uDTDwpwlYCzNyyowqEVhLjrPAuiCA && flag != value.ZBBgMZiphiLQRiHFjknVAgqGQhMTB))
		{
			value.uDTDwpwlYCzNyyowqEVhLjrPAuiCA = false;
			value.EXUNNfwSSOdVNuQChDagVkUYnZhc = false;
			value.ZBBgMZiphiLQRiHFjknVAgqGQhMTB = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.ZBBgMZiphiLQRiHFjknVAgqGQhMTB)
		{
			if (value.ZBBgMZiphiLQRiHFjknVAgqGQhMTB == P_1)
			{
				value.uDTDwpwlYCzNyyowqEVhLjrPAuiCA = false;
				value.EXUNNfwSSOdVNuQChDagVkUYnZhc = false;
			}
			else
			{
				value.uDTDwpwlYCzNyyowqEVhLjrPAuiCA = true;
				value.EXUNNfwSSOdVNuQChDagVkUYnZhc = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
