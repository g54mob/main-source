using System;
using System.Collections.Generic;

namespace Amazon.Runtime.CredentialManagement.Internal
{
	public static class CredentialProfileUtils
	{
		public static Dictionary<string, string> GetProperties(CredentialProfile profile)
		{
			return profile.Properties;
		}

		public static void SetProperty(CredentialProfile profile, string key, string value)
		{
			profile.Properties[key] = value;
		}

		public static string GetProperty(CredentialProfile profile, string key)
		{
			profile.Properties.TryGetValue(key, out var value);
			return value;
		}

		public static Guid EnsureUniqueKeyAssigned(CredentialProfile profile, ICredentialProfileStore profileStore)
		{
			if (!profile.UniqueKey.HasValue)
			{
				profile.UniqueKey = Guid.NewGuid();
				profileStore.RegisterProfile(profile);
			}
			return profile.UniqueKey.Value;
		}

		public static string GetUniqueKey(CredentialProfile profile)
		{
			if (!profile.UniqueKey.HasValue)
			{
				return null;
			}
			return profile.UniqueKey.Value.ToString("D");
		}

		public static void SetUniqueKey(CredentialProfile profile, Guid? uniqueKey)
		{
			profile.UniqueKey = uniqueKey;
		}

		public static CredentialProfileType? GetProfileType(CredentialProfile profile)
		{
			return profile.ProfileType;
		}

		public static bool IsCallbackRequired(CredentialProfile profile)
		{
			return profile.IsCallbackRequired;
		}
	}
}
