using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class QuestsWindowNew : Window
{
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public EAchievementType type;

		internal bool _003CCreateTabs_003Eb__1(MyAchievement a)
		{
			//IL_008b: Expected I4, but got O
			if ((object)a != null)
			{
				if (a.achievementType == type && a.isEnabled)
				{
					return a.IsVisible();
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public Button backBtn;

	public GameObject questPrefab;

	public GameObject tabPrefab;

	public ButtonNavigationSelectionOnly tabNavigation;

	public TabVerticalNavigation tabVertNavigation;

	public LocalizedString localizedGeneral;

	public LocalizedString localizedCharacters;

	public LocalizedString localizedWeapons;

	public LocalizedString localizedChallenges;

	public LocalizedString localizedItems;

	public LocalizedString localizedTomes;

	public LocalizedString localizedSkins;

	public LocalizedString localizedHats;

	private List<MyButtonQuest> questButtons;

	private EAchievementType achievementTab;

	public RawImage progressBar;

	public TextMeshProUGUI t_totalProgress;

	public MyButtonToggle toggleHideCompleted;

	private List<EAchievementType> tabsEnums;

	private new void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x180575040\"");
	}

	private new void Start()
	{
		//IL_0149: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_0244: Expected I, but got O
		//IL_024d: Expected O, but got I4
		//IL_0218: Expected I, but got O
		//IL_029c: Expected I, but got O
		//IL_02aa: Expected I, but got O
		//IL_02b3: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		//IL_03af: Expected I, but got O
		//IL_03b8: Expected O, but got I4
		//IL_0383: Expected I, but got O
		//IL_0413: Expected I, but got O
		//IL_0421: Expected I, but got O
		//IL_042a: Expected O, but got I4
		//IL_0475: Expected O, but got I4
		//IL_0526: Expected I, but got O
		//IL_052f: Expected O, but got I4
		//IL_04fa: Expected I, but got O
		//IL_058a: Expected I, but got O
		//IL_0598: Expected I, but got O
		//IL_05a1: Expected O, but got I4
		//IL_0741: Expected O, but got I4
		//IL_05f7: Expected O, but got I4
		//IL_0648: Expected O, but got I4
		base.Start();
		MyButtonToggle myButtonToggle = toggleHideCompleted;
		achievementTab = EAchievementType.Characters;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		Delegate obj6;
		nint num4;
		nint num2;
		object obj;
		bool flag2;
		MyButtonToggle myButtonToggle2;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				ConfigSettingsExtra otherSettings = config.otherSettings;
				if (config.otherSettings != null && (object)toggleHideCompleted != null && (object)myButtonToggle.toggleIcon != null)
				{
					myButtonToggle.toggleIcon.SetActive(otherSettings.hideCompletedQuests);
					Refresh();
					bool flag = (object)tabNavigation == null;
					flag2 = false;
					if (!flag)
					{
						tabNavigation.ButtonPressed(0, force: true);
						bool flag3 = (object)tabNavigation == null;
						obj = 0;
						flag2 = true;
						if (!flag3)
						{
							Button selectedButton = tabNavigation.GetSelectedButton();
							bool flag4 = (object)tabVertNavigation == null;
							obj = 0;
							flag2 = true;
							myButtonToggle = (MyButtonToggle)(object)tabVertNavigation;
							if (!flag4)
							{
								tabVertNavigation.Set(selectedButton);
								Action<MyButtonQuest> b = OnQuestButtonHover;
								Delegate obj2 = Delegate.Combine(MyButtonQuest.A_Hover, b);
								nint num;
								if ((object)obj2 == null)
								{
									MyButtonQuest.A_Hover = (Action<MyButtonQuest>)obj2;
									num = (nint)MyButtonQuest.A_Hover;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									Action<MyButtonQuest> action = default(Action<MyButtonQuest>);
									bool flag5 = action == null;
									num2 = (nint)typeof(Action<MyButtonQuest>);
									obj = 0;
									flag2 = false;
									myButtonToggle = (MyButtonToggle)(object)obj2;
									if (flag5)
									{
										goto IL_06a7;
									}
									MyButtonQuest.A_Hover = action;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj3 = default(object);
									bool flag6 = obj3 == null;
									num = (nint)typeof(Action<MyButtonQuest>);
									num2 = (nint)typeof(Action<MyButtonQuest>);
									obj = 0;
									flag2 = false;
									myButtonToggle = (MyButtonToggle)(object)obj2;
									if (flag6)
									{
										goto IL_06b2;
									}
								}
								ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabNavigation;
								bool flag7 = (object)tabNavigation == null;
								num2 = num;
								obj = 0;
								flag2 = false;
								myButtonToggle = (MyButtonToggle)(object)obj2;
								if (!flag7)
								{
									Action<int> b2 = OnTabSelected;
									Delegate obj4 = Delegate.Combine(buttonNavigationSelectionOnly.A_ButtonSelected, b2);
									nint num3;
									if ((object)obj4 == null)
									{
										buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj4;
										num3 = (nint)buttonNavigationSelectionOnly.A_ButtonSelected;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
										Action<int> action2 = default(Action<int>);
										bool flag8 = action2 == null;
										num2 = (nint)typeof(Action<int>);
										obj = 0;
										flag2 = false;
										myButtonToggle = (MyButtonToggle)(object)obj4;
										myButtonToggle2 = (MyButtonToggle)(object)obj4;
										if (flag8)
										{
											goto IL_06c2;
										}
										buttonNavigationSelectionOnly.A_ButtonSelected = action2;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
										object obj5 = default(object);
										bool flag9 = obj5 == null;
										num3 = (nint)typeof(Action<int>);
										num2 = (nint)typeof(Action<int>);
										obj = 0;
										flag2 = false;
										myButtonToggle = (MyButtonToggle)(object)obj4;
										if (flag9)
										{
											goto IL_06d2;
										}
									}
									MyButtonToggle myButtonToggle3 = toggleHideCompleted;
									bool flag10 = (object)toggleHideCompleted == null;
									num2 = num3;
									obj = 0;
									flag2 = false;
									myButtonToggle = (MyButtonToggle)(object)obj4;
									if (!flag10)
									{
										Action<bool> b3 = OnToggle;
										obj6 = Delegate.Combine(myButtonToggle3.A_Toggled, b3);
										if ((object)obj6 == null)
										{
											myButtonToggle3.A_Toggled = (Action<bool>)obj6;
											num4 = (nint)myButtonToggle3.A_Toggled;
											goto IL_0717;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
										Action<bool> action3 = default(Action<bool>);
										bool flag11 = action3 == null;
										num2 = (nint)typeof(Action<bool>);
										obj = 0;
										flag2 = false;
										myButtonToggle = (MyButtonToggle)(object)obj6;
										MyButtonToggle myButtonToggle4 = (MyButtonToggle)(object)obj6;
										if (!flag11)
										{
											myButtonToggle3.A_Toggled = action3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											object obj7 = default(object);
											bool flag12 = obj7 == null;
											num4 = (nint)typeof(Action<bool>);
											num2 = (nint)typeof(Action<bool>);
											obj = 0;
											flag2 = false;
											myButtonToggle = (MyButtonToggle)(object)obj6;
											if (!flag12)
											{
												goto IL_0717;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
											myButtonToggle4 = myButtonToggle;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
										goto IL_06d2;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0676;
		IL_06a7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_06b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06a7;
		IL_0717:
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		bool flag13 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
		num2 = num4;
		obj = 0;
		flag2 = false;
		myButtonToggle = (MyButtonToggle)(object)obj6;
		if (!flag13)
		{
			ProgressionSaveFile progression = saveManager2.progression;
			bool flag14 = saveManager2.progression == null;
			num2 = num4;
			obj = 0;
			flag2 = false;
			myButtonToggle = (MyButtonToggle)(object)obj6;
			if (!flag14)
			{
				MenuMeta menuMeta = progression.menuMeta;
				bool flag15 = progression.menuMeta == null;
				num2 = num4;
				obj = 0;
				flag2 = false;
				myButtonToggle = (MyButtonToggle)(object)obj6;
				if (!flag15)
				{
					menuMeta.hasVisitedQuests = true;
					return;
				}
			}
		}
		goto IL_0676;
		IL_06c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06b2;
		IL_0676:
		throw new NullReferenceException();
		IL_06d2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		myButtonToggle2 = myButtonToggle;
		goto IL_06c2;
	}

	private new unsafe void OnEnable()
	{
		//IL_0092: Expected O, but got Ref
		//IL_00a0: Expected F4, but got I4
		//IL_00b8: Expected O, but got Ref
		base.OnEnable();
		Refresh();
		int num = MyAchievements.NumCompletedAchievements();
		int num2 = MyAchievements.NumTotalAchievements();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg:N0}/{arg2:N0}";
		t_totalProgress.text = text;
		int num3 = num / num2;
		Transform transform = progressBar.transform;
		int num4 = default(int);
		transform.localScale = (Vector3)(&num4);
		Color redToGreenGradient = MyColorUtility.GetRedToGreenGradient(num3);
		progressBar.color = (Color)(&num4);
	}

	private new void OnDestroy()
	{
		//IL_03bb: Expected O, but got I4
		//IL_03c4: Expected O, but got I4
		//IL_03d2: Expected I, but got O
		//IL_0049: Expected I, but got O
		//IL_00a5: Expected I, but got O
		//IL_00b6: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_00cd: Expected I, but got O
		//IL_0107: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		//IL_01ca: Expected I, but got O
		//IL_0184: Expected I, but got O
		//IL_0214: Expected I, but got O
		//IL_0225: Expected O, but got I4
		//IL_022e: Expected O, but got I4
		//IL_023c: Expected I, but got O
		//IL_0276: Expected O, but got I4
		//IL_027f: Expected O, but got I4
		//IL_0315: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_032c: Expected I, but got O
		//IL_0379: Expected O, but got I4
		//IL_0382: Expected O, but got I4
		//IL_0390: Expected I, but got O
		base.OnDestroy();
		Action<MyButtonQuest> value = OnQuestButtonHover;
		Delegate obj = Delegate.Remove(MyButtonQuest.A_Hover, value);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num;
		if ((object)obj == null)
		{
			MyButtonQuest.A_Hover = (Action<MyButtonQuest>)obj;
			num = (nint)MyButtonQuest.A_Hover;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButtonQuest> action = default(Action<MyButtonQuest>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				num2 = (nint)typeof(Action<MyButtonQuest>);
				goto IL_0452;
			}
			MyButtonQuest.A_Hover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num = (nint)typeof(Action<MyButtonQuest>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			nint num3 = (nint)typeof(Action<MyButtonQuest>);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabNavigation;
		bool flag2 = (object)tabNavigation == null;
		obj2 = obj;
		obj3 = 0;
		obj4 = 0;
		Delegate obj10;
		Delegate obj7;
		if (!flag2)
		{
			Action<int> value2 = OnTabSelected;
			Delegate obj6 = Delegate.Remove(buttonNavigationSelectionOnly.A_ButtonSelected, value2);
			if ((object)obj6 == null)
			{
				buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj6;
				num = (nint)buttonNavigationSelectionOnly.A_ButtonSelected;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<int> action2 = default(Action<int>);
				bool flag3 = action2 == null;
				obj2 = obj6;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<int>);
				obj7 = obj6;
				if (flag3)
				{
					goto IL_0412;
				}
				buttonNavigationSelectionOnly.A_ButtonSelected = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj8 = default(object);
				bool flag4 = obj8 == null;
				num = (nint)typeof(Action<int>);
				obj2 = obj6;
				obj3 = 0;
				obj4 = 0;
				num2 = (nint)typeof(Action<int>);
				if (flag4)
				{
					goto IL_0422;
				}
			}
			MyButtonToggle myButtonToggle = toggleHideCompleted;
			bool flag5 = (object)toggleHideCompleted == null;
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (!flag5)
			{
				Action<bool> value3 = OnToggle;
				Delegate obj9 = Delegate.Remove(myButtonToggle.A_Toggled, value3);
				if ((object)obj9 == null)
				{
					myButtonToggle.A_Toggled = (Action<bool>)obj9;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<bool> action3 = default(Action<bool>);
				bool flag6 = action3 == null;
				obj2 = obj9;
				obj3 = 0;
				obj4 = 0;
				num2 = (nint)typeof(Action<bool>);
				obj10 = obj9;
				if (flag6)
				{
					goto IL_0442;
				}
				myButtonToggle.A_Toggled = action3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj11 = default(object);
				bool flag7 = obj11 == null;
				obj2 = obj9;
				obj3 = 0;
				obj4 = 0;
				num2 = (nint)typeof(Action<bool>);
				if (!flag7)
				{
					return;
				}
				goto IL_0452;
			}
		}
		goto IL_03fe;
		IL_0452:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj10 = obj2;
		goto IL_0442;
		IL_0412:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03fe;
		IL_0442:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0422;
		IL_03fe:
		throw new NullReferenceException();
		IL_0422:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		obj7 = obj2;
		goto IL_0412;
	}

	private void OnToggle(bool on)
	{
		Refresh();
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		ConfigSettingsExtra otherSettings = config.otherSettings;
		otherSettings.hideCompletedQuests = on;
	}

	private unsafe void Refresh()
	{
		DataManager instance = DataManager.Instance;
		Func<MyAchievement, bool> predicate = delegate(MyAchievement a)
		{
			//IL_005e: Expected I4, but got O
			if ((object)a == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return a.achievementType == achievementTab && a.isEnabled;
		};
		IEnumerable<MyAchievement> source = Enumerable.Where(instance.unsortedAchievements, predicate);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		Comparison<MyAchievement> comparison = delegate(MyAchievement a, MyAchievement b)
		{
			//IL_01cd: Expected I4, but got O
			//IL_0061: Expected O, but got I4
			//IL_0041: Expected O, but got I4
			//IL_01ba: Expected I4, but got I8
			int num4;
			if ((object)a != null)
			{
				object obj;
				if (!a.IsUnlocked())
				{
					obj = 0;
				}
				else
				{
					bool flag = a.IsClaimed();
					obj = (flag ? 1 : 0) ^ 1;
				}
				if ((object)b != null)
				{
					bool flag2 = b.IsUnlocked();
					if (flag2)
					{
						bool flag3 = b.IsClaimed();
						flag2 = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
					}
					if ((nint)obj != (flag2 ? 1 : 0))
					{
						bool flag4 = obj == null;
						int result = 1;
						if (!flag4)
						{
							result = -1;
						}
						return result;
					}
					MyButtonToggle myButtonToggle = toggleHideCompleted;
					if ((object)toggleHideCompleted != null && (object)myButtonToggle.toggleIcon != null)
					{
						if (myButtonToggle.toggleIcon.activeInHierarchy)
						{
							bool flag5 = a.IsClaimed();
							bool value = b.IsClaimed();
							bool flag6 = default(bool);
							num4 = flag6.CompareTo(value);
							if (num4 != 0)
							{
								goto IL_0209;
							}
						}
						num4 = a.CompareTo(b);
						goto IL_0209;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
			IL_0209:
			return num4;
		};
		list.Sort((Comparison<object>)comparison);
		if (questButtons == null)
		{
			List<MyButtonQuest> list2 = new List<MyButtonQuest>();
			questButtons = list2;
			MyButtonQuest component = questPrefab.GetComponent<MyButtonQuest>();
			questButtons.Add(component);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component2 = default(Component);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component2 == null)
				{
					break;
				}
				GameObject gameObject = component2.gameObject;
				gameObject.SetActive(value: false);
				continue;
			}
			((List<MyButtonQuest>.Enumerator*)(&enumerator))->Dispose();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (num < list._size)
			{
				MyAchievement myAchievement = ((List<MyAchievement>)(object)list).get_Item(num2);
				if (myAchievement.IsVisible())
				{
					List<MyButtonQuest> list3 = questButtons;
					if (num3 >= list3._size)
					{
						Transform transform = questPrefab.transform;
						Transform parent = transform.parent;
						GameObject gameObject2 = UnityEngine.Object.Instantiate(questPrefab, parent);
						MyButtonQuest component3 = gameObject2.GetComponent<MyButtonQuest>();
						questButtons.Add(component3);
					}
					MyButtonQuest myButtonQuest = questButtons.get_Item(num3);
					GameObject gameObject3 = myButtonQuest.gameObject;
					gameObject3.SetActive(value: true);
					MyButtonQuest myButtonQuest2 = questButtons.get_Item(num3);
					MyAchievement achievement = ((List<MyAchievement>)(object)list).get_Item(num2);
					myButtonQuest2.Set(achievement);
					num3++;
				}
				num2++;
				num = num2;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void CreateTabs()
	{
		//IL_006a: Expected I, but got O
		//IL_00f5: Expected O, but got I4
		//IL_00a2: Expected O, but got I
		//IL_0716: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_0334: Expected O, but got I
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_01be: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_01f5: Expected I, but got O
		//IL_0203: Expected I, but got O
		//IL_0230: Expected I4, but got O
		//IL_023e: Expected I, but got O
		//IL_0275: Expected I, but got O
		//IL_0283: Expected I, but got O
		//IL_028b: Expected O, but got I
		//IL_05da: Expected O, but got I
		//IL_0668: Expected O, but got I
		//IL_068c: Expected O, but got Ref
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EAchievementType));
		Array values = Enum.GetValues(typeFromHandle);
		List<EAchievementType> list = new List<EAchievementType>();
		tabsEnums = list;
		IEnumerator enumerator = values.GetEnumerator();
		Array array = values;
		IEnumerator enumerator2 = default(IEnumerator);
		object obj7 = default(object);
		Navigation navigation = default(Navigation);
		while (true)
		{
			object obj;
			if (enumerator2 != null)
			{
				nint num = (nint)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r10_v4 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_00e2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r10_v4 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				obj = 0;
				int num2 = 0;
				while (true)
				{
					object obj2 = num2 + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ r8_v4+v725 @ rax_v105*8]");
					if (0 == (nint)typeof(IEnumerator))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r10_v4 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					if ((nint)num3 < (nint)0)
					{
						continue;
					}
					goto IL_00e2;
				}
				object obj3 = num2 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ r8_v4+8+v785 @ rcx_v81*8]");
				object obj4 = (nint)0 << 4;
				object obj5 = obj4 + 312;
				object obj6 = obj5 + num;
				goto IL_00fa;
			}
			throw new NullReferenceException();
			IL_00fa:
			if (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass25_0();
				bool flag = enumerator2 == null;
				array = (Array)(object)CS_0024_003C_003E8__locals5;
				if (!flag)
				{
					object current = enumerator2.Current;
					bool flag2 = CS_0024_003C_003E8__locals5 == null;
					array = (Array)enumerator2;
					if (!flag2)
					{
						bool flag3 = current == null;
						array = (Array)enumerator2;
						if (!flag3)
						{
							nint num4 = (nint)typeof(EAchievementType);
							nint num5 = (nint)current;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rdx_v50 (Il2CppClass<System.Object>)+40]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ r8_v26 (Il2CppClass<Assets.Scripts._Data.Progression.EAchievementType>)+40]");
							bool flag4 = num6 != 0;
							nint num7 = (nint)typeof(EAchievementType);
							nint num8 = (nint)typeof(IEnumerator);
							array = (Array)current;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								CS_0024_003C_003E8__locals5.type = (EAchievementType)obj7;
								nint num9 = (nint)typeof(DataManager);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1092 @ rax_v81 (Il2CppClass<DataManager>)+B8]");
								nint num10 = 0;
								DataManager instance = DataManager.Instance;
								bool flag5 = (object)DataManager.Instance == null;
								num7 = (nint)typeof(EAchievementType);
								num8 = (nint)typeof(IEnumerator);
								array = (Array)num10;
								if (flag5)
								{
									break;
								}
								Func<MyAchievement, bool> predicate = delegate(MyAchievement a)
								{
									//IL_008b: Expected I4, but got O
									if ((object)a == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									return a.achievementType == CS_0024_003C_003E8__locals5.type && a.isEnabled && a.IsVisible();
								};
								bool flag6 = Enumerable.Any(instance.unsortedAchievements, (Func<object, bool>)predicate);
								bool flag7 = !flag6;
								array = (Array)(object)instance.unsortedAchievements;
								if (!flag7)
								{
									tabsEnums.Add(CS_0024_003C_003E8__locals5.type);
									array = (Array)(object)tabsEnums;
								}
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A690");
			Comparison<EAchievementType> comparison = delegate(EAchievementType a, EAchievementType b)
			{
				int achievementTypeIndex = GetAchievementTypeIndex((int)a);
				int achievementTypeIndex2 = GetAchievementTypeIndex((int)b);
				int num17 = default(int);
				return num17.CompareTo(achievementTypeIndex2);
			};
			tabsEnums.Sort(comparison);
			List<EAchievementType> list2 = tabsEnums;
			int num11 = 0;
			int num12 = 0;
			bool flag8;
			do
			{
				int num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ rax_v26 (System.Collections.Generic.List`1<Assets.Scripts._Data.Progression.EAchievementType>)+18]");
				if ((nint)num13 < (nint)0)
				{
					GameObject gameObject = tabPrefab;
					if (num11 > 0)
					{
						Transform transform = tabPrefab.transform;
						Transform parent = transform.parent;
						gameObject = UnityEngine.Object.Instantiate(gameObject, parent);
					}
					MyButtonTabsQuest component = gameObject.GetComponent<MyButtonTabsQuest>();
					LocalizeStringEvent component2 = component.text.GetComponent<LocalizeStringEvent>();
					EAchievementType achType = tabsEnums.get_Item(num11);
					LocalizedString tabLocalizedString = GetTabLocalizedString(achType);
					component2.StringReference = tabLocalizedString;
					EAchievementType achievementType = tabsEnums.get_Item(num11);
					component.Set(achievementType);
					num11++;
					list2 = tabsEnums;
					flag8 = tabsEnums != null;
					num12 = num11;
					continue;
				}
				List<EAchievementType> list3 = tabsEnums;
				int num14 = 0;
				int num15 = 0;
				while (true)
				{
					int num16 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v28 (System.Collections.Generic.List`1<Assets.Scripts._Data.Progression.EAchievementType>)+18]");
					if ((nint)num16 < (nint)0)
					{
						Transform transform2 = tabNavigation.transform;
						Transform child = transform2.GetChild(num14);
						Button component3 = child.GetComponent<Button>();
						if (num14 > 0)
						{
							Transform transform3 = tabNavigation.transform;
							int index = num14 - 1;
							Transform child2 = transform3.GetChild(index);
							Button component4 = child2.GetComponent<Button>();
						}
						List<EAchievementType> list4 = tabsEnums;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v33 (System.Collections.Generic.List`1<Assets.Scripts._Data.Progression.EAchievementType>)+18]");
						object obj8 = -1;
						if (num14 < (nint)obj8)
						{
							Transform transform4 = tabNavigation.transform;
							int index2 = num14 + 1;
							Transform child3 = transform4.GetChild(index2);
							Button component5 = child3.GetComponent<Button>();
						}
						List<EAchievementType> list5 = tabsEnums;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v37 (System.Collections.Generic.List`1<Assets.Scripts._Data.Progression.EAchievementType>)+18]");
						object obj9 = -1;
						if (num14 >= (nint)obj9)
						{
						}
						component3.navigation = (Navigation)(&navigation);
						num14++;
						list3 = tabsEnums;
						num15 = num14;
						continue;
					}
					break;
				}
				return;
			}
			while (flag8);
			throw new NullReferenceException();
			IL_00e2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
			obj = 0;
			goto IL_00fa;
		}
		throw new NullReferenceException();
	}

	private void OnTabSelected(int index)
	{
		EAchievementType eAchievementType = tabsEnums.get_Item(index);
		achievementTab = eAchievementType;
		Refresh();
		Button selectedButton = tabNavigation.GetSelectedButton();
		tabVertNavigation.Set(selectedButton);
	}

	private void OnQuestButtonHover(MyButtonQuest btn)
	{
		startBtn = btn;
	}

	private int GetAchievementTypeIndex(int index)
	{
		//IL_0058: Expected I4, but got I8
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (index <= 7)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+575870+index @ rdx (System.Int32)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return -1;
	}

	private LocalizedString GetTabLocalizedString(EAchievementType achType)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (achType <= EAchievementType.Hats)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r8_v1+5758EC+achType @ rdx (Assets.Scripts._Data.Progression.EAchievementType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rdx_v2 (should have been resolved before IL gen)");
		}
		return null;
	}

	private bool _003CRefresh_003Eb__23_0(MyAchievement a)
	{
		//IL_005e: Expected I4, but got O
		if ((object)a != null)
		{
			if (a.achievementType != achievementTab)
			{
				return false;
			}
			return a.isEnabled;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private int _003CRefresh_003Eb__23_1(MyAchievement a, MyAchievement b)
	{
		//IL_01cd: Expected I4, but got O
		//IL_0061: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_01ba: Expected I4, but got I8
		int num;
		if ((object)a != null)
		{
			object obj;
			if (!a.IsUnlocked())
			{
				obj = 0;
			}
			else
			{
				bool flag = a.IsClaimed();
				obj = (flag ? 1 : 0) ^ 1;
			}
			if ((object)b != null)
			{
				bool flag2 = b.IsUnlocked();
				if (flag2)
				{
					bool flag3 = b.IsClaimed();
					flag2 = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
				}
				if ((nint)obj != (flag2 ? 1 : 0))
				{
					bool flag4 = obj == null;
					int result = 1;
					if (!flag4)
					{
						result = -1;
					}
					return result;
				}
				MyButtonToggle myButtonToggle = toggleHideCompleted;
				if ((object)toggleHideCompleted != null && (object)myButtonToggle.toggleIcon != null)
				{
					if (myButtonToggle.toggleIcon.activeInHierarchy)
					{
						bool flag5 = a.IsClaimed();
						bool value = b.IsClaimed();
						bool flag6 = default(bool);
						num = flag6.CompareTo(value);
						if (num != 0)
						{
							goto IL_0209;
						}
					}
					num = a.CompareTo(b);
					goto IL_0209;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_0209:
		return num;
	}

	private int _003CCreateTabs_003Eb__25_0(EAchievementType a, EAchievementType b)
	{
		int achievementTypeIndex = GetAchievementTypeIndex((int)a);
		int achievementTypeIndex2 = GetAchievementTypeIndex((int)b);
		int num = default(int);
		return num.CompareTo(achievementTypeIndex2);
	}
}
