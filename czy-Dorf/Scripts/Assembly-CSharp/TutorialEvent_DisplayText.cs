using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using TMPro;
using UnityEngine;

public class TutorialEvent_DisplayText : TutorialEvent
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<InputDeviceLocalizationKey, bool> _003C_003E9__13_0;

		public static Func<InputDeviceLocalizationKey, bool> _003C_003E9__13_1;

		internal bool _003CUpdateText_003Eb__13_0(InputDeviceLocalizationKey x)
		{
			return x.inputDevice == Singleton<InputManager>.Instance.CurrentInputDevice;
		}

		internal bool _003CUpdateText_003Eb__13_1(InputDeviceLocalizationKey x)
		{
			return x.inputDevice == Singleton<InputManager>.Instance.CurrentInputDevice;
		}
	}

	[SerializeField]
	private string localizationKey;

	[SerializeField]
	private List<InputDeviceLocalizationKey> localizationKeyVariants;

	private TextMeshProUGUI displayedText;

	[SerializeField]
	private float fadeDuration = 0.3f;

	[SerializeField]
	private bool useHighlightColor;

	[SerializeField]
	private Material highlightMaterial;

	[SerializeField]
	private bool useHighlightFont;

	private int relativeCount = -1;

	private Dictionary<string, string> customReplacements = new Dictionary<string, string>();

	public void SetLocalizationKey(string newDisplayedText)
	{
		localizationKey = newDisplayedText;
	}

	private void Awake()
	{
		displayedText = GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
	}

	public override void Begin()
	{
		UpdateText();
		displayedText.gameObject.SetActive(value: true);
		TweenSettingsExtensions.From(ShortcutExtensionsTMPText.DOFade(displayedText, 1f, fadeDuration), 0f);
		LocalizationManager.Instance.OnLanguageChanged += UpdateText;
		Singleton<InputManager>.Instance.OnInputDeviceChanged += UpdateTextFromInputDeviceChanged;
	}

	private void UpdateTextFromInputDeviceChanged(InputDevice obj)
	{
		UpdateText();
	}

	public void UpdateText()
	{
		string key = localizationKey;
		if (Enumerable.Count(localizationKeyVariants, (InputDeviceLocalizationKey x) => x.inputDevice == Singleton<InputManager>.Instance.CurrentInputDevice) > 0)
		{
			key = Enumerable.First(localizationKeyVariants, (InputDeviceLocalizationKey x) => x.inputDevice == Singleton<InputManager>.Instance.CurrentInputDevice).localizationKey;
		}
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue(key, useFallbackText: true);
		localizedValue = ReplaceTextAttributes(localizedValue);
		LocalizationManager.Instance.UpdateTextMesh(displayedText, LocalizedFontStyle.SemiBold, localizedValue, HorizontalAlignmentOptions.Left);
	}

	private string ReplaceTextAttributes(string inputString)
	{
		string text = "";
		string text2 = "";
		if (useHighlightColor)
		{
			text = text + "<color=#" + ColorUtility.ToHtmlStringRGBA(highlightMaterial.color) + ">";
			text2 += "</color>";
		}
		if (useHighlightFont)
		{
			text = text + "<font=\"" + LocalizationManager.Instance.GetFont(LocalizedFontStyle.ExtraBold).name + "\">";
			text2 += "</font>";
		}
		if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
		{
			text = StringUtility.Reverse(text);
			text2 = StringUtility.Reverse(text2);
		}
		if (relativeCount > -1)
		{
			inputString = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(inputString, relativeCount);
		}
		foreach (KeyValuePair<string, string> customReplacement in customReplacements)
		{
			inputString = inputString.Replace(customReplacement.Key, customReplacement.Value);
		}
		inputString = inputString.Replace("[h]", text).Replace("[/h]", text2);
		return inputString;
	}

	public override void Finish()
	{
		TweenSettingsExtensions.OnComplete(ShortcutExtensionsTMPText.DOFade(displayedText, 0f, fadeDuration), delegate
		{
			displayedText.gameObject.SetActive(value: true);
		});
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= UpdateText;
		}
		if ((bool)Singleton<InputManager>.Instance)
		{
			Singleton<InputManager>.Instance.OnInputDeviceChanged -= UpdateTextFromInputDeviceChanged;
		}
	}

	public override void Skip()
	{
	}

	public void SetRelativeCount(int newCount)
	{
		relativeCount = newCount;
		UpdateText();
	}

	public void AddReplacement(string stringToReplace, string replacement)
	{
		if (!customReplacements.ContainsKey(stringToReplace))
		{
			customReplacements.Add(stringToReplace, replacement);
		}
		else
		{
			customReplacements[stringToReplace] = replacement;
		}
	}

	private void _003CFinish_003Eb__15_0()
	{
		displayedText.gameObject.SetActive(value: true);
	}
}
