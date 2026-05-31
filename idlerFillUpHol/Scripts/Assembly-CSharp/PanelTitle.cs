using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelTitle : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject Parent;

	private string _originalTitle = "";

	private string _tooltipText = "";

	private Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> _dynamicTooltip;

	private int _previousLevel = -1;

	public void Initialize(GameObject parent, string title, string tooltip = "")
	{
		Parent = parent;
		_originalTitle = title;
		_tooltipText = tooltip;
		_dynamicTooltip = null;
		GetComponent<TMP_Text>().text = _originalTitle;
	}

	public void UpdateTitleForLevel(int level)
	{
		if (_previousLevel != level)
		{
			_previousLevel = level;
			GetComponent<TMP_Text>().text = GetTitle(_originalTitle, level);
		}
	}

	public void UpdateTooltip(string tooltip)
	{
		_tooltipText = tooltip;
		_dynamicTooltip = null;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!string.IsNullOrEmpty(_tooltipText) || _dynamicTooltip != null)
		{
			if (_dynamicTooltip == null)
			{
				TooltipPanel.Instance.ShowTooltip(Parent, base.gameObject, _tooltipText);
			}
			else
			{
				TooltipPanel.Instance.ShowDynamicTooltip(Parent, base.gameObject, _dynamicTooltip);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipPanel.Instance.HideTooltip();
	}

	public void SetDynamicTooltip(Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> tooltipInfo)
	{
		_tooltipText = "";
		_dynamicTooltip = tooltipInfo;
	}

	public static string GetTitle(string name, int level)
	{
		_ = 1;
		_ = 2;
		_ = 3;
		_ = 4;
		_ = 5;
		_ = 6;
		_ = 7;
		_ = 8;
		_ = 9;
		_ = 10;
		return name + " " + level;
	}
}
