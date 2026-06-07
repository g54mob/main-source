using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AltSerialize;
using UnityEngine;

public static class BitWriterHelper
{
	public static byte[] ReadRest(this Stream stream)
	{
		long num = stream.Length - stream.Position;
		byte[] array = new byte[num];
		stream.Read(array, 0, (int)num);
		return array;
	}

	public static void WriteBool(this Stream stream, bool value)
	{
		stream.WriteByte((byte)(value ? 1 : 0));
	}

	public static bool ReadBool(this Stream stream)
	{
		return stream.ReadByte() > 0;
	}

	public static void WriteBools(this Stream stream, bool b1, bool b2 = false, bool b3 = false, bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false, bool b8 = false)
	{
		int num = (b1 ? 1 : 0);
		num |= (b2 ? 2 : 0);
		num |= (b3 ? 4 : 0);
		num |= (b4 ? 8 : 0);
		num |= (b5 ? 16 : 0);
		num |= (b6 ? 32 : 0);
		num |= (b7 ? 64 : 0);
		num |= (b8 ? 128 : 0);
		stream.WriteByte((byte)num);
	}

	public static void ReadBools(this Stream stream, out bool b1)
	{
		int num = stream.ReadByte();
		b1 = (num & 1) != 0;
	}

	public static void ReadBools(this Stream stream, out bool b1, out bool b2)
	{
		int num = stream.ReadByte();
		b1 = (num & 1) != 0;
		b2 = (num & 2) != 0;
	}

	public static void ReadBools(this Stream stream, out bool b1, out bool b2, out bool b3)
	{
		int num = stream.ReadByte();
		b1 = (num & 1) != 0;
		b2 = (num & 2) != 0;
		b3 = (num & 4) != 0;
	}

	public static void ReadBools(this Stream stream, out bool b1, out bool b2, out bool b3, out bool b4)
	{
		int num = stream.ReadByte();
		b1 = (num & 1) != 0;
		b2 = (num & 2) != 0;
		b3 = (num & 4) != 0;
		b4 = (num & 8) != 0;
	}

	public static void ReadBools(this Stream stream, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6)
	{
		int num = stream.ReadByte();
		b1 = (num & 1) != 0;
		b2 = (num & 2) != 0;
		b3 = (num & 4) != 0;
		b4 = (num & 8) != 0;
		b5 = (num & 0x10) != 0;
		b6 = (num & 0x20) != 0;
	}

	public static void ReadBools(this Stream stream, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7, out bool b8)
	{
		int num = stream.ReadByte();
		b1 = (num & 1) != 0;
		b2 = (num & 2) != 0;
		b3 = (num & 4) != 0;
		b4 = (num & 8) != 0;
		b5 = (num & 0x10) != 0;
		b6 = (num & 0x20) != 0;
		b7 = (num & 0x40) != 0;
		b8 = (num & 0x80) != 0;
	}

	public static void WriteColor(this Stream stream, Color32 c, bool alpha = true)
	{
		stream.WriteByte(c.r);
		stream.WriteByte(c.g);
		stream.WriteByte(c.b);
		if (alpha)
		{
			stream.WriteByte(c.a);
		}
	}

	public static void WriteColor(this Stream stream, Color c, bool alpha = true)
	{
		stream.WriteColor(c.ToCorrectColor32(), alpha);
	}

	public static Color32 ReadColor(this Stream stream, bool alpha = true)
	{
		return new Color32((byte)stream.ReadByte(), (byte)stream.ReadByte(), (byte)stream.ReadByte(), alpha ? ((byte)stream.ReadByte()) : byte.MaxValue);
	}

	public static void WriteVector(this Stream stream, SVector3 v)
	{
		byte b = 0;
		if (v.x != 0f)
		{
			b |= 1;
		}
		if (v.y != 0f)
		{
			b |= 2;
		}
		if (v.z != 0f)
		{
			b |= 4;
		}
		if (v.w != 0f)
		{
			b |= 8;
		}
		stream.WriteByte(b);
		if ((b & 1) > 0)
		{
			stream.WriteFloat(v.x);
		}
		if ((b & 2) > 0)
		{
			stream.WriteFloat(v.y);
		}
		if ((b & 4) > 0)
		{
			stream.WriteFloat(v.z);
		}
		if ((b & 8) > 0)
		{
			stream.WriteFloat(v.w);
		}
	}

