using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.Collections
{
	public class GridLookup<T> where T : class
	{
		internal class Item
		{
			public Root root;

			public Item prev;

			public Item next;
		}

		public class Root
		{
			public T obj;

			public Root next;

			internal Root prev;

			internal IntRect previousBounds;

			internal List<Item> items;

			internal bool flag;

			public Vector3 previousPosition;

			public Quaternion previousRotation;
		}

		private Vector2Int size;

		private Item[] cells;

		private Root all;

		private Dictionary<T, Root> rootLookup;

		private Stack<Item> itemPool;

		public Root AllItems => null;

		public GridLookup(Vector2Int size)
		{
		}

		public void Clear()
		{
		}

		public Root GetRoot(T item)
		{
			return null;
		}

		public Root Add(T item, IntRect bounds)
		{
			return null;
		}

		public void Remove(T item)
		{
		}

		public void Dirty(T item)
		{
		}

		public void Move(T item, IntRect bounds)
		{
		}

		public List<U> QueryRect<U>(IntRect r) where U : class, T
		{
			return null;
		}

		public void Resize(IntRect newBounds)
		{
		}
	}
}
