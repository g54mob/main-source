using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public interface INativeFeatureInterfaceProvider
	{
		INativeFeatureInterface CreateInterface(Type interfaceType, RuntimePlatform platform);
	}
}
