using System.Collections.Generic;

namespace Tabletop.GameWorld
{
	public struct MiniatureCollectionState
	{
		public readonly int completedCount;

		public readonly int paintedCount;

		public readonly int currentPiecesCount;

		public readonly List<int> missingPiecesList;

		public MiniatureCollectionState(int completed, int painted, int currentPieces, List<int> missingPieces)
		{
			completedCount = completed;
			paintedCount = painted;
			currentPiecesCount = currentPieces;
			missingPiecesList = new List<int>(missingPieces);
		}
	}
}
