using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class WorkerActionSewerBodyDrop : WorkerAction
	{
		private int _vigilanceAmountAdded = 10;

		private BodyBag _bag;

		private bool _bodyOnGround;

		private static Addressable<PrestigeUIStatsSO> _corpsDisposalStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/CorpsDisposal.asset");

		public SewerHole ManHole { get; set; }

		public static event Action<Agent> BodyDroped;

		public WorkerActionSewerBodyDrop(SewerHole p_manhole)
		{
			ManHole = p_manhole;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!ManHole)
			{
				return false;
			}
			if (!(p_agentRef is Worker worker))
			{
				return false;
			}
			if (!worker.IsEngaged)
			{
				return false;
			}
			return worker.ObjectHolding.IsHolding<BodyBag>();
		}

		public override void OnStart()
		{
			_bodyOnGround = false;
			SyncWithFurniture(ManHole);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(ManHole, EInteractionKey.RegularUsage, BodyBag.GetAgentQueryFilter());
		}

		public override IEnumerator ActionRoutine()
		{
			_bag = base.ActionAgent.ObjectHolding.GetHeldObject<BodyBag>();
			base.ActionAgent.ObjectHolding.DropObject();
			base.ActionAgent.ProceduralAnimator.OnItemGrabbed(_bag);
			_bag.AnimDrop();
			AnimationTracker tracker = base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropBodyHole);
			bool dropped = false;
			while (!tracker.IsCompleted)
			{
				yield return null;
				if (!dropped && tracker.GetNormalizedTime > 0.2f)
				{
					base.ActionAgent.ProceduralAnimator.DisableGrab();
					dropped = true;
				}
				if (!_bodyOnGround && tracker.GetNormalizedTime >= 0.4f)
				{
					_bodyOnGround = true;
				}
			}
			_bodyOnGround = false;
			if ((bool)_bag.BodyData.VigilanceData)
			{
				int vigilanceForSewerDrop = _bag.BodyData.VigilanceData.GetVigilanceForSewerDrop(_bag.BodyData.Credibility);
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(vigilanceForSewerDrop, ManHole.transform.position + Vector3.up);
				_corpsDisposalStat.Value.AddToCurrentValue(vigilanceForSewerDrop);
			}
			Pooler.Push(_bag);
			WorkerActionSewerBodyDrop.BodyDroped?.Invoke(base.ActionAgent);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
			BodyBag bodyBag = (base.ActionAgent ? _bag : null);
			if ((bool)bodyBag)
			{
				if (_bodyOnGround)
				{
					Vector3 rootBone = bodyBag.GetRootBone();
					rootBone.y = base.ActionAgent.transform.position.y;
					bodyBag.AnimIdleGround();
					bodyBag.transform.position = rootBone;
				}
				else
				{
					base.ActionAgent.ObjectHolding.TryGrabObject(bodyBag);
				}
			}
		}
	}
}
