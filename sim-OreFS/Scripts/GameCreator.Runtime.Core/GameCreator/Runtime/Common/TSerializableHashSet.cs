using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TSerializableHashSet<T> : ISerializationCallbackReceiver, IEnumerable<T>, IEnumerable
	{
		[NonSerialized]
		private HashSet<T> m_HashSet;

		[SerializeField]
		private T[] m_Values = Array.Empty<T>();

		public int Count => m_HashSet.Count;

		protected TSerializableHashSet()
		{
			m_HashSet = new HashSet<T>();
		}

		public bool Contains(T value)
		{
			return m_HashSet.Contains(value);
		}

		public void Clear()
		{
			m_HashSet.Clear();
		}

		public bool Add(T value)
		{
			return m_HashSet.Add(value);
		}

		public bool Remove(T value)
		{
			return m_HashSet.Remove(value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_HashSet.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return m_HashSet.GetEnumerator();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (AssemblyUtils.IsReloading)
			{
				return;
			}
			if (m_HashSet == null)
			{
				m_Values = Array.Empty<T>();
				return;
			}
			m_Values = new T[m_HashSet.Count];
			int num = 0;
			foreach (T item in m_HashSet)
			{
				m_Values[num] = item;
				num++;
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (!AssemblyUtils.IsReloading)
			{
				m_HashSet = new HashSet<T>();
				T[] values = m_Values;
				foreach (T item in values)
				{
					m_HashSet.Add(item);
				}
			}
		}
	}
}
