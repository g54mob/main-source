using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public class NativeFeatureRuntimeConfiguration
	{
		public NativeFeatureRuntimePackage[] Packages { get; private set; }

		public NativeFeatureRuntimePackage SimulatorPackage { get; private set; }

		public NativeFeatureRuntimePackage FallbackPackage { get; private set; }

		public NativeFeatureRuntimeConfiguration(NativeFeatureRuntimePackage[] packages, NativeFeatureRuntimePackage simulatorPackage = null, NativeFeatureRuntimePackage fallbackPackage = null)
		{
		}

		public NativeFeatureRuntimePackage GetPackageForPlatform(RuntimePlatform platform)
		{
			return null;
		}
	}
}
