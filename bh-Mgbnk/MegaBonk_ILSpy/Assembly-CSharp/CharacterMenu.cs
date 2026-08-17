using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : Window
{
	public BackEscape windowBackEscape;

	public static ECharacter selectedCharacter = ECharacter.Amog;

	public Transform characterGridParent;

	public GameObject characterPrefabUi;

	public MyButton b_confirm;

	public MyButton b_purchase;

	public MyButton b_back;

	public MyButton b_hatPrev;

	private List<MyButtonCharacter> characterButtons;

	public SkinSelection skinSelection;

	public GameObject hatSelection;

	public MyButton b_hats;

	private MyButtonCharacter selectedButton;

	public MainMenu mainMenu;

	public UnlocksUi shopUi;

	public new void FocusWindow()
	{
		TryInit();
		base.FocusWindow();
	}

	private new void Awake()
	{
		base.Awake();
		TryInit();
	}

	private new void OnEnable()
	{
		//IL_0130: Expected I, but got O
		//IL_0038: Expected I, but got O
		base.OnEnable();
		nint num;
		if (selectedButton != null)
		{
			num = (nint)selectedButton;
			if ((object)selectedButton == null)
			{
				goto IL_010b;
			}
			Action a_DataLoaded = DataManager.A_DataLoaded;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v117 @ rax_v21 (System.Action)+188] (should have been resolved before IL gen)");
		}
		nint num2 = (nint)typeof(DataManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v6 (Il2CppClass<DataManager>)+B8]");
		num = 0;
		DataManager instance = DataManager.Instance;
		if ((object)DataManager.Instance != null && instance.unsortedHats != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			UnlockableBase unlockable = default(UnlockableBase);
			bool active;
			while (true)
			{
				if (enumerator.MoveNext())
				{
					if (MyAchievements.IsPurchased(unlockable))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						active = true;
						break;
					}
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				active = false;
				break;
			}
			if ((object)hatSelection != null)
			{
				hatSelection.SetActive(active);
				return;
			}
		}
		goto IL_010b;
		IL_010b:
		throw new NullReferenceException();
	}

	private unsafe void TryInit()
	{
		//IL_0042: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00ef: Expected O, but got I
		//IL_010b: Expected O, but got I4
		//IL_0129: Expected O, but got I
		//IL_0bf6: Expected O, but got Ref
		//IL_019e: Expected O, but got Ref
		//IL_01a6: Expected O, but got Ref
		//IL_01d7: Expected O, but got Ref
		//IL_029c: Expected O, but got Ref
		//IL_02d2: Expected O, but got Ref
		//IL_022c: Expected O, but got Ref
		//IL_0333: Expected I, but got O
		//IL_033b: Expected O, but got Ref
		//IL_06eb: Expected O, but got Ref
		//IL_0389: Expected O, but got Ref
		//IL_0936: Expected O, but got I4
		//IL_0954: Expected I, but got O
		//IL_0959: Expected I, but got O
		//IL_0711: Expected O, but got I
		//IL_074e: Expected O, but got Ref
		//IL_03b7: Expected I, but got O
		//IL_099a: Expected O, but got I4
		//IL_09b8: Expected I, but got O
		//IL_09bd: Expected I, but got O
		//IL_05d6: Expected O, but got I4
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_0a50: Expected O, but got I4
		//IL_0a6e: Expected I, but got O
		//IL_0a73: Expected I, but got O
		//IL_077c: Expected I, but got O
		//IL_07cb: Expected O, but got Ref
		//IL_065a: Expected I, but got O
		//IL_0ab4: Expected O, but got I4
		//IL_0ad2: Expected I, but got O
		//IL_0ad7: Expected I, but got O
		//IL_0820: Expected O, but got Ref
		//IL_0875: Expected O, but got Ref
		//IL_08b9: Expected O, but got I4
		if (characterButtons != null)
		{
			return;
		}
		List<MyButtonCharacter> list = (characterButtons = new List<MyButtonCharacter>());
		GameObject gameObject = characterPrefabUi;
		bool flag = (object)characterPrefabUi == null;
		List<object>.Enumerator enumerator = (List<object>.Enumerator)0;
		List<MyButtonCharacter> list2 = list;
		nint num = default(nint);
		nint num7;
		if (!flag)
		{
			list2 = characterButtons;
			MyButtonCharacter component = characterPrefabUi.GetComponent<MyButtonCharacter>();
			bool flag2 = characterButtons == null;
			enumerator = (List<object>.Enumerator)0;
			if (!flag2)
			{
				characterButtons.Add(component);
				gameObject = (GameObject)(object)DataManager.Instance;
				bool flag3 = (object)DataManager.Instance == null;
				enumerator = (List<object>.Enumerator)0;
				num = 0;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rcx_v18 (UnityEngine.GameObject)+30]");
					List<object> list3 = Enumerable.ToList((IEnumerable<object>)0);
					bool flag4 = list3 == null;
					enumerator = (List<object>.Enumerator)0;
					num = 0;
					list2 = (List<MyButtonCharacter>)(object)list3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rcx_v18 (UnityEngine.GameObject)+30]");
					gameObject = (GameObject)0;
					if (!flag4)
					{
						list3.Sort();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						int num2 = 0;
						nint num3 = 0;
						List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
						int num5 = default(int);
						List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
						while (enumerator2.MoveNext())
						{
							List<MyButtonCharacter> list4 = characterButtons;
							bool flag5 = characterButtons == null;
							int num4 = num5;
							enumerator = enumerator3;
							nint num6 = num3;
							list2 = (List<MyButtonCharacter>)(&enumerator2);
							List<MyButtonCharacter> list5 = (List<MyButtonCharacter>)(&enumerator2);
							if (!flag5)
							{
								bool flag6 = num2 < list4._size;
								num6 = num3;
								list5 = (List<MyButtonCharacter>)(&enumerator2);
								if (!flag6)
								{
									GameObject gameObject2 = UnityEngine.Object.Instantiate(characterPrefabUi, characterGridParent);
									bool flag7 = (object)gameObject2 == null;
									num4 = num5;
									enumerator = enumerator3;
									num7 = 0;
									list2 = (List<MyButtonCharacter>)(&enumerator2);
									gameObject = characterPrefabUi;
									if (flag7)
									{
										num6 = num7;
										throw new NullReferenceException();
									}
									MyButtonCharacter component2 = gameObject2.GetComponent<MyButtonCharacter>();
									characterButtons.Add(component2);
									num6 = 0;
									list5 = characterButtons;
								}
								bool flag8 = num5 == 0;
								num4 = num5;
								enumerator = enumerator3;
								list2 = (List<MyButtonCharacter>)(&enumerator2);
								if (!flag8)
								{
									bool flag9 = (object)DataManager.Instance == null;
									num4 = num5;
									enumerator = enumerator3;
									list2 = (List<MyButtonCharacter>)(&enumerator2);
									list5 = (List<MyButtonCharacter>)(object)DataManager.Instance;
									if (!flag9)
									{
										DataManager instance = DataManager.Instance;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ stack_-68 (System.Int32)+50]");
										CharacterData characterData = instance.GetCharacterData(ECharacter.Fox);
										list5 = characterButtons;
										bool flag10 = characterButtons == null;
										num4 = num5;
										enumerator = enumerator3;
										num6 = unchecked((nint)null);
										list2 = (List<MyButtonCharacter>)(&enumerator2);
										if (!flag10)
										{
											MyButtonCharacter myButtonCharacter = characterButtons.get_Item(num2);
											bool flag11 = (object)myButtonCharacter == null;
											num4 = num5;
											enumerator = enumerator3;
											num6 = 0;
											list2 = (List<MyButtonCharacter>)(&enumerator2);
											if (!flag11)
											{
												myButtonCharacter.SetCharacter(characterData);
												num2++;
												num3 = unchecked((nint)null);
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
						((List<CharacterData>.Enumerator*)(&enumerator2))->Dispose();
						num2 = 0;
						num = num3;
						list2 = (List<MyButtonCharacter>)(&enumerator2);
						List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
						Action<MyButtonCharacter> action2 = default(Action<MyButtonCharacter>);
						object obj6 = default(object);
						Action<MyButtonCharacter> action3 = default(Action<MyButtonCharacter>);
						object obj8 = default(object);
						while (true)
						{
							int num4;
							nint num8;
							if (num2 < MyAchievements.fakeCharacters)
							{
								list2 = (List<MyButtonCharacter>)(object)characterPrefabUi;
								GameObject gameObject3 = UnityEngine.Object.Instantiate(characterPrefabUi, characterGridParent);
								bool flag12 = (object)gameObject3 == null;
								num4 = num5;
								enumerator = enumerator3;
								num = 0;
								gameObject = characterPrefabUi;
								if (flag12)
								{
									break;
								}
								MyButtonCharacter component3 = gameObject3.GetComponent<MyButtonCharacter>();
								List<object> list6 = (List<object>)(object)characterButtons;
								bool flag13 = characterButtons == null;
								num4 = num5;
								enumerator = enumerator3;
								num = 0;
								list2 = (List<MyButtonCharacter>)(object)component3;
								gameObject = (GameObject)(object)characterButtons;
								if (flag13)
								{
									break;
								}
								int version = list6._version + 1;
								list6._version = version;
								object[] items = list6._items;
								bool flag14 = list6._items == null;
								num4 = num5;
								enumerator = enumerator3;
								num = 0;
								list2 = (List<MyButtonCharacter>)(object)component3;
								gameObject = (GameObject)(object)characterButtons;
								if (flag14)
								{
									break;
								}
								nint num6 = list6._size;
								if (list6._size >= items.Length)
								{
									((List<object>)(object)characterButtons).AddWithResize((object)component3);
									num = 0;
									gameObject = (GameObject)(object)characterButtons;
								}
								else
								{
									int size = list6._size + 1;
									list6._size = size;
									bool flag15 = list6._size >= items.Length;
									num4 = num5;
									enumerator = enumerator3;
									list2 = (List<MyButtonCharacter>)(object)component3;
									if (flag15)
									{
										num8 = num6;
										throw new IndexOutOfRangeException();
									}
									items[num6] = component3;
									object obj = list6._size + 4;
									object obj2 = obj * 8;
									gameObject = (GameObject)(object)((object)list6._items + obj2);
									num = list6._size;
								}
								bool flag16 = (object)component3 == null;
								num4 = num5;
								enumerator = enumerator3;
								list2 = (List<MyButtonCharacter>)(object)component3;
								if (flag16)
								{
									break;
								}
								component3.SetCharacter(null);
								num2++;
								num = unchecked((nint)null);
								list2 = (List<MyButtonCharacter>)(object)component3;
								continue;
							}
							FindAllButtonsInWindow();
							SetupButtonNavigation();
							bool flag17 = characterButtons == null;
							num4 = num5;
							enumerator = enumerator3;
							if (flag17)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
							Action<MyButtonCharacter> action;
							nint num9;
							while (true)
							{
								if (enumerator4.MoveNext())
								{
									bool flag18 = num5 == 0;
									num4 = num5;
									enumerator = enumerator3;
									num9 = num5;
									num8 = 0;
									list2 = (List<MyButtonCharacter>)(&enumerator4);
									nint num10 = (nint)(&enumerator4);
									if (!flag18)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ stack_-68 (System.Int32)+90]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ stack_-68 (System.Int32)+90]");
										bool flag19 = (nint)0 == 0;
										num4 = num5;
										enumerator = enumerator3;
										num2 = num5;
										num8 = 0;
										list2 = (List<MyButtonCharacter>)(&enumerator4);
										num10 = (nint)(&enumerator4);
										if (!flag19)
										{
											nint num11 = (nint)typeof(SaveManager);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1400 @ rax_v86 (Il2CppClass<SaveManager>)+B8]");
											num10 = 0;
											SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
											bool flag20 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
											num4 = num5;
											enumerator = enumerator3;
											num2 = num5;
											num8 = 0;
											list2 = (List<MyButtonCharacter>)(&enumerator4);
											if (!flag20)
											{
												ConfigSaveFile config = saveManager.config;
												bool flag21 = saveManager.config == null;
												num4 = num5;
												enumerator = enumerator3;
												num2 = num5;
												num8 = 0;
												list2 = (List<MyButtonCharacter>)(&enumerator4);
												if (!flag21)
												{
													Preferences preferences = config.preferences;
													bool flag22 = config.preferences == null;
													num4 = num5;
													enumerator = enumerator3;
													num2 = num5;
													num8 = 0;
													list2 = (List<MyButtonCharacter>)(&enumerator4);
													if (!flag22)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v82+50]");
														if ((nint)0 == (nint)preferences.selectedCharacter)
														{
															startBtn = (MyButton)num5;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
															action = null;
															break;
														}
														continue;
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										num9 = num2;
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
								action = null;
								break;
							}
							Action<MyButtonCharacter> b = OnSelectCharacter;
							Delegate obj4 = Delegate.Combine(MyButtonCharacter.A_Select, b);
							object obj5;
							if ((object)obj4 == null)
							{
								MyButtonCharacter.A_Select = action;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
								bool flag23 = action2 == null;
								obj5 = 0;
								num4 = num5;
								enumerator = enumerator3;
								num9 = (nint)typeof(Action<MyButtonCharacter>);
								num8 = unchecked((nint)null);
								list2 = (List<MyButtonCharacter>)(object)obj4;
								if (flag23)
								{
									goto IL_0c71;
								}
								MyButtonCharacter.A_Select = action2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
								bool flag24 = obj6 == null;
								obj5 = 0;
								num4 = num5;
								enumerator = enumerator3;
								num9 = (nint)typeof(Action<MyButtonCharacter>);
								num8 = unchecked((nint)null);
								list2 = (List<MyButtonCharacter>)(object)obj4;
								if (flag24)
								{
									goto IL_0c7c;
								}
							}
							Action<MyButtonCharacter> b2 = OnConfirmCharacter;
							Delegate obj7 = Delegate.Combine(MyButtonCharacter.A_Confirm, b2);
							if ((object)obj7 == null)
							{
								MyButtonCharacter.A_Confirm = action;
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							bool flag25 = action3 == null;
							obj5 = 0;
							num4 = num5;
							enumerator = enumerator3;
							num9 = (nint)typeof(Action<MyButtonCharacter>);
							num8 = unchecked((nint)null);
							list2 = (List<MyButtonCharacter>)(object)obj7;
							if (!flag25)
							{
								MyButtonCharacter.A_Confirm = action3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
								bool flag26 = obj8 == null;
								obj5 = 0;
								num4 = num5;
								enumerator = enumerator3;
								num9 = (nint)typeof(Action<MyButtonCharacter>);
								num8 = unchecked((nint)null);
								list2 = (List<MyButtonCharacter>)(object)obj7;
								if (!flag26)
								{
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							goto IL_0c7c;
							IL_0c7c:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							goto IL_0c71;
							IL_0c71:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							return;
						}
					}
				}
			}
		}
		num7 = num;
		throw new NullReferenceException();
	}

	private void SetupButtonNavigation()
	{
		//IL_003d: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected I4, but got Unknown
		//IL_0117: Expected I4, but got I8
		//IL_0417: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected I4, but got Unknown
		//IL_026f: Expected O, but got I4
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		_ = 0;
		List<MyButtonCharacter> list = characterButtons;
		_ = 0;
		_ = 0;
		int num = 0;
		object obj10 = default(object);
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			_ = 0;
			object obj = num - 4;
			_ = 0;
			_ = 4;
			_ = 0;
			int num6;
			object obj4;
			if ((nint)obj < 0)
			{
				int num3 = num >> 31;
				int num4 = num3 & 3;
				object obj2 = num + num4;
				object obj3 = obj2 & 3;
				int num5 = obj3 - num4;
				num6 = num5;
				obj4 = obj2;
			}
			else
			{
				int index = num - 4;
				MyButtonCharacter myButtonCharacter = characterButtons.get_Item(index);
				Button button = myButtonCharacter.GetButton();
				num6 = (int)(num & 0x80000003L);
				if ((nint)myButtonCharacter < 0)
				{
					object obj5 = num6 - 1;
					object obj6 = obj5 | -4;
					num6 = obj6 + 1;
				}
				int num7 = num >> 31;
				int num8 = num7 & 3;
				obj4 = num8 + num;
			}
			object obj7 = obj4 >> 2;
			List<MyButtonCharacter> list2 = characterButtons;
			object obj8 = num + 4;
			if ((nint)obj8 < list2._size)
			{
				int index2 = num + 4;
				MyButtonCharacter myButtonCharacter2 = characterButtons.get_Item(index2);
				Button button2 = myButtonCharacter2.GetButton();
			}
			if (num6 > 0)
			{
				int index3 = num - 1;
				MyButtonCharacter myButtonCharacter3 = characterButtons.get_Item(index3);
				Button button3 = myButtonCharacter3.GetButton();
				if (num6 >= 3)
				{
					goto IL_02ce;
				}
			}
			List<MyButtonCharacter> list3 = characterButtons;
			object obj9 = num + 1;
			if ((nint)obj9 < list3._size)
			{
				int index4 = num + 1;
				MyButtonCharacter myButtonCharacter4 = list3.get_Item(index4);
				Button button4 = myButtonCharacter4.GetButton();
			}
			goto IL_02ce;
			IL_02ce:
			if (obj7 == null)
			{
				Button button5 = b_back.GetButton();
			}
			MyButtonCharacter myButtonCharacter5 = characterButtons.get_Item(num);
			Button button6 = myButtonCharacter5.GetButton();
			Navigation navigation = (Navigation)(obj10 - 48);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-50]");
			_ = 0;
			button6.navigation = navigation;
			list = characterButtons;
			num++;
		}
	}

	private unsafe void OnSelectCharacter(MyButtonCharacter characterButton)
	{
		//IL_0060: Expected O, but got Ref
		Button button = b_confirm.GetButton();
		Button button2 = characterButton.GetButton();
		Button button3 = b_hats.GetButton();
		Button button4 = b_confirm.GetButton();
		object obj = default(object);
		button4.navigation = (Navigation)(&obj);
		BackEscape backEscape = windowBackEscape;
		backEscape.enabled = true;
		selectedButton = characterButton;
		GameObject gameObject = b_purchase.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = b_confirm.gameObject;
		gameObject2.SetActive(value: true);
		if (MyAchievements.IsUnlocked(characterButton.characterData, out var _))
		{
			if (MyAchievements.IsPurchased(characterButton.characterData))
			{
				MyButton myButton = b_confirm;
				myButton.state = MyButton.EButtonState.Active;
				myButton.RefreshState();
			}
			else
			{
				GameObject gameObject3 = b_purchase.gameObject;
				gameObject3.SetActive(value: true);
				GameObject gameObject4 = b_confirm.gameObject;
				gameObject4.SetActive(value: false);
			}
			CharacterData characterData = characterButton.characterData;
			selectedCharacter = characterData.eCharacter;
		}
		else
		{
			MyButton myButton2 = b_confirm;
			myButton2.state = MyButton.EButtonState.Inactive;
			myButton2.RefreshState();
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		Preferences preferences = config.preferences;
		preferences.selectedCharacter = selectedCharacter;
	}

	private unsafe void DisableNavigationStatWindow()
	{
		//IL_0035: Expected O, but got Ref
		Button button = b_confirm.GetButton();
		Button button2 = b_confirm.GetButton();
		object obj = default(object);
		button2.navigation = (Navigation)(&obj);
	}

	private unsafe void EnableNavigationStatWindow()
	{
		//IL_005d: Expected O, but got Ref
		Button button = b_confirm.GetButton();
		Button button2 = selectedButton.GetButton();
		Button button3 = b_hatPrev.GetButton();
		Button button4 = b_confirm.GetButton();
		object obj = default(object);
		button4.navigation = (Navigation)(&obj);
		Button button5 = selectedButton.GetButton();
		skinSelection.EnableNavigation(button5);
	}

	private unsafe void OnConfirmCharacter(MyButtonCharacter characterButton)
	{
		//IL_0103: Expected O, but got Ref
		//IL_0103: Expected O, but got Ref
		if (characterButton.canUseCharacter)
		{
			GameObject gameObject = b_purchase.gameObject;
			MyButton btn = (gameObject.activeInHierarchy ? b_purchase : b_confirm);
			ButtonManager.ForceHoverButton(btn);
			characterButton.StartHover();
			BackEscape backEscape = windowBackEscape;
			backEscape.enabled = false;
			selectedButton = characterButton;
		}
		else
		{
			AlwaysUi instance = AlwaysUi.Instance;
			Transform transform = characterButton.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			object obj2 = default(object);
			float desiredScale = default(float);
			instance.UiTextPopup.SetText(characterButton.cantUseCharacterReason, (Vector3)(&obj), (Color)(&obj2), desiredScale);
		}
	}

	public void BuyCharacter()
	{
		mainMenu.GoToUnlocks();
		MyButtonCharacter myButtonCharacter = selectedButton;
		shopUi.FocusCharacterPurchase(myButtonCharacter.characterData);
	}

	private new void Update()
	{
		if (MyInputManager.GetButtonDown(MyInputManager.UICancel))
		{
			BackEscape backEscape = windowBackEscape;
			if (!backEscape.enabled)
			{
				ButtonManager.ForceHoverButton(selectedButton);
			}
		}
	}

	private new void OnDisable()
	{
		base.OnDisable();
		savedBtn = selectedButton;
	}

	private new void OnDestroy()
	{
		//IL_01e3: Expected O, but got I4
		//IL_01ec: Expected O, but got I4
		//IL_01fa: Expected I, but got O
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00b6: Expected I, but got O
		//IL_0149: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0160: Expected I, but got O
		//IL_01a1: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_01b8: Expected I, but got O
		base.OnDestroy();
		Action<MyButtonCharacter> value = OnSelectCharacter;
		Delegate obj = Delegate.Remove(MyButtonCharacter.A_Select, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonCharacter.A_Select = (Action<MyButtonCharacter>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButtonCharacter> action = default(Action<MyButtonCharacter>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<MyButtonCharacter>);
				goto IL_0236;
			}
			MyButtonCharacter.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			num2 = (nint)typeof(Action<MyButtonCharacter>);
			if (flag)
			{
				goto IL_021b;
			}
		}
		Action<MyButtonCharacter> value2 = OnConfirmCharacter;
		Delegate obj6 = Delegate.Remove(MyButtonCharacter.A_Confirm, value2);
		if ((object)obj6 == null)
		{
			MyButtonCharacter.A_Confirm = (Action<MyButtonCharacter>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButtonCharacter> action2 = default(Action<MyButtonCharacter>);
		bool flag2 = action2 == null;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		num2 = (nint)typeof(Action<MyButtonCharacter>);
		if (flag2)
		{
			goto IL_0226;
		}
		MyButtonCharacter.A_Confirm = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		num = (nint)typeof(Action<MyButtonCharacter>);
		if (!flag3)
		{
			return;
		}
		goto IL_0236;
		IL_021b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0236:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0226;
		IL_0226:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_021b;
	}
}
