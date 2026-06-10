using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnEnemy : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		private string enemyId;

		private int gender;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnEnemy()
		{
			Command = "spawnEnemy";
			Description = "Spawns enemy on mouse click.";
			Help = "Use this command to spawn enemy.";
			enemyId = string.Empty;
			gender = 0;
		}

		private void CommandMethod(string enemyId, int gender)
		{
			if (Repository<NPCRepository, NPC>.Instance.GetByID(enemyId) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown enemy id: " + enemyId, ConsoleMessageType.Error);
				return;
			}
			if (this.enemyId.Equals(enemyId) && active)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnEnemy;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnEnemy Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnEnemy;
			}
			this.enemyId = enemyId;
			this.gender = gender;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {this.enemyId} {gender}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnEnemy Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnEnemy()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			int layerMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("BuildingWalkable")) | (1 << LayerMask.NameToLayer("RaycastPlaneHelper")) | (1 << LayerMask.NameToLayer("VoxelMapPathfinding"));
			VillagePlace villagePlace = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePlaces[0];
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask))
			{
				BodyType bodyType = ((gender == 0) ? BodyType.Male : BodyType.Female);
				HumanoidInstance enemyInstance = MonoSingleton<NPCManager>.Instance.SpawnEnemy(enemyId, bodyType, hit.point, villagePlace, villagePlace.FactionInstance);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					enemyInstance.GetGoapAgent()?.StartTicker();
				});
			}
		}

		private void OnRightMouseDown()
		{
			CommandMethod(enemyId, gender);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(enemyId, gender);
		}
	}
}
