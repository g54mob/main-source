using Pug.Conversion;

public class MergeDroppedItemConverter : SingleAuthoringComponentConverter<MergeDroppedItemAuthoring>
{
	protected override void Convert(MergeDroppedItemAuthoring authoring)
	{
		EnsureHasComponent<MergeDroppedItemCD>();
	}
}
