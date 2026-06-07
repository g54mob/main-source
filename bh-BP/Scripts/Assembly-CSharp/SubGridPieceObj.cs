using UnityEngine;

public class SubGridPieceObj : GridPieceObj
{
	[Header("SUB")]
	public GridPieceObj Owner;

	public bool ShouldAnimateEntry;

	public bool IsAnimated;

	protected override void Remove()
	{
	}

	public override bool ShouldSpawnMesh()
	{
		return false;
	}

	public override void ResetSprite()
	{
	}

	public override void OnHit(Vector3 hitPos, Vector2 hitNormal, DamageType dmgType)
	{
	}

	public override bool IsChild()
	{
		return false;
	}

	public override bool CanBeAttackedByAlly()
	{
		return false;
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override void DropDeathStuff()
	{
	}

	protected override void OnDeathComplete()
	{
	}
}
