using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest07 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _feedID;

		[SerializeField]
		[QuestEntryPopup]
		private int _bodyCleaningID;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void QuestSetup()
		{
			ContextualAction.UnlockAction<ContextualActionSuckBloodKill>();
		}

		protected override IEnumerator QuestIntroduction()
		{
			base.FirstWorker.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Hunger, 0.2f);
			base.FirstWorker.AutonomousActions.Paused = true;
			yield break;
		}

		private void Update()
		{
			if (!(base.FirstWorker == null) && base.FirstWorker.AutonomousActions.Paused && base.FirstWorker.ObjectHolding.IsHolding(OrderPlate.HasNoCleanDrinks))
			{
				base.FirstWorker.ActionPlayer.ForceAction(new WorkerActionClearPlate(), EActionPriority.Forced);
			}
		}

		protected override void StartObservingObjectives()
		{
			AgentActionSuckBlood.SuckedBlood += OnSuckedBlood;
			AgentActionPickUpBody.WrappingInBodyBag += OnWrappingInBodyBag;
			WorkerActionSewerBodyDrop.BodyDroped += OnBodyDroped;
		}

		protected override void StopObservingObjectives()
		{
			AgentActionSuckBlood.SuckedBlood -= OnSuckedBlood;
			AgentActionPickUpBody.WrappingInBodyBag -= OnWrappingInBodyBag;
			WorkerActionSewerBodyDrop.BodyDroped -= OnBodyDroped;
		}

		private void OnBodyDroped(Agent worker)
		{
			WorkerActionSewerBodyDrop.BodyDroped -= OnBodyDroped;
			QuestEntrySuccess(_bodyCleaningID);
		}

		private void OnWrappingInBodyBag(Agent obj)
		{
			base.QuestChain.BarkFirstWorker(_bark02.GetLocalizedString(), 2f);
		}

		private void OnSuckedBlood(Agent agent, Customer victim)
		{
			base.QuestChain.BarkFirstWorker(_bark01.GetLocalizedString(), 2f);
			QuestEntrySuccess(_feedID);
			DialogueHelper.StartConversation(_feedback01);
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.FirstWorker.AutonomousActions.Paused = false;
			base.FirstWorker.Statistics.Paused = false;
			base.QuestChain.SetScenarizedPrestige();
			ContextualAction.UnlockAction<ContextualActionWipeMemory>();
			base.QuestChain.OpenBarButtonLocker.Unlock();
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.FirstWorker.AutonomousActions.Paused = false;
			base.FirstWorker.Statistics.Paused = false;
			base.QuestChain.SetScenarizedPrestige();
			ContextualAction.UnlockAction<ContextualActionWipeMemory>();
			ContextualAction.UnlockAction<ContextualActionSuckBloodKill>();
			base.QuestChain.OpenBarButtonLocker.Unlock();
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.SetScenarizedPrestige();
			ContextualAction.UnlockAction<ContextualActionWipeMemory>();
			ContextualAction.UnlockAction<ContextualActionSuckBloodKill>();
			base.QuestChain.OpenBarButtonLocker.Unlock();
		}
	}
}
