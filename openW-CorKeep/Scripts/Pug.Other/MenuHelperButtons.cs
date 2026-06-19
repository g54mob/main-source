using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using UnityEngine;

public class MenuHelperButtons : MonoBehaviour
{
	[Serializable]
	public class HelpButton
	{
		public GameObject root;

		public InputDependentSprite inputDependentSprite;

		public PugText description;
	}

	public enum HelpButtonTypes
	{
		NAVIGATE = 0,
		SELECT = 1,
		BACK = 2,
		REFRESH = 3,
		OPENPROFILE = 4,
		RESET_DEFAULTS = 5,
		CALIBRATE = 6
	}

	public enum SelectButtonVariation
	{
		SELECT = 0,
		ACTIVATE = 1,
		DEACTIVATE = 2
	}

	public HelpButton navigate;

	public HelpButton activate;

	public HelpButton back;

	public HelpButton refresh;

	public HelpButton openProfile;

	public HelpButton resetDefaults;

	public HelpButton calibrate;

	private Dictionary<HelpButtonTypes, HelpButton> helpButtonToGameObject = new Dictionary<HelpButtonTypes, HelpButton>();

	private bool showKeyHints;

	private string previousLanguage;

	private bool systemPrefersKeyboard;

	private List<HelpButtonTypes> currentButtonsToShowing;

	private SelectButtonVariation previousSelectButtonVariation;

	private const float BUTTONS_SPACING = 0.875f;

	public string GetSelectButtonVariationGlossarykey(SelectButtonVariation selectButtonVariation)
	{
		return selectButtonVariation switch
		{
			SelectButtonVariation.ACTIVATE => "menuButtonActivate", 
			SelectButtonVariation.DEACTIVATE => "menuButtonDeactivate", 
			_ => "menuButtonSelect", 
		};
	}

	private void Awake()
	{
		helpButtonToGameObject.Add(HelpButtonTypes.NAVIGATE, navigate);
		helpButtonToGameObject.Add(HelpButtonTypes.SELECT, activate);
		helpButtonToGameObject.Add(HelpButtonTypes.BACK, back);
		helpButtonToGameObject.Add(HelpButtonTypes.REFRESH, refresh);
		helpButtonToGameObject.Add(HelpButtonTypes.OPENPROFILE, openProfile);
		helpButtonToGameObject.Add(HelpButtonTypes.RESET_DEFAULTS, resetDefaults);
		helpButtonToGameObject.Add(HelpButtonTypes.CALIBRATE, calibrate);
	}

	public void UpdateShowingButtons(List<HelpButtonTypes> buttonsToShow, SelectButtonVariation selectButtonVariation)
	{
		if (showKeyHints == Manager.prefs.showKeyHints && previousLanguage == Manager.prefs.language && systemPrefersKeyboard == Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse() && currentButtonsToShowing.SequenceEqual(buttonsToShow) && previousSelectButtonVariation == selectButtonVariation)
		{
			return;
		}
		showKeyHints = Manager.prefs.showKeyHints;
		currentButtonsToShowing = buttonsToShow;
		previousLanguage = Manager.prefs.language;
		systemPrefersKeyboard = Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse();
		if (previousSelectButtonVariation != selectButtonVariation)
		{
			helpButtonToGameObject[HelpButtonTypes.SELECT].description.Render(GetSelectButtonVariationGlossarykey(selectButtonVariation));
			previousSelectButtonVariation = selectButtonVariation;
		}
		foreach (KeyValuePair<HelpButtonTypes, HelpButton> item in helpButtonToGameObject)
		{
			item.Value.root.SetActive(value: false);
		}
		List<HelpButton> list = new List<HelpButton>();
		foreach (HelpButtonTypes item2 in currentButtonsToShowing)
		{
			if (showKeyHints)
			{
				list.Add(helpButtonToGameObject[item2]);
				helpButtonToGameObject[item2].root.SetActive(value: true);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].root.transform.localPosition = new Vector3(13f, 0f, 0f);
			list[i].inputDependentSprite.UpdateButtonAndText();
		}
		StartCoroutine(AlignActiveButtons(list));
	}

	private IEnumerator AlignActiveButtons(List<HelpButton> activeButtons)
	{
		if (activeButtons.Count == 0)
		{
			yield break;
		}
		foreach (HelpButton activeButton in activeButtons)
		{
			activeButton.root.SetActive(value: false);
		}
		yield return Yielders.WaitForEndOfFrame();
		foreach (HelpButton activeButton2 in activeButtons)
		{
			activeButton2.root.SetActive(value: true);
		}
		int waitCount = 0;
		while (waitCount < 5)
		{
			int num = 0;
			foreach (HelpButton activeButton3 in activeButtons)
			{
				if (activeButton3.description.dimensions.width > 0f)
				{
					num++;
				}
			}
			if (num == activeButtons.Count)
			{
				break;
			}
			waitCount++;
			yield return Yielders.WaitForEndOfFrame();
		}
		float num2 = 0f;
		for (int num3 = activeButtons.Count - 1; num3 > 0; num3--)
		{
			HelpButton helpButton = activeButtons[num3];
			float num4 = helpButton.inputDependentSprite.GetSpriteRenderer().size.x / 2f;
			num2 -= num4 + helpButton.description.dimensions.width;
			helpButton.root.transform.localPosition += new Vector3(num2, 0f, 0f).RoundToMultipleXY(0.0625f);
			num2 -= num4 + 0.875f;
		}
		HelpButton helpButton2 = activeButtons[0];
		num2 -= helpButton2.inputDependentSprite.GetSpriteRenderer().size.x / 2f + helpButton2.description.dimensions.width;
		helpButton2.root.transform.localPosition += new Vector3(num2, 0f, 0f).RoundToMultipleXY(0.0625f);
	}
}
