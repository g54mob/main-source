using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.DebugEvents;
using NSMedieval.Goap.Actions;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class TradeGoal : Goal
	{
		public TradeGoal(Agent selfAgent)
			: base("TradeGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(PrepareData));
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction action = GoToActions.GoToCreatureTarget(TargetIndex.A);
			action.FailIfTargetDisposed(TargetIndex.A);
			action.FailIfTargetReservationReleases(TargetIndex.A);
			action.FailAtCondition(ShouldFail);
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status != ActionCompletionStatus.Success)
				{
					DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.ActionNonSuccess);
				}
				else
				{
					DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.ActionSuccess);
					HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
					if (objectAs != null && objectAs.ActiveBehaviour is TraderBehaviour traderBehaviour)
					{
						DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.TradeGoal_OnSettlerTalkTo);
						traderBehaviour.OnSettlerTalkTo(((HumanoidInstance)base.AgentOwner).WorkerBehaviour);
					}
				}
			};
			yield return action;
		}

		private bool PrepareData()
		{
			if (!base.PreferredReservableHandler.HasTarget())
			{
				DebugEventLog.Write(new GoapDebugEvent(base.AgentOwner, GoapDebugEventCode.TradeGoal_InitFail_NoPreferredReservable));
				return false;
			}
			TargetObject target = base.PreferredReservableHandler.GetTarget();
			TraderBehaviour traderBehaviour = target.GetObjectAs<HumanoidInstance>()?.TraderBehaviour;
			if (traderBehaviour == null)
			{
				DebugEventLog.Write(new GoapDebugEvent(base.AgentOwner, GoapDebugEventCode.TradeGoal_InitFail_TargetNotTrader));
				return false;
			}
			TradingPostComponentInstance tradingPostComponentInstance = traderBehaviour.TradingPostComponentInstance;
			if (tradingPostComponentInstance != null && tradingPostComponentInstance.Underwater)
			{
				base.PreferredReservableHandler.ClearTarget();
				DebugEventLog.Write(new GoapDebugEvent(base.AgentOwner, GoapDebugEventCode.TradeGoal_InitFail_MerchantStallUnderwater));
				return false;
			}
			DebugEventLog.Write(new GoapDebugEvent(base.AgentOwner, GoapDebugEventCode.TradeGoal_InitSuccess));
			QueueTarget(TargetIndex.A, target);
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}

		private bool ShouldFail()
		{
			HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
			if (objectAs.HasDisposed || objectAs.IsOnFire || objectAs.IsLeaving)
			{
				DebugEventLog.Write(new GoapDebugEvent(base.AgentOwner, GoapDebugEventCode.TradeGoal_ShouldFailTrue_TargetInvalid));
				return true;
			}
			TradingPostComponentInstance tradingPostComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().TraderBehaviour.TradingPostComponentInstance;
			int num;
			if (tradingPostComponentInstance != null)
			{
				if (!tradingPostComponentInstance.HasDisposed && !tradingPostComponentInstance.IsOnFire)
				{
					num = (tradingPostComponentInstance.Underwater ? 1 : 0);
					if (num == 0)
					{
						goto IL_0087;
					}
				}
				else
				{
					num = 1;
				}
				DebugEventLog.Write(new GoapDebugEvent(base.AgentOwner, GoapDebugEventCode.TradeGoal_ShouldFailTrue_MerchantStallInvalid));
				goto IL_0087;
			}
			return false;
			IL_0087:
			return (byte)num != 0;
		}
	}
}
