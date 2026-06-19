using Pug.Conversion;

public class ImmuneToDamageConverter : SingleAuthoringComponentConverter<ImmuneToDamageAuthoring>
{
	protected override void Convert(ImmuneToDamageAuthoring authoring)
	{
		AddComponentData(new ImmuneToDamageCD
		{
			Value = authoring.defaultValue,
			effectIDOverride = authoring.defaultEffectIDOverride
		});
	}
}
