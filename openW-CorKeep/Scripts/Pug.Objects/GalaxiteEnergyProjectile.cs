using Pug.Sprite;
using UnityEngine;

public class GalaxiteEnergyProjectile : Projectile
{
	public SpriteObject fireballSpriteObject;

	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
			directionTransform.LookAt(directionTransform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
			fireballSpriteObject.gameObject.SetActive(value: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		fireballSpriteObject.gameObject.SetActive(value: false);
	}
}
