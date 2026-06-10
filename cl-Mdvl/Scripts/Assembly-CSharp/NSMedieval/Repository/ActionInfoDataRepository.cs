using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Repository
{
	public class ActionInfoDataRepository : DynamicJsonRepository<ActionInfoDataRepository, ActionInfoData>
	{
		protected override string JsonFile()
		{
			return "Data/ActionInfoData.json";
		}
	}
}
