using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;

namespace NSMedieval.DevConsole
{
	public class CommandSetWorkerHunger : ConsoleCommand
	{
		private float hungerLevel;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWorkerHunger()
		{
			Command = "setHunger";
			Description = "Set creature's hunger level";
			Help = "Usage: setHunger <hunger_level>";
		}

		private void CommandMethod(float value)
		{
			hungerLevel = value;
			string result = "Click on a creature to set its hunger level.";
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {value}" });
		}

		private void OnWorkerSelected(Agent agent)
		{
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
