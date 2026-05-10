using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public abstract class SaveStaticSet<T> : SaveContainer where T : class
	{
		private readonly HashSet<(int, T)> _loadedObjects = new HashSet<(int, T)>();

		protected ReadOnlyHashSet<(int, T)> loadedObjects => _loadedObjects;

		public abstract bool CanObjectBeSaved(T obj);

		protected abstract void SaveSingle(string saveKey, T obj, ES3Settings settings);

		protected abstract T InstantiateSingle(string saveKey, ES3Settings settings);

		protected abstract void LoadIntoSingle(string saveKey, T obj, ES3Settings settings);

		public override void Save(ES3Settings settings)
		{
			ReadOnlyHashSet<T> list = StaticObjectSet<T>.List;
			if (list.Count <= 0)
			{
				return;
			}
			int num = 0;
			foreach (T item in list)
			{
				if (item == null)
				{
					Debug.LogException(new NullReferenceException("Cannot save null object"));
					continue;
				}
				try
				{
					if (!CanObjectBeSaved(item))
					{
						continue;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					continue;
				}
				string saveKey = typeof(T).Name + num;
				SaveSingle(saveKey, item, settings);
				num++;
			}
			if (num != 0)
			{
				ES3.Save(typeof(T).Name + "count", num, settings);
			}
		}

		public override void LoadInit(ES3Settings settings)
		{
			_loadedObjects.Clear();
			int num = ES3.Load(typeof(T).Name + "count", 0, settings);
			for (int i = 0; i < num; i++)
			{
				string saveKey = typeof(T).Name + i;
				T val = InstantiateSingle(saveKey, settings);
				if (!EqualityComparer<T>.Default.Equals(val, null))
				{
					StaticObjectSet<T>.Add(val);
					_loadedObjects.Add((i, val));
					LoadIntoSingle(typeof(T).Name + i, val, settings);
				}
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			foreach (var (num, obj) in _loadedObjects)
			{
				LoadIntoSingle(typeof(T).Name + num, obj, settings);
			}
			OnAllLoaded();
			_loadedObjects.Clear();
		}

		protected virtual void OnAllLoaded()
		{
		}
	}
}
