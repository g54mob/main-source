using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class PromptStep : AQuickTutorialStep
	{
		private bool pause;

		private bool dismissed;

		public PromptStep(string message, bool pause = false)
			: base(message, null, Vector3.zero, shouldRecheck: false)
		{
			this.pause = pause;
		}

		public override void ShowVisual()
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt(((VerbSimpleQuickTutorialMessage)Message).message, pause, OnPromptDismissed);
		}

		private void OnPromptDismissed()
		{
			dismissed = true;
		}

		protected override bool InternalCheck()
		{
			return dismissed;
		}
	}
}
