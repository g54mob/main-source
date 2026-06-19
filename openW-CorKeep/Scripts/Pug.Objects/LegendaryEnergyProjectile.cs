using Pug.Sprite;
using UnityEngine;

public class LegendaryEnergyProjectile : Projectile
{
	public SpriteObject fireballSpriteObject;

	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
			Vector3 position = vector + directionTransform.localPosition + vector2;
			Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, position, 8);
			fireballSpriteObject.gameObject.SetActive(value: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		fireballSpriteObject.gameObject.SetActive(value: false);
	}
}
