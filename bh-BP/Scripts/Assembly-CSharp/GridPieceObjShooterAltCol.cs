using UnityEngine;

public class GridPieceObjShooterAltCol : GridPieceObjShooter
{
	[NamedArray(typeof(LevelType))]
	public Collider2D[] ColsByLevel;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void InitShadow()
	{
	}

	public override void RegisterColliders()
	{
	}

	public override void DeregisterColliders()
	{
	}
}
