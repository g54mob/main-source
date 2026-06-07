using Data.Buildings;
using UnityEngine;

namespace Events.UI.ModuleViewer
{
	[CreateAssetMenu(menuName = "Events/ShowModuleViewerUIEvent", fileName = "ShowModuleViewerUIEvent", order = 0)]
	public class ShowBuildingModulesEvent : BaseEvent<(BuildingObjectData, int)>
	{
	}
}
