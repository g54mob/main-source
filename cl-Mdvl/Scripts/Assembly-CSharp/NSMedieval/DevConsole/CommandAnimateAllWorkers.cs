using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandAnimateAllWorkers : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandAnimateAllWorkers()
		{
			Command = "animateWorkers";
			Description = "Trigger animation on all workers";
			Help = "Trigger animation on all workers";
		}

		private void CommandMethod(string triggerName, float time)
		{
			MonoSingleton<WorkerManager>.Instance.AnimateAllWorkers(triggerName, time);
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Triggering animation triger '" + triggerName + "' on all workers");
		}
	}
}
