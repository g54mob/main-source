using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Managers;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnFish : ConsoleCommand
	{
		private bool active;

		private string blueprintId;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnFish()
		{
			Command = "spawnFish";
			Description = "Spawns fish on mouse click";
			Help = "Spawns fish resource. Only works on water.";
		}

		private void CommandMethod(string blueprintId)
		{
			if (Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(blueprintId) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown fish id", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnFish;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {blueprintId}" });
			this.blueprintId = blueprintId;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPlant Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnFish()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			FishMapResource byID = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(blueprintId);
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				string prefabId = byID.PrefabIDs.PickRandom();
				Vec3Int gridPosition = GridUtils.GetGridPosition(hit.point, 0.01f);
				if (!VillageManager.ActiveVillage.Map.WaterManager.IsWaterAt(gridPosition))
				{
					Debug.LogError("No water at clicked position");
				}
				else
				{
					MonoSingleton<FishResourceManager>.Instance.SpawnFishMapResource(byID.GetID(), GridUtils.GetWorldPosition(gridPosition), prefabId);
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
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnFish;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnFish Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
			}
		}
	}
}
