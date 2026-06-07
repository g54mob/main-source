using System;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Message")]
	public class MessageRequirement : TutorialRequirement
	{
		private bool _continueButtonClicked;

		public override bool ShowContinueButton => true;

		protected override float DefaultRequiredMetDuration => 0f;

		public MessageRequirement()
		{
		}

		public MessageRequirement(string message)
			: this(message, message)
		{
		}

		public MessageRequirement(string message, string messageVR)
		{
			base.RequirementNotMetMessage = message;
			base.RequirementNotMetMessageVR = messageVR;
		}

		public override void OnContinueButtonClicked()
		{
			_continueButtonClicked = true;
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			if (!_continueButtonClicked)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}
	}
}
