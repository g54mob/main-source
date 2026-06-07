using UnityEngine;

public class GE_Slow : GameplayEffect
{
	private GE_SlowData slowData;

	private StatsComponent enemyStatsComponent;

	private float slowMultiplier = 1f;

	private float stacksToRemoveMultiplier = 1f;

	public float SlowMultiplier
	{
		get
		{
			return slowMultiplier;
		}
		set
		{
			if (slowMultiplier != value)
			{
				int num = base.CurrentStacks / slowData.StacksPerSlowStep;
				for (int i = 0; i < num; i++)
				{
					RemoveSlow(i == num - 1);
				}
				slowMultiplier = value;
				for (int j = 0; j < num; j++)
				{
					AddSlow(j == 0);
				}
			}
		}
	}

	public float StacksToRemoveMultiplier
	{
		get
		{
			return stacksToRemoveMultiplier;
		}
		set
		{
			stacksToRemoveMultiplier = value;
		}
	}

	protected override int StacksToRemove => Mathf.RoundToInt((float)base.EffectData.StacksToRemove * StacksToRemoveMultiplier);

	protected override void OnInitEffect()
	{
		slowData = base.EffectData as GE_SlowData;
		enemyStatsComponent = base.Owner.GetComponent<StatsComponent>();
	}

	protected override void OnStacksAdded(int addedStacks)
	{
		base.OnStacksAdded(addedStacks);
		int num = base.CurrentStacks - addedStacks;
		if (num == 0)
		{
			AddSlow(initial: true);
		}
		int num2 = base.CurrentStacks / slowData.StacksPerSlowStep - num / slowData.StacksPerSlowStep;
		for (int i = 0; i < num2; i++)
		{
			AddSlow(initial: false);
		}
	}

	protected override void OnStacksRemoved(int removedStacks)
	{
		base.OnStacksRemoved(removedStacks);
		int num = (base.CurrentStacks + removedStacks) / slowData.StacksPerSlowStep - base.CurrentStacks / slowData.StacksPerSlowStep;
		for (int i = 0; i < num; i++)
		{
			RemoveSlow(initial: false);
		}
		if (base.CurrentStacks == 0)
		{
			RemoveSlow(initial: true);
		}
	}

	private void AddSlow(bool initial)
	{
		enemyStatsComponent.AddStatModifier(new StatModifier(EStats.MovementSpeed, ModifierOperation.Multiplicative, (initial ? slowData.StarterSlowPercentage : slowData.SlowPercentagePerSlowStep) * SlowMultiplier));
	}

	private void RemoveSlow(bool initial)
	{
		enemyStatsComponent.RemoveStatModifier(new StatModifier(EStats.MovementSpeed, ModifierOperation.Multiplicative, (initial ? slowData.StarterSlowPercentage : slowData.SlowPercentagePerSlowStep) * SlowMultiplier));
	}
}
