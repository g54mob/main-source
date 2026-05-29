using System;
using System.IO;
using System.IO.Compression;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileMeshes
	{
		public TileMesh[] tileMeshes;

		public IntRect tileRect;

		public Vector2 tileWorldSize;

		public void Rotate(int rotation)
		{
			rotation = -rotation;
			rotation = (rotation % 4 + 4) % 4;
			if (rotation == 0)
			{
				return;
			}
			int2x2 b = new int2x2(0, -1, 1, 0);
			int2x2 a = int2x2.identity;
			for (int i = 0; i < rotation; i++)
			{
				a = math.mul(a, b);
			}
			Int3 int5 = (Int3)new Vector3(tileWorldSize.x, 0f, tileWorldSize.y);
			int2 int6 = -math.min(int2.zero, math.mul(a, new int2(int5.x, int5.z)));
			int2 int7 = new int2(tileRect.Width, tileRect.Height);
			int2 int8 = -math.min(int2.zero, math.mul(a, int7 - 1));
			TileMesh[] array = new TileMesh[tileMeshes.Length];
			int2 int9 = ((rotation % 2 == 0) ? int7 : new int2(int7.y, int7.x));
			for (int j = 0; j < int7.y; j++)
			{
				for (int k = 0; k < int7.x; k++)
				{
					Int3[] verticesInTileSpace = tileMeshes[k + j * int7.x].verticesInTileSpace;
					for (int l = 0; l < verticesInTileSpace.Length; l++)
					{
						Int3 int10 = verticesInTileSpace[l];
						int2 int11 = math.mul(a, new int2(int10.x, int10.z)) + int6;
						verticesInTileSpace[l] = new Int3(int11.x, int10.y, int11.y);
					}
					int2 int12 = math.mul(a, new int2(k, j)) + int8;
					array[int12.x + int12.y * int9.x] = tileMeshes[k + j * int7.x];
				}
			}
			tileMeshes = array;
			tileWorldSize = ((rotation % 2 == 0) ? tileWorldSize : new Vector2(tileWorldSize.y, tileWorldSize.x));
			tileRect = new IntRect(tileRect.xmin, tileRect.ymin, tileRect.xmin + int9.x - 1, tileRect.ymin + int9.y - 1);
		}

		public byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(new DeflateStream(memoryStream, CompressionMode.Compress));
			binaryWriter.Write(0);
			binaryWriter.Write(tileRect.Width);
			binaryWriter.Write(tileRect.Height);
			binaryWriter.Write(tileWorldSize.x);
			binaryWriter.Write(tileWorldSize.y);
			for (int i = 0; i < tileRect.Height; i++)
			{
				for (int j = 0; j < tileRect.Width; j++)
				{
					TileMesh tileMesh = tileMeshes[i * tileRect.Width + j];
					binaryWriter.Write(tileMesh.triangles.Length);
					binaryWriter.Write(tileMesh.verticesInTileSpace.Length);
					for (int k = 0; k < tileMesh.verticesInTileSpace.Length; k++)
					{
						Int3 int5 = tileMesh.verticesInTileSpace[k];
						binaryWriter.Write(int5.x);
						binaryWriter.Write(int5.y);
						binaryWriter.Write(int5.z);
					}
					for (int l = 0; l < tileMesh.triangles.Length; l++)
					{
						binaryWriter.Write(tileMesh.triangles[l]);
					}
					for (int m = 0; m < tileMesh.tags.Length; m++)
					{
						binaryWriter.Write(tileMesh.tags[m]);
					}
				}
			}
			binaryWriter.Close();
			return memoryStream.ToArray();
		}

		public static TileMeshes Deserialize(byte[] bytes)
		{
			BinaryReader binaryReader = new BinaryReader(new DeflateStream(new MemoryStream(bytes), CompressionMode.Decompress));
			if (binaryReader.ReadInt32() != 0)
			{
				throw new Exception("Invalid data. Unexpected version number.");
			}
			int num = binaryReader.ReadInt32();
			int num2 = binaryReader.ReadInt32();
			Vector2 vector = new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
			if (num < 0 || num2 < 0)
			{
				throw new Exception("Invalid bounds");
			}
			IntRect intRect = new IntRect(0, 0, num - 1, num2 - 1);
			TileMesh[] array = new TileMesh[num * num2];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int[] array2 = new int[binaryReader.ReadInt32()];
					Int3[] array3 = new Int3[binaryReader.ReadInt32()];
					uint[] array4 = new uint[array2.Length / 3];
					for (int k = 0; k < array3.Length; k++)
					{
						array3[k] = new Int3(binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32());
					}
					for (int l = 0; l < array2.Length; l++)
					{
						array2[l] = binaryReader.ReadInt32();
					}
					for (int m = 0; m < array4.Length; m++)
					{
						array4[m] = binaryReader.ReadUInt32();
					}
					array[j + i * num] = new TileMesh
					{
						triangles = array2,
						verticesInTileSpace = array3,
						tags = array4
					};
				}
			}
			return new TileMeshes
			{
				tileMeshes = array,
				tileRect = intRect,
				tileWorldSize = vector
			};
		}
	}
}
