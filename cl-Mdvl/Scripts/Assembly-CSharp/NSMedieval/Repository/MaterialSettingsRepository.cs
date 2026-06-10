using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class MaterialSettingsRepository : DynamicJsonRepository<MaterialSettingsRepository, MaterialSettings>
	{
		protected override string JsonFile()
		{
			return "Items/MaterialSettings.json";
		}
	}
}
