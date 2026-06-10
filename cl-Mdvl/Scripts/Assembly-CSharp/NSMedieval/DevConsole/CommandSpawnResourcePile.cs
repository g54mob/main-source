using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnResourcePile : ConsoleCommand
	{
		private bool active;

		private int amount;

		private readonly HashSet<string> carcassIds = new HashSet<string> { "enemy_carcass", "human_carcass" };

		private RaycastHit hit;

		private Ray ray;

		private string resource;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnResourcePile()
		{
			Command = "spawnResource";
			Description = "Spawns resource piles on mouse click";
			Help = "Use this command with resource type as string argument to enable on click pile spawn";
			resource = string.Empty;
		}

		private void CommandMethod(string resource, int amount)
		{
			if (Repository<ResourceRepository, Resource>.Instance.GetByID(resource) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown resource type", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnPile;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {resource} {amount}" });
			this.resource = resource;
			this.amount = amount;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPile Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnPile()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(resource);
			if (!Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer) || MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(byID.BuildingBlueprintID))
			{
				return;
			}
			if (!string.IsNullOrEmpty(byID.BuildingBlueprintID))
			{
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(byID, hit.point, byID.GetID());
				return;
			}
			HumanoidInstance humanoidInstance = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.PickRandom();
			ResourceInstance resourceInstance;
			if (carcassIds.Contains(byID.GetID()))
			{
				if (byID.GetID() == "enemy_carcass")
				{
					Resource byID2 = Repository<ResourceRepository, Resource>.Instance.GetByID("enemy_carcass");
					resourceInstance = new CarcassResourceInstance(humanoidInstance, byID2, 1, "enemy")
					{
						ForbidOnInit = MonoSingleton<AnimalManager>.Instance.IsTooCloseToAggressiveAnimal(humanoidInstance.GetPosition())
					};
				}
				else
				{
					Resource byID3 = Repository<ResourceRepository, Resource>.Instance.GetByID("human_carcass");
					resourceInstance = new CarcassResourceInstance(humanoidInstance, byID3, 1, "worker")
					{
						ForbidOnInit = MonoSingleton<AnimalManager>.Instance.IsTooCloseToAggressiveAnimal(humanoidInstance.GetPosition())
					};
				}
			}
			else
			{
				resourceInstance = new ResourceInstance(byID, amount);
				resourceInstance.SetProducerUniqueId(humanoidInstance?.UniqueId ?? 0);
			}
			MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance, hit.point);
		}

		private void Deactivate()
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnPile;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPile Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
			}
		}
	}
}
