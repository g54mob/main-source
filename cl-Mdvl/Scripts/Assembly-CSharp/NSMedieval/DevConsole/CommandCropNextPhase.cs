using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Crops;
using NSMedieval.View;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandCropNextPhase : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandCropNextPhase()
		{
			Command = "cropNextPhase";
			Description = "Switch to next plant growth phase on selected crop";
			Help = "Use this to change plant growth phase on selected crop";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null))
			{
				WorldObject asWorldObject = obj.GetAsWorldObject();
				if (asWorldObject != null && asWorldObject is CropfieldInstance cropfieldInstance)
				{
					cropfieldInstance.StartNextPhaseDebug();
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
