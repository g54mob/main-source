using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandSetDebugCombatTarget : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetDebugCombatTarget()
		{
			Command = "setDebugCombatTarget";
			Description = "Select target to be used for drawing targeting gizmos";
			Help = "Select target to be used for drawing targeting gizmos";
		}

		private void CommandMethod()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Select combat target";
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				IDamageTakingAgent asCreature = obj.GetAsCreature();
				if (asCreature == null)
				{
					asCreature = obj.GetAsWorldObject() as IDamageTakingAgent;
				}
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
