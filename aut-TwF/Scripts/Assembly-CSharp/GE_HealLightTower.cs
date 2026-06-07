public class GE_HealLightTower : GameplayEffect
{
	protected override void OnInitEffect()
	{
		GE_HealLightTowerData gE_HealLightTowerData = base.EffectData as GE_HealLightTowerData;
		StatsComponent statsComponent = LTFunctionLibrary.GetLTGameManager().PlayerTower.StatsComponent;
		statsComponent.SetStat(EStats.Health, statsComponent.GetStat(EStats.Health) + (float)gE_HealLightTowerData.HealedAmount);
		LTFunctionLibrary.GetLTGameManager().PlayerCharacter.GetComponent<GameplayEffectsComponent>().RemoveEffect(gE_HealLightTowerData);
	}
}
