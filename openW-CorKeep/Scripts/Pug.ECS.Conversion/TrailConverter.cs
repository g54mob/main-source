using Pug.Conversion;

public class TrailConverter : SingleAuthoringComponentConverter<TrailAuthoring>
{
	protected override void Convert(TrailAuthoring authoring)
	{
		EnsureHasComponent<OwnerReferenceCD>();
	}
}