	public static SVector3 ReadVector(this Stream stream)
	{
		int num = stream.ReadByte();
		float x = 0f;
		float y = 0f;
		float z = 0f;
		float w = 0f;
		if ((num & 1) > 0)
		{
			x = stream.ReadFloat();
		}
		if ((num & 2) > 0)
		{
			y = stream.ReadFloat();
		}
		if ((num & 4) > 0)
		{
			z = stream.ReadFloat();
		}
		if ((num & 8) > 0)
		{
			w = stream.ReadFloat();
		}
		return new SVector3(x, y, z, w);
	}

	public static void WriteFloat(this Stream stream, float value, float min, float max)
	{
		byte[] bytes = BitConverter.GetBytes((ushort)Mathf.RoundToInt(value.MapRange(min, max, 0f, 65535f, true)));
		stream.Write(bytes, 0, bytes.Length);
	}

	public static float ReadFloat(this Stream stream, float min, float max)
	{
		byte[] array = new byte[2];
		stream.Read(array, 0, array.Length);
		return ((float)(int)BitConverter.ToUInt16(array, 0)).MapRange(0f, 65535f, min, max, true);
	}

	public static void WriteFloat(this Stream stream, float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public static float ReadFloat(this Stream stream)
	{
		byte[] array = new byte[4];
		stream.Read(array, 0, array.Length);
		return BitConverter.ToSingle(array, 0);
	}

	public static void WriteDouble(this Stream stream, double value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public static double ReadDouble(this Stream stream)
	{
		byte[] array = new byte[8];
		stream.Read(array, 0, array.Length);
		return BitConverter.ToDouble(array, 0);
	}

	public static void WriteFloatNotDefault(this Stream stream, params float[] valueDefaultPair)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < valueDefaultPair.Length; i += 2)
		{
			if (valueDefaultPair[i] != valueDefaultPair[i + 1])
			{
				num |= 1 << num2;
			}
			num2++;
			if (num2 == 8)
			{
				stream.WriteByte((byte)num);
				num = 0;
				num2 = 0;
			}
		}
		if (num2 > 0)
		{
			stream.WriteByte((byte)num);
		}
		for (int j = 0; j < valueDefaultPair.Length; j += 2)
		{
			if (valueDefaultPair[j] != valueDefaultPair[j + 1])
			{
				stream.WriteFloat(valueDefaultPair[j]);
			}
		}
	}

