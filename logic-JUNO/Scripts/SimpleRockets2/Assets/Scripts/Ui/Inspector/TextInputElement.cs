using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class TextInputElement : ItemElement
	{
		private TMP_InputField _input;

		private TextMeshProUGUI _labelText;

		private TextInputModel _model;

		public TextInputElement(XmlElement xmlElement, TextInputModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			string internalId = "input-field";
			_input = xmlElement.GetElementByInternalId<TMP_InputField>(internalId);
			_input.textComponent.enableWordWrapping = model.EnableWordWrapping;
			xmlElement.GetElementByInternalId(internalId).SetAndApplyAttribute("lineType", model.MultiLine ? TMP_InputField.LineType.MultiLineNewline.ToString() : TMP_InputField.LineType.SingleLine.ToString());
			Navigation navigation = _input.navigation;
			navigation.mode = model.NavigationMode;
			_input.navigation = navigation;
			_input.onEndEdit.AddListener(OnValueChanged);
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			Update();
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			string value = _model.Value;
			if (!_input.isFocused && _input.text != value)
			{
				_input.text = value;
			}
			TextAlignmentOptions textAlignmentOptions = LabelElement.TextAlignmentToTextMeshProAlignment(_model.Alignment);
			if (_input.textComponent.alignment != textAlignmentOptions)
			{
				_input.textComponent.alignment = textAlignmentOptions;
			}
		}

		private void OnValueChanged(string s)
		{
			_model.SetValueFromUserInput(s, _model.Label);
		}
	}
}
