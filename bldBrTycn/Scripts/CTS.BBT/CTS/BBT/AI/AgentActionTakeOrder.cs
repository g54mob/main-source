using System;
using System.Collections;
using Animancer;
using CTS.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentActionTakeOrder : AgentAction<Agent>
	{
		private readonly Customer _customer;

		private MoveTarget _moveTarget;

		private readonly LockToggle _customerBusyToggle;

		private CustomerActionOrder _customerAction;

		private static StringKey _satisfactionSuccessKey = "TakeOrderCharismaSuccess";

		private static StringKey _satisfactionFailureKey = "TakeOrderCharismaFailure";

		public static event Action<Agent> TakingOrder;

		public static event Action<Agent> OrderTaken;

		public static event Action<Agent> OrderCanceledDueToNoStock;

		public static event Action<SatisfactionEvent> SatisfactionTriggered;

		internal AgentActionTakeOrder(Customer customer)
		{
			_customer = customer;
			_customerBusyToggle = new LockToggle(_customer.Business);
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!_customer.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (!base.IsPlaying)
			{
				if (_customer.Business.IsLocked)
				{
					return false;
				}
				if (!_customer.GroupData.AssignedTable.ContextActorData.AreInteractionTargetsAvailable(EInteractionKey.RegularUsage, agentRef))
				{
					return false;
				}
			}
			return _customer.AtTable;
		}

		public override void OnStart()
		{
			_customerBusyToggle.Lock();
			if (!_customer.GroupData.AssignedTable.ContextActorData.TryGetInteractionTarget(EInteractionKey.RegularUsage, base.ActionAgent.transform.position, out _moveTarget))
			{
				CancelAction("Couldn't get regular target on table", playBlockedAction: true);
				return;
			}
			if (_customerAction == null)
			{
				_customerAction = new CustomerActionOrder(base.ActionAgent);
			}
			SyncAction(_customer, _customerAction, Priority);
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!base.ActionAgent.Movement.CheckDestination(_moveTarget))
			{
				ResetAnimation(base.ActionAgent);
				yield return MoveToTarget(_moveTarget);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			AgentActionTakeOrder.TakingOrder?.Invoke(_customer);
			Guid groupGuid = _customer.GroupData.Index;
			if ((int)base.ActionAgent.Animator.CurrentIdle != (int)AgentAnim.NoteIdle)
			{
				base.ActionAgent.Tools.OnUseTool(3);
				base.ActionAgent.Tools.OnUseTool(4);
				base.ActionAgent.Animator.SetIdle(AgentAnim.NoteIdle);
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.NoteStart);
			}
			else
			{
				yield return new WaitForSeconds(0.5f);
			}
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Note, FadeMode.FromStart);
			if (groupGuid != _customer.GroupData.Index)
			{
				_customer.ClearOrder();
				yield break;
			}
			if (_customer.CurrentOrder == null)
			{
				_customer.ClearOrder();
				yield break;
			}
			DrinkSO outDrink;
			EOrderResult eOrderResult = _customer.TryGetDrink(out outDrink);
			if (eOrderResult == EOrderResult.None)
			{
				_customer.Tags.AddTag(EAgentTag.Angry);
				_customer.ClearOrder();
				AgentActionTakeOrder.OrderCanceledDueToNoStock?.Invoke(_customer);
			}
			else
			{
				_ = (bool)outDrink;
				_customer.CurrentOrder.Setup(outDrink, eOrderResult);
			}
			if (!(base.ActionAgent is Worker worker))
			{
				yield break;
			}
			int charismaCheck = worker.GetCharismaCheck();
			if (charismaCheck != 0)
			{
				if (charismaCheck > 0)
				{
					_customer.Satisfaction.AddFlatValue(_satisfactionSuccessKey);
					AgentActionTakeOrder.SatisfactionTriggered?.Invoke(new SatisfactionEvent(_customer, isGood: true));
				}
				else
				{
					_customer.Satisfaction.AddFlatValue(_satisfactionFailureKey);
					AgentActionTakeOrder.SatisfactionTriggered?.Invoke(new SatisfactionEvent(_customer, isGood: false));
				}
			}
		}

		protected override void OnStopped()
		{
			AgentActionTakeOrder.OrderTaken?.Invoke(_customer);
			_customerBusyToggle?.Unlock();
			foreach (AgentAction item in base.ActionAgent.ActionPlayer.ActionQueue)
			{
				if (item is WorkerChoreHub { Action: ActionHubGroupOrder action } && action.CurrentAction == this)
				{
					return;
				}
			}
			ResetAnimation(base.ActionAgent);
		}

		public override void OnCancel()
		{
		}

		public static void ResetAnimation(Agent agent)
		{
			if ((int)agent.Animator.CurrentIdle == (int)AgentAnim.NoteIdle)
			{
				agent.Tools.DisableTools();
				agent.Animator.SetIdleAndPlay(AgentAnim.Idle);
				agent.Animator.PlayPunctual(AgentAnim.NoteEnd);
			}
		}
	}
}
