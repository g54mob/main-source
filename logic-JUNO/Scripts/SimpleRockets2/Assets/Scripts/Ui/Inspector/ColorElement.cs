using System;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class ColorElement : ItemElement
	{
		private Image _image;

		private TextMeshProUGUI _labelText;

		private ColorModel _model;

		public ColorElement(XmlElement xmlElement, ColorModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("color");
			elementByInternalId.AddOnClickEvent(delegate
			{
				OnColorClicked();
			});
			_image = elementByInternalId.GetComponent<Image>();
			Update();
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			Color value = _model.Value;
			if (!_model.AllowTransparency)
			{
				value.a = 1f;
			}
			if (_image.color != value)
			{
				_image.color = value;
			}
		}

		private void OnColorClicked()
		{
			if (!_model.Enabled)
			{
				return;
			}
			Action<Color, bool> onColorChanged = delegate(Color color, bool preview)
			{
				if (!preview || _model.CallbackOnPreviewColorChange)
				{
					_image.color = color;
					_model.SetValueFromUserInput(color, _model.Label, !preview, preview);
				}
			};
			Game.Instance.UserInterface.CreateColorPicker(_model.AllowTransparency, _model.Value, delegate(Color c)
			{
				onColorChanged(c, arg2: false);
			}, delegate(Color c)
			{
				onColorChanged(c, arg2: true);
			}, _model.AllowHDR);
		}
	}
}
