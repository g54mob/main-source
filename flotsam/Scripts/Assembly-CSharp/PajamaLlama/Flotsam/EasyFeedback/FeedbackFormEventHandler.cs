using AeLa.EasyFeedback;
using UnityEngine;

namespace PajamaLlama.Flotsam.EasyFeedback
{
	public class FeedbackFormEventHandler : MonoBehaviour
	{
		private FeedbackForm _feedbackFrom;

		private void Awake()
		{
			_feedbackFrom = GetComponent<FeedbackForm>();
		}

		private void OnEnable()
		{
			GameEventDispatcher.AddListener(SessionEventType.ReportBug, OnFeedbackEvent);
		}

		private void OnDisable()
		{
			GameEventDispatcher.RemoveListener(SessionEventType.ReportBug, OnFeedbackEvent);
		}

		private void OnFeedbackEvent(SessionEventType evt, object args)
		{
			_feedbackFrom.Toggle();
		}
	}
}
