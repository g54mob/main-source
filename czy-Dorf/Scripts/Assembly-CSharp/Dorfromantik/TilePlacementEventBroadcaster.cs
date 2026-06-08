using System;
using UnityEngine;

namespace Dorfromantik
{
	public class TilePlacementEventBroadcaster : ScriptableObject
	{
		public event Action<Tile, bool> OnTilePlaced_BoardPlacement;

		public event Action<Tile, bool> OnTilePlaced_UndoStored;

		public event Action<Tile, bool> OnTilePlaced_QuestsProcessed;

		public event Action<Tile, bool> OnTilePlaced_Finalized;

		public event Action<Vector3> OnTurnUndone;

		public void BroadcastTilePlacedOnBoard(Tile placedTile, bool placedByPlayer)
		{
			this.OnTilePlaced_BoardPlacement?.Invoke(placedTile, placedByPlayer);
		}

		public void BroadcastTileUndoStored(Tile placedTile, bool placedByPlayer)
		{
			this.OnTilePlaced_UndoStored?.Invoke(placedTile, placedByPlayer);
		}

		public void BroadcastTilePlacedQuestProcessed(Tile placedTile, bool placedByPlayer)
		{
			this.OnTilePlaced_QuestsProcessed?.Invoke(placedTile, placedByPlayer);
		}

		public void BroadcastTilePlacedFinalized(Tile placedTile, bool placedByPlayer)
		{
			this.OnTilePlaced_Finalized?.Invoke(placedTile, placedByPlayer);
		}

		public void BroadcastTurnUndone(Vector3 undoneTileWorldPos)
		{
			this.OnTurnUndone?.Invoke(undoneTileWorldPos);
		}
	}
}
