using UnityEngine;

public abstract class GE_StacksConsumer : GameplayEffect
{
	private GE_StacksConsumerData stacksConsumerData;

	protected TowerCombatComponent towerCombatComponent;

	protected override void OnInitEffect()
	{
		stacksConsumerData = base.EffectData as GE_StacksConsumerData;
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		towerCombatComponent.onDamageEnemy += OnDamageEnemy;
	}

	protected override void OnEndEffect()
	{
		towerCombatComponent.onDamageEnemy -= OnDamageEnemy;
	}

	private void OnDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 damagePosition, bool isMainDamage, object auxData, FDamageReport damageReport)
	{
		if (!isMainDamage)
		{
			return;
		}
		GameplayEffect gameplayEffect = enemy?.GameplayEffectsComponent?.FindEffect(stacksConsumerData.GameplayEffectToConsume);
		if (gameplayEffect != null)
		{
			OnHit(enemy, data, damagePosition, (stacksConsumerData.MaxStacksToConsume > 0) ? Mathf.Min(stacksConsumerData.MaxStacksToConsume, gameplayEffect.CurrentStacks) : gameplayEffect.CurrentStacks);
			if (stacksConsumerData.AutoConsumeStacks)
			{
				ConsumeStacks(enemy, gameplayEffect.CurrentStacks);
			}
		}
	}

	protected void ConsumeStacks(Enemy enemy, int stacksToConsume)
	{
		enemy.GameplayEffectsComponent.RemoveEffect(stacksConsumerData.GameplayEffectToConsume, (stacksConsumerData.MaxStacksToConsume > 0) ? Mathf.Min(stacksConsumerData.MaxStacksToConsume, stacksToConsume) : stacksToConsume);
	}

	protected virtual void OnHit(Enemy enemy, FDamageData data, Vector3 damagePosition, int stacks)
	{
	}
}
