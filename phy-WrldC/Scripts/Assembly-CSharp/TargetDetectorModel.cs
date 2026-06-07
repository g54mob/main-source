using UnityEngine;

public class TargetDetectorModel : ComponentModel
{
	public const string TargetDetected = "td_target_detected";

	public TargetDetectorModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("td_target_detected", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
