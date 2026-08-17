using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class PlayerStatsNew
{
	public Dictionary<EStat, float> stats;

	public Dictionary<EStat, float> rawStats;

	public Dictionary<EStat, StatComponents> statValuesMap;

	private PlayerInventory playerInventory;

	public static Action<EStat> A_StatUpdate;

	private HashSet<EStat> queuedUpdateStats;

	private Dictionary<EStat, HashSet<EShopItem>> statToShopItems;

	private bool ignoreShopItems;

	private readonly List<EStat> statsToUpdateBuffer;

	public unsafe PlayerStatsNew(PlayerInventory inventory, bool ignoreShopItems = false)
	{
		//IL_0d70: Expected O, but got I4
		//IL_015a: Expected O, but got Ref
		//IL_0162: Expected O, but got Ref
		//IL_0547: Expected O, but got I4
		//IL_01c5: Expected O, but got I4
		//IL_0275: Expected O, but got I4
		//IL_0296: Expected I, but got O
		//IL_029e: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_05eb: Expected O, but got Ref
		//IL_05f3: Expected O, but got Ref
		//IL_0f69: Expected O, but got Ref
		//IL_02c2: Expected I, but got O
		//IL_02ca: Expected I, but got O
		//IL_02f9: Expected I, but got O
		//IL_0307: Expected I, but got O
		//IL_030f: Expected O, but got I4
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_0618: Expected I, but got O
		//IL_034a: Expected I4, but got O
		//IL_069b: Expected I, but got O
		//IL_0372: Expected I, but got O
		//IL_0380: Expected I, but got O
		//IL_03a9: Expected I4, but got O
		//IL_03bc: Expected I4, but got O
		//IL_06e3: Expected I, but got O
		//IL_06fb: Expected O, but got Ref
		//IL_03f4: Expected I, but got O
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_0711: Expected I, but got O
		//IL_0423: Expected I4, but got O
		//IL_0932: Expected I, but got O
		//IL_0937: Expected I, but got O
		//IL_046b: Expected I, but got O
		//IL_07c7: Expected I, but got O
		//IL_07df: Expected O, but got Ref
		//IL_0982: Expected I, but got O
		//IL_0987: Expected I, but got O
		//IL_049a: Expected I4, but got O
		//IL_07fb: Expected I, but got O
		//IL_0803: Expected I, but got O
		//IL_0832: Expected I, but got O
		//IL_0840: Expected I, but got O
		//IL_0858: Expected O, but got Ref
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_0e8c: Expected I, but got O
		//IL_0a21: Expected I, but got O
		//IL_0a26: Expected I, but got O
		//IL_087a: Expected I4, but got O
		//IL_050b: Expected I4, but got O
		//IL_0884: Expected I, but got O
		//IL_0892: Expected I, but got O
		//IL_0a71: Expected I, but got O
		//IL_0a76: Expected I, but got O
		//IL_0b10: Expected I, but got O
		//IL_0b15: Expected I, but got O
		//IL_0b60: Expected I, but got O
		//IL_0b65: Expected I, but got O
		//IL_0bff: Expected I, but got O
		//IL_0c04: Expected I, but got O
		//IL_0c4f: Expected I, but got O
		//IL_0c54: Expected I, but got O
		//IL_0cee: Expected I, but got O
		//IL_0cf3: Expected I, but got O
		//IL_0d3e: Expected I, but got O
		//IL_0d43: Expected I, but got O
		Dictionary<EStat, float> dictionary = new Dictionary<EStat, float>();
		rawStats = dictionary;
		Dictionary<EStat, StatComponents> dictionary2 = new Dictionary<EStat, StatComponents>();
		statValuesMap = dictionary2;
		HashSet<EStat> hashSet = (HashSet<EStat>)(object)new HashSet<System.Int32Enum>();
		queuedUpdateStats = hashSet;
		List<EStat> list = new List<EStat>();
		statsToUpdateBuffer = list;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		bool flag = default(bool);
		this.ignoreShopItems = flag;
		this.playerInventory = inventory;
		Dictionary<EStat, float> dictionary3 = new Dictionary<EStat, float>();
		stats = dictionary3;
		Dictionary<EStat, float> dictionary4 = new Dictionary<EStat, float>();
		rawStats = dictionary4;
		Dictionary<EStat, StatComponents> dictionary5 = new Dictionary<EStat, StatComponents>();
		statValuesMap = dictionary5;
		Dictionary<EStat, HashSet<EShopItem>> dictionary6 = new Dictionary<EStat, HashSet<EShopItem>>();
		statToShopItems = dictionary6;
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EStat));
		Array values = Enum.GetValues(typeFromHandle);
		bool flag2 = values == null;
		Type type = typeFromHandle;
		Type type2 = typeFromHandle;
		PlayerInventory playerInventory = inventory;
		nint num4 = default(nint);
		object obj7;
		nint num10;
		StatComponents statComponents2;
		if (!flag2)
		{
			IEnumerator enumerator = values.GetEnumerator();
			bool flag3 = default(bool);
			object obj = (object)(&flag3);
			object obj3 = default(object);
			object obj2 = (object)(&obj3);
			type = typeFromHandle;
			Array array = values;
			playerInventory = inventory;
			object obj4 = default(object);
			object obj6 = default(object);
			float num9 = default(float);
			while (true)
			{
				bool flag4 = !flag3;
				nint num = (flag3 ? 1 : 0);
				nint num3;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if (obj4 == null)
					{
						break;
					}
					bool flag5 = !flag3;
					num = (flag3 ? 1 : 0);
					type = (Type)flag3;
					array = null;
					if (!flag5)
					{
						nint num2 = (flag3 ? 1 : 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v28 (Il2CppClass<System.Type>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0254;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v28 (Il2CppClass<System.Type>)+B0]");
						num3 = 0;
						Action<EStat> action = null;
						while (true)
						{
							object obj5 = action + action;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ r8_v19 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+v801 @ rax_v187*8]");
							if (0 != (nint)typeof(IEnumerator))
							{
								action = (Action<EStat>)(action + 1);
								Action<EStat> action2 = action;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v28 (Il2CppClass<System.Type>)+12E]");
								if ((nint)action2 < 0)
								{
									continue;
								}
								goto IL_0254;
							}
							break;
						}
						goto IL_026c;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0254:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
				num3 = 1;
				goto IL_026c;
				IL_026c:
				object current = ((IEnumerator)flag3).Current;
				bool flag6 = current == null;
				num4 = (nint)typeof(IEnumerator);
				type = (Type)flag3;
				array = (Array)flag3;
				if (!flag6)
				{
					nint num5 = (nint)typeof(EStat);
					nint num6 = (nint)current;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rdx_v117 (Il2CppClass<System.Object>)+40]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r8_v52 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+40]");
					bool flag7 = num7 != 0;
					num3 = (nint)typeof(EStat);
					nint num8 = (nint)typeof(IEnumerator);
					type = (Type)flag3;
					HashSet<System.Int32Enum> hashSet2 = (HashSet<System.Int32Enum>)current;
					if (!flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						type = (Type)obj6;
						playerInventory = (PlayerInventory)(object)stats;
						float baseValue = GetBaseValue((EStat)obj6);
						bool flag8 = stats == null;
						num3 = (nint)typeof(EStat);
						num8 = (nint)typeof(IEnumerator);
						hashSet2 = (HashSet<System.Int32Enum>)obj6;
						if (!flag8)
						{
							((Dictionary<System.Int32Enum, float>)(object)stats).Add((System.Int32Enum)obj6, baseValue);
							playerInventory = (PlayerInventory)(object)rawStats;
							float baseValue2 = GetBaseValue((EStat)obj6);
							bool flag9 = rawStats == null;
							num9 = baseValue;
							baseValue = baseValue2;
							num3 = (nint)typeof(EStat);
							num8 = 0;
							hashSet2 = (HashSet<System.Int32Enum>)obj6;
							if (!flag9)
							{
								((Dictionary<System.Int32Enum, float>)(object)rawStats).Add((System.Int32Enum)obj6, baseValue2);
								playerInventory = (PlayerInventory)(object)statToShopItems;
								HashSet<EShopItem> hashSet3 = (HashSet<EShopItem>)(object)new HashSet<System.Int32Enum>();
								bool flag10 = statToShopItems == null;
								num9 = baseValue2;
								baseValue = baseValue2;
								num3 = (nint)typeof(EStat);
								num8 = 0;
								hashSet2 = (HashSet<System.Int32Enum>)(object)hashSet3;
								if (!flag10)
								{
									((Dictionary<System.Int32Enum, object>)(object)statToShopItems).set_Item((System.Int32Enum)obj6, (object)hashSet3);
									playerInventory = (PlayerInventory)(object)statValuesMap;
									StatComponents statComponents = new StatComponents();
									bool flag11 = statValuesMap == null;
									num9 = baseValue2;
									baseValue = baseValue2;
									obj7 = hashSet3;
									num10 = 0;
									statComponents2 = statComponents;
									if (!flag11)
									{
										((Dictionary<System.Int32Enum, object>)(object)statValuesMap).set_Item((System.Int32Enum)obj6, (object)statComponents);
										num9 = baseValue2;
										baseValue = baseValue2;
										num4 = 0;
										array = (Array)(object)statValuesMap;
										continue;
									}
									num3 = (nint)obj7;
									num8 = num10;
									hashSet2 = (HashSet<System.Int32Enum>)(object)statComponents2;
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					((Dictionary<EStat, float>)(object)hashSet2).Add((EStat)num3, num9);
					num4 = num8;
					array = (Array)(object)hashSet2;
				}
				num = num3;
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			bool flag12 = default(bool);
			obj2 = flag12;
			bool flag13 = !flag12;
			flag = flag3;
			if (!flag13)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				flag = flag12;
			}
			Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EStat));
			Array values2 = Enum.GetValues(typeFromHandle2);
			bool flag14 = values2 == null;
			type = typeFromHandle2;
			type2 = typeFromHandle2;
			if (!flag14)
			{
				IEnumerator enumerator2 = values2.GetEnumerator();
				Type type3 = default(Type);
				object obj8 = (object)(&type3);
				PlayerInventory playerInventory2 = (PlayerInventory)(&obj3);
				nint num = (flag ? 1 : 0);
				nint num11 = num4;
				array = values2;
				object obj11 = default(object);
				object obj12 = default(object);
				while (true)
				{
					bool flag15 = (object)type3 == null;
					type = type3;
					playerInventory = (PlayerInventory)(&obj3);
					if (!flag15)
					{
						nint num12 = (nint)type3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r10_v26 (Il2CppClass<System.Type>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_068c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r10_v26 (Il2CppClass<System.Type>)+B0]");
						num = 0;
						Action<EStat> action3 = null;
						while (true)
						{
							object obj9 = action3 + action3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1763 @ r8_v10 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+v1202 @ rax_v164*8]");
							if (0 != (nint)typeof(IEnumerator))
							{
								action3 = (Action<EStat>)(action3 + 1);
								Action<EStat> action4 = action3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r10_v26 (Il2CppClass<System.Type>)+12E]");
								if ((nint)action4 < 0)
								{
									continue;
								}
								goto IL_068c;
							}
							break;
						}
						goto IL_06a0;
					}
					throw new NullReferenceException();
					IL_06a0:
					if (((IEnumerator)type3).MoveNext())
					{
						bool flag16 = (object)type3 == null;
						num11 = (nint)typeof(IEnumerator);
						type = type3;
						array = (Array)(object)type3;
						playerInventory = (PlayerInventory)(&obj3);
						if (!flag16)
						{
							nint num13 = (nint)type3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ r10_v27 (Il2CppClass<System.Type>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0785;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ r10_v27 (Il2CppClass<System.Type>)+B0]");
							num = 0;
							Action<EStat> action5 = null;
							while (true)
							{
								object obj10 = action5 + action5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1763 @ r8_v10 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+v1416 @ rax_v153*8]");
								if (0 != (nint)typeof(IEnumerator))
								{
									action5 = (Action<EStat>)(action5 + 1);
									Action<EStat> action6 = action5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ r10_v27 (Il2CppClass<System.Type>)+12E]");
									if ((nint)action6 < 0)
									{
										continue;
									}
									goto IL_0785;
								}
								break;
							}
							goto IL_079d;
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					playerInventory2 = (PlayerInventory)obj11;
					if (obj11 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					break;
					IL_079d:
					object current2 = ((IEnumerator)type3).Current;
					bool flag17 = current2 == null;
					num11 = (nint)typeof(IEnumerator);
					type = type3;
					array = (Array)(object)type3;
					playerInventory = (PlayerInventory)(&obj3);
					if (!flag17)
					{
						nint num14 = (nint)typeof(EStat);
						nint num15 = (nint)current2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rdx_v109 (Il2CppClass<System.Object>)+40]");
						nint num16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ r8_v42 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+40]");
						bool flag18 = num16 != 0;
						num = (nint)typeof(EStat);
						num11 = (nint)typeof(IEnumerator);
						type = type3;
						array = (Array)current2;
						playerInventory = (PlayerInventory)(&obj3);
						if (!flag18)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							UpdateStat((EStat)obj12);
							num = unchecked((nint)null);
							num11 = (nint)typeof(IEnumerator);
							array = (Array)(object)this;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					}
					throw new NullReferenceException();
					IL_0785:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					num = 1;
					goto IL_079d;
					IL_068c:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					num = unchecked((nint)null);
					goto IL_06a0;
				}
				Action<EStat> b = QueueUpdateStat;
				Delegate obj13 = Delegate.Combine(PlayerStatusEffects.A_StatusModifiedStat, b);
				if ((object)obj13 == null)
				{
					PlayerStatusEffects.A_StatusModifiedStat = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<EStat> action7 = default(Action<EStat>);
					bool flag19 = action7 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj13;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (flag19)
					{
						goto IL_0f9f;
					}
					PlayerStatusEffects.A_StatusModifiedStat = action7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj14 = default(object);
					bool flag20 = obj14 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj13;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (flag20)
					{
						goto IL_0faa;
					}
				}
				Action<ETome, EStat> b2 = QueueUpdateStatTome;
				Delegate obj15 = Delegate.Combine(TomeInventory.A_TomeUpgrade, b2);
				if ((object)obj15 == null)
				{
					TomeInventory.A_TomeUpgrade = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<ETome, EStat> action8 = default(Action<ETome, EStat>);
					bool flag21 = action8 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj15;
					playerInventory = (PlayerInventory)(object)typeof(Action<ETome, EStat>);
					if (flag21)
					{
						goto IL_0fba;
					}
					TomeInventory.A_TomeUpgrade = action8;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj16 = default(object);
					bool flag22 = obj16 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj15;
					playerInventory = (PlayerInventory)(object)typeof(Action<ETome, EStat>);
					if (flag22)
					{
						goto IL_0fca;
					}
				}
				Action<EStat> b3 = QueueUpdateStat;
				Delegate obj17 = Delegate.Combine(StatInventory.A_StatsChanged, b3);
				if ((object)obj17 == null)
				{
					StatInventory.A_StatsChanged = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<EStat> action9 = default(Action<EStat>);
					bool flag23 = action9 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj17;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (flag23)
					{
						goto IL_0fda;
					}
					StatInventory.A_StatsChanged = action9;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj18 = default(object);
					bool flag24 = obj18 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj17;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (flag24)
					{
						goto IL_0fea;
					}
				}
				Action<EStat> b4 = QueueUpdateStat;
				Delegate obj19 = Delegate.Combine(ItemInventory.A_StatsChanged, b4);
				if ((object)obj19 == null)
				{
					ItemInventory.A_StatsChanged = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<EStat> action10 = default(Action<EStat>);
					bool flag25 = action10 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj19;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (flag25)
					{
						goto IL_0ffa;
					}
					ItemInventory.A_StatsChanged = action10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj20 = default(object);
					bool flag26 = obj20 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj19;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (flag26)
					{
						goto IL_100a;
					}
				}
				Action<EStat> b5 = QueueUpdateStat;
				Delegate obj21 = Delegate.Combine(PassiveAbility.A_StatModified, b5);
				if ((object)obj21 == null)
				{
					PassiveAbility.A_StatModified = null;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EStat> action11 = default(Action<EStat>);
				bool flag27 = action11 == null;
				num = unchecked((nint)null);
				num11 = unchecked((nint)null);
				type = (Type)(object)obj21;
				playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
				if (!flag27)
				{
					PassiveAbility.A_StatModified = action11;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj22 = default(object);
					bool flag28 = obj22 == null;
					num = unchecked((nint)null);
					num11 = unchecked((nint)null);
					type = (Type)(object)obj21;
					playerInventory = (PlayerInventory)(object)typeof(Action<EStat>);
					if (!flag28)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				goto IL_100a;
			}
		}
		obj7 = flag;
		num10 = num4;
		statComponents2 = (StatComponents)(object)type2;
		throw new NullReferenceException();
		IL_0fda:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0fca;
		IL_100a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0ffa;
		IL_0ffa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0fea;
		IL_0faa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0f9f;
		IL_0f9f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0fea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0fda;
		IL_0fca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0fba;
		IL_0fba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0faa;
	}

	public void OnDestroy()
	{
		//IL_04c5: Expected I, but got O
		//IL_04d6: Expected O, but got I4
		//IL_04df: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_012e: Expected I, but got O
		//IL_013f: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_0197: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_023e: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		//IL_0285: Expected I, but got O
		//IL_0296: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_032c: Expected I, but got O
		//IL_033d: Expected O, but got I4
		//IL_0346: Expected O, but got I4
		//IL_0384: Expected I, but got O
		//IL_0395: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		//IL_042b: Expected I, but got O
		//IL_043c: Expected O, but got I4
		//IL_0445: Expected O, but got I4
		//IL_0483: Expected I, but got O
		//IL_0494: Expected O, but got I4
		//IL_049d: Expected O, but got I4
		Action<EStat> value = QueueUpdateStat;
		Delegate obj = Delegate.Remove(PlayerStatusEffects.A_StatusModifiedStat, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusModifiedStat = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action = default(Action<EStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStat>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_058f;
			}
			PlayerStatusEffects.A_StatusModifiedStat = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStat>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_050c;
			}
		}
		Action<ETome, EStat> value2 = QueueUpdateStatTome;
		Delegate obj6 = Delegate.Remove(TomeInventory.A_TomeUpgrade, value2);
		if ((object)obj6 == null)
		{
			TomeInventory.A_TomeUpgrade = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ETome, EStat> action2 = default(Action<ETome, EStat>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<ETome, EStat>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_0517;
			}
			TomeInventory.A_TomeUpgrade = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<ETome, EStat>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0527;
			}
		}
		Action<EStat> value3 = QueueUpdateStat;
		Delegate obj8 = Delegate.Remove(StatInventory.A_StatsChanged, value3);
		if ((object)obj8 == null)
		{
			StatInventory.A_StatsChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action3 = default(Action<EStat>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<EStat>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_0537;
			}
			StatInventory.A_StatsChanged = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<EStat>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag5)
			{
				goto IL_0547;
			}
		}
		Action<EStat> value4 = QueueUpdateStat;
		Delegate obj10 = Delegate.Remove(ItemInventory.A_StatsChanged, value4);
		if ((object)obj10 == null)
		{
			ItemInventory.A_StatsChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action4 = default(Action<EStat>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<EStat>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = 0;
			if (flag6)
			{
				goto IL_055f;
			}
			ItemInventory.A_StatsChanged = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<EStat>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = 0;
			if (flag7)
			{
				goto IL_056f;
			}
		}
		Action<EStat> value5 = QueueUpdateStat;
		Delegate obj12 = Delegate.Remove(PassiveAbility.A_StatModified, value5);
		if ((object)obj12 == null)
		{
			PassiveAbility.A_StatModified = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat> action5 = default(Action<EStat>);
		bool flag8 = action5 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj12;
		obj3 = 0;
		obj4 = 0;
		if (flag8)
		{
			goto IL_057f;
		}
		PassiveAbility.A_StatModified = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag9 = obj13 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj12;
		obj3 = 0;
		obj4 = 0;
		if (!flag9)
		{
			return;
		}
		goto IL_058f;
		IL_058f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_057f;
		IL_0537:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0527;
		IL_0517:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_050c;
		IL_056f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_055f;
		IL_057f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_056f;
		IL_055f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0547;
		IL_050c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0547:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0537;
		IL_0527:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0517;
	}

	public void Tick()
	{
		TryPopStatUpdatesQueue();
	}

	private void TryPopStatUpdatesQueue()
	{
		HashSet<EStat> hashSet = queuedUpdateStats;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rax_v2 (System.Collections.Generic.HashSet`1<Assets.Scripts.Menu.Shop.EStat>)+20]");
		if ((nint)0 > (nint)0)
		{
			List<EStat> list = statsToUpdateBuffer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v4 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			((List<System.Int32Enum>)(object)statsToUpdateBuffer).AddRange((IEnumerable<System.Int32Enum>)queuedUpdateStats);
			queuedUpdateStats.Clear();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			List<EStat>.Enumerator enumerator = default(List<EStat>.Enumerator);
			EStat stat = default(EStat);
			while (enumerator.MoveNext())
			{
				UpdateStat(stat);
			}
			enumerator.Dispose();
		}
	}

	public void ForceUpdateStats()
	{
		TryPopStatUpdatesQueue();
	}

	private void QueueUpdateStatTome(ETome eTome, EStat stat)
	{
		bool flag = queuedUpdateStats.Add(stat);
	}

	private void QueueUpdateStat(EStat stat)
	{
		bool flag = queuedUpdateStats.Add(stat);
	}

	private unsafe void UpdateStat(EStat stat)
	{
		//IL_199c: Expected O, but got I4
		//IL_00c9: Expected F4, but got I4
		//IL_00d3: Expected F4, but got I4
		//IL_0232: Expected I4, but got O
		//IL_029e: Expected O, but got I
		//IL_05ac: Expected I4, but got O
		//IL_0311: Expected I4, but got O
		//IL_0614: Expected O, but got I
		//IL_037d: Expected O, but got I
		//IL_0674: Expected O, but got Ref
		//IL_03e1: Expected O, but got Ref
		//IL_0970: Expected I4, but got O
		//IL_06a9: Expected O, but got I
		//IL_06cc: Expected O, but got I
		//IL_042e: Expected O, but got I
		//IL_09d8: Expected O, but got I
		//IL_06fa: Expected O, but got I
		//IL_0468: Expected I4, but got O
		//IL_0468: Expected O, but got I
		//IL_0734: Expected O, but got I
		//IL_0a38: Expected O, but got Ref
		//IL_0799: Expected O, but got Ref
		//IL_0c89: Expected I4, but got O
		//IL_0a61: Invalid comparison between F4 and I4
		//IL_0a6f: Expected O, but got Ref
		//IL_0a78: Expected O, but got I4
		//IL_0a81: Expected O, but got Ref
		//IL_0cf5: Expected O, but got I
		//IL_0ace: Expected O, but got I
		//IL_0af5: Expected O, but got I
		//IL_0f53: Expected I4, but got O
		//IL_0d68: Expected I4, but got O
		//IL_1c36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3b: Expected O, but got Unknown
		//IL_1c4b: Expected O, but got I
		//IL_090d: Expected O, but got F4
		//IL_0915: Expected F4, but got O
		//IL_0fbf: Expected O, but got I
		//IL_0c4e: Expected O, but got I
		//IL_0c5f: Expected O, but got F4
		//IL_0c68: Expected F4, but got O
		//IL_08d9: Expected O, but got F4
		//IL_08e1: Expected F4, but got O
		//IL_0dd4: Expected O, but got I
		//IL_0bfa: Expected O, but got I
		//IL_0c0b: Expected O, but got F4
		//IL_0c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Expected O, but got Unknown
		//IL_0c22: Expected F4, but got O
		//IL_0c33: Expected O, but got I
		//IL_125b: Expected I4, but got O
		//IL_08a5: Expected O, but got F4
		//IL_08ad: Expected F4, but got O
		//IL_1032: Expected I4, but got O
		//IL_0ba6: Expected O, but got I
		//IL_0bb7: Expected O, but got F4
		//IL_0bc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc5: Expected O, but got Unknown
		//IL_0bce: Expected F4, but got O
		//IL_0bdf: Expected O, but got I
		//IL_12c3: Expected O, but got I
		//IL_109e: Expected O, but got I
		//IL_1e11: Expected I4, but got O
		//IL_1111: Expected O, but got I4
		//IL_149b: Expected I4, but got O
		//IL_142f: Expected O, but got F4
		//IL_1438: Expected F4, but got O
		//IL_1217: Expected O, but got I4
		//IL_1402: Expected O, but got F4
		//IL_140b: Expected F4, but got O
		//IL_1500: Expected I4, but got O
		//IL_11e3: Expected O, but got I4
		//IL_1e97: Expected I4, but got O
		//IL_151b: Expected I4, but got O
		//IL_13d5: Expected O, but got F4
		//IL_13de: Expected F4, but got O
		//IL_1870: Expected I4, but got O
		//IL_11af: Expected O, but got I4
		//IL_18aa: Expected I4, but got O
		//IL_1587: Expected O, but got I
		//IL_15ce: Expected O, but got I
		//IL_1611: Expected O, but got Ref
		//IL_1772: Expected O, but got F4
		//IL_177a: Expected F4, but got O
		//IL_1746: Expected O, but got F4
		//IL_174e: Expected F4, but got O
		//IL_171a: Expected O, but got F4
		//IL_1722: Expected F4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831727E0]");
		bool flag = (nint)0 != 0;
		float baseValue = GetBaseValue(stat);
		PlayerInventory playerInventory = this.playerInventory;
		bool flag2 = this.playerInventory == null;
		EStat eStat = stat;
		float num;
		float num2;
		float num3;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		StatModifier statModifier = default(StatModifier);
		StatModifier statModifier2;
		if (!flag2)
		{
			CharacterData characterData = playerInventory.characterData;
			bool flag3 = (object)playerInventory.characterData == null;
			eStat = stat;
			if (!flag3)
			{
				bool flag4 = characterData.statModifiers == null;
				eStat = stat;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					num = 1f;
					num2 = 0f;
					num3 = 0f;
					while (enumerator.MoveNext())
					{
						bool flag5 = statModifier == null;
						statModifier2 = statModifier;
						if (!flag5)
						{
							if (statModifier.stat != stat)
							{
								continue;
							}
							if (statModifier.modifyType != EStatModifyType.Flat)
							{
								if (statModifier.modifyType != EStatModifyType.Addition)
								{
									if (statModifier.modifyType == EStatModifyType.Multiplication)
									{
										float modificationTotal = statModifier.GetModificationTotal(1);
										float num4 = modificationTotal * num;
										num = num4;
									}
								}
								else
								{
									float modificationTotal2 = statModifier.GetModificationTotal(1);
									float num5 = modificationTotal2 + num2;
									num2 = num5;
								}
							}
							else
							{
								float modificationTotal3 = statModifier.GetModificationTotal(1);
								float num6 = modificationTotal3 + num3;
								num3 = num6;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
					PlayerInventory playerInventory2 = this.playerInventory;
					bool flag6 = this.playerInventory == null;
					eStat = (EStat)(int)(&enumerator);
					if (!flag6)
					{
						eStat = (EStat)playerInventory2.tomeInventory;
						if (playerInventory2.tomeInventory != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
							eStat = EStat.MaxHealth;
							if (!flag7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
								bool flag8 = ((Dictionary<System.Int32Enum, object>)0).ContainsKey((System.Int32Enum)stat);
								bool flag9 = !flag8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
								eStat = EStat.MaxHealth;
								if (flag9)
								{
									goto IL_1b23;
								}
								PlayerInventory playerInventory3 = this.playerInventory;
								bool flag10 = this.playerInventory == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
								eStat = EStat.MaxHealth;
								if (!flag10)
								{
									eStat = (EStat)playerInventory3.tomeInventory;
									if (playerInventory3.tomeInventory != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
										bool flag11 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
										eStat = EStat.MaxHealth;
										if (!flag11)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
											object obj = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)stat);
											bool flag12 = obj == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
											eStat = EStat.MaxHealth;
											if (!flag12)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18106E6B0");
												HashSet<ETome>.Enumerator enumerator2 = default(HashSet<ETome>.Enumerator);
												while (enumerator2.MoveNext())
												{
													PlayerInventory playerInventory4 = this.playerInventory;
													bool flag13 = this.playerInventory == null;
													Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator2);
													if (!flag13)
													{
														dictionary = (Dictionary<System.Int32Enum, object>)(object)playerInventory4.tomeInventory;
														if (playerInventory4.tomeInventory != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2220 @ rcx_v14 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+28]");
															dictionary = (Dictionary<System.Int32Enum, object>)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2220 @ rcx_v14 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+28]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2220 @ rcx_v14 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+28]");
																object obj2 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)statModifier);
																if (obj2 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rax_v168 (System.Object)+14]");
																	if ((nint)0 != 2)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rax_v168 (System.Object)+14]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rax_v168 (System.Object)+14]");
																			if ((nint)0 == 1)
																			{
																				float modificationTotal4 = ((StatModifier)obj2).GetModificationTotal(1);
																				float num7 = modificationTotal4 * num;
																				num = num7;
																			}
																		}
																		else
																		{
																			float modificationTotal5 = ((StatModifier)obj2).GetModificationTotal(1);
																			float num8 = modificationTotal5 + num2;
																			num2 = num8;
																		}
																	}
																	else
																	{
																		float modificationTotal6 = ((StatModifier)obj2).GetModificationTotal(1);
																		float num9 = modificationTotal6 + num3;
																		num3 = num9;
																	}
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
												enumerator2.Dispose();
												eStat = (EStat)(int)(&enumerator2);
												goto IL_1b23;
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
		goto IL_1994;
		IL_1d07:
		PlayerInventory playerInventory5 = this.playerInventory;
		if (this.playerInventory != null)
		{
			eStat = (EStat)playerInventory5.statInventory;
			if (playerInventory5.statInventory != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
				bool flag14 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
				eStat = EStat.MaxHealth;
				if (!flag14)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
					Dictionary<string, StatModifier>.ValueCollection values = ((Dictionary<string, StatModifier>)0).Values;
					bool flag15 = values == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+20]");
					eStat = EStat.MaxHealth;
					if (!flag15)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
						Dictionary<string, StatModifier>.ValueCollection.Enumerator enumerator4 = default(Dictionary<string, StatModifier>.ValueCollection.Enumerator);
						Dictionary<string, StatModifier>.ValueCollection.Enumerator enumerator3 = enumerator4;
						Dictionary<string, StatModifier>.ValueCollection.Enumerator enumerator5 = default(Dictionary<string, StatModifier>.ValueCollection.Enumerator);
						while (enumerator5.MoveNext())
						{
							if (statModifier != null)
							{
								if (statModifier.stat != stat)
								{
									continue;
								}
								if (statModifier.modifyType != EStatModifyType.Flat)
								{
									if (statModifier.modifyType != EStatModifyType.Addition)
									{
										if (statModifier.modifyType == EStatModifyType.Multiplication)
										{
											float modificationTotal7 = statModifier.GetModificationTotal(1);
											enumerator3 = (Dictionary<string, StatModifier>.ValueCollection.Enumerator)(modificationTotal7 * num);
											num = (float)enumerator3;
										}
									}
									else
									{
										float modificationTotal8 = statModifier.GetModificationTotal(1);
										enumerator3 = (Dictionary<string, StatModifier>.ValueCollection.Enumerator)(modificationTotal8 + num2);
										num2 = (float)enumerator3;
									}
								}
								else
								{
									float modificationTotal9 = statModifier.GetModificationTotal(1);
									enumerator3 = (Dictionary<string, StatModifier>.ValueCollection.Enumerator)(modificationTotal9 + num3);
									num3 = (float)enumerator3;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						enumerator5.Dispose();
						PlayerInventory playerInventory6 = this.playerInventory;
						bool flag16 = this.playerInventory == null;
						eStat = (EStat)(int)(&enumerator5);
						if (!flag16)
						{
							if (playerInventory6.passiveAbility == null)
							{
								goto IL_1dc8;
							}
							PassiveAbility passiveAbility = playerInventory6.passiveAbility;
							bool flag17 = passiveAbility.statModifiers == null;
							eStat = (EStat)passiveAbility.statModifiers;
							if (!flag17)
							{
								if (!((Dictionary<System.Int32Enum, object>)(object)passiveAbility.statModifiers).ContainsKey((System.Int32Enum)stat))
								{
									goto IL_1dc8;
								}
								PlayerInventory playerInventory7 = this.playerInventory;
								bool flag18 = this.playerInventory == null;
								eStat = (EStat)passiveAbility.statModifiers;
								if (!flag18)
								{
									eStat = (EStat)playerInventory7.passiveAbility;
									if (playerInventory7.passiveAbility != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
										bool flag19 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
										eStat = EStat.MaxHealth;
										if (!flag19)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
											object obj3 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)stat);
											bool flag20 = obj3 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
											eStat = EStat.MaxHealth;
											if (!flag20)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rax_v108 (System.Object)+10]");
												bool flag21 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rax_v108 (System.Object)+10]");
												eStat = EStat.MaxHealth;
												if (!flag21)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rax_v108 (System.Object)+10]");
													Dictionary<EStatModifyType, StatModifier>.ValueCollection values2 = ((Dictionary<EStatModifyType, StatModifier>)0).Values;
													bool flag22 = values2 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rax_v108 (System.Object)+10]");
													eStat = EStat.MaxHealth;
													if (!flag22)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
														IEnumerator enumerator6 = default(IEnumerator);
														object obj4 = (object)(&enumerator6);
														IEnumerator<StatModifier> enumerator7 = null;
														while (true)
														{
															if (enumerator6 != null)
															{
																if (!enumerator6.MoveNext())
																{
																	break;
																}
																if (enumerator6 != null)
																{
																	StatModifier current = ((IEnumerator<StatModifier>)enumerator6).Current;
																	if (current != null)
																	{
																		if (current.modifyType != EStatModifyType.Flat)
																		{
																			if (current.modifyType != EStatModifyType.Addition)
																			{
																				if (current.modifyType == EStatModifyType.Multiplication)
																				{
																					float modificationTotal10 = current.GetModificationTotal(1);
																					enumerator3 = (Dictionary<string, StatModifier>.ValueCollection.Enumerator)(modificationTotal10 * num);
																					num = (float)enumerator3;
																				}
																			}
																			else
																			{
																				float modificationTotal11 = current.GetModificationTotal(1);
																				enumerator3 = (Dictionary<string, StatModifier>.ValueCollection.Enumerator)(modificationTotal11 + num2);
																				num2 = (float)enumerator3;
																			}
																		}
																		else
																		{
																			float modificationTotal12 = current.GetModificationTotal(1);
																			enumerator3 = (Dictionary<string, StatModifier>.ValueCollection.Enumerator)(modificationTotal12 + num3);
																			num3 = (float)enumerator3;
																		}
																		continue;
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														if (obj4 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
														}
														goto IL_1dc8;
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
		}
		goto IL_1994;
		IL_1b23:
		PlayerInventory playerInventory8 = this.playerInventory;
		if (this.playerInventory != null)
		{
			eStat = (EStat)playerInventory8.itemInventory;
			if (playerInventory8.itemInventory != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
				bool flag23 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
				eStat = EStat.MaxHealth;
				if (!flag23)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
					Dictionary<EItem, ItemBase>.ValueCollection values3 = ((Dictionary<EItem, ItemBase>)0).Values;
					bool flag24 = values3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
					eStat = EStat.MaxHealth;
					if (!flag24)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
						Dictionary<EItem, ItemBase>.ValueCollection.Enumerator enumerator9 = default(Dictionary<EItem, ItemBase>.ValueCollection.Enumerator);
						Dictionary<EItem, ItemBase>.ValueCollection.Enumerator enumerator8 = enumerator9;
						Dictionary<EItem, ItemBase>.ValueCollection.Enumerator enumerator10 = default(Dictionary<EItem, ItemBase>.ValueCollection.Enumerator);
						IntPtr intPtr = default(IntPtr);
						object obj7 = default(object);
						StatModifier statModifier3 = default(StatModifier);
						while (enumerator10.MoveNext())
						{
							bool flag25 = statModifier == null;
							Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator10);
							if (!flag25)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ stack_-190 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+28]");
								bool flag26 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ stack_-190 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+28]");
								dictionary = (Dictionary<System.Int32Enum, object>)0;
								if (!flag26)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ stack_-190 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+28]");
									if (!((Dictionary<System.Int32Enum, object>)0).ContainsKey((System.Int32Enum)stat))
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ stack_-190 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+28]");
									dictionary = (Dictionary<System.Int32Enum, object>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ stack_-190 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ stack_-190 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+28]");
										object obj5 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)stat);
										if (obj5 != null)
										{
											IEnumerable<StatModifier> modifiers = ((StatModifiersContainer)obj5).GetModifiers();
											bool flag27 = modifiers == null;
											dictionary = (Dictionary<System.Int32Enum, object>)obj5;
											if (!flag27)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
												object obj6 = (object)(&intPtr);
												dictionary = null;
												while (true)
												{
													if (intPtr != (IntPtr)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
														if (obj7 == null)
														{
															break;
														}
														bool flag28 = intPtr == (IntPtr)0;
														dictionary = null;
														if (!flag28)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
															bool flag29 = statModifier3 == null;
															dictionary = null;
															if (!flag29)
															{
																if (statModifier3.modifyType != EStatModifyType.Flat)
																{
																	if (statModifier3.modifyType != EStatModifyType.Addition)
																	{
																		flag = statModifier3.modifyType != EStatModifyType.Multiplication;
																		dictionary = null;
																		if (!flag)
																		{
																			float modificationTotal13 = statModifier3.GetModificationTotal(1);
																			enumerator8 = (Dictionary<EItem, ItemBase>.ValueCollection.Enumerator)(modificationTotal13 * num);
																			num = (float)enumerator8;
																			dictionary = (Dictionary<System.Int32Enum, object>)(object)statModifier3;
																		}
																	}
																	else
																	{
																		float modificationTotal14 = statModifier3.GetModificationTotal(1);
																		enumerator8 = (Dictionary<EItem, ItemBase>.ValueCollection.Enumerator)(modificationTotal14 + num2);
																		num2 = (float)enumerator8;
																		dictionary = (Dictionary<System.Int32Enum, object>)(object)statModifier3;
																	}
																}
																else
																{
																	float modificationTotal15 = statModifier3.GetModificationTotal(1);
																	enumerator8 = (Dictionary<EItem, ItemBase>.ValueCollection.Enumerator)(modificationTotal15 + num3);
																	num3 = (float)enumerator8;
																	dictionary = (Dictionary<System.Int32Enum, object>)(object)statModifier3;
																}
																continue;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												if (obj6 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
												}
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
						enumerator10.Dispose();
						PlayerInventory playerInventory9 = this.playerInventory;
						bool flag30 = this.playerInventory == null;
						eStat = (EStat)(int)(&enumerator10);
						if (!flag30)
						{
							eStat = (EStat)playerInventory9.statusEffects;
							if (playerInventory9.statusEffects != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
								bool flag31 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
								eStat = EStat.MaxHealth;
								if (!flag31)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
									Dictionary<EStatusEffect, StatusEffect>.ValueCollection values4 = ((Dictionary<EStatusEffect, StatusEffect>)0).Values;
									bool flag32 = values4 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
									eStat = EStat.MaxHealth;
									if (!flag32)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
										Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator enumerator12 = default(Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator);
										Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator enumerator11 = enumerator12;
										Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator enumerator13 = default(Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator);
										while (enumerator13.MoveNext())
										{
											bool flag33 = statModifier == null;
											Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator13);
											if (!flag33)
											{
												float modification = statModifier.modification;
												bool flag34 = statModifier.modification == 0f;
												dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator13);
												object obj8 = 0;
												Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator13);
												if (flag34)
												{
													throw new NullReferenceException();
												}
												while (true)
												{
													object obj9 = obj8;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+18]");
													if ((nint)obj9 >= 0)
													{
														break;
													}
													object obj10 = obj8;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+18]");
													bool flag35 = (nint)obj10 >= 0;
													dictionary = dictionary2;
													if (!flag35)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
														StatModifier statModifier4 = (StatModifier)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
														bool flag36 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
														dictionary = (Dictionary<System.Int32Enum, object>)0;
														if (!flag36)
														{
															if (statModifier4.stat == stat)
															{
																if (statModifier4.modifyType != EStatModifyType.Flat)
																{
																	if (statModifier4.modifyType == EStatModifyType.Addition)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
																		float modificationTotal16 = ((StatModifier)0).GetModificationTotal(1);
																		enumerator11 = (Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator)(modificationTotal16 + num2);
																		obj8++;
																		num2 = (float)enumerator11;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
																		dictionary2 = (Dictionary<System.Int32Enum, object>)0;
																		continue;
																	}
																	if (statModifier4.modifyType == EStatModifyType.Multiplication)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
																		float modificationTotal17 = ((StatModifier)0).GetModificationTotal(1);
																		enumerator11 = (Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator)(modificationTotal17 * num);
																		obj8++;
																		num = (float)enumerator11;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
																		dictionary2 = (Dictionary<System.Int32Enum, object>)0;
																		continue;
																	}
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
																	float modificationTotal18 = ((StatModifier)0).GetModificationTotal(1);
																	enumerator11 = (Dictionary<EStatusEffect, StatusEffect>.ValueCollection.Enumerator)(modificationTotal18 + num3);
																	num3 = (float)enumerator11;
																}
															}
															obj8++;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1876 @ rsi_v29 (System.Single)+20+v1874 @ rdi_v33*8]");
															dictionary2 = (Dictionary<System.Int32Enum, object>)0;
															continue;
														}
														throw new NullReferenceException();
													}
													throw new IndexOutOfRangeException();
												}
												continue;
											}
											throw new NullReferenceException();
										}
										enumerator13.Dispose();
										PlayerInventory playerInventory10 = this.playerInventory;
										bool flag37 = this.playerInventory == null;
										eStat = (EStat)(int)(&enumerator13);
										if (!flag37)
										{
											eStat = (EStat)playerInventory10.statInventory;
											if (playerInventory10.statInventory != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
												bool flag38 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
												eStat = EStat.MaxHealth;
												if (!flag38)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
													bool flag39 = ((Dictionary<System.Int32Enum, object>)0).ContainsKey((System.Int32Enum)stat);
													bool flag40 = !flag39;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
													eStat = EStat.MaxHealth;
													if (flag40)
													{
														goto IL_1ca8;
													}
													PlayerInventory playerInventory11 = this.playerInventory;
													bool flag41 = this.playerInventory == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
													eStat = EStat.MaxHealth;
													if (!flag41)
													{
														eStat = (EStat)playerInventory11.statInventory;
														if (playerInventory11.statInventory != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
															bool flag42 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
															eStat = EStat.MaxHealth;
															if (!flag42)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
																object obj11 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)stat);
																bool flag43 = obj11 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+10]");
																eStat = EStat.MaxHealth;
																if (!flag43)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
																	while (enumerator.MoveNext())
																	{
																		bool flag44 = statModifier == null;
																		StatModifier statModifier5 = statModifier;
																		if (!flag44)
																		{
																			if (statModifier.modifyType != EStatModifyType.Flat)
																			{
																				if (statModifier.modifyType != EStatModifyType.Addition)
																				{
																					if (statModifier.modifyType == EStatModifyType.Multiplication)
																					{
																						float modificationTotal19 = statModifier.GetModificationTotal(1);
																						float num10 = modificationTotal19 * num;
																						num = num10;
																					}
																				}
																				else
																				{
																					float modificationTotal20 = statModifier.GetModificationTotal(1);
																					float num11 = modificationTotal20 + num2;
																					num2 = num11;
																				}
																			}
																			else
																			{
																				float modificationTotal21 = statModifier.GetModificationTotal(1);
																				float num12 = modificationTotal21 + num3;
																				num3 = num12;
																			}
																			continue;
																		}
																		throw new NullReferenceException();
																	}
																	((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
																	eStat = (EStat)(int)(&enumerator);
																	goto IL_1ca8;
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
					}
				}
			}
		}
		goto IL_1994;
		IL_1835:
		float num13;
		float value = num13;
		goto IL_1e7c;
		IL_1e7c:
		bool flag45 = stats == null;
		eStat = (EStat)stats;
		if (!flag45)
		{
			((Dictionary<System.Int32Enum, float>)(object)stats).set_Item((System.Int32Enum)stat, value);
			bool flag46 = statValuesMap == null;
			eStat = (EStat)statValuesMap;
			if (!flag46)
			{
				object obj12 = ((Dictionary<System.Int32Enum, object>)(object)statValuesMap).get_Item((System.Int32Enum)stat);
				bool flag47 = obj12 == null;
				eStat = (EStat)statValuesMap;
				if (!flag47)
				{
					float num14 = baseValue + num3;
					float num15 = num2 + 1f;
					Action<EStat> a_StatUpdate = A_StatUpdate;
					if (A_StatUpdate != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3537 @ rax_v103 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		goto IL_1994;
		IL_1994:
		statModifier2 = (StatModifier)eStat;
		throw new NullReferenceException();
		IL_1dc8:
		float num16 = baseValue + num3;
		float num17 = num2 + 1f;
		float num18 = num16 * num17;
		bool flag48 = rawStats == null;
		eStat = (EStat)rawStats;
		if (flag48)
		{
			goto IL_1994;
		}
		num13 = num18 * num;
		((Dictionary<System.Int32Enum, float>)(object)rawStats).set_Item((System.Int32Enum)stat, num13);
		if (stat == EStat.MaxHealth)
		{
			if (!(1f > num13))
			{
				bool flag49 = num13 > 2.1474836E+09f;
				value = 2.1474836E+09f;
				if (!flag49)
				{
					goto IL_1835;
				}
			}
			else
			{
				value = 1f;
			}
		}
		else
		{
			if (stat == EStat.Armor)
			{
				num17 = num13 + 0.75f;
			}
			else
			{
				if (stat != EStat.Evasion)
				{
					goto IL_1835;
				}
				num17 = num13 + 1f;
			}
			float num19 = num13 / num17;
			value = num19 * 0.999f;
		}
		goto IL_1e7c;
		IL_1ca8:
		PlayerInventory playerInventory12 = this.playerInventory;
		if (this.playerInventory != null)
		{
			eStat = (EStat)playerInventory12.statInventory;
			if (playerInventory12.statInventory != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
				bool flag50 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
				eStat = EStat.MaxHealth;
				if (!flag50)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
					bool flag51 = ((Dictionary<System.Int32Enum, object>)0).ContainsKey((System.Int32Enum)stat);
					bool flag52 = !flag51;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
					eStat = EStat.MaxHealth;
					if (flag52)
					{
						goto IL_1d07;
					}
					PlayerInventory playerInventory13 = this.playerInventory;
					bool flag53 = this.playerInventory == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
					eStat = EStat.MaxHealth;
					if (!flag53)
					{
						eStat = (EStat)playerInventory13.statInventory;
						if (playerInventory13.statInventory != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
							bool flag54 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
							eStat = EStat.MaxHealth;
							if (!flag54)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
								object obj13 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)stat);
								bool flag55 = obj13 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v27 (Assets.Scripts.Menu.Shop.EStat)+18]");
								eStat = EStat.MaxHealth;
								if (!flag55)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
									List<object>.Enumerator enumerator14 = default(List<object>.Enumerator);
									while (enumerator14.MoveNext())
									{
										bool flag56 = statModifier == null;
										StatModifier statModifier5 = statModifier;
										if (!flag56)
										{
											statModifier5 = (StatModifier)statModifier.stat;
											if (statModifier.stat != EStat.MaxHealth)
											{
												if (statModifier5.modifyType != EStatModifyType.Flat)
												{
													if (statModifier5.modifyType != EStatModifyType.Addition)
													{
														if (statModifier5.modifyType == EStatModifyType.Multiplication)
														{
															float modificationTotal22 = ((StatModifier)statModifier.stat).GetModificationTotal(1);
															float num20 = modificationTotal22 * num;
															num = num20;
														}
													}
													else
													{
														float modificationTotal23 = ((StatModifier)statModifier.stat).GetModificationTotal(1);
														float num21 = modificationTotal23 + num2;
														num2 = num21;
													}
												}
												else
												{
													float modificationTotal24 = ((StatModifier)statModifier.stat).GetModificationTotal(1);
													float num22 = modificationTotal24 + num3;
													num3 = num22;
												}
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									((List<TemporaryStat>.Enumerator*)(&enumerator14))->Dispose();
									eStat = (EStat)(int)(&enumerator14);
									goto IL_1d07;
								}
							}
						}
					}
				}
			}
		}
		goto IL_1994;
	}

	private unsafe void ApplyStatModifier(StatModifier modifier, int amount, ref float flatValues, ref float additionValues, ref float multiplicationValues)
	{
		//IL_00ec: Expected Ref, but got F4
		//IL_00be: Expected O, but got F4
		//IL_0091: Expected O, but got F4
		if (modifier.modifyType != EStatModifyType.Flat)
		{
			if (modifier.modifyType != EStatModifyType.Addition)
			{
				if (modifier.modifyType == EStatModifyType.Multiplication)
				{
					float modificationTotal = modifier.GetModificationTotal(amount);
					object obj = default(object);
					float num = modificationTotal * (float)obj;
					obj = num;
				}
			}
			else
			{
				float modificationTotal2 = modifier.GetModificationTotal(amount);
				object obj2 = default(object);
				float num2 = modificationTotal2 + (float)obj2;
				obj2 = num2;
			}
		}
		else
		{
			float modificationTotal3 = modifier.GetModificationTotal(amount);
			float num3 = modificationTotal3 + flatValues;
			ref float reference = ref *(float*)num3;
		}
	}

	private float CheckFinalValue(EStat stat, float value)
	{
		float num = default(float);
		float result;
		if (stat == EStat.MaxHealth)
		{
			bool flag = 1f > num;
			result = 1f;
			if (!flag)
			{
				bool flag2 = num > 2.1474836E+09f;
				result = 2.1474836E+09f;
				if (!flag2)
				{
					return num;
				}
			}
		}
		else
		{
			switch (stat)
			{
			case EStat.Armor:
			{
				float num4 = num + 0.75f;
				float num5 = num / num4;
				return num5 * 0.999f;
			}
			case EStat.Evasion:
			{
				float num2 = num + 1f;
				float num3 = num / num2;
				num = num3 * 0.999f;
				break;
			}
			}
			result = num;
		}
		return result;
	}

	public static float GetBaseValue(EStat stat)
	{
		//IL_0064: Expected F4, but got I4
		//IL_002a: Expected O, but got I8
		//IL_003a: Expected O, but got I
		//IL_0054: Expected O, but got I8
		if (stat <= EStat.PoisonDamageMultiplier)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+44599C+stat @ rcx (Assets.Scripts.Menu.Shop.EStat)]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+445980+v16 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v18 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 0f;
	}

	public float GetStat(EStat stat)
	{
		//IL_0048: Invalid comparison between F4 and I
		//IL_0077: Expected F4, but got I
		float num = ((Dictionary<System.Int32Enum, float>)(object)stats).get_Item((System.Int32Enum)stat);
		switch (stat)
		{
		case EStat.MaxHealth:
		{
			float num3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
			bool flag = !(num3 < 0f);
			float num4 = num;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
				num4 = 0f;
			}
			num = num4;
			break;
		}
		case EStat.Projectiles:
		case EStat.ProjectileBounces:
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num2 = Math.Floor(0.0);
			return (float)num2;
		}
		}
		return num;
	}

	public float GetRawStat(EStat stat)
	{
		return ((Dictionary<System.Int32Enum, float>)(object)rawStats).get_Item((System.Int32Enum)stat);
	}

	public float GetUnclampedStat(EStat stat)
	{
		return ((Dictionary<System.Int32Enum, float>)(object)stats).get_Item((System.Int32Enum)stat);
	}
}
