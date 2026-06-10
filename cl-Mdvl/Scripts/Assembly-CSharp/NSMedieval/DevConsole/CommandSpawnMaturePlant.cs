using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnMaturePlant : ConsoleCommand
	{
		private bool active;

		private string blueprintId;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnMaturePlant()
		{
			Command = "spawnMaturePlant";
			Description = "Spawns mature plant on mouse click";
			Help = "Use this command with plant type as string argument to enable on click mature, non-stunted plant spawn";
			blueprintId = string.Empty;
		}

		private void CommandMethod(string blueprintId)
		{
			if (Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprintId) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown plant id", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnPlant;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {blueprintId}" });
			this.blueprintId = blueprintId;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPlant Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnPlant()
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprintId);
				if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
				{
					string prefabId = byID.PrefabIDs.PickRandom();
					Vector3 worldPosition = GridUtils.GetWorldPosition(GridUtils.GetGridPosition(hit.point, 0.01f));
					MonoSingleton<PlantResourceManager>.Instance.SpawnMatureNonStuntedPlantMapResource(byID.GetID(), worldPosition, prefabId, 0, domestic: false, randomPhaseHours: true);
				}
			}
		}

		private void Deactivate()
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnPlant;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPlant Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
			}
		}
	}
}
