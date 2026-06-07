using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnigmaSanctumMapSelect_Popup : APopupWindow
{
	[SerializeField]
	private BasicEndlessModeSettingData basicEndlessModeSettingData;

	[SerializeField]
	private EnvSceneCollectionData envSceneCollectionData;

	[SerializeField]
	private Sprite sprite_DailyMode;

	[SerializeField]
	private Sprite sprite_WeeklyMode;

	[SerializeField]
	private Sprite sprite_CasualMode;

	[SerializeField]
	private Transform layout_Cards;

	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private GameObject prefab_UI_Obj_EndlessModeSelectionBlock;

	[SerializeField]
	private TMP_InputField debug_InputField_TimeOffset;

	[SerializeField]
	private Slider debug_Slider_TimeOffset;

	[SerializeField]
	private TMP_Text text_TimeOffset;

	[SerializeField]
	private Button button_TimeOffset;

	private List<UI_Obj_EndlessModeSelectionBlock> list_EndlessModeSelectionBlock;

	private int dayOffset;

	private int hourOffset;

	private bool isButtonClicked;

	private List<Selectable> list_JoystickSelectables;

	private static readonly DateTime epoch;

	protected override void OnEnableProc()
	{
	}

	private void ResetContent()
	{
	}

	protected override void OnDisableProc()
	{
	}

	public void Setup()
	{
	}

	public int GetCurrentWeekIndex()
	{
		return 0;
	}

	private void OnEndlessModeBlockClicked(eEndlessModeType endlessModeType, int seed, EndlessMapData data, string leaderboardName, List<PerkSettingData> anomalyList)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void OnClickButton_Leave()
	{
	}

	private void Update()
	{
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect()
	{
	}
}
