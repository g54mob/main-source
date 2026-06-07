using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public class TextElement : ItemElement
	{
		private TextMeshProUGUI _labelText;

		private TextModel _model;

		private TextMeshProUGUI _valueText;

		public TextMeshProUGUI LabelText => _labelText;

		public TextMeshProUGUI ValueText => _valueText;

		public TextElement(XmlElement xmlElement, TextModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_valueText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("value");
			_labelText.text = model.Label;
		}

		public override void Update()
		{
			base.Update();
			_valueText.text = _model.Value;
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
		}
	}
}
