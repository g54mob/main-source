using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BCnEncoder.Decoder.Options;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;
using CommunityToolkit.HighPerformance;

namespace BCnEncoder.Decoder
{
	public class BcDecoder
	{
		public DecoderInputOptions InputOptions { get; } = new DecoderInputOptions();

		public DecoderOptions Options { get; } = new DecoderOptions();

		public DecoderOutputOptions OutputOptions { get; } = new DecoderOutputOptions();

		public Task<ColorRgba32[]> DecodeRawAsync(Stream inputStream, CompressionFormat format, int pixelWidth, int pixelHeight, CancellationToken token = default(CancellationToken))
		{
			byte[] dataArray = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(dataArray, 0, dataArray.Length);
			return Task.Run(() => DecodeRawInternal(dataArray, pixelWidth, pixelHeight, format, token), token);
		}

		public Task<ColorRgba32[]> DecodeRawAsync(ReadOnlyMemory<byte> input, CompressionFormat format, int pixelWidth, int pixelHeight, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeRawInternal(input, pixelWidth, pixelHeight, format, token), token);
		}

		public Task<ColorRgba32[]> DecodeAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternal(file, allMipMaps: false, token)[0], token);
		}

		public Task<ColorRgba32[][]> DecodeAllMipMapsAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternal(file, allMipMaps: true, token), token);
		}

		public Task<ColorRgba32[]> DecodeAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternal(file, allMipMaps: false, token)[0], token);
		}

		public Task<ColorRgba32[][]> DecodeAllMipMapsAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternal(file, allMipMaps: true, token), token);
		}

		public Task<Memory2D<ColorRgba32>> DecodeRaw2DAsync(Stream inputStream, int pixelWidth, int pixelHeight, CompressionFormat format, CancellationToken token = default(CancellationToken))
		{
			byte[] dataArray = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(dataArray, 0, dataArray.Length);
			return Task.Run(() => DecodeRawInternal(dataArray, pixelWidth, pixelHeight, format, token).AsMemory().AsMemory2D(pixelHeight, pixelWidth), token);
		}

		public Task<Memory2D<ColorRgba32>> DecodeRaw2DAsync(ReadOnlyMemory<byte> input, int pixelWidth, int pixelHeight, CompressionFormat format, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeRawInternal(input, pixelWidth, pixelHeight, format, token).AsMemory().AsMemory2D(pixelHeight, pixelWidth), token);
		}

		public Task<Memory2D<ColorRgba32>> Decode2DAsync(Stream inputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeFromStreamInternal2D(inputStream, allMipMaps: false, token)[0], token);
		}

		public Task<Memory2D<ColorRgba32>[]> DecodeAllMipMaps2DAsync(Stream inputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeFromStreamInternal2D(inputStream, allMipMaps: false, token), token);
		}

		public Task<Memory2D<ColorRgba32>> Decode2DAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternal(file, allMipMaps: false, token)[0].AsMemory().AsMemory2D((int)file.header.PixelHeight, (int)file.header.PixelWidth), token);
		}

		public Task<Memory2D<ColorRgba32>[]> DecodeAllMipMaps2DAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				ColorRgba32[][] array = DecodeInternal(file, allMipMaps: true, token);
				Memory2D<ColorRgba32>[] array2 = new Memory2D<ColorRgba32>[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					KtxMipmap ktxMipmap = file.MipMaps[i];
					array2[i] = array[i].AsMemory().AsMemory2D((int)ktxMipmap.Height, (int)ktxMipmap.Width);
				}
				return array2;
			}, token);
		}

		public Task<Memory2D<ColorRgba32>> Decode2DAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternal(file, allMipMaps: false, token)[0].AsMemory().AsMemory2D((int)file.header.dwHeight, (int)file.header.dwWidth), token);
		}

		public Task<Memory2D<ColorRgba32>[]> DecodeAllMipMaps2DAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				ColorRgba32[][] array = DecodeInternal(file, allMipMaps: true, token);
				Memory2D<ColorRgba32>[] array2 = new Memory2D<ColorRgba32>[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					DdsMipMap ddsMipMap = file.Faces[0].MipMaps[i];
					array2[i] = array[i].AsMemory().AsMemory2D((int)ddsMipMap.Height, (int)ddsMipMap.Width);
				}
				return array2;
			}, token);
		}

		public ColorRgba32[] DecodeRaw(Stream inputStream, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			byte[] array = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(array, 0, array.Length);
			return DecodeRaw(array, pixelWidth, pixelHeight, format);
		}

		public ColorRgba32[] DecodeRaw(byte[] input, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			return DecodeRawInternal(input, pixelWidth, pixelHeight, format, default(CancellationToken));
		}

		public ColorRgba32[] Decode(KtxFile file)
		{
			return DecodeInternal(file, allMipMaps: false, default(CancellationToken))[0];
		}

		public ColorRgba32[][] DecodeAllMipMaps(KtxFile file)
		{
			return DecodeInternal(file, allMipMaps: true, default(CancellationToken));
		}

		public ColorRgba32[] Decode(DdsFile file)
		{
			return DecodeInternal(file, allMipMaps: false, default(CancellationToken))[0];
		}

		public ColorRgba32[][] DecodeAllMipMaps(DdsFile file)
		{
			return DecodeInternal(file, allMipMaps: true, default(CancellationToken));
		}

		public Memory2D<ColorRgba32> DecodeRaw2D(Stream inputStream, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			byte[] array = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(array, 0, array.Length);
			return DecodeRaw(array, pixelWidth, pixelHeight, format).AsMemory().AsMemory2D(pixelHeight, pixelWidth);
		}

		public Memory2D<ColorRgba32> DecodeRaw2D(byte[] input, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			return DecodeRawInternal(input, pixelWidth, pixelHeight, format, default(CancellationToken)).AsMemory().AsMemory2D(pixelHeight, pixelWidth);
		}

		public Memory2D<ColorRgba32> Decode2D(Stream inputStream)
		{
			return DecodeFromStreamInternal2D(inputStream, allMipMaps: false, default(CancellationToken))[0];
		}

		public Memory2D<ColorRgba32>[] DecodeAllMipMaps2D(Stream inputStream)
		{
			return DecodeFromStreamInternal2D(inputStream, allMipMaps: true, default(CancellationToken));
		}

		public Memory2D<ColorRgba32> Decode2D(KtxFile file)
		{
			return DecodeInternal(file, allMipMaps: false, default(CancellationToken))[0].AsMemory().AsMemory2D((int)file.header.PixelHeight, (int)file.header.PixelWidth);
		}

		public Memory2D<ColorRgba32>[] DecodeAllMipMaps2D(KtxFile file)
		{
			ColorRgba32[][] array = DecodeInternal(file, allMipMaps: true, default(CancellationToken));
			Memory2D<ColorRgba32>[] array2 = new Memory2D<ColorRgba32>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				KtxMipmap ktxMipmap = file.MipMaps[i];
				array2[i] = array[i].AsMemory().AsMemory2D((int)ktxMipmap.Height, (int)ktxMipmap.Width);
			}
			return array2;
		}

		public Memory2D<ColorRgba32> Decode2D(DdsFile file)
		{
			return DecodeInternal(file, allMipMaps: false, default(CancellationToken))[0].AsMemory().AsMemory2D((int)file.header.dwHeight, (int)file.header.dwWidth);
		}

		public Memory2D<ColorRgba32>[] DecodeAllMipMaps2D(DdsFile file)
		{
			ColorRgba32[][] array = DecodeInternal(file, allMipMaps: true, default(CancellationToken));
			Memory2D<ColorRgba32>[] array2 = new Memory2D<ColorRgba32>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				DdsMipMap ddsMipMap = file.Faces[0].MipMaps[i];
				array2[i] = array[i].AsMemory().AsMemory2D((int)ddsMipMap.Height, (int)ddsMipMap.Width);
			}
			return array2;
		}

		public Memory2D<ColorRgba32> DecodeBlock(ReadOnlySpan<byte> blockData, CompressionFormat format)
		{
			ColorRgba32[,] array = new ColorRgba32[4, 4];
			DecodeBlockInternal(blockData, format, array);
			return array;
		}

		public void DecodeBlock(ReadOnlySpan<byte> blockData, CompressionFormat format, Span2D<ColorRgba32> outputSpan)
		{
			if (outputSpan.Width != 4 || outputSpan.Height != 4)
			{
				throw new ArgumentException("Single block decoding needs an output span of exactly 4x4");
			}
			DecodeBlockInternal(blockData, format, outputSpan);
		}

		public int DecodeBlock(Stream inputStream, CompressionFormat format, Span2D<ColorRgba32> outputSpan)
		{
			if (outputSpan.Width != 4 || outputSpan.Height != 4)
			{
				throw new ArgumentException("Single block decoding needs an output span of exactly 4x4");
			}
			Span<byte> span = stackalloc byte[16];
			span = span.Slice(0, GetBlockSize(format));
			int num = inputStream.Read(span);
			if (num == 0)
			{
				return 0;
			}
			if (num != span.Length)
			{
				throw new Exception("Input stream does not have enough data available for a full block.");
			}
			DecodeBlockInternal(span, format, outputSpan);
			return num;
		}

		public bool IsSupportedFormat(KtxFile file)
		{
			return GetCompressionFormat(file.header.GlInternalFormat) != CompressionFormat.Unknown;
		}

		public bool IsSupportedFormat(DdsFile file)
		{
			return GetCompressionFormat(file) != CompressionFormat.Unknown;
		}

		public CompressionFormat GetFormat(KtxFile file)
		{
			return GetCompressionFormat(file.header.GlInternalFormat);
		}

		public CompressionFormat GetFormat(DdsFile file)
		{
			return GetCompressionFormat(file);
		}

		public Task<ColorRgbFloat[]> DecodeRawHdrAsync(Stream inputStream, CompressionFormat format, int pixelWidth, int pixelHeight, CancellationToken token = default(CancellationToken))
		{
			byte[] dataArray = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(dataArray, 0, dataArray.Length);
			return Task.Run(() => DecodeRawInternalHdr(dataArray, pixelWidth, pixelHeight, format, token), token);
		}

		public Task<ColorRgbFloat[]> DecodeRawHdrAsync(ReadOnlyMemory<byte> input, CompressionFormat format, int pixelWidth, int pixelHeight, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeRawInternalHdr(input, pixelWidth, pixelHeight, format, token), token);
		}

		public Task<ColorRgbFloat[]> DecodeHdrAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternalHdr(file, allMipMaps: false, token)[0], token);
		}

		public Task<ColorRgbFloat[][]> DecodeAllMipMapsHdrAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternalHdr(file, allMipMaps: true, token), token);
		}

		public Task<ColorRgbFloat[]> DecodeHdrAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternalHdr(file, allMipMaps: false, token)[0], token);
		}

		public Task<ColorRgbFloat[][]> DecodeAllMipMapsHdrAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternalHdr(file, allMipMaps: true, token), token);
		}

		public Task<Memory2D<ColorRgbFloat>> DecodeRawHdr2DAsync(Stream inputStream, int pixelWidth, int pixelHeight, CompressionFormat format, CancellationToken token = default(CancellationToken))
		{
			byte[] dataArray = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(dataArray, 0, dataArray.Length);
			return Task.Run(() => DecodeRawInternalHdr(dataArray, pixelWidth, pixelHeight, format, token).AsMemory().AsMemory2D(pixelHeight, pixelWidth), token);
		}

		public Task<Memory2D<ColorRgbFloat>> DecodeRawHdr2DAsync(ReadOnlyMemory<byte> input, int pixelWidth, int pixelHeight, CompressionFormat format, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeRawInternalHdr(input, pixelWidth, pixelHeight, format, token).AsMemory().AsMemory2D(pixelHeight, pixelWidth), token);
		}

		public Task<Memory2D<ColorRgbFloat>> DecodeHdr2DAsync(Stream inputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeFromStreamInternalHdr2D(inputStream, allMipMaps: false, token)[0], token);
		}

		public Task<Memory2D<ColorRgbFloat>[]> DecodeAllMipMapsHdr2DAsync(Stream inputStream, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeFromStreamInternalHdr2D(inputStream, allMipMaps: false, token), token);
		}

		public Task<Memory2D<ColorRgbFloat>> DecodeHdr2DAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternalHdr(file, allMipMaps: false, token)[0].AsMemory().AsMemory2D((int)file.header.PixelHeight, (int)file.header.PixelWidth), token);
		}

		public Task<Memory2D<ColorRgbFloat>[]> DecodeAllMipMapsHdr2DAsync(KtxFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				ColorRgbFloat[][] array = DecodeInternalHdr(file, allMipMaps: true, token);
				Memory2D<ColorRgbFloat>[] array2 = new Memory2D<ColorRgbFloat>[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					KtxMipmap ktxMipmap = file.MipMaps[i];
					array2[i] = array[i].AsMemory().AsMemory2D((int)ktxMipmap.Height, (int)ktxMipmap.Width);
				}
				return array2;
			}, token);
		}

		public Task<Memory2D<ColorRgbFloat>> DecodeHdr2DAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(() => DecodeInternalHdr(file, allMipMaps: false, token)[0].AsMemory().AsMemory2D((int)file.header.dwHeight, (int)file.header.dwWidth), token);
		}

		public Task<Memory2D<ColorRgbFloat>[]> DecodeAllMipMapsHdr2DAsync(DdsFile file, CancellationToken token = default(CancellationToken))
		{
			return Task.Run(delegate
			{
				ColorRgbFloat[][] array = DecodeInternalHdr(file, allMipMaps: true, token);
				Memory2D<ColorRgbFloat>[] array2 = new Memory2D<ColorRgbFloat>[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					DdsMipMap ddsMipMap = file.Faces[0].MipMaps[i];
					array2[i] = array[i].AsMemory().AsMemory2D((int)ddsMipMap.Height, (int)ddsMipMap.Width);
				}
				return array2;
			}, token);
		}

		public ColorRgbFloat[] DecodeRawHdr(Stream inputStream, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			byte[] array = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(array, 0, array.Length);
			return DecodeRawHdr(array, pixelWidth, pixelHeight, format);
		}

		public ColorRgbFloat[] DecodeRawHdr(byte[] input, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			return DecodeRawInternalHdr(input, pixelWidth, pixelHeight, format, default(CancellationToken));
		}

		public ColorRgbFloat[] DecodeHdr(KtxFile file)
		{
			return DecodeInternalHdr(file, allMipMaps: false, default(CancellationToken))[0];
		}

		public ColorRgbFloat[][] DecodeAllMipMapsHdr(KtxFile file)
		{
			return DecodeInternalHdr(file, allMipMaps: true, default(CancellationToken));
		}

		public ColorRgbFloat[] DecodeHdr(DdsFile file)
		{
			return DecodeInternalHdr(file, allMipMaps: false, default(CancellationToken))[0];
		}

		public ColorRgbFloat[][] DecodeAllMipMapsHdr(DdsFile file)
		{
			return DecodeInternalHdr(file, allMipMaps: true, default(CancellationToken));
		}

		public Memory2D<ColorRgbFloat> DecodeRawHdr2D(Stream inputStream, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			byte[] array = new byte[GetBufferSize(format, pixelWidth, pixelHeight)];
			inputStream.Read(array, 0, array.Length);
			return DecodeRawHdr(array, pixelWidth, pixelHeight, format).AsMemory().AsMemory2D(pixelHeight, pixelWidth);
		}

		public Memory2D<ColorRgbFloat> DecodeRawHdr2D(byte[] input, int pixelWidth, int pixelHeight, CompressionFormat format)
		{
			return DecodeRawInternalHdr(input, pixelWidth, pixelHeight, format, default(CancellationToken)).AsMemory().AsMemory2D(pixelHeight, pixelWidth);
		}

		public Memory2D<ColorRgbFloat> DecodeHdr2D(Stream inputStream)
		{
			return DecodeFromStreamInternalHdr2D(inputStream, allMipMaps: false, default(CancellationToken))[0];
		}

		public Memory2D<ColorRgbFloat>[] DecodeAllMipMapsHdr2D(Stream inputStream)
		{
			return DecodeFromStreamInternalHdr2D(inputStream, allMipMaps: true, default(CancellationToken));
		}

		public Memory2D<ColorRgbFloat> DecodeHdr2D(KtxFile file)
		{
			return DecodeInternalHdr(file, allMipMaps: false, default(CancellationToken))[0].AsMemory().AsMemory2D((int)file.header.PixelHeight, (int)file.header.PixelWidth);
		}

		public Memory2D<ColorRgbFloat>[] DecodeAllMipMapsHdr2D(KtxFile file)
		{
			ColorRgbFloat[][] array = DecodeInternalHdr(file, allMipMaps: true, default(CancellationToken));
			Memory2D<ColorRgbFloat>[] array2 = new Memory2D<ColorRgbFloat>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				KtxMipmap ktxMipmap = file.MipMaps[i];
				array2[i] = array[i].AsMemory().AsMemory2D((int)ktxMipmap.Height, (int)ktxMipmap.Width);
			}
			return array2;
		}

		public Memory2D<ColorRgbFloat> DecodeHdr2D(DdsFile file)
		{
			return DecodeInternalHdr(file, allMipMaps: false, default(CancellationToken))[0].AsMemory().AsMemory2D((int)file.header.dwHeight, (int)file.header.dwWidth);
		}

		public Memory2D<ColorRgbFloat>[] DecodeAllMipMapsHdr2D(DdsFile file)
		{
			ColorRgbFloat[][] array = DecodeInternalHdr(file, allMipMaps: true, default(CancellationToken));
			Memory2D<ColorRgbFloat>[] array2 = new Memory2D<ColorRgbFloat>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				DdsMipMap ddsMipMap = file.Faces[0].MipMaps[i];
				array2[i] = array[i].AsMemory().AsMemory2D((int)ddsMipMap.Height, (int)ddsMipMap.Width);
			}
			return array2;
		}

		public Memory2D<ColorRgbFloat> DecodeBlockHdr(ReadOnlySpan<byte> blockData, CompressionFormat format)
		{
			ColorRgbFloat[,] array = new ColorRgbFloat[4, 4];
			DecodeBlockInternalHdr(blockData, format, array);
			return array;
		}

		public void DecodeBlockHdr(ReadOnlySpan<byte> blockData, CompressionFormat format, Span2D<ColorRgbFloat> outputSpan)
		{
			if (outputSpan.Width != 4 || outputSpan.Height != 4)
			{
				throw new ArgumentException("Single block decoding needs an output span of exactly 4x4");
			}
			DecodeBlockInternalHdr(blockData, format, outputSpan);
		}

		public int DecodeBlockHdr(Stream inputStream, CompressionFormat format, Span2D<ColorRgbFloat> outputSpan)
		{
			if (outputSpan.Width != 4 || outputSpan.Height != 4)
			{
				throw new ArgumentException("Single block decoding needs an output span of exactly 4x4");
			}
			Span<byte> span = stackalloc byte[16];
			span = span.Slice(0, GetBlockSize(format));
			int num = inputStream.Read(span);
			if (num == 0)
			{
				return 0;
			}
			if (num != span.Length)
			{
				throw new Exception("Input stream does not have enough data available for a full block.");
			}
			DecodeBlockInternalHdr(span, format, outputSpan);
			return num;
		}

		public bool IsHdrFormat(KtxFile file)
		{
			return GetCompressionFormat(file.header.GlInternalFormat).IsHdrFormat();
		}

		public bool IsHdrFormat(DdsFile file)
		{
			return GetCompressionFormat(file).IsHdrFormat();
		}

		private Memory2D<ColorRgba32>[] DecodeFromStreamInternal2D(Stream stream, bool allMipMaps, CancellationToken token)
		{
			switch (ImageFile.DetermineImageFormat(stream))
			{
			case ImageFileFormat.Dds:
			{
				DdsFile ddsFile = DdsFile.Load(stream);
				ColorRgba32[][] array3 = DecodeInternal(ddsFile, allMipMaps, token);
				Memory2D<ColorRgba32>[] array4 = new Memory2D<ColorRgba32>[array3.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					DdsMipMap ddsMipMap = ddsFile.Faces[0].MipMaps[j];
					array4[j] = array3[j].AsMemory().AsMemory2D((int)ddsMipMap.Height, (int)ddsMipMap.Width);
				}
				return array4;
			}
			case ImageFileFormat.Ktx:
			{
				KtxFile ktxFile = KtxFile.Load(stream);
				ColorRgba32[][] array = DecodeInternal(ktxFile, allMipMaps, token);
				Memory2D<ColorRgba32>[] array2 = new Memory2D<ColorRgba32>[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					KtxMipmap ktxMipmap = ktxFile.MipMaps[i];
					array2[i] = array[i].AsMemory().AsMemory2D((int)ktxMipmap.Height, (int)ktxMipmap.Width);
				}
				return array2;
			}
			default:
				throw new InvalidOperationException("Unknown image format.");
			}
		}

		private ColorRgba32[][] DecodeInternal(KtxFile file, bool allMipMaps, CancellationToken token)
		{
			int num = ((!allMipMaps) ? 1 : file.MipMaps.Count);
			ColorRgba32[][] array = new ColorRgba32[num][];
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = Options.IsParallel,
				TaskCount = Options.TaskCount
			};
			int blockSize = GetBlockSize(file.header.GlInternalFormat);
			int totalBlocks = file.MipMaps.Take(num).Sum((KtxMipmap m) => m.Faces[0].Data.Length / blockSize);
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			if (IsSupportedRawFormat(file.header.GlInternalFormat))
			{
				IRawDecoder rawDecoder = GetRawDecoder(file.header.GlInternalFormat);
				for (int num2 = 0; num2 < num; num2++)
				{
					byte[] data = file.MipMaps[num2].Faces[0].Data;
					array[num2] = rawDecoder.Decode(data, operationContext);
					operationContext.Progress.SetProcessedBlocks(file.MipMaps.Take(num2 + 1).Sum((KtxMipmap x) => x.Faces[0].Data.Length / blockSize));
				}
			}
			else
			{
				IBcBlockDecoder<RawBlock4X4Rgba32> rgba32Decoder = GetRgba32Decoder(file.header.GlInternalFormat);
				CompressionFormat compressionFormat = GetCompressionFormat(file.header.GlInternalFormat);
				if (compressionFormat.IsHdrFormat())
				{
					throw new NotSupportedException($"This Format is not an RGBA32 compatible format: {compressionFormat}, please use the HDR versions of the decode methods.");
				}
				if (rgba32Decoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {file.header.GlInternalFormat}");
				}
				for (int num3 = 0; num3 < num; num3++)
				{
					byte[] data2 = file.MipMaps[num3].Faces[0].Data;
					uint width = file.MipMaps[num3].Width;
					uint height = file.MipMaps[num3].Height;
					RawBlock4X4Rgba32[] blocks = rgba32Decoder.Decode(data2, operationContext);
					array[num3] = ImageToBlocks.ColorsFromRawBlocks(blocks, (int)width, (int)height);
					operationContext.Progress.SetProcessedBlocks(file.MipMaps.Take(num3 + 1).Sum((KtxMipmap x) => x.Faces[0].Data.Length / blockSize));
				}
			}
			return array;
		}

		private ColorRgba32[][] DecodeInternal(DdsFile file, bool allMipMaps, CancellationToken token)
		{
			uint num = ((!allMipMaps) ? 1u : file.header.dwMipMapCount);
			ColorRgba32[][] array = new ColorRgba32[num][];
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = Options.IsParallel,
				TaskCount = Options.TaskCount
			};
			int blockSize = GetBlockSize(file);
			int totalBlocks = file.Faces[0].MipMaps.Take((int)num).Sum((DdsMipMap m) => m.Data.Length / blockSize);
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			if (IsSupportedRawFormat(file))
			{
				IRawDecoder rawDecoder = GetRawDecoder(file);
				for (int num2 = 0; num2 < num; num2++)
				{
					byte[] data = file.Faces[0].MipMaps[num2].Data;
					array[num2] = rawDecoder.Decode(data, operationContext);
					operationContext.Progress.SetProcessedBlocks(file.Faces[0].MipMaps.Take(num2 + 1).Sum((DdsMipMap x) => x.Data.Length / blockSize));
				}
			}
			else
			{
				DxgiFormat dxgiFormat = (file.header.ddsPixelFormat.IsDxt10Format ? file.dx10Header.dxgiFormat : file.header.ddsPixelFormat.DxgiFormat);
				CompressionFormat compressionFormat = GetCompressionFormat(file);
				IBcBlockDecoder<RawBlock4X4Rgba32> rgba32Decoder = GetRgba32Decoder(compressionFormat);
				if (compressionFormat.IsHdrFormat())
				{
					throw new NotSupportedException($"This Format is not an RGBA32 compatible format: {compressionFormat}, please use the HDR versions of the decode methods.");
				}
				if (rgba32Decoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {dxgiFormat}");
				}
				for (int num3 = 0; num3 < num; num3++)
				{
					byte[] data2 = file.Faces[0].MipMaps[num3].Data;
					uint width = file.Faces[0].MipMaps[num3].Width;
					uint height = file.Faces[0].MipMaps[num3].Height;
					ColorRgba32[] array2 = ImageToBlocks.ColorsFromRawBlocks(rgba32Decoder.Decode(data2, operationContext), (int)width, (int)height);
					array[num3] = array2;
					operationContext.Progress.SetProcessedBlocks(file.Faces[0].MipMaps.Take(num3 + 1).Sum((DdsMipMap x) => x.Data.Length / blockSize));
				}
			}
			return array;
		}

		private ColorRgba32[] DecodeRawInternal(ReadOnlyMemory<byte> input, int pixelWidth, int pixelHeight, CompressionFormat format, CancellationToken token)
		{
			if (input.Length % GetBlockSize(format) != 0)
			{
				throw new ArgumentException("The size of the input buffer does not align with the compression format.");
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = Options.IsParallel,
				TaskCount = Options.TaskCount
			};
			int blockSize = GetBlockSize(format);
			int totalBlocks = input.Length / blockSize;
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			if (format.IsCompressedFormat())
			{
				IBcBlockDecoder<RawBlock4X4Rgba32> rgba32Decoder = GetRgba32Decoder(format);
				if (format.IsHdrFormat())
				{
					throw new NotSupportedException($"This Format is not an RGBA32 compatible format: {format}, please use the HDR versions of the decode methods.");
				}
				if (rgba32Decoder == null)
				{
					throw new NotSupportedException($"This Format is not supported: {format}");
				}
				return ImageToBlocks.ColorsFromRawBlocks(rgba32Decoder.Decode(input, operationContext), pixelWidth, pixelHeight);
			}
			return GetRawDecoder(format).Decode(input, operationContext);
		}

		private void DecodeBlockInternal(ReadOnlySpan<byte> blockData, CompressionFormat format, Span2D<ColorRgba32> outputSpan)
		{
			IBcBlockDecoder<RawBlock4X4Rgba32> rgba32Decoder = GetRgba32Decoder(format);
			if (format.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not an RGBA32 compatible format: {format}, please use the HDR versions of the decode methods.");
			}
			if (rgba32Decoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {format}");
			}
			if (blockData.Length != GetBlockSize(format))
			{
				throw new ArgumentException("The size of the input buffer does not align with the compression format.");
			}
			Span<ColorRgba32> asSpan = rgba32Decoder.DecodeBlock(blockData).AsSpan;
			asSpan.Slice(0, 4).CopyTo(outputSpan.GetRowSpan(0));
			asSpan.Slice(4, 4).CopyTo(outputSpan.GetRowSpan(1));
			asSpan.Slice(8, 4).CopyTo(outputSpan.GetRowSpan(2));
			asSpan.Slice(12, 4).CopyTo(outputSpan.GetRowSpan(3));
		}

		private Memory2D<ColorRgbFloat>[] DecodeFromStreamInternalHdr2D(Stream stream, bool allMipMaps, CancellationToken token)
		{
			switch (ImageFile.DetermineImageFormat(stream))
			{
			case ImageFileFormat.Dds:
			{
				DdsFile ddsFile = DdsFile.Load(stream);
				ColorRgbFloat[][] array3 = DecodeInternalHdr(ddsFile, allMipMaps, token);
				Memory2D<ColorRgbFloat>[] array4 = new Memory2D<ColorRgbFloat>[array3.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					DdsMipMap ddsMipMap = ddsFile.Faces[0].MipMaps[j];
					array4[j] = array3[j].AsMemory().AsMemory2D((int)ddsMipMap.Height, (int)ddsMipMap.Width);
				}
				return array4;
			}
			case ImageFileFormat.Ktx:
			{
				KtxFile ktxFile = KtxFile.Load(stream);
				ColorRgbFloat[][] array = DecodeInternalHdr(ktxFile, allMipMaps, token);
				Memory2D<ColorRgbFloat>[] array2 = new Memory2D<ColorRgbFloat>[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					KtxMipmap ktxMipmap = ktxFile.MipMaps[i];
					array2[i] = array[i].AsMemory().AsMemory2D((int)ktxMipmap.Height, (int)ktxMipmap.Width);
				}
				return array2;
			}
			default:
				throw new InvalidOperationException("Unknown image format.");
			}
		}

		private ColorRgbFloat[][] DecodeInternalHdr(KtxFile file, bool allMipMaps, CancellationToken token)
		{
			int num = ((!allMipMaps) ? 1 : file.MipMaps.Count);
			ColorRgbFloat[][] array = new ColorRgbFloat[num][];
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = Options.IsParallel,
				TaskCount = Options.TaskCount
			};
			int blockSize = GetBlockSize(file.header.GlInternalFormat);
			int totalBlocks = file.MipMaps.Take(num).Sum((KtxMipmap m) => m.Faces[0].Data.Length / blockSize);
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			IBcBlockDecoder<RawBlock4X4RgbFloat> rgbFloatDecoder = GetRgbFloatDecoder(file.header.GlInternalFormat);
			CompressionFormat compressionFormat = GetCompressionFormat(file.header.GlInternalFormat);
			if (!compressionFormat.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not an HDR format: {compressionFormat}, please use the non-HDR versions of the decode methods.");
			}
			if (rgbFloatDecoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {file.header.GlInternalFormat}");
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				byte[] data = file.MipMaps[num2].Faces[0].Data;
				uint width = file.MipMaps[num2].Width;
				uint height = file.MipMaps[num2].Height;
				RawBlock4X4RgbFloat[] blocks = rgbFloatDecoder.Decode(data, operationContext);
				array[num2] = ImageToBlocks.ColorsFromRawBlocks(blocks, (int)width, (int)height);
				operationContext.Progress.SetProcessedBlocks(file.MipMaps.Take(num2 + 1).Sum((KtxMipmap x) => x.Faces[0].Data.Length / blockSize));
			}
			return array;
		}

		private ColorRgbFloat[][] DecodeInternalHdr(DdsFile file, bool allMipMaps, CancellationToken token)
		{
			uint num = ((!allMipMaps) ? 1u : file.header.dwMipMapCount);
			ColorRgbFloat[][] array = new ColorRgbFloat[num][];
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = Options.IsParallel,
				TaskCount = Options.TaskCount
			};
			int blockSize = GetBlockSize(file);
			int totalBlocks = file.Faces[0].MipMaps.Take((int)num).Sum((DdsMipMap m) => m.Data.Length / blockSize);
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			DxgiFormat dxgiFormat = (file.header.ddsPixelFormat.IsDxt10Format ? file.dx10Header.dxgiFormat : file.header.ddsPixelFormat.DxgiFormat);
			CompressionFormat compressionFormat = GetCompressionFormat(file);
			IBcBlockDecoder<RawBlock4X4RgbFloat> rgbFloatDecoder = GetRgbFloatDecoder(compressionFormat);
			if (!compressionFormat.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not an HDR format: {compressionFormat}, please use the non-HDR versions of the decode methods.");
			}
			if (rgbFloatDecoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {dxgiFormat}");
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				byte[] data = file.Faces[0].MipMaps[num2].Data;
				uint width = file.Faces[0].MipMaps[num2].Width;
				uint height = file.Faces[0].MipMaps[num2].Height;
				ColorRgbFloat[] array2 = ImageToBlocks.ColorsFromRawBlocks(rgbFloatDecoder.Decode(data, operationContext), (int)width, (int)height);
				array[num2] = array2;
				operationContext.Progress.SetProcessedBlocks(file.Faces[0].MipMaps.Take(num2 + 1).Sum((DdsMipMap x) => x.Data.Length / blockSize));
			}
			return array;
		}

		private ColorRgbFloat[] DecodeRawInternalHdr(ReadOnlyMemory<byte> input, int pixelWidth, int pixelHeight, CompressionFormat format, CancellationToken token)
		{
			if (input.Length % GetBlockSize(format) != 0)
			{
				throw new ArgumentException("The size of the input buffer does not align with the compression format.");
			}
			OperationContext operationContext = new OperationContext
			{
				CancellationToken = token,
				IsParallel = Options.IsParallel,
				TaskCount = Options.TaskCount
			};
			int blockSize = GetBlockSize(format);
			int totalBlocks = input.Length / blockSize;
			operationContext.Progress = new OperationProgress(Options.Progress, totalBlocks);
			IBcBlockDecoder<RawBlock4X4RgbFloat> rgbFloatDecoder = GetRgbFloatDecoder(format);
			if (!format.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not an HDR format: {format}, please use the non-HDR versions of the decode methods.");
			}
			if (rgbFloatDecoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {format}");
			}
			return ImageToBlocks.ColorsFromRawBlocks(rgbFloatDecoder.Decode(input, operationContext), pixelWidth, pixelHeight);
		}

		private void DecodeBlockInternalHdr(ReadOnlySpan<byte> blockData, CompressionFormat format, Span2D<ColorRgbFloat> outputSpan)
		{
			IBcBlockDecoder<RawBlock4X4RgbFloat> rgbFloatDecoder = GetRgbFloatDecoder(format);
			if (!format.IsHdrFormat())
			{
				throw new NotSupportedException($"This Format is not an HDR format: {format}, please use the non-HDR versions of the decode methods.");
			}
			if (rgbFloatDecoder == null)
			{
				throw new NotSupportedException($"This Format is not supported: {format}");
			}
			if (blockData.Length != GetBlockSize(format))
			{
				throw new ArgumentException("The size of the input buffer does not align with the compression format.");
			}
			Span<ColorRgbFloat> asSpan = rgbFloatDecoder.DecodeBlock(blockData).AsSpan;
			asSpan.Slice(0, 4).CopyTo(outputSpan.GetRowSpan(0));
			asSpan.Slice(4, 4).CopyTo(outputSpan.GetRowSpan(1));
			asSpan.Slice(8, 4).CopyTo(outputSpan.GetRowSpan(2));
			asSpan.Slice(12, 4).CopyTo(outputSpan.GetRowSpan(3));
		}

		private bool IsSupportedRawFormat(GlInternalFormat format)
		{
			return IsSupportedRawFormat(GetCompressionFormat(format));
		}

		private bool IsSupportedRawFormat(DdsFile file)
		{
			return IsSupportedRawFormat(GetCompressionFormat(file));
		}

		private bool IsSupportedRawFormat(CompressionFormat format)
		{
			if ((uint)format <= 4u)
			{
				return true;
			}
			return false;
		}

		private IBcBlockDecoder<RawBlock4X4Rgba32> GetRgba32Decoder(GlInternalFormat format)
		{
			return GetRgba32Decoder(GetCompressionFormat(format));
		}

		private IBcBlockDecoder<RawBlock4X4Rgba32> GetRgba32Decoder(DdsFile file)
		{
			return GetRgba32Decoder(GetCompressionFormat(file));
		}

		private IBcBlockDecoder<RawBlock4X4Rgba32> GetRgba32Decoder(CompressionFormat format)
		{
			return format switch
			{
				CompressionFormat.Bc1 => new Bc1NoAlphaDecoder(), 
				CompressionFormat.Bc1WithAlpha => new Bc1ADecoder(), 
				CompressionFormat.Bc2 => new Bc2Decoder(), 
				CompressionFormat.Bc3 => new Bc3Decoder(), 
				CompressionFormat.Bc4 => new Bc4Decoder(OutputOptions.Bc4Component), 
				CompressionFormat.Bc5 => new Bc5Decoder(OutputOptions.Bc5Component1, OutputOptions.Bc5Component2), 
				CompressionFormat.Bc7 => new Bc7Decoder(), 
				CompressionFormat.Atc => new AtcDecoder(), 
				CompressionFormat.AtcExplicitAlpha => new AtcExplicitAlphaDecoder(), 
				CompressionFormat.AtcInterpolatedAlpha => new AtcInterpolatedAlphaDecoder(), 
				_ => null, 
			};
		}

		private IBcBlockDecoder<RawBlock4X4RgbFloat> GetRgbFloatDecoder(GlInternalFormat format)
		{
			return GetRgbFloatDecoder(GetCompressionFormat(format));
		}

		private IBcBlockDecoder<RawBlock4X4RgbFloat> GetRgbFloatDecoder(DdsFile file)
		{
			return GetRgbFloatDecoder(GetCompressionFormat(file));
		}

		private IBcBlockDecoder<RawBlock4X4RgbFloat> GetRgbFloatDecoder(CompressionFormat format)
		{
			return format switch
			{
				CompressionFormat.Bc6S => new Bc6SDecoder(), 
				CompressionFormat.Bc6U => new Bc6UDecoder(), 
				_ => null, 
			};
		}

		private IRawDecoder GetRawDecoder(GlInternalFormat format)
		{
			return GetRawDecoder(GetCompressionFormat(format));
		}

		private IRawDecoder GetRawDecoder(DdsFile file)
		{
			return GetRawDecoder(GetCompressionFormat(file));
		}

		private IRawDecoder GetRawDecoder(CompressionFormat format)
		{
			return format switch
			{
				CompressionFormat.R => new RawRDecoder(OutputOptions.RedAsLuminance), 
				CompressionFormat.Rg => new RawRgDecoder(), 
				CompressionFormat.Rgb => new RawRgbDecoder(), 
				CompressionFormat.Rgba => new RawRgbaDecoder(), 
				CompressionFormat.Bgra => new RawBgraDecoder(), 
				_ => throw new ArgumentOutOfRangeException("format", format, null), 
			};
		}

		public int GetBlockCount(int pixelWidth, int pixelHeight)
		{
			return ImageToBlocks.CalculateNumOfBlocks(pixelWidth, pixelHeight);
		}

		public void GetBlockCount(int pixelWidth, int pixelHeight, out int blocksWidth, out int blocksHeight)
		{
			ImageToBlocks.CalculateNumOfBlocks(pixelWidth, pixelHeight, out blocksWidth, out blocksHeight);
		}

		private int GetBlockSize(GlInternalFormat format)
		{
			return GetBlockSize(GetCompressionFormat(format));
		}

		private int GetBlockSize(DdsFile file)
		{
			return GetBlockSize(GetCompressionFormat(file));
		}

		public int GetBlockSize(CompressionFormat format)
		{
			switch (format)
			{
			case CompressionFormat.R:
				return 1;
			case CompressionFormat.Rg:
				return 2;
			case CompressionFormat.Rgb:
				return 3;
			case CompressionFormat.Rgba:
				return 4;
			case CompressionFormat.Bgra:
				return 4;
			case CompressionFormat.Bc1:
			case CompressionFormat.Bc1WithAlpha:
				return Unsafe.SizeOf<Bc1Block>();
			case CompressionFormat.Bc2:
				return Unsafe.SizeOf<Bc2Block>();
			case CompressionFormat.Bc3:
				return Unsafe.SizeOf<Bc3Block>();
			case CompressionFormat.Bc4:
				return Unsafe.SizeOf<Bc4Block>();
			case CompressionFormat.Bc5:
				return Unsafe.SizeOf<Bc5Block>();
			case CompressionFormat.Bc6U:
			case CompressionFormat.Bc6S:
				return Unsafe.SizeOf<Bc6Block>();
			case CompressionFormat.Bc7:
				return Unsafe.SizeOf<Bc7Block>();
			case CompressionFormat.Atc:
				return Unsafe.SizeOf<AtcBlock>();
			case CompressionFormat.AtcExplicitAlpha:
				return Unsafe.SizeOf<AtcExplicitAlphaBlock>();
			case CompressionFormat.AtcInterpolatedAlpha:
				return Unsafe.SizeOf<AtcInterpolatedAlphaBlock>();
			case CompressionFormat.Unknown:
				return 0;
			default:
				throw new ArgumentOutOfRangeException("format", format, null);
			}
		}

		private CompressionFormat GetCompressionFormat(GlInternalFormat format)
		{
			switch (format)
			{
			case GlInternalFormat.GlR8:
				return CompressionFormat.R;
			case GlInternalFormat.GlRg8:
				return CompressionFormat.Rg;
			case GlInternalFormat.GlRgb8:
				return CompressionFormat.Rgb;
			case GlInternalFormat.GlRgba8:
				return CompressionFormat.Rgba;
			case GlInternalFormat.GlBgra8Extension:
				return CompressionFormat.Bgra;
			case GlInternalFormat.GlCompressedRgbS3TcDxt1Ext:
				return CompressionFormat.Bc1;
			case GlInternalFormat.GlCompressedRgbaS3TcDxt1Ext:
				return CompressionFormat.Bc1WithAlpha;
			case GlInternalFormat.GlCompressedRgbaS3TcDxt3Ext:
				return CompressionFormat.Bc2;
			case GlInternalFormat.GlCompressedRgbaS3TcDxt5Ext:
				return CompressionFormat.Bc3;
			case GlInternalFormat.GlCompressedRedRgtc1Ext:
				return CompressionFormat.Bc4;
			case GlInternalFormat.GlCompressedRedGreenRgtc2Ext:
				return CompressionFormat.Bc5;
			case GlInternalFormat.GlCompressedRgbBptcUnsignedFloatArb:
				return CompressionFormat.Bc6U;
			case GlInternalFormat.GlCompressedRgbBptcSignedFloatArb:
				return CompressionFormat.Bc6S;
			case GlInternalFormat.GlCompressedRgbaBptcUnormArb:
			case GlInternalFormat.GlCompressedSrgbAlphaBptcUnormArb:
				return CompressionFormat.Bc7;
			case GlInternalFormat.GlCompressedRgbAtc:
				return CompressionFormat.Atc;
			case GlInternalFormat.GlCompressedRgbaAtcExplicitAlpha:
				return CompressionFormat.AtcExplicitAlpha;
			case GlInternalFormat.GlCompressedRgbaAtcInterpolatedAlpha:
				return CompressionFormat.AtcInterpolatedAlpha;
			default:
				return CompressionFormat.Unknown;
			}
		}

		private CompressionFormat GetCompressionFormat(DdsFile file)
		{
			switch (file.header.ddsPixelFormat.IsDxt10Format ? file.dx10Header.dxgiFormat : file.header.ddsPixelFormat.DxgiFormat)
			{
			case DxgiFormat.DxgiFormatR8Unorm:
				return CompressionFormat.R;
			case DxgiFormat.DxgiFormatR8G8Unorm:
				return CompressionFormat.Rg;
			case DxgiFormat.DxgiFormatR8G8B8A8Unorm:
				return CompressionFormat.Rgba;
			case DxgiFormat.DxgiFormatB8G8R8A8Unorm:
				return CompressionFormat.Bgra;
			case DxgiFormat.DxgiFormatBc1Typeless:
			case DxgiFormat.DxgiFormatBc1Unorm:
			case DxgiFormat.DxgiFormatBc1UnormSrgb:
				if (file.header.ddsPixelFormat.dwFlags.HasFlag(PixelFormatFlags.DdpfAlphaPixels))
				{
					return CompressionFormat.Bc1WithAlpha;
				}
				if (InputOptions.DdsBc1ExpectAlpha)
				{
					return CompressionFormat.Bc1WithAlpha;
				}
				return CompressionFormat.Bc1;
			case DxgiFormat.DxgiFormatBc2Typeless:
			case DxgiFormat.DxgiFormatBc2Unorm:
			case DxgiFormat.DxgiFormatBc2UnormSrgb:
				return CompressionFormat.Bc2;
			case DxgiFormat.DxgiFormatBc3Typeless:
			case DxgiFormat.DxgiFormatBc3Unorm:
			case DxgiFormat.DxgiFormatBc3UnormSrgb:
				return CompressionFormat.Bc3;
			case DxgiFormat.DxgiFormatBc4Typeless:
			case DxgiFormat.DxgiFormatBc4Unorm:
			case DxgiFormat.DxgiFormatBc4Snorm:
				return CompressionFormat.Bc4;
			case DxgiFormat.DxgiFormatBc5Typeless:
			case DxgiFormat.DxgiFormatBc5Unorm:
			case DxgiFormat.DxgiFormatBc5Snorm:
				return CompressionFormat.Bc5;
			case DxgiFormat.DxgiFormatBc6HTypeless:
			case DxgiFormat.DxgiFormatBc6HUf16:
				return CompressionFormat.Bc6U;
			case DxgiFormat.DxgiFormatBc6HSf16:
				return CompressionFormat.Bc6S;
			case DxgiFormat.DxgiFormatBc7Typeless:
			case DxgiFormat.DxgiFormatBc7Unorm:
			case DxgiFormat.DxgiFormatBc7UnormSrgb:
				return CompressionFormat.Bc7;
			case DxgiFormat.DxgiFormatAtcExt:
				return CompressionFormat.Atc;
			case DxgiFormat.DxgiFormatAtcExplicitAlphaExt:
				return CompressionFormat.AtcExplicitAlpha;
			case DxgiFormat.DxgiFormatAtcInterpolatedAlphaExt:
				return CompressionFormat.AtcInterpolatedAlpha;
			default:
				return CompressionFormat.Unknown;
			}
		}

		private int GetBufferSize(CompressionFormat format, int pixelWidth, int pixelHeight)
		{
			switch (format)
			{
			case CompressionFormat.R:
				return pixelWidth * pixelHeight;
			case CompressionFormat.Rg:
				return 2 * pixelWidth * pixelHeight;
			case CompressionFormat.Rgb:
				return 3 * pixelWidth * pixelHeight;
			case CompressionFormat.Rgba:
			case CompressionFormat.Bgra:
				return 4 * pixelWidth * pixelHeight;
			case CompressionFormat.Bc1:
			case CompressionFormat.Bc1WithAlpha:
			case CompressionFormat.Bc2:
			case CompressionFormat.Bc3:
			case CompressionFormat.Bc4:
			case CompressionFormat.Bc5:
			case CompressionFormat.Bc6U:
			case CompressionFormat.Bc6S:
			case CompressionFormat.Bc7:
			case CompressionFormat.Atc:
			case CompressionFormat.AtcExplicitAlpha:
			case CompressionFormat.AtcInterpolatedAlpha:
				return GetBlockSize(format) * ImageToBlocks.CalculateNumOfBlocks(pixelWidth, pixelHeight);
			case CompressionFormat.Unknown:
				return 0;
			default:
				throw new ArgumentOutOfRangeException("format", format, null);
			}
		}
	}
}
