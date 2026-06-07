using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverColorUI : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Color wantedColor;

	[SerializeField]
	private Color wantedTextColor;

	[SerializeField]
	private bool isFirstButton;

	private Color originalColor;

	private Color originalTextColor;

	private ColorBlock colorBlock;

	public bool active = true;

	private readonly Color inactiveColor = new Color(0.7f, 0.69f, 0.67f);

	public void StartHover()
	{
		if (!active)
		{
			button.GetComponentInChildren<TextMeshProUGUI>().color = inactiveColor;
			return;
		}
		colorBlock = button.colors;
		originalColor = colorBlock.selectedColor;
		originalTextColor = button.GetComponentInChildren<TextMeshProUGUI>().color;
	}

	public void ChangeColorWhenHover()
	{
		if (active)
		{
			colorBlock.selectedColor = wantedColor;
			button.colors = colorBlock;
			button.GetComponentInChildren<TextMeshProUGUI>().color = wantedTextColor;
		}
	}

	public void ChangeColorWhenLeaves()
	{
		if (active)
		{
			colorBlock.selectedColor = originalColor;
			button.colors = colorBlock;
			button.GetComponentInChildren<TextMeshProUGUI>().color = originalTextColor;
		}
	}

	private void OnDisable()
	{
		ChangeColorWhenLeaves();
	}
}
