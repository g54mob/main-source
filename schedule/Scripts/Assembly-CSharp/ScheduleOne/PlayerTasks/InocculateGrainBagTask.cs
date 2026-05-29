using ScheduleOne.ItemFramework;
using ScheduleOne.StationFramework;

namespace ScheduleOne.PlayerTasks
{
	public class InocculateGrainBagTask : Task
	{
		public enum EStage
		{
			RemoveCap = 0,
			InsertSyringe = 1,
			PushPlunger = 2
		}

		private MushroomSpawnStation _station;

		private MushroomSpawnStationItem _spawn;

		private SporeSyringeStationItem _syringe;

		private EStage _currentStage;

		private ItemInstance _grainBagInstance;

		private ItemInstance _syringeInstance;

		private ShroomSpawnDefinition _spawnDefinition;

		public override string TaskName { get; protected set; }

		public InocculateGrainBagTask(MushroomSpawnStation station)
		{
		}

		public override void Success()
		{
		}

		public override void StopTask()
		{
		}

		public override void Update()
		{
		}

		private string GetInstructionForStage(EStage stage)
		{
			return null;
		}

		private void OnSyringeCapRemoved()
		{
		}

		private void OnSyringeInserted()
		{
		}

		private void OnPlungerPushed(float amount)
		{
		}
	}
}
