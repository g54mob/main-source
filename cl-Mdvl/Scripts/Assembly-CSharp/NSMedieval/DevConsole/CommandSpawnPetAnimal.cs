using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnPetAnimal : ConsoleCommand
	{
		private bool active;

		private string animalId;

		private int amount;

		private Ray ray;

		private RaycastHit hit;

		private int sex;

		private int lifePhaseIndex;

		private float lifePhaseSeek;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnPetAnimal()
		{
			Command = "spawnPetAnimal";
			Description = "Spawns pet animal(s) on mouse click";
			Help = "spawnAnimal <animalId> <count> <sex:0/1> <lifePhaseIndex> <lifePhasePercent>";
			animalId = string.Empty;
		}

		private void CommandMethod(string animalId, int amount, int sex, int lifePhaseIndex, float lifePhaseSeek)
		{
			if (Repository<AnimalBaseRepository, Animal>.Instance.GetByID(animalId) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown animal id", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnAnimal;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {animalId} {amount} {this.sex} {this.lifePhaseIndex} {this.lifePhaseSeek}" });
			this.animalId = animalId;
			this.amount = amount;
			this.sex = sex;
			this.lifePhaseIndex = lifePhaseIndex;
			this.lifePhaseSeek = lifePhaseSeek;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnAnimal Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnAnimal()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				return;
			}
			for (int i = 0; i < amount; i++)
			{
				AnimalInstance animal = MonoSingleton<AnimalManager>.Instance.SpawnAnimal(animalId, hit.point, (sex == 0) ? BodyType.Male : BodyType.Female, lifePhaseIndex, lifePhaseSeek);
				animal.Stats.GetStat(StatType.AnimalWild).SetCurrent(0f);
				animal.SetAnimalType(AnimalType.Domestic);
				animal.Stats.GetStat(StatType.AnimalUntrained).SetCurrent(0f);
				animal.SetAnimalType(AnimalType.Pet);
				if (animal.HasHarvestableProduction())
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animal);
				}
				MonoSingleton<TaskController>.Instance.WaitFor(0.5f).Then(delegate
				{
					animal.GetGoapAgent()?.StartTicker();
				});
			}
		}

		private void Deactivate()
		{
			active = false;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= Deactivate;
			MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnAnimal;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnAnimal Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
		}
	}
}
