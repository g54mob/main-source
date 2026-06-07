using Data.FactoryFloor.Resources;

namespace Data.Buildings
{
	public class BuildingConstructionResource
	{
		public int Count;

		public int Max;

		public ResourceDataSO ResourceData;

		public BuildingConstructionResource(ResourceDataSO resourceData)
		{
			ResourceData = resourceData;
		}
	}
}
