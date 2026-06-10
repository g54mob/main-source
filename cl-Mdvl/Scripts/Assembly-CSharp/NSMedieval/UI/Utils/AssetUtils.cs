using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class AssetUtils
	{
		public static Texture2D GetTexture2D(string textureAddress)
		{
			if (!GetTexture(textureAddress, out var texture))
			{
				return null;
			}
			if (texture is Texture2D result)
			{
				return result;
			}
			return null;
		}

		public static Texture GetTexture(string textureAddress)
		{
			if (GetTexture(textureAddress, out var texture))
			{
				return texture;
			}
			return null;
		}

		public static bool GetTexture(string textureAddress, out Texture texture)
		{
			texture = MonoRepository<TextureRepository, KeyTexturePair>.Instance.GetByAddress(textureAddress);
			if (texture != null)
			{
				return true;
			}
			if (!textureAddress.Contains("specular"))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\AssetUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("There is not Texture at address: \"");
					messageBuilder.AppendFormatted(textureAddress);
					messageBuilder.AppendLiteral("\"!");
				}
				Log.Error(messageBuilder);
			}
			return false;
		}

		public static Sprite GetSprite(string address)
		{
			if (GetSpriteFromImage(address, out var newSprite))
			{
				return newSprite;
			}
			Sprite byAddress = MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetByAddress(address);
			if (byAddress != null)
			{
				return byAddress;
			}
			return MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetByAddress("default_fallback");
		}

		public static string GetSpriteAsset(string spriteId, string backgroundId, string color)
		{
			if (!string.IsNullOrEmpty(color))
			{
				string spriteAsset = GetSpriteAsset(spriteId);
				return spriteAsset.Insert(spriteAsset.Length - 1, " color=" + color) + GetSpriteAssetFormat(backgroundId);
			}
			return GetSpriteAsset(spriteId, backgroundId);
		}

		public static string GetSpriteAsset(string spriteId, string backgroundId)
		{
			if (SpriteAssetExists(backgroundId))
			{
				return GetSpriteAsset(spriteId) + GetSpriteAsset(backgroundId);
			}
			return GetSpriteAsset(spriteId);
		}

		public static string GetSpriteAsset(string spriteId)
		{
			if (SpriteAssetExists(spriteId))
			{
				return GetSpriteAssetFormat(spriteId);
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\AssetUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("There is not Sprite Asset at address: \"");
				messageBuilder.AppendFormatted(spriteId);
				messageBuilder.AppendLiteral("\"!");
			}
			Log.Warning(messageBuilder);
			return GetSpriteAssetFormat("protoAsset");
		}

		private static string GetSpriteAssetFormat(string spriteId)
		{
			if (!string.IsNullOrEmpty(spriteId))
			{
				return "<sprite=\"" + spriteId + "\" name=\"" + spriteId + "\">";
			}
			return string.Empty;
		}

		private static bool SpriteAssetExists(string spriteId)
		{
			return SpriteAssetRepository.SpriteAssetNames.Contains(spriteId);
		}

		private static bool GetSpriteFromImage(string imgPath, out Sprite newSprite)
		{
			string path = Application.streamingAssetsPath + "/" + imgPath + ".png";
			if (!File.Exists(path))
			{
				newSprite = null;
				return false;
			}
			byte[] data = File.ReadAllBytes(path);
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			newSprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\AssetUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Sprite leak for ");
				messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(imgPath));
			}
			Log.Warning(messageBuilder);
			return true;
		}
	}
}
