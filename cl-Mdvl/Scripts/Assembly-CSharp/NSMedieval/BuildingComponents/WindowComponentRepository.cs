using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class WindowComponentRepository : DynamicJsonRepository<WindowComponentRepository, WindowComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/WindowComponentRepository.json";
		}
	}
}
