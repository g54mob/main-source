using System;
using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class SecondaryQuest : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _introConversation;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _successConversation;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _failConversation;

		[SerializeField]
		private RewardData _reward;

		[field: SerializeField]
		public MapInfoSO UnlockingLevel { get; private set; }

		public static event Action<SecondaryQuest> SecondaryQuestStarting;

		public static event Action<SecondaryQuest> SecondaryQuestResumed;

		public static event Action<SecondaryQuest> SecondaryQuestRefused;

		public static event Action<SecondaryQuest> SecondaryQuestSuccess;

		public static event Action<SecondaryQuest> SecondaryQuestFinished;

		protected event Action TimerOver;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.QuestType = EQuestType.Secondary;
		}

		public virtual void OfferQuest()
		{
			if (QuestLog.GetQuestState(_questName) == QuestState.Unassigned)
			{
				StopAllCoroutines();
				StartCoroutine(SecondaryQuestPropositionCoroutine());
			}
		}

		private IEnumerator SecondaryQuestPropositionCoroutine()
		{
			yield return DialogueHelper.DialogueCoroutine(_introConversation);
			if (!LastDialogueHelper.LastDialogueAccepted)
			{
				QuestRefused();
				yield break;
			}
			SecondaryQuest.SecondaryQuestStarting?.Invoke(this);
			StartQuest();
		}

		public virtual void QuestRefused()
		{
			SecondaryQuest.SecondaryQuestRefused?.Invoke(this);
		}

		protected override void OnResumeQuest()
		{
			SecondaryQuest.SecondaryQuestResumed?.Invoke(this);
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			SecondaryQuest.SecondaryQuestSuccess?.Invoke(this);
			CancelMissionBasket();
			StartCoroutine(SecondaryQuestFinishedRoutine(_successConversation));
		}

		public override void FailQuest()
		{
			base.FailQuest();
			StopAllCoroutines();
			StartCoroutine(SecondaryQuestFailedRoutine());
		}

		private IEnumerator SecondaryQuestFinishedRoutine(string conversation)
		{
			while (CTSSingleton<UIMessage>.Instance.IsPlayingSomething())
			{
				yield return null;
			}
			yield return DialogueHelper.DialogueCoroutine(conversation);
			if ((bool)_reward)
			{
				yield return DialogueHelper.MessageRoutine(_reward.PositiveMessage);
			}
			SecondaryQuest.SecondaryQuestFinished?.Invoke(this);
		}

		private IEnumerator SecondaryQuestFailedRoutine()
		{
			EndCurrentMissionBasket();
			while (CTSSingleton<UIMessage>.Instance.IsPlayingSomething())
			{
				yield return null;
			}
			yield return DialogueHelper.DialogueCoroutine(_failConversation);
			if ((bool)_reward)
			{
				yield return DialogueHelper.MessageRoutine(_reward.FailMessage);
			}
			SecondaryQuest.SecondaryQuestFinished?.Invoke(this);
		}

		protected override void SetMissionBasket(StockMissionData stockMissionData)
		{
			CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.SetMission(stockMissionData);
		}

		protected void EndCurrentMissionBasket()
		{
			CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.EndCurrentMission();
		}

		protected override void CancelMissionBasket()
		{
			CTSSingleton<CharacterDeliveries>.Instance.CancelDelivery(CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TryOfferQuest()
		{
			OfferQuest();
		}

		public override void ForceQuestSuccess()
		{
			StopAllCoroutines();
			SetAllQuestEntriesToSuccess();
			StartSuccess(waitDelay: false, playOutro: false);
		}
	}
}
