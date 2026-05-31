using System;
using TMPro;
using UnityEngine;

public class EndOfDayCounterSetter : MonoBehaviour
{
	[SerializeField]
	private ValueCounter[] normalCounter;

	[SerializeField]
	private ValueCounter[] dailyCounter;

	[SerializeField]
	private ValueCounter dayCounter;

	[SerializeField]
	private TextMeshProUGUI summaryText;

	[SerializeField]
	private TextMeshProUGUI titleText;

	[SerializeField]
	private TextMeshProUGUI dificultText;

	public GameObject textReputationTheft;

	public PlayerInventory playerInventory;

	private bool EmptyInventroy()
	{
		return false;
	}

	private void OnEnable()
	{
	}

	public static void SteamAchievementCount(out int counter, string deleteKey, string key, int valueForAchievement, Action act = null)
	{
		counter = default(int);
	}
}
