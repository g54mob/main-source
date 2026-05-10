using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class WorkerActionTheDipBodyDrop : WorkerAction
	{
		private int _vigilanceAmountAdded = 10;

		private BodyBag _bag;

		private bool _bodyOnGround;

		public TheDip TheDip { get; set; }

		public static event Action<Agent> BodyDropedTheDip;

		internal WorkerActionTheDipBodyDrop(TheDip TheDipScript)
		{
			TheDip = TheDipScript;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!TheDip)
			{
				return false;
			}
			if (TheDip.MachinePowerState == EMachinePowerState.Off)
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
			if (TheDip.IsSomebodyIn)
			{
				return false;
			}
			if (!TheDip.CanBeUsed(worker))
			{
				return false;
			}
			return worker.ObjectHolding.IsHolding<BodyBag>();
		}

		public override void OnStart()
		{
			SyncWithFurniture(TheDip);
		}

		public override IEnumerator WaitForRoutine()
		{
			base.ActionAgent.FurnitureAssignment.StartUsing(TheDip);
			yield return MoveToActor(TheDip, EInteractionKey.RegularUsage, BodyBag.GetAgentQueryFilter());
		}

		public override IEnumerator ActionRoutine()
		{
			_bag = base.ActionAgent.ObjectHolding.GetHeldObject<BodyBag>();
			base.ActionAgent.ObjectHolding.DropObject();
			base.ActionAgent.ProceduralAnimator.OnItemGrabbed(_bag);
			_bag.AnimDropDrip();
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(TheDip.SFXMachineList.SoundsList[3]);
			AnimationTracker tracker = base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropBodyTheDip);
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
			TheDip.AddBodyBag(_bag.BodyData);
			if ((bool)TheDip.MachineTechTree)
			{
				TheDip.MachineTechTree.TryToGenerateResearchPoints(base.ActionAgent, base.ActionAgent.Statistics.GetStatisticValue(EAgentStatistics.Intellect));
			}
			Pooler.Push(_bag);
			WorkerActionTheDipBodyDrop.BodyDropedTheDip?.Invoke(base.ActionAgent);
			TheDip.Launch();
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
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
