namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public class ModuleViewerHudPanelData : AbstractHudPanelData
	{
		public ModuleViewerData ModuleViewerData;

		public int Index;

		public ModuleViewerHudPanelData(TabGroupPanelSO panelSo, ModuleViewerData moduleViewerData, int index)
			: base(panelSo)
		{
			ModuleViewerData = moduleViewerData;
			Index = index;
		}
	}
}
