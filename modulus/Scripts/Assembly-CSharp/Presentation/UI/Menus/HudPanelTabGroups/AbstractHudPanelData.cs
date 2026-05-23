namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public abstract class AbstractHudPanelData
	{
		public readonly TabGroupPanelSO PanelSo;

		public readonly bool Toggle;

		protected AbstractHudPanelData(TabGroupPanelSO panelSo, bool toggle = false)
		{
			PanelSo = panelSo;
			Toggle = toggle;
		}
	}
}
