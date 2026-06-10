using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class TableComponentRepository : DynamicJsonRepository<TableComponentRepository, TableComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/TableComponentRepository.json";
		}
	}
}
