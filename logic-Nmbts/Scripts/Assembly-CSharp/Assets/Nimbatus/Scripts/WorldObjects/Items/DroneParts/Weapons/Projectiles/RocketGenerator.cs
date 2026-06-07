using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles
{
	public class RocketGenerator : ProjectileGenerator
	{
		public EnumAttribute<ERocketSteeringMode> SteeringMode = new EnumAttribute<ERocketSteeringMode>();

		public FloatWeaponAttribute Force = new FloatWeaponAttribute();

		public Rocket Prefab;

		public override void Init(ProjectileEmitter emitter)
		{
			base.Init(emitter);
			SteeringMode.Init(EWeaponAttributeType.RocketSteeringMode, true);
			Force.Init(EWeaponAttributeType.RocketForce, 0, 0f, 100f, !emitter.UsedByEnemy);
		}

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public override Projectile CreateProjectile()
		{
			return Object.Instantiate(Prefab);
		}

		public override void InitProjectile(Projectile projectile)
		{
			Rocket rocket = projectile as Rocket;
			if (rocket != null)
			{
				rocket.Init(Emitter, Emitter.Ammunition, Emitter.Damage.Value * Emitter.DamageModifier, CollisionMode.Value, ProjectileLifetime.Value, ExplosionMode.Value, SteeringMode.Value, Force.Value);
				rocket.Rigidbody.drag = ProjectileAirResistence.Value / 100f * 3f;
			}
		}

		public override List<WeaponAttribute> GetAttributes()
		{
			return new List<WeaponAttribute> { CollisionMode, ProjectileLifetime, ProjectileAirResistence, ExplosionMode, SteeringMode, Force };
		}
	}
}
