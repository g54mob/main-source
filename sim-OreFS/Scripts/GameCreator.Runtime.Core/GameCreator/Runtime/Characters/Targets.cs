using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class Targets
	{
		[NonSerialized]
		private GameObject m_Primary;

		[NonSerialized]
		private readonly List<GameObject> m_List = new List<GameObject>();

		public GameObject Primary
		{
			get
			{
				return m_Primary;
			}
			set
			{
				if (!(m_Primary == value))
				{
					m_Primary = value;
					if (value != null && !m_List.Contains(value))
					{
						m_List.Add(value);
					}
					this.EventChangeTarget?.Invoke(m_Primary);
				}
			}
		}

		public List<GameObject> List
		{
			get
			{
				CleanNulls();
				return m_List;
			}
		}

		public event Action<GameObject> EventChangeTarget;

		public event Action<GameObject> EventCandidateAdd;

		public event Action<GameObject> EventCandidateRemove;

		public void AddCandidate(GameObject candidate)
		{
			CleanNulls();
			if (!(candidate == null) && !m_List.Contains(candidate))
			{
				m_List.Add(candidate);
				this.EventCandidateAdd?.Invoke(candidate);
			}
		}

		public void RemoveCandidate(GameObject candidate)
		{
			CleanNulls();
			if (!(candidate == null) && m_List.Contains(candidate))
			{
				m_List.Remove(candidate);
				if (m_Primary == candidate)
				{
					Primary = null;
				}
				this.EventCandidateRemove?.Invoke(candidate);
			}
		}

		private void CleanNulls()
		{
			for (int num = m_List.Count - 1; num >= 0; num--)
			{
				if (!(m_List[num] != null))
				{
					m_List.RemoveAt(num);
				}
			}
		}
	}
}
