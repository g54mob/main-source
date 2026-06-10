using NSEipix.Repository;
using NSMedieval.Roles;

namespace NSMedieval.Repository
{
	public class WardenRoleSettingsData : DynamicSettingsData<WardenRoleSettingsData, WardenRoleSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/WardenRoleSettings.json";
		}
	}
}
