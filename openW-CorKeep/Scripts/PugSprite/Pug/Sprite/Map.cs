using System.Collections.Generic;

namespace Pug.Sprite
{
	public class Map<T1, T2>
	{
		private Dictionary<T1, T2> m_forward;

		private Dictionary<T2, T1> m_back;

		public Map()
		{
			m_forward = new Dictionary<T1, T2>();
			m_back = new Dictionary<T2, T1>();
		}

		public void Clear()
		{
			m_forward.Clear();
			m_back.Clear();
		}

		public void Add(T1 key, T2 value)
		{
			m_forward.Add(key, value);
			m_back.Add(value, key);
		}

		public bool ContainsKey(T1 key)
		{
			return m_forward.ContainsKey(key);
		}

		public bool ContainsValue(T2 value)
		{
			return m_back.ContainsKey(value);
		}

		public T2 GetValue(T1 key)
		{
			return m_forward[key];
		}

		public T1 GetKey(T2 value)
		{
			return m_back[value];
		}

		public bool TryGetValue(T1 key, out T2 value)
		{
			if (m_forward.TryGetValue(key, out value))
			{
				return true;
			}
			return false;
		}

		public bool TryGetKey(T2 value, out T1 key)
		{
			if (m_back.TryGetValue(value, out key))
			{
				return true;
			}
			return false;
		}
	}
}
