using ScheduleOne.ItemFramework;
using ScheduleOne.Property;
using ScheduleOne.Tools;

namespace ScheduleOne.PlayerTasks
{
	public class FillWaterContainer : Task
	{
		private Tap _tap;

		private WaterContainerInstance _waterContainerItem;

		private FillableWaterContainer _fillable;

		public new string TaskName { get; protected set; }

		public FillWaterContainer(Tap tap, WaterContainerInstance waterContainerItem)
		{
		}

		public override void StopTask()
		{
		}

		public override void Update()
		{
		}

		private void UpdateInstruction()
		{
		}

		private void UpdateFillSound()
		{
		}
	}
}
