using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandTrackWorkerAreas : ConsoleCommand
	{
		private float accumulator;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandTrackWorkerAreas()
		{
			Command = "trackWorkerArea";
			Description = "Periodically prints A* areas and humanoid count in them";
			Help = "Use this command with start and stop arguments.";
		}

		private void CommandMethod(string commandName)
		{
			if (string.IsNullOrEmpty(commandName) || (!commandName.Equals("start") && !commandName.Equals("stop")))
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Must use this command with start or stop arguments", ConsoleMessageType.Error);
			}
			else if (!(commandName == "start"))
			{
				if (commandName == "stop")
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Stopped logging");
					MonoSingleton<SceneController>.Instance.Tick -= OnTick;
				}
			}
			else if (accumulator > 0f)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Already logging");
			}
			else
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Started logging");
				MonoSingleton<SceneController>.Instance.Tick += OnTick;
			}
		}

		private void OnTick(float delta)
		{
			accumulator += delta;
		}
	}
}
