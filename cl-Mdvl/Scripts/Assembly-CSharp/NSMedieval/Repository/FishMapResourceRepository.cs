using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class FishMapResourceRepository : DynamicJsonRepository<FishMapResourceRepository, FishMapResource>
	{
		protected override string JsonFile()
		{
			return "Resources/FishMapResource.json";
		}
	}
}
