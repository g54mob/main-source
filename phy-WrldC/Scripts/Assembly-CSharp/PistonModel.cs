using UnityEngine;

public class PistonModel : ComponentModel
{
	public const string ActiveKey = "piston_active";

	public const string ActivationType = "piston_btn_type";

	public const string InvertLogic = "piston_invert_logic";

	public const string ExtendedOutput = "piston_extended_out";

	public PistonModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("piston_active", KeyCode.T));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("piston_extended_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("piston_btn_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem("Hold");
		comboBoxPropertyModel.AddItem("Toggle");
		base.ParentBlockBodyModel.AddOverridableProperty(new BooleanPropertyModel("piston_invert_logic", value: false));
	}
}
