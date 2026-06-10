using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class SignComponentManager : ComponentBaseManager<SignComponent, SignComponentInstance>
	{
		public SignComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
