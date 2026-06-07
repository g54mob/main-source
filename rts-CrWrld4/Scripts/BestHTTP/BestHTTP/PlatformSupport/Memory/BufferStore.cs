using System.Collections.Generic;
using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.PlatformSupport.Memory
{
	[Il2CppEagerStaticClassConstruction]
	internal struct BufferStore
	{
		public readonly long Size;

		public List<BufferDesc> buffers;

		public BufferStore(long size)
		{
			Size = 0L;
			buffers = null;
		}

		public BufferStore(long size, byte[] buffer)
		{
			Size = 0L;
			buffers = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
