using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDrawEffectMap : ConsoleCommand
	{
		private bool active;

		private int amount;

		private float value;

		private Ray ray;

		private RaycastHit hit;

		private Vector3 start;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandDrawEffectMap()
		{
			Command = "drawEffectMap";
			Description = "Draws in effect map.";
			Help = "Draws in effect mask. Usage: drawEffectMap <channel> <value> Channel should be in range 0-15, value should be in 0-1.";
		}

		private void CommandMethod(int amount, float value)
		{
			start = Vector3.zero;
			if (active && this.amount == amount && this.value == value)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= OnMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseDownTickEvent -= OnMouseDownTick;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= OnMouseUp;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("DrawEffectMap Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += OnMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseDownTickEvent += OnMouseDownTick;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += OnMouseUp;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command} {amount} {value}" });
			this.amount = amount;
			this.value = value;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("DrawEffectMap Mode <color=lime>activated</color>!", ConsoleMessageType.Warning);
		}

		private void OnMouseDownTick(float dt)
		{
		}

		private void OnMouseUp()
		{
		}

		private void OnMouseDown()
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
				{
					start = hit.point;
				}
			}
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(amount, value);
		}

		private void OnRightMouseDown()
		{
			CommandMethod(amount, value);
		}
	}
}
