using System.Collections.Generic;
using UnityEngine;

public class PowerUpPanel : UIPanelBase
{
	public List<PowerUpItem> powerUpItems = new List<PowerUpItem>();

	public void Start()
	{
		powerUpItems.AddRange(GetComponentsInChildren<PowerUpItem>(includeInactive: true));
	}

	public void ActivatePowerUp(CollectableItemData data)
	{
		PowerUpItem powerUpItem = powerUpItems.Find((PowerUpItem x) => x.powerUpData == data);
		if (powerUpItem != null)
		{
			bool isActive = powerUpItem.IsActive;
			powerUpItem.ActivatePowerUp(data, isActive);
			if (!isActive)
			{
				int num = 0;
				foreach (PowerUpItem powerUpItem2 in powerUpItems)
				{
					if (powerUpItem2.IsActive && powerUpItem2 != powerUpItem)
					{
						num++;
					}
				}
				powerUpItem.transform.SetSiblingIndex(num);
				Debug.Log($"PowerUpPanel: {data.itemDisplayName} açıldı - Index: {num}");
			}
			else
			{
				Debug.Log("PowerUpPanel: " + data.itemDisplayName + " süre eklendi - Index değişmedi");
			}
		}
		else
		{
			Debug.LogWarning($"PowerUpPanel: No PowerUpItem found for powerUpType: {data.powerUpType}");
		}
	}

	public void DeactivateAllPowerUps()
	{
		foreach (PowerUpItem powerUpItem in powerUpItems)
		{
			if (powerUpItem.IsActive)
			{
				powerUpItem.DeactivatePowerUp();
			}
		}
	}
}
