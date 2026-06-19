public abstract class StringPopup : Popup
{
	public override bool CanHandle(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}

	protected abstract void Show();
}
