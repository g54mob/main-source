using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageProgress : AUISituational
{
	[SerializeField]
	private Image image_TimeBar;

	[SerializeField]
	private Image image_BarOutline;

	[SerializeField]
	private Transform node_Countdown;

	[SerializeField]
	private Transform node_ProgressBar;

	[SerializeField]
	private RectTransform rectTransform_TimeBar_BG;

	[SerializeField]
	private TMP_Text text_RoundCount;

	[SerializeField]
	private TMP_Text text_RoundTime;

	[SerializeField]
	private TMP_Text text_PrepareFirstRound;

	[SerializeField]
	private Gradient gradient_BarColor;

	private int lastUpdatedTimeInt;

	private bool doShowCountdown;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnUpdateRoundTimer(float time, float percentage)
	{
	}

	private void OnToggleRoundTimerUI(bool isOn, bool doShowCountdown, bool isFirstRound)
	{
	}
}
