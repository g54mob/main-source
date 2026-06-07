using TMPro;
using UnityEngine;

public class TutorialFloatie : MonoBehaviour
{
	public string tutorialTextString = string.Empty;

	private TextMeshProUGUI tutorialText;

	private void Awake()
	{
		Transform transform = base.transform.Find("Image");
		tutorialText = transform.Find("label").GetComponent<TextMeshProUGUI>();
		tutorialText.text = tutorialTextString;
	}

	public void UpdateTextExternally(string text)
	{
		tutorialText.text = text;
	}

	public string GetText()
	{
		return tutorialText.text;
	}
}
