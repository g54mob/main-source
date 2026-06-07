using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public static class EditorPrefsX
	{
		private enum ArrayType
		{
			Float = 0,
			Int32 = 1,
			Bool = 2,
			String = 3,
			Vector2 = 4,
			Vector3 = 5,
			Quaternion = 6,
			Color = 7
		}

		private static int endianDiff1;

		private static int endianDiff2;

		private static int idx;

		private static byte[] byteBlock;

		public static bool SetBool(string name, bool value)
		{
			return false;
		}

		public static bool GetBool(string name)
		{
			return false;
		}

		public static bool GetBool(string name, bool defaultValue)
		{
			return false;
		}

		public static long GetLong(string key, long defaultValue)
		{
			return 0L;
		}

		public static long GetLong(string key)
		{
			return 0L;
		}

		private static void SplitLong(long input, out int lowBits, out int highBits)
		{
			lowBits = default(int);
			highBits = default(int);
		}

		public static void SetLong(string key, long value)
		{
		}

		public static bool SetVector2(string key, Vector2 vector)
		{
			return false;
		}

		private static Vector2 GetVector2(string key)
		{
			return default(Vector2);
		}

		public static Vector2 GetVector2(string key, Vector2 defaultValue)
		{
			return default(Vector2);
		}

		public static bool SetVector3(string key, Vector3 vector)
		{
			return false;
		}

		public static Vector3 GetVector3(string key)
		{
			return default(Vector3);
		}

		public static Vector3 GetVector3(string key, Vector3 defaultValue)
		{
			return default(Vector3);
		}

		public static bool SetQuaternion(string key, Quaternion vector)
		{
			return false;
		}

		public static Quaternion GetQuaternion(string key)
		{
			return default(Quaternion);
		}

		public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
		{
			return default(Quaternion);
		}

		public static bool SetColor(string key, Color color)
		{
			return false;
		}

		public static Color GetColor(string key)
		{
			return default(Color);
		}

		public static Color GetColor(string key, Color defaultValue)
		{
			return default(Color);
		}

		public static bool SetBoolArray(string key, bool[] boolArray)
		{
			return false;
		}

		public static bool[] GetBoolArray(string key)
		{
			return null;
		}

		public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
		{
			return null;
		}

		public static bool SetStringArray(string key, string[] stringArray)
		{
			return false;
		}

		public static string[] GetStringArray(string key)
		{
			return null;
		}

		public static string[] GetStringArray(string key, string defaultValue, int defaultSize)
		{
			return null;
		}

		public static bool SetIntArray(string key, int[] intArray)
		{
			return false;
		}

		public static bool SetFloatArray(string key, float[] floatArray)
		{
			return false;
		}

		public static bool SetVector2Array(string key, Vector2[] vector2Array)
		{
			return false;
		}

		public static bool SetVector3Array(string key, Vector3[] vector3Array)
		{
			return false;
		}

		public static bool SetQuaternionArray(string key, Quaternion[] quaternionArray)
		{
			return false;
		}

		public static bool SetColorArray(string key, Color[] colorArray)
		{
			return false;
		}

		private static bool SetValue<T>(string key, T array, ArrayType arrayType, int vectorNumber, Action<T, byte[], int> convert) where T : IList
		{
			return false;
		}

		private static void ConvertFromInt(int[] array, byte[] bytes, int i)
		{
		}

		private static void ConvertFromFloat(float[] array, byte[] bytes, int i)
		{
		}

		private static void ConvertFromVector2(Vector2[] array, byte[] bytes, int i)
		{
		}

		private static void ConvertFromVector3(Vector3[] array, byte[] bytes, int i)
		{
		}

		private static void ConvertFromQuaternion(Quaternion[] array, byte[] bytes, int i)
		{
		}

		private static void ConvertFromColor(Color[] array, byte[] bytes, int i)
		{
		}

		public static int[] GetIntArray(string key)
		{
			return null;
		}

		public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
		{
			return null;
		}

		public static float[] GetFloatArray(string key)
		{
			return null;
		}

		public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
		{
			return null;
		}

		public static Vector2[] GetVector2Array(string key)
		{
			return null;
		}

		public static Vector2[] GetVector2Array(string key, Vector2 defaultValue, int defaultSize)
		{
			return null;
		}

		public static Vector3[] GetVector3Array(string key)
		{
			return null;
		}

		public static Vector3[] GetVector3Array(string key, Vector3 defaultValue, int defaultSize)
		{
			return null;
		}

		public static Quaternion[] GetQuaternionArray(string key)
		{
			return null;
		}

		public static Quaternion[] GetQuaternionArray(string key, Quaternion defaultValue, int defaultSize)
		{
			return null;
		}

		public static Color[] GetColorArray(string key)
		{
			return null;
		}

		public static Color[] GetColorArray(string key, Color defaultValue, int defaultSize)
		{
			return null;
		}

		private static void GetValue<T>(string key, T list, ArrayType arrayType, int vectorNumber, Action<T, byte[]> convert) where T : IList
		{
		}

		private static void ConvertToInt(List<int> list, byte[] bytes)
		{
		}

		private static void ConvertToFloat(List<float> list, byte[] bytes)
		{
		}

		private static void ConvertToVector2(List<Vector2> list, byte[] bytes)
		{
		}

		private static void ConvertToVector3(List<Vector3> list, byte[] bytes)
		{
		}

		private static void ConvertToQuaternion(List<Quaternion> list, byte[] bytes)
		{
		}

		private static void ConvertToColor(List<Color> list, byte[] bytes)
		{
		}

		public static void ShowArrayType(string key)
		{
		}

		private static void Initialize()
		{
		}

		private static bool SaveBytes(string key, byte[] bytes)
		{
			return false;
		}

		private static void ConvertFloatToBytes(float f, byte[] bytes)
		{
		}

		private static float ConvertBytesToFloat(byte[] bytes)
		{
			return 0f;
		}

		private static void ConvertInt32ToBytes(int i, byte[] bytes)
		{
		}

		private static int ConvertBytesToInt32(byte[] bytes)
		{
			return 0;
		}

		private static void ConvertTo4Bytes(byte[] bytes)
		{
		}

		private static void ConvertFrom4Bytes(byte[] bytes)
		{
		}
	}
}
