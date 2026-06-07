using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Os.Utils
{
	public static class ExtraMath
	{
		public const float third = 1f / 3f;

		public static readonly float toneScale;

		public const float invMaxByte = 0.003921569f;

		public static void Swap<T>(ref T a, ref T b)
		{
		}

		public static void Swap<T>(ref T a, ref T b, ref T c)
		{
		}

		public static void Swap<T>(ref T a, ref T b, ref T c, ref T d)
		{
		}

		public static float2 Rotate2D90(this float2 vector)
		{
			return default(float2);
		}

		public static float2 Rotate2D180(this float2 vector)
		{
			return default(float2);
		}

		public static float2 Rotate2D270(this float2 vector)
		{
			return default(float2);
		}

		public static Vector2 Rotate2D90(this Vector2 vector)
		{
			return default(Vector2);
		}

		public static float2 Rotate2D(float2 vector, float degrees)
		{
			return default(float2);
		}

		public static Vector3 Rotate90Y(this Vector3 vector)
		{
			return default(Vector3);
		}

		public static float2 GetRotate2DFactors(float radians)
		{
			return default(float2);
		}

		public static float2 ApplyRotate2DFactors(float2 vector, float2 factors)
		{
			return default(float2);
		}

		public static Vector3 XZtoXYZ(Vector2 xz, float y = 0f)
		{
			return default(Vector3);
		}

		public static float3 XZtoXYZ(float2 xz, float y = 0f)
		{
			return default(float3);
		}

		public static Vector3 GetXYZfromXZ(this Vector2 xz, float y = 0f)
		{
			return default(Vector3);
		}

		public static float3 GetXYZfromXZ(this float2 xz, float y = 0f)
		{
			return default(float3);
		}

		public static float4 GetXYZWfromXZ(this float2 xz, float y = 0f, float w = 0f)
		{
			return default(float4);
		}

		public static float4 SetW(this float3 xyz, float w = 0f)
		{
			return default(float4);
		}

		public static float3 SetX(this float3 vector, float x = 0f)
		{
			return default(float3);
		}

		public static float3 SetY(this float3 vector, float y = 0f)
		{
			return default(float3);
		}

		public static float3 SetZ(this float3 vector, float z = 0f)
		{
			return default(float3);
		}

		public static Vector3 SetX(this Vector3 vector, float x = 0f)
		{
			return default(Vector3);
		}

		public static Vector3 SetY(this Vector3 vector, float y = 0f)
		{
			return default(Vector3);
		}

		public static Vector3 SetZ(this Vector3 vector, float z = 0f)
		{
			return default(Vector3);
		}

		public static Vector4 SetW(this Vector3 vector, float w = 0f)
		{
			return default(Vector4);
		}

		public static Color SetA(this Color color, float a = 0f)
		{
			return default(Color);
		}

		public static Vector2 SetX(this Vector2 vector, float x = 0f)
		{
			return default(Vector2);
		}

		public static Vector2 SetY(this Vector2 vector, float y = 0f)
		{
			return default(Vector2);
		}

		public static float2 GetXZ(this float3 xyz)
		{
			return default(float2);
		}

		public static Vector2 GetXZ(this Vector3 xyz)
		{
			return default(Vector2);
		}

		public static Vector3 GetClampedMagnitude(this Vector3 vector, float maxMagnitude)
		{
			return default(Vector3);
		}

		public static Vector3 GetClampedMagnitudeOne(this Vector3 vector)
		{
			return default(Vector3);
		}

		public static Vector2 Clamp01(Vector2 vector)
		{
			return default(Vector2);
		}

		public static float Pow2(this float x)
		{
			return 0f;
		}

		public static int Pow2(this int x)
		{
			return 0;
		}

		public static bool OnEdge(this int3x2 bounds, int3 pos)
		{
			return false;
		}

		public static bool Contains(this int3x2 bounds, int3 pos)
		{
			return false;
		}

		public static bool Contains(this int3x2 bounds, float3 pos)
		{
			return false;
		}

		public static bool Contains(this int3x2 bounds0, int3x2 bounds1)
		{
			return false;
		}

		public static bool Intersects(this int3x2 bounds0, int3x2 bounds1)
		{
			return false;
		}

		public static int3x2 Encapsulate(this int3x2 bounds, int3 hexPos3)
		{
			return default(int3x2);
		}

		public static int3x2 Encapsulate(this int3x2 bounds0, int3x2 bounds1)
		{
			return default(int3x2);
		}

		public static Vector2 Encapsulate(this Vector2 minMax, float value)
		{
			return default(Vector2);
		}

		public static int3 ClosestPoint(this int3x2 bounds0, int3 pos)
		{
			return default(int3);
		}

		public static int3 Center(this int3x2 bounds0)
		{
			return default(int3);
		}

		public static int Pow(int x, uint pow)
		{
			return 0;
		}

		public static float InverseLerpUnclamped(float min, float max, float value)
		{
			return 0f;
		}

		public static Vector3 GetBarycentric(Vector3 point, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPointOnTriangle(Vector3 point, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			return default(Vector3);
		}

		public static float Cross2(in Vector2 v0, in Vector2 v1)
		{
			return 0f;
		}

		public static Vector2 InvBilinear(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p)
		{
			return default(Vector2);
		}

		public static int BinarySearch<T, Y>(this List<T> list, Y value) where T : IComparable<Y>
		{
			return 0;
		}

		public static int BinarySearchComponent<T, Y>(this Transform transform, Y item, int marginMin = 0, int marginMax = 0) where T : Component, IComparable<Y>
		{
			return 0;
		}

		public static int BinarySearchComponent<T>(this Transform transform, T item, int marginMin = 0, int marginMax = 0) where T : Component, IComparable<T>
		{
			return 0;
		}

		public static int BinarySearchTransformX(this Transform transform, float x, int marginMin = 0, int marginMax = 0)
		{
			return 0;
		}

		public static float ToneOffsetToPitch(float tone)
		{
			return 0f;
		}
	}
}
