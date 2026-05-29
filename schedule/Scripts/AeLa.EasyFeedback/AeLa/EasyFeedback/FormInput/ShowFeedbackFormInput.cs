using UnityEngine;

namespace AeLa.EasyFeedback.FormInput
{
	[RequireComponent(typeof(FeedbackForm))]
	public class ShowFeedbackFormInput : MonoBehaviour, IToggleFormInput
	{
		[Tooltip("Key used to toggle the feedback form")]
		public KeyCode ToggleKey;

		[Tooltip("Key used to hide the feedback form")]
		public KeyCode ShowKey;

		[Tooltip("Key used to hide the feedback form")]
		public KeyCode HideKey;

		private FeedbackForm form;

		public string Descriptor => null;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
