using System;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Inspector
{
	public class FloatInputElement : ItemElement
	{
		private TMP_InputField _input;

		private TextMeshProUGUI _labelText;

		private FloatInputModel _model;

		private double? _value;

		public FloatInputElement(XmlElement xmlElement, FloatInputModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_input = xmlElement.GetElementByInternalId<TMP_InputField>("input-field");
			_input.onEndEdit.AddListener(OnValueChanged);
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			float value = _model.Value;
			if (!_input.isFocused && _value != (double)value)
			{
				_value = value;
				try
				{
					_input.text = _model.DisplayFormatter(value);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			TextAlignmentOptions textAlignmentOptions = LabelElement.TextAlignmentToTextMeshProAlignment(_model.Alignment);
			if (_input.textComponent.alignment != textAlignmentOptions)
			{
				_input.textComponent.alignment = textAlignmentOptions;
			}
		}

		private void OnValueChanged(string s)
		{
			try
			{
				float value = _model.InputParser(s);
				_model.SetValueFromUserInput(value, _model.Label);
				_value = null;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			EventSystem current = EventSystem.current;
			if (!current.alreadySelecting)
			{
				current.SetSelectedGameObject(null);
			}
		}
	}
}
