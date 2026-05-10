using UnityEngine;

public class LTGameManager_Campaign : LTGameManager
{
	protected override void Start()
	{
		base.Start();
		LTFunctionLibrary.GetSpawnersManager().onEnemyDies += OnEnemyDie;
		LTFunctionLibrary.GetSpawnersManager().onBossSpawned += OnBossSpawned;
	}

	private void OnBossSpawned(Enemy boss)
	{
		LTFunctionLibrary.GetLevelsProgressionManager().RevealBoss(LTFunctionLibrary.GetMatchInfo().CurrentLevelData.Id);
	}

	public override int CalculateMoneyReward(bool hasWon, bool includeChests)
	{
		int num = 0;
		int num2 = 1;
		if (MatchInfo.instance.CurrentLevelData != null)
		{
			num2 = MatchInfo.instance.CurrentLevelData.MoneyPerWave;
		}
		num += Mathf.CeilToInt((float)(base.CyclesManager.CurrentCycle * num2) * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierCycles);
		if (hasWon)
		{
			num += Mathf.CeilToInt((float)CalculateVictoryMoney() * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierVictory);
		}
		if (includeChests)
		{
			num += base.ChestCoins;
		}
		return num;
	}

	private int CalculateVictoryMoney()
	{
		if (MatchInfo.instance.CurrentLevelData != null)
		{
			if (LTFunctionLibrary.GetLevelsProgressionManager().GetLevelVictories(MatchInfo.instance.CurrentLevelData.Id) == 1)
			{
				return MatchInfo.instance.CurrentLevelData.MoneyFirstVictory;
			}
			return MatchInfo.instance.CurrentLevelData.MoneyVictory;
		}
		return 0;
	}

	private void OnEnemyDie(Enemy enemy)
	{
		if (!enemy.Data.Boss || !base.PlayerTower.CombatComponent.IsAlive() || base.GameState != EGameState.Playing)
		{
			return;
		}
		enemy.Controller.gameObject.SetActive(value: false);
		enemy.movementComponent.MovementEnabled = false;
		enemy.animator.speed = 0f;
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Play);
		base.GameState = EGameState.EndingAnimation;
		base.PlayerTower.CombatComponent.BCanBeDamaged = false;
		if ((bool)MatchInfo.instance.CurrentLevelData)
		{
			if (!LTFunctionLibrary.GetLevelsProgressionManager().IsBossDefeated(MatchInfo.instance.CurrentLevelData.Id))
			{
				base.FirstTimeBossDefeated = true;
			}
			LTFunctionLibrary.GetLevelsProgressionManager().CompleteBoss(MatchInfo.instance.CurrentLevelData.Id, enemy.Data, LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings.Id == "expert");
		}
		bossVictoryAnimation.PlayVictoryAnimation(enemy);
		onVictoryAnimationStarted?.Invoke();
	}

	protected override void EndGame()
	{
		if (SaveSystem.instance.ExistsSavedGame())
		{
			SaveSystem.instance.DeleteSavedGame();
		}
		if ((bool)MatchInfo.instance.CurrentLevelData)
		{
			LTFunctionLibrary.GetLevelsProgressionManager().SetLevelPlayed(MatchInfo.instance.CurrentLevelData.Id);
			LTFunctionLibrary.GetLevelsProgressionManager().CompleteLevel(MatchInfo.instance.CurrentLevelData.Id, LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings.Id == "expert");
		}
		LTFunctionLibrary.GetPlayerUpgradesManager().AddMoney(CalculateMoneyReward(hasWon: true, includeChests: true));
		base.EndGame();
	}
}
