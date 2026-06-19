using UnityEngine;

public class SlimeProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		Vector3 vector = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
		Manager.effects.PlayPuff(PuffID.OrangeSlipperyPuff, particleOptions.particleSpawnLocations[0].position + vector, 8);
		Manager.effects.PlayPuff(PuffID.SlimeBlobDeathOrange, particleOptions.particleSpawnLocations[0].position + vector, 4);
	}
}
