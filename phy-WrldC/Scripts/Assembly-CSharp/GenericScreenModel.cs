using UnityEngine;

public class GenericScreenModel : ComponentModel
{
	public const string ScreenValue = "gscreen_value";

	public const string ScreenLabel = "gscreen_label";

	public const string ValueType = "gscreen_type";

	public GenericScreenModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("gscreen_value", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		base.ParentBlockBodyModel.AddOverridableProperty(new TextFieldPropertyModel("gscreen_label", string.Empty));
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("gscreen_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem("Raw");
		comboBoxPropertyModel.AddItem("%");
		comboBoxPropertyModel.AddItem("Bar");
	}
}
