using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class CQuest_Panic : CircumstantialQuest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _pauseEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _priorityEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _powerEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _panicFinishedEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _startFeedback;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _witnessPriorityFeedback;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _powerFeedback;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _endQuestFeedback;

		[SerializeField]
		private LocalizedString _endQuestBark;

		[SerializeField]
		private StringKey _pauseButtonId;

		[SerializeField]
		private UIGifsListSO _powerVideos;

		private CTSToggle _pauseButton;

		private CTSToggle GetPauseButton()
		{
			if (!_pauseButton)
			{
				CTSSelectable.TryGet(_pauseButtonId, out CTSToggle outSelectable);
				_pauseButton = outSelectable;
			}
			return _pauseButton;
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<UIHelpingGifs>.Instance.ChooseHelpList(_powerVideos);
			DialogueHelper.StartConversation(_startFeedback);
			yield break;
		}

		public override void StartObservingStartConditions()
		{
			PanicCounter.PanicActive += OnPanicActive;
		}

		public override void StopObservingStartConditions()
		{
			PanicCounter.PanicActive -= OnPanicActive;
		}

		protected override void StartObservingObjectives()
		{
			bool flag = false;
			foreach (Worker item in WorkerList.All)
			{
				if (item.ChoreAssigner.TryGetPriority(ChoreCategory.Witnesses, out var selfEnabled, out var priority) && priority == 0 && selfEnabled)
				{
					QuestEntrySuccess(_priorityEntry);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ListenToPriority();
			}
			if (GetPauseButton().isOn)
			{
				QuestEntrySuccess(_pauseEntry);
			}
			else
			{
				GetPauseButton().onValueChanged.AddListener(OnPauseButtonChange);
			}
			PanicPowerButton.PowerCast += OnPanicPowerCast;
		}

		protected override void StopObservingObjectives()
		{
			StopListenToPriority();
			GetPauseButton()?.onValueChanged.AddListener(OnPauseButtonChange);
			PanicPowerButton.PowerCast -= OnPanicPowerCast;
		}

		private void ListenToPriority()
		{
			WorkerChoreAssigner.OnPriorityChanged += OnWorkerPriorityOrderChanged;
			WorkerChoreAssigner.OnPriorityStatusChanged += OnWorkerPriorityStatusChanged;
		}

		private void StopListenToPriority()
		{
			WorkerChoreAssigner.OnPriorityChanged -= OnWorkerPriorityOrderChanged;
			WorkerChoreAssigner.OnPriorityStatusChanged -= OnWorkerPriorityStatusChanged;
		}

		private void OnPanicPowerCast()
		{
			PanicPowerButton.PowerCast -= OnPanicPowerCast;
			QuestEntrySuccess(_powerEntry);
			DialogueHelper.StartConversation(_powerFeedback);
		}

		private void OnPauseButtonChange(bool isOn)
		{
			if (isOn)
			{
				GetPauseButton().onValueChanged.RemoveListener(OnPauseButtonChange);
				QuestEntrySuccess(_pauseEntry);
			}
		}

		private void OnWorkerPriorityStatusChanged(Worker worker, ChoreCategory category, bool isActive)
		{
			if (isActive && category == ChoreCategory.Witnesses)
			{
				CheckWorkerPriority(worker);
			}
		}

		private void OnWorkerPriorityOrderChanged(Worker worker, ChoreCategory category, int order)
		{
			if (order == 0 && category == ChoreCategory.Witnesses)
			{
				CheckWorkerPriority(worker);
			}
		}

		private bool CheckWorkerPriority(Worker worker)
		{
			if (!worker.ChoreAssigner.TryGetPriority(ChoreCategory.Witnesses, out var selfEnabled, out var priority))
			{
				return false;
			}
			if (priority != 0 || !selfEnabled)
			{
				return false;
			}
			StopListenToPriority();
			QuestEntrySuccess(_priorityEntry);
			DialogueHelper.StartConversation(_witnessPriorityFeedback);
			return true;
		}

		private void OnPanicActive(bool isActive)
		{
			if (!base.gameObject.scene.isLoaded)
			{
				return;
			}
			if (base.QuestState == QuestState.Active)
			{
				if (base.gameObject.scene.isLoaded && !isActive)
				{
					QuestEntrySuccess(_pauseEntry);
					QuestEntrySuccess(_priorityEntry);
					QuestEntrySuccess(_powerEntry);
					QuestEntrySuccess(_panicFinishedEntry);
					Barks.BarkAnyWorker(_endQuestBark);
					DialogueHelper.StartConversation(_endQuestFeedback);
				}
			}
			else if (isActive)
			{
				StartQuest();
			}
		}
	}
}
