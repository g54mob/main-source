using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal interface IRawEncoder
	{
		byte[] Encode(ReadOnlyMemory<ColorRgba32> pixels);

		GlInternalFormat GetInternalFormat();

		GlFormat GetBaseInternalFormat();

		GlFormat GetGlFormat();

		GlType GetGlType();

		uint GetGlTypeSize();

		DxgiFormat GetDxgiFormat();
	}
}
