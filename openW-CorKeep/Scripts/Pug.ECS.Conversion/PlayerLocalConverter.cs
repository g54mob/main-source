using Pug.Conversion;

public class PlayerLocalConverter : SingleAuthoringComponentConverter<PlayerLocalAuthoring>
{
	protected override void Convert(PlayerLocalAuthoring authoring)
	{
		EnsureHasComponent<PlayerMovementForceCD>();
	}
}
