using TMPro;
using UnityEngine;

public class TextLabelController : MonoBehaviour
{
	[TextArea]
	[SerializeField]
	private string labelName;

	private TextMeshProUGUI textComponent;

	private void OnEnable()
	{
		textComponent = GetComponent<TextMeshProUGUI>();
		SetText();
	}

	public void SetLabel(string label)
	{
		labelName = label;
		SetText();
	}

	public void SetText()
	{
		try
		{
			textComponent.text = LocalizationController.Instance.GetLabelTranslation(labelName);
		}
		catch
		{
		}
	}
}
