using Pug.Conversion;

public class DamageableObjectConverter : SingleAuthoringComponentConverter<DamageableObjectAuthoring>
{
	protected override void Convert(DamageableObjectAuthoring authoring)
	{
		EnsureHasComponent<DamageableObjectCD>();
	}
}
