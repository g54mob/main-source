public class GE_GiveEffectToBuilding : GameplayEffect
{
	private GE_GiveEffectToBuildingData giveEffectToBuildingData;

	protected override void OnInitEffect()
	{
		giveEffectToBuildingData = base.EffectData as GE_GiveEffectToBuildingData;
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded += OnPlayerStructureAdded;
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded += OnPlayerStructureAdded;
	}

	protected override void OnStacksAdded(int addedStacks)
	{
		foreach (GameplayObject playerBuildingsAndTower in LTFunctionLibrary.GetPlayerData().PlayerBuildingsAndTowers)
		{
			AddStacksToStructure(playerBuildingsAndTower, addedStacks);
		}
	}

	protected override void OnStacksRemoved(int removedStacks)
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState != LTGameManager.EGameState.Playing)
		{
			return;
		}
		foreach (GameplayObject playerBuildingsAndTower in LTFunctionLibrary.GetPlayerData().PlayerBuildingsAndTowers)
		{
			if ((bool)playerBuildingsAndTower && giveEffectToBuildingData.IsAffected(playerBuildingsAndTower.ObjectData) && playerBuildingsAndTower.TryGetComponent<GameplayEffectsComponent>(out var component))
			{
				GameplayEffectData[] effectsToApply = giveEffectToBuildingData.EffectsToApply;
				foreach (GameplayEffectData gameplayEffectData in effectsToApply)
				{
					component.RemoveEffect(gameplayEffectData, removedStacks);
				}
			}
		}
	}

	protected override void OnEndEffect()
	{
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded -= OnPlayerStructureAdded;
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded -= OnPlayerStructureAdded;
	}

	private void AddStacksToStructure(GameplayObject playerStructure, int stacksToAdd)
	{
		if (giveEffectToBuildingData.IsAffected(playerStructure.ObjectData) && playerStructure.TryGetComponent<GameplayEffectsComponent>(out var component))
		{
			GameplayEffectData[] effectsToRemove = giveEffectToBuildingData.EffectsToRemove;
			foreach (GameplayEffectData gameplayEffectData in effectsToRemove)
			{
				component.RemoveEffect(gameplayEffectData);
			}
			effectsToRemove = giveEffectToBuildingData.EffectsToApply;
			foreach (GameplayEffectData gameplayEffectData2 in effectsToRemove)
			{
				component.ApplyEffect(gameplayEffectData2, stacksToAdd);
			}
		}
	}

	private void OnPlayerStructureAdded(GameplayObject playerStructure)
	{
		AddStacksToStructure(playerStructure, base.CurrentStacks);
	}
}
