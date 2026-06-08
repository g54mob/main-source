using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class NIcCUdyQMDYZUZhyXqxbpJwMTqP
{
	[Flags]
	public enum jmrgVwXLdZzwoMYgOkTfZSWgzpN
	{
		XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
		nLhhNGOsMuvwkXvLHVdIUuZPaze = 1,
		LXbacgoIFwYgcXrPmfGXeURECcQg = 2
	}

	private class cgYmXaKIknfpTOITtNZNkmLdoiS
	{
		public bool ckCJbzHMcQcqcmKdVCJFZZtNZXr;

		public bool lTkuXDpBpsLxRBVaGMtdDZauGbI;

		public bool ppReGcoRoshVbBLQZNQQMMtqTsun;
	}

	private Dictionary<int, cgYmXaKIknfpTOITtNZNkmLdoiS> kDFfelajyjWBAEPAgmfnykNClQA;

	public jmrgVwXLdZzwoMYgOkTfZSWgzpN RLFsDFISPQsNJxtmGHGGyevWShd;

	private bool isValid => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public NIcCUdyQMDYZUZhyXqxbpJwMTqP()
		: this(jmrgVwXLdZzwoMYgOkTfZSWgzpN.nLhhNGOsMuvwkXvLHVdIUuZPaze | jmrgVwXLdZzwoMYgOkTfZSWgzpN.LXbacgoIFwYgcXrPmfGXeURECcQg)
	{
	}

	public NIcCUdyQMDYZUZhyXqxbpJwMTqP(jmrgVwXLdZzwoMYgOkTfZSWgzpN targets)
	{
		RLFsDFISPQsNJxtmGHGGyevWShd = targets;
		kDFfelajyjWBAEPAgmfnykNClQA = new Dictionary<int, cgYmXaKIknfpTOITtNZNkmLdoiS>();
	}

	public void PdlrGNXpCBECJtKEwhNmSCcHIIa(Transform P_0, bool P_1)
	{
		if (!isValid)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if ((RLFsDFISPQsNJxtmGHGGyevWShd & jmrgVwXLdZzwoMYgOkTfZSWgzpN.nLhhNGOsMuvwkXvLHVdIUuZPaze) != jmrgVwXLdZzwoMYgOkTfZSWgzpN.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
			{
				num = -56811513;
				num2 = num;
			}
			else
			{
				num = -56811514;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -56811518)
				{
				case 0:
					num = -56811517;
					continue;
				default:
					return;
				case 4:
					if ((RLFsDFISPQsNJxtmGHGGyevWShd & jmrgVwXLdZzwoMYgOkTfZSWgzpN.LXbacgoIFwYgcXrPmfGXeURECcQg) != jmrgVwXLdZzwoMYgOkTfZSWgzpN.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
					{
						fidfzfDeuVOFohCcOUouqGEpHQh(P_0, P_1, kDFfelajyjWBAEPAgmfnykNClQA);
						num = -56811519;
						continue;
					}
					return;
				case 2:
					PdlrGNXpCBECJtKEwhNmSCcHIIa(P_0, P_1, kDFfelajyjWBAEPAgmfnykNClQA);
					return;
				case 6:
					return;
				case 5:
					if ((RLFsDFISPQsNJxtmGHGGyevWShd & jmrgVwXLdZzwoMYgOkTfZSWgzpN.LXbacgoIFwYgcXrPmfGXeURECcQg) != jmrgVwXLdZzwoMYgOkTfZSWgzpN.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
					{
						luNkPPCfsgDqkhEMiNQurBUdDBHP(P_0, P_1, kDFfelajyjWBAEPAgmfnykNClQA);
						num = -56811516;
						continue;
					}
					goto case 2;
				case 1:
					break;
				case 3:
					return;
				}
				break;
			}
		}
	}

	public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
	{
		if (isValid)
		{
			kDFfelajyjWBAEPAgmfnykNClQA.Clear();
		}
	}

	private static void luNkPPCfsgDqkhEMiNQurBUdDBHP(Transform P_0, bool P_1, Dictionary<int, cgYmXaKIknfpTOITtNZNkmLdoiS> P_2)
	{
		if (!(P_0 == null))
		{
			PdlrGNXpCBECJtKEwhNmSCcHIIa(P_0, P_1, P_2);
			fidfzfDeuVOFohCcOUouqGEpHQh(P_0, P_1, P_2);
		}
	}

	private static void fidfzfDeuVOFohCcOUouqGEpHQh(Transform P_0, bool P_1, Dictionary<int, cgYmXaKIknfpTOITtNZNkmLdoiS> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			int childCount = P_0.childCount;
			int num = 600900844;
			while (true)
			{
				switch (num ^ 0x23D104EE)
				{
				case 4:
					num = 600900845;
					continue;
				default:
					return;
				case 5:
					luNkPPCfsgDqkhEMiNQurBUdDBHP(P_0.GetChild(num2), P_1, P_2);
					num2++;
					num = 600900846;
					continue;
				case 2:
					num2 = 0;
					num = 600900846;
					continue;
				case 0:
				{
					int num3;
					if (num2 >= childCount)
					{
						num = 600900847;
						num3 = num;
					}
					else
					{
						num = 600900843;
						num3 = num;
					}
					continue;
				}
				case 3:
					break;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private static void PdlrGNXpCBECJtKEwhNmSCcHIIa(Transform P_0, bool P_1, Dictionary<int, cgYmXaKIknfpTOITtNZNkmLdoiS> P_2)
	{
		if (P_0 == null)
		{
			goto IL_0009;
		}
		goto IL_0072;
		IL_0009:
		int num = -651437380;
		goto IL_000e;
		IL_000e:
		bool flag = default(bool);
		cgYmXaKIknfpTOITtNZNkmLdoiS value = default(cgYmXaKIknfpTOITtNZNkmLdoiS);
		Graphic component = default(Graphic);
		int instanceID = default(int);
		while (true)
		{
			switch (num ^ -651437386)
			{
			case 5:
				break;
			default:
				return;
			case 10:
				return;
			case 8:
				goto IL_0072;
			case 11:
				return;
			case 2:
				if (P_1 != flag && value.ckCJbzHMcQcqcmKdVCJFZZtNZXr)
				{
					if (value.ckCJbzHMcQcqcmKdVCJFZZtNZXr == P_1)
					{
						value.lTkuXDpBpsLxRBVaGMtdDZauGbI = false;
						value.ppReGcoRoshVbBLQZNQQMMtqTsun = false;
						num = -651437381;
						continue;
					}
					goto case 1;
				}
				return;
			case 13:
				num = -651437402;
				continue;
			case 16:
				UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
				num = -651437384;
				continue;
			case 3:
				if (value.lTkuXDpBpsLxRBVaGMtdDZauGbI)
				{
					goto case 2;
				}
				goto IL_00f3;
			case 9:
				value.lTkuXDpBpsLxRBVaGMtdDZauGbI = false;
				num = -651437391;
				continue;
			case 1:
				value.lTkuXDpBpsLxRBVaGMtdDZauGbI = true;
				value.ppReGcoRoshVbBLQZNQQMMtqTsun = P_1;
				num = -651437402;
				continue;
			case 12:
				goto IL_0139;
			case 18:
				value = new cgYmXaKIknfpTOITtNZNkmLdoiS();
				num = -651437386;
				continue;
			case 17:
				goto IL_0160;
			case 7:
				value.ppReGcoRoshVbBLQZNQQMMtqTsun = false;
				value.ckCJbzHMcQcqcmKdVCJFZZtNZXr = flag;
				if (!flag)
				{
					P_2.Remove(instanceID);
					num = -651437379;
					continue;
				}
				goto case 2;
			case 6:
				return;
			case 15:
				if (!value.lTkuXDpBpsLxRBVaGMtdDZauGbI)
				{
					goto case 3;
				}
				goto IL_01c2;
			case 0:
				value.ckCJbzHMcQcqcmKdVCJFZZtNZXr = flag;
				P_2.Add(instanceID, value);
				num = -651437383;
				continue;
			case 4:
				goto IL_01f8;
			case 14:
				return;
			}
			break;
			IL_01c2:
			int num2;
			if (flag == value.ckCJbzHMcQcqcmKdVCJFZZtNZXr)
			{
				num = -651437377;
				num2 = num;
			}
			else
			{
				num = -651437387;
				num2 = num;
			}
			continue;
			IL_0139:
			int num3;
			if (!flag)
			{
				num = -651437392;
				num3 = num;
			}
			else
			{
				num = -651437404;
				num3 = num;
			}
			continue;
			IL_00f3:
			int num4;
			if (flag != value.ckCJbzHMcQcqcmKdVCJFZZtNZXr)
			{
				num = -651437377;
				num4 = num;
			}
			else
			{
				num = -651437388;
				num4 = num;
			}
			continue;
			IL_0160:
			instanceID = component.GetInstanceID();
			int num5;
			if (P_2.TryGetValue(instanceID, out value))
			{
				num = -651437383;
				num5 = num;
			}
			else
			{
				num = -651437382;
				num5 = num;
			}
		}
		goto IL_0009;
		IL_01f8:
		flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
		num = -651437401;
		goto IL_000e;
		IL_0072:
		component = P_0.GetComponent<Graphic>();
		if (component == null)
		{
			return;
		}
		goto IL_01f8;
	}
}
