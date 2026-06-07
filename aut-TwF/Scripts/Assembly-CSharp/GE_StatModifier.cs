public class GE_StatModifier : GameplayEffect
{
	private GE_StatModifierData statModifierData;

	protected override void OnInitEffect()
	{
		statModifierData = base.EffectData as GE_StatModifierData;
	}

	protected override void OnStacksAdded(int addedStacks)
	{
		for (int i = 0; i < addedStacks; i++)
		{
			if (statModifierData.ModifyStatBase)
			{
				float num = ((statModifierData.ModifierOperation != ModifierOperation.Multiplicative) ? statModifierData.StatValue : (base.Owner.StatsComponent.GetConfigStat(statModifierData.Stat) * statModifierData.StatValue));
				base.Owner.StatsComponent.SetStat(statModifierData.Stat, base.Owner.StatsComponent.GetStatBase(statModifierData.Stat) + num);
			}
			else
			{
				base.Owner.StatsComponent.AddStatModifier(new StatModifier(statModifierData.Stat, statModifierData.ModifierOperation, statModifierData.StatValue));
			}
		}
	}

	protected override void OnStacksRemoved(int removedStacks)
	{
		for (int i = 0; i < removedStacks; i++)
		{
			if (statModifierData.ModifyStatBase)
			{
				float num = ((statModifierData.ModifierOperation != ModifierOperation.Multiplicative) ? statModifierData.StatValue : (base.Owner.StatsComponent.GetConfigStat(statModifierData.Stat) * statModifierData.StatValue));
				base.Owner.StatsComponent.SetStat(statModifierData.Stat, base.Owner.StatsComponent.GetStatBase(statModifierData.Stat) - num);
			}
			else
			{
				base.Owner.StatsComponent.RemoveStatModifier(statModifierData.GetStatModifier());
			}
		}
	}
}
