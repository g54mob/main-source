using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class RawRgEncoder : IRawEncoder
	{
		public byte[] Encode(ReadOnlyMemory<ColorRgba32> pixels)
		{
			ReadOnlySpan<ColorRgba32> span = pixels.Span;
			byte[] array = new byte[pixels.Length * 2];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i * 2] = span[i].r;
				array[i * 2 + 1] = span[i].g;
			}
			return array;
		}

		public GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlRg8;
		}

		public GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRg;
		}

		public GlFormat GetGlFormat()
		{
			return GlFormat.GlRg;
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
			return DxgiFormat.DxgiFormatR8G8Unorm;
		}
	}
}
