using Assets.Scripts.Ui;
using ModApi;
using ModApi.Ui;
using UI.Xml;

namespace Assets.Scripts.Design
{
	public class DesignerFlyoutPanelScript : XmlLayoutController
	{
		public DesignerUiScript DesignerUi { get; private set; }

		public IFlyout Flyout { get; private set; }

		public virtual void Initialize(DesignerUiScript designerUi)
		{
			Flyout = Utilities.GetComponentInParent<FlyoutScript>(base.transform);
			DesignerUi = designerUi;
		}
	}
}
