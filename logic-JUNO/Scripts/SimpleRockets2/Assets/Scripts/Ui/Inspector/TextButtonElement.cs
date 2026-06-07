using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class TextButtonElement : ButtonElement
	{
		private XmlElement _buttonElement;

		private TextMeshProUGUI _labelText;

		private TextButtonModel _model;

		public override XmlElement Button => _buttonElement;

		public TextButtonElement(XmlElement xmlElement, TextButtonModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			Button elementByInternalId = xmlElement.GetElementByInternalId<Button>("button");
			elementByInternalId.onClick.AddListener(delegate
			{
				model.OnClicked();
			});
			_buttonElement = elementByInternalId.GetComponent<XmlElement>();
			_labelText.text = model.Label;
			Update();
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
		}
	}
}
