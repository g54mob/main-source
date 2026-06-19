using UnityEngine;

public class CoreBossElectricProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
			Vector3 vector2 = componentData.GetDirection3() * 0.3f;
			_ = vector + directionTransform.localPosition + vector2;
			Manager.effects.PlayPuff(PuffID.SmallEnergyExplosion, vector + directionTransform.localPosition + vector2);
			directionTransform.LookAt(directionTransform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
		}
	}
}
