using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Upgrades;
using Reactivity;
using UnityEngine;

namespace FractureField.Drones
{
	public class DroneManager : DroneManagerSaveData, ISaveData<DroneManager, DroneManagerSaveData>
	{
		public const RockLayerType DroneHubUnlockLayer = RockLayerType.Quartz;

		public const int BaseMaxDroneSlotCount = 0;

		public CInt MaxDroneSlotCount;

		private bool _droneRulesDirty;

		private float _timeSinceLastRebalance;

		private const float RebalanceInterval = 1f;

		public List<Drone> Drones { get; private set; }

		public List<Vector2> SentryDronePositions { get; set; }

		private Dictionary<Rock, List<Drone>> DronesPerRock { get; }

		public UpgradeManager UpgradeManager { get; private set; }

		public Ref<Drone> OnDroneSpawned { get; }

		public Ref<Drone> OnDroneDespawned { get; }

		public RInt DroneCount { get; }

		public RInt UsedSlotCount { get; }

		private RDictionary<DroneType, RInt> DroneCountForType { get; }

		public RTrigger OnDroneRuleChanged { get; }

		public DroneManager Load()
		{
			return null;
		}

		public DroneManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		private void InitializeDroneRules()
		{
		}

		private void InitializeUpgradeManager()
		{
		}

		public void FixedTick()
		{
		}

		private void ApplyDroneRules()
		{
		}

		public static int SlotCostForType(DroneType type)
		{
			return 0;
		}

		public static int HardLimitForType(DroneType type)
		{
			return 0;
		}

		private Dictionary<DroneType, int> CalculateIdealComposition()
		{
			return null;
		}

		public int GetMaxAllowedByChassisUpgrade(DroneType type)
		{
			return 0;
		}

		public int GetEffectiveMaxForType(DroneType type)
		{
			return 0;
		}

		public void SpawnDroneOfType(DroneType type)
		{
		}

		public Drone CreateDroneByType(DroneType type)
		{
			return null;
		}

		private void DespawnDrone(Drone drone)
		{
		}

		private void DespawnAllDrones()
		{
		}

		private void UpdateDroneCounts()
		{
		}

		public void EnableDrones()
		{
		}

		public void DisableDrones()
		{
		}

		public Vector2 GetDroneOffset(Drone drone)
		{
			return default(Vector2);
		}

		public int GetDroneCountTargetingRock(Rock rock)
		{
			return 0;
		}

		public void RegisterDroneTarget(Drone drone, Rock newTarget, Rock oldTarget = null)
		{
		}

		public void CleanupDestroyedRock(Rock rock)
		{
		}

		private int GetUsedSlots()
		{
			return 0;
		}

		public RInt GetDroneCountForType(DroneType type)
		{
			return null;
		}

		public void UpdateDroneRule(DroneType type, float targetPercent, int maxQuantity, int priority)
		{
		}

		public DroneRuleSettings GetDroneRule(DroneType type)
		{
			return null;
		}

		public void UpdateDroneTargetSettings(DroneType type, DroneTargetingMode mode, RockLayerType targetLayer)
		{
		}

		public DroneTargetSettings GetDroneTargetSettings(DroneType type)
		{
			return null;
		}

		public RBool GetIsShowingUpgradesForDroneType(DroneType type)
		{
			return null;
		}

		public void UpdateSentryDronePositions(SentryDrone movedSentryDrone)
		{
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
