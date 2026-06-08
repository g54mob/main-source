using System;
using System.Buffers;
using System.Collections.Generic;
using Nerdbank.Streams;

namespace MessagePack
{
	internal class SequencePool
	{
		internal struct Rental : IDisposable
		{
			private readonly SequencePool owner;

			public Sequence<byte> Value { get; }

			internal Rental(SequencePool owner, Sequence<byte> value)
			{
				this.owner = owner;
				Value = value;
			}

			public void Dispose()
			{
				owner?.Return(Value);
			}
		}

		internal static readonly SequencePool Shared = new SequencePool(Environment.ProcessorCount * 2);

		private const int MinimumSpanLength = 32768;

		private readonly int maxSize;

		private readonly Stack<Sequence<byte>> pool = new Stack<Sequence<byte>>();

		private readonly ArrayPool<byte> arrayPool = ArrayPool<byte>.Create(81920, 100);

		internal SequencePool(int maxSize)
		{
			this.maxSize = maxSize;
		}

		internal Rental Rent()
		{
			lock (pool)
			{
				if (pool.Count > 0)
				{
					return new Rental(this, pool.Pop());
				}
			}
			return new Rental(this, new Sequence<byte>(arrayPool)
			{
				MinimumSpanLength = 32768
			});
		}

		private void Return(Sequence<byte> value)
		{
			value.Reset();
			lock (pool)
			{
				if (pool.Count < maxSize)
				{
					value.MinimumSpanLength = 32768;
					pool.Push(value);
				}
			}
		}
	}
}
