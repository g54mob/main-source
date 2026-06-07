using System;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class InputSlider
	{
		private InputSliderScript _slider;

		public bool AllowNegative { get; set; }

		public XmlElement Element { get; private set; }

		public Func<float> GetAction { get; private set; }

		public bool IsUiCreated => _slider != null;

		public string Name { get; set; }

		public Action<float> SetAction { get; private set; }

		public InputSlider(Func<float> getAction, Action<float> setAction)
		{
			AllowNegative = true;
			GetAction = getAction;
			SetAction = setAction;
		}

		public void CreateUi(XmlElement xmlElement)
		{
			Element = xmlElement;
			_slider = xmlElement.gameObject.AddComponent<InputSliderScript>();
			_slider.Initialize(this);
		}

		public void DestroyUi()
		{
			UnityEngine.Object.Destroy(Element.gameObject);
			_slider = null;
			Element = null;
		}
	}
}
