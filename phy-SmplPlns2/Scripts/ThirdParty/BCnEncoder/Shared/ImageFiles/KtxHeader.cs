using System;

namespace BCnEncoder.Shared.ImageFiles
{
	public struct KtxHeader
	{
		public unsafe fixed byte Identifier[12];

		public uint Endianness;

		public GlType GlType;

		public uint GlTypeSize;

		public GlFormat GlFormat;

		public GlInternalFormat GlInternalFormat;

		public GlFormat GlBaseInternalFormat;

		public uint PixelWidth;

		public uint PixelHeight;

		public uint PixelDepth;

		public uint NumberOfArrayElements;

		public uint NumberOfFaces;

		public uint NumberOfMipmapLevels;

		public uint BytesOfKeyValueData;

		public unsafe bool VerifyHeader()
		{
			Span<byte> span = stackalloc byte[12]
			{
				171, 75, 84, 88, 32, 49, 49, 187, 13, 10,
				26, 10
			};
			for (int i = 0; i < span.Length; i++)
			{
				if (Identifier[i] != span[i])
				{
					return false;
				}
			}
			return true;
		}

		public unsafe static KtxHeader InitializeCompressed(int width, int height, GlInternalFormat internalFormat, GlFormat baseInternalFormat)
		{
			KtxHeader result = default(KtxHeader);
			Span<byte> span = stackalloc byte[12]
			{
				171, 75, 84, 88, 32, 49, 49, 187, 13, 10,
				26, 10
			};
			for (int i = 0; i < span.Length; i++)
			{
				result.Identifier[i] = span[i];
			}
			result.Endianness = 67305985u;
			result.PixelWidth = (uint)width;
			result.PixelHeight = (uint)height;
			result.GlType = (GlType)0u;
			result.GlTypeSize = 1u;
			result.GlFormat = (GlFormat)0u;
			result.GlInternalFormat = internalFormat;
			result.GlBaseInternalFormat = baseInternalFormat;
			return result;
		}

		public unsafe static KtxHeader InitializeUncompressed(int width, int height, GlType type, GlFormat format, uint glTypeSize, GlInternalFormat internalFormat, GlFormat baseInternalFormat)
		{
			KtxHeader result = default(KtxHeader);
			Span<byte> span = stackalloc byte[12]
			{
				171, 75, 84, 88, 32, 49, 49, 187, 13, 10,
				26, 10
			};
			for (int i = 0; i < span.Length; i++)
			{
				result.Identifier[i] = span[i];
			}
			result.Endianness = 67305985u;
			result.PixelWidth = (uint)width;
			result.PixelHeight = (uint)height;
			result.GlType = type;
			result.GlTypeSize = glTypeSize;
			result.GlFormat = format;
			result.GlInternalFormat = internalFormat;
			result.GlBaseInternalFormat = baseInternalFormat;
			return result;
		}
	}
}
