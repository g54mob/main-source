using System.Collections.Generic;
using ModApi.Craft;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.Paint
{
	public class ColorButtonsPanelScript
	{
		public delegate void ColorSelectedDelegate(ColorButtonScript colorButton);

		private const int ReservedColorCount = 0;

		private XmlElement _buttonTemplate;

		private List<ColorButtonScript> _colorButtons;

		private XmlElement _element;

		public ColorButtonScript SelectedColor { get; private set; }

		public event ColorSelectedDelegate ColorSelected;

		public void DeselectColor()
		{
			OnColorSelected(null);
		}

		public void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_colorButtons = new List<ColorButtonScript>();
			_element = xmlLayout.GetElementById("color-buttons");
			_buttonTemplate = xmlLayout.GetElementById("color-button-template");
		}

		public void OnThemeChanged(ThemeData theme)
		{
			int materialCount = theme.MaterialCount;
			for (int i = _colorButtons.Count; i < materialCount; i++)
			{
				RectTransform component = Object.Instantiate(_buttonTemplate.gameObject).GetComponent<RectTransform>();
				component.gameObject.SetActive(value: true);
				component.name = "ColorButton" + _colorButtons.Count;
				XmlElement component2 = component.GetComponent<XmlElement>();
				_element.AddChildElement(component2);
				ColorButtonScript colorButtonScript = component.gameObject.AddComponent<ColorButtonScript>();
				colorButtonScript.Selected += OnColorSelected;
				colorButtonScript.Initialize(component2);
				_colorButtons.Add(colorButtonScript);
			}
			for (int j = 0; j < materialCount; j++)
			{
				_colorButtons[j].gameObject.SetActive(value: true);
				_colorButtons[j].PartMaterial = theme.GetMaterial(j);
			}
			for (int k = materialCount; k < _colorButtons.Count; k++)
			{
				_colorButtons[k].gameObject.SetActive(value: false);
			}
			DeselectColor();
		}

		private void OnColorSelected(ColorButtonScript colorButtonScript)
		{
			if (SelectedColor != null)
			{
				SelectedColor.IsSelected = false;
			}
			SelectedColor = colorButtonScript;
			if (SelectedColor != null)
			{
				SelectedColor.IsSelected = true;
			}
			this.ColorSelected?.Invoke(colorButtonScript);
		}
	}
}
