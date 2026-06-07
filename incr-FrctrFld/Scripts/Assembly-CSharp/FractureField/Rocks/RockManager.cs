using System.Collections.Generic;
using FractureField.Quarry;
using FractureField.Upgrades;
using Reactivity;
using UnityEngine;

namespace FractureField.Rocks
{
	public class RockManager : RockManagerSaveData, ISaveData<RockManager, RockManagerSaveData>
	{
		public const RockLayerType MinLayerType = RockLayerType.Stone;

		public const RockLayerType MaxLayerType = RockLayerType.Chronite;

		public const RockLayerType MinHardnessLayerType = RockLayerType.Sandstone;

		private const float SlotJitterAmount = 0.2f;

		public const int BaseMaxRockLayerCapacity = 1;

		public const float BaseLayerTransitionChance = 0.2f;

		public const float BaseRockSpawnDelay = 1.5f;

		private CFloat _rockSpawnDelay;

		public const int BaseMaxRockCapacity = 10;

		private CInt _totalRockCapacity;

		private int _lastKnownCapacity;

		private readonly List<Rock> _activeRocksCache;

		private readonly Dictionary<long, DisposableAction> _rockLayerSubscriptions;

		public Dictionary<RockLayerType, UpgradeManager> LayerUpgradeManagers { get; private set; }

		public RockLayerType HighestUnlockedLayer => default(RockLayerType);

		public List<Rock> Rocks { get; private set; }

		public Ref<Rock> OnRockAdded { get; }

		public Ref<Rock> OnRockRemoved { get; }

		public QuarryBounds QuarryBounds { get; set; }

		private List<Vector2> AvailableSlots { get; }

		private Dictionary<long, Vector2> OccupiedSlots { get; }

		public CFloat RockSpawnDelay => null;

		public CInt TotalRockCapacity => null;

		public RInt CurrentRockCount { get; }

		public RDictionary<RockLayerType, RInt> CurrentLayerCounts { get; }

		public int NonCapacityRockCount { get; private set; }

		private List<Vector2> PendingSpawnPositions { get; }

		public RockManager Load()
		{
			return null;
		}

		public RockManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		public void FixedTick()
		{
		}

		public void EndFrame_FixedTick()
		{
		}

		private void SetupUnlockedLayers(bool clear)
		{
		}

		private void InitializeLayerUpgrades()
		{
		}

		private void SetupRockTracking(Rock rock)
		{
		}

		private void CleanupRockTracking(Rock rock)
		{
		}

		private void InitializeLoadedRocks()
		{
		}

		public List<Rock> GetActiveRocks()
		{
			return null;
		}

		private void UpdateRockSpawning()
		{
		}

		private void CheckSuddenAppearance()
		{
		}

		private void CheckGeodeClusters(Vector2 originalPosition, RockLayerType originalLayer)
		{
		}

		private RockLayerType SelectSpawnLayer(bool ignoreCapacity = false)
		{
			return default(RockLayerType);
		}

		private void SpawnRock()
		{
		}

		private (Vector2, Vector2)? FindValidSpawnPosition()
		{
			return null;
		}

		private void RegenerateSpawnSlots()
		{
		}

		private List<Vector2> GeneratePositionPool(int count, float minDistance)
		{
			return null;
		}

		public RockLayerData GetLayerData(RockLayerType layerType)
		{
			return null;
		}

		public bool IsLayerUnlocked(RockLayerType layerType)
		{
			return false;
		}

		public void UnlockLayer(RockLayerType layerType)
		{
		}

		public float GetLayerYieldMultiplier(RockLayerType layerType)
		{
			return 0f;
		}

		public float GetLayerDamageMultiplier(RockLayerType layerType)
		{
			return 0f;
		}

		public float GetLayerHardnessMultiplier(RockLayerType layerType)
		{
			return 0f;
		}

		public int GetLayerMaxCapacity(RockLayerType layerType)
		{
			return 0;
		}

		public float GetLayerPiercePercent(RockLayerType layerType)
		{
			return 0f;
		}

		public float GetLayerTransitionChance(RockLayerType layerType)
		{
			return 0f;
		}

		public bool CanSpawnLayerType(RockLayerType layerType)
		{
			return false;
		}

		public int GetLayerCount(RockLayerType layerType)
		{
			return 0;
		}

		public void AddRock(Rock rock, Vector2? slotPosition = null)
		{
		}

		public void RemoveRock(Rock rock)
		{
		}

		private void RemoveAllRocks()
		{
		}

		public Rock GetRockById(long id)
		{
			return null;
		}

		public UpgradeManager GetLayerUpgradeManager(RockLayerType layerType)
		{
			return null;
		}

		public Upgrade GetLayerUpgradeById(RockLayerType layerType, string upgradeId)
		{
			return null;
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
