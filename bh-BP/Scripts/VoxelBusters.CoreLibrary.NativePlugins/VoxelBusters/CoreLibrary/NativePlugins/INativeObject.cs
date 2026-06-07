using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public interface INativeObject : IDisposable
	{
		NativeObjectRef NativeObjectRef { get; }

		IntPtr AddrOfNativeObject();
	}
}
