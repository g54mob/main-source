using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal abstract class BaseBcBlockEncoder<T, TBlock> : IBcBlockEncoder<TBlock> where T : unmanaged where TBlock : unmanaged
	{
		private static readonly object lockObj = new object();

		public byte[] Encode(TBlock[] blocks, int blockWidth, int blockHeight, CompressionQuality quality, OperationContext context)
		{
			byte[] outputData = new byte[blockWidth * blockHeight * Unsafe.SizeOf<T>()];
			int currentBlocks = 0;
			if (context.IsParallel)
			{
				ParallelOptions parallelOptions = new ParallelOptions
				{
					CancellationToken = context.CancellationToken,
					MaxDegreeOfParallelism = context.TaskCount
				};
				Parallel.For(0, blocks.Length, parallelOptions, delegate(int i)
				{
					MemoryMarshal.Cast<byte, T>((Span<byte>)outputData)[i] = EncodeBlock(blocks[i], quality);
					if (context.Progress != null)
					{
						lock (lockObj)
						{
							context.Progress.Report(++currentBlocks);
						}
					}
				});
			}
			else
			{
				Span<T> span = MemoryMarshal.Cast<byte, T>((Span<byte>)outputData);
				for (int num = 0; num < blocks.Length; num++)
				{
					context.CancellationToken.ThrowIfCancellationRequested();
					span[num] = EncodeBlock(blocks[num], quality);
					context.Progress?.Report(++currentBlocks);
				}
			}
			return outputData;
		}

		public void EncodeBlock(TBlock block, CompressionQuality quality, Span<byte> output)
		{
			if (output.Length != Unsafe.SizeOf<T>())
			{
				throw new Exception("Cannot encode block! Output buffer is not the correct size.");
			}
			T val = EncodeBlock(block, quality);
			MemoryMarshal.Cast<byte, T>(output)[0] = val;
		}

		public abstract GlInternalFormat GetInternalFormat();

		public abstract GlFormat GetBaseInternalFormat();

		public abstract DxgiFormat GetDxgiFormat();

		public int GetBlockSize()
		{
			return Unsafe.SizeOf<T>();
		}

		public abstract T EncodeBlock(TBlock block, CompressionQuality quality);
	}
}
