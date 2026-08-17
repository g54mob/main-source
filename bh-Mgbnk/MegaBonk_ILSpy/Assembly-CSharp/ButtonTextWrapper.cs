using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class ButtonTextWrapper : MonoBehaviour
{
	public RectTransform rect;

	public TextMeshProUGUI t_text;

	public int paddingX = 25;

	public int paddingY = 15;

	public float yOffsetRatio = 0.1f;

	public float offsetLeftX;

	public void Refresh()
	{
		if (t_text != null)
		{
			RectTransform rectTransform = t_text.rectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			RectTransform rectTransform2 = t_text.rectTransform;
			Vector2 vector = default(Vector2);
			rectTransform2.anchoredPosition = vector;
			RectTransform rectTransform3 = t_text.rectTransform;
			Vector2 sizeDelta2 = rectTransform3.sizeDelta;
			rect.sizeDelta = vector;
		}
	}

	private void OnValidate()
	{
		if (t_text == null)
		{
			TextMeshProUGUI componentInChildren = GetComponentInChildren<TextMeshProUGUI>();
			t_text = componentInChildren;
		}
		if (rect == null)
		{
			RectTransform component = GetComponent<RectTransform>();
			rect = component;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 104 Invalid \"Jump target not found in method: 0x180548950\"");
	}
}
