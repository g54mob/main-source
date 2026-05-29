using System;
using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentActionEnterBar : AgentAction<Agent>
	{
		private Vector3 _entrancePoint;

		private LockToggle _statisticsToggle;

		private bool _forceEnter;

		public static event Action<Agent> AgentEnteredBar;

		public AgentActionEnterBar(bool forceEnter = false)
		{
			base.CanPlayBlockedAction = false;
			_forceEnter = forceEnter;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			_statisticsToggle = new LockToggle(base.ActionAgent.Statistics);
			_statisticsToggle.Lock();
			if (base.ActionAgent is Customer customer)
			{
				_entrancePoint = EntranceResolver.GetEntrancePoint(base.ActionAgent.transform.position, customer.IsVampire ? customer.VampireRandomMovementAreaMask : customer.HumanRandomMovementAreaMask);
			}
			else
			{
				_entrancePoint = EntranceResolver.GetEntrancePoint(base.ActionAgent.transform.position, base.ActionAgent.RandomMovementMask);
			}
			if (_entrancePoint == Vector3.zero)
			{
				CancelAction("couldn't find entrance point", playBlockedAction: true);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public static bool CanCustomerGroupEnterBar(bool isVampire)
		{
			if (!CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				return false;
			}
			if (isVampire)
			{
				if (CTSSingleton<CustomerSpawner>.Instance.CurrentHumanVampireRatio < 1f)
				{
					return false;
				}
			}
			else if (CTSSingleton<CustomerSpawner>.Instance.CurrentHumanVampireRatio >= 1f)
			{
				return false;
			}
			return true;
		}

		public override IEnumerator ActionRoutine()
		{
			if (base.ActionAgent is Customer p_customer)
			{
				CustomerManager.AddCustomer(p_customer);
			}
			PathingTracker movement = MoveToPosition(_entrancePoint);
			yield return null;
			while (movement.Status == PathingTracker.EStatus.InProgress)
			{
				if (!_forceEnter && !CTSSingleton<LevelParameters>.Instance.IsOpen)
				{
					base.ActionAgent.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
					yield break;
				}
				yield return null;
			}
			base.ActionAgent.UpdateLighting(0f);
			if (movement.Status == PathingTracker.EStatus.Failed)
			{
				if (base.ActionAgent is Customer)
				{
					base.ActionAgent.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
				}
				yield break;
			}
			if (base.ActionAgent.RoomObject.CurrentRoom.IsExterior())
			{
				base.ActionAgent.RoomObject.TryFindCurrentRoom();
			}
			if (!base.ActionAgent.RoomObject.CurrentRoom.IsExterior())
			{
				base.ActionAgent.SetEnterBarTag();
				base.ActionAgent.Selection.Selectable = true;
				AgentActionEnterBar.AgentEnteredBar?.Invoke(base.ActionAgent);
				if (base.ActionAgent.TryGetComponent<SituationnalBarks>(out var component))
				{
					component.EnterBar();
				}
			}
		}

		public override void OnComplete()
		{
			base.OnComplete();
			_statisticsToggle.Unlock();
			base.ActionAgent.SetEnterBarTag();
			base.ActionAgent.Selection.Selectable = true;
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
