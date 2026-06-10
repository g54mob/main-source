using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.GameEventSystem.Events;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandThunder : ConsoleCommand
	{
		private Ray ray;

		private RaycastHit hit;

		private ThunderstormEvent debugThunderEvent;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandThunder()
		{
			Command = "thunder";
			Description = "Click to spawn a thunder (from thunderstorm).";
			Help = "Spawns a thunder on mouse click (for testing only).";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.MouseDownEvent += OnMouseDown;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Click to spawn a lightning.";
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnMouseDown()
		{
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= OnMouseDown;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
