public class GE_SlowResistance : GameplayEffect
{
	private GE_SlowResistanceData slowResistanceData;

	private StatsComponent enemyStatsComponent;

	private GameplayEffectsComponent enemyGEComponent;

	protected override void OnInitEffect()
	{
		slowResistanceData = base.EffectData as GE_SlowResistanceData;
		enemyStatsComponent = base.Owner.GetComponent<StatsComponent>();
		enemyGEComponent = base.Owner.GetComponent<GameplayEffectsComponent>();
		ModifySlowValues(enemyGEComponent.FindEffect<GE_Slow>() as GE_Slow);
		enemyGEComponent.onEffectAdded += OnGEAdded;
	}

	private void OnGEAdded(GameplayEffect effect)
	{
		if (effect is GE_Slow)
		{
			ModifySlowValues((GE_Slow)effect);
		}
	}

	private void ModifySlowValues(GE_Slow slowEffect, bool reset = false)
	{
		if (slowEffect != null)
		{
			slowEffect.StacksToRemoveMultiplier = (reset ? 1f : (1f / slowResistanceData.SlowDurationMultiplier));
			slowEffect.SlowMultiplier = (reset ? 1f : slowResistanceData.SlowMultiplier);
		}
	}

	protected override void OnEndEffect()
	{
		ModifySlowValues(enemyGEComponent.FindEffect<GE_Slow>() as GE_Slow, reset: true);
		enemyGEComponent.onEffectAdded -= OnGEAdded;
	}
}
