using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;

namespace Jundroo.ModTools.Core
{
	public class LoadedMod : ILoadedMod
	{
		private Dictionary<Type, object> _services;

		public AssetBundle AssetBundle { get; private set; }

		public List<GameModBase> GameMods { get; private set; }

		IReadOnlyList<GameModBase> ILoadedMod.GameMods => GameMods;

		public ModInfo ModInfo { get; private set; }

		public IModResourceLoader ResourceLoader { get; private set; }

		public SteamPublishInfo SteamWorkshopPublishInfo { get; private set; }

		public LoadedMod(ModInfo mod, AssetBundle assetBundle, ModManifest modManifest)
		{
			ModInfo = mod;
			AssetBundle = assetBundle;
			GameMods = new List<GameModBase>(1);
			_services = new Dictionary<Type, object>();
			ResourceLoader = new ModResourceLoader(mod, modManifest, assetBundle);
			if (modManifest.HasSteamInfo)
			{
				FileInfo fileInfo = new FileInfo(mod.Path + ".SteamWorkshop");
				bool num = fileInfo.Exists && File.ReadAllText(fileInfo.FullName) == mod.BuildInfo.BuildId.ToString();
				FileInfo fileInfo2 = new FileInfo(mod.Path + ".PreviewImage");
				if (num & (fileInfo2.Exists && fileInfo2.Length < 1048576))
				{
					SteamWorkshopPublishInfo = new SteamPublishInfo
					{
						Title = modManifest.SteamTitle,
						Visibility = modManifest.SteamVisibility,
						PreviewPath = fileInfo2.FullName,
						Language = modManifest.SteamLanguage,
						Tags = new ReadOnlyCollection<string>(modManifest.SteamTags),
						Description = modManifest.SteamDescription
					};
				}
			}
		}
	}
}
