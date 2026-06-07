using UnityEngine;

public class MultiCameraModel : ComponentModel
{
	public const string ActiveKey = "multi_camera_active";

	public const string CameraType = "multi_camera_type";

	public const string AutoActive = "multi_camera_auto_active";

	public MultiCameraModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("multi_camera_active", KeyCode.V)
		{
			IsHiddenInLogic = true
		});
		ComboBoxPropertyModel comboBoxPropertyModel = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("multi_camera_type", "0", isIndexAsKey: true));
		comboBoxPropertyModel.AddItem("FPS");
		comboBoxPropertyModel.AddItem("Fixed Third");
		comboBoxPropertyModel.AddItem("Smooth Third");
		base.ParentBlockBodyModel.AddOverridableProperty(new BooleanPropertyModel("multi_camera_auto_active", value: false));
	}
}
