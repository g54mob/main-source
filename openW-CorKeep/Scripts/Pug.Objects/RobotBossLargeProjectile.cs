using Pug.Sprite;
using Unity.NetCode;
using UnityEngine;

public class RobotBossLargeProjectile : Projectile
{
	public SpriteObject fireballSpriteObject;

	public SpriteObject fireballIndirectLightSpriteObject;

	public override void OnOccupied()
	{
		base.OnOccupied();
		directionTransform.gameObject.SetActive(!hasExploded);
		if (!hasExploded && EntityUtility.IsNewlyCreatedObject(base.entity, base.world, !EntityUtility.HasComponentData<PredictedGhost>(base.entity, base.world)))
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
			Manager.effects.PlayPuff(PuffID.Explosion_Stun, vector + directionTransform.localPosition + vector2);
			fireballSpriteObject.gameObject.SetActive(value: true);
			fireballIndirectLightSpriteObject.gameObject.SetActive(value: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		fireballSpriteObject.gameObject.SetActive(value: false);
		fireballIndirectLightSpriteObject.gameObject.SetActive(value: false);
	}
}
