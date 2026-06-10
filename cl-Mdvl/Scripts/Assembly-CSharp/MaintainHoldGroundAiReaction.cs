using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

public class MaintainHoldGroundAiReaction : CombatAiReaction
{
	protected virtual float MaxDistanceFromHoldVoxel => 3f;

	public MaintainHoldGroundAiReaction(CombatAiAgent agent)
		: base(agent)
	{
	}

	public override void OnEnable()
	{
		if (base.CombatAgent?.PathDriver != null)
		{
			base.CombatAgent.PathDriver.OnStartTraversingPathEvent += OnStartTraversingPath;
		}
	}

	public override void OnDisable()
	{
		if (base.CombatAgent?.PathDriver != null)
		{
			base.CombatAgent.PathDriver.OnStartTraversingPathEvent -= OnStartTraversingPath;
		}
	}

	internal override void CombatTick()
	{
		using (ProfilerSampleJanitor.Begin("MaintainHoldGroundAiReaction::CombatTick"))
		{
			if (CombatUtils.GetAttackType(base.CombatAgent) != AttackType.Melee && base.CombatAgent.HasActivePath)
			{
				base.CombatAgent.PathDriver.Abort();
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.CombatAgent);
				return;
			}
			IDamageTakingAgent state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			Vec3Int lhs = base.CombatAi.GetState<Vec3Int>(CombatAiState.HoldGroundGridPosition);
			bool isEnabled;
			if (state == null || state.HasDisposed)
			{
				if (!base.CombatAgent.HasActivePath && lhs != default(Vec3Int) && lhs.Distance(base.CombatAgent.GetGridPosition()) > 0.25f)
				{
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(39, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\MaintainHoldGroundAiReaction.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(base.CombatAgent);
						messageBuilder.AppendLiteral(" returning to hold ground origin point ");
						messageBuilder.AppendFormatted(lhs);
					}
					Log.Debug(messageBuilder);
					GoToPoint(lhs);
				}
				return;
			}
			Vec3Int gridPosition = base.CombatAgent.GetGridPosition();
			Vec3Int other = state.GetGridPosition();
			bool flag = !CombatUtils.IsInAttackRange(base.CombatAgent, state) && gridPosition.y != other.y;
			if (!flag)
			{
				float num = Mathf.Max(CombatUtils.GetRange(base.CombatAgent, state), MaxDistanceFromHoldVoxel);
				flag = lhs.Distance(state.GetGridPosition()) > num;
			}
			if (flag)
			{
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(86, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\MaintainHoldGroundAiReaction.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Removing target because it is outside of max hold ground range (d=");
					messageBuilder2.AppendFormatted(gridPosition.Distance(in other), "F2");
					messageBuilder2.AppendLiteral("), target: ");
					messageBuilder2.AppendFormatted(state);
					messageBuilder2.AppendLiteral(", agent: ");
					messageBuilder2.AppendFormatted(base.CombatAgent);
				}
				Log.Trace(messageBuilder2);
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.CombatAgent);
			}
		}
	}

	private void OnStartTraversingPath(PathfinderAgentDriver obj)
	{
		if (PathGoesOutsideOfRadius())
		{
			Log.Trace("Removing target because path would venture outside of max hold ground range", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\MaintainHoldGroundAiReaction.cs");
			MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.CombatAgent);
			base.CombatAgent.PathDriver.Abort();
		}
	}

	private bool PathGoesOutsideOfRadius()
	{
		Vec3Int rhs = base.CombatAi.GetState<Vec3Int>(CombatAiState.HoldGroundGridPosition);
		if (!base.CombatAgent.HasActivePath || base.CombatAgent.PathDriver.FinalDestination == rhs)
		{
			return false;
		}
		foreach (MapNode item in base.CombatAgent.PathDriver.CurrentPath.NodePath)
		{
			if (rhs.Distance(item.Position) > MaxDistanceFromHoldVoxel)
			{
				return true;
			}
		}
		return false;
	}

	private void GoToPoint(Vec3Int targetPosition)
	{
		PathfinderAgentDriver pathfinderAgentDriver = base.CombatAgent?.PathDriver;
		if (pathfinderAgentDriver == null)
		{
			return;
		}
		P2PPath path = P2PPath.Construct(pathfinderAgentDriver.Agent, targetPosition);
		pathfinderAgentDriver.ExecutePath(new PathfinderDriverExecCfg
		{
			Path = path,
			StatusCb = delegate(bool result)
			{
				if (!result && base.CombatAgent is HumanoidInstance { ActiveBehaviour: WorkerBehaviour activeBehaviour })
				{
					Log.Warning("Could not process return to hold ground origin point pathfinder request.", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\MaintainHoldGroundAiReaction.cs");
					if (base.CombatAgent != null && !base.CombatAgent.HasDisposed && !base.CombatAgent.HasDied && activeBehaviour.IsDrafting)
					{
						bool isEnabled;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(88, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\MaintainHoldGroundAiReaction.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(activeBehaviour);
							messageBuilder.AppendLiteral(" turning off HoldGround stance because the agent failed to path back to the origin point");
						}
						Log.Debug(messageBuilder);
						activeBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
					}
				}
			}
		});
	}
}
