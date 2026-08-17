using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.UI.InGame.Rewards;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class MicrowaveUi : BaseEncounterWindow
{
	public GameObject itemPrefab;

	private List<MicrowaveItemButton> itemPrefabs;

	public TextMeshProUGUI t_price;

	public unsafe override void Open(EEncounter encounterType)
	{
		//IL_0163: Expected O, but got I
		//IL_017f: Expected O, but got I
		//IL_019f: Expected O, but got I
		//IL_06da: Expected O, but got Ref
		//IL_01e9: Expected I4, but got O
		//IL_0730: Expected O, but got Ref
		//IL_0752: Expected O, but got Ref
		//IL_0261: Expected I4, but got O
		//IL_02e4: Expected I, but got O
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		Component component = this;
		if (!flag)
		{
			gameObject.SetActive(value: true);
			component = InteractableMicrowave.currentlyInteracting;
			if ((object)InteractableMicrowave.currentlyInteracting != null)
			{
				if (itemPrefabs != null)
				{
					goto IL_00c8;
				}
				List<MicrowaveItemButton> list = new List<MicrowaveItemButton>();
				itemPrefabs = list;
				bool flag2 = (object)itemPrefab == null;
				component = (Component)(object)itemPrefab;
				if (!flag2)
				{
					MicrowaveItemButton component2 = itemPrefab.GetComponent<MicrowaveItemButton>();
					bool flag3 = itemPrefabs == null;
					component = (Component)(object)itemPrefab;
					if (!flag3)
					{
						itemPrefabs.Add(component2);
						goto IL_00c8;
					}
				}
			}
		}
		goto IL_05da;
		IL_05da:
		throw new NullReferenceException();
		IL_00c8:
		List<EItem> list2 = new List<EItem>();
		component = (Component)(object)list2;
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				component = (Component)(object)inventory.itemInventory;
				if (inventory.itemInventory != null)
				{
					bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					component = (Component)(nint)((UnityEngine.Object)component).m_CachedPtr;
					if (!flag4)
					{
						Dictionary<EItem, ItemBase>.KeyCollection keys = ((Dictionary<EItem, ItemBase>)(nint)((UnityEngine.Object)component).m_CachedPtr).Keys;
						bool flag5 = keys == null;
						component = (Component)(nint)((UnityEngine.Object)component).m_CachedPtr;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
							Dictionary<EItem, ItemBase>.KeyCollection.Enumerator enumerator = default(Dictionary<EItem, ItemBase>.KeyCollection.Enumerator);
							Component component3 = default(Component);
							while (enumerator.MoveNext())
							{
								if ((object)DataManager.Instance != null)
								{
									ItemData item = DataManager.Instance.GetItem((EItem)component3);
									if ((object)item != null)
									{
										EItemRarity rarity = item.rarity;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v9 (UnityEngine.Component)+80]");
										if ((nint)rarity == (nint)0)
										{
											if (list2 == null)
											{
												throw new NullReferenceException();
											}
											list2.Add((EItem)component3);
										}
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							enumerator.Dispose();
							bool flag6 = itemPrefabs == null;
							component = (Component)(&enumerator);
							if (!flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
								nint num = 0;
								List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
								while (enumerator2.MoveNext())
								{
									if ((object)component3 != null)
									{
										GameObject gameObject2 = component3.gameObject;
										if ((object)gameObject2 != null)
										{
											gameObject2.SetActive(value: false);
											num = unchecked((nint)null);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								((List<MicrowaveItemButton>.Enumerator*)(&enumerator2))->Dispose();
								bool flag7 = list2 == null;
								component = (Component)(&enumerator2);
								int num2 = 0;
								EItem eItem = (EItem)num;
								int num3 = 0;
								Component component4 = (Component)(&enumerator2);
								if (!flag7)
								{
									object arg = default(object);
									while (true)
									{
										int num4 = num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v25 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+18]");
										if ((nint)num4 < (nint)0)
										{
											List<MicrowaveItemButton> list3 = itemPrefabs;
											bool flag8 = itemPrefabs == null;
											component = component4;
											if (flag8)
											{
												break;
											}
											if (list3._size <= num2)
											{
												bool flag9 = (object)itemPrefab == null;
												component = (Component)(object)itemPrefab;
												if (flag9)
												{
													break;
												}
												Transform transform = itemPrefab.transform;
												bool flag10 = (object)transform == null;
												component = (Component)(object)itemPrefab;
												if (flag10)
												{
													break;
												}
												Transform parent = transform.parent;
												GameObject gameObject3 = UnityEngine.Object.Instantiate(itemPrefab, parent);
												bool flag11 = (object)gameObject3 == null;
												component = (Component)(object)itemPrefab;
												if (flag11)
												{
													break;
												}
												MicrowaveItemButton component5 = gameObject3.GetComponent<MicrowaveItemButton>();
												bool flag12 = itemPrefabs == null;
												component = (Component)(object)itemPrefabs;
												if (flag12)
												{
													break;
												}
												itemPrefabs.Add(component5);
											}
											bool flag13 = itemPrefabs == null;
											component = (Component)(object)itemPrefabs;
											if (flag13)
											{
												break;
											}
											MicrowaveItemButton microwaveItemButton = itemPrefabs.get_Item(num2);
											bool flag14 = (object)microwaveItemButton == null;
											component = (Component)(object)itemPrefabs;
											if (flag14)
											{
												break;
											}
											GameObject gameObject4 = microwaveItemButton.gameObject;
											bool flag15 = (object)gameObject4 == null;
											component = microwaveItemButton;
											if (flag15)
											{
												break;
											}
											gameObject4.SetActive(value: true);
											bool flag16 = itemPrefabs == null;
											component = (Component)(object)itemPrefabs;
											if (flag16)
											{
												break;
											}
											MicrowaveItemButton microwaveItemButton2 = itemPrefabs.get_Item(num2);
											EItem eItem2 = list2.get_Item(num2);
											bool flag17 = (object)microwaveItemButton2 == null;
											component = (Component)(object)list2;
											if (flag17)
											{
												break;
											}
											microwaveItemButton2.Set(this, eItem2);
											num2++;
											eItem = eItem2;
											num3 = num2;
											component4 = microwaveItemButton2;
											continue;
										}
										int price = InteractableMicrowave.currentlyInteracting.GetPrice();
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
										string text = $"<size=110%><sprite name=gold></size> {arg}";
										t_price.text = text;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05da;
	}

	private void Update()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy && MyInputManager.GetButtonDown(MyInputManager.UICancel))
		{
			UiManager instance = UiManager.Instance;
			instance.encounterWindows.RewardFinished();
		}
	}

	public void SelectUpgrade(EItem eItem)
	{
		InteractableMicrowave.currentlyInteracting.UseMicrowave(eItem);
		UiManager instance = UiManager.Instance;
		instance.encounterWindows.RewardFinished();
	}

	public void CloseScreen()
	{
		UiManager instance = UiManager.Instance;
		instance.encounterWindows.RewardFinished();
	}

	public override void OnClose()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public override void ChooseOffer(int index)
	{
	}
}
