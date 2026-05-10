using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest02 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _selectionEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _discardEntry;

		[SerializeField]
		private JunkObject _junkToDiscard;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void StartObservingObjectives()
		{
			if (!_junkToDiscard)
			{
				QuestEntrySuccess(_selectionEntry);
				QuestEntrySuccess(_discardEntry);
				return;
			}
			Worker.OnSelect += Worker_OnSelect;
			if ((bool)_junkToDiscard)
			{
				_junkToDiscard.Discarded += OnJunkDiscarded;
				WorkerChoreDiscardJunk.GoingToDiscardJunk += OnAgentGoingToDiscard;
			}
		}

		private void OnAgentGoingToDiscard(Agent agent, JunkObject junk)
		{
			if (!(agent != base.QuestChain.FirstWorker) && !(junk != _junkToDiscard))
			{
				WorkerChoreDiscardJunk.GoingToDiscardJunk -= OnAgentGoingToDiscard;
				BarkFirstWorker(_bark02.GetLocalizedString());
			}
		}

		private void OnJunkDiscarded()
		{
			_junkToDiscard.Discarded -= OnJunkDiscarded;
			QuestEntrySuccess(_discardEntry);
			QuestEntrySuccess(_selectionEntry);
		}

		private void Worker_OnSelect(Worker worker)
		{
			Worker.OnSelect -= Worker_OnSelect;
			BarkFirstWorker(_bark01.GetLocalizedString());
			QuestEntrySuccess(_selectionEntry);
		}

		protected override void StopObservingObjectives()
		{
			if ((bool)_junkToDiscard)
			{
				_junkToDiscard.Discarded -= OnJunkDiscarded;
			}
			Worker.OnSelect -= Worker_OnSelect;
			WorkerChoreDiscardJunk.GoingToDiscardJunk -= OnAgentGoingToDiscard;
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			UnlockingManager.AddUnlockKey(EUnlockKey.CheapBarPackage);
			base.QuestChain.FurnitureShopLocker.Unlock();
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			UnlockingManager.AddUnlockKey(EUnlockKey.CheapBarPackage);
			base.QuestChain.FurnitureShopLocker.Unlock();
		}

		public override void SuccessConfirmation()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.CheapBarPackage);
			base.QuestChain.FurnitureShopLocker.Unlock();
		}
	}
}
