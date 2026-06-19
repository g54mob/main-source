using Pug.Conversion;

public class ShamanBossConverter : SingleAuthoringComponentConverter<ShamanBossAuthoring>
{
	protected override void Convert(ShamanBossAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<ShamanBossCD>();
		AddComponentData(new PhaseTransitionStateCD
		{
			phase1TransitionDuration = authoring.phase1TransitionDuration,
			phase1HealthThreshold = authoring.phase1HealthThreshold,
			invulnerableDuration = authoring.invulnerableDuration
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<IsInCombatCD>();
	}
}
