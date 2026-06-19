using UnityEngine;

public class SmallFireballProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0f;
			Manager.effects.PlayPuff(PuffID.SmallFireExplosion, vector + directionTransform.localPosition + vector2);
		}
	}
}
