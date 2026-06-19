using Pug.Conversion;

public class IdleInCombatStateConverter : SingleAuthoringComponentConverter<IdleInCombatStateAuthoring>
{
	protected override void Convert(IdleInCombatStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		AddComponentData(new IdleInCombatStateCD
		{
			sqrDistanceToLeaveCombat = authoring.sqrDistanceToLeaveCombat,
			checkDistanceToPlayerFromSpawnPointInsteadOfSelf = authoring.checkDistanceToPlayerFromSpawnPointInsteadOfSelf
		});
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
