using UnityEngine;

public class StabilizerModel : ComponentModel
{
	public const string AngleControlActiveKey = "stb_ang_active";

	public const string PositionControlActiveKey = "stb_pos_active";

	public const string Strength = "stb_strength";

	public const string StrengthInput = "stb_strength_input";

	public StabilizerModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("stb_ang_active", KeyCode.U));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("stb_pos_active", KeyCode.U));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("stb_strength_input", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		base.ParentBlockBodyModel.AddOverridableProperty(new SliderPropertyModel("stb_strength", "0.5")
		{
			MaxValue = 1f,
			MinValue = 0f,
			StepValue = 0.05f,
			DisplayFormat = "{0:P0}"
		});
	}
}
