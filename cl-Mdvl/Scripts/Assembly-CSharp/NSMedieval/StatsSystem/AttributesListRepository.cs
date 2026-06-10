using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public class AttributesListRepository : DynamicJsonRepository<AttributesListRepository, AttributesList>
	{
		protected override string JsonFile()
		{
			return "StatsSystem/AttributesLists.json";
		}
	}
}
