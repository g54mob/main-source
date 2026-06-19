using Pug.Conversion;

public class DetectCollisionConverter : SingleAuthoringComponentConverter<DetectCollisionAuthoring>
{
	protected override void Convert(DetectCollisionAuthoring authoring)
	{
		EnsureHasComponent<DetectCollisionCD>();
	}
}
