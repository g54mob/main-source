using Pug.Conversion;

public class DurabilityConverter : SingleAuthoringComponentConverter<DurabilityAuthoring>
{
	protected override void Convert(DurabilityAuthoring authoring)
	{
		AddComponentData(new DurabilityCD
		{
			maxDurability = authoring.maxDurability,
			repairCostMultiplier = authoring.repairMultiplier,
			reinforceCostMultiplier = authoring.reinforceCostMultiplier
		});
	}
}
