using UnityEngine;

namespace Data.FactoryFloor.Islands
{
	public static class EnvironmentColorIDs
	{
		public enum FloorType
		{
			Tile = 0,
			Grass = 1,
			Hole = 2,
			ElevatedGrass = 3
		}

		private enum HeightID
		{
			RegularTile = 0,
			Hole = 1,
			LowTile = 2,
			ElevatedTile = 3
		}

		private enum TileID
		{
			Tile = 0,
			Grass = 1,
			EdgeRotUp = 2,
			EdgeRotRight = 3,
			EdgeRotDown = 4,
			EdgeRotLeft = 5,
			CornerRotUpR = 6,
			CornerRotDownR = 7,
			CornerRotDownL = 8,
			CornerRotUpL = 9,
			DoubleEdgeVert = 10,
			DoubleEdgeHoriz = 11,
			UEdgeRotUp = 12,
			UEdgeRotRight = 13,
			UEdgeRotDown = 14,
			UEdgeRotLeft = 15,
			SurroundedTile = 16,
			CornerOutUpR = 17,
			CornerOutDownR = 18,
			CornerOutUpL = 19,
			CornerOutDownL = 20,
			CornerOutUp = 21,
			CornerOutRight = 22,
			CornerOutDown = 23,
			CornerOutLeft = 24,
			CornerOutDiagUpR = 25,
			CornerOutDiagUpL = 26,
			CornerOutCornerUpR = 28,
			CornerOutCornerDownL = 29,
			CornerOutCornerDownR = 30,
			CornerOutCornerUpL = 31,
			CornerOutFull = 32
		}

		public static readonly Color32 Default = GetColor(FloorType.Tile);

		public static bool IsGrass(Color32 color)
		{
			return color.g == 1;
		}

		public static bool IsTile(Color32 color)
		{
			if (color.r == 0)
			{
				return color.g != 1;
			}
			return false;
		}

		public static bool IsElevatedGrass(Color32 color)
		{
			if (color.r == 3)
			{
				return color.g == 1;
			}
			return false;
		}

		public static bool IsRegularHeight(Color32 color)
		{
			return color.r == 0;
		}

		public static Color32 GetColor(FloorType floorType)
		{
			return floorType switch
			{
				FloorType.Tile => new Color32(0, 0, 0, 0), 
				FloorType.Grass => new Color32(0, 1, 0, 0), 
				FloorType.ElevatedGrass => new Color32(3, 1, 0, 0), 
				FloorType.Hole => new Color32(1, 0, 0, 0), 
				_ => Default, 
			};
		}

		public static int GetRotatedTile(bool up, bool right, bool down, bool left, bool upR, bool downR, bool downL, bool upL)
		{
			TileID tileID = TileID.Tile;
			int num = (up ? 1 : 0) + (right ? 1 : 0) + (down ? 1 : 0) + (left ? 1 : 0);
			switch (num)
			{
			case 1:
				tileID = ((!up) ? ((!right) ? ((!down) ? TileID.EdgeRotLeft : TileID.EdgeRotDown) : TileID.EdgeRotRight) : TileID.EdgeRotUp);
				break;
			case 2:
				tileID = ((!(up && down)) ? ((!(left && right)) ? ((!(up && right)) ? ((!(down && right)) ? ((!(down && left)) ? TileID.CornerRotUpL : TileID.CornerRotDownL) : TileID.CornerRotDownR) : TileID.CornerRotUpR) : TileID.DoubleEdgeHoriz) : TileID.DoubleEdgeVert);
				break;
			case 3:
				tileID = (up ? (right ? (down ? TileID.UEdgeRotRight : TileID.UEdgeRotUp) : TileID.UEdgeRotLeft) : TileID.UEdgeRotDown);
				break;
			case 4:
				tileID = TileID.SurroundedTile;
				break;
			}
			if (num != 0)
			{
				return (int)tileID;
			}
			if (tileID != TileID.DoubleEdgeVert && tileID != TileID.DoubleEdgeHoriz && num < 3)
			{
				switch ((upR ? 1 : 0) + (downR ? 1 : 0) + (downL ? 1 : 0) + (upL ? 1 : 0))
				{
				case 1:
					tileID = ((!upR) ? ((!downR) ? ((!downL) ? TileID.CornerOutUpL : TileID.CornerOutDownL) : TileID.CornerOutDownR) : TileID.CornerOutUpR);
					break;
				case 2:
					tileID = ((!(upR && downR)) ? ((!(downL && upL)) ? ((!(upR && upL)) ? ((!(downR && downL)) ? ((!(upR && downL)) ? TileID.CornerOutDiagUpL : TileID.CornerOutDiagUpR) : TileID.CornerOutDown) : TileID.CornerOutUp) : TileID.CornerOutLeft) : TileID.CornerOutRight);
					break;
				case 3:
					tileID = (upR ? (downR ? (downL ? TileID.CornerOutCornerDownR : TileID.CornerOutCornerUpR) : TileID.CornerOutCornerUpL) : TileID.CornerOutCornerDownL);
					break;
				case 4:
					tileID = TileID.CornerOutFull;
					break;
				}
			}
			return (int)tileID;
		}
	}
}
