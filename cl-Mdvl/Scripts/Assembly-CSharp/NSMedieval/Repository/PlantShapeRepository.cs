using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class PlantShapeRepository : DynamicJsonRepository<PlantShapeRepository, PlantShape>
	{
		protected override string JsonFile()
		{
			return "Data/PlantShapeRepository.json";
		}
	}
}
