using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandP2PPathCheck : ConsoleCommand
	{
		private Vec3Int pos1;

		private Vec3Int pos2;

		private WalkableModel model;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandP2PPathCheck()
		{
			Command = "pathCheck";
			Description = "Check reachability between two points. Takes WalkableModel blueprint ID";
			Help = "Check reachability between two points using different pathfinding methods, using humanoid traversal provider";
		}

		private void CommandMethod(string modelName)
		{
			model = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(modelName);
			if (model == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Model " + modelName + " not found");
				return;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked = true;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "Pick start point" });
			MonoSingleton<DebugInputController>.Instance.MouseDownEvent += OnMouseDown;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Command active for " + modelName);
		}

		private void OnMouseDown()
		{
			string[] layerNames = new string[4] { "VoxelMap", "BuildableSurface", "VoxelMapPathfinding", "RaycastPlaneHelper" };
			if (!RaycastUtils.RaycastMouseToSurface(out var position, LayerMask.GetMask(layerNames)))
			{
				return;
			}
			Vec3Int gridPosition = GridUtils.GetGridPosition(position, 0.01f);
			if (pos1 == Vec3Int.zero)
			{
				pos1 = gridPosition;
				MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "Pick end point" });
				return;
			}
			if (pos2 == Vec3Int.zero)
			{
				pos2 = gridPosition;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			string text = $"IsPathPossible: {PathfinderUtil.IsPathPossible(model, map, pos1, pos2)} \n";
			uint num = map.GetNode(pos1)?.Area ?? 0;
			uint num2 = map.GetNode(pos2)?.Area ?? 0;
			text += $"IsAreaReachable ({num}-{num2}): {PathfinderUtil.IsAreaReachable(model.StaticTraversalProvider, map, num, num2)} \n";
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(text);
			DamagePopup.Create(position, text);
			pos2 = Vec3Int.zero;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "Pick end point (RightClick cancel)" });
		}

		private void OnRightMouseDown()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
			MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= OnMouseDown;
			MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked = false;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
