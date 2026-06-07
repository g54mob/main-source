using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public abstract class BaseDataContainer : ScriptableObject, IEnumerable
	{
		public abstract int Count { get; }

		public abstract Object GetDataAtIndex(int index);

		public T GetDataAtIndex<T>(int index) where T : Object, IDataContainerElement
		{
			if (GetDataAtIndex(index) is T result)
			{
				return result;
			}
			return null;
		}

		public abstract bool TryGetDataByUID(int uid, out Object obj);

		public bool TryGetDataByUID<T>(int uid, out T data) where T : Object, IDataContainerElement
		{
			if (TryGetDataByUID(uid, out var obj) && obj is T val)
			{
				data = val;
				return true;
			}
			data = null;
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return GetDataAtIndex(i);
			}
		}

		public IEnumerable<T> GetDataEnumerator<T>() where T : Object, IDataContainerElement
		{
			for (int i = 0; i < Count; i++)
			{
				yield return GetDataAtIndex<T>(i);
			}
		}

		protected IDataContainerElement GetObjectAsDataContainerElement(Object obj)
		{
			if (obj is IDataContainerElement result)
			{
				return result;
			}
			if (obj is GameObject gameObject && gameObject.TryGetComponent<IDataContainerElement>(out var component))
			{
				return component;
			}
			return null;
		}

		[ContextMenu("Clean")]
		private void Clean()
		{
		}
	}
}
