using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using TMPro;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class SpriteAssetRepository : AddressableRepository<SpriteAssetRepository, KeySpriteAssetPair, TMP_SpriteAsset>
	{
		private static HashSet<string> spriteAssetNames;

		public static HashSet<string> SpriteAssetNames
		{
			get
			{
				if (spriteAssetNames == null)
				{
					spriteAssetNames = new HashSet<string>();
					foreach (KeySpriteAssetPair item in MonoRepository<SpriteAssetRepository, KeySpriteAssetPair>.Instance.repository)
					{
						spriteAssetNames.Add(item.GetID());
					}
				}
				return spriteAssetNames;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void OnDomainReload()
		{
			spriteAssetNames = null;
		}

		public override List<string> AddressableLabels()
		{
			return new List<string> { "SpriteAsset" };
		}

		public override void AddNewObject(string key, Object obj, bool overwrite = false)
		{
			if (!(obj == null) && !string.IsNullOrEmpty(key) && !dictionary.ContainsKey(key))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\SpriteAssetRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding SpriteAsset ");
					messageBuilder.AppendFormatted(key);
				}
				Log.Debug(messageBuilder);
				Add(new KeySpriteAssetPair(key, obj as TMP_SpriteAsset));
			}
		}

		protected override void OnStart()
		{
			TMP_Text.OnSpriteAssetRequest += GetSpriteAsset;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			TMP_Text.OnSpriteAssetRequest -= GetSpriteAsset;
		}

		private TMP_SpriteAsset GetSpriteAsset(int hashCode, string key)
		{
			return GetByAddress(key);
		}
	}
}
