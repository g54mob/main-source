using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class CardInfoUI : MonoBehaviour
{
	[Serializable]
	public class CardEntry
	{
		public GameObject Root;

		public Image Image;

		public TextMeshProUGUI Text;

		public GameObject DecreaseImage;
	}

	private class EveryXDataHolder
	{
		public PowerUpType Type;

		public float Value;

		public int EveryXLevels;

		public int Count;

		public EveryXDataHolder(PowerUpType type, float value, int everyXLevels, int count)
		{
			int count2 = default(int);
			Count = count2;
			Value = value;
			Type = type;
			EveryXLevels = everyXLevels;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<CharacterSkillCard_Base, ArcanaType> _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal ArcanaType _003CSetData_003Eb__9_0(CharacterSkillCard_Base c)
		{
			//IL_0035: Expected I4, but got O
			if (c != null)
			{
				return c.Type;
			}
			NullReferenceException ex = new NullReferenceException();
			return (ArcanaType)ex;
		}
	}

	private TextMeshProUGUI Title;

	private TextMeshProUGUI LevelText;

	private Image Edition;

	private List<CardEntry> _oneColumnEntries;

	private List<CardEntry> _twoColumnEntries;

	private DataManager _dataManager;

	private void Construct(DataManager dataManager)
	{
		_dataManager = dataManager;
	}

	public unsafe void SetData(CharacterSkillCard_Base card, ArcanaData data)
	{
		//IL_1ced: Expected O, but got I4
		//IL_1cf6: Expected O, but got I4
		//IL_01ab: Expected O, but got Ref
		//IL_1db3: Expected O, but got I4
		//IL_06b2: Expected O, but got I
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected Ref, but got Unknown
		//IL_05d4: Expected I8, but got I4
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Expected Ref, but got Unknown
		//IL_0763: Expected O, but got I
		//IL_0787: Expected O, but got Ref
		//IL_1ebb: Expected I, but got O
		//IL_1ee1: Expected O, but got Ref
		//IL_07ca: Expected O, but got I
		//IL_08b9: Expected O, but got I
		//IL_0354: Expected F4, but got I
		//IL_0390: Expected I4, but got O
		//IL_09af: Expected O, but got I
		//IL_093c: Expected O, but got I
		//IL_0859: Expected O, but got I
		//IL_086f: Expected O, but got Ref
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad3: Expected I4, but got Unknown
		//IL_0cc3: Expected O, but got Ref
		//IL_1186: Unknown result type (might be due to invalid IL or missing references)
		//IL_118b: Expected O, but got Unknown
		//IL_11d1: Expected O, but got I4
		//IL_11f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f6: Expected O, but got Unknown
		//IL_1722: Expected O, but got I
		//IL_128a: Expected O, but got I
		//IL_177e: Expected F4, but got I
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a3: Expected O, but got Unknown
		//IL_15ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b1: Expected O, but got Unknown
		//IL_12b8: Expected O, but got I
		//IL_17b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b9: Expected O, but got Unknown
		//IL_15e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ec: Expected O, but got Unknown
		//IL_18c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cc: Expected O, but got Unknown
		//IL_18d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18da: Expected O, but got Unknown
		//IL_24b8: Expected I, but got O
		//IL_1f40: Expected I, but got O
		//IL_20d2: Expected I, but got O
		//IL_20e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e6: Expected O, but got Unknown
		//IL_1941: Expected O, but got I
		//IL_1830: Expected O, but got I
		//IL_1663: Expected O, but got I
		//IL_1953: Expected O, but got I
		//IL_0eca: Expected O, but got I
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b92: Expected O, but got Unknown
		//IL_147c: Expected O, but got I4
		//IL_147c: Expected I4, but got O
		//IL_22cd: Expected I, but got O
		//IL_2216: Expected I, but got O
		//IL_2388: Expected I, but got O
		//IL_23bb: Expected O, but got Ref
		//IL_0f1e: Expected I4, but got O
		//IL_14dd: Expected I, but got O
		//IL_230b: Expected I, but got O
		//IL_0f73: Expected O, but got I
		//IL_1998: Expected O, but got I4
		//IL_1998: Expected I4, but got O
		//IL_224c: Expected I, but got O
		//IL_0fcc: Expected O, but got I
		//IL_19f8: Expected I, but got O
		//IL_2352: Expected I, but got O
		//IL_1a59: Expected O, but got I4
		//IL_1f82: Expected O, but got I
		//IL_1f82: Expected O, but got I
		//IL_23f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_23fa: Expected O, but got Unknown
		//IL_1fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbb: Expected O, but got Unknown
		//IL_2006: Expected F4, but got I
		//IL_2006: Expected I4, but got O
		//IL_1082: Expected O, but got I
		//IL_10e9: Expected O, but got I
		//IL_115a: Unknown result type (might be due to invalid IL or missing references)
		//IL_115f: Expected O, but got Unknown
		//IL_0469->IL1bbb: Incompatible stack heights: 1 vs 0
		//IL_04a3->IL1d7f: Incompatible stack heights: 2 vs 0
		//IL_1eae->IL2536: Incompatible stack heights: 6 vs 0
		//IL_0dd9->IL1bbb: Incompatible stack heights: 1 vs 0
		//IL_0e2d->IL1bbb: Incompatible stack heights: 2 vs 0
		//IL_0e5c->IL1bbb: Incompatible stack heights: 2 vs 0
		//IL_15be->IL21c1: Incompatible stack heights: 1 vs 0
		//IL_0e95->IL1bbb: Incompatible stack heights: 4 vs 0
		//IL_0eea->IL1bbb: Incompatible stack heights: 5 vs 0
		//IL_1b9f->IL24ce: Incompatible stack heights: 5 vs 4
		//IL_0f07->IL1bbb: Incompatible stack heights: 5 vs 0
		//IL_0f3a->IL1bbb: Incompatible stack heights: 5 vs 0
		//IL_0f93->IL1bbb: Incompatible stack heights: 6 vs 0
		//IL_219f->IL255c: Incompatible stack heights: 10 vs 0
		//IL_0fec->IL1bbb: Incompatible stack heights: 7 vs 0
		//IL_229c->IL21bc: Incompatible stack heights: 6 vs 0
		//IL_1fa3->IL1bbb: Incompatible stack heights: 7 vs 0
		//IL_18be->IL21bc: Incompatible stack heights: 6 vs 0
		//IL_1025->IL1bbb: Incompatible stack heights: 7 vs 0
		//IL_2027->IL1bbb: Incompatible stack heights: 7 vs 0
		//IL_248c->IL2582: Incompatible stack heights: 11 vs 0
		//IL_2049->IL1bbb: Incompatible stack heights: 7 vs 0
		//IL_117d->IL204e: Incompatible stack heights: 7 vs 0
		List<ArcanaType> list3;
		CardInfoUI cardInfoUI2 = default(CardInfoUI);
		List<Tuple<PowerUpType, float>> powerUpTypesFromModifierStats;
		List<EveryXDataHolder> list4;
		List<EveryXDataHolder> list5;
		CardInfoUI cardInfoUI4;
		List<Tuple<PowerUpType, float>> list6;
		Tuple<PowerUpType, float> tuple;
		bool flag5 = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag6 = default(bool);
		bool flag8;
		string text2;
		string value;
		bool flag10;
		if (card != null)
		{
			List<CharacterSkillCard_Base> subCards = card.SubCards;
			if (card.SubCards != null)
			{
				List<ArcanaType> list2;
				CardInfoUI cardInfoUI;
				if (subCards._size <= 0)
				{
					List<ArcanaType> list = new List<ArcanaType>();
					list2 = list;
					list3 = list;
					cardInfoUI = this;
				}
				else
				{
					Func<CharacterSkillCard_Base, ArcanaType> selector = _003C_003Ec._003C_003E9__9_0;
					bool flag = _003C_003Ec._003C_003E9__9_0 != null;
					cardInfoUI = this;
					if (!flag)
					{
						selector = (_003C_003Ec._003C_003E9__9_0 = delegate(CharacterSkillCard_Base c)
						{
							//IL_0035: Expected I4, but got O
							if (c == null)
							{
								NullReferenceException ex2 = new NullReferenceException();
								return (ArcanaType)ex2;
							}
							return c.Type;
						});
						cardInfoUI = cardInfoUI2;
					}
					IEnumerable<ArcanaType> source = Enumerable.Select(card.SubCards, selector);
					IEnumerable<ArcanaType> enumerable = Enumerable.Select((IEnumerable<CharacterSkillCard_Base>)source, selector);
					list2 = (List<ArcanaType>)enumerable;
					list3 = (List<ArcanaType>)enumerable;
				}
				powerUpTypesFromModifierStats = cardInfoUI.GetPowerUpTypesFromModifierStats(card.InitialBonus);
				list4 = new List<EveryXDataHolder>();
				IEnumerable<Dictionary<int, ModifierStats>> modifierStatsMaps = card.ModifierStatsMaps;
				if (card.ModifierStatsMaps != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v145 (System.Collections.Generic.IEnumerable`1<System.Collections.Generic.Dictionary`2<System.Int32, VampireSurvivors.Objects.ModifierStats>>)+18]");
					if ((nint)0 > (nint)0)
					{
						Dictionary<int, ModifierStats> dictionary = Enumerable.First(card.ModifierStatsMaps);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF2590");
						ModifierStats stats = default(ModifierStats);
						List<Tuple<PowerUpType, float>> powerUpTypesFromModifierStats2 = cardInfoUI.GetPowerUpTypesFromModifierStats(stats);
						if (powerUpTypesFromModifierStats2 == null)
						{
							goto IL_1bbb;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183759310");
						list5 = list4;
						List<Tuple<PowerUpType, float>>.Enumerator enumerator = default(List<Tuple<PowerUpType, float>>.Enumerator);
						object obj = default(object);
						while (enumerator.MoveNext())
						{
							bool flag2 = dictionary == null;
							List<Tuple<PowerUpType, float>>.Enumerator enumerator2 = (List<Tuple<PowerUpType, float>>.Enumerator)(&enumerator);
							if (!flag2)
							{
								Dictionary<int, ModifierStats>.KeyCollection keys = dictionary.Keys;
								if (keys != null)
								{
									CardInfoUI cardInfoUI3 = (CardInfoUI)(object)new List<int>(keys);
									if (obj != null)
									{
										if ((object)cardInfoUI3 != null)
										{
											if ((nint)((MonoBehaviour)cardInfoUI3).m_CancellationTokenSource > 1)
											{
												IntPtr cachedPtr = ((UnityEngine.Object)cardInfoUI3).m_CachedPtr;
												if (((UnityEngine.Object)cardInfoUI3).m_CachedPtr != (IntPtr)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v526 (System.IntPtr)+18]");
													if ((nint)0 <= (nint)1)
													{
														throw new IndexOutOfRangeException();
													}
													if ((nint)((MonoBehaviour)cardInfoUI3).m_CancellationTokenSource > 0)
													{
														if (((UnityEngine.Object)cardInfoUI3).m_CachedPtr != (IntPtr)0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v526 (System.IntPtr)+18]");
															if ((nint)0 > (nint)0)
															{
																EveryXDataHolder everyXDataHolder = null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-188+10]");
																everyXDataHolder.Type = PowerUpType.POWER;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-188+14]");
																everyXDataHolder.Value = 0f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v526 (System.IntPtr)+24]");
																nint num = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v526 (System.IntPtr)+20]");
																nint num2 = num - 0;
																everyXDataHolder.EveryXLevels = (int)num2;
																everyXDataHolder.Count = (int)((MonoBehaviour)cardInfoUI3).m_CancellationTokenSource;
																if (list4 != null)
																{
																	((List<object>)(object)list4).Add((object)everyXDataHolder);
																	list5 = list4;
																	continue;
																}
																throw new NullReferenceException();
															}
															throw new IndexOutOfRangeException();
														}
														throw new NullReferenceException();
													}
													System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
												}
												throw new NullReferenceException();
											}
											System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								Exception ex = System.Linq.Error.ArgumentNull("source");
								throw ex;
							}
							throw new NullReferenceException();
						}
						object obj2 = obj;
						List<Tuple<PowerUpType, float>>.Enumerator enumerator4 = default(List<Tuple<PowerUpType, float>>.Enumerator);
						List<Tuple<PowerUpType, float>>.Enumerator enumerator3 = enumerator4;
						list3 = list2;
						cardInfoUI4 = null;
						list6 = powerUpTypesFromModifierStats;
						cardInfoUI = cardInfoUI2;
					}
					else
					{
						object obj2 = 0;
						List<Tuple<PowerUpType, float>>.Enumerator enumerator3 = (List<Tuple<PowerUpType, float>>.Enumerator)0;
						list5 = list4;
						cardInfoUI4 = null;
						list6 = powerUpTypesFromModifierStats;
					}
					List<Tuple<PowerUpType, float>> powerUpTypesFromModifierStats3 = cardInfoUI.GetPowerUpTypesFromModifierStats(card.OnEveryLevelUp);
					if (powerUpTypesFromModifierStats3 != null)
					{
						if (powerUpTypesFromModifierStats3._size > 0)
						{
							bool flag3 = powerUpTypesFromModifierStats3._size <= 0;
							Tuple<PowerUpType, float>[] items = powerUpTypesFromModifierStats3._items;
							if (powerUpTypesFromModifierStats3._items == null)
							{
								goto IL_1bbb;
							}
							bool flag4 = items.Length <= 0;
							tuple = items[0];
						}
						else
						{
							tuple = (Tuple<PowerUpType, float>)(object)cardInfoUI4;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						CardInfoUI cardInfoUI5 = default(CardInfoUI);
						string translation = LocalizationManager.GetTranslation((string)(object)cardInfoUI5, FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, gameObject, text, flag6);
						bool flag7 = (object)translation == cardInfoUI5;
						flag8 = true;
						if (flag7)
						{
							goto IL_0632;
						}
						bool flag9 = translation == null;
						text2 = translation;
						value = translation;
						flag10 = true;
						if (!flag9)
						{
							bool flag11 = (object)cardInfoUI5 == null;
							text2 = translation;
							value = translation;
							flag10 = true;
							if (!flag11)
							{
								bool flag12 = (IntPtr)translation._stringLength != ((UnityEngine.Object)cardInfoUI5).m_CachedPtr;
								text2 = translation;
								value = translation;
								flag10 = true;
								if (!flag12)
								{
									ref byte second = ref *(byte*)(cardInfoUI5 + 20);
									ulong length = (ulong)(translation._stringLength + translation._stringLength);
									bool flag13 = System.SpanHelpers.SequenceEqual(ref *(byte*)(translation + 20), ref second, length);
									bool flag14 = !flag13;
									flag8 = false;
									text2 = translation;
									value = translation;
									flag10 = false;
									if (!flag14)
									{
										goto IL_0632;
									}
								}
							}
						}
						goto IL_1d98;
					}
				}
			}
		}
		goto IL_1bbb;
		IL_1bbb:
		throw new NullReferenceException();
		IL_0d4d:
		CardInfoUI cardInfoUI6 = cardInfoUI4;
		System.ParamsArray paramsArray2;
		System.ParamsArray paramsArray = paramsArray2;
		CardInfoUI cardInfoUI7 = cardInfoUI4;
		CardInfoUI cardInfoUI8 = cardInfoUI4;
		List<CardEntry> list7;
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData;
		object obj7 = default(object);
		object obj9;
		List<EveryXDataHolder>.Enumerator enumerator5 = default(List<EveryXDataHolder>.Enumerator);
		object obj11 = default(object);
		object obj12 = default(object);
		object obj13 = default(object);
		object obj15 = default(object);
		System.ParamsArray paramsArray3 = default(System.ParamsArray);
		object arg = default(object);
		List<ArcanaType> list22 = default(List<ArcanaType>);
		object obj19 = default(object);
		while (true)
		{
			if ((nint)cardInfoUI8 < powerUpTypesFromModifierStats._size)
			{
				if (list7 == null)
				{
					break;
				}
				bool flag15 = (nint)cardInfoUI7 >= list7._size;
				CardEntry[] items2 = list7._items;
				if (list7._items == null)
				{
					break;
				}
				bool flag16 = (nint)cardInfoUI7 >= items2.Length;
				CardEntry cardEntry = items2[(object)cardInfoUI7];
				if (items2[(object)cardInfoUI7] == null)
				{
					break;
				}
				List<Tuple<PowerUpType, float>> root = (List<Tuple<PowerUpType, float>>)(object)cardEntry.Root;
				if ((object)cardEntry.Root == null)
				{
					break;
				}
				bool flag17 = root._items == null;
				GameObject.SetActive_Injected((IntPtr)root._items, true);
				bool flag18 = (nint)cardInfoUI7 >= powerUpTypesFromModifierStats._size;
				List<Tuple<PowerUpType, float>> items3 = (List<Tuple<PowerUpType, float>>)(object)powerUpTypesFromModifierStats._items;
				if (powerUpTypesFromModifierStats._items == null)
				{
					break;
				}
				bool flag19 = (nint)cardInfoUI7 >= items3._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rsi_v126 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+20+v771 @ rbx_v101 (VampireSurvivors.UI.CardInfoUI)*8]");
				List<Tuple<PowerUpType, float>> list8 = (List<Tuple<PowerUpType, float>>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rsi_v126 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+20+v771 @ rbx_v101 (VampireSurvivors.UI.CardInfoUI)*8]");
				if ((nint)0 == 0 || convertedPowerUpData == null)
				{
					break;
				}
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)list8._items);
				if (obj3 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v800 @ rax_v437 (System.Object)+18]");
				bool flag20 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v800 @ rax_v437 (System.Object)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v800 @ rax_v437 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ rax_v438+18]");
				bool flag21 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ rax_v438+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ rax_v438+20]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v212+38]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v212+30]");
				Sprite sprite = SpriteManager.GetSprite((string)num3, (string)0);
				if ((object)cardEntry.Image == null)
				{
					break;
				}
				cardEntry.Image.sprite = sprite;
				if ((object)cardEntry.Image == null)
				{
					break;
				}
				object obj6 = cardEntry.Image + 244;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77350");
				if (obj7 != null)
				{
					cardEntry.Image.SetVerticesDirty();
				}
				Tuple<PowerUpType, float>[] items4 = list8._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rsi_v127 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14]");
				string textForEntry = cardInfoUI2.GetTextForEntry((PowerUpType)items4, 0f);
				if ((object)cardEntry.Text == null)
				{
					break;
				}
				cardEntry.Text.text = textForEntry;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rsi_v127 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14]");
				bool flag22 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rsi_v127 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14]");
				object obj8 = -0;
				bool flag23 = obj8 == null;
				bool flag24 = !flag22;
				bool flag25 = !flag23;
				bool active = flag25 & flag24;
				if ((nint)list8._items == 6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rsi_v127 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14]");
					paramsArray = (System.ParamsArray)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rsi_v127 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14]");
					bool flag26 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rsi_v127 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14]");
					bool flag27 = (nint)0 == 0;
					bool flag28 = !flag26;
					bool flag29 = !flag27;
					active = flag29 & flag28;
				}
				if ((object)cardEntry.DecreaseImage == null)
				{
					break;
				}
				cardEntry.DecreaseImage.SetActive(active);
				CardInfoUI cardInfoUI9 = (CardInfoUI)(cardInfoUI7 + 1);
				cardInfoUI6 = cardInfoUI7;
				cardInfoUI7 = cardInfoUI9;
				cardInfoUI8 = cardInfoUI9;
				continue;
			}
			List<Tuple<PowerUpType, float>> list9 = (List<Tuple<PowerUpType, float>>)(cardInfoUI6 + 1);
			if ((nint)obj9 >= 5 && (nint)list9 < 6)
			{
				list9 = (List<Tuple<PowerUpType, float>>)6;
			}
			bool flag30 = list4._size <= 0;
			List<CardEntry> list10 = list7;
			if (!flag30)
			{
				string text3;
				string descriptionTextString;
				bool flag40;
				CardInfoUI cardInfoUI10;
				nint num4;
				List<Tuple<PowerUpType, float>> title;
				CardInfoUI levelText;
				bool flag41;
				bool flag42;
				List<Tuple<PowerUpType, float>> list11;
				for (list10 = list7; enumerator5.MoveNext(); text3 = cardInfoUI2.ReplaceDescriptionTextPlaceholder(descriptionTextString, null, addStatsText: true), flag40 = (object)cardInfoUI10.Title == null, num4 = (nint)title, Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v10490 @ r8_v140 (Il2CppClass<System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>>)+558] (should have been resolved before IL gen)"), levelText = (CardInfoUI)(object)cardInfoUI10.LevelText, flag41 = (object)cardInfoUI10.LevelText == null, flag42 = ((UnityEngine.Object)levelText).m_CachedPtr == (IntPtr)0, GameObject.SetActive_Injected(((UnityEngine.Object)levelText).m_CachedPtr, false), list9 = list11, list10 = list7)
				{
					EveryXDataHolder everyXDataHolder2 = null;
					list11 = (List<Tuple<PowerUpType, float>>)(list9 + 1);
					bool flag31 = list10 == null;
					bool flag32 = (nint)list9 >= list10._size;
					CardInfoUI items5 = (CardInfoUI)(object)list10._items;
					bool flag33 = list10._items == null;
					List<Tuple<PowerUpType, float>> list12 = list9;
					CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)items5).m_CancellationTokenSource;
					bool flag34 = System.Runtime.CompilerServices.Unsafe.As<List<Tuple<PowerUpType, float>>, UIntPtr>(ref list12) >= System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2169 @ rbx_v122 (VampireSurvivors.UI.CardInfoUI)+20+v5619 @ r14_v99 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)*8]");
					cardInfoUI10 = (CardInfoUI)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2169 @ rbx_v122 (VampireSurvivors.UI.CardInfoUI)+20+v5619 @ r14_v99 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)*8]");
					bool flag35 = (nint)0 == 0;
					List<Tuple<PowerUpType, float>> list13 = (List<Tuple<PowerUpType, float>>)(nint)((UnityEngine.Object)cardInfoUI10).m_CachedPtr;
					bool flag36 = ((UnityEngine.Object)cardInfoUI10).m_CachedPtr == (IntPtr)0;
					bool flag37 = list13._items == null;
					GameObject.SetActive_Injected((IntPtr)list13._items, true);
					object obj10 = ((MonoBehaviour)cardInfoUI10).m_CancellationTokenSource + 244;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77350");
					if (obj11 != null)
					{
						((List<T>)(object)((MonoBehaviour)cardInfoUI10).m_CancellationTokenSource).RemoveAt(0);
					}
					title = (List<Tuple<PowerUpType, float>>)(object)cardInfoUI10.Title;
					bool flag38 = LocalizationManager.TryGetTranslation("arcanaLang/{9999}description", out var Translation, FixForRTL: true, 0, flag5, (byte)(int)gameObject != 0, (GameObject)(object)text, (string)flag6);
					if (Translation != null)
					{
						bool flag39 = Translation._stringLength > 0;
						descriptionTextString = Translation;
						if (flag39)
						{
							continue;
						}
					}
					descriptionTextString = "arcanaLang/{9999}description";
				}
			}
			if (text2 != null)
			{
				List<Tuple<PowerUpType, float>> list14 = (List<Tuple<PowerUpType, float>>)(object)cardInfoUI4;
				CardInfoUI cardInfoUI11 = cardInfoUI4;
				CardInfoUI cardInfoUI12 = cardInfoUI4;
				while ((nint)cardInfoUI12 < text2._stringLength)
				{
					bool flag43 = (nint)cardInfoUI11 >= text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6663 @ rsi_v109 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)+14+v137 @ stack_-C0_v90 (System.String)]");
					if (char.IsWhiteSpace('\0'))
					{
						cardInfoUI11 = (CardInfoUI)(cardInfoUI11 + 1);
						list14 = (List<Tuple<PowerUpType, float>>)(list14 + 2);
						cardInfoUI12 = cardInfoUI11;
						continue;
					}
					if (tuple == null)
					{
						List<Tuple<PowerUpType, float>> list15 = (List<Tuple<PowerUpType, float>>)(list9 + 1);
						bool flag44 = (nint)list9 >= list10._size;
						CardEntry[] items6 = list10._items;
						bool flag45 = (nint)list9 >= items6.Length;
						CardInfoUI cardInfoUI13 = (CardInfoUI)(object)items6[(object)list9];
						List<Tuple<PowerUpType, float>> list16 = (List<Tuple<PowerUpType, float>>)(nint)((UnityEngine.Object)cardInfoUI13).m_CachedPtr;
						bool flag46 = list16._items == null;
						GameObject.SetActive_Injected((IntPtr)list16._items, true);
						GameObject gameObject2 = ((Component)(object)((MonoBehaviour)cardInfoUI13).m_CancellationTokenSource).gameObject;
						bool flag47 = ((List<Tuple<PowerUpType, float>>)(object)gameObject2)._items == null;
						GameObject.SetActive_Injected((IntPtr)((List<Tuple<PowerUpType, float>>)(object)gameObject2)._items, false);
						TextMeshProUGUI title2 = cardInfoUI13.Title;
						title2.text = text2;
						CardInfoUI levelText2 = (CardInfoUI)(object)cardInfoUI13.LevelText;
						bool flag48 = ((UnityEngine.Object)levelText2).m_CachedPtr == (IntPtr)0;
						GameObject.SetActive_Injected(((UnityEngine.Object)levelText2).m_CachedPtr, false);
						list9 = list15;
					}
					else
					{
						EveryXDataHolder everyXDataHolder3 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2043 @ rax_v209 (System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>)+10]");
						everyXDataHolder3.Type = PowerUpType.POWER;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2043 @ rax_v209 (System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>)+14]");
						everyXDataHolder3.Value = 0f;
						everyXDataHolder3.EveryXLevels = 0;
						string text4 = cardInfoUI2.ReplaceDescriptionTextPlaceholder(text2, everyXDataHolder3, addStatsText: false);
						List<Tuple<PowerUpType, float>> list17 = (List<Tuple<PowerUpType, float>>)(list9 + 1);
						bool flag49 = (nint)list9 >= list10._size;
						CardEntry[] items7 = list10._items;
						bool flag50 = (nint)list9 >= items7.Length;
						CardInfoUI cardInfoUI14 = (CardInfoUI)(object)items7[(object)list9];
						List<Tuple<PowerUpType, float>> list18 = (List<Tuple<PowerUpType, float>>)(nint)((UnityEngine.Object)cardInfoUI14).m_CachedPtr;
						bool flag51 = list18._items == null;
						GameObject.SetActive_Injected((IntPtr)list18._items, true);
						List<Tuple<PowerUpType, float>> cancellationTokenSource2 = (List<Tuple<PowerUpType, float>>)(object)((MonoBehaviour)cardInfoUI14).m_CancellationTokenSource;
						bool flag52 = cancellationTokenSource2._items == null;
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)cancellationTokenSource2._items);
						GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						bool flag53 = ((List<Tuple<PowerUpType, float>>)(object)gameObject3)._items == null;
						GameObject.SetActive_Injected((IntPtr)((List<Tuple<PowerUpType, float>>)(object)gameObject3)._items, true);
						Sprite sprite2 = SpriteManager.GetSprite("SkillIcon_EveryLevel", "UI");
						((Image)(object)((MonoBehaviour)cardInfoUI14).m_CancellationTokenSource).sprite = sprite2;
						cardInfoUI14.Title.text = text4;
						((GameObject)(object)cardInfoUI14.LevelText).SetActive(false);
						list9 = list17;
					}
					break;
				}
			}
			while (true)
			{
				bool flag54 = obj12 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5583 @ stack_-130_v38+1C]");
				if (obj13 != null)
				{
					break;
				}
				object obj14 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5583 @ stack_-130_v38+18]");
				if ((nint)obj14 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5583 @ stack_-130_v38+10]");
				object obj16 = 0;
				object obj17 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5641 @ rdx_v157+18]");
				bool flag55 = (nint)obj17 >= 0;
				obj15++;
				List<Tuple<PowerUpType, float>> list19 = (List<Tuple<PowerUpType, float>>)(list9 + 1);
				bool flag56 = (nint)list9 >= list7._size;
				CardInfoUI items8 = (CardInfoUI)(object)list7._items;
				List<Tuple<PowerUpType, float>> list20 = list9;
				CancellationTokenSource cancellationTokenSource3 = ((MonoBehaviour)items8).m_CancellationTokenSource;
				bool flag57 = System.Runtime.CompilerServices.Unsafe.As<List<Tuple<PowerUpType, float>>, UIntPtr>(ref list20) >= System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7498 @ rbx_v109 (VampireSurvivors.UI.CardInfoUI)+20+v5619 @ r14_v99 (System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>)*8]");
				CardInfoUI cardInfoUI15 = (CardInfoUI)0;
				List<Tuple<PowerUpType, float>> list21 = (List<Tuple<PowerUpType, float>>)(nint)((UnityEngine.Object)cardInfoUI15).m_CachedPtr;
				bool flag58 = list21._items == null;
				GameObject.SetActive_Injected((IntPtr)list21._items, true);
				List<Tuple<PowerUpType, float>> title3 = (List<Tuple<PowerUpType, float>>)(object)cardInfoUI15.Title;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				paramsArray3 = new System.ParamsArray(arg);
				string text5 = string.FormatHelper((IFormatProvider)null, "arcanaLang/{{{0}}}description", (System.ParamsArray)(&list22));
				bool flag59 = LocalizationManager.TryGetTranslation(text5, out var Translation2, FixForRTL: true, 0, flag5, (byte)(int)gameObject != 0, (GameObject)(object)text, (string)flag6);
				string text6;
				if (Translation2 != null)
				{
					bool flag60 = Translation2._stringLength > 0;
					text6 = Translation2;
					if (flag60)
					{
						goto IL_23c9;
					}
				}
				text6 = text5;
				goto IL_23c9;
				IL_23c9:
				bool flag61 = (object)cardInfoUI15.Title == null;
				nint num5 = (nint)title3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v10305 @ r8_v116 (Il2CppClass<System.Collections.Generic.List`1<System.Tuple`2<VampireSurvivors.Data.PowerUpType, System.Single>>>)+558] (should have been resolved before IL gen)");
				Sprite sprite3 = SpriteManager.GetSprite("Skillicon_Special", "UI");
				bool flag62 = ((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource == null;
				((Image)(object)((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource).sprite = sprite3;
				Sprite subSkillIcon = GetSubSkillIcon((ArcanaType?)(object)1);
				bool flag63 = ((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource == null;
				((Image)(object)((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource).sprite = subSkillIcon;
				bool flag64 = ((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource == null;
				object obj18 = ((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource + 244;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77350");
				if (obj19 != null)
				{
					((List<T>)(object)((MonoBehaviour)cardInfoUI15).m_CancellationTokenSource).RemoveAt(0);
				}
				CardInfoUI levelText3 = (CardInfoUI)(object)cardInfoUI15.LevelText;
				bool flag65 = (object)cardInfoUI15.LevelText == null;
				bool flag66 = ((UnityEngine.Object)levelText3).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)levelText3).m_CachedPtr, false);
				list9 = list19;
			}
			bool flag67 = obj12 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5583 @ stack_-130_v38+1C]");
			bool flag68 = obj13 != null;
			bool flag69 = ((Exception)(object)cardInfoUI2)._className == null;
			IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)((Exception)(object)cardInfoUI2)._className);
			GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
			LayoutGroup[] componentsInChildren = gameObject4.GetComponentsInChildren<LayoutGroup>(includeInactive: true);
			CardInfoUI cardInfoUI16 = cardInfoUI4;
			while ((nint)cardInfoUI16 < componentsInChildren.Length)
			{
				bool flag70 = (nint)cardInfoUI4 >= componentsInChildren.Length;
				RectTransform component = componentsInChildren[(object)cardInfoUI4].GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component);
				cardInfoUI4 = (CardInfoUI)(cardInfoUI4 + 1);
				cardInfoUI16 = cardInfoUI4;
			}
			RectTransform component2 = gameObject4.GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
			return;
		}
		goto IL_1bbb;
		IL_1d98:
		bool flag71 = string.IsNullOrWhiteSpace(value);
		object obj20 = (flag71 ? 1 : 0) ^ 1;
		if (list6 != null)
		{
			int size = list6._size;
			if (list3 != null && list5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r12_v90 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				object obj21 = (nint)0 + (nint)list6._size;
				object obj22 = obj21 + list5._size;
				obj9 = obj22 + obj20;
				list7 = (((nint)obj9 >= 5) ? cardInfoUI2._twoColumnEntries : cardInfoUI2._oneColumnEntries);
				if (cardInfoUI2._dataManager != null)
				{
					convertedPowerUpData = cardInfoUI2._dataManager.GetConvertedPowerUpData();
					if (cardInfoUI2._oneColumnEntries != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4326 @ rax_v222+10]");
						CardInfoUI cardInfoUI17 = (CardInfoUI)0;
						List<CardEntry>.Enumerator enumerator6 = default(List<CardEntry>.Enumerator);
						Vector3 vector = default(Vector3);
						while (enumerator6.MoveNext())
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4326 @ rax_v222+10]");
							bool flag72 = (nint)0 == 0;
							List<Tuple<PowerUpType, float>>.Enumerator enumerator2 = (List<Tuple<PowerUpType, float>>.Enumerator)(&enumerator6);
							if (!flag72)
							{
								if (((UnityEngine.Object)cardInfoUI17).m_CachedPtr != (IntPtr)0)
								{
									((GameObject)(nint)((UnityEngine.Object)cardInfoUI17).m_CachedPtr).SetActive(value: false);
									if (((MonoBehaviour)cardInfoUI17).m_CancellationTokenSource != null)
									{
										GameObject gameObject5 = ((Component)(object)((MonoBehaviour)cardInfoUI17).m_CancellationTokenSource).gameObject;
										if ((object)gameObject5 != null)
										{
											gameObject5.SetActive(value: true);
											if (((UnityEngine.Object)cardInfoUI17).m_CachedPtr != (IntPtr)0)
											{
												Transform transform = ((GameObject)(nint)((UnityEngine.Object)cardInfoUI17).m_CachedPtr).transform;
												if ((object)transform != null)
												{
													transform.localScale = (Vector3)(&vector);
													size = 0;
													continue;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						if (cardInfoUI2._twoColumnEntries != null)
						{
							List<CardEntry>.Enumerator enumerator7 = default(List<CardEntry>.Enumerator);
							Vector3 value2 = default(Vector3);
							while (enumerator7.MoveNext())
							{
								CardInfoUI cardInfoUI18 = null;
								bool flag73 = ((UnityEngine.Object)cardInfoUI18).m_CachedPtr == (IntPtr)0;
								((GameObject)(nint)((UnityEngine.Object)cardInfoUI18).m_CachedPtr).SetActive(value: false);
								bool flag74 = ((MonoBehaviour)cardInfoUI18).m_CancellationTokenSource == null;
								GameObject gameObject6 = ((Component)(object)((MonoBehaviour)cardInfoUI18).m_CancellationTokenSource).gameObject;
								bool flag75 = (object)gameObject6 == null;
								gameObject6.SetActive(value: true);
								bool flag76 = ((UnityEngine.Object)cardInfoUI18).m_CachedPtr == (IntPtr)0;
								Transform transform2 = ((GameObject)(nint)((UnityEngine.Object)cardInfoUI18).m_CachedPtr).transform;
								bool flag77 = (object)transform2 == null;
								bool flag78 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
								size = 0;
							}
							nint num6 = (nint)cardInfoUI2.Title;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object arg2 = default(object);
							paramsArray2 = new System.ParamsArray(arg2);
							string term = string.FormatHelper((IFormatProvider)null, "arcanaLang/{{{0}}}name", (System.ParamsArray)(&paramsArray3));
							string translation2 = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, gameObject, text, flag6);
							if ((object)cardInfoUI2.Title != null)
							{
								object obj23 = num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v5544 @ r8_v102+558] (should have been resolved before IL gen)");
								if (card.AccumulatedLevels <= 1)
								{
									if ((object)LevelText != null)
									{
										GameObject gameObject7 = LevelText.gameObject;
										if ((object)gameObject7 != null)
										{
											gameObject7.SetActive(value: false);
											goto IL_1eea;
										}
									}
								}
								else if ((object)LevelText != null)
								{
									GameObject gameObject8 = LevelText.gameObject;
									if ((object)gameObject8 != null)
									{
										gameObject8.SetActive(value: true);
										string translation3 = LocalizationManager.GetTranslation("lang/ingame_level", FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, gameObject, text, flag6);
										int num7 = card + 24;
										string newValue = ((int*)num7)->ToString();
										if (translation3 != null)
										{
											string text7 = translation3.Replace("%0", newValue);
											if ((object)cardInfoUI2.LevelText != null)
											{
												cardInfoUI2.LevelText.text = text7;
												TextMeshProUGUI levelText4 = cardInfoUI2.LevelText;
												if ((object)cardInfoUI2.LevelText != null)
												{
													if (((TMP_Text)levelText4).m_HorizontalAlignment != HorizontalAlignmentOptions.Right || ((TMP_Text)levelText4).m_VerticalAlignment != VerticalAlignmentOptions.Geometry)
													{
														((TMP_Text)levelText4).m_HorizontalAlignment = HorizontalAlignmentOptions.Right;
														((TMP_Text)levelText4).m_VerticalAlignment = VerticalAlignmentOptions.Geometry;
														((TMP_Text)levelText4).m_havePropertiesChanged = true;
														cardInfoUI2.LevelText.SetVerticesDirty();
													}
													goto IL_1eea;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1bbb;
		IL_1eea:
		if (card.Edition == SkillCardEdition.Base)
		{
			if ((object)Edition != null)
			{
				GameObject gameObject9 = Edition.gameObject;
				if ((object)gameObject9 != null)
				{
					gameObject9.SetActive(value: false);
					goto IL_0d4d;
				}
			}
		}
		else if ((object)Edition != null)
		{
			GameObject gameObject10 = Edition.gameObject;
			if ((object)gameObject10 != null)
			{
				gameObject10.SetActive(value: true);
				IntPtr intPtr = default(IntPtr);
				string text8 = ((Enum)(&intPtr)).ToString();
				if (text8 != null)
				{
					string spriteName = text8.ToUpper();
					Sprite sprite4 = SpriteManager.GetSprite(spriteName, "randomazzo");
					if ((object)cardInfoUI2.Edition != null)
					{
						cardInfoUI2.Edition.sprite = sprite4;
						goto IL_0d4d;
					}
				}
			}
		}
		goto IL_1bbb;
		IL_0632:
		text2 = "";
		value = "";
		flag10 = flag8;
		goto IL_1d98;
	}

	public static void RefreshLayoutGroupsImmediateAndRecursive(GameObject root)
	{
		//IL_0020: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		LayoutGroup[] componentsInChildren = root.GetComponentsInChildren<LayoutGroup>(includeInactive: true);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < componentsInChildren.Length)
		{
			RectTransform component = componentsInChildren[obj].GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			obj++;
			obj2 = obj;
		}
		RectTransform component2 = root.GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
	}

	private unsafe string ReplaceDescriptionTextPlaceholder(string descriptionTextString, EveryXDataHolder stat, bool addStatsText)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected I4, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2B8D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (stat != null)
		{
			string textForEntry = GetTextForEntry(stat.Type, stat.Value, addStatsText);
			if (descriptionTextString != null)
			{
				string text = descriptionTextString.Replace("%0", textForEntry);
				int num = stat + 24;
				string newValue = ((int*)num)->ToString();
				if (text != null)
				{
					string text2 = text.Replace("%1", newValue);
					int num2 = stat + 28;
					string newValue2 = ((int*)num2)->ToString();
					if (text2 != null)
					{
						return text2.Replace("%2", newValue2);
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetTextForEntry(PowerUpType powerUpType, float value, bool addStatText = true)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_01b3: Expected I4, but got O
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01d9: Expected native int or pointer, but got O
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0227: Invalid comparison between F4 and I4
		//IL_026f: Invalid comparison between F4 and I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_011f: Expected O, but got I4
		//IL_0173: Expected O, but got I8
		//IL_018d: Expected O, but got I8
		//IL_0161: Expected O, but got I4
		object obj2 = default(object);
		object obj = obj2 - 87;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		int num2 = default(int);
		while (true)
		{
			object obj3 = obj + 119;
			object arg = (PowerUpType)obj3;
			System.ParamsArray paramsArray = (System.ParamsArray)(obj - 33);
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
			System.ParamsArray args = (System.ParamsArray)(obj - 1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-21]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-11]");
			_ = 0;
			string term = string.FormatHelper((IFormatProvider)null, "powerUpLang/{{{0}}}name", args);
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2B8F]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag = !(value > 0f);
			string text = "";
			if (!flag)
			{
				text = "+";
			}
			string text2 = text + "{0}{1} " + translation;
			string text3 = "{0}{1} ";
			string text4 = translation;
			if (!addStatText)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2B8F]");
				if ((nint)0 == (addStatText ? 1 : 0))
				{
					_ = 1;
				}
				bool flag2 = !(value > 0f);
				text = "";
				if (!flag2)
				{
					text = "+";
				}
				string text5 = text + "{0}{1}";
				text3 = "{0}{1}";
				text4 = null;
			}
			float num = value * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			_ = 0;
			ReadOnlySpan<char> format = (ReadOnlySpan<char>)(obj - 33);
			string text6 = System.Number.FormatInt32(num2, format, null);
			bool flag3 = num2 != 0;
			object obj4 = 0;
			if (!flag3)
			{
				float value2 = value * 100f;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				text6 = System.Number.FormatSingle(value2, "F1", currentInfo);
				obj4 = 0;
			}
			if (powerUpType > PowerUpType.RECYCLE)
			{
				break;
			}
			object obj5 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ r8_v8+6B9D2BC+powerUpType @ rdx (VampireSurvivors.Data.PowerUpType)*4]");
			object obj6 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v370 @ rcx_v17 (should have been resolved before IL gen)");
		}
		return "";
	}

	private string GetSign(float value)
	{
		//IL_004a: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2B8F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !(value > 0f);
		string result = "";
		if (!flag)
		{
			result = "+";
		}
		return result;
	}

	private List<Tuple<PowerUpType, float>> GetPowerUpTypesFromModifierStats(ModifierStats stats)
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_0080: Invalid comparison between F4 and I4
		//IL_00ed: Invalid comparison between F4 and I4
		//IL_015a: Invalid comparison between F4 and I4
		//IL_022a: Invalid comparison between F4 and I4
		//IL_0297: Invalid comparison between F4 and I4
		//IL_0304: Invalid comparison between F4 and I4
		//IL_0371: Invalid comparison between F4 and I4
		//IL_03de: Invalid comparison between F4 and I4
		//IL_044b: Invalid comparison between F4 and I4
		//IL_04b8: Invalid comparison between F4 and I4
		//IL_0525: Invalid comparison between F4 and I4
		//IL_0592: Invalid comparison between F4 and I4
		//IL_05ff: Invalid comparison between F4 and I4
		//IL_066c: Invalid comparison between F4 and I4
		//IL_06d9: Invalid comparison between F4 and I4
		//IL_0746: Invalid comparison between F4 and I4
		//IL_07b3: Invalid comparison between F4 and I4
		//IL_0883: Invalid comparison between F4 and I4
		//IL_08f0: Invalid comparison between F4 and I4
		//IL_095d: Invalid comparison between F4 and I4
		//IL_09ca: Invalid comparison between F4 and I4
		List<Tuple<PowerUpType, float>> list = new List<Tuple<PowerUpType, float>>();
		if (stats != null)
		{
			bool flag = stats._003CAmount_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D452h\"");
			if (!flag)
			{
				Tuple<PowerUpType, float> tuple = null;
				_ = stats._003CAmount_003Ek__BackingField;
				_ = 8;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag2 = stats._003CArea_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D48Dh\"");
			if (!flag2)
			{
				Tuple<PowerUpType, float> tuple2 = null;
				_ = stats._003CArea_003Ek__BackingField;
				_ = 4;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag3 = stats._003CArmor_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D4C8h\"");
			if (!flag3)
			{
				Tuple<PowerUpType, float> tuple3 = null;
				_ = stats._003CArmor_003Ek__BackingField;
				_ = 3;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag4 = stats._003CBanish_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D503h\"");
			if (!flag4)
			{
				Tuple<PowerUpType, float> tuple4 = null;
				_ = stats._003CBanish_003Ek__BackingField;
				_ = 22;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			if (stats._003CCharm_003Ek__BackingField != 0)
			{
				Tuple<PowerUpType, float> tuple5 = null;
				_ = 25;
				_ = stats._003CCharm_003Ek__BackingField;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag5 = stats._003CCooldown_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D584h\"");
			if (!flag5)
			{
				Tuple<PowerUpType, float> tuple6 = null;
				_ = stats._003CCooldown_003Ek__BackingField;
				_ = 6;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag6 = stats._003CCurse_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D5BFh\"");
			if (!flag6)
			{
				Tuple<PowerUpType, float> tuple7 = null;
				_ = stats._003CCurse_003Ek__BackingField;
				_ = 14;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag7 = stats._003CDefang_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D5FAh\"");
			if (!flag7)
			{
				Tuple<PowerUpType, float> tuple8 = null;
				_ = stats._003CDefang_003Ek__BackingField;
				_ = 27;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag8 = stats._003CDuration_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D635h\"");
			if (!flag8)
			{
				Tuple<PowerUpType, float> tuple9 = null;
				_ = stats._003CDuration_003Ek__BackingField;
				_ = 7;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag9 = stats._003CGreed_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D670h\"");
			if (!flag9)
			{
				Tuple<PowerUpType, float> tuple10 = null;
				_ = stats._003CGreed_003Ek__BackingField;
				_ = 13;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag10 = stats._003CGrowth_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D6ABh\"");
			if (!flag10)
			{
				Tuple<PowerUpType, float> tuple11 = null;
				_ = stats._003CGrowth_003Ek__BackingField;
				_ = 12;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag11 = stats._003CInvulTimeBonus_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D6E6h\"");
			if (!flag11)
			{
				Tuple<PowerUpType, float> tuple12 = null;
				_ = stats._003CInvulTimeBonus_003Ek__BackingField;
				_ = 19;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag12 = stats._003CLuck_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D721h\"");
			if (!flag12)
			{
				Tuple<PowerUpType, float> tuple13 = null;
				_ = stats._003CLuck_003Ek__BackingField;
				_ = 11;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag13 = stats._003CMaxHp_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D75Ch\"");
			if (!flag13)
			{
				Tuple<PowerUpType, float> tuple14 = null;
				_ = stats._003CMaxHp_003Ek__BackingField;
				_ = 2;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag14 = stats._003CMagnet_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D797h\"");
			if (!flag14)
			{
				Tuple<PowerUpType, float> tuple15 = null;
				_ = stats._003CMagnet_003Ek__BackingField;
				_ = 10;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag15 = stats._003CMoveSpeed_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D7D2h\"");
			if (!flag15)
			{
				Tuple<PowerUpType, float> tuple16 = null;
				_ = stats._003CMoveSpeed_003Ek__BackingField;
				_ = 9;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag16 = stats._003CPower_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D80Dh\"");
			if (!flag16)
			{
				Tuple<PowerUpType, float> tuple17 = null;
				_ = stats._003CPower_003Ek__BackingField;
				_ = 0;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag17 = stats._003CRegen_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D848h\"");
			if (!flag17)
			{
				Tuple<PowerUpType, float> tuple18 = null;
				_ = stats._003CRegen_003Ek__BackingField;
				_ = 1;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag18 = stats._003CReRolls_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D883h\"");
			if (!flag18)
			{
				Tuple<PowerUpType, float> tuple19 = null;
				_ = stats._003CReRolls_003Ek__BackingField;
				_ = 20;
				flag18 = list == null;
				if (flag18)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D8C2h\"");
			if (!flag18)
			{
				Tuple<PowerUpType, float> tuple20 = null;
				_ = 17;
				_ = stats._003CRevivals_003Ek__BackingField;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag19 = stats._003CSpeed_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D901h\"");
			if (!flag19)
			{
				Tuple<PowerUpType, float> tuple21 = null;
				_ = stats._003CSpeed_003Ek__BackingField;
				_ = 5;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag20 = stats._003CShields_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D93Ch\"");
			if (!flag20)
			{
				Tuple<PowerUpType, float> tuple22 = null;
				_ = stats._003CShields_003Ek__BackingField;
				_ = 16;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag21 = stats._003CSkips_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D977h\"");
			if (!flag21)
			{
				Tuple<PowerUpType, float> tuple23 = null;
				_ = stats._003CSkips_003Ek__BackingField;
				_ = 21;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
			bool flag22 = stats._003CRecycle_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B9D9B1h\"");
			if (!flag22)
			{
				Tuple<PowerUpType, float> tuple24 = null;
				_ = stats._003CRecycle_003Ek__BackingField;
				_ = 30;
				if (list == null)
				{
					goto IL_0a2e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A650");
			}
		}
		return list;
		IL_0a2e:
		return (List<Tuple<PowerUpType, float>>)(object)new NullReferenceException();
	}

	public static Sprite GetSubSkillIcon(ArcanaType? type)
	{
		bool flag = (object)type == null;
		object obj = "Skillicon_Special";
		if (!flag)
		{
			object obj2 = default(object);
			if ((nint)obj2 < 9000)
			{
				if ((nint)obj2 < 8000)
				{
					if ((nint)obj2 < 7000)
					{
						if ((nint)obj2 < 6000)
						{
							if ((nint)obj2 < 5000)
							{
								bool flag2 = (nint)obj2 >= 4000;
								obj = "Skillicon_Special";
								if (!flag2)
								{
									if ((nint)obj2 < 3000)
									{
										if ((nint)obj2 < 2000)
										{
											if ((nint)obj2 < 1200)
											{
												if ((nint)obj2 < 1100)
												{
													bool flag3 = (nint)obj2 < 1000;
													obj = "Skillicon_Special";
													if (!flag3)
													{
														obj = "SkillIcon_Weapon";
													}
												}
												else
												{
													obj = "SkillIcon_EveryLevel";
												}
											}
											else
											{
												obj = "SkillIcon_Skip";
											}
										}
										else
										{
											obj = "SkillIcon_OnRevive";
										}
									}
									else
									{
										obj = "SkillIcon_OnDamaged";
									}
								}
							}
							else
							{
								obj = "SkillIcon_Enemycount";
							}
						}
						else
						{
							obj = "SkillIcon_HPCritical";
						}
					}
					else
					{
						obj = "SkillIcon_Overheal";
					}
				}
				else
				{
					obj = "SkillIcon_Goldcount";
				}
			}
			else
			{
				obj = "SkillIcon_Familiar";
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite result = default(Sprite);
		return result;
	}

	public CardInfoUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
