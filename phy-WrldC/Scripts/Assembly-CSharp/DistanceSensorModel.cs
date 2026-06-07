using UnityEngine;

public class DistanceSensorModel : ComponentModel
{
	public const string ObstacleOutput = "ds_obstacle_out";

	public const string DistanceOutput = "ds_distance_out";

	public const string MaxRange = "ds_max_range";

	public DistanceSensorModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ds_obstacle_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("ds_distance_out", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
		base.ParentBlockBodyModel.AddOverridableProperty(new SliderPropertyModel("ds_max_range", "3")
		{
			MinValue = 0.05f,
			MaxValue = 3f,
			StepValue = 0.05f,
			DisplayFormat = "{0:0.00} unit"
		});
	}
}
