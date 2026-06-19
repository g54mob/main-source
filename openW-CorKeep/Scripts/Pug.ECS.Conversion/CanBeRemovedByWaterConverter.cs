using Pug.Conversion;

public class CanBeRemovedByWaterConverter : SingleAuthoringComponentConverter<CanBeRemovedByWaterAuthoring>
{
	protected override void Convert(CanBeRemovedByWaterAuthoring authoring)
	{
		EnsureHasComponent<CanBeRemovedByWaterCD>();
	}
}
