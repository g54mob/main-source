using Unity.Mathematics;
using UnityEngine;

namespace Os.Hex
{
	public static class HexMath
	{
		public static readonly float hexAxisLength;

		public static readonly float2 hexAxisX;

		public static readonly float2 hexAxisY;

		public static readonly float2 hexAxisZ;

		public static readonly Matrix4x4 hexToPlane;

		public static readonly Matrix4x4 hexToWorld;

		public static readonly Matrix4x4 planeToWorld;

		public static readonly float2 skewAxisX;

		public static readonly float2 skewAxisY;

		public static readonly Matrix4x4 skewToPlane;

		public static readonly Matrix4x4 planeToSkew;

		public static readonly Matrix4x4 hexToSkew;

		public static readonly Matrix4x4 skewToHex;

		public static int3 GetHex3(this int2 hex2)
		{
			return default(int3);
		}

		public static float3 GetHex3(this float2 hex2)
		{
			return default(float3);
		}

		public static int2 GetHex2(this int3 hexPos)
		{
			return default(int2);
		}

		public static float2 GetHex2(this float3 hexPos)
		{
			return default(float2);
		}

		public static float2 HexToPlane(float3 hexPos)
		{
			return default(float2);
		}

		public static float2 HexToPlane(float2 hexPos)
		{
			return default(float2);
		}

		public static float3 PlaneToHex(float2 planePos)
		{
			return default(float3);
		}

		public static float3 PlaneToWorld(float2 planePos, float y = 0f)
		{
			return default(float3);
		}

		public static float2 WorldToPlane(float3 worldPos)
		{
			return default(float2);
		}

		public static float3 RotateCW(float3 hexPos)
		{
			return default(float3);
		}

		public static float3 RotateCCW(float3 hexPos)
		{
			return default(float3);
		}

		public static int2 RotateCW(int2 hexPos)
		{
			return default(int2);
		}

		public static int3 RotateCW(int3 hexPos)
		{
			return default(int3);
		}

		public static int2 RotateCCW(int2 hexPos)
		{
			return default(int2);
		}

		public static int3 RotateCCW(int3 hexPos)
		{
			return default(int3);
		}

		public static int2 RotateCW2(int2 hexPos)
		{
			return default(int2);
		}

		public static int2 RotateCCW2(int2 hexPos)
		{
			return default(int2);
		}

		public static int3 HexRound(float3 hexPos)
		{
			return default(int3);
		}

		public static int3 HexRoundX(float3 hexPos)
		{
			return default(int3);
		}

		public static float3 HexClamp(float3 hexPos, float3 min, float3 max)
		{
			return default(float3);
		}
	}
}
