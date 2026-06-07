using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	public static class Utils
	{
		public static class Profiler
		{
			[Conditional("DIGGER_PROFILING")]
			public static void BeginSample(string name)
			{
			}

			[Conditional("DIGGER_PROFILING")]
			public static void EndSample()
			{
			}
		}

		public static class D
		{
			[Conditional("DIGGER_DEBUGGING")]
			public static void Log(string message)
			{
				UnityEngine.Debug.Log(message);
			}
		}

		public static float3 VoxelToUnityPosition(int3 voxelPosition, float3 heightmapScale)
		{
			return voxelPosition * heightmapScale;
		}

		public static float3 ChunkVoxelToUnityPosition(int3 chunkPosition, int3 voxelPosition, float3 heightmapScale)
		{
			return chunkPosition * heightmapScale + voxelPosition * heightmapScale;
		}

		public static int3 UnityToVoxelPosition(float3 position, float3 heightmapScale)
		{
			return new int3(position / heightmapScale);
		}

		public static int3 IndexToXYZ(int index, int sizeVox, int sizeVox2)
		{
			int num = index / sizeVox2;
			int num2 = (index - num * sizeVox2) / sizeVox;
			int z = index - num * sizeVox2 - num2 * sizeVox;
			return new int3(num, num2, z);
		}

		public static int3 IndexToWorldXYZ(int index, int sizeVox, int sizeVox2, int3 chunkVoxelPosition)
		{
			return IndexToXYZ(index, sizeVox, sizeVox2) + chunkVoxelPosition;
		}

		public static int XYZToHeightIndex(int3 pi, int sizeVox)
		{
			return (pi.x + 1) * (sizeVox + 2) + pi.z + 1;
		}

		public static int XZToNormalIndex(int px, int pz, int sizeVox)
		{
			return (px + 1) * (sizeVox + 2) + pz + 1;
		}

		public static int XZToHoleIndex(int px, int pz, int sizeVox)
		{
			return px * sizeVox + pz;
		}

		public static int3 HoleIndexToXZ(int index, int sizeVox)
		{
			return new int3(index / sizeVox, 0, index % sizeVox);
		}

		public static bool IsOnSurface(int3 pi, float voxelHeight, float voxelAltitude, int sizeVox, NativeArray<float> heights)
		{
			float num = float.PositiveInfinity;
			float num2 = float.NegativeInfinity;
			int num3 = math.max(-1, pi.x - 1);
			int num4 = math.min(sizeVox, pi.x + 1);
			int num5 = math.max(-1, pi.z - 1);
			int num6 = math.min(sizeVox, pi.z + 1);
			for (int i = num3; i <= num4; i++)
			{
				for (int j = num5; j <= num6; j++)
				{
					float num7 = heights[XYZToHeightIndex(new int3(i, 0, j), sizeVox)];
					if (math.abs(voxelAltitude - num7) <= voxelHeight)
					{
						return true;
					}
					num = math.min(num, num7);
					num2 = math.max(num2, num7);
				}
			}
			if (voxelAltitude >= num - voxelHeight)
			{
				return voxelAltitude <= num2 + voxelHeight;
			}
			return false;
		}

		public static bool IsOnHole(int3 pi, int sizeVox, NativeArray<int> holes)
		{
			if (holes[XYZToHoleIndex(pi + new int3(-1, 0, -1), sizeVox)] == 0 && holes[XYZToHoleIndex(pi + new int3(-1, 0, 0), sizeVox)] == 0 && holes[XYZToHoleIndex(pi + new int3(0, 0, -1), sizeVox)] == 0)
			{
				return holes[XYZToHoleIndex(pi + new int3(0, 0, 0), sizeVox)] != 0;
			}
			return true;
		}

		private static int XYZToHoleIndex(int3 pi, int sizeVox)
		{
			return math.clamp(pi.x, 0, sizeVox - 1) * sizeVox + math.clamp(pi.z, 0, sizeVox - 1);
		}

		public static Voxel AdjustAlteration(Voxel voxel, int3 pi, float voxelHeight, float voxelAltitude, float terrainHeightValue, int sizeVox, NativeArray<float> heights)
		{
			uint alteration = voxel.Alteration;
			if (alteration == 0 || alteration == 6)
			{
				return voxel;
			}
			if (voxel.IsAlteredFarSurface && IsOnSurface(pi, voxelHeight, voxelAltitude, sizeVox, heights))
			{
				voxel.Alteration = 3u;
			}
			if (voxel.Value > terrainHeightValue)
			{
				switch (voxel.Alteration)
				{
				case 5u:
					voxel.Alteration = 4u;
					break;
				case 3u:
					voxel.Alteration = 2u;
					break;
				}
			}
			else
			{
				switch (voxel.Alteration)
				{
				case 4u:
					voxel.Alteration = 5u;
					break;
				case 2u:
					voxel.Alteration = 3u;
					break;
				}
			}
			return voxel;
		}

		public static bool Approximately(Color a, Color b)
		{
			if (math.abs(a.r - b.r) < 1E-05f && math.abs(a.g - b.g) < 1E-05f && math.abs(a.b - b.b) < 1E-05f)
			{
				return math.abs(a.a - b.a) < 1E-05f;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximately(float3 a, float3 b)
		{
			return Approximately(a, b, 1E-05f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximately(float a, float b)
		{
			return Approximately(a, b, 1E-05f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximately(float3 a, float3 b, float epsilon)
		{
			float3 float5 = math.abs(a - b);
			if (float5.x < epsilon && float5.y < epsilon)
			{
				return float5.z < epsilon;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximately(float a, float b, float epsilon)
		{
			return math.abs(a - b) < epsilon;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AreColinear(float3 a, float3 b, float3 c)
		{
			return Approximately(math.cross(b - a, c - a), float3.zero);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BilinearInterpolate(float f00, float f01, float f10, float f11, float x, float y)
		{
			float num = 1f - x;
			float num2 = 1f - y;
			return num * (num2 * f00 + y * f01) + x * (num2 * f10 + y * f11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 BilinearInterpolate(float3 f00, float3 f01, float3 f10, float3 f11, float x, float y)
		{
			float num = 1f - x;
			float num2 = 1f - y;
			return num * (num2 * f00 + y * f01) + x * (num2 * f10 + y * f11);
		}

		public static Vector3 TriangleInterpolate(int2 a, int2 b, int2 c, int2 p)
		{
			int num = (b.y - c.y) * (a.x - c.x) + (c.x - b.x) * (a.y - c.y);
			if (num == 0)
			{
				return -Vector3.one;
			}
			double num2 = num;
			double num3 = (double)((b.y - c.y) * (p.x - c.x) + (c.x - b.x) * (p.y - c.y)) / num2;
			double num4 = (double)((c.y - a.y) * (p.x - c.x) + (a.x - c.x) * (p.y - c.y)) / num2;
			double num5 = 1.0 - num3 - num4;
			return new Vector3((float)num3, (float)num4, (float)num5);
		}

		public static int2 Min(int2 a, int2 b, int2 c)
		{
			return math.min(a, math.min(b, c));
		}

		public static int2 Max(int2 a, int2 b, int2 c)
		{
			return math.max(a, math.max(b, c));
		}

		public static T[] ToArray<T>(NativeArray<T> src, int length) where T : struct
		{
			T[] array = new T[length];
			NativeArray<T>.Copy(src, array, length);
			return array;
		}

		public static byte[] GetBytes(string path)
		{
			if (!File.Exists(path))
			{
				return null;
			}
			return File.ReadAllBytes(path);
		}
	}
}
