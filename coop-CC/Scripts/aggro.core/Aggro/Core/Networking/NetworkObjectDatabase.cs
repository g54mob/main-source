using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Aggro.Core.Networking
{
	public class NetworkObjectDatabase : ScriptableObject, ISerializationCallbackReceiver
	{
		[Serializable]
		public struct Entry
		{
			public UnityEngine.Object obj;

			public uint assetId;
		}

		public int version;

		public List<Entry> scrobs = new List<Entry>();

		public List<Entry> prefabs = new List<Entry>();

		public List<GameObject> spawnablePrefabs = new List<GameObject>();

		private HashSet<GameObject> _spawnablesSet = new HashSet<GameObject>();

		private Dictionary<uint, NetworkScriptableObject> _idToScrobs = new Dictionary<uint, NetworkScriptableObject>();

		private Dictionary<uint, GameObject> _idToPrefabs = new Dictionary<uint, GameObject>();

		private static NetworkObjectDatabase _instance;

		private const string RESOURCES_PATH = "_GENERATED_/db-networkobjects";

		private const int VERSION = 2;

		public static void InitializeNetwork()
		{
			foreach (GameObject item in _instance._spawnablesSet)
			{
				if (item != null && item.TryGetComponent<NetworkIdentity>(out var component) && component.assetId != 0 && item != NetworkManager.singleton.playerPrefab && !NetworkClient.GetPrefab(component.assetId, out var _))
				{
					NetworkClient.RegisterPrefab(item);
				}
			}
		}

		public static bool TryGetNetworkScrob<T>(uint id, out T scrob) where T : NetworkScriptableObject
		{
			if (id != 0 && _instance._idToScrobs.TryGetValue(id, out var value))
			{
				scrob = value as T;
				return (object)scrob != null;
			}
			scrob = null;
			return false;
		}

		public static bool TryGetNetworkPrefab(uint id, out GameObject prefab)
		{
			if (id != 0 && _instance._idToPrefabs.TryGetValue(id, out prefab))
			{
				return true;
			}
			prefab = null;
			return false;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void RuntimeInit()
		{
			_instance = Resources.Load<NetworkObjectDatabase>("_GENERATED_/db-networkobjects");
		}

		public void OnBeforeSerialize()
		{
			scrobs.Clear();
			prefabs.Clear();
			foreach (KeyValuePair<uint, NetworkScriptableObject> idToScrob in _idToScrobs)
			{
				if (idToScrob.Value != null)
				{
					Entry item = new Entry
					{
						assetId = idToScrob.Key,
						obj = idToScrob.Value
					};
					scrobs.Add(item);
				}
			}
			foreach (KeyValuePair<uint, GameObject> idToPrefab in _idToPrefabs)
			{
				if (idToPrefab.Value != null)
				{
					Entry item2 = new Entry
					{
						assetId = idToPrefab.Key,
						obj = idToPrefab.Value
					};
					prefabs.Add(item2);
				}
			}
			spawnablePrefabs.Clear();
			foreach (GameObject item3 in _spawnablesSet)
			{
				if (item3 != null)
				{
					spawnablePrefabs.Add(item3);
				}
			}
		}

		public void OnAfterDeserialize()
		{
			_idToScrobs.Clear();
			_idToPrefabs.Clear();
			for (int i = 0; i < scrobs.Count; i++)
			{
				Entry entry = scrobs[i];
				if (entry.obj is NetworkScriptableObject value)
				{
					_idToScrobs[entry.assetId] = value;
				}
			}
			for (int j = 0; j < prefabs.Count; j++)
			{
				Entry entry2 = prefabs[j];
				if (entry2.obj is GameObject value2)
				{
					_idToPrefabs[entry2.assetId] = value2;
				}
			}
			_spawnablesSet.Clear();
			for (int k = 0; k < spawnablePrefabs.Count; k++)
			{
				GameObject gameObject = spawnablePrefabs[k];
				if (gameObject != null)
				{
					_spawnablesSet.Add(gameObject);
				}
			}
		}
	}
}
