using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class BanishGoal : Goal
	{
		private bool foundPath;

		public BanishGoal(Agent selfAgent)
			: base("BanishGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(OnStart, PrepareData, OnFinishCheckSuccess));
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				return humanoidInstance.WorkerBehaviour != null;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction action = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch);
			yield return JumpActions.JumpIfNoTargetSelected(action, TargetIndex.A);
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, (int)Random.Range(3f, 10f)).FailIfTargetDisposedOrNull(TargetIndex.A);
			yield return action;
			yield return new GoapAction("DestroyWorker")
			{
				OnInit = delegate
				{
					HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
					humanoidInstance.GetStorage()?.ClearAll();
					MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
					{
						if (humanoidInstance != null)
						{
							humanoidInstance.DontSpawnCarcassOnDispose = true;
							MonoSingleton<WorkerController>.Instance.RemoveWorker(humanoidInstance);
						}
					});
					MonoSingleton<MiscLogManager>.Instance.LogBanish(humanoidInstance);
				}
			};
		}

		private bool OnStart()
		{
			return ((HumanoidInstance)base.AgentOwner).WorkerBehaviour.IsBanished;
		}

		private bool PrepareData()
		{
			List<TargetObject> list = PathfinderResourcePile.FindCategoryPiles((HumanoidInstance)base.AgentOwner, ResourceCategory.CtgEdible, null, includeForbiden: true);
			if (list != null && list.Count != 0)
			{
				TargetObject target = list.FirstOrDefault((TargetObject item) => (item.GetObjectAs<ResourcePileInstance>().Blueprint.Category & ResourceCategory.CtgMeal) != 0);
				if (!target.IsInitialized)
				{
					target = list.PickRandom();
				}
				QueueTarget(TargetIndex.A, target);
			}
			ReserveTargets();
			return true;
		}

		private bool ReserveTargets()
		{
			HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
			List<MapNode> nodesNearEdge = NPCStartPositionManager.GetNodesNearEdge(16, NPCStartPositionManager.CompareNodeDistanceToEdges, skipUnderwaterNodes: true);
			Vec3Int workerGridPosition = humanoid.GetGridPosition();
			MapNode mapNode = nodesNearEdge.FirstOrDefault((MapNode item) => PathfinderUtil.IsPathPossible(humanoid.WalkableModel, item, workerGridPosition));
			foundPath = mapNode != null;
			if (mapNode == null)
			{
				Log.Warning("Humanoid can not leave. Located in space isolated from the map edge.", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\BanishGoal.cs");
				return false;
			}
			QueueTarget(TargetIndex.B, new TargetObject(mapNode.Position));
			SelectNextTarget(TargetIndex.B);
			if (GetTargetQueue(TargetIndex.A).Count != 0)
			{
				return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
			}
			return true;
		}

		private bool OnFinishCheckSuccess()
		{
			if (!foundPath)
			{
				((HumanoidInstance)base.AgentOwner)?.WorkerBehaviour.CannotBanish();
				return false;
			}
			return true;
		}
	}
}
