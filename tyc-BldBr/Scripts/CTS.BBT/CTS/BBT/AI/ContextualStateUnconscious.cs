using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal class ContextualStateUnconscious : ContextualState, IUpdatable
	{
		private readonly float _duration;

		private readonly bool _shouldPanic;

		private float _endTime;

		private Crime _crime;

		private int _humanCredibility;

		private AgentActionGetUp _getUpAction;

		public ContextualStateUnconscious(float p_duration, bool shouldPanic)
			: base(0f)
		{
			_duration = p_duration;
			_shouldPanic = shouldPanic;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			UpdateSpreader.AddUpdate(this);
			if (base.parent is Customer customer)
			{
				customer.CrimeWitness.enabled = false;
				customer.ClearOrder();
				customer.ContextActorData.ClearAssociatedChores();
				_humanCredibility = customer.Credibility;
			}
			base.parent.ActionPlayer.ClearActionQueue();
			if (_shouldPanic)
			{
				_crime = Crime.CreateCrime(base.parent.transform.position, 1f, ECriminalActs.BodyFound, _humanCredibility, base.parent.transform);
			}
			ResetTimer();
		}

		public virtual void OnUpdate()
		{
			if (!IsTimerOver())
			{
				return;
			}
			if (base.parent.Tags.HasTag(EAgentTag.Restrained))
			{
				base.fsm.SetState<ContextualStateStuck>();
			}
			else if (!base.parent.Tags.HasTag(EAgentTag.IsUnconscious))
			{
				AgentActionGetUp getUpAction = _getUpAction;
				if (getUpAction != null && getUpAction.Status >= AgentAction.EStatus.Completed)
				{
					if (_shouldPanic)
					{
						base.parent.ContextualFSM.SetStatePanicking();
					}
					else
					{
						base.parent.ContextualFSM.SetStateNormal();
					}
				}
			}
			else if (_getUpAction == null)
			{
				_getUpAction = new AgentActionGetUp();
				base.parent.ActionPlayer.PlayInstantly(_getUpAction);
			}
		}

		public override void OnStateExit()
		{
			UpdateSpreader.RemoveUpdate(this);
			if (base.parent is Customer customer)
			{
				customer.CrimeWitness.enabled = true;
			}
			if ((bool)_crime)
			{
				_crime.DestroyCrime();
				_crime = null;
			}
		}

		public void ResetTimer()
		{
			_endTime = Time.time + _duration;
		}

		public bool IsTimerOver()
		{
			if (_duration >= 0f)
			{
				return Time.time >= _endTime;
			}
			return false;
		}
	}
}
