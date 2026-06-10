using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Repository
{
	public class TraderTypeRepository : DynamicJsonRepository<TraderTypeRepository, TraderType>
	{
		protected override string JsonFile()
		{
			return "Trading/TraderType.json";
		}
	}
}
