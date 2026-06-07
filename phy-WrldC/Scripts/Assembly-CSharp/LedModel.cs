using UnityEngine;

public class LedModel : ComponentModel
{
	public const string ActiveKey = "led_active";

	public const string ActivationType = "led_btn_type";

	public const string ColorInput = "led_color_input";

	public const string Color = "led_color";

	public const string MaxIntensity = "led_intensity";

	public LedModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("led_active", KeyCode.Alpha1, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("led_color_input", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("led_btn_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem(LanguagesManager.Instance.GetText("hold", "Hold"));
		comboBoxPropertyModel.AddItem(LanguagesManager.Instance.GetText("toggle", "Toggle"));
		ComboBoxPropertyModel comboBoxPropertyModel2 = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("led_color", "1", isIndexAsKey: true));
		comboBoxPropertyModel2.AddItem(LanguagesManager.Instance.GetText("red", "Red"));
		comboBoxPropertyModel2.AddItem(LanguagesManager.Instance.GetText("green", "Green"));
		comboBoxPropertyModel2.AddItem(LanguagesManager.Instance.GetText("blue", "Blue"));
		comboBoxPropertyModel2.AddItem(LanguagesManager.Instance.GetText("yellow", "Yellow"));
		comboBoxPropertyModel2.AddItem(LanguagesManager.Instance.GetText("white", "White"));
		base.ParentBlockBodyModel.AddOverridableProperty(new SliderPropertyModel("led_intensity", "1")
		{
			MaxValue = 1f,
			MinValue = 0f,
			StepValue = 0.05f,
			DisplayFormat = "{0:P0}"
		});
	}
}
