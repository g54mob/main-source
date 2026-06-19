using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMenuController : MonoBehaviour
{
	public CoreButtonUnityGUI englishButton;

	public CoreButtonUnityGUI frenchButton;

	public CoreButtonUnityGUI italianButton;

	public CoreButtonUnityGUI germanButton;

	public CoreButtonUnityGUI spanishButton;

	public CoreButtonUnityGUI koreanButton;

	public CoreButtonUnityGUI chineseSimplifiedButton;

	public CoreButtonUnityGUI chineseTraditionalButton;

	public CoreButtonUnityGUI russianButton;

	public CoreButtonUnityGUI japaneseButton;

	private List<CoreButtonUnityGUI> allButtons = new List<CoreButtonUnityGUI>();

	private ColorBlock defaultColorBlock;

	private ColorBlock selectedColorBlock;

	private GUIManagerPens guiRef;

	private void Awake()
	{
		defaultColorBlock = englishButton.colors;
		selectedColorBlock = default(ColorBlock);
		selectedColorBlock.colorMultiplier = 1f;
		selectedColorBlock.normalColor = defaultColorBlock.selectedColor;
		selectedColorBlock.pressedColor = defaultColorBlock.selectedColor;
		selectedColorBlock.selectedColor = defaultColorBlock.selectedColor;
		selectedColorBlock.disabledColor = defaultColorBlock.selectedColor;
		selectedColorBlock.highlightedColor = defaultColorBlock.selectedColor;
		allButtons.Add(englishButton);
		allButtons.Add(frenchButton);
		allButtons.Add(italianButton);
		allButtons.Add(germanButton);
		allButtons.Add(spanishButton);
		allButtons.Add(koreanButton);
		allButtons.Add(chineseSimplifiedButton);
		allButtons.Add(chineseTraditionalButton);
		allButtons.Add(russianButton);
		allButtons.Add(japaneseButton);
		ResetAllColorBlocks();
		switch (GameSettings.GetStoredGameLanguage())
		{
		case Language.ENGLISH:
			englishButton.colors = selectedColorBlock;
			break;
		case Language.FRENCH:
			frenchButton.colors = selectedColorBlock;
			break;
		case Language.ITALIAN:
			italianButton.colors = selectedColorBlock;
			break;
		case Language.GERMAN:
			germanButton.colors = selectedColorBlock;
			break;
		case Language.SPANISH:
			spanishButton.colors = selectedColorBlock;
			break;
		case Language.KOREAN:
			koreanButton.colors = selectedColorBlock;
			break;
		case Language.CHINESE_SIMP:
			chineseSimplifiedButton.colors = selectedColorBlock;
			break;
		case Language.CHINESE_TRAD:
			chineseTraditionalButton.colors = selectedColorBlock;
			break;
		case Language.RUSSIAN:
			russianButton.colors = selectedColorBlock;
			break;
		case Language.JAPANESE:
			japaneseButton.colors = selectedColorBlock;
			break;
		}
	}

	private void Start()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
	}

	public void SetLanguageEnglish()
	{
		SetLanguage(Language.ENGLISH);
		ResetAllColorBlocks();
		englishButton.colors = selectedColorBlock;
	}

	public void SetLanguageFrench()
	{
		SetLanguage(Language.FRENCH);
		ResetAllColorBlocks();
		frenchButton.colors = selectedColorBlock;
	}

	public void SetLanguageItalian()
	{
		SetLanguage(Language.ITALIAN);
		ResetAllColorBlocks();
		italianButton.colors = selectedColorBlock;
	}

	public void SetLanguageGerman()
	{
		SetLanguage(Language.GERMAN);
		ResetAllColorBlocks();
		germanButton.colors = selectedColorBlock;
	}

	public void SetLanguageSpanish()
	{
		SetLanguage(Language.SPANISH);
		ResetAllColorBlocks();
		spanishButton.colors = selectedColorBlock;
	}

	public void SetLanguageKorean()
	{
		SetLanguage(Language.KOREAN);
		ResetAllColorBlocks();
		koreanButton.colors = selectedColorBlock;
	}

	public void SetLanguageChineseTrad()
	{
		SetLanguage(Language.CHINESE_TRAD);
		ResetAllColorBlocks();
		chineseTraditionalButton.colors = selectedColorBlock;
	}

	public void SetLanguageChineseSimp()
	{
		SetLanguage(Language.CHINESE_SIMP);
		ResetAllColorBlocks();
		chineseSimplifiedButton.colors = selectedColorBlock;
	}

	public void SetLanguageRussian()
	{
		SetLanguage(Language.RUSSIAN);
		ResetAllColorBlocks();
		russianButton.colors = selectedColorBlock;
	}

	public void SetLanguageJapanese()
	{
		SetLanguage(Language.JAPANESE);
		ResetAllColorBlocks();
		japaneseButton.colors = selectedColorBlock;
	}

	private void SetLanguage(Language newLanguage)
	{
		GameSettings.ApplyGameLanguage(newLanguage, save: true);
		if (guiRef != null)
		{
			guiRef.UpdateControlVisuals();
			guiRef.UpdateTutorialTipForNewLanguage();
		}
	}

	private void ResetAllColorBlocks()
	{
		for (int i = 0; i < allButtons.Count; i++)
		{
			allButtons[i].colors = defaultColorBlock;
		}
	}
}
