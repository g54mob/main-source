using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

		public static string CTToBase64(this string str, Encoding encoding = null)
		{
			return null;
		}

		public static string CTFromBase64(this string str, Encoding encoding = null)
		{
			return null;
		}

		public static byte[] CTFromBase64ToByteArray(this string str)
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

		public static Color32 CTHexToColor32(this string hexString)
		{
			return default(Color32);
		}

		public static Color CTHexToColor(this string hexString)
		{
			return default(Color);
		}

		public static byte[] CTToByteArray(this string str, Encoding encoding = null)
		{
			return null;
		}

		public static void CTShuffle<T>(this T[] array, int seed = 0)
		{
		}

		public static string CTDump<T>(this T[] array, string prefix = "", string postfix = "", bool appendNewLine = true, string delimiter = "; ")
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

		public static Texture2D CTToTexture(this byte[] data)
		{
			return null;
		}

		public static Sprite CTToSprite(this byte[] data)
		{
			return null;
		}

		public static string CTToByteArray(this byte[] data, Encoding encoding = null)
		{
			return null;
		}

		public static string CTToBase64(this byte[] data)
		{
			return null;
		}

		public static void CTShuffle<T>(this IList<T> list, int seed = 0)
		{
		}

		public static string CTDump<T>(this IList<T> list, string prefix = "", string postfix = "", bool appendNewLine = true, string delimiter = "; ")
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

		public static string CTDump<K, V>(this IDictionary<K, V> dict, string prefix = "", string postfix = "", bool appendNewLine = true, string delimiter = "; ")
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

		public static string CTToHexRGB(this Color32 input)
		{
			return null;
		}

		public static string CTToHexRGB(this Color input)
		{
			return null;
		}

		public static string CTToHexRGBA(this Color32 input)
		{
			return null;
		}

		public static string CTToHexRGBA(this Color input)
		{
			return null;
		}

		public static Vector3 CTVector3(this Color32 color)
		{
			return default(Vector3);
		}

		public static Vector3 CTVector3(this Color color)
		{
			return default(Vector3);
		}

		public static Vector4 CTVector4(this Color32 color)
		{
			return default(Vector4);
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

		public static void CTGetLocalCorners(this RectTransform transform, Vector3[] fourCornersArray, Canvas canvas, float inset = 0f, bool corrected = false)
		{
		}

		public static Vector3[] CTGetLocalCorners(this RectTransform transform, Canvas canvas, float inset = 0f, bool corrected = false)
		{
			return null;
		}

		public static void CTGetScreenCorners(this RectTransform transform, Vector3[] fourCornersArray, Canvas canvas, float inset = 0f, bool corrected = false)
		{
		}

		public static Vector3[] CTGetScreenCorners(this RectTransform transform, Canvas canvas, float inset = 0f, bool corrected = false)
		{
			return null;
		}

		public static Bounds CTGetBounds(this RectTransform transform, float uiScaleFactor = 1f)
		{
			return default(Bounds);
		}

		public static void CTSetLeft(this RectTransform transform, float value)
		{
		}

		public static void CTSetRight(this RectTransform transform, float value)
		{
		}

		public static void CTSetTop(this RectTransform transform, float value)
		{
		}

		public static void CTSetBottom(this RectTransform transform, float value)
		{
		}

		public static float CTGetLeft(this RectTransform transform)
		{
			return 0f;
		}

		public static float CTGetRight(this RectTransform transform)
		{
			return 0f;
		}

		public static float CTGetTop(this RectTransform transform)
		{
			return 0f;
		}

		public static float CTGetBottom(this RectTransform transform)
		{
			return 0f;
		}

		public static Vector4 CTGetLRTB(this RectTransform transform)
		{
			return default(Vector4);
		}

		public static void CTSetLRTB(this RectTransform transform, Vector4 lrtb)
		{
		}

		public static GameObject CTFind(this MonoBehaviour mb, string name)
		{
			return null;
		}

		public static T CTFind<T>(this MonoBehaviour mb, string name)
		{
			return default(T);
		}

		public static GameObject CTFind(this GameObject go, string name)
		{
			return null;
		}

		public static T CTFind<T>(this GameObject go, string name)
		{
			return default(T);
		}

		public static Bounds CTGetBounds(this GameObject go)
		{
			return default(Bounds);
		}

		public static Transform CTFind(this Transform transform, string name)
		{
			return null;
		}

		public static T CTFind<T>(this Transform transform, string name)
		{
			return default(T);
		}

		public static byte[] CTToPNG(this Sprite sprite)
		{
			return null;
		}

		public static byte[] CTToJPG(this Sprite sprite)
		{
			return null;
		}

		public static byte[] CTToTGA(this Sprite sprite)
		{
			return null;
		}

		public static byte[] CTToEXR(this Sprite sprite)
		{
			return null;
		}

		public static byte[] CTToPNG(this Texture2D texture)
		{
			return null;
		}

		public static byte[] CTToJPG(this Texture2D texture)
		{
			return null;
		}

		public static byte[] CTToTGA(this Texture2D texture)
		{
			return null;
		}

		public static byte[] CTToEXR(this Texture2D texture)
		{
			return null;
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
