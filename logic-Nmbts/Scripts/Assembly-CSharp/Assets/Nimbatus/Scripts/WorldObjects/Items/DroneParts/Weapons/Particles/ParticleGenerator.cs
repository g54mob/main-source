using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Particles
{
	public class ParticleGenerator : NimbatusItem
	{
		[HideInInspector]
		[SerializeField]
		protected ParticleWeaponEmitter Emitter;

		public FloatWeaponAttribute ParticleLifetime = new FloatWeaponAttribute();

		public EnumAttribute<EParticleImpactMode> ParticleImpactMode = new EnumAttribute<EParticleImpactMode>();

		public EnumAttribute<EParticleGravityMode> ParticleGravityMode = new EnumAttribute<EParticleGravityMode>();

		public ParticleSystem System;

		public bool IgnoreAmmunitionColor;

		public string ShootingSound;

		private float _gravityMod;

		public void InitAttributes()
		{
			ParticleImpactMode.Init(EWeaponAttributeType.ParticleImpactMode);
			ParticleGravityMode.Init(EWeaponAttributeType.ParticleGravity);
			ParticleLifetime.Init(EWeaponAttributeType.ParticleLifetime, 2, 0f, 5f, !Emitter.UsedByEnemy);
		}

		public void Init(ParticleWeaponEmitter emitter)
		{
			Emitter = emitter;
			ShootParticles(false);
		}

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public void OnParticleCollision(GameObject other)
		{
			if (!(Emitter != null))
			{
				return;
			}
			List<ParticleCollisionEvent> list = new List<ParticleCollisionEvent>();
			float num = Mathf.Min((float)System.GetCollisionEvents(other, list) / 10f, 1f);
			float diggingStrength = Emitter.DiggingStrength.Value / 80f;
			float value = Emitter.ElementalStrength.Value;
			for (int i = 0; (float)i < num; i++)
			{
				if (Emitter != null)
				{
					Emitter.Ammunition.TriggerParticleImpact(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, list[i].colliderComponent.gameObject, list[i].intersection, Emitter.Damage.Value * Emitter.DamageModifier * 0.1f, Emitter.Damage.BaseValue, diggingStrength, value);
				}
			}
		}

		public override void Update()
		{
			_gravityMod = WorldController.TerrainSettings.GetGravityModifier();
			ParticleSystem.Particle[] array = new ParticleSystem.Particle[System.particleCount];
			System.GetParticles(array);
			float num = 0f;
			switch (ParticleGravityMode.Value)
			{
			case EParticleGravityMode.None:
				num = 0f;
				break;
			case EParticleGravityMode.NormalGravity:
				num = 2.5f;
				break;
			case EParticleGravityMode.StrongGravity:
				num = 5f;
				break;
			case EParticleGravityMode.AntiGravity:
				num = -5f;
				break;
			}
			ParticleSystem.MainModule main = System.main;
			num *= main.gravityModifierMultiplier;
			main.startSpeed = Emitter.ParticleSpeed.Value;
			main.startLifetime = ParticleLifetime.Value;
			ParticleSystem.EmissionModule emission = System.emission;
			emission.rateOverTime = Emitter.ParticleAmount.Value;
			ParticleSystem.ShapeModule shape = System.shape;
			if (shape.shapeType == ParticleSystemShapeType.Circle)
			{
				shape.arc = Emitter.EmissionAngle.Value;
				shape.rotation = new Vector3(shape.rotation.y, shape.rotation.y, 0f - shape.arc / 2f);
			}
			else if (shape.shapeType == ParticleSystemShapeType.Cone)
			{
				shape.angle = Emitter.EmissionAngle.Value;
			}
			ParticleSystem.CollisionModule collision = System.collision;
			switch (ParticleImpactMode.Value)
			{
			case EParticleImpactMode.Destroy:
				collision.bounce = 0f;
				collision.lifetimeLoss = 0.8f;
				collision.dampen = 0f;
				break;
			case EParticleImpactMode.Bounce:
				collision.bounce = 1f;
				collision.lifetimeLoss = 0f;
				collision.dampen = 0.5f;
				break;
			case EParticleImpactMode.Stick:
				collision.bounce = 0f;
				collision.lifetimeLoss = 0f;
				collision.dampen = 1f;
				break;
			}
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 position = array[i].position;
				if (RuntimeGlobals.WorldController != null && RuntimeGlobals.WorldController.ForeGroundTerrain != null)
				{
					NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(position);
					if (data.HasValue && data.Value.Volume > 0.5f)
					{
						array[i].remainingLifetime = float.Epsilon;
					}
				}
				array[i].velocity += _gravityMod * num * 9.81f * Time.smoothDeltaTime * (Vector3)GetGravityDirection(position).normalized;
			}
			System.SetParticles(array, array.Length);
		}

		public void ShootParticles(bool enable)
		{
			ParticleSystem.EmissionModule emission = System.emission;
			emission.enabled = enable;
			if (enable)
			{
				ParticleSystem.MainModule main = System.main;
				if (!IgnoreAmmunitionColor)
				{
					main.startColor = Emitter.Ammunition.ColorModifier;
				}
				StartSoundLoop(ShootingSound);
			}
			else
			{
				StopActiveSoundLoop();
			}
		}

		public List<WeaponAttribute> GetAttributes()
		{
			return new List<WeaponAttribute> { ParticleLifetime, ParticleImpactMode, ParticleGravityMode };
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
		}

		public override NimbatusItemData CreateData()
		{
			return new NimbatusItemData();
		}
	}
}
