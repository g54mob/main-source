using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerTasks.Tasks;

namespace ScheduleOne.PlayerTasks
{
	public class ApplyAdditiveToPot : GrowContainerPourTask
	{
		private AdditiveDefinition def;

		protected override bool UseCoverage => false;

		protected override GrowContainerCameraHandler.ECameraPosition CameraPosition => default(GrowContainerCameraHandler.ECameraPosition);

		public ApplyAdditiveToPot(GrowContainer _growContainer, ItemInstance _itemInstance, Pourable _pourablePrefab)
			: base(null, null, null)
		{
		}

		public override void Update()
		{
		}

		protected override void FullyCovered()
		{
		}
	}
}
