using System;
using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.PlatformSupport.Memory
{
	[Il2CppEagerStaticClassConstruction]
	public struct PooledBuffer : IDisposable
	{
		public byte[] Data;

		public int Length;

		public void Dispose()
		{
		}
	}
}
