using UnityEngine;

public class SteerableBlockModel : ComponentModel
{
	public const string FreeSpin = "steerb_free_spin";

	public const string ForwardKey = "steerb_forward";

	public const string BackwardKey = "steerb_backward";

	public const string InvertDirection = "steerb_invert_direction";

	public const string PositionInput = "steerb_position_in";

	public const string PositionOutput = "steerb_position_out";

	public SteerableBlockModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("steerb_forward", KeyCode.LeftArrow, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("steerb_backward", KeyCode.RightArrow, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("steerb_position_in", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("steerb_position_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddOverridableProperty(new BooleanPropertyModel("steerb_free_spin", value: false));
		base.ParentBlockBodyModel.AddOverridableProperty(new BooleanPropertyModel("steerb_invert_direction", value: false));
	}
}
