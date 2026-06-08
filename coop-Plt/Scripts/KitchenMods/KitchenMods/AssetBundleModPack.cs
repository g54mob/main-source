using System;
using System.Collections.Generic;
using System.IO;
using KitchenData;
using UnityEngine;

namespace KitchenMods
{
	public class AssetBundleModPack : ModPack
	{
		public List<AssetBundle> AssetBundles = new List<AssetBundle>();

		public AssetBundleModPack(string name, byte[] data)
			: base(name, data)
		{
		}

		public static bool TryLoadFile(string path, out AssetBundleModPack pack)
		{
			pack = null;
			if (!Path.GetExtension(path).Equals(".assets"))
			{
				return false;
			}
			pack = new AssetBundleModPack(Path.GetFileName(path), File.ReadAllBytes(path));
			return true;
		}

		public override void Activate()
		{
			try
			{
				AssetBundle assetBundle = AssetBundle.LoadFromMemory(Data);
				if (assetBundle != null)
				{
					AssetBundles.Add(assetBundle);
				}
			}
			catch (Exception arg)
			{
				throw new ModPackLoadException($"Failed to load content pack of {arg}:{Name}");
			}
		}

		public override void Inject(ModInjectionContext injection_context)
		{
			foreach (AssetBundle assetBundle in AssetBundles)
			{
				GameDataObject[] array = assetBundle.LoadAllAssets<GameDataObject>();
				foreach (GameDataObject gameDataObject in array)
				{
					injection_context.Constructor.All.Add(gameDataObject.ID, gameDataObject);
					injection_context.Constructor.GameDataObjects.Add(gameDataObject);
				}
			}
		}
	}
}
