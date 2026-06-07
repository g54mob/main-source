using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class RawRgbEncoder : IRawEncoder
	{
		public byte[] Encode(ReadOnlyMemory<ColorRgba32> pixels)
		{
			ReadOnlySpan<ColorRgba32> span = pixels.Span;
			byte[] array = new byte[pixels.Length * 3];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i * 3] = span[i].r;
				array[i * 3 + 1] = span[i].g;
				array[i * 3 + 2] = span[i].b;
			}
			return array;
		}

		public GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlRgb8;
		}

		public GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgb;
		}

		public GlFormat GetGlFormat()
		{
			return GlFormat.GlRgb;
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
			throw new NotSupportedException("RGB Format is not supported for dds files.");
		}
	}
}
