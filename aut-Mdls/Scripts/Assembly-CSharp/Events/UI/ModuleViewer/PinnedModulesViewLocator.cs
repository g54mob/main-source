using Presentation.FactoryFloor.PinnedBar;
using UnityEngine;

namespace Events.UI.ModuleViewer
{
	[CreateAssetMenu(menuName = "Locators/PinnedModulesViewLocator", fileName = "PinnedModulesViewLocator", order = 0)]
	public class PinnedModulesViewLocator : ScriptableObject
	{
		[HideInInspector]
		public PinnedModulesBarView PinnedModulesBarView;
	}
}
