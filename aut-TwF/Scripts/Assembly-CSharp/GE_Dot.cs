public class GE_Dot : GameplayEffect
{
	private GE_DotData dotData;

	private CombatComponent enemyCombatComponent;

	protected override void OnInitEffect()
	{
		dotData = base.EffectData as GE_DotData;
		enemyCombatComponent = base.Owner.GetComponent<CombatComponent>();
	}

	protected override void OnStacksRemoved(int removedStacks)
	{
		enemyCombatComponent.DoDamage(null, new FDamageData(removedStacks * dotData.DamagePerStack, dotData.HealthMultiplier, dotData.ArmorMultiplier, dotData.ShieldMultiplier), reportDamage: true);
	}
}
