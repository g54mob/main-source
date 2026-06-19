using Pug.Sprite;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public class BulletHellProjectile : Projectile
{
	public SpriteObject fireballSpriteObject;

	public SpriteObject fireballIndirectLightSpriteObject;

	public override void OnOccupied()
	{
		base.OnOccupied();
		directionTransform.gameObject.SetActive(!hasExploded);
		if (!hasExploded && EntityUtility.IsNewlyCreatedObject(base.entity, base.world, !EntityUtility.HasComponentData<PredictedGhost>(base.entity, base.world)))
		{
			if (!TryGetProjectileShootFromPos(out var shootFromPos))
			{
				Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
				Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
				shootFromPos = vector + directionTransform.localPosition + vector2;
			}
			Manager.effects.PlayPuff(PuffID.BulletHellProjectileSpawn, shootFromPos);
			fireballSpriteObject.gameObject.SetActive(value: true);
			fireballIndirectLightSpriteObject.gameObject.SetActive(value: true);
		}
	}

	private bool TryGetProjectileShootFromPos(out Vector3 shootFromPos)
	{
		shootFromPos = default(Vector3);
		EntityUtility.TryGetComponentData<OwnerReferenceCD>(base.entity, base.world, out var value);
		if (value.owner == Entity.Null)
		{
			return false;
		}
		EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(value.owner);
		if (entityMono == null)
		{
			return false;
		}
		if (!(entityMono is IProjectileShooter projectileShooter))
		{
			return false;
		}
		shootFromPos = EntityMonoBehaviour.ToRenderFromWorld(projectileShooter.GetNextProjectileStartWorldPosition());
		return true;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		fireballSpriteObject.gameObject.SetActive(value: false);
		fireballIndirectLightSpriteObject.gameObject.SetActive(value: false);
	}
}
