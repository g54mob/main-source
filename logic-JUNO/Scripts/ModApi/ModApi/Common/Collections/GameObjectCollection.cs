using System;
using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Common.Collections
{
	public class GameObjectCollection
	{
		public class GameObjectMap
		{
			public GameObject GameObject { get; set; }

			public int Layer { get; set; }
		}

		private List<GameObjectMap> _maps = new List<GameObjectMap>();

		public int Count => _maps.Count;

		public bool IsReadOnly => false;

		public void Add(GameObject gameObject)
		{
			if (gameObject != null)
			{
				GameObjectMap gameObjectMap = new GameObjectMap();
				gameObjectMap.GameObject = gameObject;
				gameObjectMap.Layer = gameObject.layer;
				_maps.Add(gameObjectMap);
				return;
			}
			throw new ArgumentNullException();
		}

		public void AddRange<T>(ICollection<T> collection, Func<T, GameObject> convertToGameObject)
		{
			foreach (T item in collection)
			{
				Add(convertToGameObject(item));
			}
		}

		public void Clear()
		{
			_maps.Clear();
		}

		public bool Contains(GameObject item)
		{
			if (item != null)
			{
				foreach (GameObjectMap map in _maps)
				{
					if (map.GameObject.GetInstanceID() == item.GetInstanceID())
					{
						return true;
					}
				}
			}
			return false;
		}

		public void CopyTo(GameObject[] array, int arrayIndex)
		{
			foreach (GameObjectMap map in _maps)
			{
				array[arrayIndex++] = map.GameObject;
			}
		}

		public bool Remove(GameObject item)
		{
			if (item != null)
			{
				for (int num = _maps.Count; num >= 0; num--)
				{
					if (_maps[num].GameObject.GetInstanceID() == item.GetInstanceID())
					{
						_maps.RemoveAt(num);
						return true;
					}
				}
			}
			return false;
		}

		public void RestoreLayers()
		{
			foreach (GameObjectMap map in _maps)
			{
				map.GameObject.layer = map.Layer;
			}
		}

		public void SetTemporaryLayer(int temporaryLayer)
		{
			foreach (GameObjectMap map in _maps)
			{
				map.Layer = map.GameObject.layer;
				map.GameObject.layer = temporaryLayer;
			}
		}
	}
}
