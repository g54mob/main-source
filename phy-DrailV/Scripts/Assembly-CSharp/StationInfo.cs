using System;
using UnityEngine;

[Serializable]
public class StationInfo
{
	public string Name;

	public string Type;

	public string YardID;

	public Color StationColor = Color.white;

	public string LocalizationKey;

	public StationInfo(string name, string type, string yardID, Color stationColor, string localizationKey = "")
	{
		Name = name;
		Type = type;
		YardID = yardID;
		StationColor = stationColor;
		LocalizationKey = localizationKey;
	}
}
