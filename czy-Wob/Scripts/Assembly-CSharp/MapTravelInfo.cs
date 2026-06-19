using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MapTravelInfo
{
	public static Dictionary<string, string> landmarkNameSceneMapping = new Dictionary<string, string>
	{
		{ "Pens", "03_home" },
		{ "Dog Races", "04_raceRegistration" },
		{ "Adoption Agency", "01_adoptionCenter" },
		{ "Loan Agency", "null" },
		{ "Salon", "null" },
		{ "Clubhouse", "null" }
	};

	public static void ValidateLandmarkName(string landmarkName)
	{
		if (!landmarkNameSceneMapping.ContainsKey(landmarkName))
		{
			Debug.LogError("Invalid landmark name: " + landmarkName);
		}
	}

	public static bool IsLandmarkNameCurrent(string landmarkName)
	{
		string name = SceneManager.GetActiveScene().name;
		foreach (KeyValuePair<string, string> item in landmarkNameSceneMapping)
		{
			if (name == item.Value)
			{
				return landmarkName == item.Key;
			}
		}
		return false;
	}

	public static string GetSceneNameForLandmarkName(string landmarkName)
	{
		return landmarkNameSceneMapping[landmarkName];
	}
}
