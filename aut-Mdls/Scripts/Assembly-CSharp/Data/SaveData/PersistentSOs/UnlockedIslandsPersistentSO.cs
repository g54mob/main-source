#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Events.Islands;
using UnityEngine;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Unlocked Islands", fileName = "UnlockedIslandsPersistentSO", order = 0)]
	public class UnlockedIslandsPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		private readonly HashSet<Vector3Int> _unlockedIslands = new HashSet<Vector3Int>();

		private readonly HashSet<Vector3Int> _avaliableIslands = new HashSet<Vector3Int>();

		public static int MAX_DEMO_UNLOCKABLE_ISLAND_COUNT = 3;

		public int UnlockedIslandCount => _unlockedIslands.Count;

		public override AbstractSaveData GetSaveData()
		{
			return new UnlockedIslandsSaveData(new List<Vector3Int>(_unlockedIslands), new List<Vector3Int>(_avaliableIslands));
		}

		public override void ResetToDefaults()
		{
			_unlockedIslands.Clear();
			_avaliableIslands.Clear();
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<UnlockedIslandsSaveData>(fullPath);
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			UnlockedIslandsSaveData unlockedIslandsSaveData = saveData as UnlockedIslandsSaveData;
			foreach (Vector3Int unlockedIsland in unlockedIslandsSaveData.UnlockedIslands)
			{
				_unlockedIslands.Add(unlockedIsland);
			}
			foreach (Vector3Int avaliableIsland in unlockedIslandsSaveData.AvaliableIslands)
			{
				_avaliableIslands.Add(avaliableIsland);
			}
		}

		public bool IsIslandAvaliable(IslandObject islandObject)
		{
			return _avaliableIslands.Contains(islandObject.Position);
		}

		public bool IsIslandUnlocked(IslandObject islandObject)
		{
			if (islandObject == null)
			{
				return false;
			}
			if (_zenModeSO.Value)
			{
				return true;
			}
			return _unlockedIslands.Contains(islandObject.Position);
		}

		public void UnlockIsland(IslandObject islandObject)
		{
			if (UnlockedIslandCount < MAX_DEMO_UNLOCKABLE_ISLAND_COUNT)
			{
				Vector3Int position = islandObject.Position;
				if (_unlockedIslands.Contains(position))
				{
					this.LogWarning($"Island already unlocked {position} ({islandObject.IslandConfig.IslandData.Name})", "UnlockIsland", 84);
					return;
				}
				_unlockedIslands.Add(position);
				SetAdjacentIslandsAvaliable(islandObject);
				_unlockedIslandEvent.Fire(islandObject);
			}
		}

		private void SetAdjacentIslandsAvaliable(IslandObject islandObject)
		{
			int num = int.MaxValue;
			int num2 = int.MaxValue;
			int num3 = int.MinValue;
			int num4 = int.MinValue;
			foreach (Vector3Int position in islandObject.Positions)
			{
				num = Mathf.Min(num, position.x);
				num2 = Mathf.Min(num2, position.z);
				num3 = Mathf.Max(num3, position.x);
				num4 = Mathf.Max(num4, position.z);
			}
			Vector3Int gridPosition = new Vector3Int(0, 0, 0);
			for (int i = num; i <= num3; i++)
			{
				gridPosition.x = i;
				gridPosition.z = num2 - 1;
				if (_islandLayer.TryGetIslandAtGridPosition(gridPosition, out islandObject))
				{
					_avaliableIslands.Add(islandObject.Position);
				}
				gridPosition.z = num4 + 1;
				if (_islandLayer.TryGetIslandAtGridPosition(gridPosition, out islandObject))
				{
					_avaliableIslands.Add(islandObject.Position);
				}
			}
			for (int j = num2; j <= num4; j++)
			{
				gridPosition.z = j;
				gridPosition.x = num - 1;
				if (_islandLayer.TryGetIslandAtGridPosition(gridPosition, out islandObject))
				{
					_avaliableIslands.Add(islandObject.Position);
				}
				gridPosition.x = num3 + 1;
				if (_islandLayer.TryGetIslandAtGridPosition(gridPosition, out islandObject))
				{
					_avaliableIslands.Add(islandObject.Position);
				}
			}
		}

		public void UnlockAll()
		{
			foreach (IslandObject allIsland in _islandLayer.GetAllIslands())
			{
				UnlockIsland(allIsland);
			}
		}
	}
}
