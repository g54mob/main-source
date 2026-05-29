using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using TMPro;
using UnityEngine;

public class ChallengesUi : Window
{
	public GameObject challengeButtonPrefab;

	public SelectionGroupToggleSingle challengesSelectionGroup;

	private List<SelectionGroupToggleSingleButtonChallenge> challengeButtons;

	public MapSelectionUi mapSelectionUi;

	public MyButton btn_confirm;

	private SelectionGroupToggleSingleButton hoverBtn;

	private Color completedColor;

	private Color notCompletedColor;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_stats;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_silver;

	public TextMeshProUGUI t_completed;

	public TextMeshProUGUI t_author;

	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_winCondition;

	public TextMeshProUGUI t_reward;

	public TextMeshProUGUI t_leaderboards;

	private new void Awake()
	{
	}

	private new void Start()
	{
	}

	private new void OnDestroy()
	{
	}

	private void OnChallengeHovered(SelectionGroupToggleSingleButtonChallenge btn)
	{
	}

	private void UpdateStatsText(ChallengeData challengeData)
	{
	}

	public static bool IsNegativeModifier(StatModifier statModifier)
	{
		return false;
	}

	private static bool IsOppositeStat(EStat stat)
	{
		return false;
	}

	private void SetEmpty()
	{
	}

	private void SetHidden(ChallengeData challengeData)
	{
	}

	private new void OnEnable()
	{
	}

	private void Refresh()
	{
	}

	public void SetNone()
	{
	}

	private void OnChallengeSelected(SelectionGroupToggleSingleButton btn)
	{
	}
}
