using Unity.NetCode;
using UnityEngine;

public class BurnzookaProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		if (!hasExploded && EntityUtility.IsNewlyCreatedObject(base.entity, base.world, !EntityUtility.HasComponentData<PredictedGhost>(base.entity, base.world)))
		{
			Vector3 vector = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
			Manager.effects.PlayPuff(PuffID.MusketFire, SRPivot.position + vector);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, position);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebrisBox, position, 20);
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
	}
}
