using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Particles;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters
{
	public class ParticleWeaponEmitter : Emitter
	{
		public Transform ShootTransform;

		public FloatWeaponAttribute EmissionAngle = new FloatWeaponAttribute();

		public FloatWeaponAttribute ParticleSpeed = new FloatWeaponAttribute();

		public FloatWeaponAttribute ParticleAmount = new FloatWeaponAttribute();

		public ParticleGenerator ParticleGenerator;

		private ParticleGenerator _instantiatedParticleGenerator;

		public override void InitAttributes()
		{
			base.InitAttributes();
			EmissionAngle.Init(EWeaponAttributeType.ParticleEmissionAngle, 1, 0f, 120f, !UsedByEnemy);
			ParticleSpeed.Init(EWeaponAttributeType.ParticleSpeed, 2, 0f, 200f, !UsedByEnemy);
			ParticleAmount.Init(EWeaponAttributeType.ParticleAmount, 0, 0f, 100f, !UsedByEnemy, true);
			foreach (Transform item in ShootTransform)
			{
				Object.Destroy(item.gameObject);
			}
			_instantiatedParticleGenerator = Object.Instantiate(ParticleGenerator, ShootTransform);
			_instantiatedParticleGenerator.Init(this);
			_instantiatedParticleGenerator.InitAttributes();
		}

		public override void Init()
		{
		}

		protected override void DoEmit(bool emissionActive, bool readyToShoot)
		{
			if (emissionActive)
			{
				_instantiatedParticleGenerator.ShootParticles(true);
			}
			else
			{
				_instantiatedParticleGenerator.ShootParticles(false);
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

		protected override List<WeaponAttribute> GetBaseAttributes()
		{
			return new List<WeaponAttribute> { EnergyUsage, Damage, ElementalStrength, DiggingStrength };
		}

		public override List<NimbatusItem> GetModules()
		{
			List<NimbatusItem> list = new List<NimbatusItem>();
			list.Add(_instantiatedParticleGenerator);
			list.AddRange(Upgrades.Cast<NimbatusItem>());
			return list;
		}

		protected override IEnumerable<WeaponAttribute> GetAttributes()
		{
			List<WeaponAttribute> list = new List<WeaponAttribute>();
			list.Add(ParticleAmount);
			list.Add(ParticleSpeed);
			list.Add(EmissionAngle);
			list.AddRange(_instantiatedParticleGenerator.GetAttributes());
			return list;
		}
	}
}
