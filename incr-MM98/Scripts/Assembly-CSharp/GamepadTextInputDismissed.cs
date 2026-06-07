public readonly struct GamepadTextInputDismissed
{
	public readonly bool IsCancelled;

	public readonly string Text;

	public static GamepadTextInputDismissed Cancelled => new GamepadTextInputDismissed(string.Empty, isCancelled: true);

	public GamepadTextInputDismissed(string text, bool isCancelled = false)
	{
		Text = text;
		IsCancelled = isCancelled;
	}
}
