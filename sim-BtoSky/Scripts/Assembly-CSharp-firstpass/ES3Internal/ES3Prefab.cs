using System;
using System.Collections.Generic;
using UnityEngine;

namespace ES3Internal
{
	public class ES3Prefab : MonoBehaviour
	{
		public long prefabId = GetNewRefID();

		public ES3RefIdDictionary localRefs = new ES3RefIdDictionary();

		public static event Action<GameObject> OnPrefabInstantiated;

		public void Awake()
		{
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			if (current == null)
			{
				return;
			}
			foreach (KeyValuePair<UnityEngine.Object, long> localRef in localRefs)
			{
				if (localRef.Key != null)
				{
					current.Add(localRef.Key);
				}
			}
			ES3Prefab.OnPrefabInstantiated?.Invoke(base.gameObject);
		}

		public long Get(UnityEngine.Object obj)
		{
			if (localRefs.TryGetValue(obj, out var value))
			{
				return value;
			}
			return -1L;
		}

		public long Add(UnityEngine.Object obj)
		{
			if (localRefs.TryGetValue(obj, out var value))
			{
				return value;
			}
			if (!ES3ReferenceMgrBase.CanBeSaved(obj))
			{
				return -1L;
			}
			value = GetNewRefID();
			localRefs.Add(obj, value);
			return value;
		}

		public Dictionary<string, string> GetReferences()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			if (current == null)
			{
				return dictionary;
			}
			foreach (KeyValuePair<UnityEngine.Object, long> localRef in localRefs)
			{
				long num = current.Add(localRef.Key);
				dictionary[localRef.Value.ToString()] = num.ToString();
			}
			return dictionary;
		}

		public void ApplyReferences(Dictionary<long, long> localToGlobal)
		{
			if (ES3ReferenceMgrBase.Current == null)
			{
				return;
			}
			foreach (KeyValuePair<UnityEngine.Object, long> localRef in localRefs)
			{
				if (localToGlobal.TryGetValue(localRef.Value, out var value))
				{
					ES3ReferenceMgrBase.Current.Add(localRef.Key, value);
				}
			}
		}

		public static long GetNewRefID()
		{
			return ES3ReferenceMgrBase.GetNewRefID();
		}
	}
}
