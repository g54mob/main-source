using UnityEngine;

public class DynamicSpringModel : ComponentModel
{
	public const string ReleaseKey = "dspring_release";

	public const string Released = "dspring_released";

	public DynamicSpringModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("dspring_release", KeyCode.T));
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("dspring_released", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
