using System.Collections.Generic;
using Assets.Scripts.Flight.StartLocations;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class CraftOwnerSpawnData
	{
		private static Stack<byte> _availableIds = new Stack<byte>();

		private static byte _nextId;

		private static Dictionary<byte, CraftOwnerSpawnData> _spawnData = new Dictionary<byte, CraftOwnerSpawnData>();

		public StartLocationData StartLocation { get; }

		public bool StartPaused { get; }

		public CraftOwnerSpawnData(StartLocationData startLocation, bool startPaused)
		{
			StartLocation = startLocation;
			StartPaused = startPaused;
		}

		public static byte CreateAndStore(StartLocationData startLocation, bool startPaused)
		{
			CraftOwnerSpawnData value = new CraftOwnerSpawnData(startLocation, startPaused);
			byte b = ((_availableIds.Count > 0) ? _availableIds.Pop() : _nextId++);
			if (_spawnData.ContainsKey(b))
			{
				Debug.LogError($"Craft owner spawn data with id '{b}' already existed. Its possible there is a memory leak. The id will be reused.");
			}
			_spawnData[b] = value;
			return b;
		}

		public static void Reinitialize()
		{
			_availableIds.Clear();
			_spawnData.Clear();
			_nextId = 0;
		}

		public static CraftOwnerSpawnData Retrieve(byte id)
		{
			if (!_spawnData.TryGetValue(id, out var value))
			{
				Debug.LogError($"Craft owner spawn data with id '{id}' could not be found.");
				return null;
			}
			_spawnData.Remove(id);
			return value;
		}
	}
}
