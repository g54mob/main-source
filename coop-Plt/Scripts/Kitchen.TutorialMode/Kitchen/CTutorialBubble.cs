using Controllers;
using Kitchen.Modules;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CTutorialBubble : IComponentData
	{
		public TutorialMessage Text;

		public Button ButtonPrompt;

		public InputPromptAnimation Animation;
	}
}
