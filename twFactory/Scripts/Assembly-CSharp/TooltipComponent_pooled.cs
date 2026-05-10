using System.Collections.Generic;
using UnityEngine;

public abstract class TooltipComponent_pooled : TooltipComponent
{
	private int invokersAmount;

	protected override void OnDestroy()
	{
		DestroyTooltip();
	}

	private void CreateTooltip()
	{
		if (!currentTooltipUI)
		{
			currentTooltipUI = Object.Instantiate(tooltipUIPrefab);
			HideTooltip();
		}
	}

	private void DestroyTooltip()
	{
		if ((bool)currentTooltipUI)
		{
			Object.Destroy(currentTooltipUI.gameObject);
		}
	}

	public override bool HideTooltip()
	{
		invokersAmount--;
		invokersAmount = Mathf.Max(invokersAmount, 0);
		if (invokersAmount > 0)
		{
			return true;
		}
		if ((bool)currentTooltipUI)
		{
			currentTooltipUI.gameObject.SetActive(value: false);
			return true;
		}
		return false;
	}

	public override void ShowTooltip(Transform parentTransform)
	{
		if (!currentTooltipUI)
		{
			CreateTooltip();
		}
		invokersAmount++;
		if (invokersAmount <= 1)
		{
			Dictionary<string, object> data = GetData();
			if (data != null && data.Count > 0)
			{
				currentTooltipUI.gameObject.SetActive(value: true);
				currentTooltipUI.transform.SetParent(parentTransform);
				currentTooltipUI.Setup(GetData());
				(currentTooltipUI.transform as RectTransform).position = GetStartPosition();
			}
		}
	}
}
