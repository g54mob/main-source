using UnityEngine;

public class DecouplerModel : ComponentModel
{
	public const string ActiveKey = "decoupler_active";

	public const string Separated = "decouple_separated";

	public DecouplerModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("decoupler_active", KeyCode.O));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("decouple_separated", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
