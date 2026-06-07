using ModApi.Ui.Inspector;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public class SpacerElement : ItemElement
	{
		private XmlElement _image;

		private SpacerModel _model;

		public SpacerElement(XmlElement xmlElement, SpacerModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_image = xmlElement.GetElementByInternalId("image");
			xmlElement.SetAttribute("preferredHeight", model.Height.ToString());
			if (!model.DrawImage)
			{
				_image.SetActive(active: false);
			}
		}
	}
}
