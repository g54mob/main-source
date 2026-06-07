using UnityEngine;

public class ThrusterModel : ComponentModel
{
	public const string ActiveKey = "thruster_active";

	public const string FuelOutput = "thruster_fuel";

	public ThrusterModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("thruster_active", KeyCode.T, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("thruster_fuel", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
