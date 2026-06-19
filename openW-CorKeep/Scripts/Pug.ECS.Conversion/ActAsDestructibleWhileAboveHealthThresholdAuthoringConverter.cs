using Pug.Conversion;

public class ActAsDestructibleWhileAboveHealthThresholdAuthoringConverter : SingleAuthoringComponentConverter<ActAsDestructibleWhileAboveHealthThresholdAuthoring>
{
	protected override void Convert(ActAsDestructibleWhileAboveHealthThresholdAuthoring authoring)
	{
		AddComponentData(new EnemyActAsDestructibleCD
		{
			healthThreshold = authoring.threshold,
			damageReductionBackup = default(DamageReductionCD)
		});
	}
}
