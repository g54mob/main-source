using System.Collections.Generic;

namespace Pieces
{
	public class Twin : Piece
	{
		public List<TileData> SpawnTiles
		{
			get
			{
				return GetUpdatedLineOfSightTiles();
			}
		}

		public bool InCheck { get; set; }

		protected override void Start()
		{
		}

		public void UpdateSpawnMoves()
		{
		}

		private List<TileData> GetUpdatedLineOfSightTiles()
		{
			UpdateSpawnMoves();
			List<TileData> tilesThatCanSpawnCreatures = new List<TileData>();
			List<TileData> list = new List<TileData>();
			foreach (TileData item in tilesThatCanSpawnCreatures)
			{
				if (base.tile.BoardX + 1 >= item.BoardX && base.tile.BoardX - 1 <= item.BoardX && base.tile.BoardY + 1 >= item.BoardY && base.tile.BoardY - 1 <= item.BoardY)
				{
					list.Add(item);
				}
			}
			list.ForEach(delegate(TileData x)
			{
				tilesThatCanSpawnCreatures.Remove(x);
			});
			return tilesThatCanSpawnCreatures;
		}
	}
}
