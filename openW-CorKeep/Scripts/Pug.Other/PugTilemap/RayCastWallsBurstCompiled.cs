using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

namespace PugTilemap
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct RayCastWallsBurstCompiled
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool RaycastWalls_00006CA2_0024PostfixBurstDelegate(in SinglePugMap.TileLayerLookup tileLookup, in float2 worldPosition, in float2 direction, float maxDist, out TileHitInfo hitInfo);

		internal static class RaycastWalls_00006CA2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RaycastWalls_00006CA2_0024PostfixBurstDelegate>(RaycastWalls).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static bool Invoke(in SinglePugMap.TileLayerLookup tileLookup, in float2 worldPosition, in float2 direction, float maxDist, out TileHitInfo hitInfo)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref SinglePugMap.TileLayerLookup, ref float2, ref float2, float, ref TileHitInfo, bool>)functionPointer)(ref tileLookup, ref worldPosition, ref direction, maxDist, ref hitInfo);
					}
				}
				return RaycastWalls_0024BurstManaged(in tileLookup, in worldPosition, in direction, maxDist, out hitInfo);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(PugTilemap_002ERaycastWalls_00006CA2_0024PostfixBurstDelegate))]
		public static bool RaycastWalls(in SinglePugMap.TileLayerLookup tileLookup, in float2 worldPosition, in float2 direction, float maxDist, out TileHitInfo hitInfo)
		{
			return RaycastWalls_00006CA2_0024BurstDirectCall.Invoke(in tileLookup, in worldPosition, in direction, maxDist, out hitInfo);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static bool RaycastWalls_0024BurstManaged(in SinglePugMap.TileLayerLookup tileLookup, in float2 worldPosition, in float2 direction, float maxDist, out TileHitInfo hitInfo)
		{
			hitInfo = default(TileHitInfo);
			if (maxDist > 999f)
			{
				Debug.LogError("Raycast max distance was too long!");
				return false;
			}
			float num = math.length(direction);
			if (num < 1.1920929E-07f)
			{
				Debug.LogError("Raycast direction was zero!");
				return false;
			}
			float2 float5 = direction / num;
			float2 x = worldPosition + 0.5f;
			int2 int5 = (int2)math.floor(x);
			float2 float6 = math.frac(x);
			int2 int6 = (int2)math.sign(float5);
			float2 float7 = 1f / math.abs(float5);
			float2 float8 = new float2((int6.x > 0) ? (1f - float6.x) : float6.x, (int6.y > 0) ? (1f - float6.y) : float6.y) * float7;
			float num2 = 0f;
			hitInfo.distance = -1f;
			int num3 = 0;
			while (num2 < maxDist)
			{
				if (tileLookup.GetTopTile(int5).tileType.IsWallTile())
				{
					hitInfo.distance = num2;
					hitInfo.point = worldPosition + float5 * num2;
					hitInfo.tile = int5;
					break;
				}
				if (num3 > 999)
				{
					Debug.LogError("Reached max iteration count!");
					break;
				}
				if (float8.x < float8.y)
				{
					int5.x += int6.x;
					num2 = float8.x;
					float8.x += float7.x;
				}
				else
				{
					int5.y += int6.y;
					num2 = float8.y;
					float8.y += float7.y;
				}
				if (num2 > maxDist)
				{
					break;
				}
			}
			return hitInfo.distance >= 0f;
		}
	}
}
