using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnNPC : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		private string enemyId;

		private int gender;

		private Type startingBehaviourType;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnNPC()
		{
			Command = "spawnNPC";
			Description = "Spawns Humanoid on mouse click.";
			Help = "spawnNPC [blueprintId] [gender(Male=0, Female=1)] [startingBehaviourName]";
			enemyId = string.Empty;
			gender = 0;
			startingBehaviourType = null;
		}

		private void CommandMethod(string npcId, int gender, string startingBehaviourName)
		{
			if (Repository<NPCRepository, NPC>.Instance.GetByID(npcId) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown Humanoid blueprint id: " + npcId, ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnNPC;
			}
			string text = "NSMedieval.State." + startingBehaviourName;
			Type type = Type.GetType(text);
			if (type == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("S<color=red>Behaviour class '" + text + "' not found</color>", ConsoleMessageType.Error);
				return;
			}
			enemyId = npcId;
			this.gender = gender;
			startingBehaviourType = type;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {enemyId} {gender}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnNPC Mode <color=lime>activated</color>! Right click to disable", ConsoleMessageType.Warning);
		}

		private void SpawnNPC()
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
				HumanoidInstance humanoidInstance = MonoSingleton<NPCManager>.Instance.SpawnBlank(enemyId, bodyType, hit.point, villagePlace, villagePlace?.FactionInstance);
				typeof(HumanoidInstance).GetMethod("SetActiveBehaviour").MakeGenericMethod(startingBehaviourType).Invoke(humanoidInstance, new object[1] { true });
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					humanoidInstance.GetGoapAgent()?.StartTicker();
				});
				if (startingBehaviourType == typeof(EnemyBehaviour))
				{
					humanoidInstance.CombatAi.SetState(CombatAiState.NeverIdle, true);
				}
			}
		}

		private void OnRightMouseDown()
		{
			Disable();
		}

		private void Disable()
		{
			active = false;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
			MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnNPC;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnNPC Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
		}
	}
}
