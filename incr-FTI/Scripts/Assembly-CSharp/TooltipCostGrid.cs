using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipCostGrid : MenuButton
{
	public TextMeshProUGUI label;

	public Image iconImage;

	public CostGrid costGrid;

	public RectTransform indentArea;

	public EntityId navigationTarget;

	private bool hasInitialized;

	public void AddDisplayOnlyCraftArrow()
	{
		costGrid.AddSpacerArrow();
		costGrid.craftArrow.GetComponent<Image>().enabled = false;
	}

	public void ResetDisplay()
	{
		costGrid.Clear();
		SetIndentLevel(1);
		navigationTarget = EntityId.None;
		if (!hasInitialized)
		{
			hasInitialized = true;
			AddPointerClickTrigger(OnClicked);
		}
	}

	private void OnClicked()
	{
		MenuManager.Instance.OnClickedTooltipNavigation(navigationTarget);
	}

	public void SetIndentLevel(int numIndents)
	{
		indentArea.SetLeft(numIndents * 40 + 2);
	}
}
