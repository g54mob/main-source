using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.View;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandResetTrap : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandResetTrap()
		{
			Command = "resetTrap";
			Description = "Reset selected trap.";
			Help = "Use <resetTrap> in console and then select trap you wish to reset.";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (obj == null)
			{
				return;
			}
			WorldObject asWorldObject = obj.GetAsWorldObject();
			if (asWorldObject != null)
			{
				TrapComponentInstance componentInstance = asWorldObject.Map.TrapComponentsManager.GetComponentInstance(asWorldObject);
				if (componentInstance != null && !componentInstance.HasDisposed && !componentInstance.Operational)
				{
					componentInstance.Reactivate();
				}
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
