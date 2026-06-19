using UnityEngine;

public class CrossbowBoltProjectile : Projectile
{
	public ParticleSystem boltTrail;

	public override void OnOccupied()
	{
		base.OnOccupied();
		EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		_ = (Vector3)(EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f);
		if (currentHealth > 0 && (bool)boltTrail)
		{
			boltTrail.Play(withChildren: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
		if ((bool)boltTrail)
		{
			boltTrail.Stop();
		}
	}
}
