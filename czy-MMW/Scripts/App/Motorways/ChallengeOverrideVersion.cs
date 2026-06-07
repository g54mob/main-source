using System.Collections.Generic;

namespace Motorways
{
	public class ChallengeOverrideVersion
	{
		public int Timestamp;

		public string Serialize()
		{
			return Json.Serialize(new Dictionary<string, object> { { "Timestamp", Timestamp } });
		}

		public bool Deserialize(string json)
		{
			JSON.Dictionary dictionary = JSON.ToDictionary(JSON.LoadFromString(json));
			if (dictionary == null)
			{
				ChallengeOverrides.Log.Error("Failed to parse JSON string to Dictionary.\n" + json);
				return false;
			}
			Timestamp = dictionary.GetInt("Timestamp", -1);
			if (Timestamp == -1)
			{
				ChallengeOverrides.Log.Error($"Failed to Deserialize Timestamp.\nTimestamp: {Timestamp}\n\nSource:\n{json}");
				return false;
			}
			return true;
		}
	}
}
