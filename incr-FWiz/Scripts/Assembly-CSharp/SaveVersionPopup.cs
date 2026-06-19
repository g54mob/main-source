using TMPro;

public class SaveVersionPopup : Popup
{
	public TextMeshProUGUI TitleText;

	public TextMeshProUGUI MessageText;

	public override string ID => null;

	public override bool CanHandle(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}
}
