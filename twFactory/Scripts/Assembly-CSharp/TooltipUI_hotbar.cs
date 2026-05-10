using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI_hotbar : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI buildingName;

	[SerializeField]
	private UIList costList;

	private GameplayObjectData goData;

	public override void Setup(Dictionary<string, object> data)
	{
		goData = data["gameplayObjectData"] as GameplayObjectData;
		buildingName.text = goData.DisplayName;
		costList.LoadList(goData.BuyCost);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
