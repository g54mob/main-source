using UnityEngine;

public class GrubzookaProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		Vector3 vector = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
		Manager.effects.PlayPuff(PuffID.GrubzookaFire, SRPivot.position + vector);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.AcidSplat2, base.transform.position + new Vector3(0f, 0.5f, 0f));
	}
}
