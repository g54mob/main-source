using Unity.Mathematics;
using UnityEngine;

namespace PugTilemap.Quads
{
	public static class AdjacentDir
	{
		public const int E = 1;

		public const int SE = 2;

		public const int S = 4;

		public const int SW = 8;

		public const int W = 16;

		public const int NW = 32;

		public const int N = 64;

		public const int NE = 128;

		public const int All8WayMask = 255;

		public const int Straight4WayMask = 85;

		public const int Diagonal4WayMask = 170;

		public const int Vertical2WayMask = 68;

		public const int Horizontal2WayMask = 17;

		public const int CornerTopLeft = 112;

		public const int CornerTopRight = 193;

		public const int CornerBotLeft = 28;

		public const int CornerBotRight = 7;

		public static readonly int[] corners = new int[4] { 193, 112, 7, 28 };

		public const int leftSide = 131;

		public const int rightSide = 56;

		public const int topSide = 224;

		public const int botSide = 14;

		public static readonly int[] eightWay = new int[8] { 1, 2, 4, 8, 16, 32, 64, 128 };

		public static readonly int[] fourWay = new int[4] { 1, 4, 16, 64 };

		public static readonly int[] horizontalWay = new int[2] { 1, 16 };

		public static readonly int[] allFourWayCombinations = new int[15]
		{
			1, 4, 16, 64, 5, 17, 65, 20, 68, 80,
			21, 81, 69, 84, 85
		};

		public static int[] GetWays(bool getFourWay, bool getHorizontalWay)
		{
			if (!getHorizontalWay)
			{
				if (!getFourWay)
				{
					return eightWay;
				}
				return fourWay;
			}
			return horizontalWay;
		}

		public static Vector3Int GetVector(int dir)
		{
			switch (dir)
			{
			case 1:
				return new Vector3Int(1, 0, 0);
			case 2:
				return new Vector3Int(1, 0, -1);
			case 4:
				return new Vector3Int(0, 0, -1);
			case 8:
				return new Vector3Int(-1, 0, -1);
			case 16:
				return new Vector3Int(-1, 0, 0);
			case 32:
				return new Vector3Int(-1, 0, 1);
			case 64:
				return new Vector3Int(0, 0, 1);
			case 128:
				return new Vector3Int(1, 0, 1);
			default:
				Debug.LogError("Invalid direction: " + dir);
				return Vector3Int.zero;
			}
		}

		public static float3 GetFloat3(int dir)
		{
			return dir switch
			{
				1 => new float3(1f, 0f, 0f), 
				2 => new float3(1f, 0f, -1f), 
				4 => new float3(0f, 0f, -1f), 
				8 => new float3(-1f, 0f, -1f), 
				16 => new float3(-1f, 0f, 0f), 
				32 => new float3(-1f, 0f, 1f), 
				64 => new float3(0f, 0f, 1f), 
				128 => new float3(1f, 0f, 1f), 
				_ => float3.zero, 
			};
		}

		public static int2 GetInt2(int dir)
		{
			return dir switch
			{
				1 => new int2(1, 0), 
				2 => new int2(1, -1), 
				4 => new int2(0, -1), 
				8 => new int2(-1, -1), 
				16 => new int2(-1, 0), 
				32 => new int2(-1, 1), 
				64 => new int2(0, 1), 
				128 => new int2(1, 1), 
				_ => int2.zero, 
			};
		}

		public static Vector2Int GetVector2D(int dir)
		{
			switch (dir)
			{
			case 1:
				return new Vector2Int(1, 0);
			case 2:
				return new Vector2Int(1, -1);
			case 4:
				return new Vector2Int(0, -1);
			case 8:
				return new Vector2Int(-1, -1);
			case 16:
				return new Vector2Int(-1, 0);
			case 32:
				return new Vector2Int(-1, 1);
			case 64:
				return new Vector2Int(0, 1);
			case 128:
				return new Vector2Int(1, 1);
			default:
				Debug.LogError("Invalid direction: " + dir);
				return Vector2Int.zero;
			}
		}

