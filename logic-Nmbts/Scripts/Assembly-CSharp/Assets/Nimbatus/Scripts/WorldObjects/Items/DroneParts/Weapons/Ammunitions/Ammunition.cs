using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions
{
	public class Ammunition : NimbatusItem
	{
		public EAmmunitionType AmmunitionType;

		public float TemperatureChange;

		public float DamageMultiplier;

		public NimbatusParticleEffect LaserImpactEffect;

		public NimbatusParticleEffect ImpactEffect;

		public NimbatusParticleEffect ExplosionEffect;

		public NimbatusParticleEffect BigExplosionEffect;

		public Color ColorModifier;

		public Color IconColorModifier;

		public float Probability = 1f;

		public virtual void TriggerImpact(NimbatusObject damageSourceObject, EDamageReason damagereason, GameObject target, Vector3 position, Quaternion rotation, float damage, float baseDamage, float diggingStrength, float tempMultiplier)
		{
			if (target != null)
			{
				InflictDamage(damageSourceObject, damagereason, target, damage, baseDamage, tempMultiplier);
			}
			if (RuntimeGlobals.WorldController != null && (diggingStrength > 0f || diggingStrength < 0f))
			{
				TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, 3f, diggingStrength, AmmunitionType);
			}
			if (ImpactEffect != null)
			{
				ImpactEffect.PlayEffect(position, rotation);
			}
		}

		public virtual void TriggerLaserImpact(NimbatusObject sourceObject, EDamageReason damagereason, GameObject target, Vector3 position, Quaternion rotation, float damage, float baseDamage, float diggingStrength, float tempMultiplier)
		{
			if (target != null)
			{
				InflictDamage(sourceObject, damagereason, target, damage, baseDamage, tempMultiplier);
			}
			if (RuntimeGlobals.WorldController != null && (diggingStrength > 0f || diggingStrength < 0f))
			{
				TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, 3f, diggingStrength, AmmunitionType);
			}
			if (LaserImpactEffect != null)
			{
				LaserImpactEffect.PlayEffect(position, rotation);
			}
		}

		public virtual void TriggerParticleImpact(NimbatusObject sourceObject, EDamageReason damagereason, GameObject target, Vector3 position, float damage, float baseDamage, float diggingStrength, float tempMultiplier)
		{
			if (target != null)
			{
				InflictDamage(sourceObject, damagereason, target, damage, baseDamage, tempMultiplier);
			}
			if (RuntimeGlobals.WorldController != null && (diggingStrength > 0f || diggingStrength < 0f))
			{
				TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, 3f, (AmmunitionType == EAmmunitionType.Bio) ? (diggingStrength * tempMultiplier) : diggingStrength, AmmunitionType);
			}
		}

		public virtual void TriggerExplosion(NimbatusObject sourceObject, EDamageReason damagereason, Vector3 position, float explosionRadius, float damage, float baseDamage, float diggingStrength, float tempMultiplier, LayerMask collisionMask)
		{
			DoExplosion(sourceObject, damagereason, position, explosionRadius, damage, baseDamage, diggingStrength, tempMultiplier, collisionMask);
			if (ExplosionEffect != null)
			{
				ExplosionEffect.PlayEffect(position, Quaternion.identity);
			}
		}

		public void TriggerBigExplosion(NimbatusObject sourceObject, EDamageReason damagereason, Vector3 position, int explosionRadius, float damage, float baseDamage, float diggingStrength, float tempMultiplier, LayerMask emitterCollisionmask)
		{
			DoExplosion(sourceObject, damagereason, position, explosionRadius, damage, baseDamage, diggingStrength, tempMultiplier, emitterCollisionmask);
			if (BigExplosionEffect != null)
			{
				BigExplosionEffect.PlayEffect(position, Quaternion.identity);
			}
		}

		private void DoExplosion(NimbatusObject sourceObject, EDamageReason damagereason, Vector3 position, float explosionRadius, float damage, float baseDamage, float diggingStrength, float tempMultiplier, LayerMask collisionMask)
		{
			if (RuntimeGlobals.WorldController != null && (diggingStrength > 0f || diggingStrength < 0f))
			{
				TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, (int)explosionRadius, diggingStrength, AmmunitionType);
			}
			if (damage > 0f || TemperatureChange > 0f || TemperatureChange < 0f)
			{
				Collider[] array = Physics.OverlapSphere(position, explosionRadius, collisionMask);
				foreach (Collider collider in array)
				{
					InflictDamage(sourceObject, damagereason, collider.gameObject, damage, baseDamage, tempMultiplier);
				}
			}
			if (ExplosionEffect != null)
			{
				ExplosionEffect.PlayEffect(position, Quaternion.identity);
			}
		}

		private void InflictDamage(NimbatusObject sourceObject, EDamageReason damagereason, GameObject go, float damage, float baseDamage, float tempMultiplier)
		{
			go.SendMessage("TakeDamage", new DamageInformation(damage * DamageMultiplier, damagereason, sourceObject), SendMessageOptions.DontRequireReceiver);
			float num = Mathf.Min(100f, baseDamage + 1f) / 100f;
			go.SendMessage("ChangeTemperatureBy", TemperatureChange * num * tempMultiplier, SendMessageOptions.DontRequireReceiver);
		}

		public override string ToString()
		{
			return Name.GetTranslation();
		}

		public override void InitStackSettings()
		{
			IsStackable = false;
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
