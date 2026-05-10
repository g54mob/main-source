using System;
using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentActionSlipOnPuddle : AgentAction<Agent>
	{
		private static readonly StringKey _satisfactionKey = "SlippedOnPuddle";

		public AgentAction ResumeAction { get; set; }

		public static event Action<Agent> SlippingOnPuddle;

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			yield return SlipRoutine();
			if ((bool)base.ActionAgent.Satisfaction)
			{
				base.ActionAgent.Satisfaction.AddFlatValue(_satisfactionKey);
			}
			if (base.ActionAgent is Customer { Credibility: >15 })
			{
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SlipScared);
			}
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SlipGetUp);
			if (ResumeAction != null && base.ActionAgent.ActionPlayer.HasAction(ResumeAction) && !ResumeAction.CanBePerformed(base.ActionAgent))
			{
				ResumeAction.ForceCancelAction();
			}
		}

		private void AttemptDropItem()
		{
			if (base.ActionAgent.ObjectHolding.IsCurrentlyHolding && NavMesh.SamplePosition(base.ActionAgent.transform.position + base.ActionAgent.transform.forward, out var hit, 1.5f, AgentsMover.AllAreas))
			{
				Item currentHeld = base.ActionAgent.ObjectHolding.CurrentHeld;
				base.ActionAgent.ObjectHolding.DropObject();
				currentHeld.transform.SetPositionAndRotation(hit.position, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f));
			}
		}

		private IEnumerator SlipRoutine()
		{
			AnimationTracker anim = base.ActionAgent.Animator.PlayPunctual(AgentAnim.SlipOnPuddle);
			AgentActionSlipOnPuddle.SlippingOnPuddle?.Invoke(base.ActionAgent);
			bool didDrop = false;
			while (anim.keepWaiting)
			{
				yield return null;
				if (!didDrop && anim.GetNormalizedTime > 0.6f)
				{
					didDrop = true;
					AttemptDropItem();
				}
			}
			if (!didDrop)
			{
				AttemptDropItem();
			}
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
