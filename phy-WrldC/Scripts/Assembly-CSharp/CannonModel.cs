using UnityEngine;

public class CannonModel : ComponentModel
{
	public const string Fire = "cannon_fire";

	public CannonModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("cannon_fire", KeyCode.F));
	}
}
