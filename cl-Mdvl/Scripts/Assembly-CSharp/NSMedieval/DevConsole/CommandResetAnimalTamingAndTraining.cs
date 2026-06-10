using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandResetAnimalTamingAndTraining : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandResetAnimalTamingAndTraining()
		{
			Command = "resetTamingAndTraining";
			Description = "Reset animal taming and training counters";
			Help = "Use this to reset taming and training attempts internal counters.";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null) && obj.GetAsCreature() is AnimalInstance animalInstance)
			{
				animalInstance.ResetTamingCounters();
				animalInstance.ResetTrainingCounters();
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
