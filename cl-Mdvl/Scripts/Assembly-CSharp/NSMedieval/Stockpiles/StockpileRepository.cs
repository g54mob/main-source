using NSEipix.Repository;

namespace NSMedieval.Stockpiles
{
	public class StockpileRepository : DynamicJsonRepository<StockpileRepository, Stockpile>
	{
		protected override string JsonFile()
		{
			return "Stockpile/Stockpile.json";
		}
	}
}
