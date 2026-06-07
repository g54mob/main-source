using Logic.Story;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/StoryManager", fileName = "StoryManagerLocator", order = 0)]
	public class StoryManagerLocator : ScriptableObject
	{
		[HideInInspector]
		public StoryManager StoryManager;
	}
}
