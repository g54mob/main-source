public class ConfirmDeleteSavePopup : Popup
{
	private ConfirmDeleteSavePopupData _data;

	public override string ID => null;

	public override bool CanHandle(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}

	public void OnConfirmPressed()
	{
	}

	public void OnCancelPressed()
	{
	}
}
