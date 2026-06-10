using NSEipix.Repository;
using NSMedieval.Model.MapNew;

namespace NSMedieval.Repository
{
	public class MapSizeRepository : DynamicJsonRepository<MapSizeRepository, MapSize>
	{
		protected override string JsonFile()
		{
			return "Map/MapSizes.json";
		}
	}
}
