using Assets.Source.UI;
using UnityEngine;

public class ActiveAutoCrafterConstruction : MonoBehaviour, ITooltipCustomSource
{
	private ActiveAutoCrafter _parent;

	private void Awake()
	{
		_parent = GetComponentInParent<ActiveAutoCrafter>();
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		tooltip.AddConstructionLines(_parent.Worker.Construction);
	}

	private void OnMouseOver()
	{
		if (PlayerControls.InputCancel)
		{
			_parent.Worker.CancelConstruction();
		}
	}
}
