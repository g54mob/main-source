using UnityEngine;

public class SpeedSensorModel : ComponentModel
{
	public const string GlobalSpeedOutput = "ss_global_out";

	public const string XSpeedOutput = "ss_x_out";

	public const string YSpeedOutput = "ss_y_out";

	public const string ZSpeedOutput = "ss_z_out";

	public SpeedSensorModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ss_global_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ss_x_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ss_y_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ss_z_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
