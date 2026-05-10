using System;
using System.Collections.Generic;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.StationFramework;

namespace ScheduleOne.Management
{
	public class BotanistConfiguration : EntityConfiguration
	{
		public static readonly Type[] AssignableTypes;

		public ObjectField Home;

		public ObjectField Supplies;

		public ObjectListField Assigns;

		private List<BuildableItem> _thisBotanistAssignedOn;

		private Botanist _botanist;

		public List<Pot> AssignedPots { get; private set; }

		public List<DryingRack> AssignedRacks { get; private set; }

		public List<MushroomBed> AssignedBeds { get; private set; }

		public List<MushroomSpawnStation> AssignedSpawnStations { get; private set; }

		public EmployeeHome AssignedHome { get; private set; }

		public override bool AllowRename()
		{
			return false;
		}

		public BotanistConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Botanist _botanist)
			: base(null, null, null)
		{
		}

		public override void Reset()
		{
		}

		private bool IsStationValid(BuildableItem obj, out string reason)
		{
			reason = null;
			return false;
		}

		public void AssignsChanged(List<BuildableItem> objects)
		{
		}

		private NPCField GetNPCField(IConfigurable configurable)
		{
			return null;
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
