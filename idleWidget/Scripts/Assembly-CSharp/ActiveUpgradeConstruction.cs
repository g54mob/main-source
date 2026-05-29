using Assets.Source.UI;
using UnityEngine;

public class ActiveUpgradeConstruction : MonoBehaviour, ITooltipCustomSource
{
	private ActiveUpgradeSlot _parent;

	private void Awake()
	{
		_parent = GetComponentInParent<ActiveUpgradeSlot>();
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		tooltip.AddTextLine(UIHelper.HighlightText("Right-click") + " to cancel.");
		tooltip.AddConstructionLines(_parent.Construction);
	}

	private void OnMouseOver()
	{
		if (PlayerControls.InputCancel)
		{
			_parent.CancelConstruction();
		}
	}
}
