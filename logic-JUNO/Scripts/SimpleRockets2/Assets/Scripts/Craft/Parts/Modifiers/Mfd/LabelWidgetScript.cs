using System.Xml.Linq;
using Assets.Scripts.Ui.Inspector;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Craft;
using ModApi.Ui.Inspector;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class LabelWidgetScript : WidgetScript, ILabelWidget
	{
		private TextMeshProUGUI _label;

		private string _text = string.Empty;

		public bool AutoSize
		{
			get
			{
				return _label?.enableAutoSizing ?? false;
			}
			set
			{
				if (_label != null)
				{
					_label.enableAutoSizing = value;
					_label.fontSizeMin = 1f;
					_label.fontSizeMax = 256f;
				}
			}
		}

		public float FontSize
		{
			get
			{
				return _label?.fontSize ?? 0f;
			}
			set
			{
				_label.fontSize = value;
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

		public ElementAlignment TextAlignment
		{
			get
			{
				if (_label != null)
				{
					return LabelElement.TextAlignmentToTextMeshProAlignment(_label.alignment);
				}
				return ElementAlignment.Center;
			}
			set
			{
				if (_label != null)
				{
					_label.alignment = LabelElement.TextAlignmentToTextMeshProAlignment(value);
				}
			}
		}

		protected override Color WidgetColor
		{
			get
			{
				return _label.color;
			}
			set
			{
				_label.color = value;
			}
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.Initialize(mfdScript, name, widgetType);
			_label = GetComponent<TextMeshProUGUI>();
		}

		public override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			FontSize = xml.GetFloatAttribute("fontSize");
			Text = xml.GetStringAttribute("text");
			AutoSize = xml.GetBoolAttribute("autoSize");
			TextAlignment = xml.GetEnumAttribute("textAlignment", ElementAlignment.Center);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			WidgetScript.SetAttribute(xml, "fontSize", FontSize);
			WidgetScript.SetAttribute(xml, "text", Text);
			WidgetScript.SetAttribute(xml, "autoSize", AutoSize);
			WidgetScript.SetAttribute(xml, "textAlignment", TextAlignment);
		}

		protected override void SetRaycastTarget(bool enabled)
		{
			base.SetRaycastTarget(enabled);
			_label.raycastTarget = enabled;
		}

		private static TextAlignmentOptions TextAlignmentToTextMeshProAlignment(ElementAlignment alignment)
		{
			return alignment switch
			{
				ElementAlignment.Left => TextAlignmentOptions.Left, 
				ElementAlignment.Center => TextAlignmentOptions.Center, 
				ElementAlignment.Right => TextAlignmentOptions.Right, 
				ElementAlignment.TopLeft => TextAlignmentOptions.TopLeft, 
				ElementAlignment.TopCenter => TextAlignmentOptions.Top, 
				ElementAlignment.TopRight => TextAlignmentOptions.TopRight, 
				ElementAlignment.BottomLeft => TextAlignmentOptions.BottomLeft, 
				ElementAlignment.BottomCenter => TextAlignmentOptions.Bottom, 
				ElementAlignment.BottomRight => TextAlignmentOptions.BottomRight, 
				_ => TextAlignmentOptions.Left, 
			};
		}
	}
}
