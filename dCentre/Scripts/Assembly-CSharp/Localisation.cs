using System.Collections.Generic;
using UnityEngine;

public class Localisation : MonoBehaviour
{
	public delegate void OnLanguageChange();

	public enum Languages
	{
		English = 1,
		Czech = 2,
		French = 3,
		Italian = 4,
		German = 5,
		Spanish_Spain = 6,
		Arabic = 7,
		Dutch = 8,
		Japanese = 9,
		Korean = 10,
		Portuguese_Brazil = 11,
		Portuguese_Portugal = 12,
		Russian = 13,
		Simplified_Chinese = 14,
		Spanish_LatinAmerica = 15,
		Turkish = 16,
		Polish = 17,
		Thai = 18,
		Traditional_Chinese = 19
	}

	public static Localisation instance;

	public List<LanguageObject> languages;

	public Dictionary<int, string> dictionary;

	public int loadLanguageUID;

	public Languages currentlySelectedLanguage;

	public OnLanguageChange onLanguageChangedCallback;

	private void Awake()
	{
	}

	public Dictionary<int, string> LoadLocalisation(int _uid)
	{
		return null;
	}

	public void ChangeLocalisation(int _uid)
	{
	}

	public string ReturnTextByID(int _uid)
	{
		return null;
	}
}
