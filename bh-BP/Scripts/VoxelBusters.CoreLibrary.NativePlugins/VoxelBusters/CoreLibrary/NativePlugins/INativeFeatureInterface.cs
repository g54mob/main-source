using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public interface INativeFeatureInterface : INativeObject, IDisposable
	{
		bool IsAvailable { get; }
	}
}
