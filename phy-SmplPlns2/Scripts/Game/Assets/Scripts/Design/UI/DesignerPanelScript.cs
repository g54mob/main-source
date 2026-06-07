using Assets.Scripts.UI;
using Jundroo.Juicy;

namespace Assets.Scripts.Design.UI
{
	public class DesignerPanelScript : WidgetScript
	{
		public Designer Designer { get; private set; }

		public DesignerUIScript DesignerUI { get; private set; }

		public IFlyout Flyout { get; private set; }

		public virtual void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			DesignerUI = designerUI;
			Designer = designerUI.DesignerScript.Designer;
			Flyout = GetComponentInParent<IFlyout>(includeInactive: true);
		}
	}
}
