using System;
using UnityEngine;

namespace HQFPSTemplate
{
	public class Message
	{
		private Action m_Callbacks;

		private float m_CallTime;

		public float LastCallTime
		{
			get
			{
				return m_CallTime;
			}
			private set
			{
			}
		}

		public void AddListener(Action callback)
		{
			m_Callbacks = (Action)Delegate.Combine(m_Callbacks, callback);
		}

		public void RemoveListener(Action callback)
		{
			m_Callbacks = (Action)Delegate.Remove(m_Callbacks, callback);
		}

		public void Send()
		{
			if (m_Callbacks != null)
			{
				m_CallTime = Time.time;
				m_Callbacks();
			}
		}
	}
	public class Message<T>
	{
		private Action<T> m_Callbacks;

		public void AddListener(Action<T> callback)
		{
			m_Callbacks = (Action<T>)Delegate.Combine(m_Callbacks, callback);
		}

		public void RemoveListener(Action<T> callback)
		{
			m_Callbacks = (Action<T>)Delegate.Remove(m_Callbacks, callback);
		}

		public void Send(T arg)
		{
			if (m_Callbacks != null)
			{
				m_Callbacks(arg);
			}
		}
	}
	public class Message<T, V>
	{
		private Action<T, V> m_Callbacks;

		public void AddListener(Action<T, V> callback)
		{
			m_Callbacks = (Action<T, V>)Delegate.Combine(m_Callbacks, callback);
		}

		public void RemoveListener(Action<T, V> callback)
		{
			m_Callbacks = (Action<T, V>)Delegate.Remove(m_Callbacks, callback);
		}

		public void Send(T arg1, V arg2)
		{
			if (m_Callbacks != null)
			{
				m_Callbacks(arg1, arg2);
			}
		}
	}
	public class Message<T, V, K>
	{
		private Action<T, V, K> m_Callbacks;

		public void AddListener(Action<T, V, K> callback)
		{
			m_Callbacks = (Action<T, V, K>)Delegate.Combine(m_Callbacks, callback);
		}

		public void RemoveListener(Action<T, V, K> callback)
		{
			m_Callbacks = (Action<T, V, K>)Delegate.Remove(m_Callbacks, callback);
		}

		public void Send(T arg1, V arg2, K arg3)
		{
			if (m_Callbacks != null)
			{
				m_Callbacks(arg1, arg2, arg3);
			}
		}
	}
}
