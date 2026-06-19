using UnityEngine;

public class MinigunProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		Vector3 vector = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
		Manager.effects.PlayPuff(PuffID.MinigunProjectileSpawn, particleOptions.particleSpawnLocations[0].position + vector);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		_ = base.transform.position;
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, SRPivot.position);
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
	}
}
