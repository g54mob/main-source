using Pug.Conversion;

public class DestructibleObjectConverter : SingleAuthoringComponentConverter<DestructibleObjectAuthoring>
{
	protected override void Convert(DestructibleObjectAuthoring authoring)
	{
		EnsureHasComponent<DestructibleObjectCD>();
		if (authoring.requiresDrill)
		{
			EnsureHasComponent<RequiresDrillCD>();
		}
	}
}
