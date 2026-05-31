using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Emotes;
using CTS.UI;
using CTS.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class CustomerActionAlert : CustomerAction
	{
		private static readonly StringKey _materialKey = "PanicEmote";

		private static readonly int SHFillAmount = Shader.PropertyToID("_FillAmount");

		private float _durationMultiplier = 1f;

		private Materials.PooledMaterial _material;

		private EmoteBBT _emote;

		private bool _calledOff;

		public float BaseDuration { get; set; } = 1f;

		public AnimKey? Animation { get; set; } = AgentAnim.Scared;

		public IVisible Target { get; set; }

		public static event Action<Agent, bool> AlertStatusChanged;

		public void SetTarget(Crime crime)
		{
			Target = crime;
			_durationMultiplier = crime.AlertDurationMultiplicator;
		}

		public CustomerActionAlert(IVisible target)
			: this()
		{
			Target = target;
			_durationMultiplier = 1f;
		}

		private CustomerActionAlert()
		{
			_material = CTSSingleton<Materials>.Instance.GetMaterialInstance(_materialKey);
			_emote = EmotePool.GetEmoteBBT();
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (Target.EqualsNull() || !Target.Transform.gameObject.activeInHierarchy)
			{
				return false;
			}
			Customer customer = p_agentRef as Customer;
			if (!customer)
			{
				return false;
			}
			if (customer.IsVampire)
			{
				return false;
			}
			if (customer.Tags.HasTag(EAgentTag.Leaving))
			{
				return false;
			}
			return customer.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
			_calledOff = false;
			PlayEmote();
			base.ActionAgent.Animator.Speed = 2f;
			SeatCheck();
		}

		public override IEnumerator WaitForRoutine()
		{
			CustomerActionAlert.AlertStatusChanged?.Invoke(base.ActionAgent, arg2: true);
			Target.WasSeen?.Invoke();
			base.ActionAgent.Animator.Speed = 1f;
			base.ActionAgent.Cooldowns.StartCooldown(BBTAgentTags.Oblivious, 2f);
			if (Animation.HasValue)
			{
				base.ActionAgent.Animator.PlayPunctual(Animation.Value);
			}
			yield return base.ActionAgent.transform.DOLookAt(Target.Transform.position, 0.5f, AxisConstraint.Y).WaitForCompletion();
			float maxDuration = BaseDuration * _durationMultiplier;
			_emote.SetStayDuration(maxDuration);
			_emote.SetUseScaledTime(isScaled: true);
			float currentDuration = maxDuration;
			while (currentDuration > 0f)
			{
				_material.Mat.SetFloat(SHFillAmount, currentDuration / maxDuration);
				base.ActionAgent.transform.DOKill();
				currentDuration -= Time.deltaTime;
				if (!Target.EqualsNull() && Target.IsVisible && base.ActionAgent.CrimeVision.IsInSight(Target.Transform.position))
				{
					base.ActionAgent.transform.DOLookAt(Target.Transform.position, 0f, AxisConstraint.Y);
				}
				yield return null;
			}
		}

		public override IEnumerator ActionRoutine()
		{
			if (base.ActionAgent.CrimeWitness.CheckCrimesInSight())
			{
				SendEvent();
				base.ActionAgent.ContextualFSM.SetStatePanicking();
			}
			else if (Target.IsVisible && base.ActionAgent.CrimeVision.IsInSight(Target.Transform.position))
			{
				SendEvent();
				base.ActionAgent.ContextualFSM.SetStatePanicking();
			}
			yield break;
		}

		public override void OnCancel()
		{
			if (!base.ActionAgent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				base.ActionAgent.CrimeWitness.RestartObservingAfterCooldown(0.25f);
			}
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.ReturnToIdle();
			SendEvent();
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			if (CTSSingleton<Materials>.InstanceExists())
			{
				CTSSingleton<Materials>.Instance.PushMaterialInstance(_material);
			}
			if (_emote != null)
			{
				_emote.Kill();
				EmotePool.PushEmote(_emote);
				_emote = null;
			}
			base.ActionAgent.Animator.Speed = 1f;
		}

		private void SendEvent()
		{
			if (!_calledOff)
			{
				_calledOff = true;
				CustomerActionAlert.AlertStatusChanged?.Invoke(base.ActionAgent, arg2: false);
			}
		}

		private void PlayEmote()
		{
			_emote = EmoteManagerBBT.Play(base.ActionAgent, base.ActionAgent.ContextualFSM.EmotePreAlertSprite, _emote);
			_emote.SetStayDuration(-1f);
			_emote.SetBackgroundSprite(base.ActionAgent.ContextualFSM.EmoteBackgroundSprite);
			_emote.SetBackgroundMaterial(_material);
			_emote.SetBackgroundColor(base.ActionAgent.ContextualFSM.EmoteBackgroundColor);
			_emote.SetContentColor(BBTPalette.GetColor(BBTPalette.EmoteWhite));
			_emote.SetContentSize(30f);
			_material.Mat.SetFloat(SHFillAmount, 1f);
			_emote.SetPadding(8f);
		}
	}
}
