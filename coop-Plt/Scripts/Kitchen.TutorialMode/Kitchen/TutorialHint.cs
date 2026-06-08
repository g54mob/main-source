using Controllers;
using Kitchen.Modules;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public struct TutorialHint
	{
		public TutorialMessage Message;

		public Vector3 Location;

		public Button ButtonPrompt;

		public InputPromptAnimation Animation;

		public TutorialHint(TutorialMessage m, Vector3 v, Button button_prompt, InputPromptAnimation animation = InputPromptAnimation.Attention)
		{
			Message = m;
			Location = v;
			ButtonPrompt = button_prompt;
			Animation = animation;
		}
	}
}
