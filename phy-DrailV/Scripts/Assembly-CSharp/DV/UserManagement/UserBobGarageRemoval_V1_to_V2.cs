using System.Linq;
using DV.JObjectExtstensions;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement
{
	[CreateAssetMenu(menuName = "DV/Data upgrade/User/Bob's Garage removal(v1 -> v2)")]
	public class UserBobGarageRemoval_V1_to_V2 : AJSONDataUpgrader
	{
		public override int InputVersion => 1;

		public override JObject Upgrade(UserManager manager, string path, IStorageProvider storage, JObject userGameData)
		{
			string text = userGameData.GetString("Progression_state");
			if (string.IsNullOrEmpty(text))
			{
				return userGameData;
			}
			if (!(userGameData?.Parent?.Parent is JObject dataObject))
			{
				Debug.LogError("Unexpected state: userData not found!");
				return userGameData;
			}
			string text2 = dataObject.GetString("Signature");
			if (string.IsNullOrEmpty(text2))
			{
				Debug.LogError("Unexpected state: userSignature not found!");
				return userGameData;
			}
			string passPhrase = text2 + "_salty";
			JObject jObject = JObject.Parse(DataProtection.DecryptString(text, passPhrase));
			if (jObject["Unlocked_garages"].Type != JTokenType.Array)
			{
				jObject["Unlocked_garages"] = new JArray();
			}
			string[] source = jObject["Unlocked_garages"].ToObject<string[]>();
			source = source.Where((string garageId) => garageId != "Bob").ToArray();
			object[] content = source;
			jObject["Unlocked_garages"] = new JArray(content);
			userGameData.SetString("Progression_state", DataProtection.EncryptString(jObject.ToString(), passPhrase));
			return userGameData;
		}
	}
}
