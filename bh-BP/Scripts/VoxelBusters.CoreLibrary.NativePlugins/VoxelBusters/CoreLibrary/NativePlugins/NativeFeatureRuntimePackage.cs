using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	public class NativeFeatureRuntimePackage
	{
		private readonly RuntimePlatform[] m_platforms;

		private readonly string m_custom;

		public string Assembly { get; private set; }

		public string Namespace { get; private set; }

		public string NativeInterfaceType { get; private set; }

		public string[] BindingTypes { get; private set; }

		private NativeFeatureRuntimePackage(string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null, string custom = null, params RuntimePlatform[] platforms)
		{
		}

		public static NativeFeatureRuntimePackage Generic(string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null)
		{
			return null;
		}

		public static NativeFeatureRuntimePackage Android(string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null)
		{
			return null;
		}

		public static NativeFeatureRuntimePackage IPhonePlayer(string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null)
		{
			return null;
		}

		public static NativeFeatureRuntimePackage TvOS(string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null)
		{
			return null;
		}

		public static NativeFeatureRuntimePackage iOS(string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null)
		{
			return null;
		}

		public static NativeFeatureRuntimePackage Custom(string custom, string assembly, string ns, string nativeInterfaceType, string[] bindingTypes = null)
		{
			return null;
		}

		private static string GetTypeFullName(string ns, string type)
		{
			return null;
		}

		public Type[] GetBindingTypeReferences()
		{
			return null;
		}

		public bool IsMatch(RuntimePlatform platform, string custom)
		{
			return false;
		}

		public bool SupportsPlatform(RuntimePlatform platform)
		{
			return false;
		}
	}
}
