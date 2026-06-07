using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class LabelButtonElement : ButtonElement
	{
		private XmlElement _buttonElement;

		private TextMeshProUGUI _buttonLabelText;

		private TextMeshProUGUI _labelText;

		private LabelButtonModel _model;

		public override XmlElement Button => _buttonElement;

		public LabelButtonElement(XmlElement xmlElement, LabelButtonModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_buttonLabelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("labelButton");
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
			if (_buttonLabelText.text != _model.ButtonLabel)
			{
				_buttonLabelText.text = _model.ButtonLabel;
			}
		}
	}
}
