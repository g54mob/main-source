public class GE_GiveEffectToEnemy : GameplayEffect
{
	private GE_GiveEffectToEnemyData giveEffectToEnemyData;

	protected override void OnInitEffect()
	{
		giveEffectToEnemyData = base.EffectData as GE_GiveEffectToEnemyData;
		LTFunctionLibrary.GetSpawnersManager().onEnemySpawned += OnEnemySpawned;
	}

	protected override void OnStacksAdded(int addedStacks)
	{
		foreach (Enemy spawnedEnemy in LTFunctionLibrary.GetSpawnersManager().SpawnedEnemies)
		{
			AddStacksToEnemy(spawnedEnemy, addedStacks);
		}
	}

	protected override void OnStacksRemoved(int removedStacks)
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState != LTGameManager.EGameState.Playing)
		{
			return;
		}
		foreach (Enemy spawnedEnemy in LTFunctionLibrary.GetSpawnersManager().SpawnedEnemies)
		{
			if ((bool)spawnedEnemy && giveEffectToEnemyData.IsAffected(spawnedEnemy.Data) && spawnedEnemy.TryGetComponent<GameplayEffectsComponent>(out var component))
			{
				GameplayEffectData[] effectsToApply = giveEffectToEnemyData.EffectsToApply;
				foreach (GameplayEffectData gameplayEffectData in effectsToApply)
				{
					component.RemoveEffect(gameplayEffectData, removedStacks);
				}
			}
		}
	}

	protected override void OnEndEffect()
	{
		LTFunctionLibrary.GetSpawnersManager().onEnemySpawned -= OnEnemySpawned;
	}

	private void AddStacksToEnemy(Enemy enemy, int stacksToAdd)
	{
		if (giveEffectToEnemyData.IsAffected(enemy.Data) && enemy.TryGetComponent<GameplayEffectsComponent>(out var component))
		{
			GameplayEffectData[] effectsToApply = giveEffectToEnemyData.EffectsToApply;
			foreach (GameplayEffectData gameplayEffectData in effectsToApply)
			{
				component.ApplyEffect(gameplayEffectData, stacksToAdd);
			}
		}
	}

	private void OnEnemySpawned(Enemy enemy)
	{
		AddStacksToEnemy(enemy, base.CurrentStacks);
	}
}
