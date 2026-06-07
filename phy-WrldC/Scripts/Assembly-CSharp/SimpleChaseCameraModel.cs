using UnityEngine;

public class SimpleChaseCameraModel : ComponentModel
{
	public const string ActiveKey = "sc_camera_active";

	public SimpleChaseCameraModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("sc_camera_active", KeyCode.V));
	}
}
