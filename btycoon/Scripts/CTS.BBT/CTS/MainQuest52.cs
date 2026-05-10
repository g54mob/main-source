using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest52 : Quest
	{
		[SerializeField]
		private WorkerSpawn[] _workerSpawns;

		private MaxVigilanceGoal _maxVigilanceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _maxVigilanceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilanceTarget;

		[SerializeField]
		private int _maxVigilanceTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilance;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private DaysWithoutPanicGoal _noPanicDaysGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _noPanicDaysEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _noPanicDaysTarget;

		[SerializeField]
		private int _noPanicDaysTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _noPanicDays;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_maxVigilance, _noPanicDays);
		}

		protected override IEnumerator QuestIntroduction()
		{
			WorkerSpawn[] workerSpawns = _workerSpawns;
			for (int i = 0; i < workerSpawns.Length; i++)
			{
				workerSpawns[i].Spawn();
			}
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_maxVigilanceGoal?.CleanStopObserving();
			_noPanicDaysGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_maxVigilanceTarget, _maxVigilanceTargetValue);
			DialogueLua.SetVariable(_noPanicDaysTarget, _noPanicDaysTargetValue);
			_maxVigilanceGoal = new MaxVigilanceGoal(this, _maxVigilanceEntry, _maxVigilance, _maxVigilanceTarget);
			_maxVigilanceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_noPanicDaysGoal = new DaysWithoutPanicGoal(this, _noPanicDaysEntry, _noPanicDays, _noPanicDaysTarget);
			_noPanicDaysGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
