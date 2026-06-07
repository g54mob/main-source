using UnityEngine;

public class GrabberModel : ComponentModel
{
	public const string ActiveKey = "grabber_active";

	public const string ActivationType = "grabber_btn_type";

	public const string InvertLogic = "grabber_invert_logic";

	public const string ActivedOutput = "grabber_activated_out";

	public const string GrabbedOutput = "grabber_grabbed_out";

	public GrabberModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("grabber_active", KeyCode.G));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("grabber_activated_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("grabber_grabbed_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("grabber_btn_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem("Hold");
		comboBoxPropertyModel.AddItem("Toggle");
		base.ParentBlockBodyModel.AddOverridableProperty(new BooleanPropertyModel("grabber_invert_logic", value: false));
	}
}
