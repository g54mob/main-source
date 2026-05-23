using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class RXykqpoobZXbeYNAmfMakWSBJalU
{
	[Flags]
	public enum zlJDrieuxlADuFmRezLclvHQNKee
	{
		TCGihQKDgeeGtvEXifcuojmabzj = 0,
		zObnXUAQjuELSOKdkpgPxHrSqyO = 1,
		LNdKYuuukcmEUWWnVSjYrthVBue = 2
	}

	private class LMzasCcUNpcNvFEDDNRRnssUziu
	{
		public bool iASppdBlVYSvKzbXwijEggRKSTL;

		public bool dQXcQJDbmxDlBFIlDXhsTynLjSHE;

		public bool jMTsSyufReivXAQeqghXhZLhfeK;
	}

	private Dictionary<int, LMzasCcUNpcNvFEDDNRRnssUziu> acTAAxigTnxruRkyJEEiBehLgEa;

	public zlJDrieuxlADuFmRezLclvHQNKee VUPnoVStuCzOxyaIdivBJqFXBtN;

	private bool isValid
	{
		get
		{
			return UnityTools.supportsUnityUIGraphicRaycastTarget;
		}
	}

	public RXykqpoobZXbeYNAmfMakWSBJalU()
		: this(zlJDrieuxlADuFmRezLclvHQNKee.zObnXUAQjuELSOKdkpgPxHrSqyO | zlJDrieuxlADuFmRezLclvHQNKee.LNdKYuuukcmEUWWnVSjYrthVBue)
	{
	}

	public RXykqpoobZXbeYNAmfMakWSBJalU(zlJDrieuxlADuFmRezLclvHQNKee targets)
	{
		VUPnoVStuCzOxyaIdivBJqFXBtN = targets;
		acTAAxigTnxruRkyJEEiBehLgEa = new Dictionary<int, LMzasCcUNpcNvFEDDNRRnssUziu>();
	}

	public void ZWxGRFCRCNYsxogmNDUfCfMeCIIr(Transform P_0, bool P_1)
	{
		if (!isValid)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if ((VUPnoVStuCzOxyaIdivBJqFXBtN & zlJDrieuxlADuFmRezLclvHQNKee.zObnXUAQjuELSOKdkpgPxHrSqyO) != zlJDrieuxlADuFmRezLclvHQNKee.TCGihQKDgeeGtvEXifcuojmabzj)
			{
				num = -787764767;
				num2 = num;
			}
			else
			{
				num = -787764768;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -787764767)
				{
				case 4:
					num = -787764766;
					continue;
				default:
					return;
				case 7:
					return;
				case 0:
					if ((VUPnoVStuCzOxyaIdivBJqFXBtN & zlJDrieuxlADuFmRezLclvHQNKee.LNdKYuuukcmEUWWnVSjYrthVBue) != zlJDrieuxlADuFmRezLclvHQNKee.TCGihQKDgeeGtvEXifcuojmabzj)
					{
						rEVdtDMHXcdOWFPmFptnIcacMVpc(P_0, P_1, acTAAxigTnxruRkyJEEiBehLgEa);
						num = -787764762;
						continue;
					}
					goto case 2;
				case 6:
					return;
				case 1:
					if ((VUPnoVStuCzOxyaIdivBJqFXBtN & zlJDrieuxlADuFmRezLclvHQNKee.LNdKYuuukcmEUWWnVSjYrthVBue) != zlJDrieuxlADuFmRezLclvHQNKee.TCGihQKDgeeGtvEXifcuojmabzj)
					{
						dWlFprTdLXBdCyKIjJXdBSegQEN(P_0, P_1, acTAAxigTnxruRkyJEEiBehLgEa);
						num = -787764764;
						continue;
					}
					return;
				case 2:
					ZWxGRFCRCNYsxogmNDUfCfMeCIIr(P_0, P_1, acTAAxigTnxruRkyJEEiBehLgEa);
					num = -787764761;
					continue;
				case 3:
					break;
				case 5:
					return;
				}
				break;
			}
		}
	}

	public void nympziBLtYDUiPlWNRoEGqbSPfa()
	{
		if (!isValid)
		{
			return;
		}
		while (true)
		{
			acTAAxigTnxruRkyJEEiBehLgEa.Clear();
			int num = 569909426;
			while (true)
			{
				switch (num ^ 0x21F820B0)
				{
				case 0:
					goto IL_0009;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0009:
				num = 569909425;
			}
		}
	}

	private static void rEVdtDMHXcdOWFPmFptnIcacMVpc(Transform P_0, bool P_1, Dictionary<int, LMzasCcUNpcNvFEDDNRRnssUziu> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			ZWxGRFCRCNYsxogmNDUfCfMeCIIr(P_0, P_1, P_2);
			int num = 2106608328;
			while (true)
			{
				switch (num ^ 0x7D904ACA)
				{
				case 0:
					goto IL_000a;
				case 1:
					break;
				default:
					dWlFprTdLXBdCyKIjJXdBSegQEN(P_0, P_1, P_2);
					return;
				}
				break;
				IL_000a:
				num = 2106608331;
			}
		}
	}

	private static void dWlFprTdLXBdCyKIjJXdBSegQEN(Transform P_0, bool P_1, Dictionary<int, LMzasCcUNpcNvFEDDNRRnssUziu> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			int childCount = P_0.childCount;
			int num = 0;
			int num2 = 1579340095;
			while (true)
			{
				switch (num2 ^ 0x5E22D13D)
				{
				case 0:
					num2 = 1579340094;
					continue;
				case 3:
					break;
				case 1:
					rEVdtDMHXcdOWFPmFptnIcacMVpc(P_0.GetChild(num), P_1, P_2);
					num++;
					num2 = 1579340095;
					continue;
				default:
					if (num >= childCount)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	private static void ZWxGRFCRCNYsxogmNDUfCfMeCIIr(Transform P_0, bool P_1, Dictionary<int, LMzasCcUNpcNvFEDDNRRnssUziu> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int instanceID = default(int);
		LMzasCcUNpcNvFEDDNRRnssUziu value = default(LMzasCcUNpcNvFEDDNRRnssUziu);
		while (true)
		{
			Graphic component = P_0.GetComponent<Graphic>();
			if (component == null)
			{
				break;
			}
			while (true)
			{
				IL_01ce:
				bool flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
				int num = 928087955;
				while (true)
				{
					switch (num ^ 0x37517F97)
					{
					case 7:
						num = 928087961;
						continue;
					default:
						return;
					case 15:
						if (!flag)
						{
							P_2.Remove(instanceID);
							return;
						}
						goto case 1;
					case 12:
						break;
					case 10:
						UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
						num = 928087957;
						continue;
					case 6:
						goto IL_00a8;
					case 11:
						if (!flag)
						{
							return;
						}
						goto case 13;
					case 8:
						value.jMTsSyufReivXAQeqghXhZLhfeK = false;
						num = 928087965;
						continue;
					case 0:
						goto IL_00ef;
					case 4:
						goto IL_010b;
					case 3:
						value.dQXcQJDbmxDlBFIlDXhsTynLjSHE = true;
						value.jMTsSyufReivXAQeqghXhZLhfeK = P_1;
						num = 928087965;
						continue;
					case 1:
						if (P_1 != flag && value.iASppdBlVYSvKzbXwijEggRKSTL)
						{
							if (value.iASppdBlVYSvKzbXwijEggRKSTL == P_1)
							{
								value.dQXcQJDbmxDlBFIlDXhsTynLjSHE = false;
								num = 928087967;
								continue;
							}
							goto case 3;
						}
						return;
					case 14:
						goto end_IL_0012;
					case 9:
						value.dQXcQJDbmxDlBFIlDXhsTynLjSHE = false;
						value.jMTsSyufReivXAQeqghXhZLhfeK = false;
						value.iASppdBlVYSvKzbXwijEggRKSTL = flag;
						num = 928087960;
						continue;
					case 13:
						value = new LMzasCcUNpcNvFEDDNRRnssUziu();
						value.iASppdBlVYSvKzbXwijEggRKSTL = flag;
						P_2.Add(instanceID, value);
						num = 928087953;
						continue;
					case 5:
						goto IL_01ce;
					case 2:
						return;
					}
					int num2;
					if (flag != value.iASppdBlVYSvKzbXwijEggRKSTL)
					{
						num = 928087966;
						num2 = num;
					}
					else
					{
						num = 928087958;
						num2 = num;
					}
					continue;
					IL_010b:
					instanceID = component.GetInstanceID();
					int num3;
					if (!P_2.TryGetValue(instanceID, out value))
					{
						num = 928087964;
						num3 = num;
					}
					else
					{
						num = 928087953;
						num3 = num;
					}
					continue;
					IL_00a8:
					if (value.dQXcQJDbmxDlBFIlDXhsTynLjSHE)
					{
						int num4;
						if (flag == value.iASppdBlVYSvKzbXwijEggRKSTL)
						{
							num = 928087966;
							num4 = num;
						}
						else
						{
							num = 928087959;
							num4 = num;
						}
						continue;
					}
					goto IL_00ef;
					IL_00ef:
					int num5;
					if (!value.dQXcQJDbmxDlBFIlDXhsTynLjSHE)
					{
						num = 928087963;
						num5 = num;
					}
					else
					{
						num = 928087958;
						num5 = num;
					}
					continue;
					end_IL_0012:
					break;
				}
				break;
			}
		}
	}
}
