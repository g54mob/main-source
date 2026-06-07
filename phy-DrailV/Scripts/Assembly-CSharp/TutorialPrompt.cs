using TMPro;
using UnityEngine;

public class TutorialPrompt : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;

	public void Close()
	{
	}

	public void SetText(string text)
	{
		this.text.text = text;
	}
}
