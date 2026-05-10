using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest15 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _distillerEntry;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		[QuestEntryPopup]
		private int _machineManagerEntry;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		[QuestEntryPopup]
		private int _machinePriorityEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodBagEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodBagProduceVariable;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetBloodBagProduceVariable;

		[SerializeField]
		private int _targetBloodBagProduceVariableValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark04;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodBagProduceVariable);
		}

		protected override IEnumerator QuestIntroduction()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Research);
			base.QuestChain.UnlockMachineUI();
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			Furniture.FurniturePlaced -= OnFurniturePlaced;
			BloodDistiller.BloodBagGenerated -= OnBloodBagGenerated;
			WorkerChoreAssigner.OnPriorityStatusChanged -= OnPriorityStatusChanged;
			WorkerChoreAssigner.OnPriorityChanged -= OnPriorityChanged;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetBloodBagProduceVariable, _targetBloodBagProduceVariableValue);
			Furniture.FurniturePlaced += OnFurniturePlaced;
			if (WorkerList.DoesAnyExist(WorkerList.HasChorePriorityActive, ChoreCategory.Machines))
			{
				QuestEntrySuccess(_machineManagerEntry);
			}
			else
			{
				WorkerChoreAssigner.OnPriorityStatusChanged += OnPriorityStatusChanged;
			}
			if (WorkerList.DoesAnyExist(WorkerList.HasChoreHigherPriorityActive, ChoreCategory.Machines))
			{
				QuestEntrySuccess(_machinePriorityEntry);
			}
			else
			{
				WorkerChoreAssigner.OnPriorityChanged += OnPriorityChanged;
			}
			BloodDistiller.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodDistiller distiller, StockStack stackGenerated)
		{
			if (IncrementQuestEntryVariable(_bloodBagEntry, _bloodBagProduceVariable, stackGenerated.StackCount, _targetBloodBagProduceVariable))
			{
				BloodDistiller.BloodBagGenerated -= OnBloodBagGenerated;
				QuestEntrySuccess(_bloodBagEntry);
				Barks.BarkAnyWorker(_bark04.GetLocalizedString());
			}
		}

		private void OnPriorityStatusChanged(Worker worker, ChoreCategory category, bool active)
		{
			if (category == ChoreCategory.Machines && active)
			{
				QuestEntrySuccess(_machineManagerEntry);
				Barks.BarkAgent(worker, _bark03.GetLocalizedString());
				MachinePriorityCheck(worker);
			}
		}

		private void OnPriorityChanged(Worker worker, ChoreCategory choreCatergory, int priority)
		{
			MachinePriorityCheck(worker);
		}

		private void MachinePriorityCheck(Worker worker)
		{
			if (worker.ChoreAssigner.TryGetPriority(ChoreCategory.Machines, out var selfEnabled, out var priority) && selfEnabled && priority == 0)
			{
				WorkerChoreAssigner.OnPriorityChanged -= OnPriorityChanged;
				QuestEntrySuccess(_machinePriorityEntry);
				Barks.BarkAgent(worker, _bark02.GetLocalizedString());
				DistilleryCheck();
			}
		}

		private void DistilleryCheck()
		{
			if (QuestLog.GetQuestEntryState(_questName, _distillerEntry) == QuestState.Success && QuestLog.GetQuestEntryState(_questName, _machineManagerEntry) == QuestState.Success)
			{
				DialogueHelper.StartConversation(_feedback01);
			}
		}

		private void OnFurniturePlaced(Furniture furniture)
		{
			if (furniture.Interactor is BloodDistiller)
			{
				QuestEntrySuccess(_distillerEntry);
				Barks.BarkAnyWorker(_bark02.GetLocalizedString());
				DistilleryCheck();
			}
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			UnlockingManager.AddUnlockKey(EUnlockKey.Research);
		}

		public override void SuccessConfirmation()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.Research);
		}
	}
}
