using Pug.Conversion;

public class SnakeBossConverter : SingleAuthoringComponentConverter<SnakeBossAuthoring>
{
	protected override void Convert(SnakeBossAuthoring authoring)
	{
		EnsureHasComponent<BaitableCD>();
		AddComponentData(new SnakeBossCD
		{
			internalState = -1,
			amountOfSegmentsRemainingToEnrage = 6,
			projectileCooldownTimer = 5f,
			defeatSoundEffectDelay = authoring.defeatSoundEffectDelay
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<IsInCombatCD>();
	}
}
