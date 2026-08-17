using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;

public class UpgradeInventoryUI : MonoBehaviour
{
	public GameObject itemContainerPrefab;

	public Transform weaponParent;

	public Transform tomeParent;

	public Transform itemParent;

	public Transform banishedItemsParent;

	private List<InventoryItemPrefabUI> weaponContainers;

	private List<InventoryItemPrefabUI> tomeContainers;

	private List<InventoryItemPrefabUI> itemContainers;

	private List<InventoryItemPrefabUI> banishedItemContainers;

	private void OnEnable()
	{
		Refresh();
	}

	public unsafe void Refresh()
	{
		//IL_00ed: Expected O, but got I
		//IL_0168: Expected O, but got I
		//IL_0187: Expected O, but got I
		//IL_01d4: Expected O, but got I
		//IL_0249: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_126e: Expected O, but got Ref
		//IL_1290: Expected O, but got Ref
		//IL_136c: Expected O, but got Ref
		//IL_0daa: Expected O, but got Ref
		UpgradeInventoryUI upgradeInventoryUI = this;
		MyPlayer instance = MyPlayer.Instance;
		List<System.Int32Enum> list;
		List<System.Int32Enum> list3;
		int num2;
		List<System.Int32Enum> list4;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				upgradeInventoryUI = (UpgradeInventoryUI)(object)inventory.tomeInventory;
				if (inventory.tomeInventory != null)
				{
					bool flag = ((MonoBehaviour)upgradeInventoryUI).m_CancellationTokenSource == null;
					upgradeInventoryUI = (UpgradeInventoryUI)(object)((MonoBehaviour)upgradeInventoryUI).m_CancellationTokenSource;
					if (!flag)
					{
						Dictionary<ETome, int>.KeyCollection keys = ((Dictionary<ETome, int>)(object)((MonoBehaviour)upgradeInventoryUI).m_CancellationTokenSource).Keys;
						list = Enumerable.ToList((IEnumerable<System.Int32Enum>)(object)keys);
						upgradeInventoryUI = (UpgradeInventoryUI)(object)MyPlayer.Instance;
						if ((object)MyPlayer.Instance != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v16 (UpgradeInventoryUI)+90]");
							upgradeInventoryUI = (UpgradeInventoryUI)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v16 (UpgradeInventoryUI)+90]");
							if ((nint)0 != 0)
							{
								Transform transform = upgradeInventoryUI.weaponParent;
								if ((object)upgradeInventoryUI.weaponParent != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v18 (UnityEngine.Transform)+18]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v18 (UnityEngine.Transform)+18]");
									upgradeInventoryUI = (UpgradeInventoryUI)0;
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v18 (UnityEngine.Transform)+18]");
										Dictionary<EWeapon, WeaponBase>.ValueCollection values = ((Dictionary<EWeapon, WeaponBase>)0).Values;
										List<object> list2 = Enumerable.ToList((IEnumerable<object>)values);
										upgradeInventoryUI = (UpgradeInventoryUI)(object)MyPlayer.Instance;
										if ((object)MyPlayer.Instance != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v16 (UpgradeInventoryUI)+90]");
											upgradeInventoryUI = (UpgradeInventoryUI)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v16 (UpgradeInventoryUI)+90]");
											if ((nint)0 != 0)
											{
												GameObject gameObject = upgradeInventoryUI.itemContainerPrefab;
												if ((object)upgradeInventoryUI.itemContainerPrefab != null)
												{
													bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
													upgradeInventoryUI = (UpgradeInventoryUI)(nint)((UnityEngine.Object)gameObject).m_CachedPtr;
													if (!flag3)
													{
														Dictionary<EItem, ItemBase>.KeyCollection keys2 = ((Dictionary<EItem, ItemBase>)(nint)((UnityEngine.Object)gameObject).m_CachedPtr).Keys;
														list3 = Enumerable.ToList((IEnumerable<System.Int32Enum>)(object)keys2);
														int numAvailableWeaponSlots = InventoryUtility.GetNumAvailableWeaponSlots();
														bool flag4 = list2 == null;
														upgradeInventoryUI = null;
														if (!flag4)
														{
															int num = list2._size;
															if (numAvailableWeaponSlots > list2._size)
															{
																num = numAvailableWeaponSlots;
															}
															int numAvailableTomeSlots = InventoryUtility.GetNumAvailableTomeSlots();
															bool flag5 = list == null;
															upgradeInventoryUI = null;
															if (!flag5)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
																num2 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
																if ((nint)numAvailableTomeSlots > (nint)0)
																{
																	num2 = numAvailableTomeSlots;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
																object obj = default(object);
																bool flag6 = (nint)obj <= 0;
																list4 = list;
																int num3 = 0;
																Transform transform3 = default(Transform);
																Transform transform2 = transform3;
																int num4 = num;
																List<System.Int32Enum> list5 = list;
																upgradeInventoryUI = null;
																if (flag6)
																{
																	goto IL_05f8;
																}
																object obj2 = default(object);
																while (true)
																{
																	List<InventoryItemPrefabUI> list6 = weaponContainers;
																	if (weaponContainers == null)
																	{
																		break;
																	}
																	if (num3 >= list6._size)
																	{
																		transform2 = weaponParent;
																		GameObject gameObject2 = UnityEngine.Object.Instantiate(itemContainerPrefab, weaponParent);
																		bool flag7 = (object)gameObject2 == null;
																		upgradeInventoryUI = (UpgradeInventoryUI)(object)itemContainerPrefab;
																		if (flag7)
																		{
																			break;
																		}
																		InventoryItemPrefabUI component = gameObject2.GetComponent<InventoryItemPrefabUI>();
																		weaponContainers.Add(component);
																		num4 = num;
																		list5 = (List<System.Int32Enum>)(object)weaponContainers;
																	}
																	bool flag8 = weaponContainers == null;
																	upgradeInventoryUI = (UpgradeInventoryUI)(object)weaponContainers;
																	if (flag8)
																	{
																		break;
																	}
																	InventoryItemPrefabUI inventoryItemPrefabUI = weaponContainers.get_Item(num3);
																	bool flag9 = (object)inventoryItemPrefabUI == null;
																	upgradeInventoryUI = (UpgradeInventoryUI)(object)weaponContainers;
																	if (flag9)
																	{
																		break;
																	}
																	GameObject gameObject3 = inventoryItemPrefabUI.gameObject;
																	bool flag10 = (object)gameObject3 == null;
																	upgradeInventoryUI = (UpgradeInventoryUI)(object)inventoryItemPrefabUI;
																	if (flag10)
																	{
																		break;
																	}
																	gameObject3.SetActive(value: true);
																	if (num3 >= num4)
																	{
																		bool flag11 = weaponContainers == null;
																		upgradeInventoryUI = (UpgradeInventoryUI)(object)weaponContainers;
																		if (flag11)
																		{
																			break;
																		}
																		InventoryItemPrefabUI inventoryItemPrefabUI2 = weaponContainers.get_Item(num3);
																		bool flag12 = (object)inventoryItemPrefabUI2 == null;
																		upgradeInventoryUI = (UpgradeInventoryUI)(object)weaponContainers;
																		if (flag12)
																		{
																			break;
																		}
																		inventoryItemPrefabUI2.SetUnavailable();
																	}
																	else
																	{
																		bool flag13 = weaponContainers == null;
																		upgradeInventoryUI = (UpgradeInventoryUI)(object)weaponContainers;
																		if (flag13)
																		{
																			break;
																		}
																		if (list2._size <= num3)
																		{
																			InventoryItemPrefabUI inventoryItemPrefabUI3 = weaponContainers.get_Item(num3);
																			bool flag14 = (object)inventoryItemPrefabUI3 == null;
																			upgradeInventoryUI = (UpgradeInventoryUI)(object)weaponContainers;
																			if (flag14)
																			{
																				break;
																			}
																			inventoryItemPrefabUI3.SetItem(null);
																		}
																		else
																		{
																			InventoryItemPrefabUI inventoryItemPrefabUI4 = weaponContainers.get_Item(num3);
																			WeaponBase weaponBase = ((List<WeaponBase>)(object)list2).get_Item(num3);
																			bool flag15 = weaponBase == null;
																			upgradeInventoryUI = (UpgradeInventoryUI)(object)list2;
																			if (flag15)
																			{
																				break;
																			}
																			bool flag16 = (object)inventoryItemPrefabUI4 == null;
																			upgradeInventoryUI = (UpgradeInventoryUI)(object)list2;
																			if (flag16)
																			{
																				break;
																			}
																			inventoryItemPrefabUI4.SetItem(weaponBase.weaponData);
																			num4 = num;
																		}
																	}
																	num3++;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
																	bool flag17 = num3 < (nint)obj2;
																	transform3 = transform2;
																	list4 = list5;
																	upgradeInventoryUI = null;
																	if (flag17)
																	{
																		continue;
																	}
																	goto IL_05f8;
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
		goto IL_1029;
		IL_05f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
		object obj3 = default(object);
		bool flag18 = (nint)obj3 <= 0;
		upgradeInventoryUI = null;
		if (flag18)
		{
			goto IL_0983;
		}
		int num5 = 0;
		List<System.Int32Enum> list7 = list4;
		UpgradeInventoryUI upgradeInventoryUI2 = null;
		object obj4 = default(object);
		while (true)
		{
			List<InventoryItemPrefabUI> list8 = tomeContainers;
			bool flag19 = tomeContainers == null;
			upgradeInventoryUI = upgradeInventoryUI2;
			if (flag19)
			{
				break;
			}
			if (num5 >= list8._size)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate(itemContainerPrefab, tomeParent);
				bool flag20 = (object)gameObject4 == null;
				upgradeInventoryUI = (UpgradeInventoryUI)(object)itemContainerPrefab;
				if (flag20)
				{
					break;
				}
				InventoryItemPrefabUI component2 = gameObject4.GetComponent<InventoryItemPrefabUI>();
				tomeContainers.Add(component2);
				list7 = (List<System.Int32Enum>)(object)tomeContainers;
			}
			bool flag21 = tomeContainers == null;
			upgradeInventoryUI = (UpgradeInventoryUI)(object)tomeContainers;
			if (flag21)
			{
				break;
			}
			InventoryItemPrefabUI inventoryItemPrefabUI5 = tomeContainers.get_Item(num5);
			bool flag22 = (object)inventoryItemPrefabUI5 == null;
			upgradeInventoryUI = (UpgradeInventoryUI)(object)tomeContainers;
			if (flag22)
			{
				break;
			}
			GameObject gameObject5 = inventoryItemPrefabUI5.gameObject;
			bool flag23 = (object)gameObject5 == null;
			upgradeInventoryUI = (UpgradeInventoryUI)(object)inventoryItemPrefabUI5;
			if (flag23)
			{
				break;
			}
			gameObject5.SetActive(value: true);
			if (num5 >= num2)
			{
				bool flag24 = tomeContainers == null;
				upgradeInventoryUI = (UpgradeInventoryUI)(object)tomeContainers;
				if (flag24)
				{
					break;
				}
				InventoryItemPrefabUI inventoryItemPrefabUI6 = tomeContainers.get_Item(num5);
				bool flag25 = (object)inventoryItemPrefabUI6 == null;
				upgradeInventoryUI = (UpgradeInventoryUI)(object)tomeContainers;
				if (flag25)
				{
					break;
				}
				inventoryItemPrefabUI6.SetUnavailable();
			}
			else
			{
				bool flag26 = tomeContainers == null;
				upgradeInventoryUI = (UpgradeInventoryUI)(object)tomeContainers;
				if (flag26)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				UnlockableBase item;
				InventoryItemPrefabUI inventoryItemPrefabUI8;
				if ((nint)0 <= (nint)num5)
				{
					InventoryItemPrefabUI inventoryItemPrefabUI7 = tomeContainers.get_Item(num5);
					bool flag27 = (object)inventoryItemPrefabUI7 == null;
					upgradeInventoryUI = (UpgradeInventoryUI)(object)tomeContainers;
					if (flag27)
					{
						break;
					}
					item = null;
					inventoryItemPrefabUI8 = inventoryItemPrefabUI7;
				}
				else
				{
					InventoryItemPrefabUI inventoryItemPrefabUI9 = tomeContainers.get_Item(num5);
					ETome eTome = ((List<ETome>)(object)list).get_Item(num5);
					bool flag28 = (object)DataManager.Instance == null;
					upgradeInventoryUI = (UpgradeInventoryUI)(object)list;
					if (flag28)
					{
						break;
					}
					TomeData tome = DataManager.Instance.GetTome(eTome);
					bool flag29 = (object)inventoryItemPrefabUI9 == null;
					upgradeInventoryUI = (UpgradeInventoryUI)(object)DataManager.Instance;
					if (flag29)
					{
						break;
					}
					Transform transform3 = (Transform)(object)DataManager.Instance;
					item = tome;
					inventoryItemPrefabUI8 = inventoryItemPrefabUI9;
				}
				inventoryItemPrefabUI8.SetItem(item);
				list7 = list;
			}
			num5++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
			bool flag30 = num5 < (nint)obj4;
			list4 = list7;
			upgradeInventoryUI = null;
			upgradeInventoryUI2 = null;
			if (flag30)
			{
				continue;
			}
			goto IL_0983;
		}
		goto IL_1029;
		IL_0983:
		if (itemContainers != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Component component3 = default(Component);
			while (enumerator.MoveNext())
			{
				if ((object)component3 != null)
				{
					GameObject gameObject6 = component3.gameObject;
					if ((object)gameObject6 != null)
					{
						gameObject6.SetActive(value: false);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<InventoryItemPrefabUI>.Enumerator*)(&enumerator))->Dispose();
			bool flag31 = list3 == null;
			upgradeInventoryUI = (UpgradeInventoryUI)(&enumerator);
			int num6 = 0;
			List<System.Int32Enum> list9 = list3;
			int num7 = 0;
			UpgradeInventoryUI upgradeInventoryUI3 = (UpgradeInventoryUI)(&enumerator);
			if (!flag31)
			{
				HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
				while (true)
				{
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1124 @ r15_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					if ((nint)num8 < (nint)0)
					{
						List<InventoryItemPrefabUI> list10 = itemContainers;
						bool flag32 = itemContainers == null;
						upgradeInventoryUI = upgradeInventoryUI3;
						if (flag32)
						{
							break;
						}
						if (num6 >= list10._size)
						{
							GameObject gameObject7 = UnityEngine.Object.Instantiate(itemContainerPrefab, itemParent);
							bool flag33 = (object)gameObject7 == null;
							upgradeInventoryUI = (UpgradeInventoryUI)(object)itemContainerPrefab;
							if (flag33)
							{
								break;
							}
							InventoryItemPrefabUI component4 = gameObject7.GetComponent<InventoryItemPrefabUI>();
							itemContainers.Add(component4);
							list9 = list3;
							list4 = (List<System.Int32Enum>)(object)itemContainers;
						}
						bool flag34 = itemContainers == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)itemContainers;
						if (flag34)
						{
							break;
						}
						InventoryItemPrefabUI inventoryItemPrefabUI10 = itemContainers.get_Item(num6);
						bool flag35 = (object)inventoryItemPrefabUI10 == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)itemContainers;
						if (flag35)
						{
							break;
						}
						GameObject gameObject8 = inventoryItemPrefabUI10.gameObject;
						bool flag36 = (object)gameObject8 == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)inventoryItemPrefabUI10;
						if (flag36)
						{
							break;
						}
						gameObject8.SetActive(value: true);
						bool flag37 = itemContainers == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)itemContainers;
						if (flag37)
						{
							break;
						}
						InventoryItemPrefabUI inventoryItemPrefabUI11 = itemContainers.get_Item(num6);
						EItem item2 = ((List<EItem>)(object)list9).get_Item(num6);
						bool flag38 = (object)inventoryItemPrefabUI11 == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)list9;
						if (flag38)
						{
							break;
						}
						inventoryItemPrefabUI11.SetItem(item2);
						num6++;
						num7 = num6;
						upgradeInventoryUI3 = (UpgradeInventoryUI)(object)inventoryItemPrefabUI11;
						continue;
					}
					if (banishedItemsParent != null)
					{
						if (RunUnlockables.banishedItems != null)
						{
							upgradeInventoryUI = (UpgradeInventoryUI)(object)RunUnlockables.banishedItems;
							if (RunUnlockables.banishedItems == null)
							{
								break;
							}
							if ((object)upgradeInventoryUI.itemContainerPrefab != null)
							{
								bool flag39 = (object)banishedItemsParent == null;
								upgradeInventoryUI = (UpgradeInventoryUI)(object)banishedItemsParent;
								if (flag39)
								{
									break;
								}
								GameObject gameObject9 = banishedItemsParent.gameObject;
								bool flag40 = (object)gameObject9 == null;
								upgradeInventoryUI = (UpgradeInventoryUI)(object)banishedItemsParent;
								if (flag40)
								{
									break;
								}
								gameObject9.SetActive(value: true);
								bool flag41 = banishedItemContainers == null;
								upgradeInventoryUI = (UpgradeInventoryUI)(object)gameObject9;
								if (flag41)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
								while (enumerator.MoveNext())
								{
									if ((object)component3 != null)
									{
										GameObject gameObject10 = component3.gameObject;
										if ((object)gameObject10 != null)
										{
											gameObject10.SetActive(value: false);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								((List<InventoryItemPrefabUI>.Enumerator*)(&enumerator))->Dispose();
								upgradeInventoryUI = (UpgradeInventoryUI)(&enumerator);
								if (RunUnlockables.banishedItems == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
								int num9 = 0;
								while (enumerator2.MoveNext())
								{
									List<InventoryItemPrefabUI> list11 = banishedItemContainers;
									bool flag42 = banishedItemContainers == null;
									GameObject gameObject11 = (GameObject)(&enumerator2);
									if (!flag42)
									{
										if (num9 >= list11._size)
										{
											GameObject gameObject12 = UnityEngine.Object.Instantiate(itemContainerPrefab, banishedItemsParent);
											if ((object)gameObject12 == null)
											{
												throw new NullReferenceException();
											}
											InventoryItemPrefabUI component5 = gameObject12.GetComponent<InventoryItemPrefabUI>();
											banishedItemContainers.Add(component5);
										}
										if (banishedItemContainers != null)
										{
											InventoryItemPrefabUI inventoryItemPrefabUI12 = banishedItemContainers.get_Item(num9);
											if ((object)inventoryItemPrefabUI12 != null)
											{
												GameObject gameObject13 = inventoryItemPrefabUI12.gameObject;
												if ((object)gameObject13 != null)
												{
													gameObject13.SetActive(value: true);
													if (banishedItemContainers != null)
													{
														InventoryItemPrefabUI inventoryItemPrefabUI13 = banishedItemContainers.get_Item(num9);
														if ((object)inventoryItemPrefabUI13 != null)
														{
															inventoryItemPrefabUI13.SetItem((UnlockableBase)(object)component3);
															if (banishedItemContainers != null)
															{
																InventoryItemPrefabUI inventoryItemPrefabUI14 = banishedItemContainers.get_Item(num9);
																if ((object)inventoryItemPrefabUI14 != null)
																{
																	inventoryItemPrefabUI14.SetBanished();
																	num9++;
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
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								((HashSet<ItemData>.Enumerator*)(&enumerator2))->Dispose();
								goto IL_1000;
							}
						}
						bool flag43 = (object)banishedItemsParent == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)banishedItemsParent;
						if (flag43)
						{
							break;
						}
						GameObject gameObject14 = banishedItemsParent.gameObject;
						bool flag44 = (object)gameObject14 == null;
						upgradeInventoryUI = (UpgradeInventoryUI)(object)banishedItemsParent;
						if (flag44)
						{
							break;
						}
						gameObject14.SetActive(value: false);
					}
					goto IL_1000;
					IL_1000:
					Transform root = base.transform;
					UiUtility.RebuildUi(root);
					Invoke("Rebuild", 0.01f);
					return;
				}
			}
		}
		goto IL_1029;
		IL_1029:
		throw new NullReferenceException();
	}

	private void Rebuild()
	{
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
	}

	public UpgradeInventoryUI()
	{
		List<InventoryItemPrefabUI> list = new List<InventoryItemPrefabUI>();
		weaponContainers = list;
		tomeContainers = new List<InventoryItemPrefabUI>();
		itemContainers = new List<InventoryItemPrefabUI>();
		banishedItemContainers = new List<InventoryItemPrefabUI>();
		base._002Ector();
	}
}
