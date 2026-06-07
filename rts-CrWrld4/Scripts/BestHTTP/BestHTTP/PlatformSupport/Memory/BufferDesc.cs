using System;
using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.PlatformSupport.Memory
{
	[Il2CppEagerStaticClassConstruction]
	internal struct BufferDesc
	{
		public static readonly BufferDesc Empty;

		public byte[] buffer;

		public DateTime released;

		public BufferDesc(byte[] buff)
		{
			buffer = null;
			released = default(DateTime);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
