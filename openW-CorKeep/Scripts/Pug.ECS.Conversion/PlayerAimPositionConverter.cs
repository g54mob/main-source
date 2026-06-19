using Pug.Conversion;

public class PlayerAimPositionConverter : SingleAuthoringComponentConverter<PlayerAimPositionAuthoring>
{
	protected override void Convert(PlayerAimPositionAuthoring authoring)
	{
		AddComponentData(new PlayerAimPositionCD
		{
			position = authoring.position
		});
	}
}
