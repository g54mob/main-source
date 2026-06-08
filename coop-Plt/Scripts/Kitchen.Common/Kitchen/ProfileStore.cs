using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;

namespace Kitchen
{
	public class ProfileStore
	{
		private Dictionary<ProfileIdentifier, PlayerProfile> Profiles = new Dictionary<ProfileIdentifier, PlayerProfile>();

		private Dictionary<ProfileIdentifier, string> ControlOverrides = new Dictionary<ProfileIdentifier, string>();

		private ProfileSave ProfileSave = new ProfileSave();

		public static ProfileStore Main { get; } = new ProfileStore();

		public event Action<ProfileIdentifier> OnProfileChanged = delegate
		{
		};

		public ProfileStore()
		{
			InputSourceIdentifier.DefaultInputSource.OnBindingChange += OnBindingChange;
		}

		private void OnBindingChange(int player, string action)
		{
			PlayerProfile profile = Players.Main.Get(player).Profile;
			if (profile.IsRealProfile)
			{
				ControlOverrides[profile.Identifier] = InputSourceIdentifier.DefaultInputSource.GetBindingString(player);
				Save();
			}
		}

		public void ApplyBindings(int player_id, ProfileIdentifier name)
		{
			string value;
			if (string.IsNullOrEmpty(name))
			{
				InputSourceIdentifier.DefaultInputSource.ClearBindings(player_id);
			}
			else if (!ControlOverrides.TryGetValue(name, out value))
			{
				InputSourceIdentifier.DefaultInputSource.ClearBindings(player_id);
			}
			else
			{
				InputSourceIdentifier.DefaultInputSource.SetBindingString(player_id, value);
			}
		}

		public bool HasProfile(ProfileIdentifier name)
		{
			return Profiles.ContainsKey(name);
		}

		public bool TryGetProfile(ProfileIdentifier name, out PlayerProfile profile)
		{
			bool num = Profiles.TryGetValue(name, out profile);
			if (num)
			{
				profile.Identifier = name;
			}
			return num;
		}

		public void Delete(ProfileIdentifier name)
		{
			if (Profiles.ContainsKey(name))
			{
				Profiles.Remove(name);
			}
			if (ControlOverrides.ContainsKey(name))
			{
				ControlOverrides.Remove(name);
			}
			Save();
		}

		public void SetProfile(ProfileIdentifier name, PlayerProfile profile)
		{
			if (!Profiles.TryGetValue(name, out var value) || !(profile == value))
			{
				Profiles[name] = profile;
				this.OnProfileChanged(name);
				Save();
			}
		}

		public List<PlayerProfile> AllProfiles()
		{
			return Profiles.Values.ToList();
		}

		public List<ProfileIdentifier> AvailableProfiles()
		{
			IEnumerable<ProfileIdentifier> current_profiles = from p in Players.Main.All()
				where p.IsLocalUser && p.HasProfile
				select p.Profile.Identifier;
			return (from p in Profiles.Values
				where !current_profiles.Contains(p.Identifier)
				select p.Identifier).ToList();
		}

		public void Save()
		{
			Dictionary<ProfileIdentifier, PlayerProfile> dictionary = new Dictionary<ProfileIdentifier, PlayerProfile>();
			foreach (KeyValuePair<ProfileIdentifier, PlayerProfile> profile in Profiles)
			{
				if (profile.Value.IsRealProfile)
				{
					dictionary.Add(profile.Key, profile.Value);
				}
			}
			ProfileSave.Save(dictionary, ControlOverrides);
		}

		public void Load()
		{
			(Profiles, ControlOverrides) = ProfileSave.Load();
		}
	}
}
