using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class dAsBJCqlFUZsWwFTjrjITxqcqDX
{
	public class DPOuYkEDTwDzYJsdfOHQXHpZWoM
	{
		private class DxdVzYWoDeCdjjuSlSpBwLfXAlh : ExpandableArray_DataContainer<DxdVzYWoDeCdjjuSlSpBwLfXAlh>.NQrrZCNstUmxUQSuHmBoRPhtvSn, IComparable<DxdVzYWoDeCdjjuSlSpBwLfXAlh>
		{
			public KeyboardKeyCode VoQbUhcEgfKVubpnlLEXkujSnBHc;

			public ModifierKeyFlags EkeBLrMXcdajkAgJntAeIeUTDSSh;

			public void fuLKaTfKQpOpktgPzRLpUDfEjf(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				VoQbUhcEgfKVubpnlLEXkujSnBHc = P_0;
				EkeBLrMXcdajkAgJntAeIeUTDSSh = P_1;
			}

			public void Set(DxdVzYWoDeCdjjuSlSpBwLfXAlh P_0)
			{
				VoQbUhcEgfKVubpnlLEXkujSnBHc = P_0.VoQbUhcEgfKVubpnlLEXkujSnBHc;
				EkeBLrMXcdajkAgJntAeIeUTDSSh = P_0.EkeBLrMXcdajkAgJntAeIeUTDSSh;
			}

			public bool Equals(DxdVzYWoDeCdjjuSlSpBwLfXAlh P_0)
			{
				if (VoQbUhcEgfKVubpnlLEXkujSnBHc == P_0.VoQbUhcEgfKVubpnlLEXkujSnBHc && EkeBLrMXcdajkAgJntAeIeUTDSSh == P_0.EkeBLrMXcdajkAgJntAeIeUTDSSh)
				{
					return true;
				}
				return false;
			}

			public void Clear()
			{
				VoQbUhcEgfKVubpnlLEXkujSnBHc = KeyboardKeyCode.None;
				while (true)
				{
					int num = -370697897;
					while (true)
					{
						switch (num ^ -370697899)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0025;
						case 1:
							return;
						}
						break;
						IL_0025:
						EkeBLrMXcdajkAgJntAeIeUTDSSh = ModifierKeyFlags.None;
						num = -370697900;
					}
				}
			}

			public int CompareTo(DxdVzYWoDeCdjjuSlSpBwLfXAlh other)
			{
				return 0;
			}
		}

		private enum XqGTbKlXsVNRpQTNxWZbeBJaCMH
		{
			LPkchYDSCEmVvVltTXIIChuvKIAH = 0,
			bbkRwvOVbupQPcHErPnTVDLRjFb = 1
		}

		private ModifierKeyFlags jQkZAAcLKmbKTKgembBNaKkUQxPZ;

		private ExpandableArray_DataContainer<DxdVzYWoDeCdjjuSlSpBwLfXAlh> qYObrqmvQGmlJeAiDWuLGfPDFoF;

		private ExpandableArray_DataContainer<DxdVzYWoDeCdjjuSlSpBwLfXAlh> zxJXrKmqNYaMCzfkixZLLFaidoc;

		private Keyboard jXEbFYnmcSIgpclyYvQTdCKlRWYh;

		public DPOuYkEDTwDzYJsdfOHQXHpZWoM(Keyboard keyboard)
		{
			jXEbFYnmcSIgpclyYvQTdCKlRWYh = keyboard;
			jQkZAAcLKmbKTKgembBNaKkUQxPZ = ModifierKeyFlags.None;
			qYObrqmvQGmlJeAiDWuLGfPDFoF = new ExpandableArray_DataContainer<DxdVzYWoDeCdjjuSlSpBwLfXAlh>(132, false, 132);
			zxJXrKmqNYaMCzfkixZLLFaidoc = new ExpandableArray_DataContainer<DxdVzYWoDeCdjjuSlSpBwLfXAlh>(5, false, 5);
		}

		public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
		{
			jQkZAAcLKmbKTKgembBNaKkUQxPZ = ModifierKeyFlags.None;
			qYObrqmvQGmlJeAiDWuLGfPDFoF.Clear();
			int length = zxJXrKmqNYaMCzfkixZLLFaidoc.Length;
			int num2 = default(int);
			while (true)
			{
				int num = -68595245;
				while (true)
				{
					switch (num ^ -68595241)
					{
					case 0:
						break;
					case 4:
						num2 = length - 1;
						num = -68595242;
						continue;
					case 5:
					{
						DxdVzYWoDeCdjjuSlSpBwLfXAlh dxdVzYWoDeCdjjuSlSpBwLfXAlh = zxJXrKmqNYaMCzfkixZLLFaidoc[num2];
						int num3;
						if (!jXEbFYnmcSIgpclyYvQTdCKlRWYh.GetKey(dxdVzYWoDeCdjjuSlSpBwLfXAlh.VoQbUhcEgfKVubpnlLEXkujSnBHc))
						{
							num = -68595244;
							num3 = num;
						}
						else
						{
							num = -68595243;
							num3 = num;
						}
						continue;
					}
					case 2:
						num2--;
						num = -68595242;
						continue;
					case 3:
						zxJXrKmqNYaMCzfkixZLLFaidoc.RemoveAt(num2);
						num = -68595243;
						continue;
					default:
						if (num2 < 0)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public void FYBuwUQCLpNVrSpnnAXfLMCtPm(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				jQkZAAcLKmbKTKgembBNaKkUQxPZ |= P_0.modifierKeyFlags;
				qYObrqmvQGmlJeAiDWuLGfPDFoF.injector.fuLKaTfKQpOpktgPzRLpUDfEjf(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
				int num = 162304286;
				while (true)
				{
					switch (num ^ 0x9AC911F)
					{
					case 0:
						goto IL_0004;
					case 2:
						break;
					default:
						qYObrqmvQGmlJeAiDWuLGfPDFoF.Inject();
						return;
					}
					break;
					IL_0004:
					num = 162304285;
				}
			}
		}

		public bool NRReWYmMnLhFyDLXkZDYrOMqzHHJ(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (jQkZAAcLKmbKTKgembBNaKkUQxPZ == ModifierKeyFlags.None)
			{
				goto IL_0008;
			}
			goto IL_002b;
			IL_0008:
			int num = 686681638;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x28EDEE27)
			{
			case 2:
				break;
			case 1:
				goto IL_0026;
			default:
				goto IL_0082;
			}
			goto IL_0008;
			IL_0026:
			if (P_1 == ModifierKeyFlags.None)
			{
				return false;
			}
			goto IL_002b;
			IL_002b:
			int doubledModifierKeyCount = Keyboard.GetDoubledModifierKeyCount(P_1);
			if (NRReWYmMnLhFyDLXkZDYrOMqzHHJ(qYObrqmvQGmlJeAiDWuLGfPDFoF, P_0, P_1, doubledModifierKeyCount, XqGTbKlXsVNRpQTNxWZbeBJaCMH.LPkchYDSCEmVvVltTXIIChuvKIAH))
			{
				return true;
			}
			if (NRReWYmMnLhFyDLXkZDYrOMqzHHJ(zxJXrKmqNYaMCzfkixZLLFaidoc, P_0, P_1, doubledModifierKeyCount, XqGTbKlXsVNRpQTNxWZbeBJaCMH.bbkRwvOVbupQPcHErPnTVDLRjFb))
			{
				return true;
			}
			if (P_1 != ModifierKeyFlags.None)
			{
				zxJXrKmqNYaMCzfkixZLLFaidoc.injector.fuLKaTfKQpOpktgPzRLpUDfEjf(P_0, P_1);
				zxJXrKmqNYaMCzfkixZLLFaidoc.InjectIfUnique();
				num = 686681639;
				goto IL_000d;
			}
			goto IL_0082;
			IL_0082:
			return false;
		}

		private bool NRReWYmMnLhFyDLXkZDYrOMqzHHJ(ExpandableArray_DataContainer<DxdVzYWoDeCdjjuSlSpBwLfXAlh> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, XqGTbKlXsVNRpQTNxWZbeBJaCMH P_4)
		{
			bool flag = Keyboard.IsModifierKey(P_1);
			int length = P_0.Length;
			int num = 0;
			DxdVzYWoDeCdjjuSlSpBwLfXAlh dxdVzYWoDeCdjjuSlSpBwLfXAlh = default(DxdVzYWoDeCdjjuSlSpBwLfXAlh);
			bool flag2 = default(bool);
			while (true)
			{
				int num2;
				int num3;
				if (num >= length)
				{
					num2 = -496968175;
					num3 = num2;
				}
				else
				{
					num2 = -496968176;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -496968169)
					{
					case 0:
						num2 = -496968176;
						continue;
					case 1:
						if (dxdVzYWoDeCdjjuSlSpBwLfXAlh.EkeBLrMXcdajkAgJntAeIeUTDSSh != P_2)
						{
							num2 = -496968161;
							continue;
						}
						goto IL_0145;
					case 2:
						flag2 = dxdVzYWoDeCdjjuSlSpBwLfXAlh.VoQbUhcEgfKVubpnlLEXkujSnBHc == P_1;
						num2 = -496968163;
						continue;
					case 7:
						dxdVzYWoDeCdjjuSlSpBwLfXAlh = P_0[num];
						num2 = -496968171;
						continue;
					case 3:
						if (MathTools.ZpuxGINocmlmFwdyKekRJfzImeT((int)dxdVzYWoDeCdjjuSlSpBwLfXAlh.EkeBLrMXcdajkAgJntAeIeUTDSSh, (int)P_2))
						{
							num2 = -496968173;
							continue;
						}
						goto IL_0145;
					case 8:
						if (!flag2)
						{
							int num5;
							if (Keyboard.ModifierKeyFlagsContain(dxdVzYWoDeCdjjuSlSpBwLfXAlh.EkeBLrMXcdajkAgJntAeIeUTDSSh, (KeyCode)P_1))
							{
								num2 = -496968173;
								num5 = num2;
							}
							else
							{
								num2 = -496968172;
								num5 = num2;
							}
							continue;
						}
						goto case 4;
					case 5:
						break;
					case 10:
					{
						int num4;
						if (flag2)
						{
							num2 = -496968170;
							num4 = num2;
						}
						else
						{
							num2 = -496968161;
							num4 = num2;
						}
						continue;
					}
					case 4:
						if (flag)
						{
							goto case 9;
						}
						if (dxdVzYWoDeCdjjuSlSpBwLfXAlh.VoQbUhcEgfKVubpnlLEXkujSnBHc == P_1)
						{
							num2 = -496968162;
							continue;
						}
						goto IL_0145;
					case 9:
					{
						int doubledModifierKeyCount = Keyboard.GetDoubledModifierKeyCount(dxdVzYWoDeCdjjuSlSpBwLfXAlh.EkeBLrMXcdajkAgJntAeIeUTDSSh);
						if (doubledModifierKeyCount > P_3)
						{
							if (P_4 != XqGTbKlXsVNRpQTNxWZbeBJaCMH.LPkchYDSCEmVvVltTXIIChuvKIAH)
							{
								return true;
							}
							if (jXEbFYnmcSIgpclyYvQTdCKlRWYh.AllRequiredKeysPressed(dxdVzYWoDeCdjjuSlSpBwLfXAlh.VoQbUhcEgfKVubpnlLEXkujSnBHc, dxdVzYWoDeCdjjuSlSpBwLfXAlh.EkeBLrMXcdajkAgJntAeIeUTDSSh))
							{
								return true;
							}
						}
						goto IL_0145;
					}
					default:
						{
							return false;
						}
						IL_0145:
						num++;
						num2 = -496968174;
						continue;
					}
					break;
				}
			}
		}

		public void nympziBLtYDUiPlWNRoEGqbSPfa()
		{
			jQkZAAcLKmbKTKgembBNaKkUQxPZ = ModifierKeyFlags.None;
			qYObrqmvQGmlJeAiDWuLGfPDFoF.Clear();
			zxJXrKmqNYaMCzfkixZLLFaidoc.Clear();
		}
	}

	private readonly DPOuYkEDTwDzYJsdfOHQXHpZWoM[] eYGHEvjfglVQjGXNohHnkDIesNr;

	private UpdateLoopType xFKjhyBYBeaXHwQfmSuqSKfAFpj;

	private readonly Keyboard jXEbFYnmcSIgpclyYvQTdCKlRWYh;

	private DPOuYkEDTwDzYJsdfOHQXHpZWoM xbRrcEKKIAKiQkVzQCekOswVHrJ;

	public dAsBJCqlFUZsWwFTjrjITxqcqDX(UpdateLoopSetting updateLoopSetting, Keyboard keyboard)
	{
		jXEbFYnmcSIgpclyYvQTdCKlRWYh = keyboard;
		eYGHEvjfglVQjGXNohHnkDIesNr = new DPOuYkEDTwDzYJsdfOHQXHpZWoM[3];
		int num = 0;
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				DPOuYkEDTwDzYJsdfOHQXHpZWoM dPOuYkEDTwDzYJsdfOHQXHpZWoM = new DPOuYkEDTwDzYJsdfOHQXHpZWoM(keyboard);
				eYGHEvjfglVQjGXNohHnkDIesNr[(int)list[i]] = dPOuYkEDTwDzYJsdfOHQXHpZWoM;
				num++;
				if (num == 1)
				{
					xbRrcEKKIAKiQkVzQCekOswVHrJ = dPOuYkEDTwDzYJsdfOHQXHpZWoM;
				}
			}
		}
	}

	public void UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType P_0)
	{
		if (xFKjhyBYBeaXHwQfmSuqSKfAFpj != P_0)
		{
			xFKjhyBYBeaXHwQfmSuqSKfAFpj = P_0;
			goto IL_0010;
		}
		goto IL_0047;
		IL_0047:
		xbRrcEKKIAKiQkVzQCekOswVHrJ.UZSQFwoMfSAzsmmSKmseCCiJWWD();
		int num = -165887818;
		goto IL_0015;
		IL_0010:
		num = -165887820;
		goto IL_0015;
		IL_0015:
		while (true)
		{
			switch (num ^ -165887819)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				xbRrcEKKIAKiQkVzQCekOswVHrJ = eYGHEvjfglVQjGXNohHnkDIesNr[(int)P_0];
				num = -165887819;
				continue;
			case 0:
				goto IL_0047;
			case 3:
				return;
			}
			break;
		}
		goto IL_0010;
	}

	public void oeGGRBHlkBLUZjWtfmjyRzOAmvDp(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			AList<ActionElementMap> buttonMaps_orig = P_0.ButtonMaps_orig;
			int count = buttonMaps_orig._count;
			int num = 1469830277;
			while (true)
			{
				switch (num ^ 0x579BD480)
				{
				case 0:
					num = 1469830278;
					continue;
				case 6:
					break;
				case 5:
					num2 = 0;
					num = 1469830275;
					continue;
				case 4:
				{
					ActionElementMap actionElementMap = buttonMaps_orig._items[num2];
					if (actionElementMap.hasModifiers)
					{
						xbRrcEKKIAKiQkVzQCekOswVHrJ.FYBuwUQCLpNVrSpnnAXfLMCtPm(actionElementMap);
						num = 1469830274;
						continue;
					}
					goto case 2;
				}
				case 3:
					num = 1469830273;
					continue;
				case 2:
					num2++;
					num = 1469830273;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public bool NRReWYmMnLhFyDLXkZDYrOMqzHHJ(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		return xbRrcEKKIAKiQkVzQCekOswVHrJ.NRReWYmMnLhFyDLXkZDYrOMqzHHJ(P_0, P_1);
	}

	public void wWHIeZOvAcJogZJomCBAHnsZeBwE()
	{
		int num = 0;
		while (true)
		{
			int num2 = -1688391235;
			while (true)
			{
				switch (num2 ^ -1688391239)
				{
				case 0:
					break;
				case 4:
					num2 = -1688391237;
					continue;
				case 3:
					num++;
					num2 = -1688391237;
					continue;
				case 1:
					if (eYGHEvjfglVQjGXNohHnkDIesNr[num] != null)
					{
						eYGHEvjfglVQjGXNohHnkDIesNr[num].nympziBLtYDUiPlWNRoEGqbSPfa();
						num2 = -1688391238;
						continue;
					}
					goto case 3;
				default:
					if (num >= eYGHEvjfglVQjGXNohHnkDIesNr.Length)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}
}
