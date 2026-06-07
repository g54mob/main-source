using System;
using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading
{
	public static class AudioLoader
	{
		public static Dictionary<string, List<string>> LoadedSFX;

		public static void LoadBgmAsync(BgmType bgmType, string cacheGroupName, DlcType? dlcType, Action onComplete)
		{
		}

		public static void LoadBgm(BgmType bgmType, string cacheGroupName, DlcType? dlcType, Action onComplete = null)
		{
		}

		public static void LoadSFX(SfxType sfxType, string cacheGroupName, DlcType? dlcType, Action onComplete = null)
		{
		}

		public static void LoadSFXAsync(SfxType sfxType, string cacheGroupName, DlcType? dlcType, Action onComplete = null)
		{
		}

		private static void CacheLoadedSFX(string cacheGroupName, string sfxGroupName)
		{
		}

		public static bool IsSFXLoaded(SfxType sfx)
		{
			return false;
		}

		public static void ReleaseCachedGroup(string cacheGroup)
		{
		}

		public static void ReleaseCachedKey(string keyName)
		{
		}
	}
}
