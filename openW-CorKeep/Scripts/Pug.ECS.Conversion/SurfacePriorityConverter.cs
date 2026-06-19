using Pug.Conversion;

public class SurfacePriorityConverter : SingleAuthoringComponentConverter<SurfacePriorityAuthoring>
{
	protected override void Convert(SurfacePriorityAuthoring authoring)
	{
		AddComponentData(new SurfacePriorityCD
		{
			Value = authoring.Value
		});
	}
}
