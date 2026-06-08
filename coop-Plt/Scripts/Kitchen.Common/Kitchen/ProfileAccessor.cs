using KitchenData;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public static class ProfileAccessor
	{
		private static PlayerProfile GetOrCreateProfile(ProfileIdentifier identifier, string name = null)
		{
			if (ProfileStore.Main.TryGetProfile(identifier, out var profile))
			{
				if (name != null)
				{
					profile.Name = name;
				}
				return profile;
			}
			PlayerProfile playerProfile = PlayerProfile.Default;
			playerProfile.Identifier = identifier;
			playerProfile.Name = name ?? ((string)identifier);
			playerProfile.RequiresTutorial = true;
			Set(identifier, playerProfile);
			return playerProfile;
		}

		public static bool IsValidProfileName(string new_profile)
		{
			if (string.IsNullOrEmpty(new_profile))
			{
				return false;
			}
			if (ProfileStore.Main.HasProfile((ProfileIdentifier)new_profile))
			{
				return false;
			}
			return true;
		}

		public static PlayerProfile EnsureProfile(PlatformUser user)
		{
			return GetOrCreateProfile((ProfileIdentifier)Platform.Current.GetIdentifierString(user), Platform.Current.GetDisplayName(user));
		}

		public static bool CreateProfile(string new_profile, PlayerProfile base_profile)
		{
			if (!IsValidProfileName(new_profile))
			{
				return false;
			}
			ProfileIdentifier name = (base_profile.Identifier = (ProfileIdentifier)new_profile);
			base_profile.Name = new_profile;
			ProfileStore.Main.SetProfile(name, base_profile);
			return true;
		}

		public static bool CreateAndActivateProfile(int player_id, string new_profile)
		{
			if (!CreateProfile(new_profile, Players.Main.Get(player_id).Profile))
			{
				return false;
			}
			Players.Main.SetActiveProfile(player_id, (ProfileIdentifier)new_profile);
			return true;
		}

		public static void SetNeedsTutorial(int player_id, bool needs_tutorial)
		{
			if (Players.Main.TryGetActiveProfile(player_id, out var identifier))
			{
				SetNeedsTutorial(identifier, needs_tutorial);
			}
			else
			{
				Debug.LogWarning($"Tried to set needs_tutorial state for non-existent player {player_id}");
			}
		}

		public static void SetNeedsTutorial(ProfileIdentifier identifier, bool needs_tutorial)
		{
			PlayerProfile orCreateProfile = GetOrCreateProfile(identifier);
			orCreateProfile.RequiresTutorial = needs_tutorial;
			Set(identifier, orCreateProfile);
		}

		public static void SetCosmetic(int player_id, PlayerCosmetic cosmetic)
		{
			if (Players.Main.TryGetActiveProfile(player_id, out var identifier))
			{
				SetCosmetic(identifier, cosmetic);
			}
			else
			{
				Debug.LogWarning($"Tried to set cosmetic state for non-existent player {player_id}");
			}
		}

		public static void SetCosmetic(ProfileIdentifier identifier, PlayerCosmetic cosmetic)
		{
			PlayerProfile orCreateProfile = GetOrCreateProfile(identifier);
			orCreateProfile.Cosmetics = CPlayerCosmetics.Set(orCreateProfile.Cosmetics, cosmetic.CosmeticType, cosmetic.ID);
			Set(identifier, orCreateProfile);
		}

		public static void SetColour(int player_id, Color colour)
		{
			if (Players.Main.TryGetActiveProfile(player_id, out var identifier))
			{
				SetColour(identifier, colour);
			}
			else
			{
				Debug.LogWarning($"Tried to set colour state for non-existent player {player_id}");
			}
		}

		public static void SetColour(ProfileIdentifier identifier, Color colour)
		{
			PlayerProfile orCreateProfile = GetOrCreateProfile(identifier);
			orCreateProfile.Colour = colour;
			Set(identifier, orCreateProfile);
		}

		private static void Set(ProfileIdentifier identifier, PlayerProfile profile)
		{
			ProfileStore.Main.SetProfile(identifier, profile);
		}
	}
}
