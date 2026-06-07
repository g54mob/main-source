using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/TechTreeManager", fileName = "TechTreeManagerLocator", order = 0)]
	public class TechTreeManagerLocator : ScriptableObject
	{
		[HideInInspector]
		public TechTreeManager TechTreeManager;
	}
}
