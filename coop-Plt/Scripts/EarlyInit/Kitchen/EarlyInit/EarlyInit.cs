using KitchenMods;
using Platforms;
using Platforms.Steam;
using UnityEngine;

namespace Kitchen.EarlyInit
{
	public class EarlyInit
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void Init()
		{
			SteamPlatform.SetAsActivePlatform();
			if (!PlatformSettings.IsDemoMode)
			{
				ModPreload.LoadMods();
			}
		}
	}
}
