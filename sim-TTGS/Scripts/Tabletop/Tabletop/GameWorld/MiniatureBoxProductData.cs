using System.Collections.Generic;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureBoxProductData : TabletopProductData
	{
		[SerializeField]
		private EMiniatureBoxRarity m_rarity;

		[SerializeField]
		private EMiniatureArmy m_army;

		[SerializeField]
		[Range(1f, 30f)]
		private int m_piecesByBox = 6;

		[SerializeField]
		private MiniatureRarityModifier m_rarityModifier;

		public EMiniatureBoxRarity Rarity => m_rarity;

		public int PiecesByBox => m_piecesByBox;

		public List<MiniaturePieceData> ComputeMiniaturePiecePool()
		{
			return MiniatureDatabase.ComputeMiniaturePiecePool(base.License, m_rarityModifier, m_army);
		}
	}
}
