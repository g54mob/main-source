using System;
using System.IO;
using ModApi.Common.SimpleTypes;
using Unity.Collections;
using UnityEngine;

namespace ModApi.Planet.Modifiers.Common
{
	public class SingleChannelByteCubemapDataSampler
	{
		private byte[][] _data;

		private int _faceSize;

		private int _faceSizeMinusOne;

		private int _faceSizePadded;

		public SingleChannelByteCubemapDataSampler(Texture2D texture, int colorChannel)
			: this(texture.GetPixels32(), colorChannel, texture.height)
		{
		}

		public SingleChannelByteCubemapDataSampler(Color32[] colors, int colorChannel, int faceSize)
		{
			_faceSize = faceSize;
			_faceSizeMinusOne = faceSize - 1;
			_faceSizePadded = faceSize + 4;
			int num = faceSize * 6;
			_data = new byte[6][];
			for (int i = 0; i < 6; i++)
			{
				byte[] array = (_data[i] = new byte[_faceSizePadded * _faceSizePadded]);
				for (int j = 0; j < _faceSizePadded; j++)
				{
					int num2 = Mathf.Clamp(j - 2, 0, _faceSizeMinusOne);
					for (int k = 0; k < _faceSizePadded; k++)
					{
						int num3 = Mathf.Clamp(k - 2, 0, _faceSizeMinusOne);
						int num4 = j * _faceSizePadded + k;
						int num5 = num2 * num + i * faceSize + num3;
						switch (colorChannel)
						{
						case 0:
							array[num4] = colors[num5].r;
							break;
						case 1:
							array[num4] = colors[num5].g;
							break;
						case 2:
							array[num4] = colors[num5].b;
							break;
						case 3:
							array[num4] = colors[num5].a;
							break;
						default:
							throw new NotSupportedException();
						}
					}
				}
			}
			FixupSeams();
		}

		private SingleChannelByteCubemapDataSampler(byte[][] data, int faceSize)
		{
			_faceSize = faceSize;
			_faceSizeMinusOne = faceSize - 1;
			_faceSizePadded = faceSize + 4;
			_data = data;
		}

		public static SingleChannelByteCubemapDataSampler Load(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			byte[][] array = new byte[6][];
			for (int i = 0; i < 6; i++)
			{
				byte[] array2 = (array[i] = new byte[(num + 4) * (num + 4)]);
				int num2 = 0;
				int num3 = array2.Length;
				byte[] array3 = new byte[16384];
				int num4;
				while ((num4 = reader.Read(array3, 0, System.Math.Min(array3.Length, num3 - num2))) > 0)
				{
					Buffer.BlockCopy(array3, 0, array2, num2, num4);
					num2 += num4;
				}
			}
			return new SingleChannelByteCubemapDataSampler(array, num);
		}

		public float SampleBicubic(Vector3d normal, float[][] preallocatedArray)
		{
			GetCubeFaceAndPosition(normal, out var faceData, out var facePosition);
			return SampleBicubic(faceData, (float)facePosition.x, (float)facePosition.y, preallocatedArray);
		}

		public float SampleBilinear(Vector3d normal)
		{
			GetCubeFaceAndPosition(normal, out var faceData, out var facePosition);
			return SampleBilinear(faceData, (float)facePosition.x, (float)facePosition.y);
		}

		public void Save(BinaryWriter writer)
		{
			writer.Write(_faceSize);
			byte[] array = new byte[16384];
			for (int i = 0; i < 6; i++)
			{
				int j = 0;
				int num2;
				for (int num = _data[i].Length; j < num; j += num2)
				{
					num2 = System.Math.Min(array.Length, num - j);
					Buffer.BlockCopy(_data[i], j, array, 0, num2);
					writer.Write(array, 0, num2);
				}
			}
		}

		private static float CubicInterpolate(float[] p, float x)
		{
			return p[1] + 0.5f * x * (p[2] - p[0] + x * (2f * p[0] - 5f * p[1] + 4f * p[2] - p[3] + x * (3f * (p[1] - p[2]) + p[3] - p[0])));
		}

