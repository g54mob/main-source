using NSEipix.Repository;
using NSMedieval.Factions;

namespace NSMedieval.Repository
{
	public class FactionRelationsData : DynamicSettingsData<FactionRelationsData, FactionRelations>
	{
		protected override string JsonFile()
		{
			return "Settings/FactionRelations.json";
		}
	}
}
