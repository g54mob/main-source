using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.PlayerTasks.Tasks
{
	public class GrowContainerPourTask : Task
	{
		protected GrowContainer growContainer;

		protected ItemInstance item;

		protected Pourable pourable;

		protected bool removeItemAfterInitialPour;

		public override string TaskName { get; protected set; }

		protected virtual bool UseCoverage { get; }

		protected virtual bool FailOnEmpty { get; }

		protected virtual GrowContainerCameraHandler.ECameraPosition CameraPosition { get; }

		public GrowContainerPourTask(GrowContainer _growContainer, ItemInstance _itemInstance, Pourable _pourablePrefab)
		{
		}

		public override void Update()
		{
		}

		public override void StopTask()
		{
		}

		protected virtual void OnInitialPour()
		{
		}

		protected void RemoveItem()
		{
		}

		protected virtual void FullyCovered()
		{
		}
	}
}
