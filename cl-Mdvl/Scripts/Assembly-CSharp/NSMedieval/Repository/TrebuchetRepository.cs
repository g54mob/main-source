using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class TrebuchetRepository : DynamicJsonRepository<TrebuchetRepository, Trebuchet>
	{
		protected override string JsonFile()
		{
			return "WarMachinery/TrebuchetBase.json";
		}
	}
}
