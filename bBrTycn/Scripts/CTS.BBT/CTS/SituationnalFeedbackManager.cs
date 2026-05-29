using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class SituationnalFeedbackManager : MonoBehaviour
	{
		[SerializeField]
		private StandardUISubtitlePanel _subtitlePanel;

		[SerializeField]
		private VictoryScreenActorSpineLinker _splinelinker;

		[SerializeField]
		private EActors _eActors;

		[SerializeField]
		private float _delayforReset = 3f;

		[SerializeField]
		private float _displayDuration = 3f;

		[SerializeField]
		private float _delayBetweenFeedbacks = 1f;

		[SerializeField]
		private float _conversationCheckDelay = 0.5f;

		[SerializeField]
		private bool _feedbackEnabled = true;

		private Queue<SituationalfeedbackSO> _feedbackQueue = new Queue<SituationalfeedbackSO>();

		private List<SituationalfeedbackSO> _feedbackUse = new List<SituationalfeedbackSO>();

		private SituationalfeedbackSO _currentFeedback;

		private bool _isDisplaying;

		private bool _isPaused;

		private Coroutine _resetFeedback;

		private void OnEnable()
		{
			if (_feedbackEnabled)
			{
				DialogueManager.instance.conversationStarted -= Instance_conversationStarted;
				DialogueManager.instance.conversationEnded -= Instance_conversationEnded;
				DialogueManager.instance.conversationStarted += Instance_conversationStarted;
				DialogueManager.instance.conversationEnded += Instance_conversationEnded;
			}
		}

		private void OnDisable()
		{
			if (_feedbackEnabled && DialogueManager.instance != null)
			{
				DialogueManager.instance.conversationStarted -= Instance_conversationStarted;
				DialogueManager.instance.conversationEnded -= Instance_conversationEnded;
			}
		}

		private void Instance_conversationEnded(Transform t)
		{
			StartCoroutine(ResumeQueue());
		}

		private void Instance_conversationStarted(Transform t)
		{
			PauseQueue();
		}

		public void EnqueueFeedback(SituationalfeedbackSO feedback)
		{
			if (_feedbackEnabled)
			{
				if (!_feedbackQueue.Contains(feedback) && !_feedbackUse.Contains(feedback))
				{
					_feedbackQueue.Enqueue(feedback);
				}
				if (!_isDisplaying)
				{
					StartCoroutine(DisplayFeedbacks());
				}
			}
		}

		private IEnumerator DisplayFeedbacks()
		{
			_isDisplaying = true;
			while (_feedbackQueue.Count > 0)
			{
				yield return StartCoroutine(WaitForConditions());
				_currentFeedback = _feedbackQueue.Dequeue();
				if (_currentFeedback == null)
				{
					continue;
				}
				string text = _currentFeedback.GiveaLocalizedString()?.GetLocalizedString();
				if (text == null)
				{
					_currentFeedback = null;
					continue;
				}
				_splinelinker.HideAll();
				_splinelinker.ShowingTheVictorySplinePersonna(_currentFeedback.FeedbacksActors);
				_subtitlePanel.SetContentByPass(_currentFeedback.FeedbacksActors.ToString(), text);
				_subtitlePanel.Open();
				_feedbackUse.Add(_currentFeedback);
				if (_resetFeedback == null)
				{
					_resetFeedback = StartCoroutine(WaitForReset());
				}
				yield return new WaitForSecondsRealtime(_displayDuration);
				_subtitlePanel.Close();
				yield return new WaitForSecondsRealtime(_delayBetweenFeedbacks);
				_currentFeedback = null;
			}
			_isDisplaying = false;
		}

		private IEnumerator WaitForReset()
		{
			yield return new WaitForSecondsRealtime(_delayforReset);
			_resetFeedback = null;
			_feedbackUse.Clear();
		}

		private IEnumerator WaitForConditions()
		{
			while (DialogueManager.isConversationActive || _isPaused)
			{
				yield return new WaitForSecondsRealtime(_conversationCheckDelay);
			}
		}

		public void PauseQueue()
		{
			_isPaused = true;
			_isDisplaying = false;
			_subtitlePanel.Close();
			StopAllCoroutines();
		}

		private IEnumerator ResumeQueue()
		{
			_isPaused = false;
			yield return new WaitForSeconds(_conversationCheckDelay);
			if (!_isDisplaying && _feedbackQueue.Count > 0)
			{
				StartCoroutine(DisplayFeedbacks());
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void open()
		{
			_splinelinker.HideAll();
			_splinelinker.ShowingTheVictorySplinePersonna(_eActors);
			_subtitlePanel.SetContentByPass(_eActors.ToString(), "COUCOU JE TE ");
			_subtitlePanel.Open();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void Close()
		{
			_subtitlePanel.Close();
		}
	}
}
