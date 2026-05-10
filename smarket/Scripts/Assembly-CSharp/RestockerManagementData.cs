using System;

[Serializable]
public class RestockerManagementData
{
	public int RestockerID;

	public bool IsActive;

	public bool UseUnlabeledRacks;

	public bool PickUpBoxGround;

	public bool DropEmptyBox;

	public bool RemoveLabelRack;

	public bool RestockShelf;

	public bool RestockFromVehicles;

	public RestockerManagementData(int restockerID, bool isActive = true, bool useUnlabeledRacks = false, bool pickUpBoxGround = true, bool dropEmptyBox = true, bool removeLabelRack = false, bool restockShelf = true, bool restockFromVehicles = true)
	{
	}

	public RestockerManagementData()
	{
	}

	public override string ToString()
	{
		return null;
	}
}
