using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class SpriteRepository : AddressableRepository<SpriteRepository, KeySpritePair, Sprite>
	{
		protected override List<string> GetLabelsToCache()
		{
			return new List<string> { "HeraldryBasicPatterns", "HeraldryBasicShapes", "HeraldryBasicSymbols" };
		}

		public override List<string> AddressableLabels()
		{
			return new List<string> { "Sprite" };
		}

		public override void AddNewObject(string key, Object obj, bool overwrite = false)
		{
			if (string.IsNullOrEmpty(key) || dictionary.ContainsKey(key))
			{
				return;
			}
			if (obj is Sprite sprite)
			{
				AddSprite(key, sprite);
				return;
			}
			if (obj is Texture2D texture2D)
			{
				Sprite sprite2 = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.one * 0.5f);
				AddSprite(key, sprite2);
				return;
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\SpriteRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(key);
				messageBuilder.AppendLiteral(" is not a sprite!");
			}
			Log.Warning(messageBuilder);
		}

		private void AddSprite(string key, Sprite sprite)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\SpriteRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Adding Sprite: ");
				messageBuilder.AppendFormatted(key);
				messageBuilder.AppendLiteral("!");
			}
			Log.Debug(messageBuilder);
			Add(new KeySpritePair(key, sprite));
		}
	}
}
