using CTS.Core;

namespace CTS.BBT.AI
{
	public class ContextualActionChangeFloor : MenuContextualAction<ElevatorPortal>
	{
		public Floor TargetFloor { get; set; }

		public override void Setup()
		{
			base.DisplayName = "Go to " + TargetFloor.name;
		}

		protected override bool CanBePerformed()
		{
			return true;
		}

		protected override void Execution()
		{
			MonoSingleton<FloorsManager>.Instance.ChangeCurrentFloor(TargetFloor.FloorID);
		}
	}
}
