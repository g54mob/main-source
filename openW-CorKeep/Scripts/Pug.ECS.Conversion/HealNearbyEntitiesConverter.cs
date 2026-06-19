using Pug.Conversion;

public class HealNearbyEntitiesConverter : SingleAuthoringComponentConverter<HealNearbyEntitiesAuthoring>
{
	protected override void Convert(HealNearbyEntitiesAuthoring authoring)
	{
		AddComponentData(new HealNearbyEntitiesCD
		{
			isActive = authoring.isActive,
			healsTargetsOfFaction = authoring.healsTargetsOfFaction,
			healthPerSecond = authoring.healthPerSecond,
			radius = authoring.radius
		});
	}
}
