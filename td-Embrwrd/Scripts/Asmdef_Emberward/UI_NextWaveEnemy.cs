using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NextWaveEnemy : AUISituational
{
	[SerializeField]
	private TMP_Text text_Content;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private VerticalLayoutGroup layoutGroup;

	[SerializeField]
	private Button button_ShowInfo;

	private RectTransform layoutRectTransform;

	private WaveInfoData waveInfoData;

	private List<WaveInfoMonsterData> curWaveMonsterData;

	private int curDataRound;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClickButton_ShowInfo()
	{
	}

	private void OnAddMonsterToNextWaveUI(eMonsterType type, int count)
	{
	}

	private void OnToggleNextWaveMonsterUI(bool isOn)
	{
	}

	private void UpdateText()
	{
	}

	private void OnUpdateNextWaveMonster(WaveInfoData waveInfoData, int round)
	{
	}

	private string AddColor_SubstitutedMonster(string str)
	{
		return null;
	}

	private string AddColorToMonsterNameBySize(eMonsterSize size, string str)
	{
		return null;
	}
}
