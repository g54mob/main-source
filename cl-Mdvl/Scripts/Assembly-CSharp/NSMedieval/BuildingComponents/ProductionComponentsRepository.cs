using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class ProductionComponentsRepository : DynamicJsonRepository<ProductionComponentsRepository, ProductionComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/ProductionComponentsRepository.json";
		}
	}
}
