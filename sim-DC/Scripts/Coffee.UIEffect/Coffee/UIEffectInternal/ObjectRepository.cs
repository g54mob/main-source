using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIEffectInternal
{
	internal class ObjectRepository<T> where T : UnityEngine.Object
	{
		private class Entry
		{
			public Hash128 hash;

			public int reference;

			public T storedObject;

			public void Release(Action<T> onRelease)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		private readonly Dictionary<Hash128, Entry> _cache;

		private readonly Dictionary<int, Hash128> _objectKey;

		private readonly string _name;

		private readonly Action<T> _onRelease;

		private readonly Stack<Entry> _pool;

		public int count => 0;

		public ObjectRepository(Action<T> onRelease = null)
		{
		}

		public void Clear()
		{
		}

		public bool Valid(Hash128 hash, T obj)
		{
			return false;
		}

		public void Get(Hash128 hash, ref T obj, Func<T> onCreate)
		{
		}

		public void Get<TS>(Hash128 hash, ref T obj, Func<TS, T> onCreate, TS source)
		{
		}

		private bool GetFromCache(Hash128 hash, ref T obj)
		{
			return false;
		}

		private void Add(Hash128 hash, ref T obj, T newObject)
		{
		}

		public void Release(ref T obj)
		{
		}

		private void Remove(Entry entry)
		{
		}
	}
}
