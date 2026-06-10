using TMPro;

public class ComputerPlayerInputText : CruncherAppContent
{
	public TextMeshProUGUI text;

	public string startingTextKey;

	public string fullTextKey;

	private string fullText;

	public float keystrokes;

	public int charsDisplayed;

	public bool displayCursor;

	public float cursorTimer;

	private string revealedText;

	public override void OnSetup()
	{
	}

	private void Update()
	{
	}
}
