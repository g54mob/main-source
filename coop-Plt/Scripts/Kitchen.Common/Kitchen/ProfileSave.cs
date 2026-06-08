using System;
using System.Collections.Generic;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public class ProfileSave
	{
		[Key(0)]
		public Dictionary<string, PlayerProfile> Profiles = new Dictionary<string, PlayerProfile>();

		[Key(1)]
		public Dictionary<string, string> ControlOverrides = new Dictionary<string, string>();

		public (Dictionary<ProfileIdentifier, PlayerProfile> profiles, Dictionary<ProfileIdentifier, string> control_overrides) Load()
		{
			if (Persistence.Profile.Load<ProfileSave>(out var ret) && ret != null)
			{
				Profiles = ret.Profiles;
				ControlOverrides = ret.ControlOverrides;
			}
			if (Profiles == null)
			{
				Profiles = new Dictionary<string, PlayerProfile>();
			}
			if (ControlOverrides == null)
			{
				ControlOverrides = new Dictionary<string, string>();
			}
			Dictionary<ProfileIdentifier, PlayerProfile> dictionary = new Dictionary<ProfileIdentifier, PlayerProfile>();
			Dictionary<ProfileIdentifier, string> dictionary2 = new Dictionary<ProfileIdentifier, string>();
			foreach (KeyValuePair<string, PlayerProfile> profile in Profiles)
			{
				PlayerProfile value = profile.Value;
				value.Identifier = (ProfileIdentifier)profile.Key;
				dictionary.Add(value.Identifier, value);
			}
			foreach (KeyValuePair<string, string> controlOverride in ControlOverrides)
			{
				dictionary2.Add((ProfileIdentifier)controlOverride.Key, controlOverride.Value);
			}
			return (profiles: dictionary, control_overrides: dictionary2);
		}

		public void Save(Dictionary<ProfileIdentifier, PlayerProfile> profiles, Dictionary<ProfileIdentifier, string> control_overrides)
		{
			ControlOverrides.Clear();
			Profiles.Clear();
			foreach (KeyValuePair<ProfileIdentifier, PlayerProfile> profile in profiles)
			{
				Profiles.Add(profile.Key, profile.Value);
			}
			foreach (KeyValuePair<ProfileIdentifier, string> control_override in control_overrides)
			{
				ControlOverrides.Add(control_override.Key, control_override.Value);
			}
			Persistence.Profile.Save(this);
		}
	}
}
