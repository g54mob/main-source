using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	[ExecuteInEditMode]
	public class SceneIdentifiableDatabase : MonoBehaviour, ISerializationCallbackReceiver
	{
		[Serializable]
		private struct Entry
		{
			public MonoBehaviour behaviour;

			public string guid;
		}

		[SerializeField]
		[HideInInspector]
		private List<Entry> _entries = new List<Entry>();

		private Dictionary<MonoBehaviour, string> _behaviourToGuid = new Dictionary<MonoBehaviour, string>();

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			for (int i = 0; i < _entries.Count; i++)
			{
				Entry entry = _entries[i];
				if (entry.behaviour != null)
				{
					_behaviourToGuid[entry.behaviour] = entry.guid;
				}
			}
		}

		internal string GetGuidForIdentifiable(MonoBehaviour behaviour)
		{
			if (!_behaviourToGuid.TryGetValue(behaviour, out var value))
			{
				value = Guid.NewGuid().ToString();
				_behaviourToGuid[behaviour] = value;
			}
			return value;
		}
	}
}
