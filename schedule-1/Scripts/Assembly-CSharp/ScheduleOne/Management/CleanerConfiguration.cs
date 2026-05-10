using System.Collections.Generic;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;

namespace ScheduleOne.Management
{
	public class CleanerConfiguration : EntityConfiguration
	{
		public ObjectField Home;

		public ObjectListField Bins;

		public Cleaner cleaner { get; protected set; }

		public List<TrashContainerItem> binItems { get; private set; }

		public EmployeeHome assignedHome { get; private set; }

		public override bool AllowRename()
		{
			return false;
		}

		public CleanerConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Cleaner _cleaner)
			: base(null, null, null)
		{
		}

		public override void Reset()
		{
		}

		private bool IsObjValid(BuildableItem obj, out string reason)
		{
			reason = null;
			return false;
		}

		public void AssignedBinsChanged(List<BuildableItem> objects)
		{
		}

		public override bool ShouldSave()
		{
			return false;
		}

		public override string GetSaveString()
		{
			return null;
		}

		private void HomeChanged(BuildableItem newItem)
		{
		}
	}
}
