using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public static class EditorPrefsX
{
	private enum ArrayType
	{
		Float,
		Int32,
		Bool,
		String,
		Vector2,
		Vector3,
		Quaternion,
		Color
	}

	private static int endianDiff1;

	private static int endianDiff2;

	private static int idx;

	private static byte[] byteBlock;

	public static bool SetBool(string name, bool value)
	{
		return true;
	}

	public static bool GetBool(string name)
	{
		return true;
	}

	public static bool GetBool(string name, bool defaultValue)
	{
		return true;
	}

	public static long GetLong(string key, long defaultValue)
	{
		//IL_0006: Expected I8, but got I4
		return 0L;
	}

	public static long GetLong(string key)
	{
		//IL_0006: Expected I8, but got I4
		return 0L;
	}

	private unsafe static void SplitLong(long input, out int lowBits, out int highBits)
	{
		ref int reference = ref *(int*)input;
		long num = input >> 32;
		ref int reference2 = ref *(int*)num;
	}

	public static void SetLong(string key, long value)
	{
	}

	public static bool SetVector2(string key, Vector2 vector)
	{
		//IL_00a4: Expected I4, but got O
		//IL_0039: Expected F4, but got O
		//IL_006d: Expected F4, but got O
		float[] array = new float[2];
		if (array.Length > 0)
		{
			array[0] = (float)vector;
			if (array.Length > 1)
			{
				object obj = default(object);
				array[1] = (float)obj;
				return SetFloatArray(key, array);
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private static Vector2 GetVector2(string key)
	{
		float[] floatArray = GetFloatArray(key);
		Vector2 result = default(Vector2);
		if (floatArray.Length >= 2)
		{
			if (floatArray.Length > 0 && floatArray.Length > 1)
			{
				return result;
			}
			return (Vector2)new IndexOutOfRangeException();
		}
		return result;
	}

	public static Vector2 GetVector2(string key, Vector2 defaultValue)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public static bool SetVector3(string key, Vector3 vector)
	{
		//IL_00e7: Expected I4, but got O
		float[] array = new float[3];
		if (array.Length > 0)
		{
			array[0] = vector.x;
			if (array.Length > 1)
			{
				array[1] = vector.y;
				if (array.Length > 2)
				{
					array[2] = vector.z;
					return SetFloatArray(key, array);
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public unsafe static Vector3 GetVector3(string key)
	{
		//IL_0102: Expected I, but got O
		//IL_0120: Expected F4, but got O
		//IL_011b: Expected native int or pointer, but got O
		//IL_0135: Expected F4, but got I
		//IL_0130: Expected native int or pointer, but got O
		//IL_00a9: Expected native int or pointer, but got O
		//IL_00c0: Expected native int or pointer, but got O
		//IL_00d7: Expected native int or pointer, but got O
		float[] floatArray = GetFloatArray(key);
		Vector3 vector = default(Vector3);
		if (floatArray.Length >= 3)
		{
			if (floatArray.Length > 0 && floatArray.Length > 1 && floatArray.Length > 2)
			{
				((Vector3*)(nint)vector)->x = floatArray[0];
				((Vector3*)(nint)vector)->y = floatArray[1];
				((Vector3*)(nint)vector)->z = floatArray[2];
				return vector;
			}
			return (Vector3)new IndexOutOfRangeException();
		}
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public unsafe static Vector3 GetVector3(string key, Vector3 defaultValue)
	{
		//IL_0013: Expected I, but got O
		//IL_0031: Expected F4, but got O
		//IL_002c: Expected native int or pointer, but got O
		//IL_0046: Expected F4, but got I
		//IL_0041: Expected native int or pointer, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rax_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public static bool SetQuaternion(string key, Quaternion vector)
	{
		//IL_0120: Expected I4, but got O
		float[] array = new float[4];
		if (array.Length > 0)
		{
			array[0] = vector.x;
			if (array.Length > 1)
			{
				array[1] = vector.y;
				if (array.Length > 2)
				{
					array[2] = vector.z;
					if (array.Length > 3)
					{
						array[3] = vector.w;
						return SetFloatArray(key, array);
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public unsafe static Quaternion GetQuaternion(string key)
	{
		//IL_013b: Expected F4, but got O
		//IL_0136: Expected native int or pointer, but got O
		//IL_00cb: Expected native int or pointer, but got O
		//IL_00e2: Expected native int or pointer, but got O
		//IL_00f9: Expected native int or pointer, but got O
		//IL_0110: Expected native int or pointer, but got O
		float[] floatArray = GetFloatArray(key);
		Quaternion quaternion = default(Quaternion);
		if (floatArray.Length >= 4)
		{
			if (floatArray.Length > 0 && floatArray.Length > 1 && floatArray.Length > 2 && floatArray.Length > 3)
			{
				((Quaternion*)(nint)quaternion)->w = floatArray[3];
				((Quaternion*)(nint)quaternion)->x = floatArray[0];
				((Quaternion*)(nint)quaternion)->y = floatArray[1];
				((Quaternion*)(nint)quaternion)->z = floatArray[2];
				return quaternion;
			}
			return (Quaternion)new IndexOutOfRangeException();
		}
		((Quaternion*)(nint)quaternion)->x = (float)Quaternion.identityQuaternion;
		return quaternion;
	}

	public unsafe static Quaternion GetQuaternion(string key, Quaternion defaultValue)
	{
		//IL_0013: Expected F4, but got O
		//IL_000e: Expected native int or pointer, but got O
		Quaternion quaternion = default(Quaternion);
		((Quaternion*)(nint)quaternion)->x = (float)Quaternion.identityQuaternion;
		return quaternion;
	}

	public static bool SetColor(string key, Color color)
	{
		//IL_0120: Expected I4, but got O
		float[] array = new float[4];
		if (array.Length > 0)
		{
			array[0] = color.r;
			if (array.Length > 1)
			{
				array[1] = color.g;
				if (array.Length > 2)
				{
					array[2] = color.b;
					if (array.Length > 3)
					{
						array[3] = color.a;
						return SetFloatArray(key, array);
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public unsafe static Color GetColor(string key)
	{
		//IL_0123: Expected native int or pointer, but got O
		//IL_0131: Expected native int or pointer, but got O
		//IL_00cb: Expected native int or pointer, but got O
		//IL_00e2: Expected native int or pointer, but got O
		//IL_00f9: Expected native int or pointer, but got O
		//IL_0110: Expected native int or pointer, but got O
		float[] floatArray = GetFloatArray(key);
		Color color = default(Color);
		if (floatArray.Length >= 4)
		{
			if (floatArray.Length > 0 && floatArray.Length > 1 && floatArray.Length > 2 && floatArray.Length > 3)
			{
				((Color*)(nint)color)->a = floatArray[3];
				((Color*)(nint)color)->r = floatArray[0];
				((Color*)(nint)color)->g = floatArray[1];
				((Color*)(nint)color)->b = floatArray[2];
				return color;
			}
			return (Color)new IndexOutOfRangeException();
		}
		((Color*)(nint)color)->r = 0f;
		((Color*)(nint)color)->b = 0f;
		return color;
	}

	public unsafe static Color GetColor(string key, Color defaultValue)
	{
		//IL_0015: Expected F4, but got I
		//IL_0010: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		Color color = default(Color);
		((Color*)(nint)color)->r = 0f;
		return color;
	}

	public static bool SetBoolArray(string key, bool[] boolArray)
	{
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0070: Expected I4, but got O
		//IL_01e1: Expected I4, but got O
		//IL_00e1: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0275: Expected O, but got I4
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		object obj = boolArray.Length + 7;
		object obj2 = obj >> 31;
		object obj3 = obj2 & 7;
		object obj4 = obj3 + obj;
		object obj5 = obj4 >> 3;
		object obj6 = obj5 + 5;
		byte[] array = new byte[obj6];
		object obj7 = default(object);
		object value = (ArrayType)obj7;
		byte b = Convert.ToByte(value);
		if (array.Length > 0)
		{
			array[0] = b;
			bool flag = boolArray.Length <= 0;
			object obj8 = 5;
			object obj9 = 5;
			object obj10 = 1;
			object obj11 = 0;
			object obj12 = 0;
			object obj13 = 5;
			if (flag)
			{
				goto IL_01b4;
			}
			while ((nint)obj12 < boolArray.Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v13+20+boolArray @ rdx (System.Boolean[])]");
				if ((nint)0 != 0)
				{
					if ((nint)obj8 >= array.Length)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v12+20+v57 @ rax_v8 (System.Byte[])]");
					_ = 0 | obj10;
				}
				object obj14 = obj10 + obj10;
				obj11++;
				obj13 = obj9 + 1;
				if ((nint)obj14 <= 128)
				{
					obj13 = obj9;
				}
				bool flag2 = (nint)obj14 > 128;
				obj10 = 1;
				if (!flag2)
				{
					obj10 = obj14;
				}
				bool flag3 = (nint)obj11 < boolArray.Length;
				obj8 = obj13;
				obj9 = obj13;
				obj12 = obj11;
				if (flag3)
				{
					continue;
				}
				goto IL_01b4;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
		IL_01b4:
		Initialize();
		ConvertInt32ToBytes(boolArray.Length, array);
		return true;
	}

	public unsafe static bool[] GetBoolArray(string key)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected I, but got Unknown
		//IL_011b: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0136: Expected O, but got I4
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_02e4: Expected O, but got I4
		string text = default(string);
		if (!PlayerPrefs.HasKey(text))
		{
			return new bool[0];
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999017]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text2 = PlayerPrefs.GetString(text, "");
		if (text2 != null)
		{
			char* inputPtr = (char*)(nint)(text2 + 20);
			byte[] array = Convert.FromBase64CharPtr(inputPtr, text2._stringLength);
			if (array != null)
			{
				string text3;
				if (array.Length >= 5)
				{
					if (array[0] == 2)
					{
						Initialize();
						int num = ConvertBytesToInt32(array);
						bool[] array2 = new bool[num];
						bool flag = array2 == null;
						object obj = 0;
						object obj2 = 5;
						object obj3 = 1;
						object obj4 = 0;
						if (!flag)
						{
							while ((nint)obj < array2.Length)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v4+20+v235 @ rax_v18 (System.Byte[])]");
								object obj5 = 0 & obj3;
								bool flag2 = obj5 == null;
								bool flag3 = !flag2;
								object obj6 = obj3 + obj3;
								obj4++;
								object obj7 = obj2 + 1;
								if ((nint)obj6 <= 128)
								{
									obj7 = obj2;
								}
								bool flag4 = (nint)obj6 > 128;
								obj3 = 1;
								if (!flag4)
								{
									obj3 = obj6;
								}
								obj = obj4;
								obj2 = obj7;
							}
							return array2;
						}
						goto IL_02b2;
					}
					text3 = " is not a boolean array";
				}
				else
				{
					text3 = text;
				}
				string message = "Corrupt preference file for " + text3;
				Debug.LogError(message);
				return new bool[0];
			}
			goto IL_02b2;
		}
		ArgumentNullException ex = new ArgumentNullException("s");
		throw ex;
		IL_02b2:
		return (bool[])(object)new NullReferenceException();
	}

	public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
	{
		return new bool[0];
	}

	public static bool SetStringArray(string key, string[] stringArray)
	{
		return true;
	}

	public static string[] GetStringArray(string key)
	{
		return new string[0];
	}

	public static string[] GetStringArray(string key, string defaultValue, int defaultSize)
	{
		return new string[0];
	}

	public static bool SetIntArray(string key, int[] intArray)
	{
		Action<int[], byte[], int> action = new Action<object, object, int>(ConvertFromInt);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD6000");
		bool result = default(bool);
		return result;
	}

	public static bool SetFloatArray(string key, float[] floatArray)
	{
		Action<float[], byte[], int> action = new Action<object, object, int>(ConvertFromFloat);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD6000");
		bool result = default(bool);
		return result;
	}

	public static bool SetVector2Array(string key, Vector2[] vector2Array)
	{
		Action<Vector2[], byte[], int> action = new Action<object, object, int>(ConvertFromVector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD6000");
		bool result = default(bool);
		return result;
	}

	public static bool SetVector3Array(string key, Vector3[] vector3Array)
	{
		Action<Vector3[], byte[], int> action = new Action<object, object, int>(ConvertFromVector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD6000");
		bool result = default(bool);
		return result;
	}

	public static bool SetQuaternionArray(string key, Quaternion[] quaternionArray)
	{
		Action<Quaternion[], byte[], int> action = new Action<object, object, int>(ConvertFromQuaternion);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD6000");
		bool result = default(bool);
		return result;
	}

	public static bool SetColorArray(string key, Color[] colorArray)
	{
		Action<Color[], byte[], int> action = new Action<object, object, int>(ConvertFromColor);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD6000");
		bool result = default(bool);
		return result;
	}

	private static bool SetValue<T>(string key, T array, ArrayType arrayType, int vectorNumber, Action<T, byte[], int> convert) where T : IList
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00ad: Expected I4, but got O
		//IL_017d: Expected I4, but got O
		//IL_010a: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = obj2 * vectorNumber;
		object obj3 = obj * 4;
		object obj4 = obj3 + 1;
		byte[] array2 = new byte[obj4];
		object obj5 = default(object);
		object value = (ArrayType)obj5;
		byte b = Convert.ToByte(value);
		if (array2.Length > 0)
		{
			array2[0] = b;
			Initialize();
			object obj6 = 0;
			object obj7 = 0;
			while (true)
			{
				int count = array.Count;
				if ((nint)obj6 >= count)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ stack_28+18] (should have been resolved before IL gen)");
				obj7++;
				obj6 = obj7;
			}
			return true;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private static void ConvertFromInt(int[] array, byte[] bytes, int i)
	{
		ConvertInt32ToBytes(array[i], bytes);
	}

	private static void ConvertFromFloat(float[] array, byte[] bytes, int i)
	{
		ConvertFloatToBytes(array[i], bytes);
	}

	private unsafe static void ConvertFromVector2(Vector2[] array, byte[] bytes, int i)
	{
		//IL_0016: Expected F4, but got Ref
		//IL_0030: Expected F4, but got I
		ConvertFloatToBytes((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[i]), bytes);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Vector2[])+24+i @ r8 (System.Int32)*8]");
		ConvertFloatToBytes(0f, bytes);
	}

	private unsafe static void ConvertFromVector3(Vector3[] array, byte[] bytes, int i)
	{
		//IL_0018: Expected F4, but got Ref
		//IL_002b: Expected O, but got I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_005b: Expected F4, but got I
		//IL_006e: Expected O, but got I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0090: Expected F4, but got I
		ConvertFloatToBytes((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[i]), bytes);
		object obj = i + 3;
		object obj2 = obj * 2;
		object obj3 = obj + obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Vector3[])+v46 @ rcx_v2*4]");
		ConvertFloatToBytes(0f, bytes);
		object obj4 = i * 2;
		object obj5 = i + obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Vector3[])+28+v96 @ rcx_v3*4]");
		ConvertFloatToBytes(0f, bytes);
	}

	private unsafe static void ConvertFromQuaternion(Quaternion[] array, byte[] bytes, int i)
	{
		//IL_0018: Expected F4, but got Ref
		//IL_002a: Expected O, but got I4
		//IL_003f: Expected F4, but got I
		//IL_0051: Expected O, but got I4
		//IL_0066: Expected F4, but got I
		//IL_0078: Expected O, but got I4
		//IL_008d: Expected F4, but got I
		ConvertFloatToBytes((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[i]), bytes);
		object obj = i + i;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Quaternion[])+24+v104 @ rax_v8*8]");
		ConvertFloatToBytes(0f, bytes);
		object obj2 = i + i;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Quaternion[])+28+v131 @ rax_v11*8]");
		ConvertFloatToBytes(0f, bytes);
		object obj3 = i + i;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Quaternion[])+2C+v133 @ rax_v14*8]");
		ConvertFloatToBytes(0f, bytes);
	}

	private unsafe static void ConvertFromColor(Color[] array, byte[] bytes, int i)
	{
		//IL_0018: Expected F4, but got Ref
		//IL_002a: Expected O, but got I4
		//IL_003f: Expected F4, but got I
		//IL_0051: Expected O, but got I4
		//IL_0066: Expected F4, but got I
		//IL_0078: Expected O, but got I4
		//IL_008d: Expected F4, but got I
		ConvertFloatToBytes((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[i]), bytes);
		object obj = i + i;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Color[])+24+v104 @ rax_v8*8]");
		ConvertFloatToBytes(0f, bytes);
		object obj2 = i + i;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Color[])+28+v131 @ rax_v11*8]");
		ConvertFloatToBytes(0f, bytes);
		object obj3 = i + i;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (UnityEngine.Color[])+2C+v133 @ rax_v14*8]");
		ConvertFloatToBytes(0f, bytes);
	}

	public unsafe static int[] GetIntArray(string key)
	{
		//IL_003d: Expected O, but got I
		List<int> list = new List<int>();
		Action<List<int>, byte[]> action = ConvertToInt;
		action._002Ector((object)null, (IntPtr)(nint)(delegate*<List<int>, byte[], void>)(&ConvertToInt));
		if (list != null)
		{
			ConvertToInt(list, (byte[])0);
			int[] result = default(int[]);
			return result;
		}
		return (int[])(object)new NullReferenceException();
	}

	public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
	{
		return new int[0];
	}

	public unsafe static float[] GetFloatArray(string key)
	{
		//IL_003d: Expected O, but got I
		List<float> list = new List<float>();
		Action<List<float>, byte[]> action = ConvertToFloat;
		action._002Ector((object)null, (IntPtr)(nint)(delegate*<List<float>, byte[], void>)(&ConvertToFloat));
		if (list != null)
		{
			ConvertToFloat(list, (byte[])0);
			float[] result = default(float[]);
			return result;
		}
		return (float[])(object)new NullReferenceException();
	}

	public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
	{
		return new float[0];
	}

	public unsafe static Vector2[] GetVector2Array(string key)
	{
		List<Vector2> list = new List<Vector2>();
		Action<List<Vector2>, byte[]> action = ConvertToVector2;
		action._002Ector((object)null, (IntPtr)(nint)(delegate*<List<Vector2>, byte[], void>)(&ConvertToVector2));
		if (list != null)
		{
			ConvertToVector2(list, null);
			Vector2[] result = default(Vector2[]);
			return result;
		}
		return (Vector2[])(object)new NullReferenceException();
	}

	public static Vector2[] GetVector2Array(string key, Vector2 defaultValue, int defaultSize)
	{
		return new Vector2[0];
	}

	public unsafe static Vector3[] GetVector3Array(string key)
	{
		List<Vector3> list = new List<Vector3>();
		Action<List<Vector3>, byte[]> action = ConvertToVector3;
		action._002Ector((object)null, (IntPtr)(nint)(delegate*<List<Vector3>, byte[], void>)(&ConvertToVector3));
		if (list != null)
		{
			ConvertToVector3(list, null);
			Vector3[] result = default(Vector3[]);
			return result;
		}
		return (Vector3[])(object)new NullReferenceException();
	}

	public static Vector3[] GetVector3Array(string key, Vector3 defaultValue, int defaultSize)
	{
		return new Vector3[0];
	}

	public unsafe static Quaternion[] GetQuaternionArray(string key)
	{
		List<Quaternion> list = new List<Quaternion>();
		Action<List<Quaternion>, byte[]> action = ConvertToQuaternion;
		action._002Ector((object)null, (IntPtr)(nint)(delegate*<List<Quaternion>, byte[], void>)(&ConvertToQuaternion));
		if (list != null)
		{
			ConvertToQuaternion(list, null);
			Quaternion[] result = default(Quaternion[]);
			return result;
		}
		return (Quaternion[])(object)new NullReferenceException();
	}

	public static Quaternion[] GetQuaternionArray(string key, Quaternion defaultValue, int defaultSize)
	{
		return new Quaternion[0];
	}

	public unsafe static Color[] GetColorArray(string key)
	{
		//IL_0061: Expected I, but got O
		//IL_0084: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_008e: Expected O, but got I
		List<Color> list = new List<Color>();
		Action<List<Color>, byte[]> action = ConvertToColor;
		action._002Ector((object)null, (IntPtr)(nint)(delegate*<List<Color>, byte[], void>)(&ConvertToColor));
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			if ((nint)0 != 0)
			{
				nint num = unchecked((nint)null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
				int length = default(int);
				Array.Copy((Array)0, 0, (Array)num, 0, length);
				return (Color[])num;
			}
			return List<Color>.s_emptyArray;
		}
		return (Color[])(object)new NullReferenceException();
	}

	public static Color[] GetColorArray(string key, Color defaultValue, int defaultSize)
	{
		return new Color[0];
	}

	private static void GetValue<T>(string key, T list, ArrayType arrayType, int vectorNumber, Action<T, byte[]> convert) where T : IList
	{
	}

	private static void ConvertToInt(List<int> list, byte[] bytes)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		int item = ConvertBytesToInt32(bytes);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(item);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	private static void ConvertToFloat(List<float> list, byte[] bytes)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		float item = ConvertBytesToFloat(bytes);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(item);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	private static void ConvertToVector2(List<Vector2> list, byte[] bytes)
	{
		float num = ConvertBytesToFloat(bytes);
		float num2 = ConvertBytesToFloat(bytes);
		Vector2 item = default(Vector2);
		list.Add(item);
	}

	private unsafe static void ConvertToVector3(List<Vector3> list, byte[] bytes)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0066: Expected O, but got Ref
		float num = ConvertBytesToFloat(bytes);
		float num2 = ConvertBytesToFloat(bytes);
		float num3 = ConvertBytesToFloat(bytes);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v6+18]");
		if (num4 >= 0)
		{
			object obj2 = default(object);
			list.AddWithResize((Vector3)(&obj2));
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		object obj3 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		object obj4 = (nint)0 * (nint)2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		object obj5 = 0 + obj4;
	}

	private unsafe static void ConvertToQuaternion(List<Quaternion> list, byte[] bytes)
	{
		//IL_003a: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_00b4: Expected O, but got I
		//IL_0078: Expected O, but got Ref
		float num = ConvertBytesToFloat(bytes);
		float num2 = ConvertBytesToFloat(bytes);
		float num3 = ConvertBytesToFloat(bytes);
		float num4 = ConvertBytesToFloat(bytes);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v7+18]");
		if (num5 >= 0)
		{
			object obj2 = default(object);
			list.AddWithResize((Quaternion)(&obj2));
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+18]");
		object obj3 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+18]");
		object obj4 = (nint)0 + (nint)2;
		object obj5 = obj4 + obj4;
	}

	private unsafe static void ConvertToColor(List<Color> list, byte[] bytes)
	{
		//IL_003a: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_00b4: Expected O, but got I
		//IL_0078: Expected O, but got Ref
		float num = ConvertBytesToFloat(bytes);
		float num2 = ConvertBytesToFloat(bytes);
		float num3 = ConvertBytesToFloat(bytes);
		float num4 = ConvertBytesToFloat(bytes);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v7+18]");
		if (num5 >= 0)
		{
			object obj2 = default(object);
			list.AddWithResize((Color)(&obj2));
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		object obj3 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [list @ rcx (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		object obj4 = (nint)0 + (nint)2;
		object obj5 = obj4 + obj4;
	}

	public static void ShowArrayType(string key)
	{
	}

	private static void Initialize()
	{
		endianDiff1 = 0;
		endianDiff2 = 0;
		if (byteBlock == null)
		{
			byte[] array = new byte[4];
			byteBlock = array;
			idx = 1;
		}
		else
		{
			idx = 1;
		}
	}

	private static bool SaveBytes(string key, byte[] bytes)
	{
		return true;
	}

	private static void ConvertFloatToBytes(float f, byte[] bytes)
	{
		//IL_0017: Expected I4, but got F4
		byteBlock = new byte[4]
		{
			(byte)(int)f,
			0,
			0,
			0
		};
		ConvertTo4Bytes(bytes);
	}

	private static float ConvertBytesToFloat(byte[] bytes)
	{
		//IL_0055: Expected F4, but got I4
		ConvertFrom4Bytes(bytes);
		byte[] array = byteBlock;
		if (byteBlock != null)
		{
			if (array.Length <= 0)
			{
				goto IL_0095;
			}
			if (array.Length >= 4)
			{
				return (int)array[0];
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.value);
		}
		System.ThrowHelper.ThrowArgumentException(System.ExceptionResource.Arg_ArrayPlusOffTooSmall, System.ExceptionArgument.value);
		goto IL_0095;
		IL_0095:
		System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.startIndex, System.ExceptionResource.ArgumentOutOfRange_Index);
		float result = default(float);
		return result;
	}

	private static void ConvertInt32ToBytes(int i, byte[] bytes)
	{
		byteBlock = new byte[4]
		{
			(byte)i,
			0,
			0,
			0
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 125 Invalid \"Jump target not found in method: 0x1851A9720\"");
		throw new NullReferenceException();
	}

	private static int ConvertBytesToInt32(byte[] bytes)
	{
		ConvertFrom4Bytes(bytes);
		byte[] array = byteBlock;
		if (byteBlock != null)
		{
			if (array.Length <= 0)
			{
				goto IL_0095;
			}
			if (array.Length >= 4)
			{
				return array[0];
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.value);
		}
		System.ThrowHelper.ThrowArgumentException(System.ExceptionResource.Arg_ArrayPlusOffTooSmall, System.ExceptionArgument.value);
		goto IL_0095;
		IL_0095:
		System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.startIndex, System.ExceptionResource.ArgumentOutOfRange_Index);
		int result = default(int);
		return result;
	}

	private static void ConvertTo4Bytes(byte[] bytes)
	{
		//IL_003d: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		byte[] array = byteBlock;
		int num = idx;
		int num2 = endianDiff1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v5 (System.Int32)+20+v32 @ rdx_v1 (System.Byte[])]");
		_ = 0;
		byte[] array2 = byteBlock;
		object obj = endianDiff2 + 1;
		object obj2 = idx + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v9+20+v62 @ rdx_v4 (System.Byte[])]");
		_ = 0;
		byte[] array3 = byteBlock;
		object obj3 = 2 - endianDiff2;
		object obj4 = idx + 2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v12+20+v63 @ rdx_v5 (System.Byte[])]");
		_ = 0;
		byte[] array4 = byteBlock;
		object obj5 = 3 - endianDiff1;
		object obj6 = idx + 3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v16+20+v64 @ rdx_v6 (System.Byte[])]");
		_ = 0;
		int num3 = idx + 4;
		idx = num3;
	}

	private static void ConvertFrom4Bytes(byte[] bytes)
	{
		//IL_0038: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		byte[] array = byteBlock;
		int num = endianDiff1;
		int num2 = idx;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v5 (System.Int32)+20+bytes @ rcx (System.Byte[])]");
		_ = 0;
		byte[] array2 = byteBlock;
		object obj = idx + 1;
		object obj2 = endianDiff2 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v9+20+bytes @ rcx (System.Byte[])]");
		_ = 0;
		byte[] array3 = byteBlock;
		object obj3 = idx + 2;
		object obj4 = 2 - endianDiff2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v12+20+bytes @ rcx (System.Byte[])]");
		_ = 0;
		byte[] array4 = byteBlock;
		object obj5 = idx + 3;
		object obj6 = 3 - endianDiff1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v15+20+bytes @ rcx (System.Byte[])]");
		_ = 0;
		int num3 = idx + 4;
		idx = num3;
	}
}
