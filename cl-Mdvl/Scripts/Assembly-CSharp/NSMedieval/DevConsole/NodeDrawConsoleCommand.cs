using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.UI;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class NodeDrawConsoleCommand : ConsoleCommand
	{
		private bool active;

		private float value;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		protected virtual void NodeOperation(MapNode node, float value)
		{
		}

		private void CommandMethod(float valueToSet)
		{
			if (active && Math.Abs(value - valueToSet) < 0.001f)
			{
				active = false;
				MonoSingleton<DebugInputController>.Instance.OnUpdateEvent -= OnTick;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(Command + " <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.OnUpdateEvent += OnTick;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {valueToSet}" });
			value = valueToSet;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(Command + " <color=lime>activated</color>! Left LShift to fill region, LShift+LCtrl to fill the whole map. Right click to disable it.", ConsoleMessageType.Warning);
		}

		private void OnRightMouseClick()
		{
			active = false;
			MonoSingleton<DebugInputController>.Instance.OnUpdateEvent -= OnTick;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}

		private void OnTick()
		{
			if (!Input.GetMouseButton(0))
			{
				return;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			MapNode node = map.GetNode(MonoSingleton<PlayerVoxelInfo>.Instance.HoverGridPosition);
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (Input.GetKey(KeyCode.LeftControl))
				{
					map.BeautyManager.WalkableIndicesSafeOperation(delegate(IEnumerable<int> nodeIndex)
					{
						foreach (int item in nodeIndex)
						{
							MapNode mapNode = map.GridSpaceData[item];
							if (mapNode != null && mapNode.IsWalkable)
							{
								NodeOperation(mapNode, value);
							}
						}
					});
				}
				else
				{
					Region region = node.Region;
					if (region != null)
					{
						foreach (MapNode node2 in region.Nodes)
						{
							if (node2 != null)
							{
								NodeOperation(node2, value);
							}
						}
					}
				}
			}
			else if (node != null)
			{
				NodeOperation(node, value);
			}
			map.Effects3dTextureManager.ScheduleDispatchComputeShader();
		}
	}
}
