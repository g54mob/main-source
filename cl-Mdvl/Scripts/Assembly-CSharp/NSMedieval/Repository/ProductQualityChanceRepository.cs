using NSEipix.Repository;
using NSMedieval.Production;

namespace NSMedieval.Repository
{
	public class ProductQualityChanceRepository : DynamicJsonRepository<ProductQualityChanceRepository, ProductQualityChance>
	{
		protected override string JsonFile()
		{
			return "Resources/ProductQualityChance.json";
		}
	}
}
