using ScheduleOne.Audio;
using ScheduleOne.Growing;
using ScheduleOne.ObjectScripts;

namespace ScheduleOne.PlayerTasks
{
	public class HarvestMushroomBedTask : Task
	{
		private AudioSourceController _soundLoop;

		private MushroomBed _mushroomBed;

		protected bool _canDrag;

		private int _harvestCount;

		private int _harvestTotal;

		public HarvestMushroomBedTask(MushroomBed mushroomBed, bool canDrag, AudioSourceController soundLoopPrefab)
		{
		}

		public override void StopTask()
		{
		}

		public override void Update()
		{
		}

		private void UpdateInstructionText()
		{
		}

		protected override void UpdateCursor()
		{
		}

		private GrowingMushroom GetHoveredHarvestable()
		{
			return null;
		}
	}
}
