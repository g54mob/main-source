using System;
using UnityEngine;

namespace HQFPSTemplate
{
	public class Value<T>
	{
		public delegate T Filter(T previousValue, T newValue);

		[NonSerialized]
		private Action<T> m_Set;

		[NonSerialized]
		private Filter m_Filter;

		[SerializeField]
		private T m_CurrentValue;

		[SerializeField]
		private T m_PreviousValue;

		public T Val => m_CurrentValue;

		public T PrevVal => m_PreviousValue;

		public Value()
		{
			m_CurrentValue = default(T);
			m_PreviousValue = default(T);
		}

		public Value(T initialValue)
		{
			m_CurrentValue = initialValue;
			m_PreviousValue = m_CurrentValue;
		}

		public void AddChangeListener(Action<T> callback)
		{
			m_Set = (Action<T>)Delegate.Combine(m_Set, callback);
		}

		public void RemoveChangeListener(Action<T> callback)
		{
			m_Set = (Action<T>)Delegate.Remove(m_Set, callback);
		}

		public void SetFilter(Filter filter)
		{
			m_Filter = filter;
		}

		public T Get()
		{
			return m_CurrentValue;
		}

		public T GetPreviousValue()
		{
			return m_PreviousValue;
		}

		public void Set(T value)
		{
			m_PreviousValue = m_CurrentValue;
			m_CurrentValue = value;
			if (m_Filter != null)
			{
				m_CurrentValue = m_Filter(m_PreviousValue, m_CurrentValue);
			}
			int num;
			if (m_PreviousValue != null || m_CurrentValue == null)
			{
				if (m_PreviousValue != null)
				{
					ref T previousValue = ref m_PreviousValue;
					object obj = m_CurrentValue;
					num = ((!previousValue.Equals(obj)) ? 1 : 0);
				}
				else
				{
					num = 0;
				}
			}
			else
			{
				num = 1;
			}
			bool flag = (byte)num != 0;
			if (m_Set != null && flag)
			{
				m_Set(m_CurrentValue);
			}
		}

		public void SetAndForceUpdate(T value)
		{
			m_PreviousValue = m_CurrentValue;
			m_CurrentValue = value;
			if (m_Filter != null)
			{
				m_CurrentValue = m_Filter(m_PreviousValue, m_CurrentValue);
			}
			if (m_Set != null)
			{
				m_Set(m_CurrentValue);
			}
		}

		public void SetAndDontUpdate(T value)
		{
			m_PreviousValue = m_CurrentValue;
			m_CurrentValue = value;
			if (m_Filter != null)
			{
				m_CurrentValue = m_Filter(m_PreviousValue, m_CurrentValue);
			}
		}

		public bool Is(T value)
		{
			if (m_CurrentValue != null)
			{
				return m_CurrentValue.Equals(value);
			}
			return false;
		}
	}
}
