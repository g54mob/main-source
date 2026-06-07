using TMPro;
using UnityEngine;

public class UI_RoundTimeCountDown : AUISituational
{
	[SerializeField]
	private TMP_Text text_RoundTime;

	private int lastUpdatedTimeInt;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnUpdateRoundTimer(float time, float percentage)
	{
	}

	private void OnToggleRoundTimerUI(bool isOn)
	{
	}
}
