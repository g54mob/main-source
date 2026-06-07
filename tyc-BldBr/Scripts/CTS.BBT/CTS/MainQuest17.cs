using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest17 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _reservedRoomEntry;

		[SerializeField]
		[NavArea(false)]
		private int _workerArea;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		[QuestEntryPopup]
		private int _cellEntry;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		[QuestEntryPopup]
		private int _captureManagerEntry;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		[QuestEntryPopup]
		private int _capturePriorityEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _prisonersEntry;

		[SerializeField]
		private LocalizedString _bark04;

		protected override void QuestSetup()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Cell);
		}

		protected override void StopObservingObjectives()
		{
			RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			WorkerChoreAssigner.OnPriorityStatusChanged -= OnPriorityStatusChanged;
			WorkerChoreAssigner.OnPriorityChanged -= OnPriorityChanged;
			Cell.AgentCaptured -= OnAgentCaptured;
		}

		protected override void StartObservingObjectives()
		{
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			if (WorkerList.DoesAnyExist(WorkerList.HasChorePriorityActive, ChoreCategory.Capture))
			{
				QuestEntrySuccess(_captureManagerEntry);
			}
			else
			{
				WorkerChoreAssigner.OnPriorityStatusChanged += OnPriorityStatusChanged;
			}
			if (WorkerList.DoesAnyExist(WorkerList.HasChoreHigherPriorityActive, ChoreCategory.Capture))
			{
				QuestEntrySuccess(_capturePriorityEntry);
			}
			else
			{
				WorkerChoreAssigner.OnPriorityChanged += OnPriorityChanged;
			}
			Cell.AgentCaptured += OnAgentCaptured;
		}

		private void OnRoomAssignationChanged(RoomBuilding room)
		{
			if (room.NavArea == _workerArea)
			{
				RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
				QuestEntrySuccess(_reservedRoomEntry);
				Barks.BarkAnyWorker(_bark01);
			}
		}

		private void OnAgentCaptured(Cell cell, Agent victim)
		{
			Cell.AgentCaptured -= OnAgentCaptured;
			QuestEntrySuccess(_prisonersEntry);
		}

		private void OnPriorityStatusChanged(Worker worker, ChoreCategory category, bool active)
		{
			if (category == ChoreCategory.Capture && active)
			{
				QuestEntrySuccess(_captureManagerEntry);
				CapturePriorityCheck(worker);
			}
		}

		private void OnPriorityChanged(Worker worker, ChoreCategory choreCatergory, int priority)
		{
			CapturePriorityCheck(worker);
		}

		private void CapturePriorityCheck(Worker worker)
		{
			if (worker.ChoreAssigner.TryGetPriority(ChoreCategory.Capture, out var selfEnabled, out var priority) && selfEnabled && priority == 0)
			{
				WorkerChoreAssigner.OnPriorityChanged -= OnPriorityChanged;
				QuestEntrySuccess(_capturePriorityEntry);
				Barks.BarkAgent(worker, _bark02.GetLocalizedString());
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists() && QuestLog.GetQuestEntryState(_questName, _cellEntry) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<Cell>())
			{
				QuestEntryCancelSuccess(_cellEntry);
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _cellEntry) == QuestState.Active && furniture.Interactor is Cell)
			{
				QuestEntrySuccess(_cellEntry);
				Barks.BarkAnyWorker(_bark01.GetLocalizedString());
			}
		}

		public override void SkipQuest()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Cell);
		}

		public override void SuccessConfirmation()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Cell);
		}
	}
}