		private void FixupSeam(byte[] dataA, int pixelA, int incrementA, byte[] dataB, int pixelB, int incrementB)
		{
			dataA[pixelA] = (dataB[pixelB] = (byte)((dataA[pixelA] + dataB[pixelB]) / 2));
			dataA[pixelA + incrementA] = dataB[pixelB - incrementB];
			dataA[pixelA + incrementA + incrementA] = dataB[pixelB - incrementB - incrementB];
			dataB[pixelB + incrementB] = dataA[pixelA - incrementA];
			dataB[pixelB + incrementB + incrementB] = dataA[pixelA - incrementA - incrementA];
		}

		private void FixupSeamCornerPoint(byte[] dataA, int pixelA, byte[] dataB, int pixelB, byte[] dataC, int pixelC)
		{
			dataC[pixelC] = (dataB[pixelB] = (dataA[pixelA] = (byte)Mathf.Clamp((dataA[pixelA] + dataB[pixelB] + dataC[pixelC]) / 3, 0, 255)));
		}

		private void FixupSeamCorningPadding(byte[] data)
		{
			int num = 2;
			int num2 = _faceSizePadded - 3;
			int faceSize = _faceSizePadded;
			int faceSize2 = faceSize + faceSize;
			FixCorner(0, faceSize2 + num);
			FixCorner(num2, faceSize2 + num2);
			FixCorner(num2 * faceSize, num2 * faceSize + num);
			FixCorner(num2 * faceSize + num2, num2 * faceSize + num2);
			void FixCorner(int startIndex, int valueIndex)
			{
				byte b = data[valueIndex];
				for (int i = 0; i <= faceSize2; i += faceSize)
				{
					for (int j = 0; j <= 2; j++)
					{
						data[startIndex + i + j] = b;
					}
				}
			}
		}

		private void FixupSeams()
		{
			byte[] array = _data[0];
			byte[] array2 = _data[1];
			byte[] array3 = _data[2];
			byte[] array4 = _data[3];
			byte[] array5 = _data[4];
			byte[] array6 = _data[5];
			int num = 2;
			int num2 = _faceSizePadded - 3;
			int faceSizePadded = _faceSizePadded;
			FixupSeamCornerPoint(array, num2 * faceSizePadded + num, array5, num2 * faceSizePadded + num2, array3, num * faceSizePadded + num2);
			FixupSeamCornerPoint(array, num * faceSizePadded + num, array5, num * faceSizePadded + num2, array4, num2 * faceSizePadded + num2);
			FixupSeamCornerPoint(array5, num2 * faceSizePadded + num, array2, num2 * faceSizePadded + num2, array3, num * faceSizePadded + num);
			FixupSeamCornerPoint(array5, num * faceSizePadded + num, array2, num * faceSizePadded + num2, array4, num2 * faceSizePadded + num);
			FixupSeamCornerPoint(array2, num2 * faceSizePadded + num, array6, num2 * faceSizePadded + num2, array3, num2 * faceSizePadded + num);
			FixupSeamCornerPoint(array2, num * faceSizePadded + num, array6, num * faceSizePadded + num2, array4, num * faceSizePadded + num);
			FixupSeamCornerPoint(array6, num2 * faceSizePadded + num, array, num2 * faceSizePadded + num2, array3, num2 * faceSizePadded + num2);
			FixupSeamCornerPoint(array6, num * faceSizePadded + num, array, num * faceSizePadded + num2, array4, num * faceSizePadded + num2);
			for (int i = num; i <= num2; i++)
			{
				int num3 = i * faceSizePadded;
				FixupSeam(array5, num3 + num2, 1, array, num3 + num, -1);
				FixupSeam(array, num3 + num2, 1, array6, num3 + num, -1);
				FixupSeam(array6, num3 + num2, 1, array2, num3 + num, -1);
				FixupSeam(array2, num3 + num2, 1, array5, num3 + num, -1);
			}
			for (int j = num; j <= num2; j++)
			{
				int num4 = faceSizePadded - 1 - j;
				FixupSeam(array2, num2 * faceSizePadded + j, faceSizePadded, array3, num4 * faceSizePadded + num, -1);
				FixupSeam(array2, num * faceSizePadded + j, -faceSizePadded, array4, j * faceSizePadded + num, -1);
				FixupSeam(array, num2 * faceSizePadded + num4, faceSizePadded, array3, num4 * faceSizePadded + num2, 1);
				FixupSeam(array, num * faceSizePadded + num4, -faceSizePadded, array4, j * faceSizePadded + num2, 1);
				FixupSeam(array6, num2 * faceSizePadded + j, faceSizePadded, array3, num2 * faceSizePadded + num4, faceSizePadded);
				FixupSeam(array5, num2 * faceSizePadded + j, faceSizePadded, array3, num * faceSizePadded + j, -faceSizePadded);
				FixupSeam(array6, num * faceSizePadded + j, -faceSizePadded, array4, num * faceSizePadded + num4, -faceSizePadded);
				FixupSeam(array5, num * faceSizePadded + j, -faceSizePadded, array4, num2 * faceSizePadded + j, faceSizePadded);
			}
			FixupSeamCorningPadding(array);
			FixupSeamCorningPadding(array2);
			FixupSeamCorningPadding(array3);
			FixupSeamCorningPadding(array4);
			FixupSeamCorningPadding(array5);
			FixupSeamCorningPadding(array6);
		}

