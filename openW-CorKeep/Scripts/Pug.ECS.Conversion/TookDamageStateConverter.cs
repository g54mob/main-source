using Pug.Conversion;

public class TookDamageStateConverter : SingleAuthoringComponentConverter<TookDamageStateAuthoring>
{
	protected override void Convert(TookDamageStateAuthoring authoring)
	{
		AddComponentData(new TookDamageStateCD
		{
			duration = authoring.duration,
			refreshStateOnNewDamageTaken = authoring.refreshStateOnNewDamageTaken
		});
		EnsureHasComponent<DamageEffectCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
