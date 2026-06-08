using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Rhizomatic.Utility
{
	public static class Extensions
	{
		private static char[] english;

		private static char[] farsi;

		public static Vector3 NormalizeEulerAngles(this Vector3 eulerAngles)
		{
			return default(Vector3);
		}

		public static string[] ToStrings(this IEnumerable enumerable)
		{
			return null;
		}

		public static Texture2D ToTexture2D(this RenderTexture rTex)
		{
			return null;
		}

		public static T DeepCopy<T>(this T other)
		{
			return default(T);
		}

		public static byte[] BinaryFormatterSerialize(this object serializableObject)
		{
			return null;
		}

		public static T BinaryFormatterDeserialize<T>(this byte[] serializedBytes)
		{
			return default(T);
		}

		public static void ShowExplorer(this string path)
		{
		}

		public static bool Validate(this GameObject obj, Filter filter)
		{
			return false;
		}

		public static bool Validate(this GameObject obj, int layer, string[] tags)
		{
			return false;
		}

		public static bool Validate(this GameObject obj, string[] tags)
		{
			return false;
		}

		public static bool Validate(this GameObject obj, int layer)
		{
			return false;
		}

		public static float Average(this float[] numbers)
		{
			return 0f;
		}

		public static float Map(this float value, float min, float max, float newMin = 0f, float newMax = 1f)
		{
			return 0f;
		}

		public static float MoveValue(this float value, float target, float speed, float smooth)
		{
			return 0f;
		}

		public static Vector3 MoveValue(this Vector3 value, Vector3 target, float speed, float smooth)
		{
			return default(Vector3);
		}

		public static Vector2 MoveValue(this Vector2 value, Vector2 target, float speed, float smooth)
		{
			return default(Vector2);
		}

		public static Quaternion MoveValue(this Quaternion value, Quaternion target, float speed, float smooth)
		{
			return default(Quaternion);
		}

		public static T Random<T>(this T[] array)
		{
			return default(T);
		}

		public static T Random<T>(this List<T> list)
		{
			return default(T);
		}

		public static void ApplyDirectionDrag(this Rigidbody2D rigidbody, Vector2 direction, float velocityMultiplier)
		{
		}

		public static Vector2 Rotate(this Vector2 v, float delta)
		{
			return default(Vector2);
		}

		public static float Round(this float number, float round = 10f)
		{
			return 0f;
		}

		public static string f(this string str, params object[] args)
		{
			return null;
		}

		public static string FaNum(this string str)
		{
			return null;
		}

		public static string EnNum(this string str)
		{
			return null;
		}

		public static Vector3 RandomVector(this float value)
		{
			return default(Vector3);
		}

		public static Vector3 RandomVector2D(this float value)
		{
			return default(Vector3);
		}

		public static T FromJson<T>(this string json, T fallback = default(T))
		{
			return default(T);
		}

		public static string ToJson(this object obj, Formatting formatting = Formatting.None)
		{
			return null;
		}

		public static T JsonCopy<T>(this T obj)
		{
			return default(T);
		}

		public static Color FromHtml(this string hex, float alpha = 1f)
		{
			return default(Color);
		}

		public static string ToHtml(this Color color)
		{
			return null;
		}

		public static string ToHtmlAlpha(this Color color)
		{
			return null;
		}

		public static string Beautify(this string json)
		{
			return null;
		}

		public static float Random(this Vector2 vector)
		{
			return 0f;
		}

		public static int Random(this Vector2Int vector)
		{
			return 0;
		}

		public static float Lerp(this Vector2 vector, float t)
		{
			return 0f;
		}

		public static T[] Shuffle<T>(this T[] arr)
		{
			return null;
		}

		public static List<T> Shuffle<T>(this List<T> arr)
		{
			return null;
		}

		public static T[] ShuffleInPlace<T>(this T[] arr)
		{
			return null;
		}

		public static T Clamp<T>(this T[] arr, int index)
		{
			return default(T);
		}

		public static DateTime UTCToDateTime(this string text)
		{
			return default(DateTime);
		}

		public static TimeSpan FromMillisecondsToTimeSpan(this double milliseconds)
		{
			return default(TimeSpan);
		}

		public static void AddContains<T>(this List<T> list, T item)
		{
		}
	}
}
