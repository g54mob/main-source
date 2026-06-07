public class ChangeWindowFocusCommand : AppCommand
{
	private bool _hasWindowFocus;

	public void Configure(bool hasWindowFocus)
	{
		_hasWindowFocus = hasWindowFocus;
	}

	public override void Reset()
	{
		_hasWindowFocus = false;
	}

	public override bool Execute(IApp receiver)
	{
		receiver.InputState.OnWindowFocusChanged(_hasWindowFocus);
		return true;
	}
}