	public static float[] ReadFloatNotDefault(this Stream stream, params float[] defaults)
	{
		float[] array = new float[defaults.Length];
		byte[] array2 = new byte[(defaults.Length - 1) / 8 + 1];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = (byte)stream.ReadByte();
		}
		for (int j = 0; j < defaults.Length; j++)
		{
			int num = array2[j / 8] & (1 << j % 8);
			if (num > 0)
			{
				array[j] = num;
			}
			else
			{
				array[j] = defaults[j];
			}
		}
		return array;
	}

	public static void WriteInt(this Stream stream, int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public static int ReadInt(this Stream stream)
	{
		byte[] array = new byte[4];
		stream.Read(array, 0, array.Length);
		return BitConverter.ToInt32(array, 0);
	}

	public static void WriteUInt(this Stream stream, uint value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public static uint ReadUInt(this Stream stream)
	{
		byte[] array = new byte[4];
		stream.Read(array, 0, array.Length);
		return BitConverter.ToUInt32(array, 0);
	}

	public static void WriteUShort(this Stream stream, ushort value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public static uint ReadUShort(this Stream stream)
	{
		byte[] array = new byte[2];
		stream.Read(array, 0, array.Length);
		return BitConverter.ToUInt16(array, 0);
	}

	public static void WriteUInt64(this Stream stream, ulong value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public static ulong ReadUint64(this Stream stream)
	{
		byte[] array = new byte[8];
		stream.Read(array, 0, array.Length);
		return BitConverter.ToUInt64(array, 0);
	}

	public static void WriteString(this Stream stream, string value)
	{
		if (value == null)
		{
			stream.WriteInt(-1);
			return;
		}
		stream.WriteInt(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			stream.WriteByte((byte)value[i]);
		}
	}

	public static string ReadString(this Stream stream)
	{
		int num = stream.ReadInt();
		if (num < 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < num; i++)
		{
			stringBuilder.Append((char)stream.ReadByte());
		}
		return stringBuilder.ToString();
	}

	public static void WriteStringUTF8(this Stream stream, string value)
	{
		if (value == null)
		{
			stream.WriteInt(-1);
			return;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		stream.WriteBytes(bytes);
	}

	public static string ReadStringUTF8(this Stream stream)
	{
		int num = stream.ReadInt();
		if (num < 0)
		{
			return null;
		}
		byte[] array = new byte[num];
		stream.Read(array, 0, array.Length);
		return Encoding.UTF8.GetString(array);
	}

	public static void WriteBytes(this Stream stream, byte[] value)
	{
		if (value == null)
		{
			stream.WriteInt(-1);
			return;
		}
		stream.WriteInt(value.Length);
		stream.Write(value, 0, value.Length);
	}

	public static byte[] ReadBytes(this Stream stream)
	{
		int num = stream.ReadInt();
		if (num < 0)
		{
			return null;
		}
		byte[] array = new byte[num];
		stream.Read(array, 0, array.Length);
		return array;
	}

	public static void WriteObject<T>(this Stream stream, T obj)
	{
		if (obj == null)
		{
			stream.WriteByte(2);
			return;
		}
		byte[] array = Serializer.Serialize(obj);
		bool flag = array.Length > 1048576;
		if (flag)
		{
			array = GameReader.Compress(array);
		}
		stream.WriteByte((byte)(flag ? 1 : 0));
		stream.WriteBytes(array);
	}

	public static T ReadObject<T>(this Stream stream)
	{
		int num = stream.ReadByte();
		if ((num & 2) > 0)
		{
			return default(T);
		}
		bool num2 = (num & 1) > 0;
		byte[] array = stream.ReadBytes();
		if (num2)
		{
			array = GameReader.Decompress(array);
		}
		return (T)Serializer.Deserialize(array);
	}

	public static void WriteByteObject(this Stream stream, IByteData obj)
	{
		obj.WriteData(stream);
	}

	public static void WriteEnum(this Stream stream, object value, bool asByte)
	{
		if (asByte)
		{
			stream.WriteByte((byte)(int)value);
		}
		else
		{
			stream.WriteInt((int)value);
		}
	}

	public static T ReadEnum<T>(this Stream stream, bool asByte)
	{
		if (asByte)
		{
			return (T)(object)stream.ReadByte();
		}
		return (T)(object)stream.ReadInt();
	}

	public static void WriteArray<T>(this Stream stream, IEnumerable<T> arr, Action<Stream, T> write)
	{
		if (arr == null)
		{
			stream.WriteInt(-1);
			return;
		}
		long position = stream.Position;
		stream.WriteInt(0);
		int num = 0;
		foreach (T item in arr)
		{
			write(stream, item);
			num++;
		}
		long position2 = stream.Position;
		stream.Seek(position, SeekOrigin.Begin);
		stream.WriteInt(num);
		stream.Seek(position2, SeekOrigin.Begin);
	}

	public static void WriteArray<T>(this Stream stream, IList<T> arr, Action<Stream, T> write)
	{
		if (arr == null)
		{
			stream.WriteInt(-1);
			return;
		}
		stream.WriteInt(arr.Count);
		for (int i = 0; i < arr.Count; i++)
		{
			write(stream, arr[i]);
		}
	}

	public static void ExecuteArray(this Stream stream, Action<Stream> read)
	{
		int num = stream.ReadInt();
		if (num != -1)
		{
			for (int i = 0; i < num; i++)
			{
				read(stream);
			}
		}
	}

	public static T[] ReadArray<T>(this Stream stream, Func<Stream, T> read)
	{
		int num = stream.ReadInt();
		if (num == -1)
		{
			return null;
		}
		T[] array = new T[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = read(stream);
		}
		return array;
	}

	public static Dictionary<TKey, TValue> ReadDictionary<TKey, TValue>(this Stream stream, Func<Stream, TKey> readKey, Func<Stream, TValue> readValue)
	{
		int num = stream.ReadInt();
		if (num == -1)
		{
			return null;
		}
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
		for (int i = 0; i < num; i++)
		{
			dictionary[readKey(stream)] = readValue(stream);
		}
		return dictionary;
	}

	public static List<T> ReadList<T>(this Stream stream, Func<Stream, T> read)
	{
		int num = stream.ReadInt();
		if (num == -1)
		{
			return null;
		}
		List<T> list = new List<T>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(read(stream));
		}
		return list;
	}
}
