using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public struct WargameSquad : IEnumerable<MiniatureData>, IEnumerable
	{
		[SerializeField]
		private MiniatureData[] m_miniatures;

		public int Count => m_miniatures.Length;

		public WargameSquad(MiniatureData data)
		{
			m_miniatures = new MiniatureData[WargameSettings.SquadSize];
			m_miniatures[0] = data;
		}

		public WargameSquad(CollectionWargameSquad squad)
		{
			m_miniatures = new MiniatureData[WargameSettings.SquadSize];
			for (int i = 0; i < m_miniatures.Length; i++)
			{
				m_miniatures[i] = MiniatureDatabase.Get(squad.GetMiniatureUID(i));
			}
		}

		public MiniatureData Get(int index)
		{
			return m_miniatures[index];
		}

		public IEnumerator<MiniatureData> GetEnumerator()
		{
			MiniatureData[] miniatures = m_miniatures;
			for (int i = 0; i < miniatures.Length; i++)
			{
				yield return miniatures[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Set(int index, MiniatureData data)
		{
			m_miniatures[index] = data;
		}
	}
}
