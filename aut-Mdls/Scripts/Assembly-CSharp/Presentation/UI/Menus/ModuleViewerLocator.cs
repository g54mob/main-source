using Presentation.UI.ModuleViewer;
using UnityEngine;

namespace Presentation.UI.Menus
{
	[CreateAssetMenu(menuName = "Locators/ModuleViewerLocator", fileName = "ModuleViewerLocator", order = 0)]
	public class ModuleViewerLocator : ScriptableObject
	{
		private Presentation.UI.ModuleViewer.ModuleViewer _moduleViewer;

		public Presentation.UI.ModuleViewer.ModuleViewer ModuleViewer => _moduleViewer;

		public void Set(Presentation.UI.ModuleViewer.ModuleViewer moduleViewer)
		{
			_moduleViewer = moduleViewer;
		}
	}
}
