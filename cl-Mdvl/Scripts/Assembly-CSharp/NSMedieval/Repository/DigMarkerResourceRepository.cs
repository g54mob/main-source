using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class DigMarkerResourceRepository : DynamicJsonRepository<DigMarkerResourceRepository, DigMarkerResource>
	{
		protected override string JsonFile()
		{
			return "Resources/DigMarkers.json";
		}
	}
}
