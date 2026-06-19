using UnityEngine;

public class BunnyPoisonDartProjectile : Projectile
{
	public ParticleSystem trail;

	public override void OnOccupied()
	{
		base.OnOccupied();
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
		Manager.effects.PlayPuff(PuffID.SmallPurplePuff, vector + SRPivot.localPosition + vector2, 8);
		if ((bool)trail)
		{
			trail.Play(withChildren: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if ((bool)trail)
		{
			trail.Stop();
		}
		Vector3 position = base.transform.position;
		Manager.effects.PlayPuff(PuffID.MediumPurplePuff, position);
	}
}
