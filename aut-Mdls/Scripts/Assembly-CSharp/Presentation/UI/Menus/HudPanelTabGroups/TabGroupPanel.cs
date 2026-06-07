namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public class TabGroupPanel : TabGroupPanelBase
	{
		public override void Initialize()
		{
		}

		public override void ShowPanel()
		{
			base.gameObject.SetActive(value: true);
		}

		public override void ShowPanel(AbstractHudPanelData panelData)
		{
			ShowPanel();
		}

		public override void HidePanel()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
