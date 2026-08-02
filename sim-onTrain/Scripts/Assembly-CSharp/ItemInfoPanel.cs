using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : UIPanelBase
{
	public Transform infoParent;

	[SerializeField]
	private GameObject textPanelRoot;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI descriptionText;

	[SerializeField]
	private GameObject imagePanelRoot;

	public Image itemInfoImage;

	public TextMeshProUGUI itemInfoImageTitleText;

	public TextMeshProUGUI itemInfoImageDescriptionText;

	public new void ShowPanel()
	{
		isPanelOpen = true;
		base.CanvasGroup.alpha = 1f;
	}

	public new void HidePanel()
	{
		isPanelOpen = false;
		base.CanvasGroup.alpha = 0f;
	}

	public void SetPanel(string title, string description)
	{
		if (imagePanelRoot != null)
		{
			imagePanelRoot.SetActive(value: false);
		}
		if (textPanelRoot != null)
		{
			textPanelRoot.SetActive(value: true);
		}
		titleText.SetText(title);
		descriptionText.SetText(description);
	}

	public void SetPanel(string title, string description, Sprite image)
	{
		if (textPanelRoot != null)
		{
			textPanelRoot.SetActive(value: false);
		}
		if (imagePanelRoot != null)
		{
			imagePanelRoot.SetActive(value: true);
		}
		itemInfoImageTitleText.SetText(title);
		itemInfoImageDescriptionText.SetText(description);
		itemInfoImage.sprite = image;
	}
}
