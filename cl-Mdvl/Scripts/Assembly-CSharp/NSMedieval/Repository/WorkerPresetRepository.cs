using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class WorkerPresetRepository : DynamicJsonRepository<WorkerPresetRepository, HumanPreset>
	{
		protected override string JsonFile()
		{
			return "Worker/WorkerPreset.json";
		}
	}
}
