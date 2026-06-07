using Data.Buildings;
using Presentation.UI.Menus.HudPanelTabGroups;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Open ModuleViewer", fileName = "OpenModuleViewer", order = 30)]
	public class OpenModuleViewerSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private BuildingObjectData _buildingObjectData;

		[SerializeField]
		private int _moduleIndex;

		[SerializeField]
		private ShowHudPanelEvent _showHudPanelEvent;

		[SerializeField]
		private TabGroupPanelSO _moduleViewerPanelSo;

		public override void Execute()
		{
			_showHudPanelEvent.Fire(new ModuleViewerHudPanelData(_moduleViewerPanelSo, _buildingObjectData.GetModuleViewerData, _moduleIndex));
		}
	}
}
