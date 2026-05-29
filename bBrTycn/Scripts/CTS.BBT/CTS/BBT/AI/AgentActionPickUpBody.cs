using System;
using System.Collections;
using Animancer;
using CTS.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentActionPickUpBody : AgentAction<Agent>, IGive<BodyBag>
	{
		private SoftReference<Customer> _body;

		private static readonly Resource<BodyBag> BodyBagPrefab = new Resource<BodyBag>("Prefabs/Pfb_BodyBag");

		private MoveTarget _moveTarget;

		private bool _inPickupAnimation;

		private LockToggle _bodyBusyLocker = new LockToggle();

		public Customer Body => _body;

		public BodyBag CreatedBodyBag { get; private set; }

		public static event Action<Agent> WrappingInBodyBag;

		public event Action BodyBagCreated;

		public AgentActionPickUpBody(SoftReference<Customer> body)
		{
			_body = body;
			base.Name = GetType().Name;
		}

		public AgentActionPickUpBody(Customer body)
			: this(SoftReference.Create(body))
		{
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			Customer customer = _body.Get();
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (customer.Business.IsLocked)
			{
				return false;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStateDead>())
			{
				base.DisplayName = "Pick up dead body";
				return true;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious>())
			{
				base.DisplayName = "Pick up unconscious";
				return !(customer.ActionPlayer.CurrentAction is AgentActionGetUp);
			}
			return false;
		}

		public override void OnStart()
		{
			_inPickupAnimation = false;
		}

		public override IEnumerator WaitForRoutine()
		{
			Customer customer = _body.Get();
			Vector3 position = customer.transform.position;
			Transform boneTransform;
			Vector3 p_position = ((!customer.SkeletonData.TryGetBone(EBone.HeadTop, out boneTransform)) ? position : ((boneTransform.position - position).FlattenY() * 0.5f));
			p_position += position;
			_moveTarget = MoveTarget.CreateNew(p_position, Quaternion.identity, AgentPath.EDestinationType.LookAtDistance);
			yield return MoveToTarget(_moveTarget);
		}

		public override IEnumerator ActionRoutine()
		{
			Customer customer = _body.Get();
			_bodyBusyLocker.Clear();
			_bodyBusyLocker.Add(customer.Business);
			_bodyBusyLocker.Lock();
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious>())
			{
				customer.ContextualFSM.SetStateStuck();
			}
			customer.StartCoroutine(DisableBody());
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GrabObjectLeft, FadeMode.FromStart);
			yield return Coroutines.WaitForSeconds(0.25f);
			_inPickupAnimation = true;
			yield return AgentActionPickUpBodyBag.GrabRoutine(base.ActionAgent, new PooledRef<BodyBag>(CreatedBodyBag));
			_inPickupAnimation = false;
		}

		private IEnumerator DisableBody()
		{
			Customer body = _body.Get();
			yield return Coroutines.WaitForSeconds(0.25f);
			AgentActionPickUpBody.WrappingInBodyBag?.Invoke(body);
			CreatedBodyBag = Pooler.Pull((BodyBag)BodyBagPrefab, true);
			CreatedBodyBag.Initialized = false;
			CreatedBodyBag.AlignWithBody(body);
			CreatedBodyBag.SetBodyData(body);
			yield return Coroutines.WaitForSeconds(0.1f);
			this.BodyBagCreated?.Invoke();
			if (body.ContextualFSM.CurrentState is ContextualStateDead { RemoveBodyChore: not null } contextualStateDead)
			{
				contextualStateDead.TransferChore(CreatedBodyBag);
			}
			CreatedBodyBag.Initialized = true;
			body.ClearObject();
		}

		protected override void OnStopped()
		{
			_bodyBusyLocker.Unlock();
			if ((bool)CreatedBodyBag && CreatedBodyBag.GrabbingAgent == base.ActionAgent)
			{
				CreatedBodyBag.GrabbingAgent = null;
			}
			MoveTarget.Clear(ref _moveTarget);
		}

		public override void OnCancel()
		{
			if (_inPickupAnimation && (bool)CreatedBodyBag)
			{
				CreatedBodyBag.AnimIdleGround();
			}
		}

		public BodyBag Get()
		{
			return CreatedBodyBag;
		}
	}
}
