using System;
using System.IO;

namespace QRCoder
{
	public sealed class PngByteQRCode : AbstractQRCode, IDisposable
	{
		private sealed class PngBuilder : IDisposable
		{
			public enum ColorType : byte
			{
				Greyscale = 0,
				Indexed = 3
			}

			private static readonly byte[] PngSignature;

			private static readonly uint[] CrcTable;

			private static readonly byte[] IHDR;

			private static readonly byte[] IDAT;

			private static readonly byte[] IEND;

			private static readonly byte[] PLTE;

			private static readonly byte[] tRNS;

			private MemoryStream stream;

			public void Dispose()
			{
			}

			public byte[] GetBytes()
			{
				return null;
			}

			public void WriteHeader(int width, int height, byte bitDepth, ColorType colorType)
			{
			}

			public void WritePalette(params byte[][] rgbaColors)
			{
			}

			public void WriteScanlines(byte[] scanlines)
			{
			}

			public void WriteEnd()
			{
			}

			private void WriteChunkStart(byte[] type, int length)
			{
			}

			private void WriteChunkEnd()
			{
			}

			private void WriteIntBigEndian(uint value)
			{
			}

			private static void Deflate(Stream output, byte[] bytes)
			{
			}

			private static uint Adler32(byte[] data, int index, int length)
			{
				return 0u;
			}

			private static uint Crc32(byte[] data, int index, int length)
			{
				return 0u;
			}
		}

		public PngByteQRCode()
		{
		}

		public PngByteQRCode(QRCodeData data)
		{
		}

		public byte[] GetGraphic(int pixelsPerModule, bool drawQuietZones = true)
		{
			return null;
		}

		public byte[] GetGraphic(int pixelsPerModule, byte[] darkColorRgba, byte[] lightColorRgba, bool drawQuietZones = true)
		{
			return null;
		}

		private byte[] DrawScanlines(int pixelsPerModule, bool drawQuietZones)
		{
			return null;
		}
	}
}
