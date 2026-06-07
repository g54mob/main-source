using Factory;
using Motorways.Processes;
using Server;

namespace Motorways.Commands
{
	public class AdvanceTutorialCommand : Command
	{
		[Dependency]
		private TutorialProgressionProcess _tutorialProcess;

		public override void Execute(ISimulation simulation)
		{
			_tutorialProcess.hadInput = true;
		}

		public static AdvanceTutorialCommand Create(IScope scope)
		{
			return scope.Get<AdvanceTutorialCommand>();
		}
	}
}
