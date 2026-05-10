using ScheduleOne.StationFramework;

namespace ScheduleOne.UI.Management
{
	public class SpawnStationUIElement : WorldspaceUIElement
	{
		public MushroomSpawnStation AssignedStation { get; protected set; }

		public void Initialize(MushroomSpawnStation pack)
		{
		}

		protected virtual void RefreshUI()
		{
		}
	}
}
