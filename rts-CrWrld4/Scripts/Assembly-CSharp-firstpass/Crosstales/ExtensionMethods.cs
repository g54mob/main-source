using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Crosstales
{
	public static class ExtensionMethods
	{
		private static readonly Vector3 flat;

		public static string CTToTitleCase(this string str)
		{
			return null;
		}

		public static string CTReverse(this string str)
		{
			return null;
		}

		public static string CTReplace(this string str, string oldString, string newString, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return null;
		}

		public static bool CTEquals(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return false;
		}

		public static bool CTContains(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return false;
		}

		public static bool CTContainsAny(this string str, string searchTerms, char splitChar = ' ')
		{
			return false;
		}

		public static bool CTContainsAll(this string str, string searchTerms, char splitChar = ' ')
		{
			return false;
		}

		public static string CTRemoveNewLines(this string str, string replacement = "#nl#", string newLine = null)
		{
			return null;
		}

		public static string CTAddNewLines(this string str, string replacement = "#nl#", string newLine = null)
		{
			return null;
		}

		public static bool CTisNumeric(this string str)
		{
			return false;
		}

		public static bool CTisInteger(this string str)
		{
			return false;
		}

		public static bool CTisEmail(this string str)
		{
			return false;
		}

		public static bool CTisWebsite(this string str)
		{
			return false;
		}

		public static bool CTisCreditcard(this string str)
		{
			return false;
		}

		public static bool CTisIPv4(this string str)
		{
			return false;
		}

		public static bool CTisAlphanumeric(this string str)
		{
			return false;
		}

		public static bool CThasLineEndings(this string str)
		{
			return false;
		}

		public static bool CThasInvalidChars(this string str)
		{
			return false;
		}

		public static bool CTStartsWith(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return false;
		}

		public static bool CTEndsWith(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return false;
		}

		public static int CTLastIndexOf(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return 0;
		}

		public static int CTIndexOf(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return 0;
		}

		public static int CTIndexOf(this string str, string toCheck, int startIndex, StringComparison comp = StringComparison.OrdinalIgnoreCase)
		{
			return 0;
		}

		public static string CTToBase64(this string str)
		{
			return null;
		}

		public static string CTFromBase64(this string str)
		{
			return null;
		}

		public static string CTToHex(this string str, bool addPrefix = false)
		{
			return null;
		}

		public static string CTHexToString(this string hexString)
		{
			return null;
		}

		public static Color CTHexToColor(this string hexString)
		{
			return default(Color);
		}

		public static void CTShuffle<T>(this T[] array, int seed = 0)
		{
		}

		public static string CTDump<T>(this T[] array, string prefix = "", string postfix = "")
		{
			return null;
		}

		public static string CTDump(this Quaternion[] array)
		{
			return null;
		}

		public static string CTDump(this Vector2[] array)
		{
			return null;
		}

		public static string CTDump(this Vector3[] array)
		{
			return null;
		}

		public static string CTDump(this Vector4[] array)
		{
			return null;
		}

		public static string[] CTToString<T>(this T[] array)
		{
			return null;
		}

		public static float[] CTToFloatArray(this byte[] array, int count = 0)
		{
			return null;
		}

		public static byte[] CTToByteArray(this float[] array, int count = 0)
		{
			return null;
		}

		public static void CTShuffle<T>(this IList<T> list, int seed = 0)
		{
		}

		public static string CTDump<T>(this IList<T> list, string prefix = "", string postfix = "")
		{
			return null;
		}

		public static string CTDump(this IList<Quaternion> list)
		{
			return null;
		}

		public static string CTDump(this IList<Vector2> list)
		{
			return null;
		}

		public static string CTDump(this IList<Vector3> list)
		{
			return null;
		}

		public static string CTDump(this IList<Vector4> list)
		{
			return null;
		}

		public static List<string> CTToString<T>(this IList<T> list)
		{
			return null;
		}

		public static string CTDump<K, V>(this IDictionary<K, V> dict, string prefix = "", string postfix = "")
		{
			return null;
		}

		public static void CTAddRange<K, V>(this IDictionary<K, V> dict, IDictionary<K, V> collection)
		{
		}

		public static byte[] CTReadFully(this Stream input)
		{
			return null;
		}

		public static string CTToHex(this Color input)
		{
			return null;
		}

		public static Vector3 CTVector3(this Color color)
		{
			return default(Vector3);
		}

		public static Vector4 CTVector4(this Color color)
		{
			return default(Vector4);
		}

		public static Vector2 CTMultiply(this Vector2 a, Vector2 b)
		{
			return default(Vector2);
		}

		public static Vector3 CTMultiply(this Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}

		public static Vector3 CTFlatten(this Vector3 a)
		{
			return default(Vector3);
		}

		public static Quaternion CTQuaternion(this Vector3 eulerAngle)
		{
			return default(Quaternion);
		}

		public static Color CTColorRGB(this Vector3 rgb, float alpha = 1f)
		{
			return default(Color);
		}

		public static Vector4 CTMultiply(this Vector4 a, Vector4 b)
		{
			return default(Vector4);
		}

		public static Quaternion CTQuaternion(this Vector4 angle)
		{
			return default(Quaternion);
		}

		public static Color CTColorRGBA(this Vector4 rgba)
		{
			return default(Color);
		}

		public static Vector3 CTVector3(this Quaternion angle)
		{
			return default(Vector3);
		}

		public static Vector4 CTVector4(this Quaternion angle)
		{
			return default(Vector4);
		}

		public static Vector3 CTCorrectLossyScale(this Canvas canvas)
		{
			return default(Vector3);
		}

		public static void CTGetLocalCorners(this RectTransform rt, Vector3[] fourCornersArray, Canvas canvas, float inset)
		{
		}

		public static void CTGetScreenCorners(this RectTransform rt, Vector3[] fourCornersArray, Canvas canvas, float inset)
		{
		}

		public static GameObject CTFind(this MonoBehaviour parent, string name)
		{
			return null;
		}

		public static T CTFind<T>(this MonoBehaviour parent, string name)
		{
			return default(T);
		}

		public static GameObject CTFind(this GameObject parent, string name)
		{
			return null;
		}

		public static T CTFind<T>(this GameObject parent, string name)
		{
			return default(T);
		}

		public static Transform CTFind(this Transform parent, string name)
		{
			return null;
		}

		public static T CTFind<T>(this Transform parent, string name)
		{
			return default(T);
		}

		public static bool CTIsVisibleFrom(this Renderer renderer, Camera camera)
		{
			return false;
		}

		private static Transform deepSearch(Transform parent, string name)
		{
			return null;
		}

		private static float bytesToFloat(byte firstByte, byte secondByte)
		{
			return 0f;
		}
	}
}
