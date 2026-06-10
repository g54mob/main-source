using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using UnityEngine;

namespace NSEipix.Model.Map
{
	[Serializable]
	public class TileGrid : NSEipix.Base.Model
	{
		[SerializeField]
		private int width;

		[SerializeField]
		private int height;

		[SerializeField]
		private int x;

		[SerializeField]
		private int y;

		private HashSet<Tile> tiles = new HashSet<Tile>();

		private int? hashCode;

		public List<Tile> Tiles => tiles.ToList();

		public TileGrid(int width, int height)
		{
			this.width = Mathf.Max(0, width);
			this.height = Mathf.Max(0, height);
			x = 0;
			y = 0;
			CacheTiles();
		}

		public TileGrid(int width, int height, int x, int y)
		{
			this.width = Mathf.Max(0, width);
			this.height = Mathf.Max(0, height);
			this.x = x;
			this.y = y;
			CacheTiles();
		}

		public bool Contains(Tile tile)
		{
			return tiles.Contains(tile);
		}

		public bool Contains(TileGrid grid)
		{
			return grid.tiles.All((Tile tile) => tiles.Contains(tile));
		}

		public bool Overlaps(TileGrid grid)
		{
			return grid.tiles.Any((Tile tile) => tiles.Contains(tile));
		}

		public TileGrid MoveTo(int newX, int newY)
		{
			return new TileGrid(width, height, newX, newY);
		}

		public TileGrid MoveBy(int offsetX, int offsetY)
		{
			return new TileGrid(width, height, x + offsetX, y + offsetY);
		}

		public override string GetID()
		{
			return $"{x},{y}";
		}

		public override int GetHashCode()
		{
			int? num = (hashCode = hashCode ?? ((x + y) * (x + y + 1) / 2 + y));
			return num.Value;
		}

		private void CacheTiles()
		{
			int num = width + x;
			int num2 = height + y;
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < num2; j++)
				{
					tiles.Add(new Tile(i, j));
				}
			}
		}
	}
}
