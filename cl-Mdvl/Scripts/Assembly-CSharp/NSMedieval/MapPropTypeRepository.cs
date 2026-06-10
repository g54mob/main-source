using NSEipix.Repository;
using NSMedieval.Model.MapNew;

namespace NSMedieval
{
	public class MapPropTypeRepository : DynamicJsonRepository<MapPropTypeRepository, MapPropType>
	{
		protected override string JsonFile()
		{
			return "Map/MapPropTypes.json";
		}
	}
}
