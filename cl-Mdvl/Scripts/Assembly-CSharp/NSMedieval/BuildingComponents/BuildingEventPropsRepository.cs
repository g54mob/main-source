using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class BuildingEventPropsRepository : DynamicJsonRepository<BuildingEventPropsRepository, BuildingEventProp>
	{
		protected override string JsonFile()
		{
			return "Constructables/BuildingEventProp.json";
		}
	}
}
