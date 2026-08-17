using System;
using System.Collections.Generic;
using System.Linq;
using Actors.Enemies;
using Assets.Scripts._Data.Hats;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.InGame.Rewards;
using Cpp2ILInjected;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public List<ShopItemData> unsortedShopItems;

	public List<WeaponData> unsortedWeapons;

	public List<CharacterData> unsortedCharacterData;

	public List<TomeData> unsortedTomes;

	public List<MapData> maps;

	public List<EnemyData> unsortedEnemies;

	public List<EncounterData> unsortedEncounters;

	public List<MyAchievement> unsortedAchievements;

	public List<ItemData> unsortedItems;

	public List<UnlockableBase> unsortedUnlockables;

	public List<SkinData> unsortedSkins;

	public List<MusicTrack> unsortedMusic;

	public List<HatData> unsortedHats;

	private readonly Dictionary<EShopItem, ShopItemData> _003CshopItems_003Ek__BackingField;

	private Dictionary<EWeapon, WeaponData> weapons;

	private Dictionary<ECharacter, CharacterData> characterData;

	private Dictionary<ETome, TomeData> tomeData;

	private Dictionary<EEnemy, EnemyData> enemyData;

	private Dictionary<EEncounter, EncounterData> encounterData;

	private Dictionary<EItem, ItemData> itemData;

	private Dictionary<string, MyAchievement> achievementsData;

	private Dictionary<ECharacter, List<SkinData>> skinData;

	private Dictionary<EHat, HatData> hatData;

	public static Action A_DataLoaded;

	public static DataManager Instance;

	public Dictionary<EShopItem, ShopItemData> shopItems => _003CshopItems_003Ek__BackingField;

	public unsafe void Load()
	{
		//IL_0a5d: Expected I, but got O
		//IL_0a73: Expected O, but got I
		//IL_0afc: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		//IL_0b54: Expected O, but got Ref
		//IL_00bf: Expected O, but got Ref
		//IL_017a: Expected O, but got Ref
		//IL_0c13: Expected O, but got Ref
		//IL_0240: Expected O, but got Ref
		//IL_0c6b: Expected O, but got Ref
		//IL_02ed: Expected O, but got Ref
		//IL_0cc3: Expected O, but got Ref
		//IL_03a5: Expected O, but got Ref
		//IL_0d1b: Expected O, but got Ref
		//IL_0438: Expected O, but got Ref
		//IL_0d73: Expected O, but got Ref
		//IL_04cb: Expected O, but got Ref
		//IL_0dcb: Expected O, but got Ref
		//IL_0583: Expected O, but got Ref
		//IL_0542: Expected O, but got I
		//IL_0e23: Expected O, but got Ref
		//IL_0652: Expected O, but got Ref
		//IL_0668: Expected I, but got O
		//IL_0695: Expected I, but got O
		//IL_0e7b: Expected O, but got Ref
		//IL_0733: Expected O, but got Ref
		//IL_06dc: Expected I, but got O
		//IL_06f9: Expected I, but got O
		//IL_0878: Expected O, but got Ref
		//IL_08f3: Expected I, but got O
		Instance = this;
		nint num = (nint)typeof(DataManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (Il2CppClass<DataManager>)+B8]");
		IEnumerable<object> enumerable = (IEnumerable<object>)((nint)0 + (nint)8);
		Dictionary<System.Int32Enum, object> dictionary;
		if (unsortedShopItems != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			object obj = default(object);
			while (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					dictionary = (Dictionary<System.Int32Enum, object>)(object)_003CshopItems_003Ek__BackingField;
					if (_003CshopItems_003Ek__BackingField != null)
					{
						Dictionary<EShopItem, ShopItemData> dictionary2 = _003CshopItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+50]");
						((Dictionary<System.Int32Enum, object>)(object)dictionary2).Add((System.Int32Enum)0, obj);
						nint num2 = 0;
						continue;
					}
					enumerator2 = (List<object>.Enumerator)dictionary;
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<ShopItemData>.Enumerator*)(&enumerator))->Dispose();
			bool flag2 = unsortedWeapons == null;
			enumerable = (IEnumerable<object>)(&enumerator);
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
				while (enumerator3.MoveNext())
				{
					bool flag3 = obj == null;
					Dictionary<System.Int32Enum, object> dictionary3 = (Dictionary<System.Int32Enum, object>)(&enumerator3);
					if (!flag3)
					{
						if (((UnlockableBase)obj).isEnabled)
						{
							((WeaponData)obj).Init();
							dictionary3 = (Dictionary<System.Int32Enum, object>)(object)weapons;
							if (weapons == null)
							{
								throw new NullReferenceException();
							}
							((Dictionary<System.Int32Enum, object>)(object)weapons).Add((System.Int32Enum)((WeaponData)obj).eWeapon, obj);
							nint num2 = 0;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				((List<WeaponData>.Enumerator*)(&enumerator3))->Dispose();
				bool flag4 = unsortedCharacterData == null;
				enumerable = (IEnumerable<object>)(&enumerator3);
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
					while (enumerator4.MoveNext())
					{
						bool flag5 = obj == null;
						Dictionary<System.Int32Enum, object> dictionary3 = (Dictionary<System.Int32Enum, object>)(&enumerator4);
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
							if ((nint)0 != 0)
							{
								dictionary3 = (Dictionary<System.Int32Enum, object>)(object)characterData;
								if (characterData == null)
								{
									throw new NullReferenceException();
								}
								Dictionary<ECharacter, CharacterData> dictionary4 = characterData;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+50]");
								((Dictionary<System.Int32Enum, object>)(object)dictionary4).Add((System.Int32Enum)0, obj);
								((CharacterData)obj).Init();
								nint num2 = 0;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					((List<CharacterData>.Enumerator*)(&enumerator4))->Dispose();
					enumerable = maps;
					List<object> list = Enumerable.ToList((IEnumerable<object>)maps);
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						List<object>.Enumerator enumerator5 = default(List<object>.Enumerator);
						while (enumerator5.MoveNext())
						{
							bool flag6 = obj == null;
							List<object> list2 = (List<object>)(&enumerator5);
							if (!flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
								if ((nint)0 == 0)
								{
									list2 = (List<object>)(object)maps;
									if (maps == null)
									{
										throw new NullReferenceException();
									}
									bool flag7 = ((List<object>)(object)maps).Remove(obj);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						((List<MapData>.Enumerator*)(&enumerator5))->Dispose();
						bool flag8 = unsortedTomes == null;
						enumerable = (IEnumerable<object>)(&enumerator5);
						if (!flag8)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
							List<object>.Enumerator enumerator6 = default(List<object>.Enumerator);
							while (enumerator6.MoveNext())
							{
								bool flag9 = obj == null;
								Dictionary<System.Int32Enum, object> dictionary5 = (Dictionary<System.Int32Enum, object>)(&enumerator6);
								if (!flag9)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
									if ((nint)0 != 0)
									{
										dictionary5 = (Dictionary<System.Int32Enum, object>)(object)tomeData;
										if (tomeData == null)
										{
											throw new NullReferenceException();
										}
										Dictionary<ETome, TomeData> dictionary6 = tomeData;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+50]");
										((Dictionary<System.Int32Enum, object>)(object)dictionary6).Add((System.Int32Enum)0, obj);
										nint num2 = 0;
									}
									continue;
								}
								throw new NullReferenceException();
							}
							((List<TomeData>.Enumerator*)(&enumerator6))->Dispose();
							bool flag10 = unsortedEnemies == null;
							enumerable = (IEnumerable<object>)(&enumerator6);
							if (!flag10)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
								List<object>.Enumerator enumerator7 = default(List<object>.Enumerator);
								while (enumerator7.MoveNext())
								{
									bool flag11 = obj == null;
									Dictionary<System.Int32Enum, object> dictionary5 = (Dictionary<System.Int32Enum, object>)(&enumerator7);
									if (!flag11)
									{
										dictionary5 = (Dictionary<System.Int32Enum, object>)(object)enemyData;
										if (enemyData != null)
										{
											Dictionary<EEnemy, EnemyData> dictionary7 = enemyData;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
											((Dictionary<System.Int32Enum, object>)(object)dictionary7).Add((System.Int32Enum)0, obj);
											nint num2 = 0;
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								((List<EnemyData>.Enumerator*)(&enumerator7))->Dispose();
								bool flag12 = unsortedEncounters == null;
								enumerable = (IEnumerable<object>)(&enumerator7);
								if (!flag12)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
									List<object>.Enumerator enumerator8 = default(List<object>.Enumerator);
									while (enumerator8.MoveNext())
									{
										bool flag13 = obj == null;
										Dictionary<System.Int32Enum, object> dictionary5 = (Dictionary<System.Int32Enum, object>)(&enumerator8);
										if (!flag13)
										{
											dictionary5 = (Dictionary<System.Int32Enum, object>)(object)encounterData;
											if (encounterData != null)
											{
												Dictionary<EEncounter, EncounterData> dictionary8 = encounterData;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
												((Dictionary<System.Int32Enum, object>)(object)dictionary8).Add((System.Int32Enum)0, obj);
												nint num2 = 0;
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									((List<EncounterData>.Enumerator*)(&enumerator8))->Dispose();
									bool flag14 = unsortedAchievements == null;
									enumerable = (IEnumerable<object>)(&enumerator8);
									if (!flag14)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
										List<object>.Enumerator enumerator9 = default(List<object>.Enumerator);
										while (enumerator9.MoveNext())
										{
											bool flag15 = obj == null;
											Dictionary<object, object> dictionary9 = (Dictionary<object, object>)(&enumerator9);
											if (!flag15)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+28]");
												if ((nint)0 != 0)
												{
													dictionary9 = (Dictionary<object, object>)(object)achievementsData;
													if (achievementsData == null)
													{
														throw new NullReferenceException();
													}
													Dictionary<string, MyAchievement> dictionary10 = achievementsData;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+30]");
													((Dictionary<object, object>)(object)dictionary10).Add((object)0, obj);
													nint num2 = 0;
												}
												continue;
											}
											throw new NullReferenceException();
										}
										((List<MyAchievement>.Enumerator*)(&enumerator9))->Dispose();
										bool flag16 = unsortedItems == null;
										enumerable = (IEnumerable<object>)(&enumerator9);
										if (!flag16)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
											List<object>.Enumerator enumerator10 = default(List<object>.Enumerator);
											while (enumerator10.MoveNext())
											{
												bool flag17 = obj == null;
												Dictionary<System.Int32Enum, object> dictionary11 = (Dictionary<System.Int32Enum, object>)(&enumerator10);
												if (!flag17)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
													if ((nint)0 != 0)
													{
														dictionary11 = (Dictionary<System.Int32Enum, object>)(object)itemData;
														if (itemData == null)
														{
															throw new NullReferenceException();
														}
														Dictionary<EItem, ItemData> dictionary12 = itemData;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+54]");
														((Dictionary<System.Int32Enum, object>)(object)dictionary12).Add((System.Int32Enum)0, obj);
														ItemBase dummyItem = ((ItemData)obj).GetDummyItem();
														nint num2 = 0;
													}
													continue;
												}
												throw new NullReferenceException();
											}
											((List<ItemData>.Enumerator*)(&enumerator10))->Dispose();
											bool flag18 = unsortedUnlockables == null;
											enumerable = (IEnumerable<object>)(&enumerator10);
											if (!flag18)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
												nint num3 = 0;
												List<object>.Enumerator enumerator11 = default(List<object>.Enumerator);
												UnityEngine.Object obj3 = default(UnityEngine.Object);
												while (enumerator11.MoveNext())
												{
													bool flag19 = obj == null;
													UnityEngine.Object obj2 = (UnityEngine.Object)(&enumerator11);
													if (!flag19)
													{
														nint num4 = (nint)obj;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2670 @ rax_v135 (Il2CppClass<System.Object>)+1C8] (should have been resolved before IL gen)");
														bool flag20 = obj3 != null;
														bool flag21 = !flag20;
														num3 = unchecked((nint)null);
														if (!flag21)
														{
															if ((object)obj3 == null)
															{
																throw new NullReferenceException();
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2673 @ rax_v136 (UnityEngine.Object)+28]");
															bool flag22 = (nint)0 == 0;
															num3 = unchecked((nint)null);
															if (!flag22)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180404760");
																num3 = unchecked((nint)null);
															}
														}
														continue;
													}
													throw new NullReferenceException();
												}
												((List<UnlockableBase>.Enumerator*)(&enumerator11))->Dispose();
												bool flag23 = unsortedSkins == null;
												enumerable = (IEnumerable<object>)(&enumerator11);
												if (!flag23)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
													List<object>.Enumerator enumerator12 = default(List<object>.Enumerator);
													while (enumerator12.MoveNext())
													{
														bool flag24 = obj == null;
														List<SkinData> list3 = (List<SkinData>)(&enumerator12);
														if (!flag24)
														{
															if (skinData != null)
															{
																if (!((Dictionary<System.Int32Enum, object>)(object)skinData).ContainsKey((System.Int32Enum)((SkinData)obj).character))
																{
																	List<SkinData> value = new List<SkinData>();
																	if (skinData == null)
																	{
																		throw new NullReferenceException();
																	}
																	((Dictionary<System.Int32Enum, object>)(object)skinData).Add((System.Int32Enum)((SkinData)obj).character, (object)value);
																	nint num2 = 0;
																}
																if (skinData != null)
																{
																	object obj4 = ((Dictionary<System.Int32Enum, object>)(object)skinData).get_Item((System.Int32Enum)((SkinData)obj).character);
																	if (obj4 != null)
																	{
																		((List<SkinData>)obj4).Add((SkinData)obj);
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
													((List<SkinData>.Enumerator*)(&enumerator12))->Dispose();
													bool flag25 = unsortedHats == null;
													enumerable = (IEnumerable<object>)(&enumerator12);
													if (!flag25)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
														nint num5 = 0;
														List<object>.Enumerator enumerator13 = default(List<object>.Enumerator);
														while (true)
														{
															if (enumerator13.MoveNext())
															{
																bool flag26 = obj == null;
																Dictionary<System.Int32Enum, object> dictionary13 = (Dictionary<System.Int32Enum, object>)(&enumerator13);
																if (!flag26)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+18]");
																	if ((nint)0 != 0)
																	{
																		if (hatData == null)
																		{
																			break;
																		}
																		Dictionary<EHat, HatData> dictionary14 = hatData;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ stack_-1C8 (System.Object)+50]");
																		((Dictionary<System.Int32Enum, object>)(object)dictionary14).Add((System.Int32Enum)0, obj);
																		nint num2 = 0;
																		num5 = (nint)obj;
																	}
																	continue;
																}
																throw new NullReferenceException();
															}
															((List<HatData>.Enumerator*)(&enumerator13))->Dispose();
															Action a_DataLoaded = A_DataLoaded;
															if (A_DataLoaded != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2795.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
															}
															return;
														}
														throw new NullReferenceException();
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
		dictionary = (Dictionary<System.Int32Enum, object>)enumerable;
		throw new NullReferenceException();
	}

	public ShopItemData GetShopItemData(EShopItem item)
	{
		if (_003CshopItems_003Ek__BackingField != null)
		{
			return (ShopItemData)((Dictionary<System.Int32Enum, object>)(object)_003CshopItems_003Ek__BackingField).get_Item((System.Int32Enum)item);
		}
		return (ShopItemData)(object)new NullReferenceException();
	}

	public WeaponData GetWeapon(EWeapon weapon)
	{
		if (weapons != null)
		{
			return (WeaponData)((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)weapon);
		}
		return (WeaponData)(object)new NullReferenceException();
	}

	public CharacterData GetCharacterData(ECharacter character)
	{
		if (characterData != null)
		{
			return (CharacterData)((Dictionary<System.Int32Enum, object>)(object)characterData).get_Item((System.Int32Enum)character);
		}
		return (CharacterData)(object)new NullReferenceException();
	}

	public TomeData GetTome(ETome eTome)
	{
		if (tomeData != null)
		{
			return (TomeData)((Dictionary<System.Int32Enum, object>)(object)tomeData).get_Item((System.Int32Enum)eTome);
		}
		return (TomeData)(object)new NullReferenceException();
	}

	public unsafe MapData GetMap(EMap map)
	{
		//IL_002b: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MapData mapData = default(MapData);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = (object)mapData == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				if (mapData.eMap == map)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					return mapData;
				}
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return null;
		}
		throw new NullReferenceException();
	}

	public List<TomeData> GetAllTomes()
	{
		if (tomeData != null)
		{
			Dictionary<ETome, TomeData>.ValueCollection values = tomeData.Values;
			return (List<TomeData>)(object)Enumerable.ToList((IEnumerable<object>)values);
		}
		return (List<TomeData>)(object)new NullReferenceException();
	}

	public List<WeaponData> GetAllWeapons()
	{
		if (weapons != null)
		{
			Dictionary<EWeapon, WeaponData>.ValueCollection values = weapons.Values;
			return (List<WeaponData>)(object)Enumerable.ToList((IEnumerable<object>)values);
		}
		return (List<WeaponData>)(object)new NullReferenceException();
	}

	public EnemyData GetEnemyData(EEnemy eEnemy)
	{
		if (enemyData != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)enemyData).ContainsKey((System.Int32Enum)eEnemy))
			{
				return null;
			}
			if (enemyData != null)
			{
				return (EnemyData)((Dictionary<System.Int32Enum, object>)(object)enemyData).get_Item((System.Int32Enum)eEnemy);
			}
		}
		return (EnemyData)(object)new NullReferenceException();
	}

	public EncounterData GetEncounter(EEncounter encounter)
	{
		if (encounterData != null)
		{
			return (EncounterData)((Dictionary<System.Int32Enum, object>)(object)encounterData).get_Item((System.Int32Enum)encounter);
		}
		return (EncounterData)(object)new NullReferenceException();
	}

	public MyAchievement GetAchievement(string internalName)
	{
		if (achievementsData != null)
		{
			if (!achievementsData.ContainsKey(internalName))
			{
				return null;
			}
			if (achievementsData != null)
			{
				return achievementsData.get_Item(internalName);
			}
		}
		return (MyAchievement)(object)new NullReferenceException();
	}

	public ItemData GetItem(EItem item)
	{
		if (itemData != null)
		{
			return (ItemData)((Dictionary<System.Int32Enum, object>)(object)itemData).get_Item((System.Int32Enum)item);
		}
		return (ItemData)(object)new NullReferenceException();
	}

	public List<UnlockableBase> GetAllPurchasable()
	{
		List<UnlockableBase> list = new List<UnlockableBase>();
		if (list != null)
		{
			((List<object>)(object)list).AddRange((IEnumerable<object>)unsortedCharacterData);
			((List<object>)(object)list).AddRange((IEnumerable<object>)unsortedWeapons);
			((List<object>)(object)list).AddRange((IEnumerable<object>)unsortedTomes);
			((List<object>)(object)list).AddRange((IEnumerable<object>)unsortedItems);
			return list;
		}
		return (List<UnlockableBase>)(object)new NullReferenceException();
	}

	private string GetCharactersPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172DA7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "Assets/Scripts/_Data/Characters";
	}

	private string GetTomePath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172DA8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "Assets/Scripts/_Data/Tomes";
	}

	private string GetDataPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172DA9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "Assets/Scripts/_Data";
	}

	public List<SkinData> GetSkins(ECharacter character)
	{
		if (skinData != null)
		{
			return (List<SkinData>)((Dictionary<System.Int32Enum, object>)(object)skinData).get_Item((System.Int32Enum)character);
		}
		return (List<SkinData>)(object)new NullReferenceException();
	}

	public SkinData GetSkin(ECharacter character, int savedIndex)
	{
		object obj2;
		int index;
		if (savedIndex >= 0)
		{
			if (skinData != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)skinData).get_Item((System.Int32Enum)character);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v10 (System.Object)+18]");
					if ((nint)savedIndex >= (nint)0)
					{
						goto IL_014c;
					}
					if (skinData != null)
					{
						obj2 = ((Dictionary<System.Int32Enum, object>)(object)skinData).get_Item((System.Int32Enum)character);
						if (obj2 != null)
						{
							index = savedIndex;
							goto IL_016b;
						}
					}
				}
			}
			goto IL_0102;
		}
		goto IL_014c;
		IL_014c:
		if (skinData != null)
		{
			obj2 = ((Dictionary<System.Int32Enum, object>)(object)skinData).get_Item((System.Int32Enum)character);
			if (obj2 != null)
			{
				index = 0;
				goto IL_016b;
			}
		}
		goto IL_0102;
		IL_0102:
		return (SkinData)(object)new NullReferenceException();
		IL_016b:
		return ((List<SkinData>)obj2).get_Item(index);
	}

	public HatData GetHat(EHat eHat)
	{
		if (eHat != EHat.None)
		{
			if (hatData != null)
			{
				return (HatData)((Dictionary<System.Int32Enum, object>)(object)hatData).get_Item((System.Int32Enum)eHat);
			}
			return (HatData)(object)new NullReferenceException();
		}
		return null;
	}

	public DataManager()
	{
		Dictionary<EShopItem, ShopItemData> dictionary = new Dictionary<EShopItem, ShopItemData>();
		_003CshopItems_003Ek__BackingField = dictionary;
		weapons = new Dictionary<EWeapon, WeaponData>();
		characterData = new Dictionary<ECharacter, CharacterData>();
		tomeData = new Dictionary<ETome, TomeData>();
		enemyData = new Dictionary<EEnemy, EnemyData>();
		encounterData = new Dictionary<EEncounter, EncounterData>();
		itemData = new Dictionary<EItem, ItemData>();
		achievementsData = new Dictionary<string, MyAchievement>();
		skinData = new Dictionary<ECharacter, List<SkinData>>();
		hatData = new Dictionary<EHat, HatData>();
		base._002Ector();
	}
}
