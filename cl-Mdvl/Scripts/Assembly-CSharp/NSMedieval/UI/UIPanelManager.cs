using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;

namespace NSMedieval.UI
{
	public class UIPanelManager : MonoSingleton<UIPanelManager>
	{
		private List<PanelBase> openPanels = new List<PanelBase>();

		public void OnPanelShow(PanelBase panel)
		{
			if (!openPanels.Contains(panel))
			{
				openPanels.Add(panel);
			}
		}

		public void OnPanelHide(PanelBase panel)
		{
			openPanels.Remove(panel);
		}

		public void CloseAllOpened()
		{
			while (openPanels.Count > 0)
			{
				CloseLastPanel();
			}
		}

		public bool CloseLastPanel()
		{
			if (openPanels.Count == 0)
			{
				return false;
			}
			PanelBase panelBase = openPanels.Last();
			panelBase.Hide();
			if (!panelBase.isActiveAndEnabled || !panelBase.MainPanel.activeSelf)
			{
				openPanels.Remove(panelBase);
			}
			return true;
		}
	}
}
