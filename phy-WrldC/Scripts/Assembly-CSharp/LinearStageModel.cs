using UnityEngine;

public class LinearStageModel : ComponentModel
{
	public const string MoveRightKey = "linear_s_right";

	public const string MoveLeftKey = "linear_s_left";

	public const string MovementType = "linear_s_type";

	public const string LinearSpeed = "linear_s_speed";

	public const string PositionInput = "linear_s_position_in";

	public const string PositionOutput = "linear_s_position_out";

	public LinearStageModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("linear_s_right", KeyCode.RightArrow, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("linear_s_left", KeyCode.LeftArrow, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("linear_s_position_in", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("linear_s_position_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("linear_s_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem("Linear");
		comboBoxPropertyModel.AddItem("Total");
		comboBoxPropertyModel.AddItem("Middle");
		base.ParentBlockBodyModel.AddOverridableProperty(new SliderPropertyModel("linear_s_speed", "3.0")
		{
			MaxValue = 10f,
			MinValue = 0.5f,
			StepValue = 0.5f,
			DisplayFormat = "{0:0.0} (m/s)"
		});
	}
}
