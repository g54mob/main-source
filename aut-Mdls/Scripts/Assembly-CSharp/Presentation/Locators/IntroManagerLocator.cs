using Logic.Story;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/IntroManagerLocator", fileName = "IntroManagerLocatorLocator", order = 0)]
	public class IntroManagerLocator : ScriptableObject
	{
		[HideInInspector]
		public IntroManager IntroManager;
	}
}
