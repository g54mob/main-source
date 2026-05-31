using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelButtonTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject Parent;

	private Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> _dynamicTooltip;

	public void Initialize(GameObject parent)
	{
		Parent = parent;
	}

	public void SetDynamicTooltip(Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> tooltipInfo)
	{
		_dynamicTooltip = tooltipInfo;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (_dynamicTooltip != null)
		{
			TooltipPanel.Instance.ShowDynamicTooltip(Parent, base.gameObject, _dynamicTooltip);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipPanel.Instance.HideTooltip();
	}
}
