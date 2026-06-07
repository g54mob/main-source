using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public static class NativeFeatureActivator
	{
		public static INativeFeatureInterfaceProvider InterfaceProvider { get; set; }

		public static TFeatureInterface CreateInterface<TFeatureInterface>(NativeFeatureRuntimeConfiguration runtimeConfiguration, bool isAvailable, params object[] args) where TFeatureInterface : INativeFeatureInterface
		{
			return default(TFeatureInterface);
		}

		public static TFeatureInterface CreateNativeInterfaceComponent<TFeatureInterface>(this GameObject gameObject, NativeFeatureRuntimeConfiguration runtimeConfiguration, bool isEnabled) where TFeatureInterface : INativeFeatureInterface
		{
			return default(TFeatureInterface);
		}

		private static object CreateInstance(string assemblyName, string typeName, object[] arguments)
		{
			return null;
		}
	}
}
