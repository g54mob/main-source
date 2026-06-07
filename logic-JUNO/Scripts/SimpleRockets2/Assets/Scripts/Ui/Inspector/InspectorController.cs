using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Inspector
{
	public class InspectorController : XmlLayoutController
	{
		public ElementBuilder ElementBuilder { get; private set; }

		public static InspectorController Create(Transform parent)
		{
			GameObject obj = Object.Instantiate(Resources.Load("Ui/InspectorPanel") as GameObject);
			obj.name = "InspectorPanels";
			obj.transform.SetParent(parent, worldPositionStays: false);
			XmlLayout xmlLayout = obj.AddComponent<XmlLayout>();
			InspectorController inspectorController = obj.AddComponent<InspectorController>();
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/InspectorPanel", xmlLayout);
			inspectorController.ElementBuilder = new ElementBuilder(inspectorController);
			return inspectorController;
		}

		private static InspectorPanelScript GetInspectorPanelFromElement(XmlElement element)
		{
			return element.gameObject.GetComponentInParent<InspectorPanelScript>();
		}

		private void OnCloseClicked(XmlElement element)
		{
			GetInspectorPanelFromElement(element).OnCloseButtonClicked();
		}

		private void OnMainHeaderClicked(XmlElement element)
		{
			InspectorPanelScript inspectorPanelFromElement = GetInspectorPanelFromElement(element);
			inspectorPanelFromElement.Collapsed = !inspectorPanelFromElement.Collapsed;
		}

		private void OnPinClicked(XmlElement element)
		{
			InspectorPanelScript inspectorPanelFromElement = GetInspectorPanelFromElement(element);
			inspectorPanelFromElement.IsPinned = !inspectorPanelFromElement.IsPinned;
		}
	}
}
