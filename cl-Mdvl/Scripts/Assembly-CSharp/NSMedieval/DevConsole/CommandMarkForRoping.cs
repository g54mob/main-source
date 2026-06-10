using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.DevConsole
{
	public class CommandMarkForRoping : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandMarkForRoping()
		{
			Command = "markForRoping";
			Description = "Click on a animal to give it 'rope' order ";
			Help = "Use this command to rope humanoid and animal";
		}

		private void CommandMethod()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnAgentSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Click on a target to give rope order";
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnAgentSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				if (!(agent.AgentOwner is AnimalInstance item))
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("DEBUG: Not a valid target.");
				}
				else
				{
					MonoSingleton<AnimalManager>.Instance.CanBeRopedToPen.Add(item);
				}
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnAgentSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
