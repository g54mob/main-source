using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Views.Resources;

namespace NSMedieval.DevConsole
{
	public class CommandSetStunted : ConsoleCommand
	{
		private bool stunted;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetStunted()
		{
			Command = "setStunted";
			Description = "Turns plant into a stunted one.";
			Help = "setStunted <stunted:bool>";
		}

		private void CommandMethod(bool stunted)
		{
			this.stunted = stunted;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {stunted}" });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null) && obj.GetAsWorldObject() is PlantMapResourceInstance plantMapResourceInstance)
			{
				plantMapResourceInstance.SetStunted(stunted);
				PlantMapResourceView plantMapResourceView = obj as PlantMapResourceView;
				if (!(plantMapResourceView == null))
				{
					plantMapResourceView.ChangeLifePhase();
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
