using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Resources;
using NSMedieval.State;

namespace NSMedieval.DevConsole
{
	public class CommandRemoveResourcePile : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandRemoveResourcePile()
		{
			Command = "destroyPile";
			Description = "Click on pile to destroy it";
			Help = "Use this command to destroy pile with mouse click.";
		}

		private void CommandMethod()
		{
			MonoSingleton<ResourcePileController>.Instance.ResourcePileSelectedEvent += OnPileSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Click on a pile to destroy";
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnPileSelected(ResourcePileInstance pile)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				pile.Dispose();
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<ResourcePileController>.Instance.ResourcePileSelectedEvent -= OnPileSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
