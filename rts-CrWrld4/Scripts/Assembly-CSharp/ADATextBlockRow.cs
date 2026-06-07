using TMPro;
using UnityEngine.UI;

public class ADATextBlockRow : ADABlockRow
{
	public TMP_Text text;

	public TMP_InputField inputField;

	public VerticalLayoutGroup paddedContainer;

	public string overrideText;

	public override void Start()
	{
	}

	private void LateUpdate()
	{
	}

	public override void Refresh()
	{
	}

	private string Escape(string t)
	{
		return null;
	}

	private string EscapeCode(string s)
	{
		return null;
	}

	public void OnTextChanged(string val)
	{
	}
}
