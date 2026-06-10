using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandSetLowFuel : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetLowFuel()
		{
			Command = "setLowFuel";
			Description = "Set fuel to very low";
			Help = "Use this to lower fuel level to very low";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj is BaseBuildingViewComponent baseBuildingViewComponent))
			{
				return;
			}
			FuelConsumerComponent component = baseBuildingViewComponent.GetComponent<FuelConsumerComponent>();
			if (!(component == null))
			{
				FuelConsumerComponentInstance componentInstance = component.ComponentInstance;
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					componentInstance.DebugSetLowFuel();
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
