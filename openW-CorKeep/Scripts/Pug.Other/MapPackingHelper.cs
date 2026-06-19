using System;
using Unity.Mathematics;

public static class MapPackingHelper
{
	public static byte[] PackIntoBuffer(int2 mapPosition, MapPartSerialized mapPart)
	{
		byte[] array = new byte[PackedSize(mapPart)];
		int num = 0;
		WriteIntToByteArray(array, 0, mapPosition.x);
		num += 4;
		WriteIntToByteArray(array, num, mapPosition.y);
		num += 4;
		WriteIntToByteArray(array, num, mapPart.png.Length);
		num += 4;
		Array.Copy(mapPart.png, 0, array, num, mapPart.png.Length);
		num += mapPart.png.Length;
		WriteIntToByteArray(array, num, mapPart.timestampPng.Length);
		num += 4;
		Array.Copy(mapPart.timestampPng, 0, array, num, mapPart.timestampPng.Length);
		num += mapPart.timestampPng.Length;
		return array;
	}

	public static void UnpackFromBuffer(byte[] buffer, out int2 mapPosition, out MapPartSerialized mapPart)
	{
		int num = 0;
		mapPart = default(MapPartSerialized);
		mapPosition.x = ReadIntFromByteArray(buffer, num);
		num += 4;
		mapPosition.y = ReadIntFromByteArray(buffer, num);
		num += 4;
		int num2 = ReadIntFromByteArray(buffer, num);
		num += 4;
		mapPart.png = new byte[num2];
		Array.Copy(buffer, num, mapPart.png, 0, num2);
		num += num2;
		int num3 = ReadIntFromByteArray(buffer, num);
		num += 4;
		mapPart.timestampPng = new byte[num3];
		Array.Copy(buffer, num, mapPart.timestampPng, 0, num3);
		num += num3;
		mapPart.RecomputeTimestampHash();
	}

	private static int PackedSize(MapPartSerialized mapPart)
	{
		return 16 + mapPart.png.Length + mapPart.timestampPng.Length;
	}

	private static void WriteIntToByteArray(byte[] array, int offset, int value)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = 8 * i;
			array[offset + i] = (byte)((value >> num) & 0xFF);
		}
	}

	private static int ReadIntFromByteArray(byte[] array, int offset)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = 8 * i;
			num |= array[offset + i] << num2;
		}
		return num;
	}
}
