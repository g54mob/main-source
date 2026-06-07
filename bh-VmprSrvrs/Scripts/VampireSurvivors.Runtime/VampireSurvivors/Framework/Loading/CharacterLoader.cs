using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Loading
{
	public static class CharacterLoader
	{
		private const string CharacterCacheGroup = "CharacterTextures";

		public static Dictionary<CharacterType, List<string>> GetTexturesAndTypesForSelectedPlayers(PlayerOptions playerOptions, DataManager dataManager)
		{
			return null;
		}

		public static List<string> GetTexturesForCharacterTypes(List<CharacterType> characters, PlayerOptions playerOptions, DataManager dataManager)
		{
			return null;
		}

		public static List<string> GetTexturesForCharacterType(CharacterType characterType, PlayerOptions playerOptions, DataManager dataManager)
		{
			return null;
		}

		public static void ClearCharacterTextures(List<string> excludedTextures = null)
		{
		}

		public static void LoadCharacterAsync(CharacterType characterType, Action onComplete)
		{
		}

		public static void LoadAllCharacterTextures(DataManager dataManager)
		{
		}

		public static void LoadAllCharacterTexturesAsync(DataManager dataManager, Action onComplete)
		{
		}

		public static void LoadCharacterTexture(string textureName, CharacterType characterType, DataManager dataManager, string customCacheGroup = null)
		{
		}

		public static void LoadCharacterTextureAsync(string textureName, CharacterType characterType, Action<bool> onComplete, DataManager dataManager, string customCacheGroup = null)
		{
		}
	}
}
