using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BCnEncoder.Encoder.Bptc;
using BCnEncoder.Encoder.Options;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;
using CommunityToolkit.HighPerformance;

namespace BCnEncoder.Encoder
{
	public class BcEncoder
	{
		public EncoderInputOptions InputOptions { get; } = new EncoderInputOptions();

		public EncoderOutputOptions OutputOptions { get; } = new EncoderOutputOptions();

		public EncoderOptions Options { get; } = new EncoderOptions();

		public BcEncoder(CompressionFormat format = CompressionFormat.Bc1)
		{
			OutputOptions.Format = format;
		}

		public Task EncodeToStreamAsync(ReadOnlyMemory<byte> input, int width, int height, PixelFormat format, Stream outputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				EncodeToStreamInternal(ByteToColorMemory(input.Span, width, height, format), outputStream, token);
			}, token);
		}

		public Task EncodeToStreamAsync(ReadOnlyMemory2D<ColorRgba32> input, Stream outputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				EncodeToStreamInternal(input, outputStream, default(CancellationToken));
			}, token);
		}

		public Task<KtxFile> EncodeToKtxAsync(ReadOnlyMemory<byte> input, int width, int height, PixelFormat format, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToKtxInternal(ByteToColorMemory(input.Span, width, height, format), token), token);
		}

		public Task<KtxFile> EncodeToKtxAsync(ReadOnlyMemory2D<ColorRgba32> input, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToKtxInternal(input, token), token);
		}

		public Task<DdsFile> EncodeToDdsAsync(ReadOnlyMemory<byte> input, int width, int height, PixelFormat format, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToDdsInternal(ByteToColorMemory(input.Span, width, height, format), token), token);
		}

		public Task<DdsFile> EncodeToDdsAsync(ReadOnlyMemory2D<ColorRgba32> input, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToDdsInternal(input, token), token);
		}

		public Task<byte[][]> EncodeToRawBytesAsync(ReadOnlyMemory<byte> input, int width, int height, PixelFormat format, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToRawInternal(ByteToColorMemory(input.Span, width, height, format), token), token);
		}

		public Task<byte[][]> EncodeToRawBytesAsync(ReadOnlyMemory2D<ColorRgba32> input, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToRawInternal(input, token), token);
		}

		public Task<byte[]> EncodeToRawBytesAsync(ReadOnlyMemory<byte> input, int width, int height, PixelFormat format, int mipLevel, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToRawInternal(ByteToColorMemory(input.Span, width, height, format), mipLevel, out var _, out var _, token), token);
		}

		public Task<byte[]> EncodeToRawBytesAsync(ReadOnlyMemory2D<ColorRgba32> input, int mipLevel, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToRawInternal(input, mipLevel, out var _, out var _, token), token);
		}

		public Task EncodeCubeMapToStreamAsync(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, Stream outputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				EncodeCubeMapToStreamInternal(right, left, top, down, back, front, outputStream, token);
			}, token);
		}

		public Task<KtxFile> EncodeCubeMapToKtxAsync(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeCubeMapToKtxInternal(right, left, top, down, back, front, token), token);
		}

		public Task<DdsFile> EncodeCubeMapToDdsAsync(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeCubeMapToDdsInternal(right, left, top, down, back, front, token), token);
		}

		public void EncodeToStream(ReadOnlySpan<byte> input, int width, int height, PixelFormat format, Stream outputStream)
		{
			EncodeToStream(ByteToColorMemory(input, width, height, format), outputStream);
		}

		public void EncodeToStream(ReadOnlyMemory2D<ColorRgba32> input, Stream outputStream)
		{
			EncodeToStreamInternal(input, outputStream, default(CancellationToken));
		}

		public KtxFile EncodeToKtx(ReadOnlySpan<byte> input, int width, int height, PixelFormat format)
		{
			return EncodeToKtx(ByteToColorMemory(input, width, height, format));
		}

		public KtxFile EncodeToKtx(ReadOnlyMemory2D<ColorRgba32> input)
		{
			return EncodeToKtxInternal(input, default(CancellationToken));
		}

		public DdsFile EncodeToDds(ReadOnlySpan<byte> input, int width, int height, PixelFormat format)
		{
			return EncodeToDds(ByteToColorMemory(input, width, height, format));
		}

		public DdsFile EncodeToDds(ReadOnlyMemory2D<ColorRgba32> input)
		{
			return EncodeToDdsInternal(input, default(CancellationToken));
		}

		public byte[][] EncodeToRawBytes(ReadOnlySpan<byte> input, int width, int height, PixelFormat format)
		{
			return EncodeToRawBytes(ByteToColorMemory(input, width, height, format));
		}

		public byte[][] EncodeToRawBytes(ReadOnlyMemory2D<ColorRgba32> input)
		{
			return EncodeToRawInternal(input, default(CancellationToken));
		}

		public byte[] EncodeToRawBytes(ReadOnlySpan<byte> input, int width, int height, PixelFormat format, int mipLevel, out int mipWidth, out int mipHeight)
		{
			return EncodeToRawInternal(ByteToColorMemory(input, width, height, format), mipLevel, out mipWidth, out mipHeight, default(CancellationToken));
		}

		public byte[] EncodeToRawBytes(ReadOnlyMemory2D<ColorRgba32> input, int mipLevel, out int mipWidth, out int mipHeight)
		{
			return EncodeToRawInternal(input, mipLevel, out mipWidth, out mipHeight, default(CancellationToken));
		}

		public void EncodeCubeMapToStream(ReadOnlySpan<byte> right, ReadOnlySpan<byte> left, ReadOnlySpan<byte> top, ReadOnlySpan<byte> down, ReadOnlySpan<byte> back, ReadOnlySpan<byte> front, int width, int height, PixelFormat format, Stream outputStream)
		{
			EncodeCubeMapToStreamInternal(ByteToColorMemory(right, width, height, format), ByteToColorMemory(left, width, height, format), ByteToColorMemory(top, width, height, format), ByteToColorMemory(down, width, height, format), ByteToColorMemory(back, width, height, format), ByteToColorMemory(front, width, height, format), outputStream, default(CancellationToken));
		}

		public void EncodeCubeMapToStream(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, Stream outputStream)
		{
			EncodeCubeMapToStreamInternal(right, left, top, down, back, front, outputStream, default(CancellationToken));
		}

		public KtxFile EncodeCubeMapToKtx(ReadOnlySpan<byte> right, ReadOnlySpan<byte> left, ReadOnlySpan<byte> top, ReadOnlySpan<byte> down, ReadOnlySpan<byte> back, ReadOnlySpan<byte> front, int width, int height, PixelFormat format)
		{
			return EncodeCubeMapToKtxInternal(ByteToColorMemory(right, width, height, format), ByteToColorMemory(left, width, height, format), ByteToColorMemory(top, width, height, format), ByteToColorMemory(down, width, height, format), ByteToColorMemory(back, width, height, format), ByteToColorMemory(front, width, height, format), default(CancellationToken));
		}

		public KtxFile EncodeCubeMapToKtx(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front)
		{
			return EncodeCubeMapToKtxInternal(right, left, top, down, back, front, default(CancellationToken));
		}

		public DdsFile EncodeCubeMapToDds(ReadOnlySpan<byte> right, ReadOnlySpan<byte> left, ReadOnlySpan<byte> top, ReadOnlySpan<byte> down, ReadOnlySpan<byte> back, ReadOnlySpan<byte> front, int width, int height, PixelFormat format)
		{
			return EncodeCubeMapToDdsInternal(ByteToColorMemory(right, width, height, format), ByteToColorMemory(left, width, height, format), ByteToColorMemory(top, width, height, format), ByteToColorMemory(down, width, height, format), ByteToColorMemory(back, width, height, format), ByteToColorMemory(front, width, height, format), default(CancellationToken));
		}

		public DdsFile EncodeCubeMapToDds(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front)
		{
			return EncodeCubeMapToDdsInternal(right, left, top, down, back, front, default(CancellationToken));
		}

		public byte[] EncodeBlock(ReadOnlySpan<ColorRgba32> inputBlock)
		{
			if (inputBlock.Length != 16)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			return EncodeBlockInternal(inputBlock.AsSpan2D(4, 4));
		}

		public byte[] EncodeBlock(ReadOnlySpan2D<ColorRgba32> inputBlock)
		{
			if (inputBlock.Width != 4 || inputBlock.Height != 4)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			return EncodeBlockInternal(inputBlock);
		}

		public void EncodeBlock(ReadOnlySpan<ColorRgba32> inputBlock, Stream outputStream)
		{
			if (inputBlock.Length != 16)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			EncodeBlockInternal(inputBlock.AsSpan2D(4, 4), outputStream);
		}

		public void EncodeBlock(ReadOnlySpan2D<ColorRgba32> inputBlock, Stream outputStream)
		{
			if (inputBlock.Width != 4 || inputBlock.Height != 4)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			EncodeBlockInternal(inputBlock, outputStream);
		}

		public int GetBlockSize()
		{
			return GetRgba32BlockEncoder(OutputOptions.Format)?.GetBlockSize() ?? (GetFloatBlockEncoder(OutputOptions.Format) ?? throw new NotSupportedException($"This format is either not supported or does not use block compression: {OutputOptions.Format}")).GetBlockSize();
		}

		public int GetBlockCount(int pixelWidth, int pixelHeight)
		{
			return ImageToBlocks.CalculateNumOfBlocks(pixelWidth, pixelHeight);
		}

		public void GetBlockCount(int pixelWidth, int pixelHeight, out int blocksWidth, out int blocksHeight)
		{
			ImageToBlocks.CalculateNumOfBlocks(pixelWidth, pixelHeight, out blocksWidth, out blocksHeight);
		}

		public Task EncodeToStreamHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> input, Stream outputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				EncodeToStreamInternalHdr(input, outputStream, default(CancellationToken));
			}, token);
		}

		public Task<KtxFile> EncodeToKtxHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> input, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToKtxInternalHdr(input, token), token);
		}

		public Task<DdsFile> EncodeToDdsHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> input, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToDdsInternalHdr(input, token), token);
		}

		public Task<byte[][]> EncodeToRawBytesHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> input, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToRawInternalHdr(input, token), token);
		}

		public Task<byte[]> EncodeToRawBytesHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> input, int mipLevel, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeToRawInternalHdr(input, mipLevel, out var _, out var _, token), token);
		}

		public Task EncodeCubeMapToStreamHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, Stream outputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				EncodeCubeMapToStreamInternalHdr(right, left, top, down, back, front, outputStream, token);
			}, token);
		}

		public Task<KtxFile> EncodeCubeMapToKtxHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeCubeMapToKtxInternalHdr(right, left, top, down, back, front, token), token);
		}

		public Task<DdsFile> EncodeCubeMapToDdsHdrAsync(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => EncodeCubeMapToDdsInternalHdr(right, left, top, down, back, front, token), token);
		}

		public void EncodeToStreamHdr(ReadOnlyMemory2D<ColorRgbFloat> input, Stream outputStream)
		{
			EncodeToStreamInternalHdr(input, outputStream, default(CancellationToken));
		}

		public KtxFile EncodeToKtxHdr(ReadOnlyMemory2D<ColorRgbFloat> input)
		{
			return EncodeToKtxInternalHdr(input, default(CancellationToken));
		}

		public DdsFile EncodeToDdsHdr(ReadOnlyMemory2D<ColorRgbFloat> input)
		{
			return EncodeToDdsInternalHdr(input, default(CancellationToken));
		}

		public byte[][] EncodeToRawBytesHdr(ReadOnlyMemory2D<ColorRgbFloat> input)
		{
			return EncodeToRawInternalHdr(input, default(CancellationToken));
		}

		public byte[] EncodeToRawBytesHdr(ReadOnlyMemory2D<ColorRgbFloat> input, int mipLevel, out int mipWidth, out int mipHeight)
		{
			return EncodeToRawInternalHdr(input, mipLevel, out mipWidth, out mipHeight, default(CancellationToken));
		}

		public void EncodeCubeMapToStreamHdr(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, Stream outputStream)
		{
			EncodeCubeMapToStreamInternalHdr(right, left, top, down, back, front, outputStream, default(CancellationToken));
		}

		public KtxFile EncodeCubeMapToKtxHdr(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front)
		{
			return EncodeCubeMapToKtxInternalHdr(right, left, top, down, back, front, default(CancellationToken));
		}

		public DdsFile EncodeCubeMapToDdsHdr(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front)
		{
			return EncodeCubeMapToDdsInternalHdr(right, left, top, down, back, front, default(CancellationToken));
		}

		public byte[] EncodeBlockHdr(ReadOnlySpan<ColorRgbFloat> inputBlock)
		{
			if (inputBlock.Length != 16)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			return EncodeBlockInternalHdr(inputBlock.AsSpan2D(4, 4));
		}

		public byte[] EncodeBlockHdr(ReadOnlySpan2D<ColorRgbFloat> inputBlock)
		{
			if (inputBlock.Width != 4 || inputBlock.Height != 4)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			return EncodeBlockInternalHdr(inputBlock);
		}

		public void EncodeBlockHdr(ReadOnlySpan<ColorRgbFloat> inputBlock, Stream outputStream)
		{
			if (inputBlock.Length != 16)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			EncodeBlockInternalHdr(inputBlock.AsSpan2D(4, 4), outputStream);
		}

		public void EncodeBlockHdr(ReadOnlySpan2D<ColorRgbFloat> inputBlock, Stream outputStream)
		{
			if (inputBlock.Width != 4 || inputBlock.Height != 4)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			EncodeBlockInternalHdr(inputBlock, outputStream);
		}

		public int CalculateNumberOfMipLevels(int imagePixelWidth, int imagePixelHeight)
		{
			return MipMapper.CalculateMipChainLength(imagePixelWidth, imagePixelHeight, (!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
		}

		public void CalculateMipMapSize(int imagePixelWidth, int imagePixelHeight, int mipLevel, out int mipWidth, out int mipHeight)
		{
			MipMapper.CalculateMipLevelSize(imagePixelWidth, imagePixelHeight, mipLevel, out mipWidth, out mipHeight);
		}

		private void EncodeToStreamInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> input, Stream outputStream, CancellationToken token)
		{
			switch (OutputOptions.FileFormat)
			{
			case OutputFileFormat.Dds:
				EncodeToDdsInternalHdr(input, token).Write(outputStream);
				break;
			case OutputFileFormat.Ktx:
				EncodeToKtxInternalHdr(input, token).Write(outputStream);
				break;
			}
		}

		private KtxFile EncodeToKtxInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> input, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4RgbFloat> bcBlockEncoder = null;
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgbFloat>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			if (!OutputOptions.Format.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not supported for hdr images: {OutputOptions.Format}");
			}
			bcBlockEncoder = GetFloatBlockEncoder(OutputOptions.Format);
			if (bcBlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
			}
			KtxFile ktxFile = new KtxFile(KtxHeader.InitializeCompressed(input.Width, input.Height, bcBlockEncoder.GetInternalFormat(), bcBlockEncoder.GetBaseInternalFormat()));
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int totalBlocks = array.Sum((ReadOnlyMemory2D<ColorRgbFloat> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height));
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			for (int num = 0; num < numMipMaps; num++)
			{
				int blocksWidth;
				int blocksHeight;
				RawBlock4X4RgbFloat[] blocks = ImageToBlocks.ImageTo4X4(array[num], out blocksWidth, out blocksHeight);
				byte[] array2 = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
				operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgbFloat> x) => ImageToBlocks.CalculateNumOfBlocks(x.Width, x.Height)));
				ktxFile.MipMaps.Add(new KtxMipmap((uint)array2.Length, (uint)array[num].Width, (uint)array[num].Height, 1u));
				ktxFile.MipMaps[num].Faces[0] = new KtxMipFace(array2, (uint)array[num].Width, (uint)array[num].Height);
			}
			ktxFile.header.NumberOfFaces = 1u;
			ktxFile.header.NumberOfMipmapLevels = (uint)numMipMaps;
			return ktxFile;
		}

		private DdsFile EncodeToDdsInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> input, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4RgbFloat> bcBlockEncoder = null;
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgbFloat>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			if (!OutputOptions.Format.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not supported for hdr images: {OutputOptions.Format}");
			}
			bcBlockEncoder = GetFloatBlockEncoder(OutputOptions.Format);
			if (bcBlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
			}
			(DdsHeader, DdsHeaderDx10) tuple = DdsHeader.InitializeCompressed(input.Width, input.Height, bcBlockEncoder.GetDxgiFormat(), OutputOptions.DdsPreferDxt10Header);
			DdsHeader item = tuple.Item1;
			DdsHeaderDx10 item2 = tuple.Item2;
			DdsFile ddsFile = new DdsFile(item, item2);
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int totalBlocks = array.Sum((ReadOnlyMemory2D<ColorRgbFloat> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height));
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			for (int num = 0; num < numMipMaps; num++)
			{
				int blocksWidth;
				int blocksHeight;
				RawBlock4X4RgbFloat[] blocks = ImageToBlocks.ImageTo4X4(array[num], out blocksWidth, out blocksHeight);
				byte[] array2 = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
				operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgbFloat> x) => ImageToBlocks.CalculateNumOfBlocks(x.Width, x.Height)));
				if (num == 0)
				{
					ddsFile.Faces.Add(new DdsFace((uint)input.Width, (uint)input.Height, (uint)array2.Length, numMipMaps));
				}
				ddsFile.Faces[0].MipMaps[num] = new DdsMipMap(array2, (uint)array[num].Width, (uint)array[num].Height);
			}
			ddsFile.header.dwMipMapCount = (uint)numMipMaps;
			if (numMipMaps > 1)
			{
				ddsFile.header.dwCaps |= HeaderCaps.DdscapsComplex | HeaderCaps.DdscapsMipmap;
			}
			return ddsFile;
		}

		private byte[][] EncodeToRawInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> input, CancellationToken token)
		{
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgbFloat>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			byte[][] array2 = new byte[numMipMaps][];
			IBcBlockEncoder<RawBlock4X4RgbFloat> bcBlockEncoder = null;
			bcBlockEncoder = GetFloatBlockEncoder(OutputOptions.Format);
			if (bcBlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int totalBlocks = array.Sum((ReadOnlyMemory2D<ColorRgbFloat> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height));
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			for (int num = 0; num < numMipMaps; num++)
			{
				int blocksWidth;
				int blocksHeight;
				RawBlock4X4RgbFloat[] blocks = ImageToBlocks.ImageTo4X4(array[num], out blocksWidth, out blocksHeight);
				byte[] array3 = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
				operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgbFloat> x) => ImageToBlocks.CalculateNumOfBlocks(x.Width, x.Height)));
				array2[num] = array3;
			}
			return array2;
		}

		private byte[] EncodeToRawInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> input, int mipLevel, out int mipWidth, out int mipHeight, CancellationToken token)
		{
			mipLevel = Math.Max(0, mipLevel);
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgbFloat>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			IBcBlockEncoder<RawBlock4X4RgbFloat> obj = GetFloatBlockEncoder(OutputOptions.Format) ?? throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
			if (mipLevel > numMipMaps - 1)
			{
				throw new ArgumentException("mipLevel cannot be more than number of mipmaps.");
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			operationContext.Progress = new OperationProgress(totalBlocks: array.Sum((ReadOnlyMemory2D<ColorRgbFloat> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height)), progress: Options.Progress);
			int blocksWidth;
			int blocksHeight;
			RawBlock4X4RgbFloat[] blocks = ImageToBlocks.ImageTo4X4(array[mipLevel], out blocksWidth, out blocksHeight);
			byte[] result = obj.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
			mipWidth = array[mipLevel].Width;
			mipHeight = array[mipLevel].Height;
			return result;
		}

		private void EncodeCubeMapToStreamInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, Stream outputStream, CancellationToken token)
		{
			switch (OutputOptions.FileFormat)
			{
			case OutputFileFormat.Ktx:
				EncodeCubeMapToKtxInternalHdr(right, left, top, down, back, front, token).Write(outputStream);
				break;
			case OutputFileFormat.Dds:
				EncodeCubeMapToDdsInternalHdr(right, left, top, down, back, front, token).Write(outputStream);
				break;
			}
		}

		private KtxFile EncodeCubeMapToKtxInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4RgbFloat> bcBlockEncoder = null;
			ReadOnlyMemory2D<ColorRgbFloat>[] array = new ReadOnlyMemory2D<ColorRgbFloat>[6] { right, left, top, down, back, front };
			int width = right.Width;
			int height = right.Height;
			bcBlockEncoder = GetFloatBlockEncoder(OutputOptions.Format);
			if (bcBlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
			}
			KtxFile ktxFile = new KtxFile(KtxHeader.InitializeCompressed(width, height, bcBlockEncoder.GetInternalFormat(), bcBlockEncoder.GetBaseInternalFormat()));
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			int num = MipMapper.CalculateMipChainLength(width, height, numMipMaps);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				ktxFile.MipMaps.Add(new KtxMipmap(0u, 0u, 0u, (uint)array.Length));
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int num3 = 0;
			ReadOnlyMemory2D<ColorRgbFloat>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				_ = ref array2[i];
				for (int j = 0; j < numMipMaps; j++)
				{
					MipMapper.CalculateMipLevelSize(width, height, j, out var mipWidth, out var mipHeight);
					num3 += ImageToBlocks.CalculateNumOfBlocks(mipWidth, mipHeight);
				}
			}
			operationContext.Progress = new OperationProgress(Options.Progress, num3);
			int num4 = 0;
			for (int k = 0; k < array.Length; k++)
			{
				ReadOnlyMemory2D<ColorRgbFloat>[] array3 = MipMapper.GenerateMipChain(array[k], ref numMipMaps);
				for (int l = 0; l < numMipMaps; l++)
				{
					int blocksWidth;
					int blocksHeight;
					RawBlock4X4RgbFloat[] array4 = ImageToBlocks.ImageTo4X4(array3[l], out blocksWidth, out blocksHeight);
					byte[] array5 = bcBlockEncoder.Encode(array4, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
					num4 += array4.Length;
					operationContext.Progress.SetProcessedBlocks(num4);
					if (k == 0)
					{
						ktxFile.MipMaps[l] = new KtxMipmap((uint)array5.Length, (uint)array3[l].Width, (uint)array3[l].Height, (uint)array.Length);
					}
					ktxFile.MipMaps[l].Faces[k] = new KtxMipFace(array5, (uint)array3[l].Width, (uint)array3[l].Height);
				}
			}
			ktxFile.header.NumberOfFaces = (uint)array.Length;
			ktxFile.header.NumberOfMipmapLevels = (uint)num;
			return ktxFile;
		}

		private DdsFile EncodeCubeMapToDdsInternalHdr(ReadOnlyMemory2D<ColorRgbFloat> right, ReadOnlyMemory2D<ColorRgbFloat> left, ReadOnlyMemory2D<ColorRgbFloat> top, ReadOnlyMemory2D<ColorRgbFloat> down, ReadOnlyMemory2D<ColorRgbFloat> back, ReadOnlyMemory2D<ColorRgbFloat> front, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4RgbFloat> bcBlockEncoder = null;
			ReadOnlyMemory2D<ColorRgbFloat>[] array = new ReadOnlyMemory2D<ColorRgbFloat>[6] { right, left, top, down, back, front };
			int width = right.Width;
			int height = right.Height;
			bcBlockEncoder = GetFloatBlockEncoder(OutputOptions.Format);
			if (bcBlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
			}
			(DdsHeader, DdsHeaderDx10) tuple = DdsHeader.InitializeCompressed(width, height, bcBlockEncoder.GetDxgiFormat(), OutputOptions.DdsPreferDxt10Header);
			DdsHeader item = tuple.Item1;
			DdsHeaderDx10 item2 = tuple.Item2;
			DdsFile ddsFile = new DdsFile(item, item2);
			if (OutputOptions.DdsBc1WriteAlphaFlag && OutputOptions.Format == CompressionFormat.Bc1WithAlpha)
			{
				ddsFile.header.ddsPixelFormat.dwFlags |= PixelFormatFlags.DdpfAlphaPixels;
			}
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int num = 0;
			ReadOnlyMemory2D<ColorRgbFloat>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				_ = ref array2[i];
				for (int j = 0; j < numMipMaps; j++)
				{
					MipMapper.CalculateMipLevelSize(width, height, j, out var mipWidth, out var mipHeight);
					num += ImageToBlocks.CalculateNumOfBlocks(mipWidth, mipHeight);
				}
			}
			operationContext.Progress = new OperationProgress(Options.Progress, num);
			int num2 = 0;
			for (int k = 0; k < array.Length; k++)
			{
				ReadOnlyMemory2D<ColorRgbFloat>[] array3 = MipMapper.GenerateMipChain(array[k], ref numMipMaps);
				for (int l = 0; l < numMipMaps; l++)
				{
					int blocksWidth;
					int blocksHeight;
					RawBlock4X4RgbFloat[] array4 = ImageToBlocks.ImageTo4X4(array3[l], out blocksWidth, out blocksHeight);
					byte[] array5 = bcBlockEncoder.Encode(array4, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
					num2 += array4.Length;
					operationContext.Progress.SetProcessedBlocks(num2);
					if (l == 0)
					{
						ddsFile.Faces.Add(new DdsFace((uint)array3[l].Width, (uint)array3[l].Height, (uint)array5.Length, array3.Length));
					}
					ddsFile.Faces[k].MipMaps[l] = new DdsMipMap(array5, (uint)array3[l].Width, (uint)array3[l].Height);
				}
			}
			ddsFile.header.dwCaps |= HeaderCaps.DdscapsComplex;
			ddsFile.header.dwMipMapCount = (uint)numMipMaps;
			if (numMipMaps > 1)
			{
				ddsFile.header.dwCaps |= HeaderCaps.DdscapsMipmap;
			}
			ddsFile.header.dwCaps2 |= HeaderCaps2.Ddscaps2Cubemap | HeaderCaps2.Ddscaps2CubemapPositivex | HeaderCaps2.Ddscaps2CubemapNegativex | HeaderCaps2.Ddscaps2CubemapPositivey | HeaderCaps2.Ddscaps2CubemapNegativey | HeaderCaps2.Ddscaps2CubemapPositivez | HeaderCaps2.Ddscaps2CubemapNegativez;
			return ddsFile;
		}

		private byte[] EncodeBlockInternalHdr(ReadOnlySpan2D<ColorRgbFloat> input)
		{
			IBcBlockEncoder<RawBlock4X4RgbFloat> obj = GetFloatBlockEncoder(OutputOptions.Format) ?? throw new NotSupportedException($"This Format is not supported for single block encoding: {OutputOptions.Format}");
			byte[] array = new byte[obj.GetBlockSize()];
			RawBlock4X4RgbFloat block = default(RawBlock4X4RgbFloat);
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			input.GetRowSpan(0).CopyTo(asSpan);
			input.GetRowSpan(1).CopyTo(asSpan.Slice(4));
			input.GetRowSpan(2).CopyTo(asSpan.Slice(8));
			input.GetRowSpan(3).CopyTo(asSpan.Slice(12));
			obj.EncodeBlock(block, OutputOptions.Quality, array);
			return array;
		}

		private void EncodeBlockInternalHdr(ReadOnlySpan2D<ColorRgbFloat> input, Stream outputStream)
		{
			IBcBlockEncoder<RawBlock4X4RgbFloat> floatBlockEncoder = GetFloatBlockEncoder(OutputOptions.Format);
			if (floatBlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported for single block encoding: {OutputOptions.Format}");
			}
			if (input.Width != 4 || input.Height != 4)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			Span<byte> span = stackalloc byte[16];
			span = span.Slice(0, floatBlockEncoder.GetBlockSize());
			RawBlock4X4RgbFloat block = default(RawBlock4X4RgbFloat);
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			input.GetRowSpan(0).CopyTo(asSpan);
			input.GetRowSpan(1).CopyTo(asSpan.Slice(4));
			input.GetRowSpan(2).CopyTo(asSpan.Slice(8));
			input.GetRowSpan(3).CopyTo(asSpan.Slice(12));
			floatBlockEncoder.EncodeBlock(block, OutputOptions.Quality, span);
			outputStream.Write(span);
		}

		private void EncodeToStreamInternal(ReadOnlyMemory2D<ColorRgba32> input, Stream outputStream, CancellationToken token)
		{
			switch (OutputOptions.FileFormat)
			{
			case OutputFileFormat.Dds:
				EncodeToDdsInternal(input, token).Write(outputStream);
				break;
			case OutputFileFormat.Ktx:
				EncodeToKtxInternal(input, token).Write(outputStream);
				break;
			}
		}

		private KtxFile EncodeToKtxInternal(ReadOnlyMemory2D<ColorRgba32> input, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4Rgba32> bcBlockEncoder = null;
			IRawEncoder rawEncoder = null;
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgba32>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			bool flag = OutputOptions.Format.IsCompressedFormat();
			KtxFile ktxFile;
			if (flag)
			{
				bcBlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
				if (bcBlockEncoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
				}
				ktxFile = new KtxFile(KtxHeader.InitializeCompressed(input.Width, input.Height, bcBlockEncoder.GetInternalFormat(), bcBlockEncoder.GetBaseInternalFormat()));
			}
			else
			{
				rawEncoder = GetRawEncoder(OutputOptions.Format);
				ktxFile = new KtxFile(KtxHeader.InitializeUncompressed(input.Width, input.Height, rawEncoder.GetGlType(), rawEncoder.GetGlFormat(), rawEncoder.GetGlTypeSize(), rawEncoder.GetInternalFormat(), rawEncoder.GetBaseInternalFormat()));
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int totalBlocks = (flag ? array.Sum((ReadOnlyMemory2D<ColorRgba32> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height)) : array.Sum((ReadOnlyMemory2D<ColorRgba32> m) => m.Width * m.Height));
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			for (int num = 0; num < numMipMaps; num++)
			{
				byte[] array2;
				if (flag)
				{
					int blocksWidth;
					int blocksHeight;
					RawBlock4X4Rgba32[] blocks = ImageToBlocks.ImageTo4X4(array[num], out blocksWidth, out blocksHeight);
					array2 = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
					operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgba32> x) => ImageToBlocks.CalculateNumOfBlocks(x.Width, x.Height)));
				}
				else
				{
					if (!array[num].TryGetMemory(out var memory))
					{
						throw new InvalidOperationException("Could not get Memory<T> from Memory2D<T>.");
					}
					array2 = rawEncoder.Encode(memory);
					operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgba32> x) => x.Width * x.Height));
				}
				ktxFile.MipMaps.Add(new KtxMipmap((uint)array2.Length, (uint)array[num].Width, (uint)array[num].Height, 1u));
				ktxFile.MipMaps[num].Faces[0] = new KtxMipFace(array2, (uint)array[num].Width, (uint)array[num].Height);
			}
			ktxFile.header.NumberOfFaces = 1u;
			ktxFile.header.NumberOfMipmapLevels = (uint)numMipMaps;
			return ktxFile;
		}

		private DdsFile EncodeToDdsInternal(ReadOnlyMemory2D<ColorRgba32> input, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4Rgba32> bcBlockEncoder = null;
			IRawEncoder rawEncoder = null;
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgba32>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			bool flag = OutputOptions.Format.IsCompressedFormat();
			DdsFile ddsFile;
			if (flag)
			{
				bcBlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
				if (bcBlockEncoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
				}
				(DdsHeader, DdsHeaderDx10) tuple = DdsHeader.InitializeCompressed(input.Width, input.Height, bcBlockEncoder.GetDxgiFormat(), OutputOptions.DdsPreferDxt10Header);
				DdsHeader item = tuple.Item1;
				DdsHeaderDx10 item2 = tuple.Item2;
				ddsFile = new DdsFile(item, item2);
				if (OutputOptions.DdsBc1WriteAlphaFlag && OutputOptions.Format == CompressionFormat.Bc1WithAlpha)
				{
					ddsFile.header.ddsPixelFormat.dwFlags |= PixelFormatFlags.DdpfAlphaPixels;
				}
			}
			else
			{
				rawEncoder = GetRawEncoder(OutputOptions.Format);
				ddsFile = new DdsFile(DdsHeader.InitializeUncompressed(input.Width, input.Height, rawEncoder.GetDxgiFormat()));
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int totalBlocks = (flag ? array.Sum((ReadOnlyMemory2D<ColorRgba32> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height)) : array.Sum((ReadOnlyMemory2D<ColorRgba32> m) => m.Width * m.Height));
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			for (int num = 0; num < numMipMaps; num++)
			{
				byte[] array2;
				if (flag)
				{
					int blocksWidth;
					int blocksHeight;
					RawBlock4X4Rgba32[] blocks = ImageToBlocks.ImageTo4X4(array[num], out blocksWidth, out blocksHeight);
					array2 = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
					operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgba32> x) => ImageToBlocks.CalculateNumOfBlocks(x.Width, x.Height)));
				}
				else
				{
					if (!array[num].TryGetMemory(out var memory))
					{
						throw new InvalidOperationException("Could not get Memory<T> from Memory2D<T>.");
					}
					array2 = rawEncoder.Encode(memory);
					operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgba32> x) => x.Width * x.Height));
				}
				if (num == 0)
				{
					ddsFile.Faces.Add(new DdsFace((uint)input.Width, (uint)input.Height, (uint)array2.Length, numMipMaps));
				}
				ddsFile.Faces[0].MipMaps[num] = new DdsMipMap(array2, (uint)array[num].Width, (uint)array[num].Height);
			}
			ddsFile.header.dwMipMapCount = (uint)numMipMaps;
			if (numMipMaps > 1)
			{
				ddsFile.header.dwCaps |= HeaderCaps.DdscapsComplex | HeaderCaps.DdscapsMipmap;
			}
			return ddsFile;
		}

		private byte[][] EncodeToRawInternal(ReadOnlyMemory2D<ColorRgba32> input, CancellationToken token)
		{
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgba32>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			byte[][] array2 = new byte[numMipMaps][];
			IBcBlockEncoder<RawBlock4X4Rgba32> bcBlockEncoder = null;
			IRawEncoder rawEncoder = null;
			bool flag = OutputOptions.Format.IsCompressedFormat();
			if (flag)
			{
				bcBlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
				if (bcBlockEncoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
				}
			}
			else
			{
				rawEncoder = GetRawEncoder(OutputOptions.Format);
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int totalBlocks = (flag ? array.Sum((ReadOnlyMemory2D<ColorRgba32> m) => ImageToBlocks.CalculateNumOfBlocks(m.Width, m.Height)) : array.Sum((ReadOnlyMemory2D<ColorRgba32> m) => m.Width * m.Height));
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			for (int num = 0; num < numMipMaps; num++)
			{
				byte[] array3;
				if (flag)
				{
					int blocksWidth;
					int blocksHeight;
					RawBlock4X4Rgba32[] blocks = ImageToBlocks.ImageTo4X4(array[num], out blocksWidth, out blocksHeight);
					array3 = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
					operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgba32> x) => ImageToBlocks.CalculateNumOfBlocks(x.Width, x.Height)));
				}
				else
				{
					if (!array[num].TryGetMemory(out var memory))
					{
						throw new InvalidOperationException("Could not get Memory<T> from Memory2D<T>.");
					}
					array3 = rawEncoder.Encode(memory);
					operationContext.Progress.SetProcessedBlocks(array.Take(num + 1).Sum((ReadOnlyMemory2D<ColorRgba32> x) => x.Width * x.Height));
				}
				array2[num] = array3;
			}
			return array2;
		}

		private byte[] EncodeToRawInternal(ReadOnlyMemory2D<ColorRgba32> input, int mipLevel, out int mipWidth, out int mipHeight, CancellationToken token)
		{
			mipLevel = Math.Max(0, mipLevel);
			IBcBlockEncoder<RawBlock4X4Rgba32> bcBlockEncoder = null;
			IRawEncoder rawEncoder = null;
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			ReadOnlyMemory2D<ColorRgba32>[] array = MipMapper.GenerateMipChain(input, ref numMipMaps);
			bool num = OutputOptions.Format.IsCompressedFormat();
			if (num)
			{
				bcBlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
				if (bcBlockEncoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
				}
			}
			else
			{
				rawEncoder = GetRawEncoder(OutputOptions.Format);
			}
			if (mipLevel > numMipMaps - 1)
			{
				throw new ArgumentException("mipLevel cannot be more than number of mipmaps.");
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			operationContext.Progress = new OperationProgress(totalBlocks: num ? ImageToBlocks.CalculateNumOfBlocks(array[mipLevel].Width, array[mipLevel].Height) : (array[mipLevel].Width * array[mipLevel].Height), progress: Options.Progress);
			byte[] result;
			if (num)
			{
				int blocksWidth;
				int blocksHeight;
				RawBlock4X4Rgba32[] blocks = ImageToBlocks.ImageTo4X4(array[mipLevel], out blocksWidth, out blocksHeight);
				result = bcBlockEncoder.Encode(blocks, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
			}
			else
			{
				if (!array[mipLevel].TryGetMemory(out var memory))
				{
					throw new InvalidOperationException("Could not get Memory<T> from Memory2D<T>.");
				}
				result = rawEncoder.Encode(memory);
			}
			mipWidth = array[mipLevel].Width;
			mipHeight = array[mipLevel].Height;
			return result;
		}

		private void EncodeCubeMapToStreamInternal(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, Stream outputStream, CancellationToken token)
		{
			switch (OutputOptions.FileFormat)
			{
			case OutputFileFormat.Ktx:
				EncodeCubeMapToKtxInternal(right, left, top, down, back, front, token).Write(outputStream);
				break;
			case OutputFileFormat.Dds:
				EncodeCubeMapToDdsInternal(right, left, top, down, back, front, token).Write(outputStream);
				break;
			}
		}

		private KtxFile EncodeCubeMapToKtxInternal(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4Rgba32> bcBlockEncoder = null;
			IRawEncoder rawEncoder = null;
			ReadOnlyMemory2D<ColorRgba32>[] array = new ReadOnlyMemory2D<ColorRgba32>[6] { right, left, top, down, back, front };
			int width = right.Width;
			int height = right.Height;
			bool flag = OutputOptions.Format.IsCompressedFormat();
			KtxFile ktxFile;
			if (flag)
			{
				bcBlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
				if (bcBlockEncoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
				}
				ktxFile = new KtxFile(KtxHeader.InitializeCompressed(width, height, bcBlockEncoder.GetInternalFormat(), bcBlockEncoder.GetBaseInternalFormat()));
			}
			else
			{
				rawEncoder = GetRawEncoder(OutputOptions.Format);
				ktxFile = new KtxFile(KtxHeader.InitializeUncompressed(width, height, rawEncoder.GetGlType(), rawEncoder.GetGlFormat(), rawEncoder.GetGlTypeSize(), rawEncoder.GetInternalFormat(), rawEncoder.GetBaseInternalFormat()));
			}
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			int num = MipMapper.CalculateMipChainLength(width, height, numMipMaps);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				ktxFile.MipMaps.Add(new KtxMipmap(0u, 0u, 0u, (uint)array.Length));
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int num3 = 0;
			ReadOnlyMemory2D<ColorRgba32>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				_ = ref array2[i];
				for (int j = 0; j < numMipMaps; j++)
				{
					MipMapper.CalculateMipLevelSize(width, height, j, out var mipWidth, out var mipHeight);
					num3 += (flag ? ImageToBlocks.CalculateNumOfBlocks(mipWidth, mipHeight) : (mipWidth * mipHeight));
				}
			}
			operationContext.Progress = new OperationProgress(Options.Progress, num3);
			int num4 = 0;
			for (int k = 0; k < array.Length; k++)
			{
				ReadOnlyMemory2D<ColorRgba32>[] array3 = MipMapper.GenerateMipChain(array[k], ref numMipMaps);
				for (int l = 0; l < numMipMaps; l++)
				{
					byte[] array5;
					if (flag)
					{
						int blocksWidth;
						int blocksHeight;
						RawBlock4X4Rgba32[] array4 = ImageToBlocks.ImageTo4X4(array3[l], out blocksWidth, out blocksHeight);
						array5 = bcBlockEncoder.Encode(array4, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
						num4 += array4.Length;
						operationContext.Progress.SetProcessedBlocks(num4);
					}
					else
					{
						if (!array3[l].TryGetMemory(out var memory))
						{
							throw new InvalidOperationException("Could not get Memory<T> from Memory2D<T>.");
						}
						array5 = rawEncoder.Encode(memory);
						num4 += memory.Length;
						operationContext.Progress.SetProcessedBlocks(num4);
					}
					if (k == 0)
					{
						ktxFile.MipMaps[l] = new KtxMipmap((uint)array5.Length, (uint)array3[l].Width, (uint)array3[l].Height, (uint)array.Length);
					}
					ktxFile.MipMaps[l].Faces[k] = new KtxMipFace(array5, (uint)array3[l].Width, (uint)array3[l].Height);
				}
			}
			ktxFile.header.NumberOfFaces = (uint)array.Length;
			ktxFile.header.NumberOfMipmapLevels = (uint)num;
			return ktxFile;
		}

		private DdsFile EncodeCubeMapToDdsInternal(ReadOnlyMemory2D<ColorRgba32> right, ReadOnlyMemory2D<ColorRgba32> left, ReadOnlyMemory2D<ColorRgba32> top, ReadOnlyMemory2D<ColorRgba32> down, ReadOnlyMemory2D<ColorRgba32> back, ReadOnlyMemory2D<ColorRgba32> front, CancellationToken token)
		{
			IBcBlockEncoder<RawBlock4X4Rgba32> bcBlockEncoder = null;
			IRawEncoder rawEncoder = null;
			ReadOnlyMemory2D<ColorRgba32>[] array = new ReadOnlyMemory2D<ColorRgba32>[6] { right, left, top, down, back, front };
			int width = right.Width;
			int height = right.Height;
			bool flag = OutputOptions.Format.IsCompressedFormat();
			DdsFile ddsFile;
			if (flag)
			{
				bcBlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
				if (bcBlockEncoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {OutputOptions.Format}");
				}
				(DdsHeader, DdsHeaderDx10) tuple = DdsHeader.InitializeCompressed(width, height, bcBlockEncoder.GetDxgiFormat(), OutputOptions.DdsPreferDxt10Header);
				DdsHeader item = tuple.Item1;
				DdsHeaderDx10 item2 = tuple.Item2;
				ddsFile = new DdsFile(item, item2);
				if (OutputOptions.DdsBc1WriteAlphaFlag && OutputOptions.Format == CompressionFormat.Bc1WithAlpha)
				{
					ddsFile.header.ddsPixelFormat.dwFlags |= PixelFormatFlags.DdpfAlphaPixels;
				}
			}
			else
			{
				rawEncoder = GetRawEncoder(OutputOptions.Format);
				ddsFile = new DdsFile(DdsHeader.InitializeUncompressed(width, height, rawEncoder.GetDxgiFormat()));
			}
			int numMipMaps = ((!OutputOptions.GenerateMipMaps) ? 1 : OutputOptions.MaxMipMapLevel);
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = (!Debugger.IsAttached && Options.IsParallel),
				TaskCount = Options.TaskCount
			};
			int num = 0;
			ReadOnlyMemory2D<ColorRgba32>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				_ = ref array2[i];
				for (int j = 0; j < numMipMaps; j++)
				{
					MipMapper.CalculateMipLevelSize(width, height, j, out var mipWidth, out var mipHeight);
					num += (flag ? ImageToBlocks.CalculateNumOfBlocks(mipWidth, mipHeight) : (mipWidth * mipHeight));
				}
			}
			operationContext.Progress = new OperationProgress(Options.Progress, num);
			int num2 = 0;
			for (int k = 0; k < array.Length; k++)
			{
				ReadOnlyMemory2D<ColorRgba32>[] array3 = MipMapper.GenerateMipChain(array[k], ref numMipMaps);
				for (int l = 0; l < numMipMaps; l++)
				{
					byte[] array5;
					if (flag)
					{
						int blocksWidth;
						int blocksHeight;
						RawBlock4X4Rgba32[] array4 = ImageToBlocks.ImageTo4X4(array3[l], out blocksWidth, out blocksHeight);
						array5 = bcBlockEncoder.Encode(array4, blocksWidth, blocksHeight, OutputOptions.Quality, operationContext);
						num2 += array4.Length;
						operationContext.Progress.SetProcessedBlocks(num2);
					}
					else
					{
						if (!array3[l].TryGetMemory(out var memory))
						{
							throw new InvalidOperationException("Could not get Memory<T> from Memory2D<T>.");
						}
						array5 = rawEncoder.Encode(memory);
						num2 += memory.Length;
						operationContext.Progress.SetProcessedBlocks(num2);
					}
					if (l == 0)
					{
						ddsFile.Faces.Add(new DdsFace((uint)array3[l].Width, (uint)array3[l].Height, (uint)array5.Length, array3.Length));
					}
					ddsFile.Faces[k].MipMaps[l] = new DdsMipMap(array5, (uint)array3[l].Width, (uint)array3[l].Height);
				}
			}
			ddsFile.header.dwCaps |= HeaderCaps.DdscapsComplex;
			ddsFile.header.dwMipMapCount = (uint)numMipMaps;
			if (numMipMaps > 1)
			{
				ddsFile.header.dwCaps |= HeaderCaps.DdscapsMipmap;
			}
			ddsFile.header.dwCaps2 |= HeaderCaps2.Ddscaps2Cubemap | HeaderCaps2.Ddscaps2CubemapPositivex | HeaderCaps2.Ddscaps2CubemapNegativex | HeaderCaps2.Ddscaps2CubemapPositivey | HeaderCaps2.Ddscaps2CubemapNegativey | HeaderCaps2.Ddscaps2CubemapPositivez | HeaderCaps2.Ddscaps2CubemapNegativez;
			return ddsFile;
		}

		private byte[] EncodeBlockInternal(ReadOnlySpan2D<ColorRgba32> input)
		{
			IBcBlockEncoder<RawBlock4X4Rgba32> obj = GetRgba32BlockEncoder(OutputOptions.Format) ?? throw new NotSupportedException($"This Format is not supported for single block encoding: {OutputOptions.Format}");
			byte[] array = new byte[obj.GetBlockSize()];
			RawBlock4X4Rgba32 block = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = block.AsSpan;
			input.GetRowSpan(0).CopyTo(asSpan);
			input.GetRowSpan(1).CopyTo(asSpan.Slice(4));
			input.GetRowSpan(2).CopyTo(asSpan.Slice(8));
			input.GetRowSpan(3).CopyTo(asSpan.Slice(12));
			obj.EncodeBlock(block, OutputOptions.Quality, array);
			return array;
		}

		private void EncodeBlockInternal(ReadOnlySpan2D<ColorRgba32> input, Stream outputStream)
		{
			IBcBlockEncoder<RawBlock4X4Rgba32> rgba32BlockEncoder = GetRgba32BlockEncoder(OutputOptions.Format);
			if (rgba32BlockEncoder == null)
			{
				throw new NotSupportedException($"This Format is not supported for single block encoding: {OutputOptions.Format}");
			}
			if (input.Width != 4 || input.Height != 4)
			{
				throw new ArgumentException("Single block encoding can only encode blocks of 4x4");
			}
			Span<byte> span = stackalloc byte[16];
			span = span.Slice(0, rgba32BlockEncoder.GetBlockSize());
			RawBlock4X4Rgba32 block = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = block.AsSpan;
			input.GetRowSpan(0).CopyTo(asSpan);
			input.GetRowSpan(1).CopyTo(asSpan.Slice(4));
			input.GetRowSpan(2).CopyTo(asSpan.Slice(8));
			input.GetRowSpan(3).CopyTo(asSpan.Slice(12));
			rgba32BlockEncoder.EncodeBlock(block, OutputOptions.Quality, span);
			outputStream.Write(span);
		}

		private IBcBlockEncoder<RawBlock4X4Rgba32> GetRgba32BlockEncoder(CompressionFormat format)
		{
			return format switch
			{
				CompressionFormat.Bc1 => new Bc1BlockEncoder(), 
				CompressionFormat.Bc1WithAlpha => new Bc1AlphaBlockEncoder(), 
				CompressionFormat.Bc2 => new Bc2BlockEncoder(), 
				CompressionFormat.Bc3 => new Bc3BlockEncoder(), 
				CompressionFormat.Bc4 => new Bc4BlockEncoder(InputOptions.Bc4Component), 
				CompressionFormat.Bc5 => new Bc5BlockEncoder(InputOptions.Bc5Component1, InputOptions.Bc5Component2), 
				CompressionFormat.Bc7 => new Bc7Encoder(), 
				CompressionFormat.Atc => new AtcBlockEncoder(), 
				CompressionFormat.AtcExplicitAlpha => new AtcExplicitAlphaBlockEncoder(), 
				CompressionFormat.AtcInterpolatedAlpha => new AtcInterpolatedAlphaBlockEncoder(), 
				_ => null, 
			};
		}

		private IBcBlockEncoder<RawBlock4X4RgbFloat> GetFloatBlockEncoder(CompressionFormat format)
		{
			return format switch
			{
				CompressionFormat.Bc6S => new Bc6Encoder(signed: true), 
				CompressionFormat.Bc6U => new Bc6Encoder(signed: false), 
				_ => null, 
			};
		}

		private IRawEncoder GetRawEncoder(CompressionFormat format)
		{
			return format switch
			{
				CompressionFormat.R => new RawLuminanceEncoder(InputOptions.LuminanceAsRed), 
				CompressionFormat.Rg => new RawRgEncoder(), 
				CompressionFormat.Rgb => new RawRgbEncoder(), 
				CompressionFormat.Rgba => new RawRgbaEncoder(), 
				CompressionFormat.Bgra => new RawBgraEncoder(), 
				_ => throw new ArgumentOutOfRangeException("format", format, null), 
			};
		}

		private ReadOnlyMemory2D<ColorRgba32> ByteToColorMemory(ReadOnlySpan<byte> span, int width, int height, PixelFormat format)
		{
			ColorRgba32[] array = new ColorRgba32[width * height];
			switch (format)
			{
			case PixelFormat.Rgba32:
			{
				for (int j = 0; j < width * height * 4; j += 4)
				{
					array[j / 4] = new ColorRgba32(span[j], span[j + 1], span[j + 2], span[j + 3]);
				}
				break;
			}
			case PixelFormat.Rgb24:
			{
				for (int l = 0; l < width * height * 3; l += 3)
				{
					array[l / 3] = new ColorRgba32(span[l], span[l + 1], span[l + 2], byte.MaxValue);
				}
				break;
			}
			case PixelFormat.Bgra32:
			{
				for (int m = 0; m < width * height * 4; m += 4)
				{
					array[m / 4] = new ColorRgba32(span[m + 2], span[m + 1], span[m], span[m + 3]);
				}
				break;
			}
			case PixelFormat.Bgr24:
			{
				for (int k = 0; k < width * height * 3; k += 3)
				{
					array[k / 3] = new ColorRgba32(span[k + 2], span[k + 1], span[k], byte.MaxValue);
				}
				break;
			}
			case PixelFormat.Argb32:
			{
				for (int i = 0; i < width * height * 4; i += 4)
				{
					array[i / 4] = new ColorRgba32(span[i + 1], span[i + 2], span[i + 3], span[i]);
				}
				break;
			}
			}
			return new ReadOnlyMemory2D<ColorRgba32>(array, height, width);
		}
	}
}
