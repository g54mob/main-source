using System;
using System.Collections;
using UnityEngine;

public class TutorialGameManager : LTGameManager
{
	[Header("Tutorial")]
	[SerializeField]
	private TutorialSpawnersManager tutorialSpawnersManager;

	[SerializeField]
	private int tutorialMoneyReward;

	[SerializeField]
	private TutorialQuestData[] tutorialQuests;

	private int currentQuestIdx = -1;

	private Coroutine questCoroutine;

	public TutorialSpawnersManager TutorialSpawnersManager => tutorialSpawnersManager;

	public event Action onTutorialQuestUpdated;

	public event Action onTutorialQuestStarted;

	public event Action onTutorialQuestCompleted;

	protected override void StartGame()
	{
		base.StartGame();
		StartNextQuest();
	}

	protected override void LoadPlayerUpgrades()
	{
	}

	public override int CalculateMoneyReward(bool hasWon, bool includeChests)
	{
		if (hasWon)
		{
			return tutorialMoneyReward;
		}
		return 0;
	}

	private IEnumerator QuestsCoroutine()
	{
		TutorialQuestData currentQuest = tutorialQuests[currentQuestIdx];
		currentQuest.StartQuest();
		this.onTutorialQuestStarted?.Invoke();
		yield return null;
		while (!currentQuest.IsComplete())
		{
			if (currentQuest.UpdateQuest())
			{
				this.onTutorialQuestUpdated?.Invoke();
			}
			yield return null;
		}
		currentQuest.EndQuest();
		this.onTutorialQuestCompleted?.Invoke();
		questCoroutine = null;
	}

	public TutorialQuestData GetCurrentQuest()
	{
		return tutorialQuests[currentQuestIdx];
	}

	public bool IsLastQuest()
	{
		return currentQuestIdx >= tutorialQuests.Length - 1;
	}

	public void StartNextQuest()
	{
		if (currentQuestIdx != tutorialQuests.Length - 1)
		{
			currentQuestIdx++;
			this.StartCoroutineCheckingVar(QuestsCoroutine(), ref questCoroutine, stopCoroutineIfRunning: true);
		}
	}

	protected override void OnPlayerTowerDie(CombatComponent combatComponent)
	{
		combatComponent.GetComponent<StatsComponent>().SetStat(EStats.Health, 1f);
	}

	protected override void EndGame()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().AddMoney(tutorialMoneyReward);
		base.EndGame();
	}
}
