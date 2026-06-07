using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class IfFeedbackPanel : MonoBehaviourX
	{
		public GameObject feedbackButtonContainer;

		public Button3DUIView customFeedbackButton;

		private IfFeedbackButton3DUIView[] _feedbackButtons;

		public event EventHandler<EventArgs<StoryFeedback>> FeedbackClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Start()
		{
		}

		public void SetCurrentVote(string feedback)
		{
		}

		private void CustomFeedbackClicked()
		{
		}

		private void FeedbackButtonClicked(IfFeedbackButton3DUIView sender)
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
