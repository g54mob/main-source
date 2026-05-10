using AeLa.EasyFeedback.FormInput;
using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine;

namespace AeLa.EasyFeedback
{
	public class FeedbackText : MonoBehaviour
	{
		public string Message;

		public FeedbackForm Form;

		private IToggleFormInput input;

		private IText text;

		private string currentDescriptor;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void UpdateText()
		{
		}
	}
}
