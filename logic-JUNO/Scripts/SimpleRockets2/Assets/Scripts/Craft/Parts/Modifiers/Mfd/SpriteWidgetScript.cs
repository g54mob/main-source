using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Craft;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class SpriteWidgetScript : WidgetScript, ISpriteWidget
	{
		private string _icon;

		private Image _image;

		public float FillAmount
		{
			get
			{
				return _image?.fillAmount ?? 0f;
			}
			set
			{
				_image.fillAmount = value;
				if (_image.type != Image.Type.Filled)
				{
					_image.type = Image.Type.Filled;
					_image.fillMethod = Image.FillMethod.Horizontal;
				}
			}
		}

		public string FillMethod
		{
			get
			{
				Image image = _image;
				if ((object)image != null && image.type == Image.Type.Filled)
				{
					return _image.fillMethod.ToString();
				}
				return "None";
			}
			set
			{
				if (Enum.TryParse<Image.FillMethod>(value, out var result))
				{
					_image.type = Image.Type.Filled;
					_image.fillMethod = result;
				}
				else
				{
					_image.type = Image.Type.Sliced;
				}
			}
		}

		public string Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				if (_icon != value)
				{
					_icon = value;
					_image.sprite = value?.ToSprite();
				}
			}
		}

		protected override Color WidgetColor
		{
			get
			{
				return _image.color;
			}
			set
			{
				_image.color = value;
			}
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.Initialize(mfdScript, name, widgetType);
			_image = GetComponent<Image>();
		}

		public override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			FillAmount = xml.GetFloatAttribute("fillAmount");
			FillMethod = xml.GetStringAttribute("fillMethod");
			Icon = xml.GetStringAttribute("icon");
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			WidgetScript.SetAttribute(xml, "fillAmount", FillAmount);
			WidgetScript.SetAttribute(xml, "fillMethod", FillMethod);
			WidgetScript.SetAttribute(xml, "icon", Icon);
		}

		protected override void SetRaycastTarget(bool enabled)
		{
			base.SetRaycastTarget(enabled);
			_image.raycastTarget = enabled;
		}
	}
}
