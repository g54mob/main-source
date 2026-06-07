using Motorways.UI;
using Motorways.Views;
using TMPro;
using UnityEngine;

public class LanguageButton : MonoBehaviour
{
	public TextMeshProUGUI text;

	public TouchToggle touchToggle;

	public OptionsScreenBase optionsScreen;

	public int LocaleIndex { get; private set; }

	public LocaleDatabase.LocaleId LocaleId { get; private set; }

	public void Initialize(Locale locale, int localeIndex, FontDatabase fonts, OptionsScreenBase optionsScreen, ToggleButtonGroup group, bool isSelected)
	{
		text.text = locale.Name;
		LocaleId = locale.Id;
		text.font = fonts.GetFont(locale.Charset).FontAsset;
		text.isRightToLeftText = locale.TextDirection == TextDirection.RightToLeft;
		LocaleIndex = localeIndex;
		this.optionsScreen = optionsScreen;
		group.RegisterToggle(touchToggle);
		touchToggle.IsOn = isSelected;
	}

	public void OnClick()
	{
		optionsScreen.SetLocale(LocaleIndex);
	}
}
