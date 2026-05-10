using System;
using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class DialogueQuest : Quest
	{
		[SerializeField]
		private MainCharacterData _character;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue;

		[SerializeField]
		private CutscenePageData[] _cutscenePages = Array.Empty<CutscenePageData>();

		[SerializeField]
		private RewardDataBase[] _rewards = Array.Empty<RewardDataBase>();

		[SerializeField]
		private StringKey[] _highlightUIs = Array.Empty<StringKey>();

		[SerializeField]
		private UIMessageBase[] _messages = Array.Empty<UIMessageBase>();

		[SerializeField]
		[Range(0f, 6f)]
		private int _profileScore;

		public bool IsCompleted { get; private set; }

		public UnscaledGameTime StartTime { get; private set; }

		public override QuestState GetQuestState()
		{
			if (IsCompleted)
			{
				return QuestState.Success;
			}
			return QuestState.Unassigned;
		}

		public override void StartQuest()
		{
			base.gameObject.SetActive(value: true);
			QuestLog.SetQuestState(_questName, QuestState.Unassigned);
			base.StartQuest();
		}

		protected override void QuestSetup()
		{
			base.QuestSetup();
			DialogueLua.SetVariable("EndQuestActor", _character.DialogueActorId);
		}

		protected override IEnumerator QuestIntroduction()
		{
			StartTime = UnscaledGameTime.Now;
			CTSSingleton<DialogueObjective>.Instance.SetObjective(_character, _dialogue, StartTime);
			yield break;
		}

		protected override void OnResumeQuest()
		{
			base.OnResumeQuest();
			base.gameObject.SetActive(value: true);
			CTSSingleton<DialogueObjective>.Instance.SetObjective(_character, _dialogue, StartTime);
		}

		protected override void StartObservingObjectives()
		{
			DialogueObjective.ObjectiveCompleted += OnDialogueCompleted;
		}

		protected override void StopObservingObjectives()
		{
			base.StopObservingObjectives();
			DialogueObjective.ObjectiveCompleted -= OnDialogueCompleted;
		}

		private void OnDialogueCompleted()
		{
			DialogueObjective.ObjectiveCompleted -= OnDialogueCompleted;
			QuestEntrySuccess(1);
		}

		protected override IEnumerator QuestOutroCoroutine()
		{
			yield return base.QuestOutroCoroutine();
			if (_cutscenePages.Length != 0)
			{
				CutscenePageData[] cutscenePages = _cutscenePages;
				foreach (CutscenePageData page in cutscenePages)
				{
					CTSSingleton<NewsCutscene>.Instance.AddPage(page);
				}
			}
			if (_rewards.Length != 0)
			{
				RewardDataBase[] rewards = _rewards;
				foreach (RewardDataBase reward in rewards)
				{
					yield return DialogueHelper.RewardRoutine(reward);
				}
			}
			if (_messages.Length != 0)
			{
				UIMessageBase[] messages = _messages;
				foreach (UIMessageBase message in messages)
				{
					yield return DialogueHelper.MessageRoutine(message);
				}
			}
			if (_highlightUIs.Length != 0)
			{
				StringKey[] highlightUIs = _highlightUIs;
				for (int i = 0; i < highlightUIs.Length; i++)
				{
					HighlightButton.Highlight(highlightUIs[i]);
				}
			}
			if (_profileScore > 0)
			{
				CTSSingleton<GameMode>.Instance.LevelInfo.SetScoreInProfile(_profileScore);
			}
			IsCompleted = true;
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.gameObject.SetActive(value: false);
		}

		public override void SuccessConfirmation()
		{
			base.SuccessConfirmation();
			base.gameObject.SetActive(value: false);
		}
	}
}
