using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.DeepLinkServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class DeepLinkServices
	{
		[ClearOnReload]
		private static INativeDeepLinkServicesInterface s_nativeInterface;

		public static DeepLinkServicesUnitySettings UnitySettings { get; private set; }

		public static IDeepLinkServicesDelegate Delegate { get; set; }

		public static event Callback<DeepLinkServicesDynamicLinkOpenResult> OnCustomSchemeUrlOpen
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Callback<DeepLinkServicesDynamicLinkOpenResult> OnUniversalLinkOpen
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(DeepLinkServicesUnitySettings settings)
		{
		}

		private static bool CanHandleCustomSchemeUrl(string url)
		{
			return false;
		}

		private static bool CanHandleUniversalLink(string url)
		{
			return false;
		}

		private static void HandleOnCustomSchemeUrlOpen(string url)
		{
		}

		private static void HandleOnUniversalLinkOpen(string url)
		{
		}
	}
}
