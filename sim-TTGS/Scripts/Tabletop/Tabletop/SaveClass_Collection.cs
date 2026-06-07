using System;
using System.Collections.Generic;
using Simulator;
using Tabletop.GameWorld;
using UnityEngine;

namespace Tabletop
{
	[Serializable]
	public class SaveClass_Collection : ISaveClass
	{
		public List<int> completeMiniaturesKeys;

		public List<int> completeMiniaturesValues;

		public List<int> miniaturesPaintingScores;

		public List<int> miniaturesPaintedCount;

		public List<Vector2Int> piecesKeys;

		public List<int> piecesValues;

		public List<int> miniatureProductsKeys;

		public List<int> miniatureProductsInSale;

		public List<int> miniatureProductsInDisplay;

		public List<CollectionWargameSquad> wargameSquads;

		public void StartSaveProcess()
		{
			completeMiniaturesKeys = new List<int>();
			completeMiniaturesValues = new List<int>();
			miniaturesPaintingScores = new List<int>();
			miniaturesPaintedCount = new List<int>();
			piecesKeys = new List<Vector2Int>();
			piecesValues = new List<int>();
			miniatureProductsKeys = new List<int>();
			miniatureProductsInSale = new List<int>();
			miniatureProductsInDisplay = new List<int>();
			wargameSquads = new List<CollectionWargameSquad>();
		}

		public void SaveCompleteMiniature(int uid, int completeCount, int paintingScore, int paintedCount)
		{
			completeMiniaturesKeys.Add(uid);
			completeMiniaturesValues.Add(completeCount);
			miniaturesPaintingScores.Add(paintingScore);
			miniaturesPaintedCount.Add(paintedCount);
		}

		public void SavePiece(Vector2Int uid, int count)
		{
			piecesKeys.Add(uid);
			piecesValues.Add(count);
		}

		public void SaveMiniatureProduct(int uid, int inSaleCount, int inDisplayCount)
		{
			miniatureProductsKeys.Add(uid);
			miniatureProductsInSale.Add(inSaleCount);
			miniatureProductsInDisplay.Add(inDisplayCount);
		}

		public void SaveWargameSquads(CollectionWargameSquad[] squads)
		{
			foreach (CollectionWargameSquad item in squads)
			{
				wargameSquads.Add(item);
			}
		}
	}
}
