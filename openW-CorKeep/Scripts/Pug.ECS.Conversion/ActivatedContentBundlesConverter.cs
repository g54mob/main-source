using Pug.Conversion;

public class ActivatedContentBundlesConverter : SingleAuthoringComponentConverter<ActivatedContentBundlesAuthoring>
{
	protected override void Convert(ActivatedContentBundlesAuthoring authoring)
	{
		EnsureHasBuffer<ActivatedContentBundlesBuffer>();
	}
}
