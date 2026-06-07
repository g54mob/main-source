using System;
using System.IO;
using UnityEngine;

namespace ModApi.Planet.Modifiers.Common
{
	public class SingleChannelByteTextureDataSampler : ISingleChannelTextureDataSampler
	{
		private byte[] _data;

		private int _height;

		private int _heightMinusOne;

		private int _paddedHeight;

		private int _paddedWidth;

		private int _width;

		private int _widthMinusOne;

		public SingleChannelByteTextureDataSampler(Texture2D texture, int colorChannel)
			: this(texture.GetPixels32(), colorChannel, texture.width, texture.height)
		{
		}

		public SingleChannelByteTextureDataSampler(Color32[] colors, int colorChannel, int width, int height)
		{
			_width = width;
			_height = height;
			_widthMinusOne = width - 1;
			_heightMinusOne = height - 1;
			_paddedWidth = width + 4;
			_paddedHeight = height + 4;
			_data = new byte[_paddedWidth * _paddedHeight];
			for (int i = 0; i < _paddedHeight; i++)
			{
				int num = Mathf.Clamp(i - 2, 0, _heightMinusOne);
				for (int j = 0; j < _paddedWidth; j++)
				{
					int num2 = Mathf.Clamp(j - 2, 0, _widthMinusOne);
					int num3 = i * _paddedWidth + j;
					int num4 = num * width + num2;
					switch (colorChannel)
					{
					case 0:
						_data[num3] = colors[num4].r;
						break;
					case 1:
						_data[num3] = colors[num4].g;
						break;
					case 2:
						_data[num3] = colors[num4].b;
						break;
					case 3:
						_data[num3] = colors[num4].a;
						break;
					default:
						throw new NotSupportedException();
					}
				}
			}
		}

		private SingleChannelByteTextureDataSampler(byte[] data, int width, int height)
		{
			_width = width;
			_height = height;
			_widthMinusOne = width - 1;
			_heightMinusOne = height - 1;
			_paddedWidth = width + 4;
			_paddedHeight = height + 4;
			_data = data;
		}

		public static SingleChannelByteTextureDataSampler Load(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			int num2 = reader.ReadInt32();
			byte[] array = new byte[(num + 4) * (num2 + 4)];
			int num3 = 0;
			int num4 = array.Length;
			byte[] array2 = new byte[16384];
			int num5;
			while ((num5 = reader.Read(array2, 0, System.Math.Min(array2.Length, num4 - num3))) > 0)
			{
				Buffer.BlockCopy(array2, 0, array, num3, num5);
				num3 += num5;
			}
			return new SingleChannelByteTextureDataSampler(array, num, num2);
		}

		public float SampleBicubic(float u, float v, float[][] preallocatedArray)
		{
			float num = u * (float)_widthMinusOne + 3f;
			float num2 = v * (float)_heightMinusOne + 3f;
			int num3 = (int)num;
			int num4 = (int)num2;
			float x = num - (float)num3;
			float x2 = num2 - (float)num4;
			int num5 = (num4 - 2) * _paddedWidth + (num3 - 2);
			int num6 = num5 + _paddedWidth;
			int num7 = num6 + _paddedWidth;
			int num8 = num7 + _paddedWidth;
			preallocatedArray[0][0] = 0.003921569f * (float)(int)_data[num5];
			preallocatedArray[1][0] = 0.003921569f * (float)(int)_data[num5 + 1];
			preallocatedArray[2][0] = 0.003921569f * (float)(int)_data[num5 + 2];
			preallocatedArray[3][0] = 0.003921569f * (float)(int)_data[num5 + 3];
			preallocatedArray[0][1] = 0.003921569f * (float)(int)_data[num6];
			preallocatedArray[1][1] = 0.003921569f * (float)(int)_data[num6 + 1];
			preallocatedArray[2][1] = 0.003921569f * (float)(int)_data[num6 + 2];
			preallocatedArray[3][1] = 0.003921569f * (float)(int)_data[num6 + 3];
			preallocatedArray[0][2] = 0.003921569f * (float)(int)_data[num7];
			preallocatedArray[1][2] = 0.003921569f * (float)(int)_data[num7 + 1];
			preallocatedArray[2][2] = 0.003921569f * (float)(int)_data[num7 + 2];
			preallocatedArray[3][2] = 0.003921569f * (float)(int)_data[num7 + 3];
			preallocatedArray[0][3] = 0.003921569f * (float)(int)_data[num8];
			preallocatedArray[1][3] = 0.003921569f * (float)(int)_data[num8 + 1];
			preallocatedArray[2][3] = 0.003921569f * (float)(int)_data[num8 + 2];
			preallocatedArray[3][3] = 0.003921569f * (float)(int)_data[num8 + 3];
			float[] obj = preallocatedArray[4];
			obj[0] = CubicInterpolate(preallocatedArray[0], x2);
			obj[1] = CubicInterpolate(preallocatedArray[1], x2);
			obj[2] = CubicInterpolate(preallocatedArray[2], x2);
			obj[3] = CubicInterpolate(preallocatedArray[3], x2);
			return CubicInterpolate(obj, x);
		}

		public float SampleBilinear(float u, float v)
		{
			float num = u * (float)_widthMinusOne + 3f;
			float num2 = v * (float)_heightMinusOne + 3f;
			int num3 = (int)num;
			int num4 = (int)num2;
			float num5 = num - (float)num3;
			float num6 = num2 - (float)num4;
			float num7 = 1f - num5;
			float num8 = 1f - num6;
			int num9 = (num4 - 1) * _paddedWidth + (num3 - 1);
			int num10 = num9 + 1;
			int num11 = num9 + _paddedWidth;
			int num12 = num11 + 1;
			return ((float)(int)_data[num9] * 0.003921569f * num7 + (float)(int)_data[num10] * 0.003921569f * num5) * num8 + ((float)(int)_data[num11] * 0.003921569f * num7 + (float)(int)_data[num12] * 0.003921569f * num5) * num6;
		}

		public void Save(BinaryWriter writer)
		{
			writer.Write(_width);
			writer.Write(_height);
			int i = 0;
			int num = _data.Length;
			byte[] array = new byte[16384];
			int num2;
			for (; i < num; i += num2)
			{
				num2 = System.Math.Min(array.Length, num - i);
				Buffer.BlockCopy(_data, i, array, 0, num2);
				writer.Write(array, 0, num2);
			}
		}

		private static float CubicInterpolate(float[] p, float x)
		{
			return p[1] + 0.5f * x * (p[2] - p[0] + x * (2f * p[0] - 5f * p[1] + 4f * p[2] - p[3] + x * (3f * (p[1] - p[2]) + p[3] - p[0])));
		}
	}
}
