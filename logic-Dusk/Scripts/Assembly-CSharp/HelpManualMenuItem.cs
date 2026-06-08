public class HelpManualMenuItem
{
	public string DisplayText { get; private set; }

	public bool IsJump { get; private set; }

	public bool IsHidden { get; set; }

	public bool IsDimmed { get; set; }

	public bool ChangedSinceLastView { get; set; }

	public bool IsCommand { get; private set; }

	public HelpManualMenu JumpToMenu { get; private set; }

	public string HelpText { get; private set; }

	public HelpManualMenuItem(HelpManualMenu jumpToMenu)
	{
		Init(jumpToMenu.HeaderText, null, true, true, jumpToMenu);
	}

	public HelpManualMenuItem(string displayText, string helpText)
	{
		Init(displayText, helpText, false, true, null);
	}

	public HelpManualMenuItem(string displayText, string helpText, bool isCommand)
	{
		Init(displayText, helpText, false, isCommand, null);
	}

	private void Init(string displayText, string helpText, bool isJump, bool isCommand, HelpManualMenu jumpToMenu)
	{
		IsJump = isJump;
		DisplayText = displayText;
		HelpText = helpText;
		IsCommand = isCommand;
		JumpToMenu = jumpToMenu;
	}
}
