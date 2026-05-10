using System.Collections.Generic;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public abstract class SaveStaticComponentList<T> : SaveContainer where T : MonoBehaviour, IPoolable
	{
		[SerializeField]
		private T _prefab;

		private readonly HashSet<(int, T)> _loadedObjects = new HashSet<(int, T)>();

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
				if (CanObjectBeSaved(item))
				{
					ES3.Save(typeof(T).Name + num, item.gameObject, settings);
					num++;
				}
			}
			ES3.Save(typeof(T).Name + "count", num, settings);
		}

		protected abstract bool CanObjectBeSaved(T obj);

		public override void LoadInit(ES3Settings settings)
		{
			_loadedObjects.Clear();
			int num = ES3.Load(typeof(T).Name + "count", 0, settings);
			for (int i = 0; i < num; i++)
			{
				T val = Pooler.Pull(_prefab);
				_loadedObjects.Add((i, val));
				ES3.LoadInto(typeof(T).Name + i, val.gameObject, settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			foreach (var (num, val) in _loadedObjects)
			{
				ES3.LoadInto(typeof(T).Name + num, val.gameObject, settings);
			}
			_loadedObjects.Clear();
		}
	}
}
