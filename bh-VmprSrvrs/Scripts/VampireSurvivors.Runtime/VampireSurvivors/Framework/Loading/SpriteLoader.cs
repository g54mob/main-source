using System;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading
{
	public static class SpriteLoader
	{
		public static bool LoadTexture(string textureName, string cacheGroupName, DlcType? dlcType, Action<bool> onComplete = null)
		{
			return false;
		}

		public static void LoadTextureAsync(string textureName, string cacheGroupName, DlcType? dlcType, Action<bool> onComplete = null)
		{
		}

		private static void Log(string message)
		{
		}

		private static void LoadTextureInternal(string textureName, string cacheGroupName, DlcType? dlcType, Action<bool> onComplete = null, bool forceSync = false)
		{
		}

		private static void LoadSpritesFromTexture(IResourceLocation textureLocation, string cacheGroupName, string textureName, DlcType? dlcType, Action<bool> onComplete = null, bool forceSync = false)
		{
		}
	}
}
