using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandSetPregnant : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetPregnant()
		{
			Command = "setPregnantAnimal";
			Description = "Force pregnancy on selected female animal";
			Help = "Use this to set animal as a pet";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null) && obj.GetAsCreature() is AnimalInstance { Gender: BodyType.Female } animalInstance)
			{
				animalInstance.SetAnimalAsPregnant();
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