		private void GetCubeFaceAndPosition(Vector3d position, out byte[] faceData, out Vector2d facePosition)
		{
			double num = ((position.x >= 0.0) ? position.x : (0.0 - position.x));
			double num2 = ((position.y >= 0.0) ? position.y : (0.0 - position.y));
			double num3 = ((position.z >= 0.0) ? position.z : (0.0 - position.z));
			if (num > num2)
			{
				if (num > num3)
				{
					double num4 = num * 2.0;
					if (position.x > 0.0)
					{
						faceData = _data[0];
						facePosition = new Vector2d((0.0 - position.z) / num4 + 0.5, position.y / num4 + 0.5);
					}
					else
					{
						faceData = _data[1];
						facePosition = new Vector2d(position.z / num4 + 0.5, position.y / num4 + 0.5);
					}
				}
				else
				{
					double num5 = num3 * 2.0;
					if (position.z > 0.0)
					{
						faceData = _data[4];
						facePosition = new Vector2d(position.x / num5 + 0.5, position.y / num5 + 0.5);
					}
					else
					{
						faceData = _data[5];
						facePosition = new Vector2d((0.0 - position.x) / num5 + 0.5, position.y / num5 + 0.5);
					}
				}
			}
			else if (num2 > num3)
			{
				double num6 = num2 * 2.0;
				if (position.y > 0.0)
				{
					faceData = _data[2];
					facePosition = new Vector2d(position.x / num6 + 0.5, (0.0 - position.z) / num6 + 0.5);
				}
				else
				{
					faceData = _data[3];
					facePosition = new Vector2d(position.x / num6 + 0.5, position.z / num6 + 0.5);
				}
			}
			else
			{
				double num7 = num3 * 2.0;
				if (position.z > 0.0)
				{
					faceData = _data[4];
					facePosition = new Vector2d(position.x / num7 + 0.5, position.y / num7 + 0.5);
				}
				else
				{
					faceData = _data[5];
					facePosition = new Vector2d((0.0 - position.x) / num7 + 0.5, position.y / num7 + 0.5);
				}
			}
		}

