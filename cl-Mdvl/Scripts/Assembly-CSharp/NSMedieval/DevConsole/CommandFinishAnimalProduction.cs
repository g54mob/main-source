using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandFinishAnimalProduction : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandFinishAnimalProduction()
		{
			Command = "finishAnimalProduction";
			Description = "Force animal production to complete";
			Help = "Use this to complete animal production";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null) && obj.GetAsCreature() is AnimalInstance animalInstance && !animalInstance.HasHarvestableProduction())
			{
				animalInstance.CompleteAnimalProduction();
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
