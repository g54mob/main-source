using UnityEngine;

public class BuzzerModel : ComponentModel
{
	public const string ActiveKey = "buzzer_active";

	public const string ActivationType = "buzzer_btn_type";

	public const string VolumeInput = "buzzer_volume_input";

	public const string PitchInput = "buzzer_pitch_input";

	public const string Volume = "buzzer_volume";

	public const string Pitch = "buzzer_pitch";

	public BuzzerModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("buzzer_active", KeyCode.Alpha1, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("buzzer_volume_input", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("buzzer_pitch_input", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("buzzer_btn_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem(LanguagesManager.Instance.GetText("hold", "Hold"));
		comboBoxPropertyModel.AddItem(LanguagesManager.Instance.GetText("toggle", "Toggle"));
		base.ParentBlockBodyModel.AddOverridableProperty(new SliderPropertyModel("buzzer_volume", "1")
		{
			MaxValue = 1f,
			MinValue = 0f,
			StepValue = 0.05f,
			DisplayFormat = "{0:0.00}"
		});
		base.ParentBlockBodyModel.AddOverridableProperty(new SliderPropertyModel("buzzer_pitch", "1")
		{
			MaxValue = 2f,
			MinValue = 0f,
			StepValue = 0.05f,
			DisplayFormat = "{0:0.00}"
		});
	}
}
