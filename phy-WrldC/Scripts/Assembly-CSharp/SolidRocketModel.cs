using UnityEngine;

public class SolidRocketModel : ComponentModel
{
	public const string ActiveKey = "sr_active";

	public const string FuelOutput = "sr_fuel";

	public SolidRocketModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("sr_active", KeyCode.T));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("sr_fuel", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
