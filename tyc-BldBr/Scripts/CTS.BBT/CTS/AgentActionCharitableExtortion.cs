using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Emotes;
using UnityEngine;

namespace CTS
{
	public class AgentActionCharitableExtortion : AgentAction<Agent>
	{
		private static readonly Resource<VFXData> _vfxData = new Resource<VFXData>("Scriptables/VFX/VFX_MoneyThrow");

		private bool _throwMoney;

		private bool _isFirst;

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef is Customer;
		}

		public override void OnStart()
		{
			if (base.ActionAgent is Customer customer)
			{
				customer.ClearOrder();
			}
			SeatCheck();
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			Agent actionAgent = base.ActionAgent;
			if (!(actionAgent is Customer customer))
			{
				yield break;
			}
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.ThrowingMoneyStart);
			float loopDuration = Random.value + 1f;
			base.ActionAgent.Animator.Events.OnThrowMoney += OnThrowMoney;
			_isFirst = true;
			base.ActionAgent.Animator.StartCoroutine(base.ActionAgent.Animator.PlayTimedLoop(AgentAnim.ThrowingMoneyLoop, loopDuration));
			for (float time = 0f; time < loopDuration; time += Time.deltaTime)
			{
				yield return null;
				if (_throwMoney)
				{
					_throwMoney = false;
					Transform boneTransform;
					if (_isFirst)
					{
						int money = customer.Money;
						customer.ClearOrder();
						customer.SpendMoney(customer.Money);
						EmoteManagerBBT.Play(customer, $"${money}");
						_isFirst = false;
					}
					else if (base.ActionAgent.SkeletonData.TryGetBone(EBone.LHand, out boneTransform))
					{
						base.ActionAgent.VFXManager.Play(_vfxData, boneTransform, spawnAsChild: false);
					}
				}
			}
			base.ActionAgent.VFXManager.Kill(PowerCharitableExtortion.HeadLoopVFX);
			yield return null;
			base.ActionAgent.Animator.Events.OnThrowMoney -= OnThrowMoney;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.ThrowingMoneyEnd);
		}

		private void OnThrowMoney()
		{
			_throwMoney = true;
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.ReturnToIdle();
			base.ActionAgent.Animator.Events.OnThrowMoney -= OnThrowMoney;
		}

		public override void OnCancel()
		{
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			base.ActionAgent.VFXManager.Kill(PowerCharitableExtortion.HeadLoopVFX);
		}
	}
}
