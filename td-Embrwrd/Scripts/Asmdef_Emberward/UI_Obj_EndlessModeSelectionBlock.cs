using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_EndlessModeSelectionBlock : MonoBehaviour
{
	public enum eTimeCountdownType
	{
		NONE = 0,
		DAILY = 1,
		WEEKLY = 2
	}

	[SerializeField]
	private Image image_LevelPhoto;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private Transform node_AnomalyDetail;

	[SerializeField]
	private TMP_Text text_Description_Anomaly;

	[SerializeField]
	private HorizontalLayoutGroup node_AnomalyLayout;

	[SerializeField]
	private Transform node_TimeCountdown;

	[SerializeField]
	private TMP_Text text_TimeCountdown;

	[SerializeField]
	private GameObject node_SelectEffect;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private eEndlessModeType endlessModeType;

	[SerializeField]
	private int endlessMapIndex;

	[SerializeField]
	private Button button_OpenLeaderboard;

	[SerializeField]
	private GameObject node_AnomalyDetails;

	[SerializeField]
	private List<UI_Obj_EndlessModePerkDetail> list_AnomalyDetails;

	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_AnomalyDetailControlTip;

	[SerializeField]
	private GameObject prefab_AnomalyIcon;

	private string leaderboardPrefixName;

	private List<PerkSettingData> list_Anomaly;

	private EndlessMapData data;

	private int seed;

	private Action<eEndlessModeType, int, EndlessMapData, string, List<PerkSettingData>> onButtonClickCallback;

	private bool doShowControlTip;

	private bool isSelected;

	private bool isDetailInfoShowing;

	public Button Button => null;

	public eEndlessModeType EndlessModeType => default(eEndlessModeType);

	public Button Button_OpenLeaderboard => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void UpdateGlyphText()
	{
	}

	private void OnButtonClicked_OpenLeaderboard()
	{
	}

	private void OnButtonClicked()
	{
	}

	public void Setup(EndlessMapData data, int seed, eEndlessModeType endlessModeType, bool isLocked, Sprite levelPhoto, string leaderboardPrefixName, Action<eEndlessModeType, int, EndlessMapData, string, List<PerkSettingData>> onButtonClickCallback, List<PerkSettingData> list_Anomaly = null, bool doShowAnomaly = true)
	{
	}

	public void OverrideTitle(string title)
	{
	}

	public void OverrideDescription(string description)
	{
	}

	public void ToggleLocked(bool isLocked)
	{
	}

	public void SetTimeCountdown(TimeSpan timeSpan, eTimeCountdownType countdownType)
	{
	}

	public void ToggleSelectEffect(bool isOn)
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnClickButton()
	{
	}

	private void Update()
	{
	}

	private void ToggleDetailInfo(bool isShow)
	{
	}
}
