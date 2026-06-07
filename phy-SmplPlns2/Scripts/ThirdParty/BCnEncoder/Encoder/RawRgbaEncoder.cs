using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class RawRgbaEncoder : IRawEncoder
	{
		public byte[] Encode(ReadOnlyMemory<ColorRgba32> pixels)
		{
			ReadOnlySpan<ColorRgba32> span = pixels.Span;
			byte[] array = new byte[pixels.Length * 4];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i * 4] = span[i].r;
				array[i * 4 + 1] = span[i].g;
				array[i * 4 + 2] = span[i].b;
				array[i * 4 + 3] = span[i].a;
			}
			return array;
		}

		public GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlRgba8;
		}

		public GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public GlFormat GetGlFormat()
		{
			return GlFormat.GlRgba;
		}

		public GlType GetGlType()
		{
			return GlType.GlByte;
		}

		public uint GetGlTypeSize()
		{
			return 1u;
		}

		public DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatR8G8B8A8Unorm;
		}
	}
}
