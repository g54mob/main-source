using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
	public static LoadingUI Instance;

	public Text asciiProgressLabel;

	public Text statusLabel;

	public int characterCount = 25;

	private void Awake()
	{
		Instance = this;
		statusLabel.text = string.Empty;
	}

	public void SetValue(float percent)
	{
		if (percent > 1f)
		{
			percent = 1f;
		}
		int num = Mathf.RoundToInt((float)characterCount * percent);
		asciiProgressLabel.text = string.Empty.ToString().PadRight(num, '|');
		asciiProgressLabel.text += string.Empty.ToString().PadRight(characterCount - num, '.');
	}

	public void SetStatusText(string text)
	{
		statusLabel.text = text;
	}
}
