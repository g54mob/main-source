using Pug.Conversion;

public class ShieldConverter : SingleAuthoringComponentConverter<ShieldAuthoring>
{
	protected override void Convert(ShieldAuthoring authoring)
	{
		AddComponentData(new ShieldCD
		{
			shieldWidthDegrees = authoring.shieldWidthDegrees,
			active = authoring.defaultShieldActive
		});
	}
}
