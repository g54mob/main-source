using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	internal class AgentActionPickUpBodyBag : AgentActionPickUpItem
	{
		private const float normalizedTimeToGrab = 0.75f;

		private bool _inAnimation;

		public BodyBag Bag
		{
			get
			{
				Item outValue;
				return (base.Item.TryGetValue(out outValue) ? outValue : null) as BodyBag;
			}
		}

		public static event Action<Agent> PickingBodyBagUp;

		public AgentActionPickUpBodyBag(BodyBag bodyBag)
			: base(bodyBag)
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			_inAnimation = false;
			return base.WaitForRoutine();
		}

		public override IEnumerator ActionRoutine()
		{
			_inAnimation = true;
			yield return GrabRoutine(base.ActionAgent, new PooledRef<BodyBag>(Bag));
			_inAnimation = false;
		}

		public static IEnumerator GrabRoutine(Agent agent, PooledRef<BodyBag> pooledBag)
		{
			pooledBag.Value.GrabbingAgent = agent;
			Vector3 position = agent.transform.position + agent.transform.forward;
			Quaternion rotation = agent.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
			pooledBag.Value.transform.SetPositionAndRotation(position, rotation);
			pooledBag.Value.AnimPickup();
			AnimationTracker tracker = agent.Animator.PlayPunctual(AgentAnim.GrabBodyBag);
			AgentActionPickUpBodyBag.PickingBodyBagUp?.Invoke(agent);
			bool hasGrabbed = false;
			while (!tracker.IsCompleted)
			{
				agent.ProceduralAnimator.WeightMultiplier = tracker.GetNormalizedTime;
				if (!hasGrabbed && tracker.GetNormalizedTime >= 0.75f)
				{
					hasGrabbed = true;
					if (pooledBag.TryGetValue(out var outValue))
					{
						GrabData[] proceduralGrabData = outValue.ProceduralGrabData;
						foreach (GrabData point in proceduralGrabData)
						{
							agent.ProceduralAnimator.EnableGrab(point);
						}
					}
				}
				yield return null;
			}
			agent.ProceduralAnimator.WeightMultiplier = 1f;
			if (pooledBag.IsValid())
			{
				agent.ObjectHolding.TryGrabObject((BodyBag)pooledBag);
			}
			if (agent.TryGetComponent<SituationnalBarks_Workers>(out var component))
			{
				component.BodyBag();
			}
		}

		public override void OnCancel()
		{
			base.OnCancel();
			if (_inAnimation && (bool)Bag)
			{
				Bag.AnimIdleGround();
			}
		}
	}
}
