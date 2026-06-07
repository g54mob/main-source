using UnityEngine;

public class FPSCameraModel : ComponentModel
{
	public const string ActiveKey = "fps_camera_active";

	public FPSCameraModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("fps_camera_active", KeyCode.V));
	}
}
