using System;
using System.Collections.Generic;

namespace MemoryPack
{
	public sealed class MemoryPackWriterOptionalState : IDisposable
	{
		private sealed class ReferenceEqualityComparer : IEqualityComparer<object>
		{
			public static ReferenceEqualityComparer Instance { get; }

			private ReferenceEqualityComparer()
			{
			}

			public new bool Equals(object? x, object? y)
			{
				return false;
			}

			public int GetHashCode(object obj)
			{
				return 0;
			}
		}

		internal static readonly MemoryPackWriterOptionalState NullState;

		private uint nextId;

		private readonly Dictionary<object, uint> objectToRef;

		public MemoryPackSerializerOptions Options { get; private set; }

		internal MemoryPackWriterOptionalState()
		{
		}

		private MemoryPackWriterOptionalState(bool _)
		{
		}

		internal void Init(MemoryPackSerializerOptions? options)
		{
		}

		public void Reset()
		{
		}

		public (bool, uint) GetOrAddReference(object value)
		{
			return default((bool, uint));
		}

		void IDisposable.Dispose()
		{
		}
	}
}
