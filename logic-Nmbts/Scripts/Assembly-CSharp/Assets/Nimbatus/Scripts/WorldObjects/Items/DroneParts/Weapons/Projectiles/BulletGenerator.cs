using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles
{
	public class BulletGenerator : ProjectileGenerator
	{
		public Projectile Prefab;

		public override Projectile CreateProjectile()
		{
			return Object.Instantiate(Prefab);
		}

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public override void InitProjectile(Projectile projectile)
		{
			projectile.Init(Emitter, Emitter.Ammunition, Emitter.Damage.Value * Emitter.DamageModifier, CollisionMode.Value, ProjectileLifetime.Value, ExplosionMode.Value);
			projectile.Rigidbody.drag = ProjectileAirResistence.Value / 100f * 3f;
		}

		public override List<WeaponAttribute> GetAttributes()
		{
			return new List<WeaponAttribute> { CollisionMode, ProjectileLifetime, ProjectileAirResistence, ExplosionMode };
		}
	}
}
