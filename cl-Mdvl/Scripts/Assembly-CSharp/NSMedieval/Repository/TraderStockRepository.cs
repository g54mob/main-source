using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Repository
{
	public class TraderStockRepository : DynamicJsonRepository<TraderStockRepository, TraderStockContent>
	{
		protected override string JsonFile()
		{
			return "Trading/TraderStocks.json";
		}
	}
}
