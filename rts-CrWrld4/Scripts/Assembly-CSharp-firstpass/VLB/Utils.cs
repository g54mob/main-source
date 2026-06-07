using System;
using UnityEngine;

namespace VLB
{
	public static class Utils
	{
		public enum FloatPackingPrecision
		{
			High = 64,
			Low = 8,
			Undef = 0
		}

		private static FloatPackingPrecision ms_FloatPackingPrecision;

		private const int kFloatPackingHighMinShaderLevel = 35;

		public static string GetPath(Transform current)
		{
			return null;
		}

		public static T NewWithComponent<T>(string name) where T : Component
		{
			return null;
		}

		public static T GetOrAddComponent<T>(this GameObject self) where T : Component
		{
			return null;
		}

		public static T GetOrAddComponent<T>(this MonoBehaviour self) where T : Component
		{
			return null;
		}

		public static bool HasFlag(this Enum mask, Enum flags)
		{
			return false;
		}

		public static Vector2 xy(this Vector3 aVector)
		{
			return default(Vector2);
		}

		public static Vector2 xz(this Vector3 aVector)
		{
			return default(Vector2);
		}

		public static Vector2 yz(this Vector3 aVector)
		{
			return default(Vector2);
		}

		public static Vector2 yx(this Vector3 aVector)
		{
			return default(Vector2);
		}

		public static Vector2 zx(this Vector3 aVector)
		{
			return default(Vector2);
		}

		public static Vector2 zy(this Vector3 aVector)
		{
			return default(Vector2);
		}

		public static float GetVolumeCubic(this Bounds self)
		{
			return 0f;
		}

		public static float GetMaxArea2D(this Bounds self)
		{
			return 0f;
		}

		public static Color Opaque(this Color self)
		{
			return default(Color);
		}

		public static void GizmosDrawPlane(Vector3 normal, Vector3 position, Color color, float size = 1f)
		{
		}

		public static Plane TranslateCustom(this Plane plane, Vector3 translation)
		{
			return default(Plane);
		}

		public static bool IsValid(this Plane plane)
		{
			return false;
		}

		public static Matrix4x4 SampleInMatrix(this Gradient self, int floatPackingPrecision)
		{
			return default(Matrix4x4);
		}

		public static Color[] SampleInArray(this Gradient self, int samplesCount)
		{
			return null;
		}

		private static Vector4 Vector4_Floor(Vector4 vec)
		{
			return default(Vector4);
		}

		public static float PackToFloat(this Color color, int floatPackingPrecision)
		{
			return 0f;
		}

		public static FloatPackingPrecision GetFloatPackingPrecision()
		{
			return default(FloatPackingPrecision);
		}

		public static void MarkCurrentSceneDirty()
		{
		}
	}
}
