using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI_source : TooltipUI
{
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private FillBar fillBar;

	[SerializeField]
	private TextMeshProUGUI amountText;

	private Source source;

	private void Update()
	{
		if (source.CurrentClickFarmingUnits < source.ClickFarmingUnits)
		{
			fillBar.SetBarValue(source.CurrentClickFarmingUnits);
		}
		else
		{
			fillBar.SetBarValue(0f);
		}
		amountText.text = source.CurrentAmount.ToString();
		LayoutRebuilder.ForceRebuildLayoutImmediate(amountText.transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(amountText.transform.parent as RectTransform);
	}

	public override void Setup(Dictionary<string, object> data)
	{
		source = data["source"] as Source;
		iconImage.sprite = source.Resource.Image;
		fillBar.SetBarMaxValue(source.ClickFarmingUnits);
		fillBar.SetBarValue(source.CurrentClickFarmingUnits);
		amountText.text = source.CurrentAmount.ToString();
		WorldObjectUI component = GetComponent<WorldObjectUI>();
		component.FollowTarget = source.gameObject;
		component.Offset += source.PlacementComponent.GetCenter() - source.transform.position;
		LayoutRebuilder.ForceRebuildLayoutImmediate(amountText.transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(amountText.transform.parent as RectTransform);
	}
}
