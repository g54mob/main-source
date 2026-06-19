using UnityEngine;

public class LanguageSelectPopup : StringPopup
{
	public const string LanguageSelectPopupID = "LangaugeSelectPopup";

	public LanguageSelectPopupButton LanguageButtonPrefab;

	public Transform LanguageButtonParent;

	public override string ID => null;

	protected override void Show()
	{
	}

	public void OnSelectLanguage(LanguageListingItem listing)
	{
	}
}
