using System.Collections.Generic;
using ScheduleOne.Employees;

namespace ScheduleOne.Quests
{
	public class Quest_Chemists : Quest_Employees
	{
		public QuestEntry AssignWorkEntry;

		protected override void OnMinPass()
		{
		}

		public override List<Employee> GetEmployees()
		{
			return null;
		}
	}
}
