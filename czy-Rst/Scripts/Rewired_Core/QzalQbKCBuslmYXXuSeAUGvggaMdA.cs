using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class QzalQbKCBuslmYXXuSeAUGvggaMdA
{
	[Flags]
	public enum ynBSZMtiMykBGzGbRBNzonelHDVJ
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class KVtdvOCLIzOCnviIsPzWCYEhPLUj
	{
		public bool IhmWbUcfkcufapwHKQnJBsxbFehI;

		public bool rgagpkrjVUzrJMEmXumryToyMXRg;

		public bool XExwPWjjLQOLgYDMYBwqHsdrDVcrA;
	}

	private Dictionary<int, KVtdvOCLIzOCnviIsPzWCYEhPLUj> KkjbphGbqGMqjDlnJRoImoORzcaBb;

	public ynBSZMtiMykBGzGbRBNzonelHDVJ KpdxxEoLbjkSHFevwUBtpXAVALfr;

	private bool TLuAtPIxQbudAkextBnAhZPEMtgXA => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public QzalQbKCBuslmYXXuSeAUGvggaMdA()
		: this(ynBSZMtiMykBGzGbRBNzonelHDVJ.Self | ynBSZMtiMykBGzGbRBNzonelHDVJ.Children)
	{
	}

	public QzalQbKCBuslmYXXuSeAUGvggaMdA(ynBSZMtiMykBGzGbRBNzonelHDVJ P_0)
	{
		KpdxxEoLbjkSHFevwUBtpXAVALfr = P_0;
		KkjbphGbqGMqjDlnJRoImoORzcaBb = new Dictionary<int, KVtdvOCLIzOCnviIsPzWCYEhPLUj>();
	}

	public void pYuAdJCpRMTzPwAPnLirIOgKkrIh(Transform P_0, bool P_1)
	{
		if (!TLuAtPIxQbudAkextBnAhZPEMtgXA)
		{
			return;
		}
		if ((KpdxxEoLbjkSHFevwUBtpXAVALfr & ynBSZMtiMykBGzGbRBNzonelHDVJ.Self) != ynBSZMtiMykBGzGbRBNzonelHDVJ.None)
		{
			if ((KpdxxEoLbjkSHFevwUBtpXAVALfr & ynBSZMtiMykBGzGbRBNzonelHDVJ.Children) != ynBSZMtiMykBGzGbRBNzonelHDVJ.None)
			{
				RRdnGkxtrJWAsDpyRUoCpPhARTEo(P_0, P_1, KkjbphGbqGMqjDlnJRoImoORzcaBb);
			}
			else
			{
				lhXlYsqAraJrZZksSHHYwJrDPgUs(P_0, P_1, KkjbphGbqGMqjDlnJRoImoORzcaBb);
			}
		}
		else if ((KpdxxEoLbjkSHFevwUBtpXAVALfr & ynBSZMtiMykBGzGbRBNzonelHDVJ.Children) != ynBSZMtiMykBGzGbRBNzonelHDVJ.None)
		{
			laUCQWJRmnkYrbllNnKFSQRavNtA(P_0, P_1, KkjbphGbqGMqjDlnJRoImoORzcaBb);
		}
	}

	public void ExoJtgNHkcBcwCMkScBFKTeWckCIA()
	{
		if (TLuAtPIxQbudAkextBnAhZPEMtgXA)
		{
			KkjbphGbqGMqjDlnJRoImoORzcaBb.Clear();
		}
	}

	private static void RRdnGkxtrJWAsDpyRUoCpPhARTEo(Transform P_0, bool P_1, Dictionary<int, KVtdvOCLIzOCnviIsPzWCYEhPLUj> P_2)
	{
		if (!(P_0 == null))
		{
			lhXlYsqAraJrZZksSHHYwJrDPgUs(P_0, P_1, P_2);
			laUCQWJRmnkYrbllNnKFSQRavNtA(P_0, P_1, P_2);
		}
	}

	private static void laUCQWJRmnkYrbllNnKFSQRavNtA(Transform P_0, bool P_1, Dictionary<int, KVtdvOCLIzOCnviIsPzWCYEhPLUj> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				RRdnGkxtrJWAsDpyRUoCpPhARTEo(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void lhXlYsqAraJrZZksSHHYwJrDPgUs(Transform P_0, bool P_1, Dictionary<int, KVtdvOCLIzOCnviIsPzWCYEhPLUj> P_2)
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
			value = new KVtdvOCLIzOCnviIsPzWCYEhPLUj();
			value.IhmWbUcfkcufapwHKQnJBsxbFehI = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.rgagpkrjVUzrJMEmXumryToyMXRg && flag == value.IhmWbUcfkcufapwHKQnJBsxbFehI) || (!value.rgagpkrjVUzrJMEmXumryToyMXRg && flag != value.IhmWbUcfkcufapwHKQnJBsxbFehI))
		{
			value.rgagpkrjVUzrJMEmXumryToyMXRg = false;
			value.XExwPWjjLQOLgYDMYBwqHsdrDVcrA = false;
			value.IhmWbUcfkcufapwHKQnJBsxbFehI = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.IhmWbUcfkcufapwHKQnJBsxbFehI)
		{
			if (value.IhmWbUcfkcufapwHKQnJBsxbFehI == P_1)
			{
				value.rgagpkrjVUzrJMEmXumryToyMXRg = false;
				value.XExwPWjjLQOLgYDMYBwqHsdrDVcrA = false;
			}
			else
			{
				value.rgagpkrjVUzrJMEmXumryToyMXRg = true;
				value.XExwPWjjLQOLgYDMYBwqHsdrDVcrA = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
