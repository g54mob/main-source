using Factory;
using Motorways.Commands;
using Server;

namespace Motorways.Actions
{
	public class AdvanceTutorialAction : MotorwaysPlayerAction
	{
		public ISimulation targetSimulation;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			targetSimulation = base.Scope.Get<ISimulation>();
			targetSimulation.ScheduleCommand(AdvanceTutorialCommand.Create(base.Scope));
		}

		public override void Tick(float frameTime)
		{
			OnActionComplete();
		}

		public static AdvanceTutorialAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			AdvanceTutorialAction advanceTutorialAction = scope.Get<AdvanceTutorialAction>();
			advanceTutorialAction.InitializeAction(owningGroup, timestamp);
			advanceTutorialAction.OnActionBegin(timestamp);
			return advanceTutorialAction;
		}
	}
}
