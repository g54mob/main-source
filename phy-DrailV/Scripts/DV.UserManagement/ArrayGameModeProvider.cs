using System;
using DV.UserManagement.Integration;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Game Mode Provider")]
public class ArrayGameModeProvider : AGameModeProvider
{
	public string[] gameModes;

	public string[] localizationKeys;

	public override string[] GetGameModes()
	{
		return gameModes;
	}

	public override string GetLocalizationKey(string gameMode)
	{
		int num = Array.IndexOf(gameModes, gameMode);
		if (num >= 0)
		{
			return localizationKeys[num];
		}
		return "";
	}
}