		private float SampleBicubic(byte[] faceData, float u, float v, float[][] preallocatedArray)
		{
			float num = u * (float)_faceSizeMinusOne + 3f;
			float num2 = v * (float)_faceSizeMinusOne + 3f;
			int num3 = (int)num;
			int num4 = (int)num2;
			float x = num - (float)num3;
			float x2 = num2 - (float)num4;
			int num5 = (num4 - 2) * _faceSizePadded + (num3 - 2);
			int num6 = num5 + _faceSizePadded;
			int num7 = num6 + _faceSizePadded;
			int num8 = num7 + _faceSizePadded;
			preallocatedArray[0][0] = 0.003921569f * (float)(int)faceData[num5];
			preallocatedArray[1][0] = 0.003921569f * (float)(int)faceData[num5 + 1];
			preallocatedArray[2][0] = 0.003921569f * (float)(int)faceData[num5 + 2];
			preallocatedArray[3][0] = 0.003921569f * (float)(int)faceData[num5 + 3];
			preallocatedArray[0][1] = 0.003921569f * (float)(int)faceData[num6];
			preallocatedArray[1][1] = 0.003921569f * (float)(int)faceData[num6 + 1];
			preallocatedArray[2][1] = 0.003921569f * (float)(int)faceData[num6 + 2];
			preallocatedArray[3][1] = 0.003921569f * (float)(int)faceData[num6 + 3];
			preallocatedArray[0][2] = 0.003921569f * (float)(int)faceData[num7];
			preallocatedArray[1][2] = 0.003921569f * (float)(int)faceData[num7 + 1];
			preallocatedArray[2][2] = 0.003921569f * (float)(int)faceData[num7 + 2];
			preallocatedArray[3][2] = 0.003921569f * (float)(int)faceData[num7 + 3];
			preallocatedArray[0][3] = 0.003921569f * (float)(int)faceData[num8];
			preallocatedArray[1][3] = 0.003921569f * (float)(int)faceData[num8 + 1];
			preallocatedArray[2][3] = 0.003921569f * (float)(int)faceData[num8 + 2];
			preallocatedArray[3][3] = 0.003921569f * (float)(int)faceData[num8 + 3];
			float[] obj = preallocatedArray[4];
			obj[0] = CubicInterpolate(preallocatedArray[0], x2);
			obj[1] = CubicInterpolate(preallocatedArray[1], x2);
			obj[2] = CubicInterpolate(preallocatedArray[2], x2);
			obj[3] = CubicInterpolate(preallocatedArray[3], x2);
			return CubicInterpolate(obj, x);
		}

		private float SampleBilinear(byte[] faceData, float u, float v)
		{
			float num = u * (float)_faceSizeMinusOne + 3f;
			float num2 = v * (float)_faceSizeMinusOne + 3f;
			int num3 = (int)num;
			int num4 = (int)num2;
			float num5 = num - (float)num3;
			float num6 = num2 - (float)num4;
			float num7 = 1f - num5;
			float num8 = 1f - num6;
			int num9 = (num4 - 1) * _faceSizePadded + (num3 - 1);
			int num10 = num9 + 1;
			int num11 = num9 + _faceSizePadded;
			int num12 = num11 + 1;
			return ((float)(int)faceData[num9] * 0.003921569f * num7 + (float)(int)faceData[num10] * 0.003921569f * num5) * num8 + ((float)(int)faceData[num11] * 0.003921569f * num7 + (float)(int)faceData[num12] * 0.003921569f * num5) * num6;
		}

		private void SaveDebugTexture()
		{
			int faceSizePadded = _faceSizePadded;
			Texture2D texture2D = new Texture2D(faceSizePadded * 6, faceSizePadded, TextureFormat.RGB24, mipChain: false, linear: true);
			NativeArray<ColorRGB24> rawTextureData = texture2D.GetRawTextureData<ColorRGB24>();
			for (int i = 0; i < 6; i++)
			{
				byte[] array = _data[i];
				for (int j = 0; j < faceSizePadded; j++)
				{
					int num = j * faceSizePadded * 6;
					for (int k = 0; k < faceSizePadded; k++)
					{
						int num2 = i * faceSizePadded + k;
						byte b = array[j * faceSizePadded + k];
						rawTextureData[num + num2] = new ColorRGB24(b, b, b);
					}
				}
			}
			byte[] bytes = texture2D.EncodeToPNG();
			File.WriteAllBytes("C:\\Temp\\CubemapSeamDebug.png", bytes);
		}
	}
}
