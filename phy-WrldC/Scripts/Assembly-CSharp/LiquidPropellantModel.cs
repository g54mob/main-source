using UnityEngine;

public class LiquidPropellantModel : ComponentModel
{
	public const string FuelOutput = "lpropellant_fuel";

	public LiquidPropellantModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("lpropellant_fuel", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
