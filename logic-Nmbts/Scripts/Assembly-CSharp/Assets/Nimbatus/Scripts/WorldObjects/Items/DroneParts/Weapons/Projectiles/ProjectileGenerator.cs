using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles
{
	public abstract class ProjectileGenerator : NimbatusItem
	{
		[HideInInspector]
		[SerializeField]
		protected ProjectileEmitter Emitter;

		public NimbatusParticleEffect ShootEffect;

		public EnumAttribute<EProjectileExplosionMode> ExplosionMode = new EnumAttribute<EProjectileExplosionMode>();

		public EnumAttribute<EProjectileCollisionMode> CollisionMode = new EnumAttribute<EProjectileCollisionMode>();

		public FloatWeaponAttribute ProjectileLifetime = new FloatWeaponAttribute();

		public FloatWeaponAttribute ProjectileAirResistence = new FloatWeaponAttribute();

		public abstract List<WeaponAttribute> GetAttributes();

		public virtual void Init(ProjectileEmitter emitter)
		{
			Emitter = emitter;
			ExplosionMode.Init(EWeaponAttributeType.ExplosionMode, true);
			CollisionMode.Init(EWeaponAttributeType.ProjectileCollisionMode, true);
			ProjectileLifetime.Init(EWeaponAttributeType.ProjectileLifetime, 2, 0f, 15f, !emitter.UsedByEnemy);
			ProjectileAirResistence.Init(EWeaponAttributeType.ProjectileAirResistence, 0, 0f, 50f, !emitter.UsedByEnemy, true);
		}

		public abstract Projectile CreateProjectile();

		public abstract void InitProjectile(Projectile projectile);

		public override void FillUpData(ref NimbatusItemData data)
		{
		}

		public override NimbatusItemData CreateData()
		{
			return new NimbatusItemData();
		}
	}
}
