using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TSerializableLinkList<T> : ISerializationCallbackReceiver, IEnumerable<T>, IEnumerable
	{
		[NonSerialized]
		private LinkedList<T> m_LinkList;

		[SerializeField]
		private T[] m_Values = Array.Empty<T>();

		public int Count => m_LinkList.Count;

		public bool IsEmpty => m_LinkList.Count == 0;

		protected TSerializableLinkList()
		{
			m_LinkList = new LinkedList<T>();
		}

		public bool Contains(T value)
		{
			return m_LinkList.Contains(value);
		}

		public void Clear()
		{
			m_LinkList.Clear();
		}

		public T First()
		{
			return m_LinkList.First.Value;
		}

		public T Last()
		{
			return m_LinkList.Last.Value;
		}

		public void AddFirst(T value)
		{
			m_LinkList.AddFirst(value);
		}

		public void AddLast(T value)
		{
			m_LinkList.AddLast(value);
		}

		public T RemoveFirst()
		{
			T result = First();
			m_LinkList.RemoveFirst();
			return result;
		}

		public T RemoveLast()
		{
			T result = Last();
			m_LinkList.RemoveLast();
			return result;
		}

		public bool Remove(T value)
		{
			return m_LinkList.Remove(value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_LinkList.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return m_LinkList.GetEnumerator();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (AssemblyUtils.IsReloading)
			{
				return;
			}
			if (m_LinkList == null)
			{
				m_Values = Array.Empty<T>();
				return;
			}
			m_Values = new T[m_LinkList.Count];
			int num = 0;
			foreach (T link in m_LinkList)
			{
				m_Values[num] = link;
				num++;
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (!AssemblyUtils.IsReloading)
			{
				m_LinkList = new LinkedList<T>(m_Values);
			}
		}
	}
}
