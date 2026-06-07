using DigitalLegacy.UI.Sizing;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class IconButtonRowElement : ItemElement
	{
		public XmlElement Container { get; set; }

		public IconButtonRowElement(XmlElement xmlElement, IconButtonRowModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			Container = xmlElement.GetElementByInternalId("container");
			uResize componentInParent = Container.gameObject.GetComponentInParent<uResize>();
			if (componentInParent != null)
			{
				componentInParent.OnResizeUpdate.AddListener(OnResizeUpdate);
				componentInParent.OnResizeEnd.AddListener(OnResizeUpdate);
			}
			if (!string.IsNullOrWhiteSpace(model.Label))
			{
				TextMeshProUGUI elementByInternalId = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
				if (elementByInternalId != null)
				{
					elementByInternalId.text = model.Label;
				}
			}
		}

		private void OnResizeUpdate()
		{
			LayoutRebuilder.MarkLayoutForRebuild(Container.rectTransform);
		}
	}
}
