using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class DoorComponentBlueprint : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private BuildingType componentType;

		[SerializeField]
		private SerializableIntStringDictionary thermalModels = SerializableDictionary<int, string>.CreateNew<SerializableIntStringDictionary>();

		[SerializeField]
		private bool canChangeDirection;

		[SerializeField]
		private string thermalModelID;

		[NonSerialized]
		private ThermalModel thermalModel;

		[SerializeField]
		private ushort pathfindingPenaltyAlwaysOpen;

		[SerializeField]
		private float walkSpeedMultiplierAlwaysOpen;

		[SerializeField]
		private float coverOpen;

		[SerializeField]
		private DoorType doorType;

		[SerializeField]
		private float openingSpeedMultiplier;

		[SerializeField]
		private float closingSpeedMultiplier;

		[SerializeField]
		private List<LockStateData> lockStates;

		[SerializeField]
		private bool countsAsDoorInRaid;

		[SerializeField]
		private bool dealDamageWhenClosing;

		[SerializeField]
		private bool drawBridge;

		[SerializeField]
		private float enemyDamage;

		[SerializeField]
		private float workerDamage;

		[SerializeField]
		private float animalDamage;

		[SerializeField]
		private float pileDamage;

		[SerializeField]
		private float floraDamage;

		[SerializeField]
		private float ignoresArmor;

		[SerializeField]
		private float armorDamage;

		[SerializeField]
		private float chanceToHurt;

		[SerializeField]
		private float criticalChance;

		[SerializeField]
		private BoxColliderSettings boxColliderSettings;

		[SerializeField]
		private List<string> criticalHitEffectorGroupIDs;

		[SerializeField]
		private List<string> hitEffectorGroupIDs;

		[SerializeField]
		private string openAudioEventId;

		[SerializeField]
		private string closeAudioEventId;

		[NonSerialized]
		private HitEffector[] onHitEffectors;

		[NonSerialized]
		private HitEffector[] onCriticalHitEffectors;

		public BuildingType ComponentType => componentType;

		public List<LockStateData> LockStates => lockStates;

		public ushort PathfindingPenaltyAlwaysOpen => pathfindingPenaltyAlwaysOpen;

		public float WalkSpeedMultiplierAlwaysOpen => walkSpeedMultiplierAlwaysOpen;

		public float CoverOpen => coverOpen;

		public DoorType DoorType => doorType;

		public float OpeningSpeedMultiplier => openingSpeedMultiplier;

		public float ClosingSpeedMultiplier => closingSpeedMultiplier;

		public bool CanChangeDirection => canChangeDirection;

		public BoxColliderSettings BoxColliderSettings => boxColliderSettings;

		public float EnemyDamage => enemyDamage;

		public float WorkerDamage => workerDamage;

		public float AnimalDamage => animalDamage;

		public float PileDamage => pileDamage;

		public float FloraDamage => floraDamage;

		public float IgnoresArmor => ignoresArmor;

		public float ArmorDamage => armorDamage;

		public float ChanceToHurt => chanceToHurt;

		public float CriticalChance => criticalChance;

		public LockState DefaultLockState
		{
			get
			{
				if (lockStates == null || lockStates.Count == 0)
				{
					return LockState.Locked;
				}
				return lockStates.First((LockStateData x) => x.DefaultLockState).LockState;
			}
		}

		public ThermalModel ThermalModel
		{
			get
			{
				if (thermalModelID == null)
				{
					return null;
				}
				if (thermalModel == null)
				{
					thermalModel = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(thermalModelID);
				}
				return thermalModel;
			}
		}

		public bool CountsAsDoorInRaid => countsAsDoorInRaid;

		public bool DealDamageWhenClosing => dealDamageWhenClosing;

		public bool DrawBridge => drawBridge;

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

		public string OpenAudioEventId => openAudioEventId;

		public string CloseAudioEventId => closeAudioEventId;

		public override string GetID()
		{
			return id;
		}
	}
}
