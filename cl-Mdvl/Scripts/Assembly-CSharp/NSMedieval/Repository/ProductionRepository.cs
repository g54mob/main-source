using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class ProductionRepository : DynamicJsonRepository<ProductionRepository, NSMedieval.Model.Production>
	{
		protected override string JsonFile()
		{
			return "Resources/Production.json";
		}
	}
}
