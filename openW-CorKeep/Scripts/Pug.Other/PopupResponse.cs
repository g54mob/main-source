public struct PopupResponse
{
	public int Value { get; }

	public bool IsConfirm => Value == 1;

	public bool IsCancel => Value == 0;

	public PopupResponse(bool confirm)
	{
		Value = (confirm ? 1 : 0);
	}

	public PopupResponse(int value)
	{
		Value = value;
	}
}
