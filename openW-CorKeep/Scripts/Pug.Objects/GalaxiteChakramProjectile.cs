using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class GalaxiteChakramProjectile : Projectile
{
	public ParticleSystem projectileTrail;

	public SpriteRenderer shadowSprite;

	public SpriteObject indirectLightSprite;

	public PlatformDependentValue<bool> disableShadow;

	public PlatformDependentValue<bool> disableIndirectLight;

	protected override void Awake()
	{
		if (disableShadow.GetValueForCurrentPlatform())
		{
			shadowSprite.enabled = false;
		}
		if (disableIndirectLight.GetValueForCurrentPlatform())
		{
			indirectLightSprite.gameObject.SetActive(value: false);
		}
		base.Awake();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
		Vector3 vector2 = componentData.GetDirection3() * 0.5f;
		Manager.effects.PlayPuff(PuffID.DirtItemDust, vector + SRPivot.localPosition + vector2, 5);
		projectileTrail.Play(withChildren: true);
		projectileTrail.transform.LookAt(projectileTrail.transform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
		projectileTrail.transform.LookAt(projectileTrail.transform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.PlayPuff(PuffID.SmallColorfulExplosion, position);
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
		if ((bool)projectileTrail)
		{
			projectileTrail.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}
}
