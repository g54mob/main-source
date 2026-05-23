using Presentation.FactoryFloor;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/ToolSystemLocator", fileName = "ToolSystemLocator", order = 0)]
	public class ToolSystemLocator : ScriptableObject
	{
		public ToolSystem ToolSystem { get; private set; }

		public void SetToolSystem(ToolSystem toolSystem)
		{
			ToolSystem = toolSystem;
		}
	}
}
