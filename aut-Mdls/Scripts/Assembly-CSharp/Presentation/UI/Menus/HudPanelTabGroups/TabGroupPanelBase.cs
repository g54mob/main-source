using UnityEngine;

namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public abstract class TabGroupPanelBase : MonoBehaviour
	{
		public abstract void Initialize();

		public abstract void ShowPanel();

		public abstract void ShowPanel(AbstractHudPanelData panelData);

		public abstract void HidePanel();
	}
}
