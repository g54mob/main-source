using Pug.Conversion;

public class NonHittableConverter : SingleAuthoringComponentConverter<NonHittableAuthoring>
{
	protected override void Convert(NonHittableAuthoring authoring)
	{
		EnsureHasComponent<NonHittableCD>();
	}
}
