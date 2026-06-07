using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class MXySRXOfmMgXrIAuZtBSajLexeQ
{
	public class TJjOCDktpDoznERUIKEstSPgrhM
	{
		private class mIfzWeATJyTcEFlWRmMfdHayzqS : ExpandableArray_DataContainer<mIfzWeATJyTcEFlWRmMfdHayzqS>.auphSZvmhSLQzyipfcVqbmnlOPkA, IComparable<mIfzWeATJyTcEFlWRmMfdHayzqS>
		{
			public KeyboardKeyCode eZCuZcaXadasLLacRQKJXebMgIEg;

			public ModifierKeyFlags pxgOIesoqtEnNuHMTOPwpUSZHND;

			public void KZkCmzhSYSECcInSnhPgKBxtRsI(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				eZCuZcaXadasLLacRQKJXebMgIEg = P_0;
				pxgOIesoqtEnNuHMTOPwpUSZHND = P_1;
			}

			public void Set(mIfzWeATJyTcEFlWRmMfdHayzqS P_0)
			{
				eZCuZcaXadasLLacRQKJXebMgIEg = P_0.eZCuZcaXadasLLacRQKJXebMgIEg;
				pxgOIesoqtEnNuHMTOPwpUSZHND = P_0.pxgOIesoqtEnNuHMTOPwpUSZHND;
			}

			public bool Equals(mIfzWeATJyTcEFlWRmMfdHayzqS P_0)
			{
				if (eZCuZcaXadasLLacRQKJXebMgIEg == P_0.eZCuZcaXadasLLacRQKJXebMgIEg)
				{
					while (true)
					{
						int num = 846497452;
						while (true)
						{
							switch (num ^ 0x327486AD)
							{
							case 2:
								break;
							case 1:
								goto IL_002c;
							default:
								return true;
							}
							break;
							IL_002c:
							if (pxgOIesoqtEnNuHMTOPwpUSZHND != P_0.pxgOIesoqtEnNuHMTOPwpUSZHND)
							{
								goto end_IL_000e;
							}
							num = 846497453;
						}
						continue;
						end_IL_000e:
						break;
					}
				}
				return false;
			}

			public void Clear()
			{
				eZCuZcaXadasLLacRQKJXebMgIEg = KeyboardKeyCode.None;
				pxgOIesoqtEnNuHMTOPwpUSZHND = ModifierKeyFlags.None;
			}

			public int CompareTo(mIfzWeATJyTcEFlWRmMfdHayzqS other)
			{
				return 0;
			}
		}

		private enum lCjUSJMgBkBFexJVfIOuTMxSwhf
		{
			ktcScHylIQucOZxwvBGOYyghHZX = 0,
			OfiYndeVeuIgvUhQZDJfwfDHcQC = 1
		}

		private ModifierKeyFlags QrcvDDCHWcAzoHIjUDHNPnkAheEE;

		private ExpandableArray_DataContainer<mIfzWeATJyTcEFlWRmMfdHayzqS> BbYfufYoAOwLsEgfrbKJDtBVDfIA;

		private ExpandableArray_DataContainer<mIfzWeATJyTcEFlWRmMfdHayzqS> KmFfqPAKVGHxzdFvIPBNsRyuWzr;

		private Keyboard SFYAuTPTwQDVYDMfiGzNbbQzFhV;

		public TJjOCDktpDoznERUIKEstSPgrhM(Keyboard keyboard)
		{
			SFYAuTPTwQDVYDMfiGzNbbQzFhV = keyboard;
			QrcvDDCHWcAzoHIjUDHNPnkAheEE = ModifierKeyFlags.None;
			BbYfufYoAOwLsEgfrbKJDtBVDfIA = new ExpandableArray_DataContainer<mIfzWeATJyTcEFlWRmMfdHayzqS>(132, false, 132);
			KmFfqPAKVGHxzdFvIPBNsRyuWzr = new ExpandableArray_DataContainer<mIfzWeATJyTcEFlWRmMfdHayzqS>(5, false, 5);
		}

		public void rdEJYvExbWYUXSDuseVgzyXPBhA()
		{
			QrcvDDCHWcAzoHIjUDHNPnkAheEE = ModifierKeyFlags.None;
			BbYfufYoAOwLsEgfrbKJDtBVDfIA.Clear();
			int length = KmFfqPAKVGHxzdFvIPBNsRyuWzr.Length;
			int num = length - 1;
			while (num >= 0)
			{
				while (true)
				{
					mIfzWeATJyTcEFlWRmMfdHayzqS mIfzWeATJyTcEFlWRmMfdHayzqS2 = KmFfqPAKVGHxzdFvIPBNsRyuWzr[num];
					int num2 = 663166963;
					while (true)
					{
						switch (num2 ^ 0x27871FF2)
						{
						case 5:
							num2 = 663166966;
							continue;
						case 0:
							KmFfqPAKVGHxzdFvIPBNsRyuWzr.RemoveAt(num);
							num2 = 663166960;
							continue;
						case 2:
							num--;
							num2 = 663166961;
							continue;
						case 4:
							break;
						case 1:
							goto IL_0083;
						default:
							goto end_IL_006f;
						}
						break;
						IL_0083:
						int num3;
						if (!SFYAuTPTwQDVYDMfiGzNbbQzFhV.GetKey(mIfzWeATJyTcEFlWRmMfdHayzqS2.eZCuZcaXadasLLacRQKJXebMgIEg))
						{
							num2 = 663166962;
							num3 = num2;
						}
						else
						{
							num2 = 663166960;
							num3 = num2;
						}
					}
					continue;
					end_IL_006f:
					break;
				}
			}
		}

		public void iASUWziKCPOAqDFyBxjPKkUEupz(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 1974452433;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x75AFC0D0)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_002d;
			case 3:
				return;
			}
			goto IL_0003;
			IL_002d:
			QrcvDDCHWcAzoHIjUDHNPnkAheEE |= P_0.modifierKeyFlags;
			BbYfufYoAOwLsEgfrbKJDtBVDfIA.injector.KZkCmzhSYSECcInSnhPgKBxtRsI(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
			BbYfufYoAOwLsEgfrbKJDtBVDfIA.Inject();
			num = 1974452435;
			goto IL_0008;
		}

		public bool mqNUFPUSxTieRfzECkDKlmKwoII(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (QrcvDDCHWcAzoHIjUDHNPnkAheEE == ModifierKeyFlags.None && P_1 == ModifierKeyFlags.None)
			{
				goto IL_000b;
			}
			int doubledModifierKeyCount = Keyboard.GetDoubledModifierKeyCount(P_1);
			int num;
			if (mqNUFPUSxTieRfzECkDKlmKwoII(BbYfufYoAOwLsEgfrbKJDtBVDfIA, P_0, P_1, doubledModifierKeyCount, lCjUSJMgBkBFexJVfIOuTMxSwhf.ktcScHylIQucOZxwvBGOYyghHZX))
			{
				num = 1364231876;
			}
			else if (mqNUFPUSxTieRfzECkDKlmKwoII(KmFfqPAKVGHxzdFvIPBNsRyuWzr, P_0, P_1, doubledModifierKeyCount, lCjUSJMgBkBFexJVfIOuTMxSwhf.OfiYndeVeuIgvUhQZDJfwfDHcQC))
			{
				num = 1364231879;
			}
			else
			{
				if (P_1 == ModifierKeyFlags.None)
				{
					goto IL_009b;
				}
				KmFfqPAKVGHxzdFvIPBNsRyuWzr.injector.KZkCmzhSYSECcInSnhPgKBxtRsI(P_0, P_1);
				KmFfqPAKVGHxzdFvIPBNsRyuWzr.InjectIfUnique();
				num = 1364231874;
			}
			goto IL_0010;
			IL_009b:
			return false;
			IL_0010:
			switch (num ^ 0x515086C6)
			{
			case 0:
				break;
			case 3:
				return false;
			case 2:
				return true;
			case 1:
				return true;
			default:
				goto IL_009b;
			}
			goto IL_000b;
			IL_000b:
			num = 1364231877;
			goto IL_0010;
		}

		private bool mqNUFPUSxTieRfzECkDKlmKwoII(ExpandableArray_DataContainer<mIfzWeATJyTcEFlWRmMfdHayzqS> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, lCjUSJMgBkBFexJVfIOuTMxSwhf P_4)
		{
			bool flag = Keyboard.IsModifierKey(P_1);
			int length = P_0.Length;
			mIfzWeATJyTcEFlWRmMfdHayzqS mIfzWeATJyTcEFlWRmMfdHayzqS2 = default(mIfzWeATJyTcEFlWRmMfdHayzqS);
			int num3 = default(int);
			bool flag2 = default(bool);
			while (true)
			{
				int num = -2142201559;
				while (true)
				{
					switch (num ^ -2142201553)
					{
					case 5:
						break;
					case 2:
						if (flag)
						{
							goto case 1;
						}
						if (mIfzWeATJyTcEFlWRmMfdHayzqS2.eZCuZcaXadasLLacRQKJXebMgIEg == P_1)
						{
							num = -2142201554;
							continue;
						}
						goto IL_012b;
					case 3:
						mIfzWeATJyTcEFlWRmMfdHayzqS2 = P_0[num3];
						num = -2142201560;
						continue;
					case 6:
						num3 = 0;
						num = -2142201557;
						continue;
					case 0:
						if (flag2 || Keyboard.ModifierKeyFlagsContain(mIfzWeATJyTcEFlWRmMfdHayzqS2.pxgOIesoqtEnNuHMTOPwpUSZHND, (KeyCode)P_1))
						{
							goto case 2;
						}
						if (MathTools.qOsiFZjqUyWgwKunsmbTkfvCdXp((int)mIfzWeATJyTcEFlWRmMfdHayzqS2.pxgOIesoqtEnNuHMTOPwpUSZHND, (int)P_2))
						{
							num = -2142201555;
							continue;
						}
						goto IL_012b;
					case 4:
					{
						int num4;
						if (num3 >= length)
						{
							num = -2142201562;
							num4 = num;
						}
						else
						{
							num = -2142201556;
							num4 = num;
						}
						continue;
					}
					case 7:
					{
						flag2 = mIfzWeATJyTcEFlWRmMfdHayzqS2.eZCuZcaXadasLLacRQKJXebMgIEg == P_1;
						int num2;
						if (flag2)
						{
							num = -2142201561;
							num2 = num;
						}
						else
						{
							num = -2142201553;
							num2 = num;
						}
						continue;
					}
					case 8:
						if (mIfzWeATJyTcEFlWRmMfdHayzqS2.pxgOIesoqtEnNuHMTOPwpUSZHND != P_2)
						{
							num = -2142201553;
							continue;
						}
						goto IL_012b;
					case 1:
					{
						int doubledModifierKeyCount = Keyboard.GetDoubledModifierKeyCount(mIfzWeATJyTcEFlWRmMfdHayzqS2.pxgOIesoqtEnNuHMTOPwpUSZHND);
						if (doubledModifierKeyCount > P_3)
						{
							if (P_4 != lCjUSJMgBkBFexJVfIOuTMxSwhf.ktcScHylIQucOZxwvBGOYyghHZX)
							{
								return true;
							}
							if (SFYAuTPTwQDVYDMfiGzNbbQzFhV.AllRequiredKeysPressed(mIfzWeATJyTcEFlWRmMfdHayzqS2.eZCuZcaXadasLLacRQKJXebMgIEg, mIfzWeATJyTcEFlWRmMfdHayzqS2.pxgOIesoqtEnNuHMTOPwpUSZHND))
							{
								return true;
							}
						}
						goto IL_012b;
					}
					default:
						{
							return false;
						}
						IL_012b:
						num3++;
						num = -2142201557;
						continue;
					}
					break;
				}
			}
		}

		public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
		{
			QrcvDDCHWcAzoHIjUDHNPnkAheEE = ModifierKeyFlags.None;
			BbYfufYoAOwLsEgfrbKJDtBVDfIA.Clear();
			KmFfqPAKVGHxzdFvIPBNsRyuWzr.Clear();
		}
	}

	private readonly TJjOCDktpDoznERUIKEstSPgrhM[] TLERLwPBmpTvOkzIYiLpNvIoiAa;

	private UpdateLoopType KyGQivhvNcexgOdgEkqkdUhAdys;

	private readonly Keyboard SFYAuTPTwQDVYDMfiGzNbbQzFhV;

	private TJjOCDktpDoznERUIKEstSPgrhM CLjmYleEuCraJMMUJEFwtuAaGlg;

	public MXySRXOfmMgXrIAuZtBSajLexeQ(UpdateLoopSetting updateLoopSetting, Keyboard keyboard)
	{
		SFYAuTPTwQDVYDMfiGzNbbQzFhV = keyboard;
		TLERLwPBmpTvOkzIYiLpNvIoiAa = new TJjOCDktpDoznERUIKEstSPgrhM[3];
		int num = 0;
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				TJjOCDktpDoznERUIKEstSPgrhM tJjOCDktpDoznERUIKEstSPgrhM = new TJjOCDktpDoznERUIKEstSPgrhM(keyboard);
				TLERLwPBmpTvOkzIYiLpNvIoiAa[(int)list[i]] = tJjOCDktpDoznERUIKEstSPgrhM;
				num++;
				if (num == 1)
				{
					CLjmYleEuCraJMMUJEFwtuAaGlg = tJjOCDktpDoznERUIKEstSPgrhM;
				}
			}
		}
	}

	public void rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType P_0)
	{
		if (KyGQivhvNcexgOdgEkqkdUhAdys != P_0)
		{
			KyGQivhvNcexgOdgEkqkdUhAdys = P_0;
			CLjmYleEuCraJMMUJEFwtuAaGlg = TLERLwPBmpTvOkzIYiLpNvIoiAa[(int)P_0];
		}
		CLjmYleEuCraJMMUJEFwtuAaGlg.rdEJYvExbWYUXSDuseVgzyXPBhA();
	}

	public void JeIBSOiPcFNzaouiBXruMGOQOwE(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0051;
		IL_0003:
		int num = 439029888;
		goto IL_0008;
		IL_0008:
		AList<ActionElementMap> buttonMaps_orig = default(AList<ActionElementMap>);
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ 0x1A2B1082)
			{
			case 5:
				break;
			case 1:
			{
				ActionElementMap actionElementMap = buttonMaps_orig._items[num2];
				if (actionElementMap.hasModifiers)
				{
					CLjmYleEuCraJMMUJEFwtuAaGlg.iASUWziKCPOAqDFyBxjPKkUEupz(actionElementMap);
					num = 439029889;
					continue;
				}
				goto case 3;
			}
			case 4:
				goto IL_0051;
			case 3:
				num2++;
				num = 439029890;
				continue;
			case 2:
				return;
			default:
				if (num2 >= count)
				{
					return;
				}
				goto case 1;
			}
			break;
		}
		goto IL_0003;
		IL_0051:
		buttonMaps_orig = P_0.ButtonMaps_orig;
		count = buttonMaps_orig._count;
		num2 = 0;
		num = 439029890;
		goto IL_0008;
	}

	public bool mqNUFPUSxTieRfzECkDKlmKwoII(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		return CLjmYleEuCraJMMUJEFwtuAaGlg.mqNUFPUSxTieRfzECkDKlmKwoII(P_0, P_1);
	}

	public void PgZPlMozMoJLNxNdALvYkygDCFr()
	{
		int num = 0;
		while (num < TLERLwPBmpTvOkzIYiLpNvIoiAa.Length)
		{
			while (true)
			{
				int num2;
				if (TLERLwPBmpTvOkzIYiLpNvIoiAa[num] != null)
				{
					TLERLwPBmpTvOkzIYiLpNvIoiAa[num].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					num2 = -1658370649;
					goto IL_0009;
				}
				goto IL_0044;
				IL_0009:
				while (true)
				{
					switch (num2 ^ -1658370651)
					{
					case 0:
						num2 = -1658370650;
						continue;
					case 3:
						break;
					case 2:
						goto IL_0044;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				IL_0044:
				num++;
				num2 = -1658370652;
				goto IL_0009;
				continue;
				end_IL_0026:
				break;
			}
		}
	}
}