		public static int GetDir(Vector3Int vec)
		{
			if (vec.x == 1 && vec.y == 0)
			{
				return 1;
			}
			if (vec.x == 1 && vec.y == -1)
			{
				return 2;
			}
			if (vec.x == 0 && vec.y == -1)
			{
				return 4;
			}
			if (vec.x == -1 && vec.y == -1)
			{
				return 8;
			}
			if (vec.x == -1 && vec.y == 0)
			{
				return 16;
			}
			if (vec.x == -1 && vec.y == 1)
			{
				return 32;
			}
			if (vec.x == 0 && vec.y == 1)
			{
				return 64;
			}
			if (vec.x == 1 && vec.y == 1)
			{
				return 128;
			}
			Vector3Int vector3Int = vec;
			Debug.LogError("Invalid direction: " + vector3Int.ToString());
			return 0;
		}

		public static string GetMaskString(int m)
		{
			string text = "";
			if ((m & 1) != 0)
			{
				text += "E ";
			}
			if ((m & 2) != 0)
			{
				text += "SE ";
			}
			if ((m & 4) != 0)
			{
				text += "S ";
			}
			if ((m & 8) != 0)
			{
				text += "SW ";
			}
			if ((m & 0x10) != 0)
			{
				text += "W ";
			}
			if ((m & 0x20) != 0)
			{
				text += "NW ";
			}
			if ((m & 0x40) != 0)
			{
				text += "N ";
			}
			if ((m & 0x80) != 0)
			{
				text += "NE ";
			}
			if (text == "")
			{
				text = "<none>";
			}
			return text;
		}

		public static int GetAdjacentDirsMask(int dir)
		{
			int num = ((dir == 1) ? 128 : (dir >> 1));
			int num2 = ((dir == 128) ? 1 : (dir << 1));
			return num | num2;
		}

		public static bool IsOppositeDirections(int dir1, int dir2)
		{
			return dir1 switch
			{
				1 => dir2 == 16, 
				16 => dir2 == 1, 
				4 => dir2 == 64, 
				64 => dir2 == 4, 
				128 => dir2 == 8, 
				32 => dir2 == 2, 
				2 => dir2 == 32, 
				8 => dir2 == 32, 
				_ => false, 
			};
		}

		public static int[] GetSubCornerBitMasks(int dirFlags)
		{
			return new int[4]
			{
				GetBotLeftSubCornerBitMask(dirFlags),
				GetBotRightSubCornerBitMask(dirFlags),
				GetTopLeftSubCornerBitMask(dirFlags),
				GetTopRightSubCornerBitMask(dirFlags)
			};
		}

		public static int GetTopLeftSubCornerBitMask(int dirFlags)
		{
			int num = 7;
			if ((dirFlags & 0x10) > 0)
			{
				num |= 0x10;
				num |= 8;
			}
			if ((dirFlags & 0x40) > 0)
			{
				num |= 0x40;
				num |= 0x80;
			}
			if ((dirFlags & 0x20) > 0)
			{
				num |= 0x20;
			}
			return num;
		}

		public static int GetTopRightSubCornerBitMask(int dirFlags)
		{
			int num = 28;
			if ((dirFlags & 1) > 0)
			{
				num |= 1;
				num |= 2;
			}
			if ((dirFlags & 0x40) > 0)
			{
				num |= 0x40;
				num |= 0x20;
			}
			if ((dirFlags & 0x80) > 0)
			{
				num |= 0x80;
			}
			return num;
		}

		public static int GetBotLeftSubCornerBitMask(int dirFlags)
		{
			int num = 193;
			if ((dirFlags & 0x10) > 0)
			{
				num |= 0x10;
				num |= 0x20;
			}
			if ((dirFlags & 4) > 0)
			{
				num |= 4;
				num |= 2;
			}
			if ((dirFlags & 8) > 0)
			{
				num |= 8;
			}
			return num;
		}

		public static int GetBotRightSubCornerBitMask(int dirFlags)
		{
			int num = 112;
			if ((dirFlags & 1) > 0)
			{
				num |= 1;
				num |= 0x80;
			}
			if ((dirFlags & 4) > 0)
			{
				num |= 4;
				num |= 8;
			}
			if ((dirFlags & 2) > 0)
			{
				num |= 2;
			}
			return num;
		}
	}
}
