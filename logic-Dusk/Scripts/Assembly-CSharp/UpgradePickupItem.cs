using UnityEngine;

public class UpgradePickupItem : RoomItem
{
	public bool collected;

	public override string ItemName
	{
		get
		{
			if (UpgradeItem != null)
			{
				return UpgradeItem.Name;
			}
			return "not a valid item (drone upgrade)";
		}
	}

	public BaseDroneUpgrade UpgradeItem { get; private set; }

	public override bool Explored
	{
		get
		{
			return true;
		}
	}

	public void SetUpgradeItem(BaseDroneUpgrade upgradeItem)
	{
		UpgradeItem = upgradeItem;
	}

	public override void Start()
	{
		base.Start();
		GetComponent<Renderer>().enabled = true;
	}

	public override void UpdateCameraView()
	{
		if (UpgradeItem != null)
		{
			GetComponent<Renderer>().enabled = true;
		}
		else
		{
			GetComponent<Renderer>().enabled = false;
		}
	}
}
