using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class cHqRtqSnvZYMLmoNYIQaJzSHZpkb
{
	[Flags]
	public enum jiLcjGIbeGJmSpRvrJDCsFTaOdV
	{
		iOlZgcuFwLCPNAjSgaSDuxucio = 0,
		GPvHCRsebwtmlqWcYlcJOPzQqbD = 1,
		cxppFhEkwgwtrskqhRnMGJfRexp = 2
	}

	private class LoDceYDgQEnIrAMDcDjjCspbbFOG
	{
		public bool BjCFuqdMJIabvLfGQddIBFDCrWEx;

		public bool YORsZWHKqfvSwofazZpoPgrtBHAK;

		public bool EqRfVfQiNyAEecHrCklBUeHtTjH;
	}

	private Dictionary<int, LoDceYDgQEnIrAMDcDjjCspbbFOG> VEHPHwQoNlITHpfndYAcsNlVDGf;

	public jiLcjGIbeGJmSpRvrJDCsFTaOdV ymVCeOcpwUSAKUJDDVrBcRDXeyO;

	private bool isValid
	{
		get
		{
			return UnityTools.supportsUnityUIGraphicRaycastTarget;
		}
	}

	public cHqRtqSnvZYMLmoNYIQaJzSHZpkb()
		: this(jiLcjGIbeGJmSpRvrJDCsFTaOdV.GPvHCRsebwtmlqWcYlcJOPzQqbD | jiLcjGIbeGJmSpRvrJDCsFTaOdV.cxppFhEkwgwtrskqhRnMGJfRexp)
	{
	}

	public cHqRtqSnvZYMLmoNYIQaJzSHZpkb(jiLcjGIbeGJmSpRvrJDCsFTaOdV targets)
	{
		ymVCeOcpwUSAKUJDDVrBcRDXeyO = targets;
		VEHPHwQoNlITHpfndYAcsNlVDGf = new Dictionary<int, LoDceYDgQEnIrAMDcDjjCspbbFOG>();
	}

	public void mkbZMChGYDoTKCWjjeEtIdAOcVVA(Transform P_0, bool P_1)
	{
		if (!isValid)
		{
			goto IL_0008;
		}
		goto IL_0079;
		IL_0008:
		int num = -297070929;
		goto IL_000d;
		IL_000d:
		switch (num ^ -297070930)
		{
		case 0:
			break;
		default:
			return;
		case 5:
			return;
		case 6:
			goto IL_003e;
		case 1:
			return;
		case 3:
			goto IL_005b;
		case 4:
			goto IL_0079;
		case 2:
			return;
		}
		goto IL_0008;
		IL_0079:
		if ((ymVCeOcpwUSAKUJDDVrBcRDXeyO & jiLcjGIbeGJmSpRvrJDCsFTaOdV.GPvHCRsebwtmlqWcYlcJOPzQqbD) != jiLcjGIbeGJmSpRvrJDCsFTaOdV.iOlZgcuFwLCPNAjSgaSDuxucio)
		{
			if ((ymVCeOcpwUSAKUJDDVrBcRDXeyO & jiLcjGIbeGJmSpRvrJDCsFTaOdV.cxppFhEkwgwtrskqhRnMGJfRexp) != jiLcjGIbeGJmSpRvrJDCsFTaOdV.iOlZgcuFwLCPNAjSgaSDuxucio)
			{
				AvZkeKeBPgflzpblbGpzkTqqJOyd(P_0, P_1, VEHPHwQoNlITHpfndYAcsNlVDGf);
				num = -297070933;
				goto IL_000d;
			}
			goto IL_003e;
		}
		goto IL_005b;
		IL_005b:
		if ((ymVCeOcpwUSAKUJDDVrBcRDXeyO & jiLcjGIbeGJmSpRvrJDCsFTaOdV.cxppFhEkwgwtrskqhRnMGJfRexp) != jiLcjGIbeGJmSpRvrJDCsFTaOdV.iOlZgcuFwLCPNAjSgaSDuxucio)
		{
			GjlOegvWHPCNnYoPFLFxgzkeNAQ(P_0, P_1, VEHPHwQoNlITHpfndYAcsNlVDGf);
			num = -297070932;
			goto IL_000d;
		}
		return;
		IL_003e:
		mkbZMChGYDoTKCWjjeEtIdAOcVVA(P_0, P_1, VEHPHwQoNlITHpfndYAcsNlVDGf);
	}

	public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
	{
		if (!isValid)
		{
			return;
		}
		while (true)
		{
			VEHPHwQoNlITHpfndYAcsNlVDGf.Clear();
			int num = -673785846;
			while (true)
			{
				switch (num ^ -673785846)
				{
				case 2:
					goto IL_0009;
				default:
					return;
				case 1:
					break;
				case 0:
					return;
				}
				break;
				IL_0009:
				num = -673785845;
			}
		}
	}

	private static void AvZkeKeBPgflzpblbGpzkTqqJOyd(Transform P_0, bool P_1, Dictionary<int, LoDceYDgQEnIrAMDcDjjCspbbFOG> P_2)
	{
		if (!(P_0 == null))
		{
			mkbZMChGYDoTKCWjjeEtIdAOcVVA(P_0, P_1, P_2);
			GjlOegvWHPCNnYoPFLFxgzkeNAQ(P_0, P_1, P_2);
		}
	}

	private static void GjlOegvWHPCNnYoPFLFxgzkeNAQ(Transform P_0, bool P_1, Dictionary<int, LoDceYDgQEnIrAMDcDjjCspbbFOG> P_2)
	{
		if (P_0 == null)
		{
			goto IL_0009;
		}
		goto IL_0068;
		IL_0009:
		int num = 1121106672;
		goto IL_000e;
		IL_000e:
		int num2 = default(int);
		int childCount = default(int);
		while (true)
		{
			switch (num ^ 0x42D2BAF6)
			{
			case 4:
				break;
			case 6:
				return;
			case 3:
				num = 1121106679;
				continue;
			case 0:
				AvZkeKeBPgflzpblbGpzkTqqJOyd(P_0.GetChild(num2), P_1, P_2);
				num2++;
				num = 1121106679;
				continue;
			case 2:
				num2 = 0;
				num = 1121106677;
				continue;
			case 5:
				goto IL_0068;
			default:
				if (num2 >= childCount)
				{
					return;
				}
				goto case 0;
			}
			break;
		}
		goto IL_0009;
		IL_0068:
		childCount = P_0.childCount;
		num = 1121106676;
		goto IL_000e;
	}

	private static void mkbZMChGYDoTKCWjjeEtIdAOcVVA(Transform P_0, bool P_1, Dictionary<int, LoDceYDgQEnIrAMDcDjjCspbbFOG> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int instanceID = default(int);
		LoDceYDgQEnIrAMDcDjjCspbbFOG value = default(LoDceYDgQEnIrAMDcDjjCspbbFOG);
		while (true)
		{
			Graphic component = P_0.GetComponent<Graphic>();
			if (component == null)
			{
				break;
			}
			while (true)
			{
				bool flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
				int num = -958257137;
				while (true)
				{
					switch (num ^ -958257147)
					{
					case 11:
						num = -958257148;
						continue;
					default:
						return;
					case 3:
						break;
					case 6:
						goto end_IL_0012;
					case 1:
						goto end_IL_0083;
					case 5:
						num = -958257141;
						continue;
					case 10:
						instanceID = component.GetInstanceID();
						if (P_2.TryGetValue(instanceID, out value))
						{
							break;
						}
						if (!flag)
						{
							return;
						}
						goto case 8;
					case 13:
						value.YORsZWHKqfvSwofazZpoPgrtBHAK = false;
						value.EqRfVfQiNyAEecHrCklBUeHtTjH = false;
						num = -958257152;
						continue;
					case 8:
						value = new LoDceYDgQEnIrAMDcDjjCspbbFOG();
						value.BjCFuqdMJIabvLfGQddIBFDCrWEx = flag;
						P_2.Add(instanceID, value);
						num = -958257146;
						continue;
					case 0:
						goto IL_0115;
					case 14:
						UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
						num = -958257145;
						continue;
					case 9:
						value.YORsZWHKqfvSwofazZpoPgrtBHAK = true;
						value.EqRfVfQiNyAEecHrCklBUeHtTjH = P_1;
						num = -958257141;
						continue;
					case 7:
						goto IL_015f;
					case 12:
						goto IL_0188;
					case 4:
						value.YORsZWHKqfvSwofazZpoPgrtBHAK = false;
						value.EqRfVfQiNyAEecHrCklBUeHtTjH = false;
						value.BjCFuqdMJIabvLfGQddIBFDCrWEx = flag;
						if (!flag)
						{
							P_2.Remove(instanceID);
							return;
						}
						goto IL_015f;
					case 2:
						return;
					}
					if (value.YORsZWHKqfvSwofazZpoPgrtBHAK)
					{
						int num2;
						if (flag == value.BjCFuqdMJIabvLfGQddIBFDCrWEx)
						{
							num = -958257151;
							num2 = num;
						}
						else
						{
							num = -958257147;
							num2 = num;
						}
						continue;
					}
					goto IL_0115;
					IL_0188:
					int num3;
					if (flag == value.BjCFuqdMJIabvLfGQddIBFDCrWEx)
					{
						num = -958257150;
						num3 = num;
					}
					else
					{
						num = -958257151;
						num3 = num;
					}
					continue;
					IL_0115:
					int num4;
					if (!value.YORsZWHKqfvSwofazZpoPgrtBHAK)
					{
						num = -958257143;
						num4 = num;
					}
					else
					{
						num = -958257150;
						num4 = num;
					}
					continue;
					IL_015f:
					if (P_1 != flag && value.BjCFuqdMJIabvLfGQddIBFDCrWEx)
					{
						int num5;
						if (value.BjCFuqdMJIabvLfGQddIBFDCrWEx != P_1)
						{
							num = -958257140;
							num5 = num;
						}
						else
						{
							num = -958257144;
							num5 = num;
						}
						continue;
					}
					return;
					continue;
					end_IL_0012:
					break;
				}
				continue;
				end_IL_0083:
				break;
			}
		}
	}
}
