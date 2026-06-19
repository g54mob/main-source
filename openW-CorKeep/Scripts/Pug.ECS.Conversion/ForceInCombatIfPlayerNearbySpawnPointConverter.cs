using Pug.Conversion;

public class ForceInCombatIfPlayerNearbySpawnPointConverter : SingleAuthoringComponentConverter<ForceInCombatIfPlayerNearbySpawnPointAuthoring>
{
	protected override void Convert(ForceInCombatIfPlayerNearbySpawnPointAuthoring authoring)
	{
		AddComponentData(new ForceInCombatIfPlayerNearbySpawnPointCD
		{
			distanceToStayInCombatSq = authoring.distanceToStayInCombat * authoring.distanceToStayInCombat
		});
	}
}
