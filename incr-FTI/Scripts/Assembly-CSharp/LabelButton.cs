using TMPro;

public class LabelButton : MenuButton
{
	public TextMeshProUGUI label;

	public string localizationKey;

	public void ReloadLabels()
	{
		if (localizationKey != null)
		{
			label.text = localizationKey.Localized();
		}
	}
}
