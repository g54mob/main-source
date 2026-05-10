using ScheduleOne.Employees;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence.Loaders
{
	public class EmployeeLoader : NPCLoader
	{
		public override string NPCType => null;

		public override void Load(DynamicSaveData saveData)
		{
		}

		protected virtual Employee CreateAndLoadEmployee(DynamicSaveData saveData)
		{
			return null;
		}
	}
}
