using UnityEngine;

namespace Events.UI.ModuleViewer
{
	[CreateAssetMenu(menuName = "Events/PinModuleUIEvent", fileName = "PinModuleUIEvent", order = 0)]
	public class PinModuleUIEvent : BaseEvent<(ModuleViewerData, int)>
	{
	}
}
