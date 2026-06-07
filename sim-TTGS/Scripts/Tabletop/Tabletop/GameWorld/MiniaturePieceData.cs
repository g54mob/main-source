using System;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public struct MiniaturePieceData
	{
		[SerializeField]
		private GameObject m_prefab;

		private MiniatureData m_miniatureData;

		private int m_index;

		public GameObject Prefab => m_prefab;

		public Vector2Int UID => new Vector2Int(MiniatureData.UID, m_index);

		public MiniatureData MiniatureData => m_miniatureData;

		public MiniaturePieceData(MiniaturePieceData data, MiniatureData miniatureData, int index)
		{
			m_prefab = data.m_prefab;
			m_miniatureData = miniatureData;
			m_index = index;
		}
	}
}
