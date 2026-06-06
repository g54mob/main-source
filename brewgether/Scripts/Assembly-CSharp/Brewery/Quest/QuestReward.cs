using System;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Quest
{
	[Serializable]
	public class QuestReward
	{
		[Header("Currency")]
		[Tooltip("Amount of money to give on completion")]
		public int moneyReward;

		[Header("Experience (Future)")]
		[Tooltip("Experience points if/when XP system is added")]
		public int experienceReward;

		[Header("Items (Future)")]
		[Tooltip("Item IDs to give - implementation pending")]
		public string[] itemRewardIds;

		[Header("Prefab Reward")]
		[Tooltip("Prefab to spawn as a reward (e.g., moped, vehicle)")]
		public GameObject rewardPrefab;

		[Tooltip("Icon to display in UI for this reward (e.g., Moped icon)")]
		public Sprite rewardIcon;

		[Tooltip("Display name for the reward shown in UI. If empty, uses prefab name or 'Special Reward'.")]
		public string rewardDisplayName;

		[Tooltip("Name of a QuestSpawnPoint in the scene to spawn at. Takes priority over NPC spawning.")]
		public string spawnPointName;

		[Tooltip("NPC ID to spawn the prefab near. Used if spawnPointName is empty.")]
		public string spawnNearNpcId;

		[Tooltip("Offset from the spawn location (used for NPC/player spawning, ignored for spawn points)")]
		public Vector3 spawnOffset;

		[Header("Grid Spawning")]
		[Tooltip("Spawn multiple instances of rewardPrefab in a grid pattern")]
		public bool spawnAsGrid;

		[Tooltip("Number of items to spawn in the grid (only used if spawnAsGrid is true)")]
		public int gridSpawnCount;

		[Tooltip("Spacing between grid items in meters")]
		public float gridSpacing;

		[Tooltip("Number of items per row in the grid")]
		public int gridRowSize;

		[Header("Vehicle ID (For Mopeds/Vehicles)")]
		[Tooltip("Unique ID for spawned vehicles. Required for save/load persistence. If empty, uses prefab name + spawn point.")]
		public string uniqueSpawnedVehicleId;

		public bool HasReward => false;

		public string GetDisplayName()
		{
			return null;
		}

		public void ApplyReward(ulong clientId)
		{
		}

		private void SpawnPrefabReward(NetworkObject playerObj)
		{
		}

		private void SpawnSingleItem(Vector3 position, Quaternion rotation, bool useGroundRaycast)
		{
		}

		private void AssignVehicleUniqueId(GameObject instance)
		{
		}

		private void RegisterWithVehicleRegistry(string uniqueId)
		{
		}

		private string GetStableVehicleId()
		{
			return null;
		}

		private void SpawnGridItems(Vector3 origin, Quaternion rotation, bool useGroundRaycast)
		{
		}

		private static GameObject FindNpcById(string npcId)
		{
			return null;
		}

		private static GameObject FindSpawnPointByName(string pointName)
		{
			return null;
		}

		private Vector3 GetFallbackSpawnPosition(NetworkObject playerObj, out Quaternion rotation)
		{
			rotation = default(Quaternion);
			return default(Vector3);
		}

		public void ApplyRewardToAllPlayers()
		{
		}
	}
}
