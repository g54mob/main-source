using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/ObjectiveManager", fileName = "ObjectivesManagerLocator", order = 0)]
	public class ObjectivesManagerLocator : ScriptableObject
	{
		[HideInInspector]
		public ObjectiveManager ObjectivesManager;
	}
}
