using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModIO.Util
{
	internal class PrefabPool : SelfInstancingMonoSingleton<PrefabPool>
	{
		public Dictionary<string, List<MonoBehaviour>> pool = new Dictionary<string, List<MonoBehaviour>>();

		public List<GameObject> pooledItems = new List<GameObject>();

		public T Load<T>(string name) where T : MonoBehaviour
		{
			GameObject gameObject = pooledItems.FirstOrDefault((GameObject x) => x.name == name);
			if (gameObject == null)
			{
				Debug.LogWarning("Unable to find " + name);
				return null;
			}
			GameObject obj = UnityEngine.Object.Instantiate(gameObject);
			obj.name = name;
			return obj.GetComponent<T>();
		}

		public T Get<T>(string name) where T : MonoBehaviour
		{
			if (pool.TryGetValue(name, out var value))
			{
				if (value.Count > 0)
				{
					T obj = value.First() as T;
					value.RemoveAt(0);
					obj.gameObject.SetActive(value: true);
					return obj;
				}
			}
			else
			{
				pool.Add(name, new List<MonoBehaviour>());
			}
			return Load<T>(name);
		}

		public void Return<T>(string name, T item) where T : MonoBehaviour
		{
			item.transform.SetParent(null);
			item.gameObject.SetActive(value: false);
			try
			{
				pool[name].Add(item);
			}
			catch (Exception arg)
			{
				Debug.Log($"Error return item {name} exception {arg}");
			}
		}
	}
}
