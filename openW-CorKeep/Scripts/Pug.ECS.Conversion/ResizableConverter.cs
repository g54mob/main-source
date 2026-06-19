using Pug.Conversion;

public class ResizableConverter : SingleAuthoringComponentConverter<ResizableTileSizeAuthoring>
{
	protected override void Convert(ResizableTileSizeAuthoring authoring)
	{
		AddComponentData(new ResizableTileSizeCD
		{
			StartOnSmallestSize = authoring.StartOnSmallestSize
		});
	}
}
