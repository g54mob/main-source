using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class AgentActionSuckBlood : AgentAction<Agent>, IGive<Crime>
	{
		private CustomerActionGetBloodSucked _humanAction;

		private LockToggle _customerBusyToggle = new LockToggle();

		private readonly bool _shouldAvoidBeingSeen;

		private Crime _createdCrime;

		private static List<Customer> availableCustomers = new List<Customer>();

		public Customer Human { get; set; }

		public float SafetyDistance { get; set; } = 5f;

		private static LayerMask SafetyMask => (1 << LayerMask.NameToLayer("Wall")) | (1 << LayerMask.NameToLayer("Floor"));

		public static event Action SuckingBlood;

		public static event Action<Agent, Customer> SuckedBlood;

		public AgentActionSuckBlood(Customer customer, bool shouldAvoidBeingSeen = false)
		{
			Human = customer;
			_shouldAvoidBeingSeen = shouldAvoidBeingSeen;
		}

		public static bool IsHumanCorrect<TCollection>(Customer customer, Agent agent, TCollection availableCustomers, float safetyDistance = 5f) where TCollection : IEnumerable<Customer>
		{
			if (agent is Customer && customer.RoomObject.CurrentRoom.NavArea == 4)
			{
				return false;
			}
			if (!customer.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (customer.Tags.HasTag(EAgentTag.Leaving))
			{
				return false;
			}
			if ((bool)customer.ControllingVampire && agent != customer.ControllingVampire)
			{
				return false;
			}
			Vector3 vector = customer.transform.position + Vector3.up;
			RoomBuilding currentRoom = customer.RoomObject.CurrentRoom;
			if (customer.ActionPlayer.HasAnyActionOfType<AgentActionLeave>() && Vector3.SqrMagnitude(vector - agent.transform.position) > 1.5f)
			{
				return false;
			}
			safetyDistance *= safetyDistance;
			foreach (Customer item in availableCustomers)
			{
				if (!(item == customer) && !(currentRoom.Container != item.RoomObject.CurrentRoom.Container))
				{
					Vector3 vector2 = item.transform.position + Vector3.up;
					if (Vector3.SqrMagnitude(vector - vector2) < safetyDistance && !Physics.Linecast(vector, vector2, SafetyMask))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!Human)
			{
				return false;
			}
			if (!Human.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (Human.IsVampire)
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (_shouldAvoidBeingSeen)
			{
				float safetyDistance = (base.IsPlaying ? (SafetyDistance - 1f) : SafetyDistance);
				CustomerManager.GetFreeHumanList(availableCustomers);
				if (!IsHumanCorrect(Human, agentRef, availableCustomers, safetyDistance))
				{
					return false;
				}
			}
			if (base.IsPlaying)
			{
				return true;
			}
			return Human.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>();
		}

		public override void OnStart()
		{
			if (Human.ContextActorData.TryGetInteractionTarget(EInteractionKey.RegularUsage, base.ActionAgent.transform.position, out var _))
			{
				_customerBusyToggle.Lock();
				_customerBusyToggle.Clear();
				_customerBusyToggle.Add(Human.Business);
				if (_humanAction == null)
				{
					_humanAction = new CustomerActionGetBloodSucked(base.ActionAgent);
				}
				Human.Animator.Events.OnBitten -= OnHumanBitten;
				Human.Animator.Events.OnBitten += OnHumanBitten;
			}
			else
			{
				CancelAction("Couldn't get regular usage point on Human target", playBlockedAction: true);
			}
		}

		private void OnHumanBitten()
		{
			Human.Animator.Events.OnBitten -= OnHumanBitten;
			if ((bool)base.ActionAgent)
			{
				base.ActionAgent.Statistics.AddToStatistic(EAgentStatistics.Hunger, 100f);
				if (Human.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Alcohol, out var statisticValue))
				{
					base.ActionAgent.Statistics.AddToStatistic(EAgentStatistics.Alcohol, statisticValue * 0.5f);
				}
				AgentActionSuckBlood.SuckedBlood?.Invoke(base.ActionAgent, Human);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToLookAt(Human.transform, 0.2f, 3f);
			SyncAction(Human, _humanAction, Priority);
			base.SyncedAction.SetWaitForCompletion(value: false);
			yield return MoveToAgent(Human, 0.2f, 2f, _humanAction);
		}

		public override IEnumerator ActionRoutine()
		{
			AgentActionSuckBlood.SuckingBlood?.Invoke();
			_createdCrime = Crime.CreateCrime(base.ActionAgent.transform.position, 1f, ECriminalActs.Hurted);
			base.ActionAgent.AddCrime(_createdCrime);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Bite, FadeMode.FromStart);
		}

		protected override void OnStopped()
		{
			Human.Animator.Events.OnBitten -= OnHumanBitten;
			if ((object)_createdCrime != null)
			{
				base.ActionAgent.RemoveCrime(_createdCrime);
				_createdCrime.DestroyCrime();
			}
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			_customerBusyToggle.Remove(Human.Business);
		}

		public override void OnCancel()
		{
		}

		Crime IGive<Crime>.Get()
		{
			return _createdCrime;
		}
	}
}
