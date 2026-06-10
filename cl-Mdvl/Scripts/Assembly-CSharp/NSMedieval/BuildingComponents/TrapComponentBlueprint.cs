using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class TrapComponentBlueprint : NSEipix.Base.Model
	{
		private BuildingType componentType = BuildingType.Trap;

		[SerializeField]
		private string id;

		[SerializeField]
		private float setupTime;

		[SerializeField]
		private float chanceToHurt;

		[SerializeField]
		private float affectsWorker;

		[SerializeField]
		private float affectsEnemy;

		[SerializeField]
		private float affectsAnimal;

		[SerializeField]
		private float affectsDomesticAnimal;

		[SerializeField]
		private float damage;

		[SerializeField]
		private float ignoresArmor;

		[SerializeField]
		private float armorDamage;

		[SerializeField]
		private float criticalChance;

		[SerializeField]
		private List<string> hitEffectorGroupIDs;

		[SerializeField]
		private List<string> criticalHitEffectorGroupIDs;

		[SerializeField]
		private List<string> successfulHitEffectorGroupIDs;

		[SerializeField]
		private string decomposeModifiersId;

		[SerializeField]
		private float weight;

		[SerializeField]
		private ushort pathfindingPenaltyActive;

		[SerializeField]
		private float walkSpeedMultiplierActive;

		[SerializeField]
		private float spawnOilRadius;

		[SerializeField]
		private float spawnFire;

		[SerializeField]
		private float spawnFireRadius;

		[SerializeField]
		private float triggerOnFire;

		[SerializeField]
		private byte oilType;

		[SerializeField]
		private byte fireType;

		[SerializeField]
		private float chanceToDestroyAfterTriggering;

		[NonSerialized]
		private HitEffector[] onHitEffectors;

		[NonSerialized]
		private HitEffector[] onCriticalHitEffectors;

		[NonSerialized]
		private HitEffector[] onSuccessfulHitEffector;

		public float SetupTime => setupTime;

		public float ChanceToHurt => chanceToHurt;

		public float AffectsAnimal => affectsAnimal;

		public float AffectsWorker => affectsWorker;

		public float AffectsEnemy => affectsEnemy;

		public float AffectsDomesticAnimal => affectsDomesticAnimal;

		public float Damage => damage;

		public float IgnoresArmor => ignoresArmor;

		public float ArmorDamage => armorDamage;

		public float CriticalChance => criticalChance;

		public BuildingType ComponentType => componentType;

		public ushort PathfindingPenaltyActive => pathfindingPenaltyActive;

		public float WalkSpeedMultiplierActive => walkSpeedMultiplierActive;

		public HitEffector[] OnHitEffectors
		{
			get
			{
				if (onHitEffectors == null)
				{
					List<HitEffector> list = new List<HitEffector>();
					foreach (string hitEffectorGroupID in hitEffectorGroupIDs)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(hitEffectorGroupID).HitEffectors);
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
					foreach (string criticalHitEffectorGroupID in criticalHitEffectorGroupIDs)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(criticalHitEffectorGroupID).HitEffectors);
					}
					onCriticalHitEffectors = list.ToArray();
				}
				return onCriticalHitEffectors;
			}
		}

		public HitEffector[] OnSuccessfulHitEffector
		{
			get
			{
				if (onSuccessfulHitEffector == null)
				{
					List<HitEffector> list = new List<HitEffector>();
					foreach (string successfulHitEffectorGroupID in successfulHitEffectorGroupIDs)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(successfulHitEffectorGroupID).HitEffectors);
					}
					onSuccessfulHitEffector = list.ToArray();
				}
				return onSuccessfulHitEffector;
			}
		}

		public float Weight => weight;

		public string DecomposeModifiersId => decomposeModifiersId;

		public float SpawnOilRadius => spawnOilRadius;

		public float SpawnFire => spawnFire;

		public float SpawnFireRadius => spawnFireRadius;

		public float TriggerOnFire => triggerOnFire;

		public byte OilType => oilType;

		public byte FireType => fireType;

		public float ChanceToDestroyAfterTriggering => chanceToDestroyAfterTriggering;

		public override string GetID()
		{
			return id;
		}
	}
}
