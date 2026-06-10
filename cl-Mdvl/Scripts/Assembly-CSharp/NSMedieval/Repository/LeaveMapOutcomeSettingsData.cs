using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class LeaveMapOutcomeSettingsData : DynamicSettingsData<LeaveMapOutcomeSettingsData, LeaveMapOutcomeSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/LeaveMapOutcomeSettings.json";
		}
	}
}
