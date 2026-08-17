using System;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;

public class MapSelectionUi : Window
{
	public SelectionGroupToggleSingle mapSelectionGroup;

	public SelectionGroupToggleSingle tierSelectionGroup;

	public ChallengesUi challengesUi;

	private bool firstSelection = true;

	private SelectionGroupToggleSingleButton selectedBtn;

	private SelectionGroupToggleSingleButton mapBtn;

	public MapStatsWindow mapStatsWindow;

	public MapSelectionWindow mapButtonsWindow;

	public RunConfig runConfig;

	public MyButton btnConfirm;

	public GameObject jukebox;

	public static Action<RunConfig> A_RunConfigChanged;

	public static Action<SelectionGroupToggleSingleButton, MapData> A_MapSelected;

	public MapData defaultMapData;

	private bool isSelectingMap;

	private bool newMapSelected;

	public static bool isTestFight;

	public static Action A_MapSelectionEnabled;

	private new void Awake()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00a9: Expected I, but got O
		//IL_006b: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_0104: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_011b: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_0213: Expected I, but got O
		//IL_0260: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_0277: Expected I, but got O
		base.Awake();
		SelectionGroupToggleSingle selectionGroupToggleSingle = mapSelectionGroup;
		Delegate obj6;
		Delegate obj4;
		if ((object)mapSelectionGroup != null)
		{
			Action<SelectionGroupToggleSingleButton> b = OnMapSelected;
			Delegate obj = Delegate.Combine(selectionGroupToggleSingle.A_ButtonSelected, b);
			nint num;
			object obj2;
			object obj3;
			if ((object)obj == null)
			{
				selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj;
				num = (nint)selectionGroupToggleSingle.A_ButtonSelected;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<SelectionGroupToggleSingleButton> action = default(Action<SelectionGroupToggleSingleButton>);
				bool flag = action == null;
				obj2 = 0;
				obj3 = 0;
				nint num2 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				obj4 = obj;
				if (flag)
				{
					goto IL_02c1;
				}
				selectionGroupToggleSingle.A_ButtonSelected = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				obj6 = obj;
				obj2 = 0;
				obj3 = 0;
				num2 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				if (flag2)
				{
					goto IL_02cc;
				}
			}
			SelectionGroupToggleSingle selectionGroupToggleSingle2 = tierSelectionGroup;
			bool flag3 = (object)tierSelectionGroup == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			nint num3 = num;
			if (!flag3)
			{
				Action<SelectionGroupToggleSingleButton> b2 = OnTierSelected;
				Delegate obj7 = Delegate.Combine(selectionGroupToggleSingle2.A_ButtonSelected, b2);
				if ((object)obj7 == null)
				{
					selectionGroupToggleSingle2.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj7;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<SelectionGroupToggleSingleButton> action2 = default(Action<SelectionGroupToggleSingleButton>);
				bool flag4 = action2 == null;
				obj6 = obj7;
				obj2 = 0;
				obj3 = 0;
				num3 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				Delegate obj8 = obj7;
				if (!flag4)
				{
					selectionGroupToggleSingle2.A_ButtonSelected = action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj9 = default(object);
					bool flag5 = obj9 == null;
					obj6 = obj7;
					obj2 = 0;
					obj3 = 0;
					num3 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
					if (!flag5)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					obj8 = obj6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num2 = num3;
				goto IL_02cc;
			}
		}
		throw new NullReferenceException();
		IL_02cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_02c1;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00a9: Expected I, but got O
		//IL_006b: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_0104: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_011b: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_0213: Expected I, but got O
		//IL_0260: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_0277: Expected I, but got O
		base.OnDestroy();
		SelectionGroupToggleSingle selectionGroupToggleSingle = mapSelectionGroup;
		Delegate obj6;
		Delegate obj4;
		if ((object)mapSelectionGroup != null)
		{
			Action<SelectionGroupToggleSingleButton> value = OnMapSelected;
			Delegate obj = Delegate.Remove(selectionGroupToggleSingle.A_ButtonSelected, value);
			nint num;
			object obj2;
			object obj3;
			if ((object)obj == null)
			{
				selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj;
				num = (nint)selectionGroupToggleSingle.A_ButtonSelected;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<SelectionGroupToggleSingleButton> action = default(Action<SelectionGroupToggleSingleButton>);
				bool flag = action == null;
				obj2 = 0;
				obj3 = 0;
				nint num2 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				obj4 = obj;
				if (flag)
				{
					goto IL_02c1;
				}
				selectionGroupToggleSingle.A_ButtonSelected = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				obj6 = obj;
				obj2 = 0;
				obj3 = 0;
				num2 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				if (flag2)
				{
					goto IL_02cc;
				}
			}
			SelectionGroupToggleSingle selectionGroupToggleSingle2 = tierSelectionGroup;
			bool flag3 = (object)tierSelectionGroup == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			nint num3 = num;
			if (!flag3)
			{
				Action<SelectionGroupToggleSingleButton> value2 = OnTierSelected;
				Delegate obj7 = Delegate.Remove(selectionGroupToggleSingle2.A_ButtonSelected, value2);
				if ((object)obj7 == null)
				{
					selectionGroupToggleSingle2.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj7;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<SelectionGroupToggleSingleButton> action2 = default(Action<SelectionGroupToggleSingleButton>);
				bool flag4 = action2 == null;
				obj6 = obj7;
				obj2 = 0;
				obj3 = 0;
				num3 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
				Delegate obj8 = obj7;
				if (!flag4)
				{
					selectionGroupToggleSingle2.A_ButtonSelected = action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj9 = default(object);
					bool flag5 = obj9 == null;
					obj6 = obj7;
					obj2 = 0;
					obj3 = 0;
					num3 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
					if (!flag5)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					obj8 = obj6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num2 = num3;
				goto IL_02cc;
			}
		}
		throw new NullReferenceException();
		IL_02cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_02c1;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void Init()
	{
		bool flag = SaveManager._003CInstance_003Ek__BackingField != null;
		RunConfig runConfig = this.runConfig;
		if (!flag)
		{
			runConfig.mapData = defaultMapData;
		}
		else
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression = saveManager.progression;
			MenuMeta menuMeta = progression.menuMeta;
			MapData map = DataManager.Instance.GetMap(menuMeta.lastSelectedMap);
			runConfig.mapData = map;
			RunConfig runConfig2 = this.runConfig;
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression2 = saveManager2.progression;
			RunConfig runConfig3 = this.runConfig;
			MapData mapData = runConfig3.mapData;
			int lastSelectedTier = progression2.menuMeta.GetLastSelectedTier(mapData.eMap);
			runConfig2.mapTierIndex = lastSelectedTier;
		}
		tierSelectionGroup.FindButtons();
		RunConfig runConfig4 = this.runConfig;
		SelectionGroupToggleSingle selectionGroupToggleSingle = tierSelectionGroup;
		selectionGroupToggleSingle.startIndex = runConfig4.mapTierIndex;
		mapButtonsWindow.InitButtons();
		mapSelectionGroup.FindButtons();
		RunConfig runConfig5 = this.runConfig;
		MapData mapData2 = runConfig5.mapData;
		SelectionGroupToggleSingle selectionGroupToggleSingle2 = mapSelectionGroup;
		selectionGroupToggleSingle2.startIndex = mapData2.unlockOrder;
		RunConfig runConfig6 = this.runConfig;
		MapData mapData3 = runConfig6.mapData;
		SelectionGroupToggleSingleButton button = mapSelectionGroup.GetButton(mapData3.unlockOrder);
		startBtn = button;
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton btn)
	{
		isSelectingMap = true;
		bool flag = mapBtn == btn;
		if (!flag)
		{
			newMapSelected = true;
		}
		mapBtn = btn;
		MapEntry component = btn.GetComponent<MapEntry>();
		RunConfig runConfig = this.runConfig;
		MapData mapData = component._003CmapData_003Ek__BackingField;
		runConfig.mapData = component._003CmapData_003Ek__BackingField;
		mapStatsWindow.RefreshTiers();
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		int lastSelectedTier = progression.menuMeta.GetLastSelectedTier(mapData.eMap);
		if (!firstSelection)
		{
			if (flag)
			{
				SelectionGroupToggleSingleButton button = tierSelectionGroup.GetButton(lastSelectedTier);
				ButtonManager.ForceHoverButton(button);
			}
			tierSelectionGroup.ForceSelect(lastSelectedTier);
			isSelectingMap = false;
		}
		else
		{
			firstSelection = false;
		}
		ChallengesUi challengesUi = this.challengesUi;
		challengesUi.challengesSelectionGroup.SetNone();
		challengesUi.mapSelectionUi.SetChallenge(null);
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression2 = saveManager2.progression;
		MenuMeta menuMeta = progression2.menuMeta;
		menuMeta.lastSelectedMap = mapData.eMap;
		SaveManager._003CInstance_003Ek__BackingField.SaveProgression();
		if (!flag)
		{
			newMapSelected = true;
		}
		Action<SelectionGroupToggleSingleButton, MapData> a_MapSelected = A_MapSelected;
		if (A_MapSelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v320 @ r10_v1 (System.Action`2<SelectionGroupToggleSingleButton, MapData>)+18] (should have been resolved before IL gen)");
		}
		Action<RunConfig> a_RunConfigChanged = A_RunConfigChanged;
		if (A_RunConfigChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v323 @ r9_v2 (System.Action`1<Assets.Scripts.Game.Other.RunConfig>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnTierSelected(SelectionGroupToggleSingleButton btn)
	{
		//IL_011f: Expected O, but got I
		//IL_017c: Expected O, but got I
		GameObject gameObject = base.gameObject;
		if (!gameObject.activeInHierarchy || this.runConfig == null || !(btn != null))
		{
			return;
		}
		RunConfig runConfig = this.runConfig;
		int selectedIndex = tierSelectionGroup.GetSelectedIndex();
		runConfig.mapTierIndex = selectedIndex;
		RunConfig runConfig2 = this.runConfig;
		MapData mapData = runConfig2.mapData;
		StageData[] stages = mapData.stages;
		RunConfig runConfig3 = this.runConfig;
		int mapTierIndex = runConfig3.mapTierIndex;
		runConfig3.stageData = stages[mapTierIndex];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v16+30]");
		object obj = 0;
		MapEntry component = mapBtn.GetComponent<MapEntry>();
		MapData mapData2 = component._003CmapData_003Ek__BackingField;
		int selectedIndex2 = tierSelectionGroup.GetSelectedIndex();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v12+50]");
		((MenuMeta)0).SetTier(mapData2.eMap, selectedIndex2);
		int selectedIndex3 = tierSelectionGroup.GetSelectedIndex();
		if (runConfig.mapTierIndex == selectedIndex3)
		{
			if (!newMapSelected && !isSelectingMap)
			{
				ButtonManager.ForceHoverButton(btnConfirm);
			}
		}
		else
		{
			challengesUi.SetNone();
		}
		newMapSelected = false;
		Action<RunConfig> a_RunConfigChanged = A_RunConfigChanged;
		if (A_RunConfigChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v298 @ rax_v24 (System.Action`1<Assets.Scripts.Game.Other.RunConfig>)+18] (should have been resolved before IL gen)");
		}
	}

	public void SetChallenge(ChallengeData challengeData)
	{
		RunConfig runConfig = this.runConfig;
		runConfig.challenge = challengeData;
		Action<RunConfig> a_RunConfigChanged = A_RunConfigChanged;
		if (A_RunConfigChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rax_v5 (System.Action`1<Assets.Scripts.Game.Other.RunConfig>)+18] (should have been resolved before IL gen)");
		}
	}

	public void StartMap()
	{
		isTestFight = false;
		MapController.StartNewMap(runConfig);
	}

	public void StartBossFightTest()
	{
		isTestFight = true;
		RunConfig runConfig = this.runConfig;
		runConfig.mapTierIndex = 2;
		RunConfig runConfig2 = this.runConfig;
		MapData mapData = runConfig2.mapData;
		StageData[] stages = mapData.stages;
		int mapTierIndex = runConfig2.mapTierIndex;
		runConfig2.stageData = stages[mapTierIndex];
		MapController.TestMap(this.runConfig);
		MapController.LoadFinalStage();
	}

	private new void OnDisable()
	{
		base.OnDisable();
		savedBtn = mapBtn;
		startBtn = savedBtn;
		alwaysUseStartBtn = true;
	}

	private new void OnEnable()
	{
		base.OnEnable();
		alwaysUseStartBtn = false;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		bool active = saveManager.progression.HasShopItem(EShopItem.Boombox);
		jukebox.SetActive(active);
		Action a_MapSelectionEnabled = A_MapSelectionEnabled;
		if (A_MapSelectionEnabled != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v135.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public MapSelectionUi()
	{
		RunConfig runConfig = new RunConfig();
		this.runConfig = runConfig;
		isSelectingMap = true;
		base._002Ector();
	}
}
