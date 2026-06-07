using UnityEngine;

namespace Events.UI.ModuleViewer
{
	[CreateAssetMenu(menuName = "Events/ShowModuleViewerUIEvent", fileName = "ShowModuleViewerUIEvent", order = 0)]
	public class ShowModuleViewerEvent : BaseEvent<(ModuleViewerData, int)>
	{
	}
}
