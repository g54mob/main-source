using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectWorld_Popup : APopupWindow
{
	[SerializeField]
	private Button button_Ok;

	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private Button button_Stats;

	[SerializeField]
	private Button button_Stats_Ok;

	[SerializeField]
	private Button button_EditShard;

	[SerializeField]
	private Button button_EditShard_Confirm;

	[SerializeField]
	private Button button_EditShard_Reset;

	[SerializeField]
	private Button button_EditShard_Random;

	[SerializeField]
	private Button button_EditShard_Max;

	[SerializeField]
	private TMP_Text text_Stats;

	[SerializeField]
	private GameObject node_Stats;

	[SerializeField]
	private UI_HardModeInfo ui_HardModeInfo;

	[SerializeField]
	private List<UI_Obj_SelectWorldEntry> list_SelectWorldEntries;

	[SerializeField]
	private List<UI_Obj_HardModeShard> list_SelectableShards;

	[Header("自訂遊戲")]
	[SerializeField]
	private GameObject node_CustomGameMapOffset;

	[SerializeField]
	private GameObject node_CustomGame;

	[SerializeField]
	private Toggle toggle_CustomGame;

	[SerializeField]
	private GameObject node_CustomGameWarning;

	[Header("所有搖桿可以選擇的物件")]
	[SerializeField]
	private List<Selectable> list_JoystickSelectables;

	[SerializeField]
	private eWorldType selectedWorldType;

	public Action<eWorldType, HardModeSetting, bool> OnWindowFinishCallback;

	public bool IsChosen;

	private List<int> list_SelectedShardLevel;

	private HardModeSetting hardModeSetting;

	private eGameDifficultyType gameDifficulty;

	private bool isInfernoShardUnlocked;

	private bool isCustomGame;

	private void FetchAllSelectables()
	{
	}

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void OnToggleCustomGameChanged(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	private void OnClickButton_Stats_Ok()
	{
	}

	private void OnClickButton_EditShard_Max()
	{
	}

	private void OnClickButton_Stats()
	{
	}

	private void OnClickButton_EditShard_Reset()
	{
	}

	private void OnClickButton_EditShard_Random()
	{
	}

	private void OnClickButton_EditShard()
	{
	}

	private void OnClickButton_EditShard_Confirm()
	{
	}

	private void RebuildNavigationAndSelect(Selectable selectable, float delay = 0f)
	{
	}

	private void OnClickButton_Ok()
	{
	}

	private void OnClickButton_Leave()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void Initialize(eGameDifficultyType difficulty)
	{
	}

	private List<int> SplitDigits(int number)
	{
		return null;
	}

	public void SetupShards(List<int> list_shardLevel, bool doBounceAnim = false)
	{
	}

	private void OnClickShard(eHardModeShardType shardType, int level, UI_Obj_HardModeShard shard)
	{
	}

	public void Toggle(bool isOn)
	{
	}

	private void OnSelectWorld(eWorldType worldType)
	{
	}

	private bool IsWorldUnlocked(eWorldType worldType)
	{
		return false;
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void UpdateStats()
	{
	}

	public override void OnWindowLostFocus()
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
}
