using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.LaserBeams;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters
{
	public class LaserEmitter : Emitter
	{
		public FloatWeaponAttribute NumberOfLasers = new FloatWeaponAttribute();

		public Transform ShootTransform;

		public LaserBeam LaserBeam;

		private LaserBeam _instantiatedLaserBeam;

		public override void InitAttributes()
		{
			base.InitAttributes();
			NumberOfLasers.Init(EWeaponAttributeType.NumberOfLasers, 0, 1f, 10f, !UsedByEnemy);
			foreach (Transform item in ShootTransform)
			{
				Object.Destroy(item.gameObject);
			}
			_instantiatedLaserBeam = Object.Instantiate(LaserBeam, ShootTransform);
			_instantiatedLaserBeam.Init(this);
		}

		protected override List<WeaponAttribute> GetBaseAttributes()
		{
			return new List<WeaponAttribute> { EnergyUsage, Damage, ElementalStrength, DiggingStrength };
		}

		public override void Init()
		{
		}

		protected override void DoEmit(bool emissionActive, bool readyToShoot)
		{
			float num4 = 10f * NumberOfLasers.Value / 2f;
			float value3 = NumberOfLasers.Value;
			float num5 = 2f;
			int num = 0;
			_instantiatedLaserBeam.SetNumberOfBeams((int)NumberOfLasers.Value);
			float value = NumberOfLasers.Value;
			for (int i = 0; (float)i < value; i++)
			{
				float num2 = value * 10f / 2f;
				float angle = Mathf.Lerp(0f - num2, num2, (float)i / (value - 1f));
				if (value <= 1f)
				{
					angle = 0f;
				}
				List<RaycastHit> list = _instantiatedLaserBeam.ShootLaser(emissionActive, ShootTransform.position, Quaternion.AngleAxis(angle, Vector3.forward) * ShootTransform.right, num);
				num++;
				if (!readyToShoot)
				{
					continue;
				}
				float num3 = Damage.Value;
				if (1f / AttackSpeed.Value < Time.fixedDeltaTime)
				{
					num3 = Time.deltaTime * AttackSpeed.Value * num3;
				}
				num3 *= DamageModifier;
				float diggingStrength = DiggingStrength.Value / 50f;
				float value2 = ElementalStrength.Value;
				foreach (RaycastHit item in list)
				{
					Quaternion rotation = Quaternion.FromToRotation(Vector3.up, item.normal);
					switch (_instantiatedLaserBeam.HitMode.Value)
					{
					case ELaserHitMode.Damage:
						Ammunition.TriggerLaserImpact(ParentObject, (!UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, item.collider.gameObject, item.point, rotation, num3, Damage.BaseValue, diggingStrength, value2);
						break;
					case ELaserHitMode.Push:
						Ammunition.TriggerLaserImpact(ParentObject, (!UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, item.collider.gameObject, item.point, rotation, num3 * 0.5f, Damage.BaseValue, diggingStrength, value2);
						if (item.rigidbody != null)
						{
							PushAway(item.rigidbody, -item.normal, 500f + Damage.Value * 50f);
						}
						break;
					case ELaserHitMode.Attract:
						Ammunition.TriggerLaserImpact(ParentObject, (!UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, item.collider.gameObject, item.point, rotation, num3 * 0.5f, Damage.BaseValue, diggingStrength, value2);
						Attract(item.rigidbody, item.normal, 500f + Damage.Value * 50f);
						break;
					}
				}
			}
		}

		protected override bool IsUnobstructed()
		{
			if (RuntimeGlobals.WorldController == null || RuntimeGlobals.WorldController.ForeGroundTerrain == null)
			{
				return true;
			}
			NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(ShootTransform.position);
			if (data.HasValue && data.Value.Volume > 0.5f)
			{
				return false;
			}
			return true;
		}

		private void PushAway(Rigidbody r, Vector3 direction, float strength)
		{
			if (r != null)
			{
				r.AddForce(direction * strength, ForceMode.Force);
			}
		}

		private void Attract(Rigidbody r, Vector3 direction, float strength)
		{
			if (r != null)
			{
				r.AddForce(direction * strength, ForceMode.Force);
			}
		}

		public override List<NimbatusItem> GetModules()
		{
			List<NimbatusItem> list = new List<NimbatusItem>();
			list.Add(_instantiatedLaserBeam);
			list.AddRange(Upgrades);
			return list;
		}

		protected override IEnumerable<WeaponAttribute> GetAttributes()
		{
			List<WeaponAttribute> list = new List<WeaponAttribute>();
			list.Add(NumberOfLasers);
			list.AddRange(_instantiatedLaserBeam.GetAttributes());
			return list;
		}
	}
}
