using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Emotes;
using CTS.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest13 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _cleanEntry;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		[QuestEntryPopup]
		private int _morgueEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[QuestEntryPopup]
		private int _bodiesEntry;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private UIGifsListSO _morgueHelpingGifs;

		protected override IEnumerator QuestIntroduction()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Morgue);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			JunkObject.OnJunkDiscarded -= OnObjectDiscarded;
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			WorkerActionMorgueBodyDrop.BodyDroppedInMorgue -= OnBodyAdded;
			WorkerActionSewerBodyDrop.BodyDroped -= OnBodyDroped;
		}

		protected override void StartObservingObjectives()
		{
			if (StaticObjectSet<JunkObject>.List.Count <= 0 && IsEntryStateActive(_cleanEntry))
			{
				QuestEntrySuccess(_cleanEntry);
			}
			else
			{
				JunkObject.OnJunkDiscarded += OnObjectDiscarded;
			}
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			if (Collections<Customer>.Filter(CustomerManager.HumansList, (Customer customer) => customer.IsDead).Count <= 0)
			{
				QuestEntrySuccess(_bodiesEntry);
				return;
			}
			WorkerActionMorgueBodyDrop.BodyDroppedInMorgue += OnBodyAdded;
			WorkerActionSewerBodyDrop.BodyDroped += OnBodyDroped;
		}

		private void OnBodyDroped(Agent worker)
		{
			BodyEntrySuccess(worker);
		}

		private void OnBodyAdded(Worker worker)
		{
			BodyEntrySuccess(worker);
		}

		private void BodyEntrySuccess(Agent worker)
		{
			if (QuestLog.GetQuestEntryState(_questName, _bodiesEntry) == QuestState.Active)
			{
				WorkerActionMorgueBodyDrop.BodyDroppedInMorgue -= OnBodyAdded;
				WorkerActionSewerBodyDrop.BodyDroped -= OnBodyDroped;
				QuestEntrySuccess(_bodiesEntry);
				Barks.BarkAgent(worker, _bark02);
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _morgueEntry) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<StationMorgue>())
			{
				QuestEntryCancelSuccess(_morgueEntry);
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _morgueEntry) == QuestState.Active && furniture.Interactor is StationMorgue)
			{
				QuestEntrySuccess(_morgueEntry);
				CTSSingleton<UIHelpingGifs>.Instance.ChooseHelpList(_morgueHelpingGifs);
			}
		}

		private void OnObjectDiscarded(JunkObject junk)
		{
			if (QuestLog.GetQuestEntryState(_questName, _cleanEntry) == QuestState.Active && StaticObjectSet<JunkObject>.List.Count == 0)
			{
				if (WorkerList.TryGet(out var outWorker))
				{
					EmoteManagerBBT.BarkAgent(outWorker, _bark01.GetLocalizedString());
				}
				QuestEntrySuccess(_cleanEntry);
			}
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			UnlockingManager.AddUnlockKey(EUnlockKey.Morgue);
		}

		public override void SuccessConfirmation()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Morgue);
		}
	}
}
