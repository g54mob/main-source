using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
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
	public class CommandSpawnPlant : ConsoleCommand
	{
		private bool active;

		private string blueprintId;

		private string phaseName;

		private int phaseIndex;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnPlant()
		{
			Command = "spawnPlant";
			Description = "Spawns plant on mouse click";
			Help = "spawnPlant <id> <phaseName> - you can find id and phase name in PlantMapResource.json";
			blueprintId = string.Empty;
		}

		private void CommandMethod(string blueprintId)
		{
			CommandMethod(blueprintId, null);
		}

		private void CommandMethod(string blueprintId, string phaseName)
		{
			PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown plant id.", ConsoleMessageType.Warning);
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Available plant ids: " + string.Join(", ", Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetAllItems()));
				return;
			}
			if (phaseName == null)
			{
				phaseName = byID.LifePhases[0].PhaseName;
			}
			this.phaseName = phaseName;
			phaseIndex = -1;
			for (int i = 0; i < byID.LifePhases.Count; i++)
			{
				PlantLifePhases plantLifePhases = byID.LifePhases[i];
				if (string.Compare(this.phaseName, plantLifePhases.PhaseName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					phaseIndex = i;
					break;
				}
			}
			if (phaseIndex == -1)
			{
				phaseIndex = 0;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Phase '" + phaseName + "' not found. Possible phases are: " + string.Join(", ", byID.LifePhases) + ".\nUsing the first one: " + byID.LifePhases[0].PhaseName);
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnPlant;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " " + blueprintId + " " + phaseName });
			this.blueprintId = blueprintId;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPlant Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnPlant()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprintId);
				string text = byID.PrefabIDs.PickRandom();
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(47, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandSpawnPlant.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Spawning plant ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" in phase ");
					messageBuilder.AppendFormatted(phaseName);
					messageBuilder.AppendLiteral(", random prefab id is ");
					messageBuilder.AppendFormatted(text);
				}
				Log.Info(messageBuilder);
				Vector3 worldPosition = GridUtils.GetWorldPosition(GridUtils.GetGridPosition(hit.point, 0.01f));
				MonoSingleton<PlantResourceManager>.Instance.SpawnPlantMapResource(byID.GetID(), worldPosition, text, phaseIndex, domestic: false, randomPhaseHours: false).SetPhaseProgress(0.5f);
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
