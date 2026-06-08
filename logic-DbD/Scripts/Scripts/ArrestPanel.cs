using System;
using UnityEngine;
using UnityEngine.UI;

public class ArrestPanel : PopupPanel
{
	private static readonly string SUSPECT_PHOTO_DIRECTORY = "UI/Arrest/Prisoners/Named";

	private static readonly string SUSPECT_PHOTO = "Suspect";

	[SerializeField]
	private Image suspectPhoto;

	[SerializeField]
	private GameObject namedSuspect;

	[SerializeField]
	private GameObject randomSuspect;

	public void SetSuspectPhoto(bool isCorrectArrest, string arrestName)
	{
		int currLevel = LevelManager.GetCurrLevel();
		Sprite sprite = null;
		if (isCorrectArrest)
		{
			sprite = LoadSuspectPhoto(currLevel, SUSPECT_PHOTO);
		}
		else if (currLevel == 0)
		{
			sprite = (ContainsName(arrestName, "Jay") ? LoadSuspectPhoto(currLevel, "Jay") : ((!ContainsName(arrestName, "Laura")) ? LoadSuspectPhoto(currLevel, "Banker") : LoadSuspectPhoto(currLevel, "Retired")));
		}
		else
		{
			Appearance appearance = null;
			if (currLevel == 1)
			{
				appearance = Level1.GetAppearance(arrestName.ToUpperInvariant());
			}
			SetRandomSuspect(arrestName, appearance);
		}
		suspectPhoto.sprite = sprite;
	}

	public Sprite LoadSuspectPhoto(int level, string fileName)
	{
		namedSuspect.SetActive(value: true);
		randomSuspect.SetActive(value: false);
		return ResourcesManager.GetImage($"{SUSPECT_PHOTO_DIRECTORY}/{level} {fileName}");
	}

	public void SetRandomSuspect(string arrestName, Appearance appearance = null)
	{
		namedSuspect.SetActive(value: false);
		randomSuspect.SetActive(value: true);
		string firstName = arrestName.Split(" ")[0];
		randomSuspect.GetComponent<SuspectAppearance>().SetAppearance(firstName, appearance);
	}

	public bool ContainsName(string arrestName, string name)
	{
		return arrestName.Contains(name, StringComparison.OrdinalIgnoreCase);
	}
}
