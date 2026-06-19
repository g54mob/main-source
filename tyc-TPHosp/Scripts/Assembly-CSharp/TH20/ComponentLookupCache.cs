using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ComponentLookupCache<TComponentType> where TComponentType : MonoBehaviour
	{
		private struct CacheItem<TV>
		{
			public readonly GameObject GameObject;

			public readonly TV Component;

			public CacheItem(GameObject gameObject, TV component)
			{
				GameObject = gameObject;
				Component = component;
			}
		}

		private readonly int _capacity;

		private readonly Dictionary<GameObject, LinkedListNode<CacheItem<TComponentType>>> _cacheMap;

		private readonly LinkedList<CacheItem<TComponentType>> _lruList = new LinkedList<CacheItem<TComponentType>>();

		public ComponentLookupCache(int capacity)
		{
			_capacity = capacity;
			_cacheMap = new Dictionary<GameObject, LinkedListNode<CacheItem<TComponentType>>>(capacity);
		}

		public TComponentType Get(GameObject gameObject)
		{
			if (_cacheMap.TryGetValue(gameObject, out var value))
			{
				TComponentType component = value.Value.Component;
				_lruList.Remove(value);
				_lruList.AddLast(value);
				return component;
			}
			TComponentType component2 = gameObject.GetComponent<TComponentType>();
			Add(gameObject, component2);
			return component2;
		}

		public void Add(GameObject gameObject, TComponentType component)
		{
			if (_cacheMap.Count >= _capacity)
			{
				RemoveFirst();
			}
			LinkedListNode<CacheItem<TComponentType>> linkedListNode = new LinkedListNode<CacheItem<TComponentType>>(new CacheItem<TComponentType>(gameObject, component));
			_lruList.AddLast(linkedListNode);
			_cacheMap.Add(gameObject, linkedListNode);
		}

		private void RemoveFirst()
		{
			LinkedListNode<CacheItem<TComponentType>> first = _lruList.First;
			_lruList.RemoveFirst();
			_cacheMap.Remove(first.Value.GameObject);
		}
	}
}
