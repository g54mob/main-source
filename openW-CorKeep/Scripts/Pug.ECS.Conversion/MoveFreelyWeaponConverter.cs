using Pug.Conversion;

public class MoveFreelyWeaponConverter : SingleAuthoringComponentConverter<MoveFreelyWeaponAuthoring>
{
	protected override void Convert(MoveFreelyWeaponAuthoring authoring)
	{
		AddComponentData(new MoveFreelyWeaponCD
		{
			moveSpeedMultiplier = authoring.moveSpeedMultiplier
		});
	}
}
