using ScheduleOne.EntityFramework;
using ScheduleOne.StationFramework;

namespace ScheduleOne.Management
{
	public class SpawnStationConfiguration : EntityConfiguration
	{
		public NPCField AssignedBotanist;

		public ObjectField Destination;

		public MushroomSpawnStation Station { get; protected set; }

		public TransitRoute DestinationRoute { get; protected set; }

		public SpawnStationConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, MushroomSpawnStation station)
			: base(null, null, null)
		{
		}

		public override void Reset()
		{
		}

		private void DestinationChanged(BuildableItem item)
		{
		}

		public bool DestinationFilter(BuildableItem obj, out string reason)
		{
			reason = null;
			return false;
		}

		public override void Selected()
		{
		}

		public override void Deselected()
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
	}
}
