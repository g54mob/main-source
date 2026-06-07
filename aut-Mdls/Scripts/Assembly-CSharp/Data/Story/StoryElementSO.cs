using System;
using System.Collections.Generic;
using Data.Quests.SubQuestEvents;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Story
{
	public abstract class StoryElementSO : ScriptableObject
	{
		[Expandable]
		[SerializeField]
		private ShowNarrationDialogueSubQuestEventSO _narrationSO;

		[Expandable]
		[SerializeField]
		private ShowMultiPageModalDialogueSubQuestEventSO _modalSO;

		[SerializeField]
		private List<AbstractSubQuestEventSO> _onCompleteSubquestEvents;

		[SerializeField]
		private bool _skip;

		private bool _isComplete;

		[ReadOnly]
		public int ID = -1;

		[Tooltip("Used if multiple StoryElementSO are triggered at the same")]
		public int ExecutionOrder;

		public bool IsComplete => _isComplete;

		public event Action<StoryElementSO> OnStoryCompleted;

		public abstract void Initialize();

		public abstract void Destroy();

		[Button("Reset ID", EButtonEnableMode.Always)]
		private void ResetID()
		{
			ID = -1;
		}

		private void OnDestroy()
		{
			Destroy();
		}

		[Button("Try Execute", EButtonEnableMode.Always)]
		protected void TryExecute()
		{
			if (!_isComplete && !_skip)
			{
				SetComplete(complete: true);
				this.OnStoryCompleted?.Invoke(this);
			}
		}

		[Button("Force Execute", EButtonEnableMode.Always)]
		public void Execute()
		{
			TryExecuteNarration();
			TryExecuteModal();
		}

		private void TryExecuteModal()
		{
			if (!(_modalSO == null))
			{
				_modalSO.Execute();
			}
		}

		private void TryExecuteNarration()
		{
			if (!(_narrationSO == null))
			{
				if (_onCompleteSubquestEvents.Count > 0)
				{
					_narrationSO.SetOnCloseCallback(OnNarrationClosed);
				}
				_narrationSO.Execute();
			}
		}

		private void OnNarrationClosed()
		{
			foreach (AbstractSubQuestEventSO onCompleteSubquestEvent in _onCompleteSubquestEvents)
			{
				onCompleteSubquestEvent.Execute();
			}
		}

		public void SetComplete(bool complete)
		{
			_isComplete = complete;
		}

		public void EnsureCompletedEventsAreTriggered()
		{
			OnNarrationClosed();
		}
	}
}
