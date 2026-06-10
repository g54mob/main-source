using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class SiegeWeaponProjectileBlueprint : NSEipix.Base.Model
	{
		private Resource resourceBlueprint;

		[SerializeField]
		private string id;

		[SerializeField]
		private string prefabId;

		[SerializeField]
		private string hitParticle;

		[SerializeField]
		private string impactAudioEvent;

		[SerializeField]
		private bool spawnPileOnImpact;

		[SerializeField]
		private float projectileDamageOnImpact;

		[SerializeField]
		private int projectileAmount;

		[SerializeField]
		private float groundDamage;

		[SerializeField]
		private float buildingDamage;

		[SerializeField]
		private float pileDamage;

		[SerializeField]
		private float creatureDamage;

		[SerializeField]
		private float projectileHitRadius;

		[SerializeField]
		private float damageFalloff;

		[SerializeField]
		private float powerLossAfterHit = 0.25f;

		[SerializeField]
		private bool spawnsFire;

		[SerializeField]
		private float fireIntensity;

		[SerializeField]
		private bool spawnsOil;

		[SerializeField]
		private byte fireType;

		[SerializeField]
		private bool hasWetnessOnImpact;

		[SerializeField]
		private float wetnessOnImpact;

		[SerializeField]
		private int wallHitHorizontalRange;

		[SerializeField]
		private int wallHitGroundHorizontalRange;

		[SerializeField]
		private float groundHitMinRaycastLength;

		[SerializeField]
		private float groundHitMaxRaycastLength;

		[SerializeField]
		private float groundHitSpreadAngle;

		[SerializeField]
		private OilBlobType oilType;

		[SerializeField]
		private string[] hitEffectorGroupIDs;

		[SerializeField]
		private string[] criticalHitEffectorGroupIDs;

		[SerializeField]
		private string[] hitModifierEffectorIDs;

		[NonSerialized]
		private HitEffector[] onHitEffectors;

		[NonSerialized]
		private HitEffector[] onCriticalHitEffectors;

		public string PrefabId => prefabId;

		public string HitParticle => hitParticle;

		public bool SpawnPileOnImpact => spawnPileOnImpact;

		public float ProjectileDamageOnImpact => projectileDamageOnImpact;

		public int ProjectileAmount => projectileAmount;

		public float PowerLossAfterHit => powerLossAfterHit;

		public float GroundDamage => groundDamage;

		public float BuildingDamage => buildingDamage;

		public float CreatureDamage => creatureDamage;

		public float PileDamage => pileDamage;

		public float ProjectileHitRadius => projectileHitRadius;

		public float DamageFalloff => damageFalloff;

		public bool SpawnsFire => spawnsFire;

		public float FireIntensity => fireIntensity;

		public bool SpawnsOil => spawnsOil;

		public byte FireType => fireType;

		public bool HasWetnessOnImpact => hasWetnessOnImpact;

		public int WallHitHorizontalRange => wallHitHorizontalRange;

		public int WallHitGroundHorizontalRange => wallHitGroundHorizontalRange;

		public float GroundHitMinRaycastLength => groundHitMinRaycastLength;

		public float GroundHitMaxRaycastLength => groundHitMaxRaycastLength;

		public float GroundHitSpreadAngle => groundHitSpreadAngle;

		public float WetnessOnImpact => wetnessOnImpact;

		public OilBlobType OilType => oilType;

		public string[] HitModifierEffectorIDs => hitModifierEffectorIDs;

		public HitEffector[] OnHitEffectors
		{
			get
			{
				if (onHitEffectors == null)
				{
					List<HitEffector> list = new List<HitEffector>();
					string[] array = hitEffectorGroupIDs;
					foreach (string text in array)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(text).HitEffectors);
					}
					onHitEffectors = list.ToArray();
				}
				return onHitEffectors;
			}
		}

		public HitEffector[] OnCriticalHitEffectors
		{
			get
			{
				if (onCriticalHitEffectors == null)
				{
					List<HitEffector> list = new List<HitEffector>();
					string[] array = criticalHitEffectorGroupIDs;
					foreach (string text in array)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(text).HitEffectors);
					}
					onCriticalHitEffectors = list.ToArray();
				}
				return onCriticalHitEffectors;
			}
		}

		public string ImpactAudioEvent => impactAudioEvent;

		public Resource ResourceBlueprint()
		{
			if (resourceBlueprint == null)
			{
				resourceBlueprint = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			}
			return resourceBlueprint;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
