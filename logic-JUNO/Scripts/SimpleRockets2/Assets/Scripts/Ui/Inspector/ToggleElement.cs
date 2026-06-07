using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class ToggleElement : ItemElement
	{
		private TextMeshProUGUI _labelText;

		private ToggleModel _model;

		private bool _suppressOnValueChanged;

		private Toggle _toggle;

		public ToggleElement(XmlElement xmlElement, ToggleModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			ToggleElement toggleElement = this;
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_toggle = xmlElement.GetElementByInternalId<Toggle>("toggle");
			_toggle.onValueChanged.AddListener(delegate(bool x)
			{
				model.SetValueFromUserInput(x, toggleElement._model.Label);
			});
			_labelText.text = model.Label;
			Update();
		}

		public override void Update()
		{
			base.Update();
			bool value = _model.Value;
			if (_toggle.isOn != value)
			{
				_toggle.SetIsOnWithoutNotify(value);
				base.GameObject.GetComponentInChildren<CustomToggleScript>()?.UpdateOffImage();
			}
		}
	}
}
