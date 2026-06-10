using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.View;
using NSMedieval.Village.Map;

public class PrisonerEscapeGoal : Goal
{
	private const float EscapeAttemptCooldownHours = 0.5f;

	private PrisonerBehaviour prisoner;

	private readonly TimeInterval escapeAttemptCooldown;

	private PrisonerBehaviour Prisoner => prisoner ?? (prisoner = (base.AgentOwner as HumanoidInstance)?.PrisonerBehaviour);

	private HumanoidInstance HumanoidOwner => Prisoner?.Humanoid;

	public PrisonerEscapeGoal(Agent selfAgent)
		: base("PrisonerEscapeGoal", selfAgent, GoalInterruptMode.HigherPriority)
	{
		escapeAttemptCooldown = TimeInterval.FromNowMinutes(0);
		AddInitStep(new ThreadSequenceStep(null, FindRetreatNode));
	}

	public override bool CanStart(bool isForced = false)
	{
		if (HumanoidOwner.HasFainted || HumanoidOwner.IsSleeping)
		{
			return false;
		}
		if (!HumanoidOwner.IsCaptive())
		{
			return false;
		}
		if (!escapeAttemptCooldown.HasEnded)
		{
			return false;
		}
		if (Prisoner.Humanoid.RopedTo() == null && !Prisoner.Shackled && !Prisoner.IsEscaping)
		{
			return Prisoner.GoapAgent?.CurrentGoalName != "PrisonerSurrenderGoal";
		}
		return false;
	}

	public override bool AgentTypeCheck()
	{
		return Prisoner != null;
	}

	public override void EndGoalWith(GoalCondition condition)
	{
		base.EndGoalWith(condition);
		HumanoidInstance obj = (HumanoidInstance)base.AgentOwner;
		obj.SetWalkableModel(obj.CurrentHumanType.WalkableModelFriendly);
	}

	protected override IEnumerable<GoapAction> GetNextAction()
	{
		GoapAction goapAction = new GoapAction("SetStateAction");
		goapAction.OnInit = delegate
		{
			Prisoner.IsEscaping = true;
			escapeAttemptCooldown.ResetFromNowMinutes((int)((float)Goal.DateTime.MinutesInHour * 0.5f));
		};
		yield return goapAction;
		GoapAction goapAction2 = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
		goapAction2.OnInit = delegate
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("bbt_prisoner_run", HumanoidOwner);
			MonoSingleton<BlackBarMessageController>.Instance?.ShowClickableBlackBarMessage(text, HumanoidOwner.GetAgentView<HumanoidView>());
		};
		goapAction2.OnComplete = delegate(ActionCompletionStatus status)
		{
			if (status != ActionCompletionStatus.Success && Prisoner != null)
			{
				Prisoner.IsEscaping = false;
			}
		};
		yield return goapAction2.FailAtCondition(delegate
		{
			PrisonerBehaviour prisonerBehaviour = Prisoner;
			return prisonerBehaviour != null && !prisonerBehaviour.IsEscaping;
		});
		yield return new GoapAction("LeftMap")
		{
			OnInit = delegate
			{
				HumanoidOwner?.DestroyStorage();
				HumanoidOwner?.DestroyEquipment();
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (HumanoidOwner != null)
					{
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Prisoners\\PrisonerEscapeGoal.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Prisoner has escaped ");
							messageBuilder.AppendFormatted(base.AgentOwner);
						}
						Log.Info(messageBuilder);
						MonoSingleton<NPCController>.Instance.RemoveNPC(HumanoidOwner);
						string text = MonoSingleton<LocalizationController>.Instance.GetText("bbt_prisoner_gone", HumanoidOwner);
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
					}
				});
			}
		};
	}

	private bool FindRetreatNode()
	{
		if (!MonoSingleton<NPCStartPositionManager>.IsInstantiated())
		{
			return false;
		}
		IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
		((HumanoidInstance)obj).SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("prisoner_escape_01"));
		MapNode closestReachableEdgeNode = NPCStartPositionManager.GetClosestReachableEdgeNode(obj);
		HumanoidOwner?.CombatAi.SetState(CombatAiState.StuckWhileRetreating, closestReachableEdgeNode == null);
		if (closestReachableEdgeNode != null)
		{
			SetTarget(TargetIndex.A, new TargetObject(closestReachableEdgeNode.Position));
			return true;
		}
		return false;
	}
}
