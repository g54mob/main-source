using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class UGCRuntimePrefabManager
	{
		private GameObject _runtimePrefabRoot;

		private Dictionary<UGCRuntimePrefabKey, GameObject> _contentIDToRuntimePrefab;

		public GameObject RuntimePrefabRoot => _runtimePrefabRoot;

		public UGCRuntimePrefabManager()
		{
			_runtimePrefabRoot = new GameObject("UGC Runtime Prefabs");
			_runtimePrefabRoot.SetActive(value: false);
			_contentIDToRuntimePrefab = new Dictionary<UGCRuntimePrefabKey, GameObject>();
		}

		public GameObject GetRuntimePrefab(UGCRuntimePrefabKey key)
		{
			if (_contentIDToRuntimePrefab.TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}

		public void AddOrReplaceRuntimePrefab(UGCRuntimePrefabKey key, GameObject newRuntimePrefab)
		{
			if (_contentIDToRuntimePrefab.TryGetValue(key, out var value))
			{
				Object.Destroy(value);
				_contentIDToRuntimePrefab[key] = newRuntimePrefab;
			}
			else
			{
				_contentIDToRuntimePrefab.Add(key, newRuntimePrefab);
			}
		}
	}
}
