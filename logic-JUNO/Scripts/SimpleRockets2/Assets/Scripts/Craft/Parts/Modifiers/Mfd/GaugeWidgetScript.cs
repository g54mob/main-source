using System.Xml.Linq;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Craft;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class GaugeWidgetScript : WidgetScript, IGaugeWidget
	{
		private Image _background;

		private Image _fill;

		private TextMeshProUGUI _label;

		private float _needleValue;

		private string _text = string.Empty;

		private float _value;

		public Vector3 BackgroundColor
		{
			get
			{
				return ToVector3(_background.color);
			}
			set
			{
				_background.color = ToColor(value);
			}
		}

		public Vector3 FillColor
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				_label.text = WidgetScript.ProcessNewlines(value);
			}
		}

		public Vector3 TextColor
		{
			get
			{
				return ToVector3(_label.color);
			}
			set
			{
				_label.color = ToColor(value);
			}
		}

		public float Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		protected override Color WidgetColor
		{
			get
			{
				return _fill.color;
			}
			set
			{
				_fill.color = value;
			}
		}

		private float FillValue
		{
			get
			{
				return _needleValue;
			}
			set
			{
				_needleValue = value;
				_fill.fillAmount = Mathf.Lerp(0.11f, 0.89f, value);
			}
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.Initialize(mfdScript, name, widgetType);
			_background = GetComponent<Image>();
			_label = GetComponentInChildren<TextMeshProUGUI>();
			_fill = Utilities.GetFirstChild<Image>("Fill", base.gameObject);
		}

		public override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Text = xml.GetStringAttribute("text");
			FillColor = xml.GetVector3Attribute("fillColor");
			BackgroundColor = xml.GetVector3Attribute("backgroundColor");
			TextColor = xml.GetVector3Attribute("textColor");
			Value = xml.GetFloatAttribute("value");
			FillValue = Value;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			WidgetScript.SetAttribute(xml, "text", Text);
			WidgetScript.SetAttribute(xml, "backgroundColor", Utilities.Vector3ToString(BackgroundColor));
			WidgetScript.SetAttribute(xml, "fillColor", Utilities.Vector3ToString(FillColor));
			WidgetScript.SetAttribute(xml, "textColor", Utilities.Vector3ToString(TextColor));
			WidgetScript.SetAttribute(xml, "value", Value);
		}

		protected override void SetRaycastTarget(bool enabled)
		{
			base.SetRaycastTarget(enabled);
			_label.raycastTarget = enabled;
		}

		protected virtual void Update()
		{
			FillValue = Mathf.Lerp(FillValue, Value, Time.unscaledDeltaTime * 2.5f);
		}

		private static Color ToColor(Vector3 v)
		{
			return new Color(v.x, v.y, v.z);
		}

		private static Vector3 ToVector3(Color c)
		{
			return new Vector3(c.r, c.g, c.b);
		}
	}
}
