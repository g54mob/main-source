using System;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandGenerateRaidSpawnPoints : ConsoleCommand
	{
		private int enemyCount = 10;

		private bool siege;

		private bool active;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandGenerateRaidSpawnPoints()
		{
			Command = "genRaidSpawnPoints";
			Description = "Generates raid spawn points for N enemies every time you click and visualizes them with gizmos.";
			Help = "genRaidSpawnPoints [numberOfEnemies]";
		}

		private void CommandMethod(int enemyCount, bool siege)
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<SceneController>.Instance.UnscaledTick -= OnTick;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("GenerateRaidSpawnPoints <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				this.enemyCount = Math.Max(1, enemyCount);
				this.siege = siege;
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<SceneController>.Instance.UnscaledTick += OnTick;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("GenerateRaidSpawnPoints <color=lime>activated</color>! Left click to spawn and visualize.", ConsoleMessageType.Warning);
		}

		private void OnTick(float dt)
		{
			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			WalkableModel testAgentWalkableDoorsNoWater = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoorsNoWater();
			int num = (int)((float)enemyCount * 0.7f);
			int num2 = enemyCount - num;
			int num3 = Math.Min(num, 30);
			int num4 = Math.Min(num2, 30);
			int num5 = enemyCount;
			int positionsToGet = enemyCount + num3 + num4 + num5;
			MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(testAgentWalkableDoorsNoWater, out var _, out var outStartingNodes, positionsToGet, int.MaxValue, !siege);
			if (outStartingNodes.Count == 0)
			{
				Log.Error("Failed to find spawn points", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandGenerateRaidSpawnPoints.cs");
				return;
			}
			using PooledList<MapNode> outFrontLineSpawnPoints = ListPool<MapNode>.GetJanitor();
			using PooledList<MapNode> outBackLineSpawnPoints = ListPool<MapNode>.GetJanitor();
			RaidManager.DistributeSpawnPoints(outStartingNodes, num, num2, num3, num4, outFrontLineSpawnPoints, outBackLineSpawnPoints, out var _);
			foreach (MapNode item in outStartingNodes)
			{
				_ = item;
			}
			foreach (MapNode item2 in outFrontLineSpawnPoints)
			{
				_ = item2;
			}
			foreach (MapNode item3 in outBackLineSpawnPoints)
			{
				_ = item3;
			}
			MonoSingleton<RtsCamera>.Instance.JumpTo(outStartingNodes.First().WorldPosition, snap: true);
		}

		private void OnRightMouseDown()
		{
			CommandMethod(enemyCount, siege: false);
		}
	}
}
