using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal abstract class BaseBcBlockDecoder<T, TBlock> : IBcBlockDecoder<TBlock> where T : unmanaged where TBlock : unmanaged
	{
		private static readonly object lockObj = new object();

		public TBlock[] Decode(ReadOnlyMemory<byte> data, OperationContext context)
		{
			if (data.Length % Unsafe.SizeOf<T>() != 0)
			{
				throw new InvalidDataException("Given data does not align with the block length.");
			}
			int num = data.Length / Unsafe.SizeOf<T>();
			TBlock[] output = new TBlock[num];
			int currentBlocks = 0;
			if (context.IsParallel)
			{
				ParallelOptions parallelOptions = new ParallelOptions
				{
					CancellationToken = context.CancellationToken,
					MaxDegreeOfParallelism = context.TaskCount
				};
				Parallel.For(0, num, parallelOptions, delegate(int i)
				{
					ReadOnlySpan<T> readOnlySpan2 = MemoryMarshal.Cast<byte, T>(data.Span);
					output[i] = DecodeBlock(readOnlySpan2[i]);
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
				ReadOnlySpan<T> readOnlySpan = MemoryMarshal.Cast<byte, T>(data.Span);
				for (int num2 = 0; num2 < num; num2++)
				{
					context.CancellationToken.ThrowIfCancellationRequested();
					output[num2] = DecodeBlock(readOnlySpan[num2]);
					context.Progress?.Report(++currentBlocks);
				}
			}
			return output;
		}

		public TBlock DecodeBlock(ReadOnlySpan<byte> data)
		{
			T block = MemoryMarshal.Cast<byte, T>(data)[0];
			return DecodeBlock(block);
		}

		protected abstract TBlock DecodeBlock(T block);
	}
}
