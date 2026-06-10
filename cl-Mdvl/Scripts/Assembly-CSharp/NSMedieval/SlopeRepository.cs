using NSEipix.Repository;
using NSMedieval.Model.MapNew;

namespace NSMedieval
{
	public class SlopeRepository : DynamicJsonRepository<SlopeRepository, Slope>
	{
		protected override string JsonFile()
		{
			return "Map/Slopes.json";
		}
	}
}
