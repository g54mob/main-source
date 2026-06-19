using Pug.Conversion;

public class DamageReductionConverter : SingleAuthoringComponentConverter<DamageReductionAuthoring>
{
	protected override void Convert(DamageReductionAuthoring authoring)
	{
		int reduction = authoring.reduction;
		if (authoring.calculateReductionFromLevel && TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			reduction = authoring.LevelToReduction(component.level);
		}
		AddComponentData(new DamageReductionCD
		{
			reduction = reduction,
			maxDamagePerHit = authoring.maxDamagePerHit,
			minDamagePerHit = authoring.minDamagePerHit,
			ignoreReductionWhenDamagedByDrill = authoring.ignoreReductionWhenDamagedByDrill
		});
	}
}
