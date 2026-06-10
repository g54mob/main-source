using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class WorkerCountMultipliersData : DynamicSettingsData<WorkerCountMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/WorkerCountMultipliers.json";
		}
	}
}
