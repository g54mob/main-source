using Presentation.UI.Menus.HudPanelTabGroups;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Toggle ModuleViewer", fileName = "ToggleModuleViewer", order = 29)]
	public class HideModuleViewerSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private TabGroupPanelSO _moduleViewerPanelSo;

		[SerializeField]
		private HideHudPanelEvent _hideHudPanelEvent;

		public override void Execute()
		{
			_hideHudPanelEvent.Fire(_moduleViewerPanelSo);
		}
	}
}
