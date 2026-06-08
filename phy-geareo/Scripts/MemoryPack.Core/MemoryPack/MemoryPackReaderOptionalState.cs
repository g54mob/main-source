using System;
using System.Collections.Generic;

namespace MemoryPack
{
	public sealed class MemoryPackReaderOptionalState : IDisposable
	{
		private readonly Dictionary<uint, object> refToObject;

		public MemoryPackSerializerOptions Options { get; private set; }

		internal MemoryPackReaderOptionalState()
		{
		}

		internal void Init(MemoryPackSerializerOptions? options)
		{
		}

		public object GetObjectReference(uint id)
		{
			return null;
		}

		public void AddObjectReference(uint id, object value)
		{
		}

		public void Reset()
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
