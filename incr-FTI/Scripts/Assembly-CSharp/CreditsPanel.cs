using TMPro;
using UnityEngine.UI;

public class CreditsPanel : MenuPanel
{
	public ScrollRect scrollRect;

	public LayoutGroup layoutGroup;

	public TextMeshProUGUI listItemDeveloper;

	public TextMeshProUGUI listItemArt;

	public TextMeshProUGUI listItemMusic;

	public TextMeshProUGUI listItemLocalization;

	public override void Initialize()
	{
		base.Initialize();
		scrollRect.scrollSensitivity = 40f;
		scrollRect.verticalScrollbarSpacing = -1f;
		header.headerIcon.sprite = IconManager.Instance.quests;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		listItemDeveloper.text = TextDisplay.FormattedKeyValue("CreditsDeveloper", "Erik Asmussen");
		listItemArt.text = TextDisplay.FormattedKeyValue("CreditsArt", "Evelina Waara");
		listItemMusic.text = TextDisplay.FormattedKeyValue("CreditsMusic", "Erik Asmussen");
		listItemLocalization.text = TextDisplay.FormattedKeyValue("CreditsLocalization", "\nZ-h-y  (简体中文)\nLady_whynot  (Deutsch)\nSigma6.9  (Français)\nFadaja  (Türkçe)\nArenvs  (Español)\nanton00500 and Kent City (Русский)\nDaniele Martinelli and Martina Esse (Italiano)\nDiogo Stafocher (Português-Brazil)");
	}

	public override void CreateItems()
	{
		base.CreateItems();
	}
}
