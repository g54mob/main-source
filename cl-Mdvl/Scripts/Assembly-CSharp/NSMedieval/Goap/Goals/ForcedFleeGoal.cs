using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class ForcedFleeGoal : Goal
	{
		private WalkableModel walkableModelCache;

		public ForcedFleeGoal(Agent selfAgent)
			: base("ForcedFleeGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(() => true));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IDamageTakingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return ((IDamageDealAgent)base.AgentOwner).CombatAi?.GetState<bool>(CombatAiState.IsFleeing) ?? false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ForcedFleeGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Goal ended: ");
				messageBuilder.AppendFormatted(condition);
			}
			Log.Debug(messageBuilder);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				base.Agent?.DelayNextTick(1f);
			});
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.FleeFromEnemy(Random.Range(15f, 29f));
			goapAction.OnPreInit = delegate
			{
				walkableModelCache = GetAnimalInstance().WalkableModel;
				GetAnimalInstance().SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(GetAnimalInstance().Blueprint.ForcedFleeWalkableModel));
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ForcedFleeGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("fleeAction init cached ");
					messageBuilder.AppendFormatted(walkableModelCache);
					messageBuilder.AppendLiteral(" current: ");
					messageBuilder.AppendFormatted(GetAnimalInstance().WalkableModel);
					messageBuilder.AppendLiteral(" ");
				}
				Log.Debug(messageBuilder);
			};
			goapAction.OnInit = delegate
			{
				MonoSingleton<CombatController>.Instance.OnFleeStart(base.AgentOwner as IDamageCommonAgent);
			};
			goapAction.OnComplete = delegate
			{
				Log.Debug("fleeAction complete", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ForcedFleeGoal.cs");
				if (base.AgentOwner != null && !base.AgentOwner.HasDisposed)
				{
					GetAnimalInstance().SetWalkableModel(walkableModelCache);
					MonoSingleton<CombatController>.Instance.OnFleeStop(base.AgentOwner as IDamageCommonAgent);
				}
			};
			goapAction.WithPopupText(TargetIndex.None, MonoSingleton<LocalizationController>.Instance.GetText("running_away"), ColorUtils.GetColor("green"));
			goapAction.WithMovementSpeedMultiplier((base.AgentOwner is AnimalInstance) ? 1.4f : 1.1f);
			yield return goapAction;
		}

		private AnimalInstance GetAnimalInstance()
		{
			if (base.AgentOwner is AnimalInstance result)
			{
				return result;
			}
			throw new MissingReferenceException("Agent is not AnimalInstance");
		}
	}
}
