using UnityEngine;

namespace CritiasFoliage
{
	public struct FoliageCell
	{
		public delegate void FoliageIterationAction(int hash);

		private static readonly int prime1 = 179425889;

		private static readonly int prime2 = 373587157;

		private static readonly int prime3 = 79425917;

		public int x;

		public int y;

		public int z;

		public FoliageCell(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public FoliageCell(Vector3 pos, bool subdivided)
		{
			if (!subdivided)
			{
				x = Mathf.FloorToInt(pos.x / 100f);
				y = Mathf.FloorToInt(pos.y / 100f);
				z = Mathf.FloorToInt(pos.z / 100f);
			}
			else
			{
				x = Mathf.FloorToInt(pos.x / 20f);
				y = Mathf.FloorToInt(pos.y / 20f);
				z = Mathf.FloorToInt(pos.z / 20f);
			}
		}

		public void Set(Vector3 pos)
		{
			x = Mathf.FloorToInt(pos.x / 100f);
			y = Mathf.FloorToInt(pos.y / 100f);
			z = Mathf.FloorToInt(pos.z / 100f);
		}

		public void SetSubdivided(Vector3 pos)
		{
			x = Mathf.FloorToInt(pos.x / 20f);
			y = Mathf.FloorToInt(pos.y / 20f);
			z = Mathf.FloorToInt(pos.z / 20f);
		}

		public Vector3 GetCenter()
		{
			return new Vector3(100f * (float)x + 50f, 100f * (float)y + 50f, 100f * (float)z + 50f);
		}

		public Vector3 GetCenterSubdivided()
		{
			return new Vector3(20f * (float)x + 10f, 20f * (float)y + 10f, 20f * (float)z + 10f);
		}

		public Bounds GetBounds()
		{
			return new Bounds(GetCenter(), FoliageGlobals.CELL_SIZE3);
		}

		public Bounds GetBoundsSubdivided()
		{
			return new Bounds(GetCenterSubdivided(), FoliageGlobals.CELL_SUBDIVIDED_SIZE3);
		}

		public override int GetHashCode()
		{
			return prime1 * x + prime2 * y + prime3 * z;
		}

		public override bool Equals(object obj)
		{
			FoliageCell foliageCell = (FoliageCell)obj;
			if (foliageCell.x != x)
			{
				return false;
			}
			if (foliageCell.y != y)
			{
				return false;
			}
			if (foliageCell.z != z)
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return $"({x}, {y}, {z})";
		}

		public static int MakeHashSubdivided(Vector3 pos)
		{
			int num = Mathf.FloorToInt(pos.x / 20f);
			int num2 = Mathf.FloorToInt(pos.y / 20f);
			int num3 = Mathf.FloorToInt(pos.z / 20f);
			return prime1 * num + prime2 * num2 + prime3 * num3;
		}

		public static int MakeHash(Vector3 pos)
		{
			int num = Mathf.FloorToInt(pos.x / 100f);
			int num2 = Mathf.FloorToInt(pos.y / 100f);
			int num3 = Mathf.FloorToInt(pos.z / 100f);
			return prime1 * num + prime2 * num2 + prime3 * num3;
		}

		public static int MakeHash(int x, int y, int z)
		{
			return prime1 * x + prime2 * y + prime3 * z;
		}

		public static void IterateMinMax(Vector3 min, Vector3 max, bool subdivided, FoliageIterationAction action)
		{
			FoliageCell foliageCell = new FoliageCell(min, subdivided);
			FoliageCell foliageCell2 = new FoliageCell(max, subdivided);
			for (int i = foliageCell.x; i <= foliageCell2.x; i++)
			{
				for (int j = foliageCell.y; j <= foliageCell2.y; j++)
				{
					for (int k = foliageCell.z; k <= foliageCell2.z; k++)
					{
						action(MakeHash(i, j, k));
					}
				}
			}
		}

		public static void IterateNeighboring(FoliageCell cell, int depth, FoliageIterationAction action)
		{
			int num = cell.x - depth;
			int num2 = cell.x + depth;
			int num3 = cell.y - depth;
			int num4 = cell.y + depth;
			int num5 = cell.z - depth;
			int num6 = cell.z + depth;
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					for (int k = num5; k <= num6; k++)
					{
						action(MakeHash(i, j, k));
					}
				}
			}
		}
	}
}
