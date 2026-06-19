using UnityEngine;

public class OctarineArrowProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		_ = (Vector3)(EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, SRPivot.position, 4);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebrisBox, SRPivot.position);
		Manager.effects.PlayPuff(PuffID.SmallAncientSmoke, SRPivot.position, 8);
		Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, SRPivot.position, 8);
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
	}
}
