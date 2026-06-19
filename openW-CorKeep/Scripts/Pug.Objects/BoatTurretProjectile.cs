using UnityEngine;

public class BoatTurretProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, position, 4);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebrisBox, position, 30);
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
	}
}
