using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Tags
{
	[Serializable]
	public class GameplayTagsList : IEnumerable<int>, IEnumerable
	{
		[SerializeField]
		private List<int> m_tags;

		public int Count
		{
			get
			{
				if (m_tags == null)
				{
					return 0;
				}
				return m_tags.Count;
			}
		}

		public GameplayTagsList(HashSet<int> tags)
		{
			m_tags = new List<int>();
			foreach (int tag in tags)
			{
				m_tags.Add(tag);
			}
		}

		public void Set(HashSet<int> tags)
		{
			m_tags.Clear();
			foreach (int tag in tags)
			{
				m_tags.Add(tag);
			}
		}

		public IEnumerator<int> GetEnumerator()
		{
			foreach (int tag in m_tags)
			{
				yield return tag;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool Contains(int uid)
		{
			return m_tags.Contains(uid);
		}
	}
}
