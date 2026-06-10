using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;

namespace NSEipix.Model.Map
{
	public class TileMap : Singleton<TileMap>
	{
		private HashSet<Tile> tiles = new HashSet<Tile>();

		private TileMap()
		{
		}

		public bool Contains(Tile tile)
		{
			return tiles.Contains(tile);
		}

		public bool Contains(TileGrid grid)
		{
			return grid.Tiles.All((Tile tile) => Contains(tile));
		}

		public bool Overlaps(TileGrid grid)
		{
			return tiles.Any((Tile tile) => Contains(tile));
		}

		public void Add(Tile tile)
		{
			tiles.Add(tile);
		}

		public void Add(IEnumerable<Tile> tiles)
		{
			tiles.ForEach(delegate(Tile tile)
			{
				Add(tile);
			});
		}

		public void Add(TileGrid grid)
		{
			Add(grid.Tiles);
		}

		public void Subtract(Tile tile)
		{
			tiles.Remove(tile);
		}

		public void Subtract(IEnumerable<Tile> tiles)
		{
			tiles.ForEach(delegate(Tile tile)
			{
				Subtract(tile);
			});
		}

		public void Subtract(TileGrid grid)
		{
			Subtract(grid.Tiles);
		}

		public void Clear()
		{
			tiles.Clear();
		}
	}
}
