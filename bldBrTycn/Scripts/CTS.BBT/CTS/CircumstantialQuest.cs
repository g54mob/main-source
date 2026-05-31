using System;
using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class CircumstantialQuest : Quest
	{
		[SerializeField]
		private UIMessageSO _questMessage;

		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		protected CircumstantialQuestsManager _manager;

		private bool _introValidated;

		public static event Action CircumstantialQuestStarting;

		public static event Action CircumstantialQuestValidating;

		protected override void OnDisabled()
		{
			base.OnDisabled();
			StopObservingStartConditions();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.QuestType = EQuestType.Circumstantial;
			if (QuestLog.GetQuestState(_questName) != QuestState.Success)
			{
				StartObservingStartConditions();
			}
		}

		public abstract void StopObservingStartConditions();

		public abstract void StartObservingStartConditions();

		public override void StartQuest()
		{
			if (QuestLog.GetQuestState(_questName) == QuestState.Unassigned)
			{
				CircumstantialQuest.CircumstantialQuestStarting?.Invoke();
				StopAllCoroutines();
				StartCoroutine(CircumstantialQuestStartCoroutine());
			}
		}

		private IEnumerator CircumstantialQuestStartCoroutine()
		{
			if ((bool)_questMessage)
			{
				CTSSingleton<UIMessage>.Instance.ShowMessage(_questMessage);
				UIMessage.MessageValidated += OnMessageValidated;
				while (!_introValidated)
				{
					yield return null;
				}
			}
			_introValidated = false;
			_manager.SetCurrentLevel(this, CTSSingleton<GameMode>.Instance.LevelInfo);
			base.StartQuest();
		}

		private void OnMessageValidated()
		{
			UIMessage.MessageValidated -= OnMessageValidated;
			_introValidated = true;
		}

		public override void ValidateQuest()
		{
			CircumstantialQuest.CircumstantialQuestValidating?.Invoke();
			base.ValidateQuest();
		}
	}
}
