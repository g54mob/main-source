using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;

namespace NSMedieval.Goap.Goals
{
	public class DigGoal : Goal
	{
		private HumanoidInstance humanoidOwner;

		private bool isViaPreferredReservable;

		private bool allJobsWouldEncloseRegion;

		public DigMarkerResourceInstance DigMarker { get; private set; }

		public DigGoal(Agent selfAgent)
			: base("DigGoal", selfAgent)
		{
			humanoidOwner = (HumanoidInstance)base.AgentOwner;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<DigMarkerResourceInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, TryFindDigJob));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IToolAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return base.ConstructionJobManager.HasDigJobs;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.ConstructionJobManager.ReleaseDestroyClaim(humanoidOwner);
			base.EndGoalWith(condition);
			DigMarker = null;
			isViaPreferredReservable = false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction selectNextTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			selectNextTarget.OnComplete = delegate
			{
				DigMarker = GetTarget(TargetIndex.A).GetObjectAs<DigMarkerResourceInstance>();
			};
			yield return selectNextTarget;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailAtCondition(() => FailCondition());
			GoapAction goapAction = MapResourceActions.StartObtaining(TargetIndex.A, OrderType.Digging, hideToolAtComplete: true, MapResourceActions.FailType.FailGoal, !isViaPreferredReservable, allJobsWouldEncloseRegion);
			goapAction.OnInit = delegate
			{
				string miningTool = GetTarget(TargetIndex.A).GetObjectAs<DigMarkerResourceInstance>().Blueprint.MiningTool;
				((IToolAgent)base.AgentOwner).SetTool(miningTool);
			};
			goapAction.FailAtCondition(() => FailCondition(doExpensiveChecks: true));
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				((IToolAgent)base.AgentOwner).HideTool();
				if (status == ActionCompletionStatus.Fail && base.State != GoalState.Ended && humanoidOwner.IsWorker())
				{
					humanoidOwner.WorkerBehaviour.WorkerProximity.OnDiggingFailed();
				}
			};
			goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction.TriggerAnimation("Mining", ActionAnimationMode.Interrupt);
			yield return goapAction;
			yield return MapResourceActions.SpawnHarvestedResources(TargetIndex.A, OrderType.Digging);
			yield return JumpActions.JumpIfHaveTargetsInQueue(selectNextTarget, TargetIndex.A);
		}

		private bool FailCondition(bool doExpensiveChecks = false)
		{
			DigMarkerResourceInstance digMarker = DigMarker;
			if (digMarker == null || digMarker.HasDisposed)
			{
				return true;
			}
			if (digMarker.IsOnFire)
			{
				return true;
			}
			if (digMarker.FactionOwnership == FactionOwnership.Enemy)
			{
				return true;
			}
			WaterDepthLevel waterDepthLevel = digMarker.WaterDepthLevel;
			if (waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High)
			{
				return true;
			}
			if (doExpensiveChecks)
			{
				MapNode node = DigMarker.GetNode();
				MapNode node2 = humanoidOwner.GetNode();
				if (node != node2 && node.CreaturesCount > 0 && humanoidOwner.Map.CreaturesOnNodes.TryGetValue(node.Index, out var value))
				{
					foreach (CreatureBase item in value)
					{
						Goal goal = item?.GoapAgent?.GetCurrentGoal();
						if (goal != null)
						{
							if (goal is DeconstructGoal { TargetBuilding: not null } deconstructGoal && deconstructGoal.TargetBuilding.GetNode() == node2 && humanoidOwner.UniqueId < item.UniqueId)
							{
								return true;
							}
							if (goal is DigGoal { DigMarker: not null } digGoal && digGoal.DigMarker.GetNode() == node2 && humanoidOwner.UniqueId < item.UniqueId)
							{
								return true;
							}
						}
					}
				}
				if (!isViaPreferredReservable)
				{
					MapNode node3 = digMarker.GetNode()?.GetNodeBelow();
					if (!allJobsWouldEncloseRegion && base.ConstructionJobManager.WouldDestroyJobEncloseRegion(node3))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool TryFindDigJob()
		{
			DigMarker = null;
			isViaPreferredReservable = false;
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			ClearTargetsQueue(TargetIndex.A);
			if (base.PreferredReservableHandler.HasTarget())
			{
				isViaPreferredReservable = true;
				List<WorldObject> targets = new List<WorldObject> { base.PreferredReservableHandler.GetTarget().GetAsReservable() as WorldObject };
				List<TargetObject> list = PathfinderMedieval.FindMedievalObjects<DigMarkerResourceInstance>(pathfindingAgent, targets);
				if (list != null && list.Count > 0)
				{
					TargetObject target = list.First();
					DigMarkerResourceInstance objectAs = target.GetObjectAs<DigMarkerResourceInstance>();
					if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
					{
						DigMarker = objectAs;
						QueueTarget(TargetIndex.A, target);
						return true;
					}
					base.PreferredReservableHandler.ClearTarget();
				}
			}
			if (!base.ConstructionJobManager.TryReserveDigJob(humanoidOwner, out var outJobs, out allJobsWouldEncloseRegion))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\DigGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No jobs ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				outJobs.Dispose();
				return false;
			}
			foreach (var item3 in outJobs)
			{
				DestroyVoxelJob item = item3.Item1;
				Vec3Int item2 = item3.Item2;
				DigMarkerResourceInstance digMarker = MonoSingleton<DigMarkerResourceManager>.Instance.GetDigMarker(item.DigMarkerPosition);
				QueueTarget(TargetIndex.A, new TargetObject(digMarker, item2));
			}
			outJobs.Dispose();
			return true;
		}
	}
}
