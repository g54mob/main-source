using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Repository
{
	public class TraderStockModifierRepository : DynamicJsonRepository<TraderStockModifierRepository, TraderStockModifier>
	{
		protected override string JsonFile()
		{
			return "Trading/TraderStockModifiers.json";
		}
	}
}
