using UnityEngine;

public class LavaSlimeBossProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		XScaler.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.3f;
			_ = vector + XScaler.localPosition + vector2;
			Manager.effects.PlayPuff(PuffID.Explosion_Medium, vector + XScaler.localPosition + vector2);
		}
	}
}
