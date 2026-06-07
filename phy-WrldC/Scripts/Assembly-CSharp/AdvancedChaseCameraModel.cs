using UnityEngine;

public class AdvancedChaseCameraModel : ComponentModel
{
	public const string ActiveKey = "ac_camera_active";

	public AdvancedChaseCameraModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ac_camera_active", KeyCode.V));
	}
}
