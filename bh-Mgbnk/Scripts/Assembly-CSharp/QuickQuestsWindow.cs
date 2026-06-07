using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class QuickQuestsWindow : MonoBehaviour
{
	public GameObject prefab;

	public GameObject allQuestsCompletedText;

	private int numMaxQuests;

	private List<QuickQuestContainer> containers;

	private List<MyAchievement> quests;

	private Dictionary<MyAchievement, int> randomTieBreaker;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void Refresh()
	{
	}

	private int GetTie(MyAchievement a)
	{
		return 0;
	}

	private List<MyAchievement> GetAllAchievements()
	{
		return null;
	}

	private void TryInit()
	{
	}
}
