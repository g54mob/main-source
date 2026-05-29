using ScheduleOne.Employees;

namespace ScheduleOne.Persistence.Loaders
{
	public class LegacyEmployeeLoader : LegacyNPCLoader
	{
		public override string NPCType => null;

		public Employee LoadAndCreateEmployee(string mainPath)
		{
			return null;
		}
	}
}
