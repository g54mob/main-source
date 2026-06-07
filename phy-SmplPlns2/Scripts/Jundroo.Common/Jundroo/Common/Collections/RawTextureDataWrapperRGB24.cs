using System;
using Jundroo.Common.DataTypes;
using Unity.Collections;
using UnityEngine;

namespace Jundroo.Common.Collections
{
	public abstract class RawTextureDataWrapperRGB24
	{
		private class Color32Wrapper : RawTextureDataWrapperRGB24
		{
			private NativeArray<Color32> _array;

			public override ColorRGB24 this[int index]
			{
				get
				{
					Color32 color = _array[index];
					return new ColorRGB24(color.r, color.g, color.b);
				}
				set
				{
					_array[index] = new Color32(value.r, value.g, value.b, byte.MaxValue);
				}
			}

			public Color32Wrapper(Texture2D texture)
			{
				_array = texture.GetRawTextureData<Color32>();
			}

			public override byte Alpha(int index)
			{
				return _array[index].a;
			}

			public override byte Blue(int index)
			{
				return _array[index].b;
			}

			public override byte Green(int index)
			{
				return _array[index].g;
			}

			public override byte Red(int index)
			{
				return _array[index].r;
			}
		}

		private class ColorARGB32Wrapper : RawTextureDataWrapperRGB24
		{
			private NativeArray<ColorARGB32> _array;

			public override ColorRGB24 this[int index]
			{
				get
				{
					ColorARGB32 colorARGB = _array[index];
					return new ColorRGB24(colorARGB.r, colorARGB.g, colorARGB.b);
				}
				set
				{
					_array[index] = new ColorARGB32(byte.MaxValue, value.r, value.g, value.b);
				}
			}

			public ColorARGB32Wrapper(Texture2D texture)
			{
				_array = texture.GetRawTextureData<ColorARGB32>();
			}

			public override byte Alpha(int index)
			{
				return _array[index].a;
			}

			public override byte Blue(int index)
			{
				return _array[index].b;
			}

			public override byte Green(int index)
			{
				return _array[index].g;
			}

			public override byte Red(int index)
			{
				return _array[index].r;
			}
		}

		private class ColorRGB24Wrapper : RawTextureDataWrapperRGB24
		{
			private NativeArray<ColorRGB24> _array;

			public override ColorRGB24 this[int index]
			{
				get
				{
					return _array[index];
				}
				set
				{
					_array[index] = value;
				}
			}

			public ColorRGB24Wrapper(Texture2D texture)
			{
				_array = texture.GetRawTextureData<ColorRGB24>();
			}

			public override byte Alpha(int index)
			{
				return byte.MaxValue;
			}

			public override byte Blue(int index)
			{
				return _array[index].b;
			}

			public override byte Green(int index)
			{
				return _array[index].g;
			}

			public override byte Red(int index)
			{
				return _array[index].r;
			}
		}

		public abstract ColorRGB24 this[int index] { get; set; }

		public static RawTextureDataWrapperRGB24 Create(Texture2D texture)
		{
			return texture.format switch
			{
				TextureFormat.RGBA32 => new Color32Wrapper(texture), 
				TextureFormat.ARGB32 => new ColorARGB32Wrapper(texture), 
				TextureFormat.RGB24 => new ColorRGB24Wrapper(texture), 
				_ => throw new NotSupportedException($"Texture format '{texture.format}' not supported"), 
			};
		}

		public abstract byte Alpha(int index);

		public abstract byte Blue(int index);

		public abstract byte Green(int index);

		public abstract byte Red(int index);
	}
}
