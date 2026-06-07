using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class ProgressBarElement : ItemElement
	{
		private Image _image;

		private TextMeshProUGUI _labelText;

		private ProgressBarModel _model;

		private float _value;

		public ProgressBarElement(XmlElement xmlElement, ProgressBarModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_image = xmlElement.GetElementByInternalId<Image>("image-bar");
			_labelText.text = model.Label;
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			if (_value != _model.Value)
			{
				_value = _model.Value;
				_image.fillAmount = _value;
			}
		}
	}
}
