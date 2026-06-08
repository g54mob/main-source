using UnityEngine.UI;

public class UIInput : UITextLabel
{
	public Text placeholderText;

	public Text characterCounterText;

	public InputField inputField { get; private set; }

	public bool HasFocus { get; private set; }

	protected override void Awake()
	{
		inputField = GetComponent<InputField>();
	}

	public void RefreshCounter()
	{
		characterCounterText.text = string.Format("({0}/{1})", label.text.Length, inputField.characterLimit);
	}
}
