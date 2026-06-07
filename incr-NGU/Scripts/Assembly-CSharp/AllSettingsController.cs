using System.Collections.Generic;
using UnityEngine;

public class AllSettingsController : MonoBehaviour
{
	public Character character;

	public NGUResolutions resolutions;

	public List<GenericToggleSettings> toggles;

	public List<GenericMultiSettings> multiToggles;

	public List<GenericInputSetting> inputSettings;

	public LootFilterType lootFilterSettings;

	public NumberDisplaySettings numberdisplaySettings;

	public GameObject res3GenericPicker;

	public GameObject res3NameGenerator;

	public GameObject permaFoil;

	public GameObject invAutomerge;

	public GameObject invAutoboost;

	public CUIColorPicker res3ColourPicker;

	public void updateMenu()
	{
		foreach (GenericToggleSettings toggle in toggles)
		{
			if (toggle != null)
			{
				toggle.setState();
			}
		}
		foreach (GenericMultiSettings multiToggle in multiToggles)
		{
			if (multiToggle != null)
			{
				multiToggle.setCurState();
			}
		}
		foreach (GenericInputSetting inputSetting in inputSettings)
		{
			if (inputSetting != null)
			{
				inputSetting.updateInputText();
			}
		}
		lootFilterSettings.updateButtons();
		numberdisplaySettings.updateButtons();
		if (!character.res3.res3On)
		{
			res3GenericPicker.SetActive(value: false);
		}
		else
		{
			res3GenericPicker.SetActive(value: true);
		}
		if (character.menuID == 40)
		{
			if (!character.res3.res3On || !character.arbitrary.boughtRes3Pack)
			{
				res3ColourPicker.gameObject.SetActive(value: false);
			}
			else
			{
				res3ColourPicker.gameObject.SetActive(value: true);
				Color color = new Color(character.res3.res3R, character.res3.res3G, character.res3.res3B);
				res3ColourPicker.Color = color;
			}
			if (!character.res3.res3On || !character.arbitrary.res3NameGeneratorBought)
			{
				res3NameGenerator.gameObject.SetActive(value: false);
			}
			else
			{
				res3NameGenerator.gameObject.SetActive(value: true);
			}
			if (character.inventoryController.totalInvMergeSlots() > 0)
			{
				invAutomerge.gameObject.SetActive(value: true);
				invAutoboost.gameObject.SetActive(value: true);
			}
			else
			{
				invAutomerge.gameObject.SetActive(value: false);
				invAutoboost.gameObject.SetActive(value: false);
			}
			if (character.cards.cardsOn && character.arbitrary.boughtFoils)
			{
				permaFoil.gameObject.SetActive(value: true);
			}
			else
			{
				permaFoil.gameObject.SetActive(value: false);
			}
		}
	}
}
