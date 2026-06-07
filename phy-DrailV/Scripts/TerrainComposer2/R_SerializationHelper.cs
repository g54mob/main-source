using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class R_SerializationHelper
{
	public static void SerializeString(List<byte> bytes, string v)
	{
		bytes.AddRange(BitConverter.GetBytes(v.Length));
		bytes.AddRange(Encoding.ASCII.GetBytes(v));
	}

	public static void SerializeFloat(List<byte> bytes, float v)
	{
		bytes.AddRange(BitConverter.GetBytes(v));
	}

	public static void SerializeInt(List<byte> bytes, int v)
	{
		bytes.AddRange(BitConverter.GetBytes(v));
	}

	public static void SerializeBool(List<byte> bytes, bool v)
	{
		bytes.Add((byte)(v ? 1 : 0));
	}

	public static void SerializeVector2(List<byte> bytes, Vector2 v)
	{
		bytes.AddRange(BitConverter.GetBytes(v.x));
		bytes.AddRange(BitConverter.GetBytes(v.y));
	}

	public static void SerializeVector3(List<byte> bytes, Vector3 v)
	{
		bytes.AddRange(BitConverter.GetBytes(v.x));
		bytes.AddRange(BitConverter.GetBytes(v.y));
		bytes.AddRange(BitConverter.GetBytes(v.z));
	}

	public static void SerializeVector4(List<byte> bytes, Vector4 v)
	{
		bytes.AddRange(BitConverter.GetBytes(v.x));
		bytes.AddRange(BitConverter.GetBytes(v.y));
		bytes.AddRange(BitConverter.GetBytes(v.z));
		bytes.AddRange(BitConverter.GetBytes(v.w));
	}

	public static void SerializeQuaternion(List<byte> bytes, Quaternion v)
	{
		bytes.AddRange(BitConverter.GetBytes(v.x));
		bytes.AddRange(BitConverter.GetBytes(v.y));
		bytes.AddRange(BitConverter.GetBytes(v.z));
		bytes.AddRange(BitConverter.GetBytes(v.w));
	}

	public static void SerializeTransform(List<byte> bytes, Transform t)
	{
		SerializeVector3(bytes, t.position);
		SerializeVector4(bytes, new Vector4(t.rotation.x, t.rotation.y, t.rotation.z, t.rotation.w));
		SerializeVector3(bytes, t.localScale);
	}

	public static void SerializeColor(List<byte> bytes, Color color)
	{
		bytes.AddRange(BitConverter.GetBytes(color.r));
		bytes.AddRange(BitConverter.GetBytes(color.g));
		bytes.AddRange(BitConverter.GetBytes(color.b));
		bytes.AddRange(BitConverter.GetBytes(color.a));
	}

	public static void SerializeIntArray(List<byte> bytes, int[] array)
	{
		SerializeInt(bytes, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			SerializeInt(bytes, array[i]);
		}
	}

	public static void SerializeFloatArray(List<byte> bytes, float[] array)
	{
		SerializeInt(bytes, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			SerializeFloat(bytes, array[i]);
		}
	}

	public static void SerializeBoolArray(List<byte> bytes, bool[] array)
	{
		SerializeInt(bytes, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			SerializeBool(bytes, array[i]);
		}
	}

	public static void SerializeVector2Array(List<byte> bytes, Vector2[] array)
	{
		SerializeInt(bytes, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			SerializeVector2(bytes, array[i]);
		}
	}

	public static void SerializeVector3Array(List<byte> bytes, Vector3[] array)
	{
		if (array != null)
		{
			SerializeInt(bytes, array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				SerializeVector3(bytes, array[i]);
			}
		}
	}

	public static void SerializeVector4Array(List<byte> bytes, Vector4[] array)
	{
		SerializeInt(bytes, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			SerializeVector4(bytes, array[i]);
		}
	}

	public static void SerializeTransformArray(List<byte> bytes, Transform[] array)
	{
		SerializeInt(bytes, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			SerializeTransform(bytes, array[i]);
		}
	}

	public static void SerializeAnimationCurve(List<byte> bytes, AnimationCurve curve)
	{
		SerializeInt(bytes, curve.length);
		for (int i = 0; i < curve.length; i++)
		{
			SerializeVector2(bytes, new Vector2(curve.keys[i].time, curve.keys[i].value));
		}
	}

	public static void SerializeAnimationCurveExact(List<byte> bytes, AnimationCurve curve)
	{
		SerializeInt(bytes, curve.length);
		for (int i = 0; i < curve.length; i++)
		{
			Keyframe keyframe = curve.keys[i];
			SerializeFloat(bytes, keyframe.time);
			SerializeFloat(bytes, keyframe.value);
			SerializeFloat(bytes, keyframe.inTangent);
			SerializeFloat(bytes, keyframe.outTangent);
		}
	}

	public static void Serialize2DFloatArray(List<byte> bytes, float[,] array)
	{
		int length = array.GetLength(0);
		int length2 = array.GetLength(1);
		bytes.AddRange(BitConverter.GetBytes(length));
		bytes.AddRange(BitConverter.GetBytes(length2));
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				bytes.AddRange(BitConverter.GetBytes(array[i, j]));
			}
		}
	}

	public static void Serialize2DIntArrayToBytes(List<byte> bytes, int[,] array)
	{
		int length = array.GetLength(0);
		int length2 = array.GetLength(1);
		bytes.AddRange(BitConverter.GetBytes(length));
		bytes.AddRange(BitConverter.GetBytes(length2));
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				bytes.Add((byte)array[i, j]);
			}
		}
	}

	public static string DeserializeString(byte[] bytes, ref int index)
	{
		int num = BitConverter.ToInt32(bytes, index);
		index += 4;
		string result = Encoding.ASCII.GetString(bytes, index, num);
		index += num;
		return result;
	}

	public static float DeserializeFloat(byte[] bytes, ref int index)
	{
		float result = BitConverter.ToSingle(bytes, index);
		index += 4;
		return result;
	}

	public static int DeserializeInt(byte[] bytes, ref int index)
	{
		int result = BitConverter.ToInt32(bytes, index);
		index += 4;
		return result;
	}

	public static bool DeserializeBool(byte[] bytes, ref int index)
	{
		if (bytes[index++] != 1)
		{
			return false;
		}
		return true;
	}

	public static Vector2 DeserializeVector2(byte[] bytes, ref int index)
	{
		Vector2 result = default(Vector2);
		result.x = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.y = BitConverter.ToSingle(bytes, index);
		index += 4;
		return result;
	}

	public static Vector3 DeserializeVector3(byte[] bytes, ref int index)
	{
		Vector3 result = default(Vector3);
		result.x = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.y = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.z = BitConverter.ToSingle(bytes, index);
		index += 4;
		return result;
	}

	public static Vector4 DeserializeVector4(byte[] bytes, ref int index)
	{
		Vector4 result = default(Vector4);
		result.x = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.y = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.z = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.w = BitConverter.ToSingle(bytes, index);
		index += 4;
		return result;
	}

	public static Quaternion DeserializeQuaternion(byte[] bytes, ref int index)
	{
		Quaternion result = default(Quaternion);
		result.x = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.y = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.z = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.w = BitConverter.ToSingle(bytes, index);
		index += 4;
		return result;
	}

	public static Color DeserializeColor(byte[] bytes, ref int index)
	{
		Color result = default(Color);
		result.r = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.g = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.b = BitConverter.ToSingle(bytes, index);
		index += 4;
		result.a = BitConverter.ToSingle(bytes, index);
		index += 4;
		return result;
	}

	public static void DeserializeTransform(byte[] bytes, ref int index, Transform t)
	{
		t.position = DeserializeVector3(bytes, ref index);
		Vector4 vector = DeserializeVector4(bytes, ref index);
		t.rotation = new Quaternion(vector.x, vector.y, vector.z, vector.w);
		t.localScale = DeserializeVector3(bytes, ref index);
	}

	public static void DeserializeAnimationCurve(byte[] bytes, ref int index, AnimationCurve curve)
	{
		int num = DeserializeInt(bytes, ref index);
		for (int i = 0; i < num; i++)
		{
			Vector2 vector = DeserializeVector2(bytes, ref index);
			curve.AddKey(vector.x, vector.y);
		}
	}

	public static void DeserializeAnimationCurve2(byte[] bytes, ref int index, AnimationCurve curve)
	{
		int num = DeserializeInt(bytes, ref index);
		for (int i = 0; i < num; i++)
		{
			Vector2 vector = DeserializeVector2(bytes, ref index);
			curve.AddKey(new Keyframe(vector.x, vector.y, float.PositiveInfinity, float.PositiveInfinity));
		}
	}

	public static Keyframe[] DeserializeAnimationCurveExact(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		Keyframe[] array = new Keyframe[num];
		for (int i = 0; i < num; i++)
		{
			float time = DeserializeFloat(bytes, ref index);
			float value = DeserializeFloat(bytes, ref index);
			float inTangent = DeserializeFloat(bytes, ref index);
			float outTangent = DeserializeFloat(bytes, ref index);
			array[i] = new Keyframe(time, value, inTangent, outTangent);
		}
		return array;
	}

	public static int[] DeserializeIntArray(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = DeserializeInt(bytes, ref index);
		}
		return array;
	}

	public static float[] DeserializeFloatArray(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		float[] array = new float[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = DeserializeFloat(bytes, ref index);
		}
		return array;
	}

	public static bool[] DeserializeBoolArray(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		bool[] array = new bool[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = DeserializeBool(bytes, ref index);
		}
		return array;
	}

	public static Vector2[] DeserializeVector2Array(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		Vector2[] array = new Vector2[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = DeserializeVector2(bytes, ref index);
		}
		return array;
	}

	public static Vector3[] DeserializeVector3Array(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		Vector3[] array = new Vector3[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = DeserializeVector3(bytes, ref index);
		}
		return array;
	}

	public static Vector4[] DeserializeVector4Array(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		Vector4[] array = new Vector4[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = DeserializeVector4(bytes, ref index);
		}
		return array;
	}

	public static Transform[] DeserializeTransformArray(byte[] bytes, ref int index)
	{
		int num = DeserializeInt(bytes, ref index);
		Transform[] array = new Transform[num];
		for (int i = 0; i < num; i++)
		{
			DeserializeTransform(bytes, ref index, array[i]);
		}
		return array;
	}

	public static float[,] Deserialize2DFloatArray(byte[] bytes, ref int index)
	{
		int num = BitConverter.ToInt32(bytes, index);
		index += 4;
		int num2 = BitConverter.ToInt32(bytes, index);
		index += 4;
		float[,] array = new float[num, num2];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array[i, j] = BitConverter.ToSingle(bytes, index);
				index += 4;
			}
		}
		return array;
	}

	public static int[,] Deserialize2DByteArrayToInt(byte[] bytes, ref int index)
	{
		int num = BitConverter.ToInt32(bytes, index);
		index += 4;
		int num2 = BitConverter.ToInt32(bytes, index);
		index += 4;
		int[,] array = new int[num, num2];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array[i, j] = bytes[index++];
			}
		}
		return array;
	}
}
