using NSEipix.Repository;
using NSMedieval.Model.MapNew;

namespace NSMedieval
{
	public class MapRepository : DynamicJsonRepository<MapRepository, NSMedieval.Model.MapNew.Map>
	{
		public override void Reload()
		{
			Deserialize();
		}

		protected override string JsonFile()
		{
			return "Map/MapTypes.json";
		}
	}
}
