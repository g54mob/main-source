using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class GoalPreferenceRepository : DynamicJsonRepository<GoalPreferenceRepository, GoalPreference>
	{
		protected override string JsonFile()
		{
			return "Worker/GoalPreference.json";
		}
	}
}
