using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class ProductionComponentBuildingManager : ComponentBaseManager<ProductionComponent, ProductionComponentInstance>
	{
		public ProductionComponentBuildingManager(VillageMap map)
			: base(map)
		{
		}
	}
}
