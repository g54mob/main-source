using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class AdditionalMenuRepository : JsonRepository<AdditionalMenuRepository, AdditionalMenuItemData>
	{
		protected override string JsonFile()
		{
			return "Data/AdditionalMenuData.json";
		}
	}
}
