using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model.MapNew;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Map
{
	public class SlopeGenerator
	{
		private static readonly byte[,] SubMatrix01 = new byte[7, 2]
		{
			{ 1, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 }
		};

		private static readonly byte[,] SubMatrix02 = new byte[7, 2]
		{
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 1, 1 }
		};

		private static readonly byte[,] SubMatrix03 = new byte[7, 2]
		{
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 1 }
		};

		private static readonly byte[,] SubMatrix04 = new byte[7, 2]
		{
			{ 1, 1 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 }
		};

		private static readonly byte[,] SubMatrix05 = new byte[2, 7]
		{
			{ 1, 1, 1, 1, 1, 1, 1 },
			{ 1, 0, 0, 0, 0, 0, 0 }
		};

		private static readonly byte[,] SubMatrix06 = new byte[2, 7]
		{
			{ 1, 1, 1, 1, 1, 1, 1 },
			{ 0, 0, 0, 0, 0, 0, 1 }
		};

		private static readonly byte[,] SubMatrix07 = new byte[7, 2]
		{
			{ 0, 0 },
			{ 0, 0 },
			{ 0, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 1 }
		};

		private static readonly byte[,] SubMatrix08 = new byte[7, 2]
		{
			{ 1, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 1 },
			{ 0, 0 },
			{ 0, 0 },
			{ 0, 0 }
		};

		private static readonly byte[,] SubMatrix09 = new byte[7, 2]
		{
			{ 0, 0 },
			{ 0, 0 },
			{ 0, 0 },
			{ 0, 0 },
			{ 0, 1 },
			{ 0, 1 },
			{ 1, 1 }
		};

		private static readonly byte[,] SubMatrix10 = new byte[2, 6]
		{
			{ 1, 0, 0, 0, 0, 0 },
			{ 1, 1, 1, 1, 1, 1 }
		};

		private readonly HashSet<Vec3Int> slopeLocations = new HashSet<Vec3Int>();

		private VillageMap villageMap;

		public void PlaceSlopes(VillageMap villageMap, Vec3Int mapSize)
		{
			this.villageMap = villageMap;
			slopeLocations.Clear();
			int chunkSize = MonoSingleton<World>.Instance.ChunkGenerator.ChunkSize;
			byte[,,] array = new byte[chunkSize, mapSize.y, chunkSize];
			for (int i = 0; i < mapSize.x; i += chunkSize)
			{
				for (int j = 0; j < mapSize.z; j += chunkSize)
				{
					for (int k = 0; k < chunkSize; k++)
					{
						for (int l = 0; l < mapSize.y; l++)
						{
							for (int m = 0; m < chunkSize; m++)
							{
								array[k, l, m] = GetChunkByteData(k + i, l, m + j);
							}
						}
					}
					for (int n = 1; n < mapSize.y - 1; n++)
					{
						PlaceSlopesOnLayer(array, n, new Vector2Int(i, j));
					}
				}
			}
		}

		private byte GetChunkByteData(int x, int y, int z)
		{
			MapNode node = villageMap.GetNode(x, y, z);
			if (node == null || node.IsVoxelAir())
			{
				return 0;
			}
			if (node.CheckIsDataType(GridDataType.Slope))
			{
				return 2;
			}
			return 1;
		}

		private bool UpdateGridSlope(int x, int y, int z, PooledList<Vec3Int> slopePositions)
		{
			if (villageMap.GetNode(x, y, z) == null)
			{
				return false;
			}
			slopePositions.Add(new Vec3Int(x, y, z));
			return true;
		}

		private void PlaceSlopesOnLayer(byte[,,] mapData, int y, Vector2Int chunkPosition)
		{
			PlaceSlope(mapData, y, chunkPosition, SubMatrix01, "slope", new Vec3Int(3, 0, -1), "SubMatrix01", -90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix02, "slope", new Vec3Int(2, 0, 0), "SubMatrix02", 90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix03, "slope", new Vec3Int(2, 0, 1), "SubMatrix03", 90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix04, "slope", new Vec3Int(3, 0, 0), "SubMatrix04", -90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix05, "slope", new Vec3Int(1, 0, 3), "SubMatrix05", 180f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix06, "slope", new Vec3Int(0, 0, 2), "SubMatrix06");
			PlaceSlope(mapData, y, chunkPosition, SubMatrix07, "slope", new Vec3Int(2, 0, 1), "SubMatrix07", 90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix08, "slope", new Vec3Int(6, 0, 0), "SubMatrix08", -90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix09, "slope", new Vec3Int(2, 0, 0), "SubMatrix09", 90f);
			PlaceSlope(mapData, y, chunkPosition, SubMatrix10, "slope", new Vec3Int(0, 0, 3), "SubMatrix10", 180f);
		}

		private void PlaceSlope(byte[,,] mapData, int y, Vector2Int chunkPosition, byte[,] subMatrix, string slopeID, Vec3Int offset, string name, float angle = 0f)
		{
			if (!SubMatrix(mapData, subMatrix, y, in chunkPosition, out var position) || TooClose((Vector3)position))
			{
				return;
			}
			position += offset;
			position = new Vec3Int(position.x, y * World.MapBlockHeight, position.z);
			int num = (((int)angle < 0) ? ((int)angle + 360) : ((int)angle));
			int length = Repository<SlopeRepository, Slope>.Instance.GetByID(slopeID).Length;
			bool flag = true;
			PooledList<Vec3Int> janitor = ListPool<Vec3Int>.GetJanitor();
			try
			{
				switch (num)
				{
				case 0:
				{
					for (int j = position.z; j < position.z + length; j++)
					{
						flag &= UpdateGridSlope(position.x + 1, y, j + 1, janitor);
						if (!flag)
						{
							break;
						}
					}
					break;
				}
				case 90:
				{
					for (int i = position.x; i < position.x + length; i++)
					{
						flag &= UpdateGridSlope(i + 1, y, position.z, janitor);
						if (!flag)
						{
							break;
						}
					}
					break;
				}
				case 180:
				{
					for (int num3 = position.z; num3 > position.z - length; num3--)
					{
						flag &= UpdateGridSlope(position.x, y, num3, janitor);
						if (!flag)
						{
							break;
						}
					}
					break;
				}
				case 270:
				{
					for (int num2 = position.x; num2 > position.x - length; num2--)
					{
						flag &= UpdateGridSlope(num2, y, position.z + 1, janitor);
						if (!flag)
						{
							break;
						}
					}
					break;
				}
				}
				if (!flag || y <= 0)
				{
					return;
				}
				foreach (Vec3Int item in janitor)
				{
					Vec3Int a = item;
					Vec3Int vec3Int = a + Vec3Int.down;
					MapNode node = villageMap.GetNode(vec3Int.x, vec3Int.y, vec3Int.z);
					if (node == null || node.IsVoxelAir())
					{
						return;
					}
					Vec3Int vec3Int2 = a + Vec3Int.up;
					node = villageMap.GetNode(vec3Int2.x, vec3Int2.y, vec3Int2.z);
					if (node != null && !node.IsVoxelAir())
					{
						return;
					}
				}
				Vector3 worldPosition = janitor[janitor.Count - 1].ToVector3World();
				SlopeInstance slope = new SlopeInstance(Repository<SlopeRepository, Slope>.Instance.GetByID("slope"), worldPosition, janitor, num, name);
				MonoSingleton<SlopeManager>.Instance.SpawnSlopeInstance(slope);
			}
			finally
			{
				((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private bool SubMatrix(byte[,,] data, byte[,] subMatrix, int y, in Vector2Int chunkOffset, out Vec3Int position)
		{
			int length = data.GetLength(0);
			int length2 = data.GetLength(2);
			int length3 = subMatrix.GetLength(0);
			int length4 = subMatrix.GetLength(1);
			for (int i = 0; i < length - length3 + 1; i++)
			{
				for (int j = 0; j < length2 - length4 + 1; j++)
				{
					bool flag = true;
					for (int k = 0; k < length3; k++)
					{
						for (int l = 0; l < length4; l++)
						{
							if (data[i + k, y, j + l] != subMatrix[k, l])
							{
								flag = false;
								break;
							}
						}
					}
					if (!flag)
					{
						continue;
					}
					position = new Vec3Int(i, y, j);
					if (data[(byte)position.x, (byte)position.y - 1, (byte)position.z] == 0 || data[(byte)position.x, (byte)position.y + 1, (byte)position.z] == 1)
					{
						continue;
					}
					position += new Vec3Int(chunkOffset.x, 0, chunkOffset.y);
					if (!slopeLocations.Contains(position))
					{
						if (!slopeLocations.Contains(position))
						{
							slopeLocations.Add(position);
						}
						return true;
					}
				}
			}
			position = Vec3Int.zero;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool TooClose(Vector3 position)
		{
			foreach (Vec3Int slopeLocation in slopeLocations)
			{
				Vector3 vector = (Vector3)slopeLocation;
				if (!(Math.Abs(vector.y - position.y) > 0.001f) && !(vector == position) && Vector3.Distance(vector, position) < 10f)
				{
					return true;
				}
			}
			return false;
		}
	}
}
