using Pug.Conversion;

public class DamageEffectConverter : SingleAuthoringComponentConverter<DamageEffectAuthoring>
{
	protected override void Convert(DamageEffectAuthoring authoring)
	{
		EnsureHasComponent<DamageEffectCD>();
	}
}
