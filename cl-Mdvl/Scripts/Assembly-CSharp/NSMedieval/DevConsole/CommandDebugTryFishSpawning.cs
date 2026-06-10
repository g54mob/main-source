using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Resources;

namespace NSMedieval.DevConsole
{
	public class CommandDebugTryFishSpawning : ConsoleCommand
	{
		private bool active;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandDebugTryFishSpawning()
		{
			Command = "tryFishSpawn";
			Description = "Force system to try to spawn a new fish";
			Help = "Use this to try to spawn new fish using FishRegrowController";
		}

		private void CommandMethod()
		{
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnFish;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("TrySpawnFish Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnFish()
		{
			MonoSingleton<FishRegrowController>.Instance.DebugTryFishSpawning();
		}

		private void Deactivate()
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnFish;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("TrySpawnFish Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
			}
		}
	}
}
