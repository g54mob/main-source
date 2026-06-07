using System;
using CTS.Core;
using CTS.Emotes;
using CTS.UI;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class ContextualStatePanicking : ContextualState, IUpdatable
	{
		private WorkerChoreHub _witnessAutomationChore;

		private static readonly int SHFillAmount = Shader.PropertyToID("_FillAmount");

		private EmoteBBT _emote;

		private bool _leaving => !base.parent.Cooldowns.IsOnCooldown(BBTAgentTags.StartedPanicking);

		public static StringKey SatisfactionPanicKey { get; } = "PanicLoss";

		public static event Action<Agent> Panicking;

		public static event Action<Agent> StoppedPanicking;

		public ContextualStatePanicking(float speed)
			: base(speed)
		{
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			_emote = EmotePool.GetEmoteBBT();
			EmoteManagerBBT.Play(base.parent, base.parent.ContextualFSM.EmoteAlertSprite, _emote);
			_emote.SetStayDuration(-1f);
			_emote.SetBackgroundSprite(base.parent.ContextualFSM.EmoteBackgroundSprite);
			_emote.SetBackgroundMaterial(base.parent.ContextualFSM.EmoteBackgroundMaterial);
			_emote.SetBackgroundColor(base.parent.ContextualFSM.EmoteBackgroundColor);
			_emote.SetContentColor(BBTPalette.GetColor(BBTPalette.EmoteWhite));
			_emote.SetContentSize(30f);
			_emote.SetPadding(8f);
			base.parent.ContextualFSM.EmoteBackgroundMaterial.SetFloat(SHFillAmount, 1f);
			UpdateSpreader.AddUpdate(this);
			ContextualStatePanicking.Panicking?.Invoke(base.parent);
			if (!(base.parent is Customer customer))
			{
				base.parent.ContextualFSM.SetStateNormal();
				return;
			}
			_witnessAutomationChore = new WorkerChoreHub(ChoreCategory.Witnesses, new ActionHubWitnessDealing(customer), customer.RoomObject)
			{
				AssignationBypassPowers = true
			};
			MonoSingleton<ChoreList>.Instance.AddToList(_witnessAutomationChore);
			customer.Animator.EnableOverride("Panic");
			if (SaveManager.CurrentSaveState == SaveManager.ESaveState.None)
			{
				base.parent.Cooldowns.StopCooldown(BBTAgentTags.Oblivious);
				base.parent.RemoveTag(BBTAgentTags.NoReview);
				base.parent.Tags.RemoveTag(EAgentTag.WentInMachine);
				base.parent.Statistics.SetStatisticValue(EAgentStatistics.Alcohol, 0f);
				if ((bool)base.parent.Satisfaction)
				{
					base.parent.Satisfaction.SetModifier(SatisfactionPanicKey);
				}
				if ((bool)customer.ControllingVampire)
				{
					customer.ControllingVampire.SetControlledHuman(null);
				}
				customer.SeparateFromGroup();
				customer.ReleaseSeat();
				base.parent.Cooldowns.StartCooldown(BBTAgentTags.StartedPanicking);
			}
		}

		public void OnUpdate()
		{
			if (_leaving)
			{
				base.parent.ContextualFSM.EmoteBackgroundMaterial.SetFloat(SHFillAmount, 0f);
				if ((object)_emote.Sprite != base.parent.ContextualFSM.EmoteRunSprite)
				{
					_emote.SetSprite(base.parent.ContextualFSM.EmoteRunSprite);
				}
				if (!base.parent.Tags.HasTag(EAgentTag.IsInside) && _emote.IsPlaying)
				{
					_emote.Kill();
				}
			}
			else
			{
				base.parent.ContextualFSM.EmoteBackgroundMaterial.SetFloat(SHFillAmount, 1f - base.parent.Cooldowns.GetUnitCompletion(BBTAgentTags.StartedPanicking));
			}
		}

		public override void OnStateExit()
		{
			if (_emote != null)
			{
				_emote.Kill();
				EmotePool.PushEmote(_emote);
			}
			ContextualStatePanicking.StoppedPanicking?.Invoke(base.parent);
			UpdateSpreader.RemoveUpdate(this);
			_witnessAutomationChore?.DestroyChore();
			base.parent.Animator.DisableOverride("Panic");
		}
	}
}
