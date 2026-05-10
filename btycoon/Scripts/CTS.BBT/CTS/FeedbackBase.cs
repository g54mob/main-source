using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class FeedbackBase : MonoBehaviour
	{
		[SerializeField]
		[QuestPopup(false)]
		protected string _questName;

		[SerializeField]
		protected string _feedbackText;

		[SerializeField]
		protected float _feedbackDelay;

		[SerializeField]
		protected GameObject[] _toHighlight;

		private QuestState previousState;

		private bool _feedBackShowable;

		private bool _shown;

		private void OnEnable()
		{
			QuestsEvents.QuestStateChanged += OnQuestStateChanged;
		}

		private void OnQuestStateChanged(string quest, QuestState state)
		{
			if (!(quest != _questName) && previousState != state)
			{
				previousState = state;
				if (state == QuestState.Active)
				{
					StartFeedbackLogic();
				}
				else
				{
					StopFeedbackLogic();
				}
			}
		}

		private void OnDisable()
		{
			StopFeedbackLogic();
			QuestsEvents.QuestStateChanged -= OnQuestStateChanged;
		}

		protected void ShowFeedback()
		{
			if (!_shown)
			{
				ShowFeedback(_feedbackText);
			}
		}

		protected void ShowFeedback(string text)
		{
			if (QuestLog.GetQuestState(_questName) == QuestState.Active)
			{
				_feedBackShowable = true;
				StartCoroutine(ShowFeedbackCoroutine(text, _feedbackDelay));
			}
		}

		private IEnumerator ShowFeedbackCoroutine(string message, float delay)
		{
			yield return new WaitForSecondsRealtime(delay);
			MonoSingleton<FeedbackHandler>.Instance.ShowFeedback(message);
			_shown = true;
			ShowHighlights();
		}

		protected virtual void ShowHighlights()
		{
			GameObject[] toHighlight = _toHighlight;
			foreach (GameObject p_target in toHighlight)
			{
				MonoSingleton<HighlightersManager>.Instance.Highlight(p_target);
			}
		}

		protected void HideFeedback()
		{
			if (_feedBackShowable)
			{
				_feedBackShowable = false;
				StopAllCoroutines();
				if (MonoSingleton<FeedbackHandler>.InstanceExists())
				{
					MonoSingleton<FeedbackHandler>.Instance.HideFeedback();
				}
				_shown = false;
				HideHighlights();
			}
		}

		protected virtual void HideHighlights()
		{
			GameObject[] toHighlight = _toHighlight;
			foreach (GameObject p_target in toHighlight)
			{
				MonoSingleton<HighlightersManager>.Instance.StopHighlight(p_target);
			}
		}

		protected abstract void StartFeedbackLogic();

		protected abstract void StopFeedbackLogic();
	}
}
