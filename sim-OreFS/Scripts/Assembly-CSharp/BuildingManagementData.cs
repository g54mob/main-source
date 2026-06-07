using Mirror;

public struct BuildingManagementData
{
	public BuildingObject targetBuilding;

	public BuildingManagementMode mode;

	public T_BuildingItemSO buildingSO;

	public int refundAmount;

	public uint buildingNetId;

	public BuildingManagementData(BuildingObject building, BuildingManagementMode managementMode)
	{
		targetBuilding = building;
		mode = managementMode;
		buildingSO = ((building != null) ? building.buildingItemSO : null);
		refundAmount = ((buildingSO != null) ? buildingSO.Price : 0);
		if (building != null)
		{
			NetworkIdentity component = building.GetComponent<NetworkIdentity>();
			buildingNetId = ((component != null) ? component.netId : 0u);
		}
		else
		{
			buildingNetId = 0u;
		}
	}

	public bool CanResale()
	{
		if (targetBuilding != null && targetBuilding.IsPlaced && buildingSO != null)
		{
			return buildingSO.canBeResaledWithHammer;
		}
		return false;
	}

	public bool CanRelocate()
	{
		if (targetBuilding != null && targetBuilding.IsPlaced && buildingSO != null)
		{
			return buildingSO.canBeRelocatedWithHammer;
		}
		return false;
	}
}
