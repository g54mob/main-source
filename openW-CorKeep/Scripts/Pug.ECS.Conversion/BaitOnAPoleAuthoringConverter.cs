using Pug.Conversion;

public class BaitOnAPoleAuthoringConverter : SingleAuthoringComponentConverter<BaitOnAPoleAuthoring>
{
	protected override void Convert(BaitOnAPoleAuthoring authoring)
	{
		EnsureHasComponent<BaitCD>();
		EnsureHasComponent<BaitOnAPoleCD>();
		EnsureHasComponent<OwnerReferenceCD>();
	}
}
