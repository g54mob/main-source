using System;
using System.IO;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetMap
	{
		private const int Padding = 2;

		private float[][] _faces = new float[6][];

		public int Size { get; private set; }

		public PlanetMap(int size)
		{
			Size = size;
			for (int i = 0; i < 6; i++)
			{
				_faces[i] = new float[(size + 4) * (size + 4)];
			}
		}

		public static PlanetMap Load(BinaryReader reader, int size)
		{
			PlanetMap planetMap = new PlanetMap(size);
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < size; j++)
				{
					for (int k = 0; k < size; k++)
					{
						float value = reader.ReadSingle();
						planetMap.Set((CubemapFace)i, k, j, value);
					}
				}
			}
			return planetMap;
		}

		public static void WrapCoordinates(ref CubemapFace face, ref int x, ref int y, int size)
		{
			throw new NotImplementedException();
		}

		public float Get(CubemapFace face, int x, int y)
		{
			int index = GetIndex(x, y);
			return _faces[(int)face][index];
		}

		public void GetCoordinates(Vector3d position, out CubemapFace outFace, out int outX, out int outY)
		{
			Utility.CubemapDirectionToTextureCoordinates(position, out outFace, out var u, out var v);
			float num = 1f / (float)Size;
			float num2 = (float)((u + 1.0) * 0.5 * (double)(Size - 1)) - num;
			float num3 = (float)((v + 1.0) * 0.5 * (double)(Size - 1)) - num;
			outX = (int)num2;
			outY = (int)num3;
		}

		public float Sample(Vector3d position, float[][] preallocatedArray)
		{
			Utility.CubemapDirectionToTextureCoordinates(position, out var face, out var u, out var v);
			float num = 1f / (float)Size;
			float num2 = (float)((u + 1.0) * 0.5 * (double)(Size - 1)) - num;
			float num3 = (float)((v + 1.0) * 0.5 * (double)(Size - 1)) - num;
			int num4 = (int)num2;
			int num5 = (int)num3;
			float x = num2 - (float)num4;
			float y = num3 - (float)num5;
			float[][] array = preallocatedArray;
			if (preallocatedArray == null)
			{
				array = new float[4][];
				for (int i = 0; i < 4; i++)
				{
					array[i] = new float[4];
				}
			}
			float[] array2 = _faces[(int)face];
			for (int j = 0; j < 4; j++)
			{
				int num6 = GetIndex(num4 - 1, num5 + j - 1);
				for (int k = 0; k < 4; k++)
				{
					array[k][j] = array2[num6];
					num6++;
				}
			}
			return BicubicInterpolate(array, x, y);
		}

		public void Set(CubemapFace face, int x, int y, float value)
		{
			int index = GetIndex(x, y);
			_faces[(int)face][index] = value;
		}

		public void Write(BinaryWriter writer)
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					for (int k = 0; k < Size; k++)
					{
						float value = Get((CubemapFace)i, k, j);
						writer.Write(value);
					}
				}
			}
		}

		private static float BicubicInterpolate(float[][] p, float x, float y)
		{
			float[] obj = p[4];
			obj[0] = CubicInterpolate(p[0], y);
			obj[1] = CubicInterpolate(p[1], y);
			obj[2] = CubicInterpolate(p[2], y);
			obj[3] = CubicInterpolate(p[3], y);
			return CubicInterpolate(obj, x);
		}

		private static float CubicInterpolate(float[] p, float x)
		{
			return p[1] + 0.5f * x * (p[2] - p[0] + x * (2f * p[0] - 5f * p[1] + 4f * p[2] - p[3] + x * (3f * (p[1] - p[2]) + p[3] - p[0])));
		}

		private int GetIndex(int x, int y)
		{
			return (y + 2) * Size + x + 2;
		}
	}
}
