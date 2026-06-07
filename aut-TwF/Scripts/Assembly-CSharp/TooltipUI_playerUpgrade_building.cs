using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI_playerUpgrade_building : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI buildingName;

	[SerializeField]
	private TextMeshProUGUI buildingDescription;

	[SerializeField]
	private UpgradesMenuTowerInfo towerInfo;

	[SerializeField]
	private UIList costList;

	public override void Setup(Dictionary<string, object> data)
	{
		GameplayObjectData gameplayObjectData = data["buildingData"] as GameplayObjectData;
		buildingName.text = gameplayObjectData.DisplayName;
		buildingDescription.text = gameplayObjectData.Description;
		if ((bool)gameplayObjectData.Prefab.GetComponent<Tower>())
		{
			towerInfo.SelectedTower = gameplayObjectData.Prefab.GetComponent<Tower>();
		}
		else
		{
			towerInfo.gameObject.SetActive(value: false);
		}
		costList.LoadList(gameplayObjectData.BuyCost);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
