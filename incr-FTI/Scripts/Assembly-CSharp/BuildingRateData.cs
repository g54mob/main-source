public class BuildingRateData : ItemRateData
{
	public BuildingType buildingType;

	public BuildingRateData(ConsumableState s, BuildingType b)
	{
		state = s;
		buildingType = b;
	}
}
