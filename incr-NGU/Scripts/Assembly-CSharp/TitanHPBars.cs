using UnityEngine;
using UnityEngine.UI;

public class TitanHPBars : MonoBehaviour
{
	public Character character;

	public Button plainBar;

	public Button fancyBar;

	private void Start()
	{
		updateToggleStatus();
	}

	public void turnOnFancy()
	{
		character.settings.specialAdvHpBars = true;
		updateToggleStatus();
	}

	public void turnOnPlain()
	{
		character.settings.specialAdvHpBars = false;
		updateToggleStatus();
	}

	private void updateToggleStatus()
	{
		if (character.settings.specialAdvHpBars)
		{
			fancyBar.interactable = false;
			plainBar.interactable = true;
		}
		else
		{
			fancyBar.interactable = true;
			plainBar.interactable = false;
		}
	}
}
