using Controllers;
using Kitchen.Modules;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public static class Hint
	{
		public static TutorialHint Above(Vector3 v, TutorialMessage m, Button button_prompt = Button.None, InputPromptAnimation animation = InputPromptAnimation.Attention)
		{
			return new TutorialHint(m, v, button_prompt, animation);
		}

		public static TutorialHint Below(Vector3 v, TutorialMessage m, Button button_prompt = Button.None, InputPromptAnimation animation = InputPromptAnimation.Attention)
		{
			return new TutorialHint(m, v + new Vector3(0f, 0f, -3f), button_prompt, animation);
		}
	}
}
