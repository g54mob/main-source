using System;
using DV.Common;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement
{
	public static class UserProfileExtensions
	{
		private static string SALT_SUFFIX = "_salty";

		public static JObject ReadProgressionState(this IUserProfile user)
		{
			if (user.GameData["Progression_state"] != null)
			{
				try
				{
					JObject jObject = JObject.Parse(DataProtection.DecryptString(user.GameData["Progression_state"].Value<string>(), user.Signature + SALT_SUFFIX));
					if (jObject["Unlocked_general_licenses"].Type != JTokenType.Array)
					{
						jObject["Unlocked_general_licenses"] = new JArray();
					}
					if (jObject["Unlocked_job_licenses"].Type != JTokenType.Array)
					{
						jObject["Unlocked_job_licenses"] = new JArray();
					}
					if (jObject["Unlocked_garages"].Type != JTokenType.Array)
					{
						jObject["Unlocked_garages"] = new JArray();
					}
					if (jObject["Unlocked_items"].Type != JTokenType.Array)
					{
						jObject["Unlocked_items"] = new JArray();
					}
					return jObject;
				}
				catch (Exception ex)
				{
					Debug.LogError("Couldn't decrypt/parse progression data from user " + user.Name + ": " + ex.Message);
					Debug.LogException(ex);
				}
			}
			return new JObject
			{
				{
					"Unlocked_general_licenses",
					new JArray()
				},
				{
					"Unlocked_job_licenses",
					new JArray()
				},
				{
					"Unlocked_garages",
					new JArray()
				},
				{
					"Unlocked_items",
					new JArray()
				}
			};
		}

		public static void SaveProgressionState(this IUserProfile user, JObject progressionData)
		{
			user.GameData["Progression_state"] = DataProtection.EncryptString(progressionData.ToString(), user.Signature + SALT_SUFFIX);
			user.Save(UserSavingMode.JustUser);
		}
	}
}
