using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class newhampshire_player : Website
{
	public const string URL = "legendsofnewhampshire.com/player/";

	[SerializeField]
	private TextMeshProUGUI playerName1;

	[SerializeField]
	private TextMeshProUGUI playerName2;

	[SerializeField]
	private TextMeshProUGUI class1;

	[SerializeField]
	private TextMeshProUGUI class2;

	[SerializeField]
	private TextMeshProUGUI description;

	[SerializeField]
	private GameObject profileNotFoundObject;

	[SerializeField]
	private GameObject profileFoundObject;

	private static string thisPlayer;

	private static Dictionary<string, Character> playerCharacters;

	private static Dictionary<string, string> playerDescriptions;

	public override bool LoadPage(string url)
	{
		thisPlayer = url.Substring("legendsofnewhampshire.com/player/".Length);
		if (!HasCharacter(thisPlayer))
		{
			ProfileFound(found: false);
			return true;
		}
		ProfileFound(found: true);
		string text = Character.GetClassString(playerCharacters[thisPlayer].type) + " Class";
		playerName1.text = thisPlayer;
		playerName2.text = thisPlayer;
		class1.text = text;
		class2.text = text;
		description.text = playerDescriptions[thisPlayer];
		return true;
	}

	public static bool HasCharacter(string username)
	{
		return playerCharacters.ContainsKey(username);
	}

	public static Character GetCharacter(string username)
	{
		return playerCharacters[username];
	}

	public static void SetPlayers(Dictionary<string, Character> characters, Dictionary<string, string> descriptions)
	{
		Debug.Log("Setting players");
		playerCharacters = characters;
		playerDescriptions = descriptions;
	}

	private void ProfileFound(bool found)
	{
		profileNotFoundObject.SetActive(!found);
		profileFoundObject.SetActive(found);
	}
}
