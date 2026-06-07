using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class RawLuminanceEncoder : IRawEncoder
	{
		private readonly bool useLuminance;

		public RawLuminanceEncoder(bool useLuminance)
		{
			this.useLuminance = useLuminance;
		}

		public byte[] Encode(ReadOnlyMemory<ColorRgba32> pixels)
		{
			ReadOnlySpan<ColorRgba32> span = pixels.Span;
			byte[] array = new byte[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				if (useLuminance)
				{
					array[i] = (byte)(new ColorYCbCr(span[i]).y * 255f);
				}
				else
				{
					array[i] = span[i].r;
				}
			}
			return array;
		}

		public GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlR8;
		}

		public GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRed;
		}

		public GlFormat GetGlFormat()
		{
			return GlFormat.GlRed;
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
			return DxgiFormat.DxgiFormatR8Unorm;
		}
	}
}
