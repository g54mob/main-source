using UnityEngine;

public class SettingsColorBlind : MonoBehaviour
{
	public EnumSelector selector;

	private void Start()
	{
		selector.onChange.AddListener(OnChange);
	}

	private void OnEnable()
	{
		selector.options.Clear();
		selector.options.AddRange(new string[5]
		{
			TextTranslator.Translate("Menu/ColorblindModeOff"),
			TextTranslator.Translate("Menu/ColorblindModeYellow"),
			TextTranslator.Translate("Menu/ColorblindModeOrange"),
			TextTranslator.Translate("Menu/ColorblindModePurple"),
			TextTranslator.Translate("Menu/ColorblindModeWhite")
		});
		if ((bool)SettingsManager.Instance)
		{
			selector.SetIndex((int)SettingsManager.Instance.ColorblindMode);
		}
	}

	private void OnChange()
	{
		SettingsManager.Instance.SetColorblind((SettingsManager.ColorBlindMode)selector.Index);
	}
}
