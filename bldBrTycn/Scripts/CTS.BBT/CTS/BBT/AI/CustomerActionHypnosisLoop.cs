using System.Collections;
using CTS.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class CustomerActionHypnosisLoop : CustomerAction
	{
		private SoftReference<Agent> _vampire;

		private MoveTarget _moveTarget;

		private bool _wasPanicking;

		public Agent Target
		{
			get
			{
				return _vampire;
			}
			set
			{
				_vampire = value;
			}
		}

		public CustomerActionHypnosisLoop(SoftReference<Agent> agentToFollow, bool wasPanicking = false)
		{
			_vampire = agentToFollow;
			_wasPanicking = wasPanicking;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			Priority = EActionPriority.Default;
			if (!Target.ContextActorData.TryGetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position, out _moveTarget))
			{
				CancelAction("Couldn't get pickup point on vampire", playBlockedAction: true);
				return;
			}
			SyncWithAgent(_vampire);
			base.ActionAgent.AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.StayOpen;
		}

		public override IEnumerator WaitForRoutine()
		{
			while (true)
			{
				if (base.ActionAgent.Movement.CurrentPath == null && Vector3.Distance(base.ActionAgent.transform.position, _vampire.Get().transform.position) > 2f)
				{
					MoveToLookAt(_moveTarget.transform, 0.2f, 1.5f, -1f);
				}
				yield return null;
			}
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			StopAgentSyncing();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
