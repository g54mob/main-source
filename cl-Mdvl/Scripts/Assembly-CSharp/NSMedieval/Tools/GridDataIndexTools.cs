using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Map;
using Unity.Burst;
using UnityEngine;

namespace NSMedieval.Tools
{
	public static class GridDataIndexTools
	{
		public const int EdgeVoxelsForbidden = 16;

		private static int sizeXCache;

		private static int sizeYCache;

		private static int sizeZCache;

		private static int sizeXCacheWithEdgeFrame;

		private static int sizeZCacheWithEdgeFrame;

		private static int maxDataLength = 1;

		public static int MaxDataLength => maxDataLength;

		public static int SizeX => sizeXCache;

		public static int SizeY => sizeYCache;

		public static int SizeZ => sizeZCache;

		public static void CheckSetMaxDataLength(int x, int y, int z)
		{
			int num = x * y * z;
			if (num > maxDataLength)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(61, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\GridDataIndexTools.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Setting maxDataLength ");
					messageBuilder.AppendFormatted(x);
					messageBuilder.AppendLiteral(" * ");
					messageBuilder.AppendFormatted(y);
					messageBuilder.AppendLiteral(" * ");
					messageBuilder.AppendFormatted(z);
					messageBuilder.AppendLiteral(" - this will reset static arrays.");
				}
				Log.Info(messageBuilder);
				maxDataLength = num;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			sizeXCache = 0;
			sizeYCache = 0;
			sizeZCache = 0;
			maxDataLength = 1;
			sizeXCacheWithEdgeFrame = 0;
			sizeZCacheWithEdgeFrame = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int GetX(int index)
		{
			return index % sizeXCache;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int GetY(int index)
		{
			return index / sizeXCache % sizeYCache;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int GetZ(int index)
		{
			return index / (sizeXCache * sizeYCache);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int FastTo1DIndex(int x, int y, int z)
		{
			if (x < 0 || x >= sizeXCache || y < 0 || y >= sizeYCache || z < 0 || z >= sizeZCache)
			{
				return -1;
			}
			return x + y * sizeXCache + z * sizeXCache * sizeYCache;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int FastTo1DIndex(Vec3Int gridPosition)
		{
			return FastTo1DIndex(gridPosition.x, gridPosition.y, gridPosition.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static Vec3Int FastTo3DIndex(int index)
		{
			FastTo3DIndex(index, out var x, out var y, out var z);
			return new Vec3Int(x, y, z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static Vec3Int To3DIndex(int index, in Vec3Int mapSize)
		{
			To3DIndex(index, in mapSize, out var x, out var y, out var z);
			return new Vec3Int(x, y, z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void FastTo3DIndex(int index, out int x, out int y, out int z)
		{
			x = index % sizeXCache;
			y = index / sizeXCache % sizeYCache;
			z = index / (sizeXCache * sizeYCache);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void To3DIndex(int index, in Vec3Int mapSize, out int x, out int y, out int z)
		{
			x = index % mapSize.x;
			y = index / mapSize.x % mapSize.y;
			z = index / (mapSize.x * mapSize.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int FastTo1DIndexNoCheck(Vec3Int pos)
		{
			return pos.x + pos.y * sizeXCache + pos.z * sizeXCache * sizeYCache;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int FastTo1DIndexNoCheck(int x, int y, int z)
		{
			return x + y * sizeXCache + z * sizeXCache * sizeYCache;
		}

		public static void InitialiseFastMethods(int x, int y, int z)
		{
			sizeXCache = x;
			sizeYCache = y;
			sizeZCache = z;
			sizeXCacheWithEdgeFrame = x + 160;
			sizeZCacheWithEdgeFrame = z + 160;
			CheckSetMaxDataLength(x, y, z);
		}

		public static bool IsTopLayer(int y)
		{
			return y >= sizeYCache;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool InRangeX(int x)
		{
			if (x >= 0)
			{
				return x < sizeXCache;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool InRangeY(int y)
		{
			if (y >= 0)
			{
				return y < sizeYCache;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool InRangeZ(int z)
		{
			if (z >= 0)
			{
				return z < sizeZCache;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool InRange(int x, int y, int z)
		{
			if (x >= 0 && y >= 0 && z >= 0 && x < sizeXCache && y < sizeYCache)
			{
				return z < sizeZCache;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool InRange(Vec3Int pos)
		{
			int x = pos.x;
			int y = pos.y;
			int z = pos.z;
			if (x >= 0 && y >= 0 && z >= 0 && x < sizeXCache && y < sizeYCache)
			{
				return z < sizeZCache;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool InRangeXZ(int x, int z)
		{
			if (x >= 0 && z >= 0 && x < sizeXCache)
			{
				return z < sizeZCache;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int Get2dIndexXZ(int x, int z)
		{
			return x + z * sizeXCache;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int Get2dIndexXZEdgeFrame(int x, int z)
		{
			return x + z * sizeXCacheWithEdgeFrame;
		}

		public static bool IsForbiddenEdge(int x, int z)
		{
			if (GlobalSaveController.CurrentVillageData.IsSecondMap || World.AllowEdgePlacement)
			{
				return false;
			}
			if (x >= 16 && z >= 16 && x < sizeXCache - 16)
			{
				return z >= sizeZCache - 16;
			}
			return true;
		}

		public static bool IsForbiddenEdge(Vec3Int position)
		{
			if (GlobalSaveController.CurrentVillageData.IsSecondMap || World.AllowEdgePlacement)
			{
				return false;
			}
			int x = position.x;
			int z = position.z;
			if (x >= 16 && z >= 16 && x < sizeXCache - 16)
			{
				return z >= sizeZCache - 16;
			}
			return true;
		}
	}
}
